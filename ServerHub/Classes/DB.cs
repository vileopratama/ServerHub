using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ServerHub.Classes
{
    class DB
    {
        public static SqlConnection SqlServerConn = new SqlConnection();
        public static MySqlConnection MySqlServerConn = new MySqlConnection();
        public static string SQL;
        //public static string MySQL;
        public static SqlCommand SqlCmd;
        public static MySqlCommand MySqlCmd;
        private static string sqlserver;
        private static string mysqlserver;
        private static string sqlport;
        private static string mysqlport;
        private static string sqldatabase;
        private static string mysqldatabase;
        public static string sqluser;
        public static string mysqluser;
        public static string sqlpassword;
        public static string mysqlpassword;
        public static bool is_sqlconnected = false;
        public static bool is_mysqlconnected = false;


        public static string SqlServer
        {
            get { return sqlserver; }
            set { sqlserver = value; }
        }

        public static string MySqlServer
        {
            get { return mysqlserver; }
            set { mysqlserver = value; }
        }

        public static string SqlPort
        {
            get { return sqlport; }
            set { sqlport = value; }
        }

        public static string MySqlPort
        {
            get { return mysqlport; }
            set { mysqlport = value; }
        }

        public static string SqlDatabase
        {
            get { return sqldatabase; }
            set { sqldatabase = value; }
        }

        public static string MySqlDatabase
        {
            get { return mysqldatabase; }
            set { mysqldatabase = value; }
        }

        public static string SqlUser
        {
            get { return sqluser; }
            set { sqluser = value; }
        }

        public static string MySqlUser
        {
            get { return mysqluser; }
            set { mysqluser = value; }
        }

        public static string SqlPassword
        {
            get { return sqlpassword; }
            set { sqlpassword = value; }
        }

        public static string MySqlPassword
        {
            get { return mysqlpassword; }
            set { mysqlpassword = value; }
        }

        public static bool isSqlConnected
        {
            get { return is_sqlconnected; }
            set { is_sqlconnected = value; }
        }

        public static bool isMySqlConnected
        {
            get { return is_mysqlconnected; }
            set { is_mysqlconnected = value; }
        }

        public static void SqlConnect()
        {
            SqlServerConn.Close();
            try
            {
                SqlServerConn.ConnectionString = "Server=" + SqlServer + ";" +
                                        "DataBase=AR;" +
                                        "User Id=" + SqlUser + ";" +
                                        "Password=" + SqlPassword + ";";
                SqlServerConn.Open();
                isSqlConnected = true;
            }
            catch (SqlException)
            {
                isSqlConnected = false;
            
            }
        }

        public static void MySqlConnect()
        {
            MySqlServerConn.Close();
            try
            {
                MySqlServerConn.ConnectionString = "SERVER="+MySqlServer+";"+"PORT="+MySqlPort+";"+"DATABASE="+MySqlDatabase+";"+"UID="+MySqlUser+";"+"PASSWORD="+MySqlPassword;
                MySqlServerConn.Open();
                isMySqlConnected = true;
            }
            catch (MySqlException)
            {
                isMySqlConnected = false;

            }
        }

        public static void SqlDisconnect()
        {
            SqlServerConn.Close();
            SqlServerConn.Dispose();
        }

        public static void MySqlDisconnect()
        {
            MySqlServerConn.Close();
            MySqlServerConn.Dispose();
        }

        public static void MySqlDelete(string Table,string Key,string Value)
        {
            try
            {
                MySqlConnect();
                string SQL = "DELETE FROM " + Table + " WHERE "+Key+"=@param";
               
                using (MySqlCommand cmd = new MySqlCommand(SQL , MySqlServerConn))
                {
                    cmd.Parameters.Add("@param", MySqlDbType.VarChar, 255).Value = Value;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Delete Error " + ex.Message);
            }
            finally
            {
                MySqlServerConn.Close();
                MySqlServerConn.Dispose();

            }
        }
    }
}
