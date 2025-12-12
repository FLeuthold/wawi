using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchemaGenerator48
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string folderPath = @"./config/"; // dein Verzeichnis mit den .txt-Dateien

            if (!File.Exists("conn.conf"))
            {
                folderPath = @"../../config/";
            }


            var connStr = File.ReadAllLines(folderPath + "conn.conf")[0];
            var builder = new SqlConnectionStringBuilder(connStr);
            string dbName = builder.InitialCatalog;

            // Verbindung zur master-DB
            builder.InitialCatalog = "master";

            using (var conn = new SqlConnection(builder.ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand($@"
IF DB_ID('{dbName}') IS NULL
    CREATE DATABASE [{dbName}];", conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            using (var conn = new SqlConnection(connStr))
            {
                conn.Open();
                using (var cmd = new SqlCommand())
                {


                    cmd.Connection = conn;

                    //DbHelper.EnsureDatabase(cmd);
                    foreach (var file in Directory.GetFiles(folderPath, "*.txt"))
                    {
                        // Tabellen aus Dateien einlesen
                        var tableDef = SchemaGenerator.Parse(file);
                        string sqlTable = SchemaGenerator.GenerateCreateTable(tableDef);
                        cmd.CommandText = sqlTable;
                        cmd.ExecuteNonQuery();
                        Console.WriteLine($"Tabelle {tableDef.Name} erstellt/überprüft.");
                    }



                    string[] relLines = File.ReadAllLines(folderPath + "mm.rel");
                    var sqlStatements = SchemaGenerator.ParseRelations(relLines);


                    foreach (var sql in sqlStatements)
                    {
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Schema erfolgreich erstellt!");
                    

                    //DbHelper.EnsureDatabase(connStr, conn);

                    // Migrations-Tabelle sicherstellen
                    string ensureTable = @"
IF OBJECT_ID('dbo.Migrations', 'U') IS NULL
CREATE TABLE dbo.Migrations (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(200) NOT NULL,
    AppliedAt DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME()
);";
                    cmd.CommandText = ensureTable;
                    cmd.ExecuteNonQuery();


                    // Alle Migrationsordner holen und numerisch sortieren
                    var migrationDirs = Directory.GetDirectories(folderPath + "migrations/", "migration*")
                                             .OrderBy(d => d, new MigrationComparer())
                                             .ToList();

                    foreach (var dir in migrationDirs)
                    {
                        string migrationName = Path.GetFileName(dir);

                        // Prüfen ob schon angewandt
                        cmd.CommandText = "SELECT COUNT(*) FROM dbo.Migrations WHERE Name = @Name";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Name", migrationName);
                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            Console.WriteLine($"{migrationName} already applied.");
                            continue;
                        }

                        Console.WriteLine($"Applying {migrationName}...");

                        // ALTER-Dateien
                        string alterDir = Path.Combine(dir, "alter");

                        if (Directory.Exists(alterDir))
                        {
                            foreach (var file in Directory.GetFiles(alterDir, "*.txt"))
                            {
                                string tableName = Path.GetFileNameWithoutExtension(file);
                                foreach (var sql in SchemaGenerator.ParseAlterFile(tableName, file))
                                {
                                    cmd.CommandText = sql;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // ADD-Dateien
                        string addDir = Path.Combine(dir, "add");
                        if (Directory.Exists(addDir))
                        {
                            cmd.Connection = conn;
                            foreach (var file in Directory.GetFiles(addDir, "*.txt"))
                            {
                                string tableName = Path.GetFileNameWithoutExtension(file);
                                foreach (var sql in SchemaGenerator.ParseAddFile(tableName, file))
                                {
                                    cmd.CommandText = sql;
                                    cmd.ExecuteNonQuery();
                                }
                            }
                        }

                        // Migration protokollieren
                        string insertSql = "INSERT INTO dbo.Migrations (Name) VALUES (@Name)";
                        cmd.CommandText = insertSql;
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@Name", migrationName);
                        cmd.ExecuteNonQuery();
                    }
                    //MigrationRunner.Run(connStr, folderPath + "migrations/");
                }
            }



            Console.ReadLine();

        }
    }

    public class TableDef
    {
        public string Name { get; set; }
        public List<(string Column, string Type)> Columns { get; set; } = new List<(string Column, string Type)>();
    }

    public static class SchemaGenerator
    {

        public static TableDef Parse(string filename)
        {
            string[] lines = File.ReadAllLines(filename);
            var table = new TableDef { Name = Path.GetFileNameWithoutExtension(filename) }; //
            foreach (var line in lines)
            {
                var parts = line.Split(';').Select(p => p.Trim()).ToArray();
                if (parts.Length == 2)
                    table.Columns.Add((parts[0], parts[1]));
            }
            return table;
        }

        public static IEnumerable<string> ParseAlterFile(string tableName, string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1); // skip header
            foreach (var line in lines)
            {
                var parts = line.Split(';').Select(p => p.Trim()).ToArray();
                string nameBefore = parts[0];
                string typeBefore = parts[1];
                string nameAfter = parts[2];
                string typeAfter = parts[3];

                if (nameBefore == nameAfter)
                {
                    yield return $"ALTER TABLE {tableName} ALTER COLUMN {nameAfter} {typeAfter};";
                }
                else
                {
                    yield return $"EXEC sp_rename '{tableName}.{nameBefore}', '{nameAfter}', 'COLUMN';";
                    yield return $"ALTER TABLE {tableName} ALTER COLUMN {nameAfter} {typeAfter};";
                }
            }
        }

        public static IEnumerable<string> ParseAddFile(string tableName, string filePath)
        {
            var lines = File.ReadAllLines(filePath).Skip(1); // skip header
            foreach (var line in lines)
            {
                var parts = line.Split(',').Select(p => p.Trim()).ToArray();
                string name = parts[0];
                string type = parts[1];
                yield return $"ALTER TABLE {tableName} ADD {name} {type};";
            }
        }
        public static string GenerateCreateTable(TableDef table)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"IF OBJECT_ID('{table.Name}', 'U') IS NULL");
            sb.AppendLine($"CREATE TABLE {table.Name} (");
            sb.AppendLine("    Id INT IDENTITY PRIMARY KEY,");
            foreach (var col in table.Columns)
            {
                sb.AppendLine($"    {col.Column} {col.Type} NOT NULL,");
            }
            sb.Length -= 3; // letztes Komma entfernen
            sb.AppendLine("\n);");
            return sb.ToString();
        }


        /**/



        public static IEnumerable<string> ParseRelations(string[] lines)
        {
            foreach (var line in lines)
            {
                var parts = line.Split(',');
                int type = int.Parse(parts[0].Trim());
                var tables = parts[1].Split(';').Select(t => t.Trim()).ToList();

                if (type == 1)
                {
                    // m:n oder n:n → Zwischentabelle
                    string joinTable = string.Join("", tables);
                    var sb = new StringBuilder();
                    sb.AppendLine($"IF OBJECT_ID('{joinTable}', 'U') IS NULL");
                    sb.AppendLine($"CREATE TABLE {joinTable} (");

                    // Spalten für alle Tabellen
                    for (int i = 0; i < tables.Count; i++)
                    {
                        sb.AppendLine($"    {tables[i]}Id INT NOT NULL,");
                    }

                    // Primärschlüssel über alle Spalten
                    sb.AppendLine($"    CONSTRAINT PK_{joinTable} PRIMARY KEY ({string.Join(", ", tables.Select(t => t + "Id"))}),");

                    // Fremdschlüssel
                    foreach (var t in tables)
                    {
                        sb.AppendLine($"    CONSTRAINT FK_{joinTable}_{t} FOREIGN KEY ({t}Id) REFERENCES {t}(Id),");
                    }

                    sb.Length -= 3; // letztes Komma entfernen
                    sb.AppendLine("\n);");
                    yield return sb.ToString();
                }
                else if (type == 0 && tables.Count == 2)
                {
                    // 1:n → ALTER TABLE
                    string sql = $@"
IF COL_LENGTH('{tables[0]}', '{tables[1]}Id') IS NULL
    ALTER TABLE {tables[0]} ADD {tables[1]}Id INT NULL
    CONSTRAINT FK_{tables[0]}_{tables[1]} FOREIGN KEY ({tables[1]}Id) REFERENCES {tables[1]}(Id);";
                    yield return sql;
                }
            }
        }

    }

    // Hilfsklasse für numerische Sortierung
    public class MigrationComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int numX = ExtractNumber(Path.GetFileName(x));
            int numY = ExtractNumber(Path.GetFileName(y));
            return numX.CompareTo(numY);
        }

        private int ExtractNumber(string name)
        {
            string digits = new string(name.Where(char.IsDigit).ToArray());
            return string.IsNullOrEmpty(digits) ? 0 : int.Parse(digits);
        }
    }
}
