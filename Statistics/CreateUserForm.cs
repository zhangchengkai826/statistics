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
    public partial class CreateUserForm : Form
    {
        private DataBaseManager _dbMgr;

        public CreateUserForm(DataBaseManager dbMgr)
        {
            InitializeComponent();
            _dbMgr = dbMgr;
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            if (tbUsrName.Text != null && tbPw.Text != null && !String.IsNullOrWhiteSpace(tbUsrName.Text) && !String.IsNullOrWhiteSpace(tbPw.Text))
            {
                _dbMgr.createUser(tbUsrName.Text, tbPw.Text);
                Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password!");
            }
        }
    }
}
