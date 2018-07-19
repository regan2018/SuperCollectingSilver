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

namespace SuperCollectingSilver
{
    public partial class MainForm : Form
    {

        private MyChromiumBrowser myBrowser;//浏览器对象

        private string printFilePath;//测试打印文件路径

        public MainForm()
        {
            InitializeComponent();

            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var path = Application.StartupPath + "\\HtmlUI\\test.html";
            //path= System.Web.HttpUtility.UrlEncode(path);
            path = path.Replace("#", "%23");
            
            myBrowser = MyChromiumBrowser.Instance(this);

            //myBrowser.Navigate("http://192.168.0.102:8080/WDSHGL");
            //myBrowser.Navigate("http://localhost:8080/WDSHGL");
            myBrowser.Navigate("http://119.23.15.8:8080/tty");
            //myBrowser.Navigate(path);

        }
        
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
