using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Data;

namespace Statistics
{
    public class TableManager
    {
        private string name = "";
        private Int64 numRecords = -1;
        private DataBaseManager owner;
        private MainForm form = null;
        private static readonly int RECORDS_PER_PAGE = 100;
        private int currPage = -1;
        private string orderBy = "_id_internal";
        private string order = "ASC";
        private DataTable dt = null;
        private Dictionary<int, DataSet> dsBackend = new Dictionary<int, DataSet>();
        public TableManager(string name, DataBaseManager dbMgr, MainForm form)
        {
            this.name = name;
            this.owner = dbMgr;
            this.form = form;
        }
        private int _getNumPages()
        {
            if (numRecords < 0) return -1;
            else if (numRecords == 0) return 1;
            else return (int)(numRecords-1 / RECORDS_PER_PAGE) + 1;
        }
        public Int64 GetNumRecords()
        {
            try
            {
                string strSql = String.Format(@"SELECT COUNT(*) FROM {0}", name);
                NpgsqlCommand cmd = new NpgsqlCommand(strSql, owner.Conn);
                numRecords = (Int64)cmd.ExecuteScalar();
                return numRecords;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                numRecords = -1;
                return numRecords;
            }
        }
        public void show()
        {
            if(currPage == -1)
            {
                showPageAt(1);
            }
            else
            {
                showPageAt(currPage);
            }
        }
        private DataTable _normalizeDt(DataTable dt)
        {
            dt.Columns[0].ColumnName = "id";
            dt.Columns[0].ReadOnly = true;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][0] = (currPage - 1) * RECORDS_PER_PAGE + i + 1;
            }
            return dt;
        }
        public void showPageAt(int page)
        {
            if (numRecords < 0) // first open that page
            {
                GetNumRecords();
            }
            if (page <= 0 || page > _getNumPages())
            {
                MessageBox.Show("Page index out of range!");
                return;
            }
            currPage = page;
            form.LblPages.Text = String.Format(@"{0} / {1}", currPage, _getNumPages());
            if (!dsBackend.ContainsKey(currPage))
            {
                try
                {
                    string strSql = String.Format(@"SELECT * FROM {0} ORDER BY {1} {2} LIMIT {3} OFFSET {4}", name, orderBy, order, RECORDS_PER_PAGE, RECORDS_PER_PAGE * (currPage - 1));
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(strSql, owner.Conn);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dsBackend[currPage] = ds;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                }
            }
            dt = dsBackend[currPage].Tables[0].Copy();
            dt = _normalizeDt(dt);
            form.MainDataGrid.DataSource = dt;
        }
    }
}
