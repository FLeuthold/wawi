// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;




string connStr = "Data Source=.;Initial Catalog=wawientity027799;Integrated Security=True;TrustServerCertificate=True";

string folderPath = @"../../../"; // dein Verzeichnis mit den .txt-Dateien

foreach (var file in Directory.GetFiles(folderPath, "*.txt"))
{
    // Tabellen aus Dateien einlesen
    var tableDef = SchemaGenerator.Parse(file);
    string sqlTable = SchemaGenerator.GenerateCreateTable(tableDef);
    SchemaGenerator.ExecuteSql(connStr, sqlTable);
    Console.WriteLine($"Tabelle {tableDef.Name} erstellt/überprüft.");
}


// SQL erzeugen
/*string[] lines = File.ReadAllLines("mm.rel");
foreach (var line in lines)
{
    var parts = line.Split(';').Select(p => p.Trim()).ToArray();
    string sqlJoin = SchemaGenerator.GenerateManyToMany("Book", "Author");
}
    

SchemaGenerator.ExecuteSql(connStr, sqlJoin);*/


string[] relLines = File.ReadAllLines(folderPath + "mm.rel");
var sqlStatements = SchemaGenerator.ParseRelations(relLines);

using (var conn = new SqlConnection(connStr))
{
    conn.Open();
    foreach (var sql in sqlStatements)
    {
        using (var cmd = new SqlCommand(sql, conn))
        {
            cmd.ExecuteNonQuery();
        }
    }
}

Console.WriteLine("Schema erfolgreich erstellt!");



public class TableDef
{
    public string Name { get; set; }
    public List<(string Column, string Type)> Columns { get; set; } = new();
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

    public static string GenerateManyToMany(string tableA, string tableB)
    {
        var joinTable = tableA + tableB;
        return $@"
IF OBJECT_ID('{joinTable}', 'U') IS NULL
CREATE TABLE {joinTable} (
    {tableA}Id INT NOT NULL,
    {tableB}Id INT NOT NULL,
    CONSTRAINT PK_{joinTable} PRIMARY KEY ({tableA}Id, {tableB}Id),
    CONSTRAINT FK_{joinTable}_{tableA} FOREIGN KEY ({tableA}Id) REFERENCES {tableA}(Id),
    CONSTRAINT FK_{joinTable}_{tableB} FOREIGN KEY ({tableB}Id) REFERENCES {tableB}(Id)
);";
    }

    public static void ExecuteSql(string connectionString, string sql)
    {
        using var conn = new SqlConnection(connectionString);
        conn.Open();
        using var cmd = new SqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
    }



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

