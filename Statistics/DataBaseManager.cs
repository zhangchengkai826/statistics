using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Statistics
{
    public class DataBaseManager
    {
        private NpgsqlConnection _conn = null;
        private MainForm _form = null;
        private Dictionary<string, TableManager> tables = new Dictionary<string, TableManager>();
        private TableManager currtable = null;
        public TableManager Currtable { get; }

        public DataBaseManager(MainForm form)
        {
            _form = form;
        }

        public bool isConnected()
        {
            return _conn != null;
        }

        public void createUser(string userName, string passWord)
        {
            NpgsqlConnection adminConn = null;
            try
            {
                string strConn = @"Host=localhost;" +
                                 @"Port=5432;" +
                                 @"Database=stat_admin_db;" +
                                 @"Username=stat_admin;" +
                                 @"Password=23FG87X4;";
                adminConn = new NpgsqlConnection(strConn);
                adminConn.Open();

                string strSql = String.Format(@"CREATE ROLE {0} WITH LOGIN ENCRYPTED PASSWORD '{1}'", userName, passWord);
                NpgsqlCommand cmd = new NpgsqlCommand(strSql, adminConn);
                cmd.ExecuteNonQuery();

                strSql = String.Format(@"GRANT {0} TO stat_admin", userName);
                cmd = new NpgsqlCommand(strSql, adminConn);
                cmd.ExecuteNonQuery();

                strSql = String.Format(@"CREATE DATABASE {0} WITH OWNER {1} ENCODING 'UTF8'", userName + "_db", userName);
                cmd = new NpgsqlCommand(strSql, adminConn);
                cmd.ExecuteNonQuery();

                MessageBox.Show(String.Format(@"User {0} created successfully!", userName));
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                if (adminConn != null)
                {
                    adminConn.Close();
                }
            }
        }

        public void StartConnection(string userName, string passWord)
        {
            try
            {
                if (_conn != null)
                {
                    _conn.Close();
                }
                string strConnF = @"Host=localhost;" +
                                  @"Port=5432;" +
                                  @"Database={0}_db;" +
                                  @"Username={0};" +
                                  @"Password={1};";
                string strConn = String.Format(strConnF, userName, passWord);
                _conn = new NpgsqlConnection(strConn);
                _conn.Open();

                _updateTblList();

                MessageBox.Show(String.Format(@"Successfully connected as '{0}'!", userName));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                if (_conn != null)
                {
                    _conn.Close();
                }
            }
        }

        public void CloseConnection()
        {
            if(_conn != null)
            {
                _conn.Close();
            }
        }

        private void _updateTblList()
        {
            string strSql = @"SELECT table_name FROM information_schema.tables WHERE table_schema='public' AND table_type='BASE TABLE'";
            NpgsqlCommand cmd = new NpgsqlCommand(strSql, _conn);
            NpgsqlDataReader rdr = cmd.ExecuteReader();

            _form.TblNames.Clear();
            Dictionary<string, TableManager> tables_tmp = new Dictionary<string, TableManager>();
            while (rdr.Read())
            {
                string tbName = rdr.GetString(0);
                _form.TblNames.Add(tbName);
                if (tables.ContainsKey(tbName)) tables_tmp[tbName] = tables[tbName];
                else tables_tmp[tbName] = new TableManager(tbName);
            }
            rdr.Close();
            tables = tables_tmp;
        }

        public void CreateTable(string tblName, ref Dictionary<string, string> tblCols)
        {
            try
            {
                string strSql = String.Format(@"CREATE TABLE {0} (_id_internal serial PRIMARY KEY", tblName);
                foreach(KeyValuePair<string, string> entry in tblCols)
                {
                    strSql += String.Format(@", {0} {1}", entry.Key, entry.Value);
                }
                strSql += ")";
                NpgsqlCommand cmd = new NpgsqlCommand(strSql, _conn);
                cmd.ExecuteNonQuery();

                _updateTblList();

                MessageBox.Show(String.Format(@"Table '{0}' created successfully!", tblName));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void DeleteTable(string tblName)
        {
            if (_conn == null) return;
            try
            {
                string strSql = String.Format(@"DROP TABLE {0}", tblName);
                NpgsqlCommand cmd = new NpgsqlCommand(strSql, _conn);
                cmd.ExecuteNonQuery();

                _updateTblList();

                MessageBox.Show(String.Format(@"Table '{0}' deleted!", tblName));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void OpenTable(string tblName)
        {
            currtable = tables[tblName];
        }

        public void RenameTable(string oldName, string newName)
        {
            if (oldName == newName) return;
            try
            {
                string strSql = String.Format(@"ALTER TABLE {0} RENAME TO {1}", oldName, newName);
                NpgsqlCommand cmd = new NpgsqlCommand(strSql, _conn);
                cmd.ExecuteNonQuery();
                tables[newName] = tables[oldName];
                tables.Remove(oldName);

                _updateTblList();

                MessageBox.Show(String.Format(@"Rename table {0} to {1}!", oldName, newName));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
