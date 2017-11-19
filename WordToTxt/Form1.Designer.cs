namespace WordToTxt
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint1 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(0D, 5D);
            System.Windows.Forms.DataVisualization.Charting.DataPoint dataPoint2 = new System.Windows.Forms.DataVisualization.Charting.DataPoint(1D, 8D);
            this.BtnProc = new System.Windows.Forms.Button();
            this.tbGetText = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbFilePath = new System.Windows.Forms.Label();
            this.btnDecode = new System.Windows.Forms.Button();
            this.chtFreq = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.TxtToWordFreq = new System.Diagnostics.Process();
            ((System.ComponentModel.ISupportInitialize)(this.chtFreq)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnProc
            // 
            this.BtnProc.Location = new System.Drawing.Point(44, 89);
            this.BtnProc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.BtnProc.Name = "BtnProc";
            this.BtnProc.Size = new System.Drawing.Size(295, 89);
            this.BtnProc.TabIndex = 0;
            this.BtnProc.Text = "处理文件";
            this.BtnProc.UseVisualStyleBackColor = true;
            this.BtnProc.Click += new System.EventHandler(this.BtnProc_Click);
            // 
            // tbGetText
            // 
            this.tbGetText.Location = new System.Drawing.Point(44, 222);
            this.tbGetText.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbGetText.Multiline = true;
            this.tbGetText.Name = "tbGetText";
            this.tbGetText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbGetText.Size = new System.Drawing.Size(633, 602);
            this.tbGetText.TabIndex = 1;
            // 
            // lbFilePath
            // 
            this.lbFilePath.AutoSize = true;
            this.lbFilePath.Location = new System.Drawing.Point(39, 40);
            this.lbFilePath.Name = "lbFilePath";
            this.lbFilePath.Size = new System.Drawing.Size(59, 27);
            this.lbFilePath.TabIndex = 2;
            this.lbFilePath.Text = "Path:";
            // 
            // btnDecode
            // 
            this.btnDecode.Location = new System.Drawing.Point(382, 89);
            this.btnDecode.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Size = new System.Drawing.Size(295, 89);
            this.btnDecode.TabIndex = 3;
            this.btnDecode.Text = "读取解析";
            this.btnDecode.UseVisualStyleBackColor = true;
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);
            // 
            // chtFreq
            // 
            chartArea1.Name = "ChartArea1";
            this.chtFreq.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chtFreq.Legends.Add(legend1);
            this.chtFreq.Location = new System.Drawing.Point(685, 89);
            this.chtFreq.Name = "chtFreq";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            dataPoint1.Label = "A";
            dataPoint2.Label = "h";
            series1.Points.Add(dataPoint1);
            series1.Points.Add(dataPoint2);
            this.chtFreq.Series.Add(series1);
            this.chtFreq.Size = new System.Drawing.Size(931, 735);
            this.chtFreq.TabIndex = 4;
            this.chtFreq.Text = "chart1";
            // 
            // TxtToWordFreq
            // 
            this.TxtToWordFreq.StartInfo.Arguments = "temp.txt log.txt";
            this.TxtToWordFreq.StartInfo.Domain = "";
            this.TxtToWordFreq.StartInfo.FileName = "TxtToWordFreq.exe";
            this.TxtToWordFreq.StartInfo.LoadUserProfile = false;
            this.TxtToWordFreq.StartInfo.Password = null;
            this.TxtToWordFreq.StartInfo.StandardErrorEncoding = null;
            this.TxtToWordFreq.StartInfo.StandardOutputEncoding = null;
            this.TxtToWordFreq.StartInfo.UserName = "";
            this.TxtToWordFreq.SynchronizingObject = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1628, 859);
            this.Controls.Add(this.chtFreq);
            this.Controls.Add(this.btnDecode);
            this.Controls.Add(this.lbFilePath);
            this.Controls.Add(this.tbGetText);
            this.Controls.Add(this.BtnProc);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Word字数频率统计";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chtFreq)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnProc;
        private System.Windows.Forms.TextBox tbGetText;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbFilePath;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.DataVisualization.Charting.Chart chtFreq;
        private System.Diagnostics.Process TxtToWordFreq;
    }
}

