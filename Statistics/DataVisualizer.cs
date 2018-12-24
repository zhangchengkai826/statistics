using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statistics
{
    public class DataVisualizer
    {
        private DataBaseManager dbMgr;
        public DataBaseManager DbMgr { get => dbMgr; }
        private MainForm form;
        public DataVisualizer(DataBaseManager _dbMgr, MainForm _form)
        {
            dbMgr = _dbMgr;
            form = _form;
        }
        public void MakeGraph()
        {
            DataVisualizerWizard wizard = new DataVisualizerWizard(this);
            wizard.Show();
        }
        public List<string> GetColumnNames()
        {
            List<string> cols = new List<string>();
            for (int i = 1; i < form.MainDataGrid.ColumnCount; i++)
            {
                cols.Add(form.MainDataGrid.Columns[i].Name);
            }
            return cols;
        }
    }
}
