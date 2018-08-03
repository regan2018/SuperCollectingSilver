using CefSharp;
using CefSharp.WinForms;
using SuperCollectingSilver.com.he.util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCollectingSilver.com.he.ExtChromiumBrowser
{
    /// <summary>
    /// 自定义谷歌内核浏览器--扩展（支持第二屏幕显示用）
    /// </summary>
    public class MyChromiumBrowserExtend : Control
    {
        private ChromiumWebBrowser webBrowser;//浏览器


        /// <summary>
        /// 承载浏览器的窗体类，必须设置
        /// </summary>
        private MainForm mainWindow;

        /// <summary>
        /// 承载浏览器的窗体类，需要第二显示器显示时设置
        /// </summary>
        public SecondScreenShowForm secodeScreenShowWindow;

        private Form window;


        #region 浏览器初始化
        /// <summary>
        /// 浏览器初始化
        /// </summary>
        public static void BrowserInit()
        {
            #region 浏览器全局设置
            var setting = new CefSharp.CefSettings();
            setting.Locale = "zh-CN";
            //缓存路径
            setting.CachePath = Application.StartupPath + "/BrowserCache";
            //浏览器引擎的语言
            setting.AcceptLanguageList = "zh-CN,zh;q=0.9";
            setting.LocalesDirPath = Application.StartupPath + "/localeDir";
            //日志文件
            setting.LogFile = Application.StartupPath + "/LogData";
            setting.PersistSessionCookies = true;
            setting.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/67.0.3396.99 Safari/537.36";
            setting.UserDataPath = Application.StartupPath + "/userData";

            //开启ppapi-flash
            //setting.CefCommandLineArgs.Add("enable-npapi", "1");
            setting.CefCommandLineArgs.Add("--ppapi-flash-path", System.AppDomain.CurrentDomain.BaseDirectory + "Plugins\\pepflashplayer32_30_0_0_134.dll"); //指定flash的版本，不使用系统安装的flash版本
            setting.CefCommandLineArgs.Add("--ppapi-flash-version", "30.0.0.134");

            setting.CefCommandLineArgs.Add("Connection", "keep-alive");
            setting.CefCommandLineArgs.Add("Accept-Encoding", "gzip, deflate, br");

            CefSharp.Cef.Initialize(setting);
            #endregion

        }
        #endregion

        #region 公共设置
        /// <summary>
        /// 公共设置
        /// </summary>
        private void publicSet()
        {

            webBrowser = new ChromiumWebBrowser("about:blank");

            #region 设置js与cefSharp互通
            CefSharp.CefSharpSettings.LegacyJavascriptBindingEnabled = true;
            webBrowser.RegisterJsObject("googleBrower", this, new CefSharp.BindingOptions() { CamelCaseJavascriptNames = false });
            #endregion


            BrowserSettings bset = new BrowserSettings();
            bset.Plugins = CefState.Enabled;//启用插件
            bset.WebSecurity = CefState.Disabled;//禁用跨域限制
            webBrowser.BrowserSettings = bset;

            webBrowser.DownloadHandler = new DownloadHandler();
            webBrowser.KeyboardHandler = new KeyBoardHandler();

            //MenuHandler.mainWindow = mainWindow;
            //webBrowser.MenuHandler = new MenuHandler();

            //webBrowser.Dock = DockStyle.Fill;
            //webBrowser.Margin = new Padding(0, 0, 0, 0);
            //mainWindow.Controls.Add(webBrowser);
        }
        #endregion

        public MyChromiumBrowserExtend() { }

        /// <summary>
        /// 获取实例
        /// <param name="mainWindow">主屏显示的窗体</param>
        /// </summary>
        public MyChromiumBrowserExtend(MainForm mainWindow)
        {
            this.publicSet();
            
            this.mainWindow = mainWindow;
            this.window = this.mainWindow;

            #region 处理一些浏览器事件
            webBrowser.DownloadHandler = new DownloadHandler();
            webBrowser.KeyboardHandler = new KeyBoardHandler();
            MenuHandler.mainWindow = mainWindow;
            webBrowser.MenuHandler = new MenuHandler();

            webBrowser.KeyUp += WebBrowser_KeyUp;
            #endregion

            webBrowser.Dock = DockStyle.Fill;
            //添加到窗体中的panel容器中
            mainWindow.panel.Controls.Add(webBrowser);

            mainWindow.panel.Dock = DockStyle.Fill;
            mainWindow.panel.SizeChanged += Panel_SizeChanged;
            Panel_SizeChanged(null, null);

        }

        
        /// <summary>
        /// 获取实例
        /// </summary>
        /// <param name="seconddScreenShowWindow">第二屏幕显示的窗体</param>
        /// <returns></returns>
        public MyChromiumBrowserExtend(SecondScreenShowForm secodeScreenShowWindow)
        {
            this.publicSet();

            this.secodeScreenShowWindow = secodeScreenShowWindow;
            this.window = this.secodeScreenShowWindow;

            #region 处理一些浏览器事件
            webBrowser.DownloadHandler = new DownloadHandler();
            webBrowser.KeyboardHandler = new KeyBoardHandler();
            MenuHandler.mainWindow = secodeScreenShowWindow;
            webBrowser.MenuHandler = new MenuHandler();

            webBrowser.KeyUp += WebBrowser_KeyUp;

            webBrowser.FrameLoadEnd += SecondScreenShowWebBrowser_FrameLoadEnd;
            #endregion

            webBrowser.Dock = DockStyle.Fill;
            //添加到窗体中的panel容器中
            secodeScreenShowWindow.panel.Controls.Add(webBrowser);

            secodeScreenShowWindow.panel.Dock = DockStyle.Fill;
            secodeScreenShowWindow.panel.SizeChanged += SecondScreenShowPanel_SizeChanged;
            SecondScreenShowPanel_SizeChanged(null, null);
        }

        private void WebBrowser_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {
                //显示开发者工具
                webBrowser.ShowDevTools();
            }
        }

        /// <summary>
        /// 刷新
        /// </summary>
        public void Reload()
        {
            webBrowser.Reload();
        }

        private void Panel_SizeChanged(object sender, EventArgs e)
        {
            mainWindow.panel.Width = mainWindow.Width;
            mainWindow.panel.Height = mainWindow.Height-35;
            mainWindow.panel.Top = -5;
            mainWindow.panel.Left = 0;
        }

        private void SecondScreenShowPanel_SizeChanged(object sender, EventArgs e)
        {
            secodeScreenShowWindow.panel.Width = secodeScreenShowWindow.Width;
            secodeScreenShowWindow.panel.Height = secodeScreenShowWindow.Height;
            secodeScreenShowWindow.panel.Top = 0;
            secodeScreenShowWindow.panel.Left = 0;
        }
        private static string filePath = "";
        private void SecondScreenShowWebBrowser_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
            filePath = filePath.Replace("%23", "#");
            //第二屏幕显示的内容加载完后删除html文件
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }

        #region cefSharp与js交互
        /// <summary>
        /// 运行js代码
        /// </summary>
        /// <param name="jsCode"></param>
        public void actionJsCode(string jsCode)
        {
            webBrowser.GetBrowser().MainFrame.ExecuteJavaScriptAsync(jsCode);
        }
        #endregion

        #region 用于页面js与后台cefSharp互通操作
        /// <summary>
        /// 用于页面与后台互通操作
        /// </summary>
        /// <param name="data">数据</param>
        /// <param name="action">动作：print=打印，printSet=打印设置，printPreview=打印预览</param>
        public void cefQuery(string data, string action)
        {
            //将数据转成html文件
            data= HtmlTextConvertFile(data);

            ActionType actionType = ActionType.直接打印;
            if ("print".ToLower().Equals(action.ToLower().Trim()))
            {
                actionType = ActionType.直接打印;
            }
            if ("printSet".ToLower().Equals(action.ToLower().Trim()))
            {
                actionType = ActionType.打印设置;
            }
            if ("printPreview".ToLower().Equals(action.ToLower().Trim()))
            {
                actionType = ActionType.打印预览;
            }
            if ("secondScreen".ToLower().Equals(action.ToLower().Trim()))
            {
                actionType = ActionType.第二显示器;
            }
            if ("exit".ToLower().Equals(action.ToLower().Trim()))
            {
                actionType = ActionType.退出程序;
            }
            switch (actionType)
            {
                case ActionType.第二显示器://用于第二显示器显示
                    if (null != this.secodeScreenShowWindow)
                    {
                        data = data.Replace("#", "%23");
                        filePath = data;
                        this.secodeScreenShowWindow.myBrowser.Navigate(data);
                    }
                    break;
                case ActionType.退出程序://用于关闭应用程序
                    if (null != this.mainWindow)
                    {
                        this.mainWindow.Exit();
                    }
                    break;
                default:
                    this.window.Invoke((EventHandler)delegate
                    {
                        //设置预打印文件的路径，并执行对应的操作,data为打印文件路径
                        PrintUtil.Instance.SetPrintFilePath(data, actionType);
                    });
                    break;
            }

        }

        #endregion

        /// <summary>
        /// 加载页面
        /// </summary>
        /// <param name="url"></param>
        public void Navigate(string url)
        {
            webBrowser.Load(url);
        }


        #region HTML文本内容转HTML文件
        /// <summary>
        /// HTML文本内容转HTML文件
        /// </summary>
        /// <param name="strHtml">HTML文本内容</param>
        /// <returns>HTML文件的路径</returns>
        public static string HtmlTextConvertFile(string strHtml)
        {
            if (string.IsNullOrEmpty(strHtml))
            {
                throw new Exception("HTML text content cannot be empty.");
            }

            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory.ToString() + @"html\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string fileName = path + DateTime.Now.ToString("yyyyMMddHHmmssfff") + new Random().Next(1000, 10000) + ".html";
                FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.UTF8);
                streamWriter.Write(strHtml);
                streamWriter.Flush();

                streamWriter.Close();
                streamWriter.Dispose();
                fileStream.Close();
                fileStream.Dispose();
                return fileName;
            }
            catch
            {
                throw new Exception("HTML text content error.");
            }
        }
        #endregion
    }
}
