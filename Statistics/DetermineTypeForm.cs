using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace Statistics
{
    public partial class DetermineTypeForm : Form
    {
        private string fileName;
        private DataBaseManager dbMgr;
        private string[] cols;
        private int totalRecords = 0;
        private bool readFinish = false;
        private int numRecordsCnt = 0;
        private Stopwatch sw;
        private string tblName;
        public DetermineTypeForm(string[] colNames, string[] egVals, string _fileName, DataBaseManager _dbMgr)
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            MainGrid.DataSource = bs;
            dt.Columns.Add("Column Name", typeof(string));
            dt.Columns.Add("Sample Value in File", typeof(string));
            dt.Columns.Add("Specify your target type here", typeof(string));
            for(int i=0; i < colNames.Count(); i++)
            {
                dt.Rows.Add(colNames[i], egVals[i], "");
            }
            fileName = _fileName;
            dbMgr = _dbMgr;
            cols = colNames;
            MainGrid.Columns[0].ReadOnly = true;
            MainGrid.Columns[1].ReadOnly = true;
        }

        private void btImport_Click(object sender, EventArgs e)
        {
            btImport.Enabled = false;
            btImport.Text = "Importing...";
            tbTblName.Enabled = false;
            MainGrid.Enabled = false;

            sw = System.Diagnostics.Stopwatch.StartNew();
            tblName = tbTblName.Text;
            string strSql = String.Format(@"CREATE TABLE {0} (_id_internal serial PRIMARY KEY", tblName);
            for (int i = 0; i < MainGrid.RowCount; i++)
            {
                strSql += String.Format(@", {0} {1}", MainGrid.Rows[i].Cells[0].Value, MainGrid.Rows[i].Cells[2].Value);
            }
            strSql += ")";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(strSql, dbMgr.Conn);
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                totalRecords = numRecordsCnt = 0;
                readFinish = false;
                btImport.Enabled = true;
                btImport.Text = "Import!";
                tbTblName.Enabled = true;
                MainGrid.Enabled = true;
                return;
            }
            dbMgr.MakeTableUnOpenable(tblName);
            Task importTk = Task.Run(() =>
            {
                try
                {
                    using (StreamReader sr = new StreamReader(fileName))
                    {
                        sr.ReadLine();
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            totalRecords++;
                            string[] vals = line.Split(',');

                            string keys = " ";
                            for (int i = 0; i < cols.Length; i++)
                            {
                                keys += cols[i];
                                if (i != cols.Length - 1)
                                    keys += ", ";
                            }
                            keys += " ";
                            string values = " ";
                            for (int i = 0; i < vals.Length; i++)
                            {
                                values += "'" + vals[i] + "'";
                                if (i != vals.Length - 1) values += ", ";
                            }
                            string lclStrSql = String.Format(@"INSERT INTO {0} ({1}) VALUES ({2})", tblName, keys, values);
                            ThreadPool.QueueUserWorkItem(o=> 
                            {
                                NpgsqlConnection lclConn = null;
                                try
                                {
                                    lclConn = dbMgr.Conn.CloneWith(dbMgr.Conn.ConnectionString);
                                    lclConn.Open();
                                    NpgsqlCommand cmd = new NpgsqlCommand(lclStrSql, lclConn);
                                    cmd.ExecuteNonQuery();
                                    lclConn.Close();
                                    Interlocked.Increment(ref numRecordsCnt);
                                }
                                catch
                                {
                                    if(lclConn != null)
                                        lclConn.Close();
                                }
                            });
                        }
                    }
                    readFinish = true;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    strSql = String.Format(@"DROP TABLE {0}", tblName);
                    NpgsqlCommand cmd = new NpgsqlCommand(strSql, dbMgr.Conn);
                    cmd.ExecuteNonQuery();

                    totalRecords = numRecordsCnt = 0;
                    readFinish = false;
                    btImport.Enabled = true;
                    btImport.Text = "Import!";
                    tbTblName.Enabled = true;
                    MainGrid.Enabled = true;
                }
            });
        }

        private void progressBarTimer_Tick(object sender, EventArgs e)
        {
            lblProgress.Text = String.Format(@"{0} insert succeeded / {1} discovered", numRecordsCnt, totalRecords);
            if (readFinish && totalRecords == numRecordsCnt)
            {
                progressBarTimer.Stop();
                dbMgr.UpdateTableList();
                sw.Stop();
                MessageBox.Show(String.Format(@"Table imported successfully! [Total Time Used {0}s]", (double)sw.ElapsedMilliseconds / 1000.0));
                dbMgr.MakeTableOpenable(tblName);
                Close();
            }
        }
    }
}
