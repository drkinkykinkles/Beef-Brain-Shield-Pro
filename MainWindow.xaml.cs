using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace beefbrain_shield_pro
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set up the tray icon
            NotifyIcon trayIcon = new NotifyIcon();
            Stream iconStream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Assets/bbsp2.ico")).Stream;
            trayIcon.Icon = new System.Drawing.Icon(iconStream);
            trayIcon.Text = "Beef Brain Shield Pro";
            trayIcon.Visible = true;

            // Handle when the tray icon is left clicked
            trayIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(delegate (object? sender, System.Windows.Forms.MouseEventArgs e) { this.TrayIconClickHandler(sender, e); });
            
            // Add a menu for when the tray icon is right clicked
            trayIcon.ContextMenuStrip = new ContextMenuStrip();
            trayIcon.ContextMenuStrip.Items.Add("Open", null, this.RestoreFromTray);
            trayIcon.ContextMenuStrip.Items.Add("Exit", null, this.Shutdown);
        }

        private void ResetBackground()
        {
            background.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/window_lg.png"));
        }

        private void ChangeBackgroundOkay()
        {
            background.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/window_clickokay_lg.png"));
        }

        private void ChangeBackgroundX()
        {
            background.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Assets/window_clickx_lg.png"));
        }

        private void TrayIconClickHandler(object? sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.RestoreFromTray();
            }
        }

        private void RestoreFromTray(object? sender, EventArgs e)
        {
            this.Show();
            this.Activate();
        }

        private void RestoreFromTray()
        {
            this.Show();
            this.Activate();
        }

        private void Shutdown(object? sender, EventArgs args)
        {
            this.Shutdown();
        }

        private void Shutdown()
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void okay_btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangeBackgroundOkay();
        }

        private void okay_btn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ResetBackground();
            this.Hide();
        }

        private void close_btn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChangeBackgroundX();
        }

        private void close_btn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ResetBackground();
            this.Shutdown();
        }

        private void titlebar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
