using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Npgsql;
using System.Windows.Forms.DataVisualization.Charting;

namespace Statistics
{
    public partial class DataVisualizerWizard : Form
    {
        private DataVisualizer visualizer;
        private Stopwatch sw;
        private bool isTaskRunning = false;
        private bool isDataNeedsCompose = false;
        private DataTable bindingTable;
        public DataVisualizerWizard(DataVisualizer _visualizer)
        {
            InitializeComponent();
            visualizer = _visualizer;
            List<string> cols = visualizer.GetColumnNames();
            foreach (string i in cols)
            {
                cbSrc1.Items.Add(i);
                cbSrc2.Items.Add(i);
                cbSrc1.SelectedIndex = cbSrc2.SelectedIndex = 0;
            }
            btSave.Enabled = false;
            ctGraph.Series[0].Name = "";
            foreach (var i in Enum.GetValues(typeof(SeriesChartType)))
            {
                cbChartType.Items.Add(i);
            }
            cbChartType.SelectedIndex = 3;
        }

        private void btCompose_Click(object sender, EventArgs e)
        {
            string x = cbSrc1.Text;
            string y = cbSrc2.Text;
            isDataNeedsCompose = false;
            btCompose.Enabled = false;
            btCompose.Text = "Composing...";
            btSave.Enabled = false;
            Task.Run(() =>
            {
                isTaskRunning = true;
                sw = Stopwatch.StartNew();
                NpgsqlConnection lclConn = null;
                try
                {
                    lclConn = visualizer.DbMgr.Conn.CloneWith(visualizer.DbMgr.Conn.ConnectionString);
                    bindingTable = new DataTable();

                    string strSql = String.Format(@"SELECT DISTINCT {0} FROM {1} ORDER BY {0} ASC", x, visualizer.DbMgr.Currtable);
                    NpgsqlCommand cmd = new NpgsqlCommand(strSql, lclConn);
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt1 = ds.Tables[0].Copy();

                    strSql = String.Format(@"SELECT SUM({0}) FROM {1} GROUP BY {2} ORDER BY {2} ASC", y, visualizer.DbMgr.Currtable, x);
                    cmd = new NpgsqlCommand(strSql, lclConn);
                    da = new NpgsqlDataAdapter(cmd);
                    ds = new DataSet();
                    da.Fill(ds);
                    DataTable dt2 = ds.Tables[0].Copy();

                    bindingTable.Columns.Add(x, dt1.Columns[0].DataType);
                    bindingTable.Columns.Add(y, dt2.Columns[0].DataType);
                    for(int i = 0; i < dt1.Rows.Count; i++)
                    {
                        bindingTable.Rows.Add(dt1.Rows[i][0], dt2.Rows[i][0]);
                    }
                    isDataNeedsCompose = true;
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.Message);
                }
                finally
                {
                    if (lclConn != null) lclConn.Close();
                    isTaskRunning = false;
                }
            });
        }

        private ChartValueType GetChartTypeFromDataType(Type type)
        {
            if (type == typeof(DateTime)) return ChartValueType.Date;
            if (type == typeof(double)) return ChartValueType.Double;
            if (type == typeof(float)) return ChartValueType.Single;
            if (type == typeof(int)) return ChartValueType.Int32;
            if (type == typeof(long)) return ChartValueType.Int64;
            if (type == typeof(string)) return ChartValueType.String;
            return ChartValueType.Auto;
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            if (isDataNeedsCompose)
            {
                isDataNeedsCompose = false;
                ctGraph.Series[0].XValueMember = cbSrc1.Text;
                ctGraph.Series[0].YValueMembers = cbSrc2.Text;
                ctGraph.Series[0].XValueType = GetChartTypeFromDataType(bindingTable.Columns[0].DataType);
                ctGraph.Series[0].YValueType = GetChartTypeFromDataType(bindingTable.Columns[1].DataType);
                ctGraph.ChartAreas[0].AxisX.Title = cbSrc1.Text;
                ctGraph.ChartAreas[0].AxisY.Title = cbSrc2.Text;
                ctGraph.Series[0].ChartType = (SeriesChartType)cbChartType.SelectedItem;
                ctGraph.DataSource = bindingTable;
                ctGraph.DataBind();
                btSave.Enabled = true;
                sw.Stop();
                MessageBox.Show(String.Format(@"Graph compose finished. [Time elapsed: {0}s]", (double)sw.ElapsedMilliseconds / 1000.0));
            }
            if (!isTaskRunning)
            {
                btCompose.Enabled = true;
                btCompose.Text = "Compose";
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string ext = saveFileDialog.FileName.Split('.')[1].ToLower();
                    switch (ext)
                    {
                        case "png":
                            ctGraph.SaveImage(saveFileDialog.FileName, ChartImageFormat.Png);
                            break;
                        case "jpeg":
                            ctGraph.SaveImage(saveFileDialog.FileName, ChartImageFormat.Jpeg);
                            break;
                        case "gif":
                            ctGraph.SaveImage(saveFileDialog.FileName, ChartImageFormat.Gif);
                            break;
                        case "tiff":
                            ctGraph.SaveImage(saveFileDialog.FileName, ChartImageFormat.Tiff);
                            break;
                        case "bmp":
                            ctGraph.SaveImage(saveFileDialog.FileName, ChartImageFormat.Bmp);
                            break;
                    }
                }
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
        }
    }
}
