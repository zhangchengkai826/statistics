using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace Statistics
{
    public class DataBaseManager
    {
        public void createUser(string userName, string passWord)
        {
            string strConn = @"Provider=Npgsql;" +
                             @"Data Source=localhost;" +
                             @"location=stat_admin_db;" +
                             @"User ID=stat_admin;";
            OleDbConnection adminConn = new OleDbConnection(strConn);
            adminConn.Open();

            string strSql = String.Format(@"CREATE ROLE {0} WITH LOGIN ENCRYPTED PASSWORD '{1}'", userName, passWord);
            OleDbCommand cmd = new OleDbCommand(strSql, adminConn);
            cmd.ExecuteNonQuery();

            strSql = String.Format(@"GRANT {0} TO stat_admin", userName);
            cmd = new OleDbCommand(strSql, adminConn);
            cmd.ExecuteNonQuery();

            strSql = String.Format(@"CREATE DATABASE {0} WITH OWNER {1} ENCODING 'UTF8'", userName + "_db", userName);
            cmd = new OleDbCommand(strSql, adminConn);
            cmd.ExecuteNonQuery();

            adminConn.Close();
        }
    }
}
