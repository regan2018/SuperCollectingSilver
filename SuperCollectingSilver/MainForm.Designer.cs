namespace SuperCollectingSilver
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示主界面toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.打印测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清除登录信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.notifyMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "恒馨超市";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // notifyMenu
            // 
            this.notifyMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.notifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示主界面toolStripMenuItem,
            this.清除登录信息ToolStripMenuItem,
            this.打印设置ToolStripMenuItem,
            this.打印测试ToolStripMenuItem,
            this.退出系统ToolStripMenuItem});
            this.notifyMenu.Name = "notifyMenu";
            this.notifyMenu.Size = new System.Drawing.Size(176, 152);
            // 
            // 显示主界面toolStripMenuItem
            // 
            this.显示主界面toolStripMenuItem.Name = "显示主界面toolStripMenuItem";
            this.显示主界面toolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.显示主界面toolStripMenuItem.Text = "显示主界面";
            this.显示主界面toolStripMenuItem.Click += new System.EventHandler(this.显示主界面toolStripMenuItem_Click);
            // 
            // 打印设置ToolStripMenuItem
            // 
            this.打印设置ToolStripMenuItem.Name = "打印设置ToolStripMenuItem";
            this.打印设置ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.打印设置ToolStripMenuItem.Text = "打印设置";
            this.打印设置ToolStripMenuItem.Click += new System.EventHandler(this.打印设置ToolStripMenuItem_Click);
            // 
            // 打印测试ToolStripMenuItem
            // 
            this.打印测试ToolStripMenuItem.Name = "打印测试ToolStripMenuItem";
            this.打印测试ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.打印测试ToolStripMenuItem.Text = "打印测试";
            this.打印测试ToolStripMenuItem.Click += new System.EventHandler(this.打印测试ToolStripMenuItem_Click);
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // 清除登录信息ToolStripMenuItem
            // 
            this.清除登录信息ToolStripMenuItem.Name = "清除登录信息ToolStripMenuItem";
            this.清除登录信息ToolStripMenuItem.Size = new System.Drawing.Size(175, 24);
            this.清除登录信息ToolStripMenuItem.Text = "清除登录信息";
            this.清除登录信息ToolStripMenuItem.Click += new System.EventHandler(this.清除登录信息ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 453);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "恒馨收银系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.notifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyMenu;
        private System.Windows.Forms.ToolStripMenuItem 打印设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打印测试ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示主界面toolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清除登录信息ToolStripMenuItem;
    }
}

