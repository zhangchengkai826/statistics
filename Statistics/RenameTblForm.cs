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
    public partial class RenameTblForm : Form
    {
        DataBaseManager _dbMgr;
        string _oldName;
        public RenameTblForm(DataBaseManager dbMgr, string oldName)
        {
            InitializeComponent();
            _dbMgr = dbMgr;
            tbNewName.Text = oldName;
            _oldName = oldName;
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            _dbMgr.RenameTable(_oldName, tbNewName.Text);
            Close();
        }
    }
}
