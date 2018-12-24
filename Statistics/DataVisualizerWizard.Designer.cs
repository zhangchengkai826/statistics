namespace Statistics
{
    partial class DataVisualizerWizard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btSave = new System.Windows.Forms.Button();
            this.btCompose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbSrc1 = new System.Windows.Forms.ComboBox();
            this.lblSrc2 = new System.Windows.Forms.Label();
            this.cbSrc2 = new System.Windows.Forms.ComboBox();
            this.ctGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbChartType = new System.Windows.Forms.ComboBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ctGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // btSave
            // 
            this.btSave.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btSave.Location = new System.Drawing.Point(648, 400);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(121, 38);
            this.btSave.TabIndex = 23;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // btCompose
            // 
            this.btCompose.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btCompose.Location = new System.Drawing.Point(648, 356);
            this.btCompose.Name = "btCompose";
            this.btCompose.Size = new System.Drawing.Size(121, 38);
            this.btCompose.TabIndex = 22;
            this.btCompose.Text = "Compose";
            this.btCompose.UseVisualStyleBackColor = true;
            this.btCompose.Click += new System.EventHandler(this.btCompose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(643, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Source Column 1";
            // 
            // cbSrc1
            // 
            this.cbSrc1.FormattingEnabled = true;
            this.cbSrc1.Location = new System.Drawing.Point(648, 88);
            this.cbSrc1.Name = "cbSrc1";
            this.cbSrc1.Size = new System.Drawing.Size(121, 20);
            this.cbSrc1.TabIndex = 18;
            // 
            // lblSrc2
            // 
            this.lblSrc2.AutoSize = true;
            this.lblSrc2.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSrc2.Location = new System.Drawing.Point(643, 111);
            this.lblSrc2.Name = "lblSrc2";
            this.lblSrc2.Size = new System.Drawing.Size(149, 25);
            this.lblSrc2.TabIndex = 17;
            this.lblSrc2.Text = "Source Column 2";
            // 
            // cbSrc2
            // 
            this.cbSrc2.FormattingEnabled = true;
            this.cbSrc2.Location = new System.Drawing.Point(648, 139);
            this.cbSrc2.Name = "cbSrc2";
            this.cbSrc2.Size = new System.Drawing.Size(121, 20);
            this.cbSrc2.TabIndex = 16;
            // 
            // ctGraph
            // 
            chartArea3.Name = "ChartArea1";
            this.ctGraph.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.ctGraph.Legends.Add(legend3);
            this.ctGraph.Location = new System.Drawing.Point(7, 9);
            this.ctGraph.Name = "ctGraph";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.ctGraph.Series.Add(series3);
            this.ctGraph.Size = new System.Drawing.Size(630, 438);
            this.ctGraph.TabIndex = 24;
            this.ctGraph.Text = "chart1";
            // 
            // progressTimer
            // 
            this.progressTimer.Enabled = true;
            this.progressTimer.Interval = 1000;
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Light", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(643, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Chart Type";
            // 
            // cbChartType
            // 
            this.cbChartType.FormattingEnabled = true;
            this.cbChartType.Location = new System.Drawing.Point(648, 190);
            this.cbChartType.Name = "cbChartType";
            this.cbChartType.Size = new System.Drawing.Size(121, 20);
            this.cbChartType.TabIndex = 25;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif |JPEG Image (.jpeg)|*.jpeg |Png " +
    "Image (.png)|*.png |Tiff Image (.tiff)|*.tiff";
            // 
            // DataVisualizerWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbChartType);
            this.Controls.Add(this.ctGraph);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btCompose);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSrc1);
            this.Controls.Add(this.lblSrc2);
            this.Controls.Add(this.cbSrc2);
            this.Name = "DataVisualizerWizard";
            this.Text = "Data Visualizer Wizard";
            ((System.ComponentModel.ISupportInitialize)(this.ctGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btCompose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSrc1;
        private System.Windows.Forms.Label lblSrc2;
        private System.Windows.Forms.ComboBox cbSrc2;
        private System.Windows.Forms.DataVisualization.Charting.Chart ctGraph;
        private System.Windows.Forms.Timer progressTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbChartType;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}