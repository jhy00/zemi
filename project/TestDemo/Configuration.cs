using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestDemo
{
    public partial class Configuration : Form
    {
        public Configuration()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 选择python解释器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Open_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "请选择你的Python解释器";
            openFileDialog1.Filter = "exe可执行文件（*.exe）|*.exe";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_python.Text = openFileDialog1.FileName;
                GlobalData.pythonScript = openFileDialog1.FileName;
                MessageBox.Show("设置成功");
            }
        }

        /// <summary>
        /// 确定pytho解释器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ok_Click(object sender, EventArgs e)
        {
            string pythonScript = txt_python.Text.Trim();
            if(pythonScript.Length == 0)
            {
                MessageBox.Show("请选择python解释器");
                return;
            }
            else
            {
                this.Hide();
            }
        }

        private void Configuration_Load(object sender, EventArgs e)
        {
            txt_python.Text = @"D:\PLD\Code\PythonEnv\biformer\python.exe";
        }
    }
}
