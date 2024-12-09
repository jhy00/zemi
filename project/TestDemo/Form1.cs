using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TestDemo
{
    public partial class Form1 : Form
    {
        // 用于跟踪当前运行的进程
        private Process currentProcess;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 启动hsv2.py脚本，并传递临时文件路径作为参数
            string hsv2PyPath = @"D:\zemi6\project(1)\project\python\HSV2_run_test0.py"; // hsv2.py脚本的路径
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "D:\\anaconda3\\envs\\pytorch\\python.exe",
                //Arguments = $"\"{hsv2PyPath}\" \"{tempFilePath}\"",
                Arguments = hsv2PyPath,
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true
            };
            Process.Start(psi);
        }
        
        /// <summary>
        /// 保存眼孔参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            string txt0FilePath = @"txt0.txt";
            StreamReader streamReader = new StreamReader(txt0FilePath);
            string line = streamReader.ReadLine();
            line=streamReader.ReadLine();
            string[] line1=line.Split(new char[] { '=' });
            string lineRight = line1[1];
            string[] lineArray = lineRight.Split(new char[] { ',' });
            int LH=int.Parse(lineArray[0]);
            int LS=int.Parse(lineArray[1]);
            int LV=int.Parse(lineArray[2]);

            line = streamReader.ReadLine();
            string[] line2 = line.Split(new char[] { '=' });
            string lineRight2 = line2[1];
            string[] lineArray2 = lineRight2.Split(new char[] { ',' });
            int HH = int.Parse(lineArray2[0]);
            int HS = int.Parse(lineArray2[1]);
            int HV = int.Parse(lineArray2[2]);

            string savePath = @"../../../python/eye.py";

            try
            {
                string savaStr = string.Format("LH={0}\nLS={1}\nLV={2}\nHH={3}\nHS={4}\nHV={5}", LH, LS, LV, HH, HS, HV);
                //StreamWriter swriter = new StreamWriter(savePath, false, Encoding.UTF8);
                //swriter.WriteLine(savaStr);
                File.WriteAllText(savePath, savaStr); // 将字符串写入文件
                MessageBox.Show("保存成功！");

            }
            catch (Exception ex)
            {
                return;
            }
        }

        /// <summary>
        /// 保存眼眶参数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button5_Click(object sender, EventArgs e)
        {
            string txt0FilePath = @"txt0.txt";
            StreamReader streamReader = new StreamReader(txt0FilePath);
            string line = streamReader.ReadLine();
            line = streamReader.ReadLine();
            string[] line1 = line.Split(new char[] { '=' });
            string lineRight = line1[1];
            string[] lineArray = lineRight.Split(new char[] { ',' });
            int LH = int.Parse(lineArray[0]);
            int LS = int.Parse(lineArray[1]);
            int LV = int.Parse(lineArray[2]);

            line = streamReader.ReadLine();
            string[] line2 = line.Split(new char[] { '=' });
            string lineRight2 = line2[1];
            string[] lineArray2 = lineRight2.Split(new char[] { ',' });
            int HH = int.Parse(lineArray2[0]);
            int HS = int.Parse(lineArray2[1]);
            int HV = int.Parse(lineArray2[2]);

            string savePath = @"../../../python/eye.py";

            try
            {
                string savaStr = string.Format("LH={0}\nLS={1}\nLV={2}\nHH={3}\nHS={4}\nHV={5}", LH, LS, LV, HH, HS, HV);
                //StreamWriter swriter = new StreamWriter(savePath, false, Encoding.UTF8);
                //swriter.WriteLine(savaStr);
                File.WriteAllText(savePath, savaStr); // 将字符串写入文件
                MessageBox.Show("保存成功！");

            }
            catch (Exception ex)
            {
                return;
            }
        }

        /// <summary>
        /// 启动eye1.0.py
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            // 指定Python可执行文件的路径
            string pythonPath = @"D:\anaconda3\envs\pytorch\python.exe"; // 请替换为你的Python安装路径
            string scriptPath = @"D:\zemi6\project(1)\project\python\eye1.1.py"; // 请替换为你的eye1.1脚本路径

            // 创建一个新的进程启动Python脚本
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = pythonPath,
                Arguments = $"\"{scriptPath}\"",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true
            };

            // 声明进程
            using (currentProcess = new Process { StartInfo = startInfo })
            {
                currentProcess.Start();
                currentProcess.WaitForExit();
                string output = currentProcess.StandardOutput.ReadToEnd();
                string errors = currentProcess.StandardError.ReadToEnd();

                if (!string.IsNullOrEmpty(errors))
                {
                    MessageBox.Show("Error: " + errors);
                }
                else
                {
                    MessageBox.Show("Script executed successfully.");
                }
            }
        }

        private void 参数配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuration frm=new Configuration();
            frm.ShowDialog();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            if (currentProcess != null && !currentProcess.HasExited)
            {
                currentProcess.Kill(); // 强制停止进程
                currentProcess.WaitForExit(); // 等待进程结束

                btn_startHSV2.Enabled = true;  // 启用启动按钮
                btn_startEYE.Enabled = true;  // 启用启动按钮
                btn_stop.Enabled = false; // 禁用停止按钮
            }
        }
    }
}
