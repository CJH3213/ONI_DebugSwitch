using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using 缺氧游戏debug开关.Properties;

namespace 缺氧游戏debug开关
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            //还原上次关闭窗口大小
            this.Size = Settings.Default.FormSize;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载上次选择的路径
            string savedPath = Settings.Default.GameDataPath;

            //获取游戏安装目录并补充完整路径
            string[] paths =  Utiliy.GetSoftwarePath("缺氧");
            for (int i=0; i<paths.Length; i++) 
                paths[i] += "\\OxygenNotIncluded_Data";

            //将获取到的游戏目录放入下拉表
            comboBox1.Items.Clear();
            comboBox1.Items.Add(savedPath);
            comboBox1.Items.AddRange(paths);
            comboBox1.SelectedIndex = 0;

            //检查路径，初始按键状态
            CheckComboBox();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            //保存窗口大小
            Settings.Default.FormSize = this.Size;

            Settings.Default.Save();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "开启Debug")
            {
                File.Create(comboBox1.Text + "\\debug_enable.txt").Close();

                if(FileTools.IfHaveFile(comboBox1.Text + "\\debug_enable.txt"))    //创建成功
                {
                    button1.Text = "关闭Debug";
                    textBox1.Text += "已添加 debug_enable.txt 文件\r\n";
                }
                else
                {
                    textBox1.Text += "添加 debug_enable.txt 文件 失败\r\n";
                }
            }
            else
            {
                if (FileTools.IfHaveFile(comboBox1.Text + "\\debug_enable.txt"))   //路径下存在文件吗
                {
                    File.Delete(comboBox1.Text + "\\debug_enable.txt");
                    if (FileTools.IfHaveFile(comboBox1.Text + "\\debug_enable.txt") == false)  //已经删除
                    { 
                        button1.Text = "开启Debug";
                        textBox1.Text += "已删除 debug_enable.txt 文件\r\n";
                    }
                    else  //删除失败
                    {
                        textBox1.Text += "删除 debug_enable.txt 文件 失败\r\n";
                    }
                }
                else
                    textBox1.Text += "不存在 debug_enable.txt 文件\r\n";
            }
        }

        //检查下拉表路径改变按键状态
        private void CheckComboBox()
        {
            //下拉表已选路径，按键可用
            if(comboBox1.Text != null && comboBox1.Text.Length > 0)
            {
                button1.Enabled = true;
                textBox1.Text += "路径：" + comboBox1.Text + "\r\n";
                IsDebugEnable(comboBox1.Text);
            }
            else
                button1.Enabled = false;
        }

        //debug_enable文件是否存在
        private bool IsDebugEnable(string fileName) 
        {
            if (FileTools.IfHaveFile(fileName + "\\debug_enable.txt"))
            {
                textBox1.Text += "已存在 debug_enable.txt 文件\r\n";
                button1.Text = "关闭Debug";
                return true;
            }
            else
            {
                textBox1.Text += "未存在 debug_enable.txt 文件\r\n";
                button1.Text = "开启Debug";
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //按下按钮弹出文件浏览器
            folderBrowserDialog1.Description = "请找到游戏数据路径：\\OxygenNotIncluded\\OxygenNotIncluded_Data";
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer;
            folderBrowserDialog1.ShowNewFolderButton = false;

            //检查已经选好的文件路径
            if(folderBrowserDialog1.ShowDialog() == DialogResult.OK) 
            {
                string dir = folderBrowserDialog1.SelectedPath;

                comboBox1.Text = dir;
                Settings.Default.GameDataPath = dir;
                comboBox1.Items.Add(dir);

                CheckComboBox();
            }

        }

        //下拉表选项改变时，保存所选路径，检查路径是否有debug文件
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.Default.GameDataPath = comboBox1.Text;

            CheckComboBox();
        }


    }
}
