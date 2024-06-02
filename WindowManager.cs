using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowManager
{
    // static class w/ P/Invoke declarations for user32.dll functions used to manipulate window positions/sizes
    public static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        // Struct representing a rectangle (used by GetWindowRect)
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }

    // class with methods to manipulate and retrieve info about windows
    public class WindowManager
    {
        // moves and resizes the currently active window
        public static void MoveAndResizeWindow(int x, int y, int width, int height)
        {
            // get a handle to currently active window
            IntPtr hWnd = NativeMethods.GetForegroundWindow();
            // if a valid handle is retrieved, move and resize the window
            if (hWnd != IntPtr.Zero)
            {
                NativeMethods.MoveWindow(hWnd, x, y, width, height, true);
            }
        }

        // retrieves the working area of the primary screen (excludes taskbars)
        public static (int width, int height, int x, int y) GetWorkingArea()
        {
            // get primary screen
            var primaryScreen = Screen.PrimaryScreen;
            // if primary screen is valid, return the dimensions and position of the working area
            if (primaryScreen != null)
            {
                var workingArea = primaryScreen.WorkingArea;
                return (workingArea.Width, workingArea.Height, workingArea.X, workingArea.Y);
            }
            // return default values if the primary screen is not valid
            return (0, 0, 0, 0);
        }

        // retrieves dimensions and position of the currently active window
        public static (int x, int y, int width, int height) GetWindowRect()
        {
            // get a handle to currently active window
            IntPtr hWnd = NativeMethods.GetForegroundWindow();
            // if valid handle is retrieved, get the window's Rectangle
            if (hWnd != IntPtr.Zero)
            {
                NativeMethods.GetWindowRect(hWnd, out NativeMethods.RECT rect);
                return (rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            }
            // return default values if no valid handle is retrieved
            return (0, 0, 0, 0);
        }
    }
}