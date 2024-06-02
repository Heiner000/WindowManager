using System;
using System.Windows.Forms;
using NHotkey;
using NHotkey.WindowsForms;
using System.Drawing;

namespace WindowManager
{
    // class hanldes the UI & hotkey registration for the window manager
    public partial class MainForm : Form
    {
        // NotifyIcon for the system tray icon
        private NotifyIcon trayIcon = new NotifyIcon();
        // ContextMenuStrip for the tray icon menu
        private ContextMenuStrip trayMenu = new ContextMenuStrip();

        // MainForm constructor
        public MainForm()
        {
            InitializeComponent();
            RegisterHotkeys();
            InitializeTrayIcon();
        }

        // register hotkeys to snap windows using SnapToFraction
        private void RegisterHotkeys()
        {
            // params: key identifier, key combo, action lambda
            // halves
            HotkeyManager.Current.AddOrReplace("SnapLeft", Keys.Left | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0, 0, 0.5, 1));
            HotkeyManager.Current.AddOrReplace("SnapRight", Keys.Right | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0.5, 0, 0.5, 1));
            HotkeyManager.Current.AddOrReplace("SnapTop", Keys.Up | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0, 0, 1, 0.5));
            HotkeyManager.Current.AddOrReplace("SnapBottom", Keys.Down | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0, 0.5, 1, 0.5));

            // corner fourths
            HotkeyManager.Current.AddOrReplace("SnapTopLeft", Keys.O | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0, 0, 0.5, 0.5));
            HotkeyManager.Current.AddOrReplace("SnapTopRight", Keys.P | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0.5, 0, 0.5, 0.5));
            HotkeyManager.Current.AddOrReplace("SnapBottomLeft", Keys.K | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0, 0.5, 0.5, 0.5));
            HotkeyManager.Current.AddOrReplace("SnapBottomRight", Keys.L | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0.5, 0.5, 0.5, 0.5));

            // full thirds
            HotkeyManager.Current.AddOrReplace("SnapLeftThird", Keys.A | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0, 0, 1.0 / 3, 1));
            HotkeyManager.Current.AddOrReplace("SnapMidThird", Keys.S | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(1.0 / 3, 0, 1.0 / 3, 1));
            HotkeyManager.Current.AddOrReplace("SnapRightThird", Keys.D | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(2.0 / 3, 0, 1.0 / 3, 1));

            // two-thirds
            HotkeyManager.Current.AddOrReplace("Snap2ThirdsLeft", Keys.V | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0, 0, 2.0 / 3, 1));
            HotkeyManager.Current.AddOrReplace("Snap2ThirdsRight", Keys.B | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(1.0 / 3, 0, 2.0 / 3, 1));


            // sixths
            HotkeyManager.Current.AddOrReplace("SnapTopLeftSixth", Keys.Q | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0, 0, 1.0 / 3, 0.5));
            HotkeyManager.Current.AddOrReplace("SnapTopMidSixth", Keys.W | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(1.0 / 3, 0, 1.0 / 3, 0.5));
            HotkeyManager.Current.AddOrReplace("SnapTopRightSixth", Keys.E | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(2.0 / 3, 0, 1.0 / 3, 0.5));
            HotkeyManager.Current.AddOrReplace("SnapBotLeftSixth", Keys.Z | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0, 0.5, 1.0 / 3, 0.5));
            HotkeyManager.Current.AddOrReplace("SnapBotMidSixth", Keys.X | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(1.0 / 3, 0.5, 1.0 / 3, 0.5));
            HotkeyManager.Current.AddOrReplace("SnapBotRightSixth", Keys.C | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(2.0 / 3, 0.5, 1.0 / 3, 0.5));

            // eighths
            HotkeyManager.Current.AddOrReplace("EighthT1", Keys.R | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0, 0, 1.0 / 4, 0.5));
            HotkeyManager.Current.AddOrReplace("EighthT2", Keys.T | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(1.0 / 4, 0, 1.0 / 4, 0.5));
            HotkeyManager.Current.AddOrReplace("EighthT3", Keys.Y | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(2.0 / 4, 0, 1.0 / 4, 0.5));
            HotkeyManager.Current.AddOrReplace("EighthT4", Keys.U | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(3.0 / 4, 0, 1.0 / 4, 0.5));
            HotkeyManager.Current.AddOrReplace("EighthB1", Keys.F | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(0, 0.5, 1.0 / 4, 0.5));
            HotkeyManager.Current.AddOrReplace("EighthB2", Keys.G | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(1.0 / 4, 0.5, 1.0 / 4, 0.5));
            HotkeyManager.Current.AddOrReplace("EighthB3", Keys.H | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(2.0 / 4, 0.5, 1.0 / 4, 0.5));
            HotkeyManager.Current.AddOrReplace("EighthB4", Keys.J | Keys.Control | Keys.Alt, (s, e) => SnapToFraction(3.0 / 4, 0.5, 1.0 / 4, 0.5));
        }

        // initializes the system tray icon and context menu
        private void InitializeTrayIcon()
        {
            // add an exit option for the tray menu
            trayMenu.Items.Add("Exit", null, OnExit);

            // set up the tray icon
            trayIcon.Text = "WindowManager";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);

            // associate the context menu with the tray icon
            trayIcon.ContextMenuStrip = trayMenu;
            trayIcon.Visible = true;
        }

        // override the OnLoad method to hide the form and remove it form the taskbar
        protected override void OnLoad(EventArgs e)
        {
            Visible = false; // Hide the form window
            ShowInTaskbar = false; // Remove from taskbar
            base.OnLoad(e);
        }

        // event handler to exit the app when the exit option is selected
        private void OnExit(object? sender, EventArgs e)
        {
            Application.Exit();
        }

        // General method to snap to a fraction of the screen's working area
        private void SnapToFraction(double startXFraction, double startYFraction, double widthFraction, double heightFraction)
        // startXFraction = starting x position as a fraction of the screen's width
        // startYFraction = starting y position as a fraction of the screen's height
        // widthFraction = width of the window as a fraction of the screen's width
        // heightFraction = height of the window as a fraction of the screen's height
        {
            var (width, height, x, y) = WindowManager.GetWorkingArea();
            int newWidth = (int)(width * widthFraction);
            int newHeight = (int)(height * heightFraction);
            int newX = x + (int)(width * startXFraction);
            int newY = y + (int)(height * startYFraction);
            WindowManager.MoveAndResizeWindow(newX, newY, newWidth, newHeight);
        }
    }
}
