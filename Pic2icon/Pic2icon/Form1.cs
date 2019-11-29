using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pic2icon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void num_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = sender as NumericUpDown;
            if (num == num_width)
            {
                num_height.Value = num_width.Value;
                return;
            }
            if (num == num_height)
            {
                num_width.Value = num_height.Value;
                return;
            }
        }

        private void btn_picture_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofg = new OpenFileDialog() { 
                Title = "选择图片",
                Filter = "图片文件 |*.jpeg;*.jpg;*.png;"
            };
            if (ofg.ShowDialog() == DialogResult.OK)
            {
                tbx_picture.Text = ofg.FileName;
            }
        }

        private void btn_result_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfg = new SaveFileDialog()
            {
                Title = "选择icon输出路径",
                Filter = "ico文件 |*.ico;"
            };
            if (sfg.ShowDialog() == DialogResult.OK)
            {
                tbx_result.Text = sfg.FileName;
            }
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            string[] strArr = new string[3] {
                tbx_picture.Text, num_width.Value.ToString(), tbx_result.Text
            };
            RunPy(Application.StartupPath + @"\Pic2icon.py", "", strArr);
            MessageBox.Show("完成输出");
        }

        public void RunPy(string filename, string args = "", params string[] teps)
        {

            string sArguments = filename;
            foreach (string sigstr in teps)
            {
                sArguments += " " + sigstr;//传递参数
            }
            sArguments += " " + args;

            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "python.exe",
                Arguments = sArguments,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            Process p = new Process()
            {
                StartInfo = startInfo
            };
            p.Start();
            p.BeginOutputReadLine();
            p.WaitForExit();
        }
    }
}
