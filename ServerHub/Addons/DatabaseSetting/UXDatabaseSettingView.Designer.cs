namespace ServerHub.Addons.DatabaseSetting
{
	partial class UXDatabaseSettingView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UXDatabaseSettingView));
			this.cbGroup = new ns1.BunifuDropdown();
			this.bunifuCustomLabel1 = new ns1.BunifuCustomLabel();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.bunifuCustomLabel2 = new ns1.BunifuCustomLabel();
			this.txtMySqlServer = new ns1.BunifuMaterialTextbox();
			this.txtSqlServer = new ns1.BunifuMaterialTextbox();
			this.txtSqlPort = new ns1.BunifuMaterialTextbox();
			this.txtMySqlPort = new ns1.BunifuMaterialTextbox();
			this.bunifuCustomLabel3 = new ns1.BunifuCustomLabel();
			this.txtSqlUser = new ns1.BunifuMaterialTextbox();
			this.txtMySqlUser = new ns1.BunifuMaterialTextbox();
			this.bunifuCustomLabel4 = new ns1.BunifuCustomLabel();
			this.txtSqlPassword = new ns1.BunifuMaterialTextbox();
			this.txtMySqlPassword = new ns1.BunifuMaterialTextbox();
			this.bunifuCustomLabel5 = new ns1.BunifuCustomLabel();
			this.btnSave = new ns1.BunifuFlatButton();
			this.btnTestConnection = new ns1.BunifuFlatButton();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			this.SuspendLayout();
			// 
			// cbGroup
			// 
			this.cbGroup.BackColor = System.Drawing.Color.Transparent;
			this.cbGroup.BorderRadius = 3;
			this.cbGroup.ForeColor = System.Drawing.Color.White;
			this.cbGroup.Items = new string[] {
        "KAP",
        "BKI",
        "KJPP"};
			this.cbGroup.Location = new System.Drawing.Point(80, 12);
			this.cbGroup.Name = "cbGroup";
			this.cbGroup.NomalColor = System.Drawing.Color.Gainsboro;
			this.cbGroup.onHoverColor = System.Drawing.Color.DarkGray;
			this.cbGroup.selectedIndex = -1;
			this.cbGroup.Size = new System.Drawing.Size(469, 35);
			this.cbGroup.TabIndex = 4;
			// 
			// bunifuCustomLabel1
			// 
			this.bunifuCustomLabel1.AutoSize = true;
			this.bunifuCustomLabel1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bunifuCustomLabel1.Location = new System.Drawing.Point(12, 24);
			this.bunifuCustomLabel1.Name = "bunifuCustomLabel1";
			this.bunifuCustomLabel1.Size = new System.Drawing.Size(49, 17);
			this.bunifuCustomLabel1.TabIndex = 5;
			this.bunifuCustomLabel1.Text = "Group";
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(110, 69);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(140, 124);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			// 
			// pictureBox2
			// 
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(338, 69);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(164, 124);
			this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox2.TabIndex = 7;
			this.pictureBox2.TabStop = false;
			// 
			// bunifuCustomLabel2
			// 
			this.bunifuCustomLabel2.AutoSize = true;
			this.bunifuCustomLabel2.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bunifuCustomLabel2.Location = new System.Drawing.Point(12, 230);
			this.bunifuCustomLabel2.Name = "bunifuCustomLabel2";
			this.bunifuCustomLabel2.Size = new System.Drawing.Size(46, 17);
			this.bunifuCustomLabel2.TabIndex = 8;
			this.bunifuCustomLabel2.Text = "Server";
			// 
			// txtMySqlServer
			// 
			this.txtMySqlServer.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMySqlServer.Font = new System.Drawing.Font("Century Gothic", 9.75F);
			this.txtMySqlServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtMySqlServer.HintForeColor = System.Drawing.Color.Empty;
			this.txtMySqlServer.HintText = "";
			this.txtMySqlServer.isPassword = false;
			this.txtMySqlServer.LineFocusedColor = System.Drawing.Color.Blue;
			this.txtMySqlServer.LineIdleColor = System.Drawing.Color.Gray;
			this.txtMySqlServer.LineMouseHoverColor = System.Drawing.Color.Blue;
			this.txtMySqlServer.LineThickness = 1;
			this.txtMySqlServer.Location = new System.Drawing.Point(91, 213);
			this.txtMySqlServer.Margin = new System.Windows.Forms.Padding(4);
			this.txtMySqlServer.Name = "txtMySqlServer";
			this.txtMySqlServer.Size = new System.Drawing.Size(195, 44);
			this.txtMySqlServer.TabIndex = 9;
			this.txtMySqlServer.Text = "Localhost";
			this.txtMySqlServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			// 
			// txtSqlServer
			// 
			this.txtSqlServer.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSqlServer.Font = new System.Drawing.Font("Century Gothic", 9.75F);
			this.txtSqlServer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtSqlServer.HintForeColor = System.Drawing.Color.Empty;
			this.txtSqlServer.HintText = "";
			this.txtSqlServer.isPassword = false;
			this.txtSqlServer.LineFocusedColor = System.Drawing.Color.Blue;
			this.txtSqlServer.LineIdleColor = System.Drawing.Color.Gray;
			this.txtSqlServer.LineMouseHoverColor = System.Drawing.Color.Blue;
			this.txtSqlServer.LineThickness = 1;
			this.txtSqlServer.Location = new System.Drawing.Point(323, 213);
			this.txtSqlServer.Margin = new System.Windows.Forms.Padding(4);
			this.txtSqlServer.Name = "txtSqlServer";
			this.txtSqlServer.Size = new System.Drawing.Size(195, 44);
			this.txtSqlServer.TabIndex = 10;
			this.txtSqlServer.Text = "Localhost";
			this.txtSqlServer.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			// 
			// txtSqlPort
			// 
			this.txtSqlPort.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSqlPort.Font = new System.Drawing.Font("Century Gothic", 9.75F);
			this.txtSqlPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtSqlPort.HintForeColor = System.Drawing.Color.Empty;
			this.txtSqlPort.HintText = "";
			this.txtSqlPort.isPassword = false;
			this.txtSqlPort.LineFocusedColor = System.Drawing.Color.Blue;
			this.txtSqlPort.LineIdleColor = System.Drawing.Color.Gray;
			this.txtSqlPort.LineMouseHoverColor = System.Drawing.Color.Blue;
			this.txtSqlPort.LineThickness = 1;
			this.txtSqlPort.Location = new System.Drawing.Point(323, 265);
			this.txtSqlPort.Margin = new System.Windows.Forms.Padding(4);
			this.txtSqlPort.Name = "txtSqlPort";
			this.txtSqlPort.Size = new System.Drawing.Size(195, 44);
			this.txtSqlPort.TabIndex = 13;
			this.txtSqlPort.Text = "3306";
			this.txtSqlPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			// 
			// txtMySqlPort
			// 
			this.txtMySqlPort.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMySqlPort.Font = new System.Drawing.Font("Century Gothic", 9.75F);
			this.txtMySqlPort.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtMySqlPort.HintForeColor = System.Drawing.Color.Empty;
			this.txtMySqlPort.HintText = "";
			this.txtMySqlPort.isPassword = false;
			this.txtMySqlPort.LineFocusedColor = System.Drawing.Color.Blue;
			this.txtMySqlPort.LineIdleColor = System.Drawing.Color.Gray;
			this.txtMySqlPort.LineMouseHoverColor = System.Drawing.Color.Blue;
			this.txtMySqlPort.LineThickness = 1;
			this.txtMySqlPort.Location = new System.Drawing.Point(91, 265);
			this.txtMySqlPort.Margin = new System.Windows.Forms.Padding(4);
			this.txtMySqlPort.Name = "txtMySqlPort";
			this.txtMySqlPort.Size = new System.Drawing.Size(195, 44);
			this.txtMySqlPort.TabIndex = 12;
			this.txtMySqlPort.Text = "1433";
			this.txtMySqlPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			// 
			// bunifuCustomLabel3
			// 
			this.bunifuCustomLabel3.AutoSize = true;
			this.bunifuCustomLabel3.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bunifuCustomLabel3.Location = new System.Drawing.Point(12, 282);
			this.bunifuCustomLabel3.Name = "bunifuCustomLabel3";
			this.bunifuCustomLabel3.Size = new System.Drawing.Size(34, 17);
			this.bunifuCustomLabel3.TabIndex = 11;
			this.bunifuCustomLabel3.Text = "Port";
			// 
			// txtSqlUser
			// 
			this.txtSqlUser.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSqlUser.Font = new System.Drawing.Font("Century Gothic", 9.75F);
			this.txtSqlUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtSqlUser.HintForeColor = System.Drawing.Color.Empty;
			this.txtSqlUser.HintText = "";
			this.txtSqlUser.isPassword = false;
			this.txtSqlUser.LineFocusedColor = System.Drawing.Color.Blue;
			this.txtSqlUser.LineIdleColor = System.Drawing.Color.Gray;
			this.txtSqlUser.LineMouseHoverColor = System.Drawing.Color.Blue;
			this.txtSqlUser.LineThickness = 1;
			this.txtSqlUser.Location = new System.Drawing.Point(323, 317);
			this.txtSqlUser.Margin = new System.Windows.Forms.Padding(4);
			this.txtSqlUser.Name = "txtSqlUser";
			this.txtSqlUser.Size = new System.Drawing.Size(195, 44);
			this.txtSqlUser.TabIndex = 16;
			this.txtSqlUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			// 
			// txtMySqlUser
			// 
			this.txtMySqlUser.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMySqlUser.Font = new System.Drawing.Font("Century Gothic", 9.75F);
			this.txtMySqlUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtMySqlUser.HintForeColor = System.Drawing.Color.Empty;
			this.txtMySqlUser.HintText = "";
			this.txtMySqlUser.isPassword = false;
			this.txtMySqlUser.LineFocusedColor = System.Drawing.Color.Blue;
			this.txtMySqlUser.LineIdleColor = System.Drawing.Color.Gray;
			this.txtMySqlUser.LineMouseHoverColor = System.Drawing.Color.Blue;
			this.txtMySqlUser.LineThickness = 1;
			this.txtMySqlUser.Location = new System.Drawing.Point(88, 317);
			this.txtMySqlUser.Margin = new System.Windows.Forms.Padding(4);
			this.txtMySqlUser.Name = "txtMySqlUser";
			this.txtMySqlUser.Size = new System.Drawing.Size(195, 44);
			this.txtMySqlUser.TabIndex = 15;
			this.txtMySqlUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			// 
			// bunifuCustomLabel4
			// 
			this.bunifuCustomLabel4.AutoSize = true;
			this.bunifuCustomLabel4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bunifuCustomLabel4.Location = new System.Drawing.Point(12, 334);
			this.bunifuCustomLabel4.Name = "bunifuCustomLabel4";
			this.bunifuCustomLabel4.Size = new System.Drawing.Size(33, 17);
			this.bunifuCustomLabel4.TabIndex = 14;
			this.bunifuCustomLabel4.Text = "User";
			// 
			// txtSqlPassword
			// 
			this.txtSqlPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtSqlPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F);
			this.txtSqlPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtSqlPassword.HintForeColor = System.Drawing.Color.Empty;
			this.txtSqlPassword.HintText = "";
			this.txtSqlPassword.isPassword = false;
			this.txtSqlPassword.LineFocusedColor = System.Drawing.Color.Blue;
			this.txtSqlPassword.LineIdleColor = System.Drawing.Color.Gray;
			this.txtSqlPassword.LineMouseHoverColor = System.Drawing.Color.Blue;
			this.txtSqlPassword.LineThickness = 1;
			this.txtSqlPassword.Location = new System.Drawing.Point(323, 369);
			this.txtSqlPassword.Margin = new System.Windows.Forms.Padding(4);
			this.txtSqlPassword.Name = "txtSqlPassword";
			this.txtSqlPassword.Size = new System.Drawing.Size(195, 44);
			this.txtSqlPassword.TabIndex = 19;
			this.txtSqlPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			// 
			// txtMySqlPassword
			// 
			this.txtMySqlPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtMySqlPassword.Font = new System.Drawing.Font("Century Gothic", 9.75F);
			this.txtMySqlPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.txtMySqlPassword.HintForeColor = System.Drawing.Color.Empty;
			this.txtMySqlPassword.HintText = "";
			this.txtMySqlPassword.isPassword = false;
			this.txtMySqlPassword.LineFocusedColor = System.Drawing.Color.Blue;
			this.txtMySqlPassword.LineIdleColor = System.Drawing.Color.Gray;
			this.txtMySqlPassword.LineMouseHoverColor = System.Drawing.Color.Blue;
			this.txtMySqlPassword.LineThickness = 1;
			this.txtMySqlPassword.Location = new System.Drawing.Point(88, 369);
			this.txtMySqlPassword.Margin = new System.Windows.Forms.Padding(4);
			this.txtMySqlPassword.Name = "txtMySqlPassword";
			this.txtMySqlPassword.Size = new System.Drawing.Size(198, 44);
			this.txtMySqlPassword.TabIndex = 18;
			this.txtMySqlPassword.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			// 
			// bunifuCustomLabel5
			// 
			this.bunifuCustomLabel5.AutoSize = true;
			this.bunifuCustomLabel5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.bunifuCustomLabel5.Location = new System.Drawing.Point(12, 386);
			this.bunifuCustomLabel5.Name = "bunifuCustomLabel5";
			this.bunifuCustomLabel5.Size = new System.Drawing.Size(69, 17);
			this.bunifuCustomLabel5.TabIndex = 17;
			this.bunifuCustomLabel5.Text = "Password";
			// 
			// btnSave
			// 
			this.btnSave.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
			this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
			this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnSave.BorderRadius = 5;
			this.btnSave.ButtonText = "Save";
			this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnSave.DisabledColor = System.Drawing.Color.Gray;
			this.btnSave.Iconcolor = System.Drawing.Color.Transparent;
			this.btnSave.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnSave.Iconimage")));
			this.btnSave.Iconimage_right = null;
			this.btnSave.Iconimage_right_Selected = null;
			this.btnSave.Iconimage_Selected = null;
			this.btnSave.IconMarginLeft = 0;
			this.btnSave.IconMarginRight = 0;
			this.btnSave.IconRightVisible = true;
			this.btnSave.IconRightZoom = 0D;
			this.btnSave.IconVisible = true;
			this.btnSave.IconZoom = 90D;
			this.btnSave.IsTab = false;
			this.btnSave.Location = new System.Drawing.Point(399, 439);
			this.btnSave.Name = "btnSave";
			this.btnSave.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
			this.btnSave.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
			this.btnSave.OnHoverTextColor = System.Drawing.Color.White;
			this.btnSave.selected = false;
			this.btnSave.Size = new System.Drawing.Size(119, 48);
			this.btnSave.TabIndex = 20;
			this.btnSave.Text = "Save";
			this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnSave.Textcolor = System.Drawing.Color.White;
			this.btnSave.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnTestConnection
			// 
			this.btnTestConnection.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(139)))), ((int)(((byte)(87)))));
			this.btnTestConnection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
			this.btnTestConnection.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.btnTestConnection.BorderRadius = 5;
			this.btnTestConnection.ButtonText = "Test Connection";
			this.btnTestConnection.Cursor = System.Windows.Forms.Cursors.Hand;
			this.btnTestConnection.DisabledColor = System.Drawing.Color.Gray;
			this.btnTestConnection.Iconcolor = System.Drawing.Color.Transparent;
			this.btnTestConnection.Iconimage = ((System.Drawing.Image)(resources.GetObject("btnTestConnection.Iconimage")));
			this.btnTestConnection.Iconimage_right = null;
			this.btnTestConnection.Iconimage_right_Selected = null;
			this.btnTestConnection.Iconimage_Selected = null;
			this.btnTestConnection.IconMarginLeft = 0;
			this.btnTestConnection.IconMarginRight = 0;
			this.btnTestConnection.IconRightVisible = true;
			this.btnTestConnection.IconRightZoom = 0D;
			this.btnTestConnection.IconVisible = true;
			this.btnTestConnection.IconZoom = 90D;
			this.btnTestConnection.IsTab = false;
			this.btnTestConnection.Location = new System.Drawing.Point(238, 439);
			this.btnTestConnection.Name = "btnTestConnection";
			this.btnTestConnection.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(112)))), ((int)(((byte)(168)))));
			this.btnTestConnection.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(129)))), ((int)(((byte)(77)))));
			this.btnTestConnection.OnHoverTextColor = System.Drawing.Color.White;
			this.btnTestConnection.selected = false;
			this.btnTestConnection.Size = new System.Drawing.Size(155, 48);
			this.btnTestConnection.TabIndex = 21;
			this.btnTestConnection.Text = "Test Connection";
			this.btnTestConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnTestConnection.Textcolor = System.Drawing.Color.White;
			this.btnTestConnection.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.btnTestConnection.Click += new System.EventHandler(this.btnTestConnection_Click);
			// 
			// UXDatabaseSettingView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(569, 499);
			this.Controls.Add(this.btnTestConnection);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.txtSqlPassword);
			this.Controls.Add(this.txtMySqlPassword);
			this.Controls.Add(this.bunifuCustomLabel5);
			this.Controls.Add(this.txtSqlUser);
			this.Controls.Add(this.txtMySqlUser);
			this.Controls.Add(this.bunifuCustomLabel4);
			this.Controls.Add(this.txtSqlPort);
			this.Controls.Add(this.txtMySqlPort);
			this.Controls.Add(this.bunifuCustomLabel3);
			this.Controls.Add(this.txtSqlServer);
			this.Controls.Add(this.txtMySqlServer);
			this.Controls.Add(this.bunifuCustomLabel2);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.bunifuCustomLabel1);
			this.Controls.Add(this.cbGroup);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "UXDatabaseSettingView";
			this.Text = "UXDatabaseSettingView";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.UXDatabaseSettingView_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private ns1.BunifuDropdown cbGroup;
        private ns1.BunifuCustomLabel bunifuCustomLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ns1.BunifuCustomLabel bunifuCustomLabel2;
        private ns1.BunifuMaterialTextbox txtMySqlServer;
        private ns1.BunifuMaterialTextbox txtSqlServer;
        private ns1.BunifuMaterialTextbox txtSqlPort;
        private ns1.BunifuMaterialTextbox txtMySqlPort;
        private ns1.BunifuCustomLabel bunifuCustomLabel3;
        private ns1.BunifuMaterialTextbox txtSqlUser;
        private ns1.BunifuMaterialTextbox txtMySqlUser;
        private ns1.BunifuCustomLabel bunifuCustomLabel4;
        private ns1.BunifuMaterialTextbox txtSqlPassword;
        private ns1.BunifuMaterialTextbox txtMySqlPassword;
        private ns1.BunifuCustomLabel bunifuCustomLabel5;
        private ns1.BunifuFlatButton btnSave;
        private ns1.BunifuFlatButton btnTestConnection;
    }
}