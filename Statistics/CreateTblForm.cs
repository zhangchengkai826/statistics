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
    public partial class CreateTblForm : Form
    {
        private Size _getSizeFromPercentage(double x, double y)
        {
            return new Size((int)(ClientSize.Width * x), (int)(ClientSize.Height * y));
        }

        private Point _getPointFromPercentage(double x, double y)
        {
            return new Point((int)(ClientSize.Width * x), (int)(ClientSize.Height * y));
        }

        private DataBaseManager _dbMgr = null;
        public CreateTblForm(DataBaseManager dbMgr)
        {
            InitializeComponent();
            _dbMgr = dbMgr;
        }

        private void btCreate_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> colInfo = new Dictionary<string, string>();
            foreach(Tuple<TextBox, TextBox> x in _ctrlGroups.Values)
            {
                colInfo[x.Item1.Text] = x.Item2.Text;
            }
            _dbMgr.CreateTable(tbTblName.Text, ref colInfo);
            Close();
        }

        private void CreateTblForm_Load(object sender, EventArgs e)
        {
            lblTblName.Location = _getPointFromPercentage(0, 0);
            lblTblName.Size = _getSizeFromPercentage(0.5, 0.05);

            tbTblName.AutoSize = false;
            tbTblName.Location = _getPointFromPercentage(0.5, 0);
            tbTblName.Size = _getSizeFromPercentage(0.5, 0.05);
            tbTblName.Font = new Font("Consolas", (int)(0.04 * ClientSize.Height), GraphicsUnit.Pixel);

            MainPanel.Location = _getPointFromPercentage(0, 0.05);
            MainPanel.Size = _getSizeFromPercentage(1, 0.85);

            btAdd.Location = _getPointFromPercentage(0, 0.9);
            btAdd.Size = _getSizeFromPercentage(0.5, 0.1);

            btCreate.Location = _getPointFromPercentage(0.5, 0.9);
            btCreate.Size = _getSizeFromPercentage(0.5, 0.1);

            lblColName.Size = _getSizeFromPercentage(0.48, 0.05);
            lblColType.Size = _getSizeFromPercentage(0.41, 0.05);
        }

        private Dictionary<Button, Tuple<TextBox, TextBox>> _ctrlGroups = new Dictionary<Button, Tuple<TextBox, TextBox>>();
        private void btAdd_Click(object sender, EventArgs e)
        {
            TextBox tbn = new TextBox();
            tbn.Size = _getSizeFromPercentage(0.49, 0.05);
            tbn.AutoSize = false;
            tbn.Font = new Font("Consolas", (int)(0.04*ClientSize.Height), GraphicsUnit.Pixel);
            MainPanel.Controls.Add(tbn);

            TextBox tbt = new TextBox();
            tbt.Size = _getSizeFromPercentage(0.38, 0.05);
            tbt.AutoSize = false;
            tbt.Font = new Font("Consolas", (int)(0.04 * ClientSize.Height), GraphicsUnit.Pixel);
            MainPanel.Controls.Add(tbt);

            Button x = new Button();
            x.Size = _getSizeFromPercentage(0.05, 0.05);
            x.Text = "X";
            x.Click += removeColumnDef;
            MainPanel.Controls.Add(x);

            _ctrlGroups[x] = new Tuple<TextBox, TextBox>(tbn, tbt);
        }

        private void removeColumnDef(object sender, EventArgs e)
        {
            MainPanel.Controls.Remove((Button)sender);
            MainPanel.Controls.Remove((TextBox)_ctrlGroups[(Button)sender].Item1);
            MainPanel.Controls.Remove((TextBox)_ctrlGroups[(Button)sender].Item2);
            _ctrlGroups.Remove((Button)sender);
        }
    }
}
