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
    public partial class SortForm : Form
    {
        private TableManager table;
        public SortForm(TableManager _table, List<string> cols, string order)
        {
            InitializeComponent();
            table = _table;
            if (order == "ASC")
            {
                rbAsc.Checked = true;
            }
            else if(order == "DESC")
            {
                rbDesc.Checked = true;
            }
            cbCol.Items.Add("<default>");
            foreach(string c in cols)
            {
                cbCol.Items.Add(c);
            }
            string selectedItem;
            if (table.OrderBy == "_id_internal") selectedItem = "<default>";
            else selectedItem = table.OrderBy;
            cbCol.SelectedItem = selectedItem;
        }

        private void btSort_Click(object sender, EventArgs e)
        {
            string newOrder = rbAsc.Checked ? "ASC" : "DESC";
            if (cbCol.Text != table.OrderBy || newOrder != table.Order)
            {
                table.OrderBy = cbCol.Text;
                if (table.OrderBy == "<default>") table.OrderBy = "_id_internal";
                table.Order = newOrder;
                table.DsBackend.Clear();
                table.ShowPageAt(table.CurrPage);
            }
            Close();
        }
    }
}
