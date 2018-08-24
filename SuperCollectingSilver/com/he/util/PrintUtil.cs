using SuperCollectingSilver.com.he.ExtChromiumBrowser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCollectingSilver.com.he.util
{
    sealed class PrintUtil
    {
        public static readonly PrintUtil Instance = new PrintUtil();
        static PrintUtil() { }

        private WebBrowser webBrowser;
        private string printFilePath;
        private ActionType actionType;

        private PrintUtil() {
            this.Init();
        }

        private void Init()
        {
            try
            {
                
                this.webBrowser.Dispose();
                GC.Collect();
                //GC.WaitForPendingFinalizers();
                this.webBrowser = null;

            }
            catch (Exception e) { }

            this.webBrowser = new WebBrowser();
            this.webBrowser.Hide();
            this.webBrowser.DocumentCompleted += WebBrowser_DocumentCompleted;
        }

        /// <summary>
        /// 设置预打印文件的路径，并执行对应的操作
        /// </summary>
        /// <param name="printFilePath">预打印文件的路径（可以是网页地址）</param>
        /// <param name="actionType">操作</param>
        public void SetPrintFilePath(string printFilePath,ActionType actionType)
        {
            this.Init();

            this.actionType = actionType;
            this.printFilePath = printFilePath;
            this.webBrowser.Navigate(printFilePath);
        }

        private void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var mySize= this.webBrowser.Document.Window.Size;
            this.webBrowser.Width = mySize.Width;
            this.webBrowser.Height = mySize.Height;
            switch (actionType)
            {
                case ActionType.直接打印:
                    this.Print();
                    break;
                case ActionType.弹窗打印:
                    this.ShowPrintDialog();
                    break;
                case ActionType.打印设置:
                    this.ShowPageSetupDialog();
                    break;
                case ActionType.打印预览:
                    this.ShowPrintPreviewDialog();
                    break; 
            }
        }

        /// <summary>
        /// 打印
        /// </summary>
        private void Print()
        {
            this.webBrowser.Print();

            if (File.Exists(printFilePath))
            {
                File.Delete(printFilePath);
            }
        }

        /// <summary>
        /// 显示打印设置
        /// </summary>
        private void ShowPageSetupDialog()
        {
            this.webBrowser.ShowPageSetupDialog();
        }

        /// <summary>
        /// 显示打印对话框
        /// </summary>
        private void ShowPrintDialog()
        {
            this.webBrowser.ShowPrintDialog();
        }
        /// <summary>
        /// 显示打印预览
        /// </summary>
        private void ShowPrintPreviewDialog()
        {
            this.webBrowser.ShowPrintPreviewDialog();
        }

    }
}
