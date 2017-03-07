using System;
using System.Threading;
using System.Windows.Forms;
using ServerHub.Classes;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;
using MySql.Data.MySqlClient;

namespace ServerHub.Addons.Replication
{
  
    public partial class UXReplicationView : Form
	{
        int TotalRecords = 0;
        int Max = 0;
        int Result = 0;
        string Text = "";
        int i;
        SqlCommand cmd;
        SqlDataReader reader;
     
        public UXReplicationView()
		{
			InitializeComponent();
		}

        private int GetTotalRecords(String Table)
        {
            int total = 0;
            try
            {
                DB.SqlConnect();
                cmd = new SqlCommand("SELECT COUNT(*) FROM " + Table, DB.SqlServerConn);
                total = int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                total = 0;
            }
            finally
            {
                DB.SqlDisconnect();
            }

            return total;
        }
		
		private void loadTable(object sender, DoWorkEventArgs e)
		{
			this.objPARTNER(sender, e);
			this.objKLIEN(sender, e);
			this.objPROPOSALHEAD(sender, e);
			this.objART01A(sender, e);
			this.objART01B(sender, e);
			this.objKBT01C(sender, e);
		}

        private void btnStart_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker1 = new BackgroundWorker();
            if (!backgroundWorker1.IsBusy)
            {
				
				TotalRecords  = this.GetTotalRecords("AR.dbo.PARTNER");
				TotalRecords += this.GetTotalRecords("AR.dbo.KLIEN");
				TotalRecords += this.GetTotalRecords("AR.dbo.ProposalHead");
				TotalRecords += this.GetTotalRecords("AR" + DB.Init() + ".dbo.ART01A");
				TotalRecords += this.GetTotalRecords("AR" + DB.Init() + ".dbo.ART01B");
				TotalRecords += this.GetTotalRecords("KB" + DB.Init() + ".dbo.KBT01C");

                Max = TotalRecords;
                i = 0;
                progressbar1.Value = 0;
                btnStart.Enabled = false;
                btnStart.Text = "Wait";
                
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.DoWork += backgroundWorker1_DoWork;
                backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
                backgroundWorker1.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
                backgroundWorker1.RunWorkerAsync(TotalRecords);
            }
        }

