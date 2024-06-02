using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace WindowManager
{
    public static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
    }

    public class WindowManager
    {
        public static void MoveAndResizeWindow(int x, int y, int width, int height)
        {
            IntPtr hWnd = NativeMethods.GetForegroundWindow();
            if (hWnd != IntPtr.Zero)
            {
                NativeMethods.MoveWindow(hWnd, x, y, width, height, true);
            }
        }

        public static (int width, int height) GetScreenSize()
        {
            var primaryScreen = Screen.PrimaryScreen;
            if (primaryScreen != null)
            {
                return (primaryScreen.Bounds.Width, primaryScreen.Bounds.Height);
            }
            return (0, 0);
        }

        public static (int x, int y, int width, int height) GetWindowRect()
        {
            IntPtr hWnd = NativeMethods.GetForegroundWindow();
            if (hWnd != IntPtr.Zero)
            {
                NativeMethods.GetWindowRect(hWnd, out NativeMethods.RECT rect);
                return (rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
            }
            return (0, 0, 0, 0);
        }
    }
}