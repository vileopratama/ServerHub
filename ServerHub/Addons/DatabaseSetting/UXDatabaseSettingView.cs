﻿using ServerHub.Classes;
using System;
using System.Windows.Forms;

namespace ServerHub.Addons.DatabaseSetting
{
	public partial class UXDatabaseSettingView : Form
	{
		public UXDatabaseSettingView()
		{
			InitializeComponent();
		}

        private void BindingSQLServerDatabase()
        {
            INI ini = new INI(App.baseDirectory() + "/config.ini");
			DB.Group = ini.Read("Group", "Name");
			DB.SqlServer = ini.Read("SQL Server", "Server");
            DB.SqlPort = ini.Read("SQL Server", "Port");
            DB.SqlDatabase = ini.Read("SQL Server", "Database");
            DB.SqlUser = ini.Read("SQL Server", "User");
            DB.SqlPassword = ini.Read("SQL Server", "Password");
        }

        private void BindingMySQLServerDatabase()
        {
            INI ini = new INI(App.baseDirectory() + "/config.ini");
            DB.MySqlServer = ini.Read("MySQL Server", "Server");
            DB.MySqlPort = ini.Read("MySQL Server", "Port");
            DB.MySqlDatabase = ini.Read("MySQL Server", "Database");
            DB.MySqlUser = ini.Read("MySQL Server", "User");
            DB.MySqlPassword = ini.Read("MySQL Server", "Password");
        }

        private void BindingSQLServeField()
        {
			int group;
			if (DB.Group == "KJPP")
				group = 2;
			else if (DB.Group == "BKI")
				group = 1;
			else
				group = 0; 

			this.cbGroup.selectedIndex = group;
            this.txtSqlServer.Text = DB.SqlServer;
            this.txtSqlPort.Text = DB.SqlPort;
            this.txtSqlUser.Text = DB.SqlUser;
            this.txtSqlPassword.Text = DB.SqlPassword;
        }

        private void BindingMySQLServeField()
        {
            this.txtMySqlServer.Text = DB.MySqlServer;
            this.txtMySqlPort.Text = DB.MySqlPort;
            this.txtMySqlUser.Text = DB.MySqlUser;
            this.txtMySqlPassword.Text = DB.MySqlPassword;
        }


        private void UXDatabaseSettingView_Load(object sender, EventArgs e)
        {
            this.BindingSQLServerDatabase();
            this.BindingSQLServeField();
            this.BindingMySQLServerDatabase();
            this.BindingMySQLServeField();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
			string sqlServer;
			string mysqlServer;
			string group = cbGroup.selectedValue.ToString();
			if (group == "BKI")
			{
				sqlServer = "AR_BKI";
				mysqlServer = "k0455101_bki_finance";
			}
			else if (group == "KJPP")
			{
				sqlServer = "AR_KJPP";
				mysqlServer = "k0455101_kjpp_finance";
			}
			else
			{
				sqlServer = "AR";
				mysqlServer = "k0455101_kap_finance";
			}

			
			INI ini = new INI(App.baseDirectory() + "/config.ini");
			ini.Write("Group", "Name", group);

			ini.Write("SQL Server", "Server", txtSqlServer.Text);
            ini.Write("SQL Server", "Port", txtSqlPort.Text);
            ini.Write("SQL Server", "Database", sqlServer);
            ini.Write("SQL Server", "User", txtSqlUser.Text);
            ini.Write("SQL Server", "Password", txtSqlPassword.Text);

            ini.Write("MySQL Server", "Server", txtMySqlServer.Text);
            ini.Write("MySQL Server", "Port", txtMySqlPort.Text);
            ini.Write("MySQL Server", "Database", mysqlServer);
            ini.Write("MySQL Server", "User", txtMySqlUser.Text);
            ini.Write("MySQL Server", "Password", txtMySqlPassword.Text);

			//binding all database configuration
			this.BindingSQLServerDatabase();
			this.BindingMySQLServerDatabase();

            MessageBox.Show("Save configuration successfully ?", "Database Configuration",
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnTestConnection_Click(object sender, EventArgs e)
        {
            DB.SqlConnect();
            if (DB.isSqlConnected == false)
            {
                MessageBox.Show("SQL Server Error Connection,please check your configuration ?", "SQL Server Database Configuration",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("SQL Server Successfull connection to database ?", "SQL Server Database Configuration",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }

            DB.MySqlConnect();
            if (DB.isMySqlConnected == false)
            {
                MessageBox.Show("MySQL Server Error Connection,please check your configuration ?", "MySQL Server Database Configuration",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("MySQL Server Successfull connection to database ?", "MySQL Server Database Configuration",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}
