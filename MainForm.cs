using System;
using System.Windows.Forms;
using NHotkey;
using NHotkey.WindowsForms;

namespace WindowManager
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            RegisterHotkeys();
        }

        private void RegisterHotkeys()
        {
            HotkeyManager.Current.AddOrReplace("SnapLeft", Keys.Left | Keys.Control | Keys.Alt, OnSnapLeft);
            HotkeyManager.Current.AddOrReplace("SnapRight", Keys.Right | Keys.Control | Keys.Alt, OnSnapRight);
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
    }
}