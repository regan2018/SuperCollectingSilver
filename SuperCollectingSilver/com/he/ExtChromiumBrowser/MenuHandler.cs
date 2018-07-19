using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperCollectingSilver.com.he.ExtChromiumBrowser
{
    class MenuHandler : IContextMenuHandler
    {
        public static Form mainWindow { get; set; }

        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            
        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            return true;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            //var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;
            //chromiumWebBrowser.ContextMenu = null;
        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            //var chromiumWebBrowser = (ChromiumWebBrowser)browserControl;

            //var menu = new ContextMenuStrip();
            //menu.Items.Add("最小化");
            //chromiumWebBrowser.ContextMenuStrip = menu;

            return false;
        }
    }
}
