namespace TestDemo
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
            this.btn_startHSV2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_startEYE = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.参数配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_stop = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_startHSV2
            // 
            this.btn_startHSV2.Location = new System.Drawing.Point(74, 54);
            this.btn_startHSV2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_startHSV2.Name = "btn_startHSV2";
            this.btn_startHSV2.Size = new System.Drawing.Size(141, 37);
            this.btn_startHSV2.TabIndex = 0;
            this.btn_startHSV2.Text = "启动HSV2.py";
            this.btn_startHSV2.UseVisualStyleBackColor = true;
            this.btn_startHSV2.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(74, 168);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(141, 37);
            this.button4.TabIndex = 4;
            this.button4.Text = "保存眼孔参数";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(284, 168);
            this.button5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(141, 37);
            this.button5.TabIndex = 5;
            this.button5.Text = "保存眼眶参数";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btn_startEYE
            // 
            this.btn_startEYE.Location = new System.Drawing.Point(284, 54);
            this.btn_startEYE.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_startEYE.Name = "btn_startEYE";
            this.btn_startEYE.Size = new System.Drawing.Size(141, 37);
            this.btn_startEYE.TabIndex = 6;
            this.btn_startEYE.Text = "启动eye1.0.py";
            this.btn_startEYE.UseVisualStyleBackColor = true;
            this.btn_startEYE.Click += new System.EventHandler(this.button6_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.配置ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 配置ToolStripMenuItem
            // 
            this.配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.参数配置ToolStripMenuItem});
            this.配置ToolStripMenuItem.Name = "配置ToolStripMenuItem";
            this.配置ToolStripMenuItem.Size = new System.Drawing.Size(44, 22);
            this.配置ToolStripMenuItem.Text = "配置";
            // 
            // 参数配置ToolStripMenuItem
            // 
            this.参数配置ToolStripMenuItem.Name = "参数配置ToolStripMenuItem";
            this.参数配置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.参数配置ToolStripMenuItem.Text = "参数配置";
            this.参数配置ToolStripMenuItem.Click += new System.EventHandler(this.参数配置ToolStripMenuItem_Click);
            // 
            // btn_stop
            // 
            this.btn_stop.Location = new System.Drawing.Point(493, 54);
            this.btn_stop.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_stop.Name = "btn_stop";
            this.btn_stop.Size = new System.Drawing.Size(141, 37);
            this.btn_stop.TabIndex = 8;
            this.btn_stop.Text = "停止Python执行";
            this.btn_stop.UseVisualStyleBackColor = true;
            this.btn_stop.Click += new System.EventHandler(this.btn_stop_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 357);
            this.Controls.Add(this.btn_stop);
            this.Controls.Add(this.btn_startEYE);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_startHSV2);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "TestDemo";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_startHSV2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_startEYE;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 参数配置ToolStripMenuItem;
        private System.Windows.Forms.Button btn_stop;
    }
}

