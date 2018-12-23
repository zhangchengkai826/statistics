using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Npgsql;
using System.Threading;

namespace Statistics
{
    public partial class ExportTableWizard : Form
    {
        private TableManager table;
        private int pageExported = 0;
        private Stopwatch sw;
        private bool isTaskStart = false;
        private string fileName;
        public ExportTableWizard(TableManager _table, string _fileName)
        {
            InitializeComponent();
            table = _table;
            fileName = _fileName;
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            if (!isTaskStart)
            {
                isTaskStart = true;
                sw = System.Diagnostics.Stopwatch.StartNew();
                Task importTk = Task.Run(() =>
                {
                    NpgsqlConnection lclConn = null;
                    try
                    {
                        lclConn = table.Owner.Conn.CloneWith(table.Owner.Conn.ConnectionString);
                        using (StreamWriter sw = new StreamWriter(fileName))
                        {
                            string hdr = "";
                            for (int i = 1; i < table.AssociatiedForm.MainDataGrid.ColumnCount; i++)
                            {
                                hdr += table.AssociatiedForm.MainDataGrid.Columns[i].Name + ", ";
                            }
                            hdr = hdr.Substring(0, hdr.Length - 2);
                            sw.WriteLine(hdr);
                            for (int pageId = 1; pageId <= table.NumPages; pageId++)
                            {
                                string strSql = String.Format(@"SELECT * FROM {0} ORDER BY {1} {2} LIMIT {3} OFFSET {4}", table.Name, table.OrderBy, table.Order, TableManager.RECORDS_PER_PAGE, (pageId - 1) * TableManager.RECORDS_PER_PAGE);
                                try
                                {
                                    NpgsqlDataAdapter lclDa = new NpgsqlDataAdapter(strSql, lclConn);
                                    DataSet lclDs = new DataSet();
                                    lclDa.Fill(lclDs);
                                    DataTable lclDt = lclDs.Tables[0];
                                    for (int recId = 0; recId < lclDt.Rows.Count; recId++)
                                    {
                                        string v = "";
                                        for (int i = 1; i < lclDt.Columns.Count; i++)
                                        {
                                            v += lclDt.Rows[recId][i] + ", ";
                                        }
                                        v = v.Substring(0, v.Length - 2);
                                        sw.WriteLine(v);
                                    }
                                    Interlocked.Increment(ref pageExported);
                                }
                                catch(Exception exe)
                                {
                                    lclConn.Open();
                                }
                            }
                        }
                    }
                    catch (Exception exc)
                    {
                        progressTimer.Stop();
                        MessageBox.Show(exc.Message);
                        if (lclConn != null) lclConn.Close();
                        table.IsBeingExported = false;
                        isTaskStart = false;
                        Close();
                    }
                });
            }
            lblProgress.Text = String.Format(@"{0} page(s) exported / {1} page(s) in total", pageExported, table.NumPages);
            if(pageExported == table.NumPages)
            {
                progressTimer.Stop();
                sw.Stop();
                MessageBox.Show(String.Format(@"Table exported successfully! [Total Time Used {0}s]", (double)sw.ElapsedMilliseconds / 1000.0));
                table.IsBeingExported = false;
                isTaskStart = false;
                Close();
            }
        }

        private void ExportTableWizard_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Table is being exported, please do not close this window. You can edit other tables while waiting.");
            e.Cancel = isTaskStart;
        }
    }
}
