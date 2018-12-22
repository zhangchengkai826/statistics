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
    public partial class RenameColForm : Form
    {
        TableManager table;
        string oldName;
        public RenameColForm(TableManager _table, string _oldName)
        {
            InitializeComponent();
            table = _table;
            oldName = _oldName;
            tbNewName.Text = oldName;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            table.RenameColInternal(oldName, tbNewName.Text);
            Close();
        }
    }
}
