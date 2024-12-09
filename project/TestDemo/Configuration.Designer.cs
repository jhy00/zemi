namespace TestDemo
{
    partial class Configuration
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
            this.label1 = new System.Windows.Forms.Label();
            this.txt_python = new System.Windows.Forms.TextBox();
            this.btn_Open = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(89, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Python解释器：";
            // 
            // txt_python
            // 
            this.txt_python.Font = new System.Drawing.Font("宋体", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txt_python.Location = new System.Drawing.Point(393, 115);
            this.txt_python.Name = "txt_python";
            this.txt_python.Size = new System.Drawing.Size(692, 50);
            this.txt_python.TabIndex = 1;
            // 
            // btn_Open
            // 
            this.btn_Open.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_Open.Location = new System.Drawing.Point(1134, 115);
            this.btn_Open.Name = "btn_Open";
            this.btn_Open.Size = new System.Drawing.Size(127, 50);
            this.btn_Open.TabIndex = 2;
            this.btn_Open.Text = "···";
            this.btn_Open.UseVisualStyleBackColor = true;
            this.btn_Open.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Font = new System.Drawing.Font("宋体", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_ok.Location = new System.Drawing.Point(456, 275);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(486, 90);
            this.btn_ok.TabIndex = 3;
            this.btn_ok.Text = "确定";
            this.btn_ok.UseVisualStyleBackColor = true;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Configuration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1418, 525);
            this.Controls.Add(this.btn_ok);
            this.Controls.Add(this.btn_Open);
            this.Controls.Add(this.txt_python);
            this.Controls.Add(this.label1);
            this.Name = "Configuration";
            this.Text = "参数配置";
            this.Load += new System.EventHandler(this.Configuration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_python;
        private System.Windows.Forms.Button btn_Open;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}