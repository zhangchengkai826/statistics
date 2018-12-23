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
using System.IO;
using Npgsql;
using System.Threading;

namespace Statistics
{
    public partial class DataAnalyzerWizard : Form
    {
        private int allTask;
        private int finishedTask = 0;
        private DataAnalyzer analyzer;
        private bool isTaskRunning = false;
        private bool isReportReady = false;

        public DataAnalyzerWizard(DataAnalyzer _analyzer)
        {
            InitializeComponent();
            analyzer = _analyzer;
            foreach (var i in Enum.GetValues(typeof(StatisticFigureType)))
            {
                cbStatType.Items.Add(i);
            }
            cbStatType.SelectedIndex = 0;
            cbSrc2.Hide();
            lblSrc2.Hide();
            List<string> cols = analyzer.GetColumnNames();
            foreach (string i in cols)
            {
                cbSrc1.Items.Add(i);
                cbSrc2.Items.Add(i);
                cbSrc1.SelectedIndex = cbSrc2.SelectedIndex = 0;
            }
            btSave.Enabled = false;
            tbReport.ReadOnly = true;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            allTask = tbStatNeedsAnalyze.Items.Count;
            if (allTask < 1) return;
            isReportReady = false;
            tbReport.Clear();
            btSave.Enabled = false;
            btStart.Enabled = false;
            btStart.Text = "Analyzing...";
            btAdd.Enabled = false;
            btRemove.Enabled = false;
            progressTimer.Start();
            Task AnalyzeTk = Task.Run(() =>
            {
                isTaskRunning = true;
                Stopwatch sw = Stopwatch.StartNew();
                try
                {
                    Parallel.For(0, allTask, index =>
                    {
                        StatisticFigure s = (StatisticFigure)tbStatNeedsAnalyze.Items[index];
                        Analyze(ref s);
                    });
                    isReportReady = true;
                    isTaskRunning = false;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    isReportReady = false;
                }
                finally
                {
                    isTaskRunning = false;
                }
            });
        }

        private void Analyze(ref StatisticFigure s) {
            NpgsqlConnection lclConn = null;
            try
            {
                string strSql;
                NpgsqlCommand cmd;
                lclConn = analyzer.DbMgr.Conn.CloneWith(analyzer.DbMgr.Conn.ConnectionString);
                lclConn.Open();
                switch (s.type)
                {
                    case StatisticFigureType.Mean:
                        strSql = String.Format(@"SELECT AVG({0}) FROM {1}", s.parameters[0], analyzer.DbMgr.Currtable);
                        cmd = new NpgsqlCommand(strSql, lclConn);
                        s.value = (double)cmd.ExecuteScalar();
                        break;
                    case StatisticFigureType.Variance:
                        strSql = String.Format(@"SELECT VAR_POP({0}) FROM {1}", s.parameters[0], analyzer.DbMgr.Currtable);
                        cmd = new NpgsqlCommand(strSql, lclConn);
                        s.value = (double)cmd.ExecuteScalar();
                        break;
                    case StatisticFigureType.StandardDeviation:
                        strSql = String.Format(@"SELECT STDDEV_POP({0}) FROM {1}", s.parameters[0], analyzer.DbMgr.Currtable);
                        cmd = new NpgsqlCommand(strSql, lclConn);
                        s.value = (double)cmd.ExecuteScalar();
                        break;
                    case StatisticFigureType.Covariance:
                        strSql = String.Format(@"SELECT COVAR_POP({0}, {1}) FROM {2}", s.parameters[1], s.parameters[0], analyzer.DbMgr.Currtable);
                        cmd = new NpgsqlCommand(strSql, lclConn);
                        s.value = (double)cmd.ExecuteScalar();
                        break;
                    case StatisticFigureType.CorrelationCoefficient:
                        strSql = String.Format(@"SELECT CORR({0}, {1}) FROM {2}", s.parameters[1], s.parameters[0], analyzer.DbMgr.Currtable);
                        cmd = new NpgsqlCommand(strSql, lclConn);
                        s.value = (double)cmd.ExecuteScalar();
                        break;
                }
                Interlocked.Increment(ref finishedTask);
            }
            catch(Exception exe)
            {
                MessageBox.Show(exe.Message);
            }
            finally
            {
                if (lclConn != null) lclConn.Close();
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {

        }

        private void cbStatType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            switch ((StatisticFigureType)cbStatType.SelectedItem)
            {
                case StatisticFigureType.Mean:
                case StatisticFigureType.Variance:
                case StatisticFigureType.StandardDeviation:
                    cbSrc2.Hide();
                    lblSrc2.Hide();
                    break;
                case StatisticFigureType.Covariance:
                case StatisticFigureType.CorrelationCoefficient:
                    cbSrc2.Show();
                    lblSrc2.Show();
                    break;
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            StatisticFigure s = new StatisticFigure();
            s.type = (StatisticFigureType)cbStatType.SelectedItem;
            if (cbSrc2.Visible)
            {
                s.parameters = new string[] { (string)cbSrc1.SelectedItem, (string)cbSrc2.SelectedItem };
            }
            else
            {
                s.parameters = new string[] { (string)cbSrc1.SelectedItem };
            }
            tbStatNeedsAnalyze.Items.Add(s);
        }

        private void btRemove_Click(object sender, EventArgs e)
        {
            if(tbStatNeedsAnalyze.SelectedIndex >= 0)
            {
                tbStatNeedsAnalyze.Items.RemoveAt(tbStatNeedsAnalyze.SelectedIndex);
            }
        }

        private void progressTimer_Tick(object sender, EventArgs e)
        {
            lblProgress.Text = String.Format(@"{0} stats analyzes / {1} in total", finishedTask, allTask);
            if(isReportReady && progressTimer.Enabled)
            {
                isReportReady = false;
                progressTimer.Stop();
                btStart.Text = "Start Analyze";
                btStart.Enabled = true;
                btAdd.Enabled = true;
                btRemove.Enabled = true;
                btSave.Enabled = true;
            }
        }
    }
}
