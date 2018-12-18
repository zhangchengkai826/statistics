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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Size _getSizeFromPercentage(double x, double y)
        {
            return new Size((int)(ClientSize.Width * x), (int)(ClientSize.Height * y));
        }

        private Point _getPointFromPercentage(double x, double y)
        {
            return new Point((int)(ClientSize.Width * x), (int)(ClientSize.Height * y));
        }

        public void redrawControls()
        {
            MainMenu.Location = _getPointFromPercentage(0, 0);
            MainMenu.Size = _getSizeFromPercentage(1, 0.05);

            MainDataView.Location = _getPointFromPercentage(0.25, 0.05);
            MainDataView.Size = _getSizeFromPercentage(0.75, 0.85);

            lblTables.Location = _getPointFromPercentage(0, 0.05);
            lblTables.Size = _getSizeFromPercentage(0.25, 0.1);

            TblLists.Location = _getPointFromPercentage(0, 0.15);
            TblLists.Size = _getSizeFromPercentage(0.25, 0.55);

            btOpenTbl.Location = _getPointFromPercentage(0, 0.7);
            btOpenTbl.Size = _getSizeFromPercentage(0.25, 0.1);

            btCreateTbl.Location = _getPointFromPercentage(0, 0.8);
            btCreateTbl.Size = _getSizeFromPercentage(0.25, 0.1);

            btDelTbl.Location = _getPointFromPercentage(0, 0.9);
            btDelTbl.Size = _getSizeFromPercentage(0.25, 0.1);

            btPrevPage.Location = _getPointFromPercentage(0.25, 0.9);
            btPrevPage.Size = _getSizeFromPercentage(0.25, 0.1);

            btNextPage.Location = _getPointFromPercentage(0.75, 0.9);
            btNextPage.Size = _getSizeFromPercentage(0.25, 0.1);

            lblPages.Location = _getPointFromPercentage(0.5, 0.9);
            lblPages.Size = _getSizeFromPercentage(0.25, 0.1);
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            redrawControls();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            redrawControls();
        }
    }
}
