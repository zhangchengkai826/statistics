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
        private DataBaseManager _dbMgr = null;
        private BindingList<object> tblNames = new BindingList<object>();
        public BindingList<object> TblNames { get => tblNames; set => tblNames = value; }
        public int CurrTblIndexInTblLists { get => currTblIndexInTblLists; set => currTblIndexInTblLists = value; }
        private int currTblIndexInTblLists = -1;

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

            mainDataGrid.Location = _getPointFromPercentage(0.25, 0.05);
            mainDataGrid.Size = _getSizeFromPercentage(0.75, 0.85);

            lblTables.Location = _getPointFromPercentage(0, 0.05);
            lblTables.Size = _getSizeFromPercentage(0.25, 0.1);

            tblLists.Location = _getPointFromPercentage(0, 0.15);
            tblLists.Size = _getSizeFromPercentage(0.25, 0.55);

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
            lblPages.Size = _getSizeFromPercentage(0.25, 0.05);

            lblRecords.Location = _getPointFromPercentage(0.5, 0.95);
            lblRecords.Size = _getSizeFromPercentage(0.25, 0.05);
        }

        private void tblLists_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            if (e.Index < 0) return;
            e.DrawBackground();
            Graphics g = e.Graphics;
            if(e.Index == CurrTblIndexInTblLists)
                g.FillRectangle(new SolidBrush(Color.Silver), e.Bounds);
            e.Graphics.DrawString(tblLists.Items[e.Index].ToString(), e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            redrawControls();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _dbMgr = new DataBaseManager(this);
            tblLists.DataSource = tblNames;
            redrawControls();
        }

        private void createUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateUserForm diag = new CreateUserForm(_dbMgr);
            diag.ShowDialog();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _dbMgr.CloseConnection();
        }

        private void newConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartNewConnForm diag = new StartNewConnForm(_dbMgr);
            diag.ShowDialog();
        }

        private void btCreateTbl_Click(object sender, EventArgs e)
        {
            if (_dbMgr.isConnected())
            {
                CreateTblForm diag = new CreateTblForm(_dbMgr);
                diag.Show();
            }
        }

        private void btDelTbl_Click(object sender, EventArgs e)
        {
            if(_dbMgr.isConnected() && tblLists.SelectedItem != null && tblLists.SelectedItem.ToString() != "")
            {
                _dbMgr.DeleteTable(tblLists.SelectedItem.ToString());
            }
        }

        private void btOpenTbl_Click(object sender, EventArgs e)
        {
            if (_dbMgr.isConnected() && tblLists.SelectedItem != null && tblLists.SelectedItem.ToString() != "")
            {
                _dbMgr.OpenTable(tblLists.SelectedItem.ToString());
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dbMgr.isConnected() && tblLists.SelectedItem != null && tblLists.SelectedItem.ToString() != "")
            {
                RenameTblForm diag = new RenameTblForm(_dbMgr, tblLists.SelectedItem.ToString());
                diag.ShowDialog();
            }
        }

        private void tblLists_MouseDown(object sender, MouseEventArgs e)
        {
            tblLists.SelectedIndex = tblLists.IndexFromPoint(e.X, e.Y); 
        }

        private void cmTblList_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = (tblLists.SelectedIndex == -1);
        }

        private void mainDataGrid_MouseDown(object sender, MouseEventArgs e)
        {
            var hti = MainDataGrid.HitTest(e.X, e.Y);
            if (hti.RowIndex >= 0 && hti.ColumnIndex >= 0)
            {
                MainDataGrid.CurrentCell = MainDataGrid[hti.ColumnIndex, hti.RowIndex];
                return;
            }
            if(hti.ColumnIndex >=0 && hti.ColumnIndex < MainDataGrid.ColumnCount && hti.RowIndex < 0)
            {
                MainDataGrid.CurrentCell = MainDataGrid[hti.ColumnIndex, 0];
            }
        }

        private void mainDataGrid_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void cmMainGrid_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = MainDataGrid.IsCurrentCellInEditMode;
        }

        private void sortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dbMgr.Currtable == null)
            {
                MessageBox.Show("Please open a table first!");
                return;
            }
            _dbMgr.Tables[_dbMgr.Currtable].SortRecordsByColumn();
        }

        private void importCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_dbMgr.Conn == null)
            {
                MessageBox.Show("Please start a db connection first!");
                return;
            }
            if (importTableDiag.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _dbMgr.ImportTable(importTableDiag.FileName);
            }
        }

        private void btPrevPage_Click(object sender, EventArgs e)
        {
            if(_dbMgr.Currtable != null)
            {
                _dbMgr.Tables[_dbMgr.Currtable].ShowPrevPage();
            }
        }

        private void btNextPage_Click(object sender, EventArgs e)
        {
            if (_dbMgr.Currtable != null)
            {
                _dbMgr.Tables[_dbMgr.Currtable].ShowNextPage();
            }
        }

        private void goToPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dbMgr.Currtable != null)
            {
                GoToPageForm diag = new GoToPageForm(_dbMgr.Tables[_dbMgr.Currtable].NumPages, _dbMgr.Tables[_dbMgr.Currtable].CurrPage);
                DialogResult dr = diag.ShowDialog();
                if (_dbMgr.Tables[_dbMgr.Currtable].CurrPage == diag.PageGoTo || dr != DialogResult.OK) return;
                _dbMgr.Tables[_dbMgr.Currtable].ShowPageAt(diag.PageGoTo);
            }
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dbMgr.Currtable != null)
            {
                _dbMgr.Tables[_dbMgr.Currtable].InsertRow(sender, e);
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dbMgr.Currtable != null)
            {
                _dbMgr.Tables[_dbMgr.Currtable].DeleteRow(sender, e);
            }
        }

        private void renameColumnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dbMgr.Currtable != null)
            {
                _dbMgr.Tables[_dbMgr.Currtable].RenameCol(sender, e);
            }
        }

        private void mainDataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (_dbMgr.Currtable != null)
            {
                _dbMgr.Tables[_dbMgr.Currtable].UpdateData(sender, e);
            }
        }

        private void exportCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_dbMgr.Currtable != null)
            {
                _dbMgr.Tables[_dbMgr.Currtable].ExportTable();
            }
        }
    }
}
