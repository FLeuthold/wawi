using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wawi
{
    internal static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DerContext>());
            using (var context = new DerContext())
            {
                var configuration = new wawi.Migrations.Configuration(); // deine Migrations-Konfigurationsklasse
                var migrator = new DbMigrator(configuration);
                //migrator.Update(); // führt alle ausstehenden Migrationen aus
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());
        }
    }
}
