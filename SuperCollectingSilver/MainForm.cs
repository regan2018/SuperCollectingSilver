using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp.WinForms;
using System.Drawing.Printing;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Collections;
using SuperCollectingSilver.com.he.util;
using CefSharp;
using SuperCollectingSilver.com.he.ExtChromiumBrowser;
using System.Diagnostics;
using OAUS.Core;
using System.Configuration;

namespace SuperCollectingSilver
{
    public partial class MainForm : Form
    {

        private MyChromiumBrowser myBrowser;//浏览器对象

        private string printFilePath;//测试打印文件路径

        private string oausServerIP = "119.23.15.8";//默认升级程序服务地址
        private int oausServerPort = 4540;//默认升级程序服务请求商品

        public Panel panel;

        public MainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;

            this.Check();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.panel = new Panel();
            this.Controls.Add(panel);

            var path = Application.StartupPath + "\\HtmlUI\\test.html";
            path = path.Replace("#", "%23");
            
            myBrowser = MyChromiumBrowser.Instance(this);

            //myBrowser.Navigate("http://192.168.0.102:8080/WDSHGL");
            //myBrowser.Navigate("http://localhost:8080/WDSHGL");
            string baseUrl = "http://119.23.15.8:8080/tty";
            try
            {
                baseUrl=ConfigurationManager.AppSettings["BaseUrl"];
            }
            catch (Exception) {
                baseUrl = "http://119.23.15.8:8080/tty";
            }
            myBrowser.Navigate(baseUrl);

        }


        #region 检查更新
        public void Check()
        {
            try
            {
                try
                {
                    oausServerIP = ConfigurationManager.AppSettings["UpdateUrl"].ToString();
                    oausServerPort = int.Parse(ConfigurationManager.AppSettings["UpdatePort"].ToString());
                }
                catch { }
                bool flag = VersionHelper.HasNewVersion(oausServerIP, oausServerPort);

                if (flag)
                {
                    bool flag2 = DialogResult.OK == MessageBox.Show("亲,有新版本哦,赶快点击“确定”升级吧！", "升级提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (flag2)
                    {
                        string fileName = AppDomain.CurrentDomain.BaseDirectory + "AutoUpdater\\AutoUpdater.exe";
                        Process process = Process.Start(fileName);
                        Process.GetCurrentProcess().Kill();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("获取版本信息失败！");
                LogHelper.WriteLog(typeof(MainForm), ex.Message + "  :获取更新信息异常，请手动下载更新包！");
            }
        }


        #endregion


        #region 右下角Icon图标右键菜单

        private void 打印设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printFilePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"HtmlUI\print_test.html";
            this.Invoke((EventHandler)delegate
            {
                //设置打印文件路径
                PrintUtil.Instance.SetPrintFilePath(printFilePath,ActionType.打印设置);
            });
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }

        private void 打印测试ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printFilePath = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"HtmlUI\print_test.html";
            this.Invoke((EventHandler)delegate
            {
                //设置打印文件路径
                PrintUtil.Instance.SetPrintFilePath(printFilePath, ActionType.弹窗打印);
            });
        }
        #endregion
    }
}
