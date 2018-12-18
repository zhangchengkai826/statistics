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
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.DataGrid = new System.Windows.Forms.DataGridView();
            this.lblTables = new System.Windows.Forms.Label();
            this.lbTables = new System.Windows.Forms.ListBox();
            this.btOpenTbl = new System.Windows.Forms.Button();
            this.btCreateTbl = new System.Windows.Forms.Button();
            this.btDelTbl = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btPrevPage = new System.Windows.Forms.Button();
            this.btNextPage = new System.Windows.Forms.Button();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(800, 27);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // DataGrid
            // 
            this.DataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGrid.Location = new System.Drawing.Point(206, 27);
            this.DataGrid.Name = "DataGrid";
            this.DataGrid.RowTemplate.Height = 23;
            this.DataGrid.Size = new System.Drawing.Size(594, 476);
            this.DataGrid.TabIndex = 1;
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
            // lbTables
            // 
            this.lbTables.FormattingEnabled = true;
            this.lbTables.ItemHeight = 12;
            this.lbTables.Location = new System.Drawing.Point(12, 53);
            this.lbTables.Name = "lbTables";
            this.lbTables.Size = new System.Drawing.Size(188, 352);
            this.lbTables.TabIndex = 3;
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
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(455, 521);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "0 / 0";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(57, 23);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 561);
            this.Controls.Add(this.btNextPage);
            this.Controls.Add(this.btPrevPage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btDelTbl);
            this.Controls.Add(this.btCreateTbl);
            this.Controls.Add(this.btOpenTbl);
            this.Controls.Add(this.lbTables);
            this.Controls.Add(this.lblTables);
            this.Controls.Add(this.DataGrid);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "Statistics version 2.0rc Author: Chengkai Zhang ";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.DataGridView DataGrid;
        private System.Windows.Forms.Label lblTables;
        private System.Windows.Forms.ListBox lbTables;
        private System.Windows.Forms.Button btOpenTbl;
        private System.Windows.Forms.Button btCreateTbl;
        private System.Windows.Forms.Button btDelTbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btPrevPage;
        private System.Windows.Forms.Button btNextPage;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    }
}

