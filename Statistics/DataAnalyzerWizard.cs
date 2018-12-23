using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Statistics
{
    public partial class DataAnalyzerWizard : Form
    {
        private int allTask;
        private int finishedTask = 0;
        private DataAnalyzer analyzer;

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
        }

        private void btStart_Click(object sender, EventArgs e)
        {

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
    }
}
