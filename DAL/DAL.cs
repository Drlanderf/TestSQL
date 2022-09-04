using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using static System.Net.Mime.MediaTypeNames;

namespace DossierCSharp
{
    public class DAL_mySQL
    {
        /*private MySqlConnection connection;
        private const string server="localhost";
        private const string database = "eventlog";
        private const string username = "root";
        private const string password = "";*/
        private MySqlConnection connection;
        private string server= string.Empty;
        private string database = string.Empty;
        private string username = string.Empty;
        private string password = string.Empty;

        private static DAL_mySQL _instance = null;

        public static DAL_mySQL getInstance() 
        {
            if( _instance == null) 
            {
                _instance = new DAL_mySQL(); 
            }
            return _instance;//singleton
        }

        private DAL_mySQL()
        {
            //ACCESS
            String strAssemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath +
                                              @"\Datas\CaisseManager.accdb;Persist Security Info=False;Jet OLEDB:Database Password=pc4every1";

            //mySQL
            /*string connectstring = "server =" + server + 
                "; database=" + database + 
                "; username=" + username + 
                "; password = " + password + 
                ";";*/
            /*this.server = ConfigurationManager.AppSettings["Server"];
            this.database = ConfigurationManager.AppSettings["Database"];
            this.username = ConfigurationManager.AppSettings["Login"];
            this.password = ConfigurationManager.AppSettings["Password"];
                string connectstring = "server =" + this.server + 
                "; database=" + this.database + 
                "; username=" + this.username + 
                "; password = " + this.password + 
                ";";*/
            //connection = new MySqlConnection(connectstring);
        }
        private void DB_open()

        {

            try

            {

                connection.Open();

            }

            catch (Exception ex)

            {

                Console.WriteLine(ex.ToString());

                throw;

            }

        }



        private void DB_close()

        {

            connection.Close();

        }



        public DataTable ExecuteQuery_dt(string Query)
        {
            DataTable dt = new DataTable();
            this.DB_open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(Query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dt.Load(dataReader);
                dataReader.Close();
                return dt;
             }

            finally
            { 
                this.DB_close();
            }

        }
        public void ExecuteNonQuery(string Query)
        {
            this.DB_open();
            try
            {
                MySqlCommand cmd = new MySqlCommand(Query, connection);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                this.DB_close();
            }

        }


    }
}
