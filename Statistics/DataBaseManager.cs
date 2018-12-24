using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;
using System.IO;

namespace Statistics
{
    public class DataBaseManager
    {
        private NpgsqlConnection conn = null;
        private MainForm form = null;
        private Dictionary<string, TableManager> tables = new Dictionary<string, TableManager>();
        public Dictionary<string, TableManager> Tables { get => tables; }
        private string currtable = null;
        public string Currtable { get => currtable; }
        public NpgsqlConnection Conn { get => conn; }
        private HashSet<string> tblsPreventOpening = new HashSet<string>();

        public void MakeTableUnOpenable(string name)
        {
            tblsPreventOpening.Add(name);
        }
        public void MakeTableOpenable(string name)
        {
            if (tblsPreventOpening.Contains(name))
                tblsPreventOpening.Remove(name);
        }
        public bool IsTableOpenable(string name)
        {
            if (tblsPreventOpening.Contains(name))
                return false;
            return true;
        }

        public DataBaseManager(MainForm form)
        {
            this.form = form;
        }

        public bool isConnected()
        {
            return Conn != null;
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
                tables.Clear();
                currtable = null;
                tblsPreventOpening.Clear();
                if (conn != null)
                {
                    conn.Close();
                }
                string strConnF = @"Host=localhost;" +
                                  @"Port=5432;" +
                                  @"Database={0}_db;" +
                                  @"Username={0};" +
                                  @"Password={1};";
                conn = new NpgsqlConnection(String.Format(strConnF, userName, passWord));
                conn.Open();

                UpdateTableList();

                MessageBox.Show(String.Format(@"Successfully connected as '{0}'!", userName));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public void CloseConnection()
        {
            if(conn != null)
            {
                conn.Close();
            }
        }

        public void UpdateTableList()
        {
            try
            {
                string strSql = @"SELECT table_name FROM information_schema.tables WHERE table_schema='public' AND table_type='BASE TABLE'";
                NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn);
                NpgsqlDataReader rdr = cmd.ExecuteReader();

                form.TblNames.Clear();
                Dictionary<string, TableManager> tables_tmp = new Dictionary<string, TableManager>();
                while (rdr.Read())
                {
                    string tbName = rdr.GetString(0);
                    form.TblNames.Add(tbName);
                    if (tables.ContainsKey(tbName)) tables_tmp[tbName] = tables[tbName];
                    else tables_tmp[tbName] = new TableManager(tbName, this, form);
                }
                rdr.Close();
                tables = tables_tmp;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
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
                NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn);
                cmd.ExecuteNonQuery();

                UpdateTableList();

                MessageBox.Show(String.Format(@"Table '{0}' created successfully!", tblName));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        public void DeleteTable(string tblName)
        {
            if (conn == null) return;
            try
            {
                string strSql = String.Format(@"DROP TABLE {0}", tblName);
                NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn);
                cmd.ExecuteNonQuery();

                UpdateTableList();

                MessageBox.Show(String.Format(@"Table '{0}' deleted!", tblName));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            if(tblName == currtable)
            {
                CloseTable();
            }
        }
        public void CloseTable()
        {
            form.CurrTblIndexInTblLists = -1;
            form.TblLists.Invalidate();
            currtable = null;
            form.MainDataGrid.ContextMenuStrip = null;
            form.MainDataGrid.DataSource = null;
            form.Lblrecords.Text = "0 record(s)";
            form.LblPages.Text = "0 / 0";
        }
        public void OpenTable(string tblName)
        {
            if (!IsTableOpenable(tblName))
            {
                MessageBox.Show("This table is still being imported, please wait!");
                return;
            }
            currtable = tblName;
            form.CurrTblIndexInTblLists = form.TblLists.FindStringExact(currtable);
            form.TblLists.Invalidate();
            tables[currtable].show();
            form.MainDataGrid.ContextMenuStrip = form.CmMainGrid;
            form.Lblrecords.Text = tables[currtable].NumRecords + " record(s)";
        }
        public void RenameTable(string oldName, string newName)
        {
            if (oldName == newName) return;
            try
            {
                string strSql = String.Format(@"ALTER TABLE {0} RENAME TO {1}", oldName, newName);
                NpgsqlCommand cmd = new NpgsqlCommand(strSql, conn);
                cmd.ExecuteNonQuery();
                tables[newName] = tables[oldName];
                tables.Remove(oldName);

                UpdateTableList();

                MessageBox.Show(String.Format(@"Rename table {0} to {1}!", oldName, newName));
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            if (oldName == currtable) OpenTable(newName);
        }
        public void ImportTable(string fileName)
        {
            try
            {
                string[] cols, vals;
                using (StreamReader sr = new StreamReader(fileName))
                {
                    string line = sr.ReadLine();
                    cols = line.Split(',');
                    line = sr.ReadLine();
                    vals = line.Split(',');
                }
                DetermineTypeForm diag = new DetermineTypeForm(cols, vals, fileName, this);
                diag.Show();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}
