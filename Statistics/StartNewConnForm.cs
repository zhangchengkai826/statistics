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
    public partial class StartNewConnForm : Form
    {
        private DataBaseManager _dbMgr = null;
        public StartNewConnForm(DataBaseManager dbMgr)
        {
            InitializeComponent();
            _dbMgr = dbMgr;
        }

        private void btConn_Click(object sender, EventArgs e)
        {
            if (tbUsrName.Text != null && tbPw.Text != null && !String.IsNullOrWhiteSpace(tbUsrName.Text) && !String.IsNullOrWhiteSpace(tbPw.Text))
            {
                _dbMgr.StartConnection(tbUsrName.Text, tbPw.Text);
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }
    }
}
