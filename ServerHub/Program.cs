using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServerHub.Classes;

namespace ServerHub
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
            BindingSQLServerDatabase();
            BindingMySQLServerDatabase();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new UxMain());
		}

        static void BindingSQLServerDatabase()
        {
            INI ini = new INI(App.baseDirectory() + "/config.ini");
			DB.Group = ini.Read("Group", "Name");
			DB.SqlServer = ini.Read("SQL Server", "Server");
            DB.SqlPort = ini.Read("SQL Server", "Port");
            DB.SqlDatabase = ini.Read("SQL Server", "Database");
            DB.SqlUser = ini.Read("SQL Server", "User");
            DB.SqlPassword = ini.Read("SQL Server", "Password");
        }

        static void BindingMySQLServerDatabase()
        {
            INI ini = new INI(App.baseDirectory() + "/config.ini");
            DB.MySqlServer = ini.Read("MySQL Server", "Server");
            DB.MySqlPort = ini.Read("MySQL Server", "Port");
            DB.MySqlDatabase = ini.Read("MySQL Server", "Database");
            DB.MySqlUser = ini.Read("MySQL Server", "User");
            DB.MySqlPassword = ini.Read("MySQL Server", "Password");
        }
    }
}