        public void objPARTNER(object sender, DoWorkEventArgs e)
        {
            try
            {
                DB.SqlConnect();
                String CmdString = "SELECT * FROM AR.dbo.Partner ORDER BY KodePartner ASC";
                cmd = new SqlCommand(CmdString, DB.SqlServerConn);
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                { 
                    if (!String.IsNullOrEmpty(reader["KodePartner"].ToString()))
                    {
                        i++;
                        e.Result = i;
                        Text = "Records " + i + " From " + Max;
                        //Delete Table ART01A
                        DB.MySqlDelete("dbo_Partner", "KodePartner", reader["KodePartner"].ToString());
                        //input
                        try
                        {
                            DB.SQL = "INSERT INTO dbo_Partner(IDPartner,KodePartner,NamaPartner,PasswordPartner)" +
                                     "VALUES(@ID,@KODE,@NAMA,@PASSWORD)";
                            DB.MySqlConnect();
                            DB.MySqlCmd = new MySqlCommand(DB.SQL, DB.MySqlServerConn);
                            DB.MySqlCmd.Parameters.Add("@ID", MySqlDbType.Int16, 11).Value = reader["IDPartner"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KODE", MySqlDbType.VarChar, 255).Value = reader["KodePartner"].ToString();
                            DB.MySqlCmd.Parameters.Add("@NAMA", MySqlDbType.VarChar, 255).Value = reader["NamaPartner"].ToString();
                            DB.MySqlCmd.Parameters.Add("@PASSWORD", MySqlDbType.VarChar, 255).Value = reader["PasswordPartner"].ToString();
                            DB.MySqlCmd.CommandType = CommandType.Text;
                            DB.MySqlCmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "ERROR");
                        }
                        finally
                        {
                            DB.MySqlCmd.Dispose();
                            DB.MySqlServerConn.Close();
                        }


                        int progressPercentage = (i/Max) * 100;
                        
                        (sender as BackgroundWorker).ReportProgress(progressPercentage, i);
                        Thread.Sleep(10);
                       
                    }

                    
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                DB.SqlDisconnect();
            }
        }

        public void objKLIEN(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                DB.SqlConnect();
                String CmdString = "SELECT *,CASE WHEN TGLAKTIF IS NULL THEN GETDATE() ELSE TGLAKTIF END AS TglAktif2 FROM AR.dbo.KLIEN ORDER BY KodeKlien ASC";
                cmd = new SqlCommand(CmdString, DB.SqlServerConn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Text = "Records " + i + " From " + Max;
                    if (!String.IsNullOrEmpty(reader["KodeKlien"].ToString()))
                    {
                        i++;
                        e.Result = i;

                        //Delete Table ART01A
                        DB.MySqlDelete("dbo_Klien", "KodeKlien", reader["KodeKlien"].ToString());
                        //input
                        try
                        {
                            DB.SQL = "INSERT INTO dbo_Klien(IDKlien,KodeKlien,NamaKlien,TglAktif,KodeJasa,KodeIndukPT,Alamat1,Alamat2,KodePos,Telp,Email,CP,Status,KodeJenisPT,Fax,Alamat3,NMklienSurat,Alamatsurat1,Alamatsurat2,Alamatsurat3,Alamatsurat4,Alamat4)" +
                                     "               VALUES(@IDKLIEN,@KODEKLIEN,@NAMAKLIEN,@TglAktif,@KODEJASA,@KodeIndukPT,@ALAMAT1,@ALAMAT2,@KODEPOS,@TELP,@EMAIL,@CP,@STATUS,@KODEJENISPT,@FAX,@ALAMAT3,@NMKLIENSURAT,@ALAMATSURAT1,@ALAMATSURAT2,@ALAMATSURAT3,@ALAMATSURAT4,@ALAMAT4)";
                            //MessageBox.Show(DB.SQL);
                            DB.MySqlConnect();
                            DB.MySqlCmd = new MySqlCommand(DB.SQL, DB.MySqlServerConn);
                            DB.MySqlCmd.Parameters.Add("@IDKLIEN", MySqlDbType.VarChar, 255).Value = reader["IDKLIEN"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KODEKLIEN", MySqlDbType.VarChar,255).Value = reader["KODEKLIEN"].ToString();
                            DB.MySqlCmd.Parameters.Add("@NAMAKLIEN", MySqlDbType.VarChar, 255).Value = reader["NAMAKLIEN"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TglAktif", MySqlDbType.DateTime).Value = Convert.ToDateTime(reader["TglAktif2"].ToString());
                            DB.MySqlCmd.Parameters.Add("@KODEJASA", MySqlDbType.VarChar,255).Value = reader["KODEJASA"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KodeIndukPT", MySqlDbType.VarChar,15).Value = reader["KodeIndukPT"].ToString();
                            DB.MySqlCmd.Parameters.Add("@ALAMAT1", MySqlDbType.VarChar).Value = reader["ALAMAT1"].ToString();
                            DB.MySqlCmd.Parameters.Add("@ALAMAT2", MySqlDbType.VarChar, 255).Value = reader["ALAMAT2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KODEPOS", MySqlDbType.VarChar, 255).Value = reader["KODEPOS"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TELP", MySqlDbType.VarChar, 255).Value = reader["TELP"].ToString();
                            DB.MySqlCmd.Parameters.Add("@EMAIL", MySqlDbType.VarChar, 255).Value = reader["EMAIL"].ToString();
                            DB.MySqlCmd.Parameters.Add("@CP", MySqlDbType.VarChar, 255).Value = reader["CP"].ToString();
                            DB.MySqlCmd.Parameters.Add("@STATUS", MySqlDbType.VarChar, 255).Value = reader["STATUS"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KODEJENISPT", MySqlDbType.VarChar,255).Value = reader["KODEJENISPT"].ToString();
                            DB.MySqlCmd.Parameters.Add("@FAX", MySqlDbType.VarChar,255).Value = reader["FAX"].ToString();
                            DB.MySqlCmd.Parameters.Add("@ALAMAT3", MySqlDbType.VarChar, 255).Value = reader["ALAMAT3"].ToString();
                            DB.MySqlCmd.Parameters.Add("@NMKLIENSURAT", MySqlDbType.VarChar, 255).Value = reader["NMKLIENSURAT"].ToString();
                            DB.MySqlCmd.Parameters.Add("@ALAMATSURAT1", MySqlDbType.VarChar,255).Value = reader["ALAMATSURAT1"].ToString();
                            DB.MySqlCmd.Parameters.Add("@ALAMATSURAT2", MySqlDbType.VarChar, 255).Value = reader["ALAMATSURAT2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@ALAMATSURAT3", MySqlDbType.VarChar,255).Value = reader["ALAMATSURAT3"].ToString();
                            DB.MySqlCmd.Parameters.Add("@ALAMATSURAT4", MySqlDbType.VarChar, 255).Value = reader["ALAMATSURAT4"].ToString();
                            DB.MySqlCmd.Parameters.Add("@ALAMAT4", MySqlDbType.VarChar, 255).Value = reader["ALAMAT4"].ToString();
                            DB.MySqlCmd.CommandType = CommandType.Text;
                            DB.MySqlCmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "ERROR");
                        }
                        finally
                        {
                            DB.MySqlCmd.Dispose();
                            DB.MySqlServerConn.Close();
                        }

                        int progressPercentage = (i / Max) * 100;

                        (sender as BackgroundWorker).ReportProgress(progressPercentage, i);
                        Thread.Sleep(10);

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                DB.SqlDisconnect();
            }
        }

        public void objPROPOSALHEAD(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                DB.SqlConnect();
                String CmdString = " SELECT *,CASE WHEN TGLPROPOSAL IS NULL THEN GETDATE() ELSE TGLPROPOSAL END AS TGLPROPOSAL2, " +
                                   " CASE WHEN PrdPartnerD IS NULL THEN GETDATE() ELSE PrdPartnerD END AS PrdPartnerD2, " +
                                   " CASE WHEN PrdPartnerS IS NULL THEN GETDATE() ELSE PrdPartnerS END AS PrdPartnerS2, " +
                                   " CASE WHEN PrdKapD IS NULL THEN GETDATE() ELSE PrdKapD END AS PrdKapD2, " +
                                   " CASE WHEN PrdKapS IS NULL THEN GETDATE() ELSE PrdKapS END AS PrdKapS2, " +
                                   " CASE WHEN TorTgl IS NULL THEN GETDATE() ELSE TorTgl END AS TorTgl2, " +
                                   " CASE WHEN TorTglKembali IS NULL THEN GETDATE() ELSE TorTglKembali END AS TorTglKembali2, " +
                                   " CASE WHEN Periode IS NULL THEN GETDATE() ELSE Periode END AS Periode2, " +
                                   " CASE WHEN TGLKEMBALI IS NULL THEN GETDATE() ELSE TGLPROPOSAL END AS TGLKEMBALI2, " +
                                   " CASE WHEN NILAI IS NULL THEN 0 ELSE NILAI END AS NILAI2, " +
                                   " CASE WHEN TORNILAI IS NULL THEN 0 ELSE TORNILAI END AS TORNILAI2 ," +
                                   " CASE WHEN NILAIOPE IS NULL THEN 0 ELSE NILAIOPE END AS NILAIOPE2 " +
								   " FROM AR.dbo.PROPOSALHEAD ORDER BY IDProposal ASC";
                cmd = new SqlCommand(CmdString, DB.SqlServerConn);
                reader = cmd.ExecuteReader(); 


                while (reader.Read())
                {
                    Text = "Records " + i + " From " + Max;
                    if (!String.IsNullOrEmpty(reader["NoProposal"].ToString()))
                    {
                        i++;
                        e.Result = i;

                        //Delete Table ART01A
                        DB.MySqlDelete("dbo_ProposalHead", "IDProposal", reader["IDProposal"].ToString());
                        //input
                        try
                        {
                            DB.SQL = "INSERT INTO dbo_ProposalHead(IDProposal,NoProposal,TglProposal,Nilai,PrdPartnerD,PrdPartnerS,PrdKapD,PrdKapS,TglKembali,Referal,KodeBank,KodePartner,KodeKlien,KodeNegara,NmPartner,NmKlien,KodeKlien2,KodeNegara2,KodeJasa,KodeJenisPT,Status,StatusBDO,StatusClien,KursID,Torno,TorTgl,Tornilai,TorTglKembali,StatusTor,KursTOR,nilaiOPE,kursOPE,Periode,tglStugas)" +
                                     "VALUES(@IDProposal,@NoProposal,@TglProposal,@Nilai,@PrdPartnerD,@PrdPartnerS,@PrdKapD,@PrdKapS,@TglKembali,@Referal,@KodeBank,@KodePartner,@KodeKlien,@KodeNegara,@NmPartner,@NmKlien,@KodeKlien2,@KodeNegara2,@KodeJasa,@KodeJenisPT,@Status,@StatusBDO,@StatusClien,@KursID,@Torno,@TorTgl,@Tornilai,@TorTglKembali,@StatusTor,@KursTOR,@nilaiOPE,@kursOPE,@Periode,@tglStugas)";

                            

                            DB.MySqlConnect();
                            DB.MySqlCmd = new MySqlCommand(DB.SQL, DB.MySqlServerConn);
                            DB.MySqlCmd.Parameters.Add("@IDProposal", MySqlDbType.VarChar, 100).Value = reader["IDProposal"].ToString();
                            DB.MySqlCmd.Parameters.Add("@NoProposal", MySqlDbType.VarChar, 100).Value = reader["NoProposal"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TglProposal", MySqlDbType.VarChar).Value = reader["TglProposal2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Nilai", MySqlDbType.Double).Value = reader["NILAI2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@PrdPartnerD", MySqlDbType.VarChar).Value = reader["PrdPartnerD2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@PrdPartnerS", MySqlDbType.VarChar).Value = reader["PrdPartnerS2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@PrdKapD", MySqlDbType.VarChar).Value = reader["PrdKapD2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@PrdKapS", MySqlDbType.VarChar).Value = reader["PrdKapS2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TglKembali", MySqlDbType.VarChar).Value = reader["TglKembali"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Referal", MySqlDbType.VarChar, 255).Value = reader["Referal"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KodeBank", MySqlDbType.VarChar, 255).Value = reader["KodeBank"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KodePartner", MySqlDbType.VarChar, 255).Value = reader["KodePartner"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KodeKlien", MySqlDbType.VarChar, 255).Value = reader["KodeKlien"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KodeNegara", MySqlDbType.VarChar, 255).Value = reader["KodeNegara"].ToString();
                            DB.MySqlCmd.Parameters.Add("@NmPartner", MySqlDbType.VarChar, 255).Value = reader["NmPartner"].ToString();
                            DB.MySqlCmd.Parameters.Add("@NmKlien", MySqlDbType.VarChar, 255).Value = reader["NmKlien"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KodeKlien2", MySqlDbType.VarChar, 255).Value = reader["KodeKlien2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KodeNegara2", MySqlDbType.VarChar, 255).Value = reader["KodeNegara2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KodeJasa", MySqlDbType.VarChar, 255).Value = reader["KodeJasa"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KodeJenisPT", MySqlDbType.VarChar, 255).Value = reader["KodeJenisPT"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Status", MySqlDbType.VarChar, 255).Value = reader["Status"].ToString();
                            DB.MySqlCmd.Parameters.Add("@StatusBDO", MySqlDbType.VarChar, 255).Value = reader["StatusBDO"].ToString();
                            DB.MySqlCmd.Parameters.Add("@StatusClien", MySqlDbType.VarChar, 255).Value = reader["StatusClien"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KursID", MySqlDbType.VarChar, 255).Value = reader["KursID"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Torno", MySqlDbType.VarChar, 255).Value = reader["Torno"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TorTgl", MySqlDbType.VarChar).Value = reader["TorTgl2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Tornilai", MySqlDbType.Double).Value = reader["TORNILAI2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TorTglKembali", MySqlDbType.VarChar).Value = reader["TorTglKembali2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@StatusTor", MySqlDbType.VarChar, 255).Value = reader["StatusTor"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KursTOR", MySqlDbType.VarChar, 5).Value = reader["KursTOR"].ToString();
                            DB.MySqlCmd.Parameters.Add("@nilaiOPE", MySqlDbType.Double).Value = reader["NILAIOPE2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@kursOPE", MySqlDbType.VarChar, 5).Value = reader["kursOPE"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Periode", MySqlDbType.VarChar).Value = reader["Periode"].ToString();
                            DB.MySqlCmd.Parameters.Add("@tglStugas", MySqlDbType.VarChar, 255).Value = reader["tglStugas"].ToString();
                            
                            DB.MySqlCmd.CommandType = CommandType.Text;
                            DB.MySqlCmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "ERROR");
                        }
                        finally
                        {
                            DB.MySqlCmd.Dispose();
                            DB.MySqlServerConn.Close();
                        }

                        int progressPercentage = (i / Max) * 100;

                        (sender as BackgroundWorker).ReportProgress(progressPercentage, i);
                        Thread.Sleep(10);

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                DB.SqlDisconnect();
            }
        }

        public void objART01A(object sender, DoWorkEventArgs e)
        {
            try
            {
                DB.SqlConnect();
                String CmdString = "SELECT *,CASE WHEN TGL_PAJAK IS NULL THEN TGL ELSE TGL_PAJAK END AS TGL_PAJAK2," +
                "CASE WHEN TGLINPUT IS NULL THEN TGL ELSE TGLINPUT END AS TGLINPUT2," +
                "CASE WHEN MUKA IS NULL THEN 0 ELSE MUKA END AS MUKA2," +
                "CASE WHEN DISC1 IS NULL THEN 0 ELSE DISC1 END AS DISC12," +
                "CASE WHEN NDISC1 IS NULL THEN 0 ELSE NDISC1 END AS NDISC12," +
                "CASE WHEN PPN IS NULL THEN 0 ELSE PPN END AS PPN2," +
                "CASE WHEN NETTO IS NULL THEN 0 ELSE NETTO END AS NETTO2," +
                "CASE WHEN MTR IS NULL THEN 0 ELSE MTR END AS MTR2," +
                "CASE WHEN TOTAL IS NULL THEN 0 ELSE TOTAL END AS TOTAL2," +
                "CASE WHEN TUKAR IS NULL THEN 0 ELSE TUKAR END AS TUKAR2," +
                "CASE WHEN NPPN IS NULL THEN 0 ELSE NPPN END AS NPPN2," +
                "CASE WHEN POT IS NULL THEN 0 ELSE POT END AS POT2," +
                "CASE WHEN BAYAR IS NULL THEN 0 ELSE BAYAR END AS BAYAR2," +
                "CASE WHEN DEBET IS NULL THEN 0 ELSE DEBET END AS DEBET2," +
                "CASE WHEN KREDIT IS NULL THEN 0 ELSE KREDIT END AS KREDIT2," +
                "CASE WHEN BANK IS NULL THEN 0 ELSE BANK END AS BANK2," +
                "CASE WHEN TOTAL_DEBET_GL IS NULL THEN 0 ELSE TOTAL_DEBET_GL END AS TOTAL_DEBET_GL2," +
                "CASE WHEN TOTAL_KREDIT_GL IS NULL THEN 0 ELSE TOTAL_KREDIT_GL END AS TOTAL_KREDIT_GL2," +
                "CASE WHEN PPN_RATE IS NULL THEN 0 ELSE PPN_RATE END AS PPN_RATE2," +
				"CASE WHEN TGLPOTONG IS NULL THEN TGL ELSE TGLPOTONG END AS TGLPOTONG2 " + 
				"FROM AR" + DB.Init() + ".dbo.ART01A ORDER BY FAKTUR ASC";

				cmd = new SqlCommand(CmdString, DB.SqlServerConn);
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Text = "Records " + i + " From " + Max;
                    if (!String.IsNullOrEmpty(reader["Faktur"].ToString()))
                    {
                        i++;
                        e.Result = i;

                        //Delete Table ART01A
                        DB.MySqlDelete("dbo_ART01A", "FAKTUR", reader["Faktur"].ToString());
                        //input
                        try
                        {
                            DB.SQL = "INSERT INTO dbo_ART01A(FAKTUR,TGL,KONTAN,CUST,SLM,TERM,MUKA,DISC1,NDISC1,PPN,MTR,NETTO,KET,TOTAL,F_PAJAK,TGL_PAJAK,NCUST,WIL,SO,SATUAN,POST,VLT,TUKAR,JTGL,NPPN,POT,BAYAR,DEBET,KREDIT,BANK,TOTAL_DEBET_GL,TOTAL_KREDIT_GL,PPN_RATE,USERNAME,TGLINPUT,NO_KONTRAK,TglPotong)" +
                                     "VALUES(@FAKTUR,@TGL,@KONTAN,@CUST,@SLM,@TERM,@MUKA,@DISC1,@NDISC1,@PPN,@MTR,@NETTO,@KET,@TOTAL,@F_PAJAK,@TGL_PAJAK,@NCUST,@WIL,@SO,@SATUAN,@POST,@VLT,@TUKAR,@JTGL,@NPPN,@POT,@BAYAR,@DEBET,@KREDIT,@BANK,@TOTAL_DEBET_GL,@TOTAL_KREDIT_GL,@PPN_RATE,@USERNAME,@TGLINPUT,@NO_KONTRAK,@TGLPOTONG)";
                            DB.MySqlConnect();
                            DB.MySqlCmd = new MySqlCommand(DB.SQL, DB.MySqlServerConn);
                            DB.MySqlCmd.Parameters.Add("@FAKTUR", MySqlDbType.VarChar, 255).Value = reader["FAKTUR"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TGL", MySqlDbType.DateTime).Value = Convert.ToDateTime(reader["TGL"].ToString());
                            DB.MySqlCmd.Parameters.Add("@KONTAN", MySqlDbType.VarChar, 1).Value = reader["KONTAN"].ToString();
                            DB.MySqlCmd.Parameters.Add("@CUST", MySqlDbType.VarChar, 10).Value = reader["CUST"].ToString();
                            DB.MySqlCmd.Parameters.Add("@SLM", MySqlDbType.VarChar, 10).Value = reader["SLM"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TERM", MySqlDbType.Int16, 6).Value = reader["TERM"].ToString();
                            DB.MySqlCmd.Parameters.Add("@MUKA", MySqlDbType.Double).Value = reader["MUKA2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@DISC1", MySqlDbType.Double).Value = reader["DISC12"].ToString();
                            DB.MySqlCmd.Parameters.Add("@NDISC1", MySqlDbType.Double).Value = reader["NDISC12"].ToString();
                            DB.MySqlCmd.Parameters.Add("@PPN", MySqlDbType.Double).Value = reader["PPN2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@MTR", MySqlDbType.Double).Value = reader["MTR2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@NETTO", MySqlDbType.Double).Value = reader["NETTO2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KET", MySqlDbType.MediumText).Value = reader["KET"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TOTAL", MySqlDbType.Double).Value = reader["TOTAL2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@F_PAJAK", MySqlDbType.VarChar, 10).Value = reader["F_PAJAK"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TGL_PAJAK", MySqlDbType.DateTime).Value = Convert.ToDateTime(reader["TGL_PAJAK2"].ToString());
                            DB.MySqlCmd.Parameters.Add("@NCUST", MySqlDbType.VarChar, 255).Value = reader["NCUST"].ToString();
                            DB.MySqlCmd.Parameters.Add("@WIL", MySqlDbType.VarChar, 3).Value = reader["WIL"].ToString();
                            DB.MySqlCmd.Parameters.Add("@SO", MySqlDbType.VarChar, 10).Value = reader["SO"].ToString();
                            DB.MySqlCmd.Parameters.Add("@SATUAN", MySqlDbType.VarChar, 1).Value = reader["SATUAN"].ToString();
                            DB.MySqlCmd.Parameters.Add("@POST", MySqlDbType.VarChar, 1).Value = reader["POST"].ToString();
                            DB.MySqlCmd.Parameters.Add("@VLT", MySqlDbType.VarChar, 3).Value = reader["VLT"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TUKAR", MySqlDbType.Double).Value = reader["TUKAR2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@JTGL", MySqlDbType.DateTime).Value = Convert.ToDateTime(reader["JTGL"].ToString());
                            DB.MySqlCmd.Parameters.Add("@NPPN", MySqlDbType.Double).Value = reader["NPPN2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@POT", MySqlDbType.Double).Value = reader["POT2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@BAYAR", MySqlDbType.Double).Value = reader["BAYAR2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@DEBET", MySqlDbType.Double).Value = reader["DEBET2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@KREDIT", MySqlDbType.Double).Value = reader["KREDIT2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@BANK", MySqlDbType.Double).Value = reader["BANK2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TOTAL_DEBET_GL", MySqlDbType.Double).Value = reader["TOTAL_DEBET_GL2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TOTAL_KREDIT_GL", MySqlDbType.Double).Value = reader["TOTAL_KREDIT_GL2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@PPN_RATE", MySqlDbType.Double).Value = reader["PPN_RATE2"].ToString();
                            DB.MySqlCmd.Parameters.Add("@USERNAME", MySqlDbType.VarChar, 10).Value = reader["USERNAME"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TGLINPUT", MySqlDbType.VarChar, 10).Value = Convert.ToDateTime(reader["TGLINPUT2"].ToString());
                            DB.MySqlCmd.Parameters.Add("@NO_KONTRAK", MySqlDbType.VarChar, 30).Value = reader["NO_KONTRAK"].ToString();
                            DB.MySqlCmd.Parameters.Add("@TGLPOTONG", MySqlDbType.VarChar, 10).Value = Convert.ToDateTime(reader["TGLPOTONG2"].ToString());
                            DB.MySqlCmd.CommandType = CommandType.Text;
                            DB.MySqlCmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "ERROR");
                        }
                        finally
                        {
                            DB.MySqlCmd.Dispose();
                            DB.MySqlServerConn.Close();
                        }

                        int progressPercentage = (i / Max) * 100;

                        (sender as BackgroundWorker).ReportProgress(progressPercentage, i);
                        Thread.Sleep(10);

                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
            }
            finally
            {
                DB.SqlDisconnect();
            }
        }

		public void objART01B(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			try
			{
				DB.SqlConnect();
				String CmdString = " SELECT FAKTUR,NO,BRG,GD,STN,WO,SJ,NoPH,NilaiPH,BayarTahap,NOTOR, " +
					" CASE WHEN HS IS NULL THEN 0 ELSE HS END AS HS," +
					" CASE WHEN QTY IS NULL THEN 0 ELSE QTY END AS QTY," +
					" CASE WHEN DISC2 IS NULL THEN 0 ELSE DISC2 END AS DISC2," +
					" CASE WHEN NDISC2 IS NULL THEN 0 ELSE NDISC2 END AS NDISC2," +					
					" CASE WHEN NilaiPH IS NULL THEN 0 ELSE NilaiPH END as NilaiPH," +
					" CASE WHEN Bayar IS NULL THEN 0 ELSE Bayar END AS Bayar" +
					" FROM AR" + DB.Init() + ".dbo.ART01B ORDER BY NoPH ASC";

				cmd = new SqlCommand(CmdString, DB.SqlServerConn);
				reader = cmd.ExecuteReader();

				while (reader.Read())
				{
					Text = "Records " + i + " From " + Max;
					if (!String.IsNullOrEmpty(reader["Faktur"].ToString()))
					{
						i++;
						e.Result = i;

						//Delete Table ART01A
						DB.MySqlDelete("dbo_ART01B", "NoPH", reader["NoPH"].ToString());
						//input
						try
						{
							DB.SQL = "INSERT INTO dbo_ART01B(FAKTUR,NO,BRG,HS,QTY,DISC2,NDISC2,GD,STN,WO,SJ,NoPH,BayarTahap,NilaiPH,Bayar,NOTOR)" +
									 "VALUES(@FAKTUR,@NO,@BRG,@HS,@QTY,@DISC2,@NDISC2,@GD,@STN,@WO,@SJ,@NoPH,@BayarTahap,@NilaiPH,@Bayar,@NOTOR)";
							DB.MySqlConnect();
							DB.MySqlCmd = new MySqlCommand(DB.SQL, DB.MySqlServerConn);
							DB.MySqlCmd.Parameters.Add("@FAKTUR", MySqlDbType.VarChar, 10).Value = reader["Faktur"].ToString();
							DB.MySqlCmd.Parameters.Add("@NO", MySqlDbType.Int16).Value = reader["NO"].ToString();
							DB.MySqlCmd.Parameters.Add("@BRG", MySqlDbType.VarChar, 255).Value = reader["BRG"].ToString();
							DB.MySqlCmd.Parameters.Add("@HS", MySqlDbType.Double).Value = reader["HS"].ToString();
							DB.MySqlCmd.Parameters.Add("@QTY", MySqlDbType.Double).Value = reader["QTY"].ToString();
							DB.MySqlCmd.Parameters.Add("@DISC2", MySqlDbType.Double).Value = reader["DISC2"].ToString();
							DB.MySqlCmd.Parameters.Add("@NDISC2", MySqlDbType.Double).Value = reader["NDISC2"].ToString();
							DB.MySqlCmd.Parameters.Add("@GD", MySqlDbType.VarChar, 2).Value = reader["GD"].ToString();
							DB.MySqlCmd.Parameters.Add("@STN", MySqlDbType.VarChar, 1).Value = reader["STN"].ToString();
							DB.MySqlCmd.Parameters.Add("@WO", MySqlDbType.VarChar, 10).Value = reader["WO"].ToString();
							DB.MySqlCmd.Parameters.Add("@SJ", MySqlDbType.VarChar, 10).Value = reader["SJ"].ToString();
							DB.MySqlCmd.Parameters.Add("@NoPH", MySqlDbType.VarChar, 100).Value = reader["NoPH"].ToString();
							DB.MySqlCmd.Parameters.Add("@BayarTahap", MySqlDbType.VarChar, 50).Value = reader["BayarTahap"].ToString();
							DB.MySqlCmd.Parameters.Add("@NilaiPH", MySqlDbType.Double).Value = reader["NilaiPH"].ToString();
							DB.MySqlCmd.Parameters.Add("@Bayar", MySqlDbType.Double).Value = reader["Bayar"].ToString();
							DB.MySqlCmd.Parameters.Add("@NOTOR", MySqlDbType.VarChar, 100).Value = reader["NOTOR"].ToString();
							DB.MySqlCmd.CommandType = CommandType.Text;
							DB.MySqlCmd.ExecuteNonQuery();
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.ToString(), "ERROR");
						}
						finally
						{
							DB.MySqlCmd.Dispose();
							DB.MySqlServerConn.Close();
						}

						int progressPercentage = (i / Max) * 100;

						(sender as BackgroundWorker).ReportProgress(progressPercentage, i);
						Thread.Sleep(10);

					}

				}

			}
			catch (Exception ex)
			{
				MessageBox.Show("Error " + ex.Message);
			}
			finally
			{
				DB.SqlDisconnect();
			}
		}

		public void objKBT01C(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                DB.SqlConnect();
                String CmdString = "SELECT Jenis_Form,No_Bukti,Type_Transaksi,No_Faktur,No_Giro,Kode_ARAP,Status_Posting," +
					" Relasi,Keterangan,No,Vlt,RELASI_LAWAN,FAKTUR_LAWAN," +
					" CASE WHEN Sisa IS NULL THEN 0 ELSE Sisa END AS Sisa, " +
					" CASE WHEN Nilai_Potong IS NULL THEN 0 ELSE Nilai_Potong END AS Nilai_Potong, " +
					" CASE WHEN Nilai_Bayar IS NULL THEN 0 ELSE Nilai_Bayar END AS Nilai_Bayar, " +
					" CASE WHEN Tukar IS NULL THEN 0 ELSE Tukar END AS Tukar, " +
					" CASE WHEN Nilai_Potong_PPH23 IS NULL THEN 0 ELSE Nilai_Potong_PPH23 END AS Nilai_Potong_PPH23, " +
					" CASE WHEN TANGGAL_FAKTUR_LAWAN IS NULL THEN GETDATE() ELSE TANGGAL_FAKTUR_LAWAN END AS TANGGAL_FAKTUR_LAWAN, " +
					" CASE WHEN NILAI_BAYAR_LAWAN IS NULL THEN 0 ELSE NILAI_BAYAR_LAWAN END AS NILAI_BAYAR_LAWAN, " +
					" CASE WHEN NILAI_SISA_LAWAN IS NULL THEN 0 ELSE NILAI_SISA_LAWAN END AS NILAI_SISA_LAWAN " +
					" FROM KB" + DB.Init() + ".dbo.KBT01C ORDER BY NO";
				
				cmd = new SqlCommand(CmdString, DB.SqlServerConn);
                reader = cmd.ExecuteReader();
              
                while (reader.Read())
                {
                    Text = "Records " + i + " From " + Max;
                    if (!String.IsNullOrEmpty(reader["No_Bukti"].ToString()))
                    {
                        i++;
                        e.Result = i;

						//Delete Table KBT01C
						DB.MySqlDelete("dbo_KBT01C", "No", reader["No"].ToString());
                        //input
                        try
                        {
                            DB.SQL = "INSERT INTO dbo_KBT01C(Jenis_Form,No_Bukti,Type_Transaksi,No_Faktur,Sisa,Nilai_Potong,Nilai_Bayar,No_Giro,Kode_ARAP,Status_Posting,Relasi,Keterangan,No,Vlt,Tukar,Nilai_Potong_PPH23,RELASI_LAWAN,FAKTUR_LAWAN,TANGGAL_FAKTUR_LAWAN,NILAI_BAYAR_LAWAN,NILAI_SISA_LAWAN)" +
									 "VALUES(@Jenis_Form,@No_Bukti,@Type_Transaksi,@No_Faktur,@Sisa,@Nilai_Potong,@Nilai_Bayar,@No_Giro,@Kode_ARAP,@Status_Posting,@Relasi,@Keterangan,@No,@Vlt,@Tukar,@Nilai_Potong_PPH23,@RELASI_LAWAN,@FAKTUR_LAWAN,@TANGGAL_FAKTUR_LAWAN,@NILAI_BAYAR_LAWAN,@NILAI_SISA_LAWAN)";
                            DB.MySqlConnect();
                            DB.MySqlCmd = new MySqlCommand(DB.SQL, DB.MySqlServerConn);
                            DB.MySqlCmd.Parameters.Add("@Jenis_Form", MySqlDbType.Int16, 6).Value = reader["Jenis_Form"].ToString();
                            DB.MySqlCmd.Parameters.Add("@No_Bukti", MySqlDbType.VarChar,11).Value = reader["No_Bukti"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Type_Transaksi", MySqlDbType.VarChar,20).Value = reader["Type_Transaksi"].ToString();
                            DB.MySqlCmd.Parameters.Add("@No_Faktur", MySqlDbType.VarChar,10).Value = reader["No_Faktur"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Sisa", MySqlDbType.Double).Value = reader["Sisa"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Nilai_Potong", MySqlDbType.Double).Value = reader["Nilai_Potong"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Nilai_Bayar", MySqlDbType.Double).Value = reader["Nilai_Bayar"].ToString();
                            DB.MySqlCmd.Parameters.Add("@No_Giro", MySqlDbType.VarChar, 20).Value = reader["No_Giro"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Kode_ARAP", MySqlDbType.VarChar, 1).Value = reader["Kode_ARAP"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Status_Posting", MySqlDbType.VarChar, 1).Value = reader["Status_Posting"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Relasi", MySqlDbType.VarChar, 10).Value = reader["Relasi"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Keterangan", MySqlDbType.VarChar, 30).Value = reader["Keterangan"].ToString();
                            DB.MySqlCmd.Parameters.Add("@No", MySqlDbType.Int16, 6).Value = reader["No"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Vlt", MySqlDbType.VarChar,3).Value = reader["Vlt"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Tukar", MySqlDbType.Double).Value = reader["Tukar"].ToString();
                            DB.MySqlCmd.Parameters.Add("@Nilai_Potong_PPH23", MySqlDbType.Double).Value = reader["Nilai_Potong_PPH23"].ToString();
							DB.MySqlCmd.Parameters.Add("@RELASI_LAWAN", MySqlDbType.VarChar, 10).Value = reader["RELASI_LAWAN"].ToString();
							DB.MySqlCmd.Parameters.Add("@FAKTUR_LAWAN", MySqlDbType.VarChar, 10).Value = reader["FAKTUR_LAWAN"].ToString();
							DB.MySqlCmd.Parameters.Add("@TANGGAL_FAKTUR_LAWAN", MySqlDbType.VarChar).Value = reader["TANGGAL_FAKTUR_LAWAN"].ToString();
							DB.MySqlCmd.Parameters.Add("@NILAI_BAYAR_LAWAN", MySqlDbType.Double).Value = reader["NILAI_BAYAR_LAWAN"].ToString();
							DB.MySqlCmd.Parameters.Add("@NILAI_SISA_LAWAN", MySqlDbType.Double).Value = reader["NILAI_SISA_LAWAN"].ToString();

							DB.MySqlCmd.CommandType = CommandType.Text;
                            DB.MySqlCmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "ERROR");
                        }
                        finally
                        {
                            DB.MySqlCmd.Dispose();
                            DB.MySqlServerConn.Close();
                        }

                        int progressPercentage = (i / Max) * 100;

                        (sender as BackgroundWorker).ReportProgress(progressPercentage, i);
                        Thread.Sleep(10);

                    }
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error SQL Server : " + ex.Message);
            }
            finally
            {
                DB.SqlDisconnect();
            }
        }

		
		private void backgroundWorker1_DoWork(object sender,DoWorkEventArgs e)
        {
			loadTable(sender,e);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            lblTable.Text = "All data loaded!";
            btnStart.Enabled = true;
            btnStart.Text = "Start";
            MessageBox.Show("Finish Replication Data of Total " + e.Result);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
       
            if (e.UserState != null)
            {
                lblTable.Text = Text;
                int progressPercentage = (int)((i) * 100.0 / Max);
                progressbar1.Value = progressPercentage;
            }
                
        }

		private void UXReplicationView_Load(object sender, EventArgs e)
		{
			lblGroup.Text = DB.Group;
		}
	}
}
