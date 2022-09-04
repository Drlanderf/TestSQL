using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace DBmySQL
{
    public class Event_log

    {

        private string myDate = string.Empty;
        private string User = string.Empty;
        private string Computer = string.Empty;

        private string Application = string.Empty;
        private string Module = string.Empty;
        private string Action = string.Empty;
        private string Remarque = string.Empty;


        
        public Event_log()
        {}



        public Event_log(string Application, string Module, string Action, string Remarque)
        {
            this.myDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.User = System.Environment.UserName;
            this.Computer = System.Environment.MachineName;
            this.Application = Application;
            this.Module = Module;
            this.Action = Action;
            this.Remarque = Remarque;
            this.WriteLog();
        }



        private void WriteLog()

        {
            string qry = "INSERT INTO `eventlog`(`DATE_TIME`, `USER`, `COMPUTER`, `APPLICATION`, `MODULE`, `ACTION`, `REMARQUE`) VALUES(" +

                     "'" + this.myDate + "'," +
                     "'" + this.User + "'," +
                     "'" + this.Computer + "'," +
                     "'" + this.Application + "'," +
                     "'" + this.Module + "'," +
                     "'" + this.Action + "'," +
                     "'" + this.Remarque + "')";

            try
            {
                DAL_mySQL myDAL = DAL_mySQL.getInstance();
                myDAL.ExecuteNonQuery(qry);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }



        }



        public DataTable Get_Events()

        {
            DAL_mySQL myDAL = DAL_mySQL.getInstance();
            DataTable dt = myDAL.ExecuteQuery_dt("SELECT * FROM eventlog ORDER BY DATE_TIME DESC");
            return dt;
        }



        public void Create_Table()
        {
            string qry = "CREATE TABLE IF NOT EXISTS `eventlog` ( " +
                             "`ID` bigint(20) NOT NULL AUTO_INCREMENT," +
                             "`DATE_TIME` datetime NOT NULL," +
                             "`USER` varchar(50) NOT NULL," +
                             "`COMPUTER` varchar(50) NOT NULL," +
                             "`APPLICATION` varchar(50) NOT NULL," +
                             "`MODULE` varchar(50) NOT NULL," +
                             "`ACTION` varchar(250) NOT NULL," +
                             "`REMARQUE` varchar(250) NOT NULL," +
                             "PRIMARY KEY(`ID`)" +
                             ") ENGINE = InnoDB  DEFAULT CHARSET = latin1 AUTO_INCREMENT = 1; ";
            try
            {
                DAL_mySQL myDAL = DAL_mySQL.getInstance();
                myDAL.ExecuteNonQuery(qry);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
