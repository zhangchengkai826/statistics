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
    public partial class GoToPageForm : Form
    {
        public int PageGoTo;
        public GoToPageForm(int NumPages, int CurrPage)
        {
            InitializeComponent();
            numericBox.Maximum = NumPages;
            numericBox.Value = CurrPage;
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            PageGoTo = (int)numericBox.Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
