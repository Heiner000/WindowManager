using System;
using System.Windows.Forms;
using NHotkey;
using NHotkey.WindowsForms;
using System.Drawing;

namespace WindowManager
{
    public partial class MainForm : Form
    {
        private NotifyIcon trayIcon = new NotifyIcon();
        private ContextMenuStrip trayMenu = new ContextMenuStrip();

        public MainForm()
        {
            InitializeComponent();
            RegisterHotkeys();
            InitializeTrayIcon();
        }

        private void RegisterHotkeys()
        {
            HotkeyManager.Current.AddOrReplace("SnapLeft", Keys.Left | Keys.Control | Keys.Alt, OnSnapLeft);
            HotkeyManager.Current.AddOrReplace("SnapRight", Keys.Right | Keys.Control | Keys.Alt, OnSnapRight);
            HotkeyManager.Current.AddOrReplace("SnapTop", Keys.Up | Keys.Control | Keys.Alt, OnSnapTop);
            HotkeyManager.Current.AddOrReplace("SnapBottom", Keys.Down | Keys.Control | Keys.Alt, OnSnapBottom);
            HotkeyManager.Current.AddOrReplace("SnapTopLeft", Keys.O | Keys.Control | Keys.Alt, OnSnapTopLeft);
            HotkeyManager.Current.AddOrReplace("SnapTopRight", Keys.P | Keys.Control | Keys.Alt, OnSnapTopRight);
            HotkeyManager.Current.AddOrReplace("SnapBottomLeft", Keys.K | Keys.Control | Keys.Alt, OnSnapBottomLeft);
            HotkeyManager.Current.AddOrReplace("SnapBottomRight", Keys.L | Keys.Control | Keys.Alt, OnSnapBottomRight);
        }

        private void InitializeTrayIcon()
        {
            trayMenu.Items.Add("Exit", null, OnExit);
            
            trayIcon.Text = "WindowManager";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);

            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Visible = true;
        }

        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // hide the form window
            ShowInTaskbar = false; // remove from taskbar
            base.OnLoad(e);
        }

        private void OnExit(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OnSnapLeft(object? sender, HotkeyEventArgs e)
        {
            var screenSize = WindowManager.GetScreenSize();
            WindowManager.MoveAndResizeWindow(0, 0, screenSize.width / 2, screenSize.height);
            e.Handled = true;
        }

        private void OnSnapRight(object? sender, HotkeyEventArgs e)
        {
            var screenSize = WindowManager.GetScreenSize();
            WindowManager.MoveAndResizeWindow(screenSize.width / 2, 0, screenSize.width / 2, screenSize.height);
            e.Handled = true;
        }

        private void OnSnapTop(object? sender, HotkeyEventArgs e)
        {
            var screenSize = WindowManager.GetScreenSize();
            WindowManager.MoveAndResizeWindow(0, 0, screenSize.width, screenSize.height / 2);
            e.Handled = true;
        }

        private void OnSnapBottom(object? sender, HotkeyEventArgs e)
        {
            var screenSize = WindowManager.GetScreenSize();
            WindowManager.MoveAndResizeWindow(0, screenSize.height / 2, screenSize.width, screenSize.height / 2);
            e.Handled = true;
        }

        private void OnSnapTopLeft(object? sender, HotkeyEventArgs e)
        {
            var screenSize = WindowManager.GetScreenSize();
            WindowManager.MoveAndResizeWindow(0, 0, screenSize.width / 2, screenSize.height / 2);
            e.Handled = true;
        }

        private void OnSnapTopRight(object? sender, HotkeyEventArgs e)
        {
            var screenSize = WindowManager.GetScreenSize();
            WindowManager.MoveAndResizeWindow(screenSize.width / 2, 0, screenSize.width / 2, screenSize.height / 2);
            e.Handled = true;
        }

        private void OnSnapBottomLeft(object? sender, HotkeyEventArgs e)
        {
            var screenSize = WindowManager.GetScreenSize();
            WindowManager.MoveAndResizeWindow(0, screenSize.height / 2, screenSize.width / 2, screenSize.height / 2);
            e.Handled = true;
        }

        private void OnSnapBottomRight(object? sender, HotkeyEventArgs e)
        {
            var screenSize = WindowManager.GetScreenSize();
            WindowManager.MoveAndResizeWindow(screenSize.width / 2, screenSize.height / 2, screenSize.width / 2, screenSize.height / 2);
            e.Handled = true;
        }
    }
}