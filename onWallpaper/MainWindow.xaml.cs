using DMSkin.WPF;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.ComponentModel;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace onWallpaper
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : DMSkinSimpleWindow
    {
        private NotifyIcon notify;
        private string downloadPath;
        private string collectionPath;
        private bool showWindow = true;
        public MainWindow()
        {
            InitializeComponent();
            InitImagePage();
            InitTaskBar();
        }

        private void InitTaskBar()
        {
            notify = new NotifyIcon();
            notify.BalloonTipText = "程序后台运行中";
            notify.Text = "桌面壁纸工具";
            notify.Icon = System.Drawing.Icon.FromHandle(Resource1.Icon.GetHicon());
            notify.Visible = true;

            MenuItem open = new MenuItem("打开");
            open.Click += new EventHandler(notifyClicked);
            MenuItem exit = new MenuItem("退出");
            exit.Click += new EventHandler(exitBtnClicked);
            MenuItem[] children = new MenuItem[] {open, exit};
            notify.ContextMenu = new ContextMenu(children);
            notify.MouseClick += new MouseEventHandler(notifyClicked);
        }

        private void InitImagePage()
        {
            downloadPath = CommonHelper.GetConfigValue("downloadPath");
            downloadPathText.Text = downloadPath;
            collectionPath = CommonHelper.GetConfigValue("collectionPath");
            collectionPathText.Text = collectionPath;
        }

        private void notifyClicked(object sender, EventArgs e)
        {
            if (showWindow)
            {
                showWindow = false;
                this.Visibility = Visibility.Hidden;
            }
            else
            {
                showWindow = true;
                this.Visibility = Visibility.Visible;
                this.Activate();
            }
        }

        private void closeBtnClicked(object sender, EventArgs e)
        {
            int notifyTime = CommonHelper.GetConfigIntValue("notifyTime");
            if (notifyTime < 1)
            {
                notify.ShowBalloonTip(1000);
                notifyTime += 1;
                CommonHelper.SetConfigString("notifyTime", notifyTime.ToString());
            }  
            showWindow = false;
            this.Visibility = Visibility.Hidden;
        }

        private void exitBtnClicked(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void selectDownloadFolderBtnClicked(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            if (downloadPath == null)
            {
                dialog.InitialDirectory = "C:\\Users";
            }
            else
            {
                dialog.InitialDirectory = downloadPath;
            }
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                downloadPath = dialog.FileName;
                if (downloadPath.Substring(0, 1) != "\\")
                {
                    downloadPath += "\\";
                }
                downloadPathText.Text = downloadPath;
                CommonHelper.SetConfigString("downloadPath", downloadPath);
            }
        }

        private void selectCollectionFolderBtnClicked(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            if (collectionPath == null)
            {
                dialog.InitialDirectory = "C:\\Users";
            }
            else
            {
                dialog.InitialDirectory = collectionPath;
            }
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                collectionPath = dialog.FileName;
                if (collectionPath.Substring(0, 1) != "\\")
                {
                    collectionPath += "\\";
                }
                collectionPathText.Text = collectionPath;
                CommonHelper.SetConfigString("collectionPath", collectionPath);
            }
        }

        private void selectIntervalInputKeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            
        }

        private void startBtnClicked(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(test);
        }

        private void test()
        {
            WallhallaHelper wallhalla = new WallhallaHelper();
            string result = wallhalla.NextImagePath();
            //System.Windows.MessageBox.Show(result);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = true;
            base.OnClosing(e);
        }
    }
}
