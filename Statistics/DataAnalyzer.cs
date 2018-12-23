using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    public class DataAnalyzer
    {
        private StatisticalReport report;
        private DataBaseManager dbMgr;
        private MainForm form;

        public DataAnalyzer(DataBaseManager _dbMgr, MainForm _form)
        {
            dbMgr = _dbMgr;
            form = _form;
        }

        public void StartAnalysis()
        {
            DataAnalyzerWizard wizard = new DataAnalyzerWizard(this);
            wizard.Show();
        }

        public List<string> GetColumnNames()
        {
            List<string> cols = new List<string>();
            for(int i = 1; i < form.MainDataGrid.ColumnCount; i++)
            {
                cols.Add(form.MainDataGrid.Columns[i].Name);
            }
            return cols;
        }
    }
}
