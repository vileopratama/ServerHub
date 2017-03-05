using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerHub
{
	public partial class UxMain : Form
	{
		public UxMain()
		{
			InitializeComponent();
		}
        
		private void btnReplication_Click_2(object sender, EventArgs e)
		{
			Container.Controls.Clear();
			Container.Visible = true;
			Addons.Replication.UXReplicationView replication = new Addons.Replication.UXReplicationView();
			replication.TopLevel = false;
			replication.FormBorderStyle = FormBorderStyle.None;
			Container.Controls.Add(replication);
			replication.Visible = true;
		}

		private void btnSetting_Click(object sender, EventArgs e)
		{
			Container.Controls.Clear();
			Container.Visible = true;
			Addons.DatabaseSetting.UXDatabaseSettingView databaseSetting = new Addons.DatabaseSetting.UXDatabaseSettingView();
			databaseSetting.TopLevel = false;
			databaseSetting.FormBorderStyle = FormBorderStyle.None;
			Container.Controls.Add(databaseSetting);
			databaseSetting.Visible = true;
		}

        private void UxMain_Load(object sender, EventArgs e)
        {
            this.btnReplication_Click_2(sender, e);
        }

        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
