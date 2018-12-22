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
        public string Name { get => name; }
        private Int64 numRecords = -1;
        public Int64 NumRecords
        {
            get
            {
                if (numRecords != -1) return numRecords;
                try
                {
                    string strSql = String.Format(@"SELECT COUNT(*) FROM {0}", name);
                    NpgsqlCommand cmd = new NpgsqlCommand(strSql, owner.Conn);
                    NumRecords = (Int64)cmd.ExecuteScalar();
                    return numRecords;
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message);
                    NumRecords = -1;
                    return numRecords;
                }
            }
            set
            {
                numRecords = value;
                form.Lblrecords.Text = numRecords + " record(s)";
            }
        }
        private int numPages = -1;
        public int NumPages
        {
            get
            {
                int newNumPages;
                if (NumRecords < 0) {
                    newNumPages = -1;
                }
                else if (NumRecords == 0) newNumPages = 1;
                else newNumPages = (int)((NumRecords - 1) / RECORDS_PER_PAGE) + 1;
                if (newNumPages != numPages)
                {
                    numPages = newNumPages;
                    form.LblPages.Text = currPage + " / " + numPages;
                }
                return numPages;  
            }
        }
        private DataBaseManager owner;
        public DataBaseManager Owner { get => owner; }
        private MainForm form = null;
        private static readonly int RECORDS_PER_PAGE = 100;
        private int currPage = -1;
        private string orderBy = "_id_internal";
        private string order = "ASC";
        private DataTable dt = null;
        public DataTable Dt { get => dt; }
        private Dictionary<int, DataSet> dsBackend = new Dictionary<int, DataSet>();
        public TableManager(string name, DataBaseManager dbMgr, MainForm form)
        {
            this.name = name;
            this.owner = dbMgr;
            this.form = form;
        }
        public void show()
        {
            if (currPage == -1)
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
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i][0] = (currPage - 1) * RECORDS_PER_PAGE + i + 1;
            }
            return dt;
        }
        public void showPageAt(int page)
        {
            if (page <= 0 || page > NumPages)
            {
                MessageBox.Show("Page index out of range!");
                return;
            }
            currPage = page;
            form.LblPages.Text = String.Format(@"{0} / {1}", currPage, NumPages);
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

        private void ShowLastPageInDefaultOrder()
        {
            orderBy = "_id_internal";
            order = "ASC";
            showPageAt(NumPages);
        }

        public void InsertRow(object sender, EventArgs e)
        {
            InsertForm diag = new InsertForm(form, this);
            diag.ShowDialog();
            if (dsBackend.ContainsKey(NumPages)) dsBackend.Remove(NumPages);
            ShowLastPageInDefaultOrder();
        }

        public void DeleteRow(object sender, EventArgs e)
        {
            if (form.MainDataGrid.SelectedCells.Count < 1) return;
            try
            {
                int id = (int)form.MainDataGrid.CurrentRow.Cells[0].Value;
                int idInpage = id - (currPage - 1) * RECORDS_PER_PAGE - 1; // start from 0
                int idInternal = (int)dsBackend[currPage].Tables[0].Rows[idInpage][0];
                string strSql = String.Format(@"DELETE FROM {0} WHERE _id_internal={1}", Name, idInternal);
                NpgsqlCommand cmd = new NpgsqlCommand(strSql, Owner.Conn);
                cmd.ExecuteNonQuery();
                NumRecords -= 1;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            for(int i=currPage;i<=NumPages+1;i++)
                if (dsBackend.ContainsKey(i)) dsBackend.Remove(i);
            showPageAt(currPage);
        }
    }
}
