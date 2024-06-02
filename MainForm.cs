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
            // halves
            HotkeyManager.Current.AddOrReplace("SnapLeft", Keys.Left | Keys.Control | Keys.Alt, OnSnapLeft);
            HotkeyManager.Current.AddOrReplace("SnapRight", Keys.Right | Keys.Control | Keys.Alt, OnSnapRight);
            HotkeyManager.Current.AddOrReplace("SnapTop", Keys.Up | Keys.Control | Keys.Alt, OnSnapTop);
            HotkeyManager.Current.AddOrReplace("SnapBottom", Keys.Down | Keys.Control | Keys.Alt, OnSnapBottom);
            // corner fourths
            HotkeyManager.Current.AddOrReplace("SnapTopLeft", Keys.O | Keys.Control | Keys.Alt, OnSnapTopLeft);
            HotkeyManager.Current.AddOrReplace("SnapTopRight", Keys.P | Keys.Control | Keys.Alt, OnSnapTopRight);
            HotkeyManager.Current.AddOrReplace("SnapBottomLeft", Keys.K | Keys.Control | Keys.Alt, OnSnapBottomLeft);
            HotkeyManager.Current.AddOrReplace("SnapBottomRight", Keys.L | Keys.Control | Keys.Alt, OnSnapBottomRight);
            // full thirds
            HotkeyManager.Current.AddOrReplace("SnapLeftThird", Keys.A | Keys.Control | Keys.Alt, OnSnapLeftThird);
            HotkeyManager.Current.AddOrReplace("SnapMidThird", Keys.S | Keys.Control | Keys.Alt, OnSnapMidThird);
            HotkeyManager.Current.AddOrReplace("SnapRightThird", Keys.D | Keys.Control | Keys.Alt, OnSnapRightThird);
            // sixths
            HotkeyManager.Current.AddOrReplace("SnapTopLeftSixth", Keys.Q | Keys.Control | Keys.Alt, OnSnapTopLeftSixth);
            HotkeyManager.Current.AddOrReplace("SnapTopMidSixth", Keys.W | Keys.Control | Keys.Alt, OnSnapTopMidSixth);
            HotkeyManager.Current.AddOrReplace("SnapTopRightSixth", Keys.E | Keys.Control | Keys.Alt, OnSnapTopRightSixth);
            HotkeyManager.Current.AddOrReplace("SnapBotLeftSixth", Keys.Z | Keys.Control | Keys.Alt, OnSnapBotLeftSixth);
            HotkeyManager.Current.AddOrReplace("SnapBotMidSixth", Keys.X | Keys.Control | Keys.Alt, OnSnapBotMidSixth);
            HotkeyManager.Current.AddOrReplace("SnapBotRightSixth", Keys.C | Keys.Control | Keys.Alt, OnSnapBotRightSixth);

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
            Visible = false; // Hide the form window
            ShowInTaskbar = false; // Remove from taskbar
            base.OnLoad(e);
        }

        private void OnExit(object? sender, EventArgs e)
        {
            Application.Exit();
        }
        // SNAP LEFT HALF
        private void OnSnapLeft(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            WindowManager.MoveAndResizeWindow(x, y, width / 2, height);
            e.Handled = true;
        }
        // SNAP RIGHT HALF
        private void OnSnapRight(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            WindowManager.MoveAndResizeWindow(x + width / 2, y, width / 2, height);
            e.Handled = true;
        }
        // SNAP TOP HALF
        private void OnSnapTop(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            WindowManager.MoveAndResizeWindow(x, y, width, height / 2);
            e.Handled = true;
        }
        // SNAP BOTTOM HALF
        private void OnSnapBottom(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            WindowManager.MoveAndResizeWindow(x, y + height / 2, width, height / 2);
            e.Handled = true;
        }
        // SNAP TOP LEFT CORNER
        private void OnSnapTopLeft(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            WindowManager.MoveAndResizeWindow(x, y, width / 2, height / 2);
            e.Handled = true;
        }
        // SNAP TOP RIGHT CORNER
        private void OnSnapTopRight(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            WindowManager.MoveAndResizeWindow(x + width / 2, y, width / 2, height / 2);
            e.Handled = true;
        }
        // SNAP BOTTOM LEFT CORNER
        private void OnSnapBottomLeft(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            WindowManager.MoveAndResizeWindow(x, y + height / 2, width / 2, height / 2);
            e.Handled = true;
        }
        // SNAP BOTTOM RIGHT CORNER
        private void OnSnapBottomRight(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            WindowManager.MoveAndResizeWindow(x + width / 2, y + height / 2, width / 2, height / 2);
            e.Handled = true;
        }
        // SNAP LEFT THIRD
        private void OnSnapLeftThird(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            int thirdWidth = width / 3;
            WindowManager.MoveAndResizeWindow(x, y, thirdWidth, height);
            e.Handled = true;
        }
        // SNAP MIDDLE THIRD
        private void OnSnapMidThird(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            int thirdWidth = width / 3;
            WindowManager.MoveAndResizeWindow(x + thirdWidth, y, thirdWidth, height);
            e.Handled = true;
        }
        // SNAP RIGHT THIRD
        private void OnSnapRightThird(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            int thirdWidth = width / 3;
            WindowManager.MoveAndResizeWindow(x + 2 * thirdWidth, y, thirdWidth, height);
            e.Handled = true;
        }
        // SNAP TOP LEFT SIXTH
        private void OnSnapTopLeftSixth(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            int sixthWidth = width / 3;
            int sixthHeight = height / 2;
            WindowManager.MoveAndResizeWindow(x, y, sixthWidth, sixthHeight);
            e.Handled = true;
        }
        // SNAP TOP MIDDLE SIXTH
        private void OnSnapTopMidSixth(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            int sixthWidth = width / 3;
            int sixthHeight = height / 2;
            WindowManager.MoveAndResizeWindow(x + sixthWidth, y, sixthWidth, sixthHeight);
            e.Handled = true;
        }
        // SNAP TOP RIGHT SIXTH
        private void OnSnapTopRightSixth(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            int sixthWidth = width / 3;
            int sixthHeight = height / 2;
            WindowManager.MoveAndResizeWindow(x + 2 * sixthWidth, y, sixthWidth, sixthHeight);
            e.Handled = true;
        }
        // SNAP BOTTOM LEFT SIXTH
        private void OnSnapBotLeftSixth(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            int sixthWidth = width / 3;
            int sixthHeight = height / 2;
            WindowManager.MoveAndResizeWindow(x, y + sixthWidth, sixthWidth, sixthHeight);
            e.Handled = true;
        }
        // SNAP BOTTOM MIDDLE SIXTH
        private void OnSnapBotMidSixth(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            int sixthWidth = width / 3;
            int sixthHeight = height / 2;
            WindowManager.MoveAndResizeWindow(x + sixthWidth, y + sixthHeight, sixthWidth, sixthHeight);
            e.Handled = true;
        }
        // SNAP BOTTOM RIGHT SIXTH
        private void OnSnapBotRightSixth(object? sender, HotkeyEventArgs e)
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            int sixthWidth = width / 3;
            int sixthHeight = height / 2;
            WindowManager.MoveAndResizeWindow(x + 2 * sixthWidth, y + sixthHeight, sixthWidth, sixthHeight);
            e.Handled = true;
        }
    }
}
