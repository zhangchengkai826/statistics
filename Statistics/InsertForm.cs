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

namespace Statistics
{
    public partial class InsertForm : Form
    {
        private MainForm form;
        private TableManager table = null;
        private DataTable dt = new DataTable();
        public InsertForm(MainForm _form, TableManager _table)
        {
            InitializeComponent();
            form = _form;
            table = _table;
            BindingSource bs = new BindingSource();
            bs.DataSource = dt;
            for (int i = 1; i < form.MainDataGrid.Columns.Count; i++)
            {
                dt.Columns.Add(form.MainDataGrid.Columns[i].Name, form.MainDataGrid.Columns[i].ValueType);
            }
            InsertData.DataSource = bs;
        }

        private void btInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string keys = " ";
                for (int i = 0; i < InsertData.ColumnCount; i++)
                {
                    keys += InsertData.Columns[i].Name;
                    if (i != InsertData.ColumnCount - 1)
                        keys += ", ";
                }
                keys += " ";
                string values = "";
                for (int rowId = 0; rowId < InsertData.RowCount - 1; rowId++)
                {
                    DataGridViewRow rw = InsertData.Rows[rowId];
                    string v = "( ";
                    for (int i = 0; i < rw.Cells.Count; i++)
                    {
                        if (rw.Cells[i].Value == null || rw.Cells[i].Value == DBNull.Value || String.IsNullOrWhiteSpace(rw.Cells[i].Value.ToString()))
                        {
                            MessageBox.Show("Some cells remains empty!");
                            return;
                        }
                        v += "'" + rw.Cells[i].Value + "'";
                        if (i != rw.Cells.Count - 1) v += ", ";
                    }
                    v += " ), ";
                    values += v;
                }
                values = values.Substring(0, values.Length - 2);
                string strSql = String.Format(@"INSERT INTO {0} ({1}) VALUES {2}", table.Name, keys, values);
                NpgsqlCommand cmd = new NpgsqlCommand(strSql, table.Owner.Conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show(String.Format(@"Insert succeed!"));
                table.NumRecords += InsertData.RowCount - 1;
                Close();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                return;
            }
        }

        private void InsertData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }
    }
}
