using System.Windows.Forms;

namespace Statistics
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainDataView = new System.Windows.Forms.DataGridView();
            this.lblTables = new System.Windows.Forms.Label();
            this.tblLists = new System.Windows.Forms.ListBox();
            this.btOpenTbl = new System.Windows.Forms.Button();
            this.btCreateTbl = new System.Windows.Forms.Button();
            this.btDelTbl = new System.Windows.Forms.Button();
            this.lblPages = new System.Windows.Forms.Label();
            this.btPrevPage = new System.Windows.Forms.Button();
            this.btNextPage = new System.Windows.Forms.Button();
            this.cmTblList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataView)).BeginInit();
            this.cmTblList.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.databaseToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 27);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(57, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(57, 23);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createUserToolStripMenuItem,
            this.newConnectionToolStripMenuItem});
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(93, 23);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // createUserToolStripMenuItem
            // 
            this.createUserToolStripMenuItem.Name = "createUserToolStripMenuItem";
            this.createUserToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.createUserToolStripMenuItem.Text = "Create User";
            this.createUserToolStripMenuItem.Click += new System.EventHandler(this.createUserToolStripMenuItem_Click);
            // 
            // newConnectionToolStripMenuItem
            // 
            this.newConnectionToolStripMenuItem.Name = "newConnectionToolStripMenuItem";
            this.newConnectionToolStripMenuItem.Size = new System.Drawing.Size(204, 24);
            this.newConnectionToolStripMenuItem.Text = "New Connection";
            this.newConnectionToolStripMenuItem.Click += new System.EventHandler(this.newConnectionToolStripMenuItem_Click);
            // 
            // MainDataView
            // 
            this.MainDataView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataView.Location = new System.Drawing.Point(206, 27);
            this.MainDataView.Name = "MainDataView";
            this.MainDataView.RowTemplate.Height = 23;
            this.MainDataView.Size = new System.Drawing.Size(594, 476);
            this.MainDataView.TabIndex = 1;
            // 
            // lblTables
            // 
            this.lblTables.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTables.Location = new System.Drawing.Point(59, 27);
            this.lblTables.Name = "lblTables";
            this.lblTables.Size = new System.Drawing.Size(100, 23);
            this.lblTables.TabIndex = 2;
            this.lblTables.Text = "Tables";
            this.lblTables.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblLists
            // 
            this.tblLists.ContextMenuStrip = this.cmTblList;
            this.tblLists.Font = new System.Drawing.Font("UD Digi Kyokasho N-R", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tblLists.FormattingEnabled = true;
            this.tblLists.ItemHeight = 15;
            this.tblLists.Location = new System.Drawing.Point(12, 53);
            this.tblLists.Name = "tblLists";
            this.tblLists.Size = new System.Drawing.Size(188, 349);
            this.tblLists.TabIndex = 3;
            this.tblLists.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tblLists_MouseDown);
            // 
            // btOpenTbl
            // 
            this.btOpenTbl.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btOpenTbl.Location = new System.Drawing.Point(12, 419);
            this.btOpenTbl.Name = "btOpenTbl";
            this.btOpenTbl.Size = new System.Drawing.Size(188, 40);
            this.btOpenTbl.TabIndex = 4;
            this.btOpenTbl.Text = "Open";
            this.btOpenTbl.UseVisualStyleBackColor = true;
            this.btOpenTbl.Click += new System.EventHandler(this.btOpenTbl_Click);
            // 
            // btCreateTbl
            // 
            this.btCreateTbl.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCreateTbl.Location = new System.Drawing.Point(12, 465);
            this.btCreateTbl.Name = "btCreateTbl";
            this.btCreateTbl.Size = new System.Drawing.Size(188, 40);
            this.btCreateTbl.TabIndex = 5;
            this.btCreateTbl.Text = "Create";
            this.btCreateTbl.UseVisualStyleBackColor = true;
            this.btCreateTbl.Click += new System.EventHandler(this.btCreateTbl_Click);
            // 
            // btDelTbl
            // 
            this.btDelTbl.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btDelTbl.ForeColor = System.Drawing.Color.Red;
            this.btDelTbl.Location = new System.Drawing.Point(12, 511);
            this.btDelTbl.Name = "btDelTbl";
            this.btDelTbl.Size = new System.Drawing.Size(188, 40);
            this.btDelTbl.TabIndex = 6;
            this.btDelTbl.Text = "Delete";
            this.btDelTbl.UseVisualStyleBackColor = true;
            this.btDelTbl.Click += new System.EventHandler(this.btDelTbl_Click);
            // 
            // lblPages
            // 
            this.lblPages.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblPages.Location = new System.Drawing.Point(455, 521);
            this.lblPages.Name = "lblPages";
            this.lblPages.Size = new System.Drawing.Size(100, 23);
            this.lblPages.TabIndex = 7;
            this.lblPages.Text = "0 / 0";
            this.lblPages.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btPrevPage
            // 
            this.btPrevPage.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btPrevPage.Location = new System.Drawing.Point(206, 511);
            this.btPrevPage.Name = "btPrevPage";
            this.btPrevPage.Size = new System.Drawing.Size(188, 40);
            this.btPrevPage.TabIndex = 8;
            this.btPrevPage.Text = "Prev Page";
            this.btPrevPage.UseVisualStyleBackColor = true;
            // 
            // btNextPage
            // 
            this.btNextPage.Font = new System.Drawing.Font("Segoe UI Light", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btNextPage.Location = new System.Drawing.Point(612, 511);
            this.btNextPage.Name = "btNextPage";
            this.btNextPage.Size = new System.Drawing.Size(188, 40);
            this.btNextPage.TabIndex = 9;
            this.btNextPage.Text = "Next Page";
            this.btNextPage.UseVisualStyleBackColor = true;
            // 
            // cmTblList
            // 
            this.cmTblList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem});
            this.cmTblList.Name = "cmTblList";
            this.cmTblList.Size = new System.Drawing.Size(181, 50);
            this.cmTblList.Opening += new System.ComponentModel.CancelEventHandler(this.cmTblList_Opening);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.btNextPage);
            this.Controls.Add(this.btPrevPage);
            this.Controls.Add(this.lblPages);
            this.Controls.Add(this.btDelTbl);
            this.Controls.Add(this.btCreateTbl);
            this.Controls.Add(this.btOpenTbl);
            this.Controls.Add(this.tblLists);
            this.Controls.Add(this.lblTables);
            this.Controls.Add(this.MainDataView);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Statistics version 2.0rc Author: Chengkai Zhang ";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataView)).EndInit();
            this.cmTblList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.DataGridView MainDataView;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.ListBox tblLists;
        private System.Windows.Forms.Button btOpenTbl;
        private System.Windows.Forms.Button btCreateTbl;
        private System.Windows.Forms.Button btDelTbl;
        private System.Windows.Forms.Label lblPages;
        private System.Windows.Forms.Button btPrevPage;
        private System.Windows.Forms.Button btNextPage;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createUserToolStripMenuItem;
        private ToolStripMenuItem newConnectionToolStripMenuItem;
        private ContextMenuStrip cmTblList;
        private ToolStripMenuItem renameToolStripMenuItem;
    }
}

