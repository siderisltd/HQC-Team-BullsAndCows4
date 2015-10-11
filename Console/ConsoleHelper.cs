namespace ConsoleUtills
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    // Singleton
    public sealed class ConsoleHelper
    {
        private static volatile ConsoleHelper instance;

        private static object syncLock = new object();

        private ConsoleHelper()
        {
        }

        private enum StdHandle
        {
            OutputHandle = -11
        }

        public static ConsoleHelper Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncLock)
                    {
                        if (instance == null)
                        {
                            instance = new ConsoleHelper();
                        }
                    }
                }
                return instance;
            }
        }

        public static uint ConsoleFontsCount
        {
            get
            {
                return GetNumberOfConsoleFonts();
            }
        }

        private static ConsoleFont[] ConsoleFonts
        {
            get
            {
                ConsoleFont[] fonts = new ConsoleFont[GetNumberOfConsoleFonts()];
                if (fonts.Length > 0)
                {
                    GetConsoleFontInfo(GetStdHandle(StdHandle.OutputHandle), false, (uint)fonts.Length, fonts);
                }
                   
                return fonts;
            }
        }

        public bool SetConsoleFont(byte index)
        {
            return SetConsoleFont(GetStdHandle(StdHandle.OutputHandle), index);
        }

        public void CenterConsole()
        {
            IntPtr hWin = GetConsoleWindow();
            RECT rc;
            GetWindowRect(hWin, out rc);
            Screen scr = Screen.FromPoint(new Point(rc.left, rc.top));
            int x = scr.WorkingArea.Left + (scr.WorkingArea.Width - (rc.right - rc.left)) / 2;
            int y = scr.WorkingArea.Top + (scr.WorkingArea.Height - (rc.bottom - rc.top)) / 2;
            MoveWindow(hWin, x, y, rc.right - rc.left, rc.bottom - rc.top, false);
        }

        public void SetMaxWidth()
        {
            Console.WindowWidth = Console.LargestWindowWidth - 4;
        }

        public void SetMaxHeight()
        {
            Console.WindowHeight = Console.LargestWindowHeight - 1;
        }

        [DllImport("kernel32")]
        private static extern bool SetConsoleFont(IntPtr hOutput, uint index);

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT rc);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int x, int y, int w, int h, bool repaint);

        [DllImport("kernel32")]
        private static extern IntPtr GetStdHandle(StdHandle index);

        [DllImport("kernel32")]
        private static extern bool GetConsoleFontInfo(
            IntPtr hOutput,
            [MarshalAs(UnmanagedType.Bool)]bool bMaximize,
            uint count,
            [MarshalAs(UnmanagedType.LPArray), Out] ConsoleFont[] fonts);

        [DllImport("kernel32")]
        private static extern uint GetNumberOfConsoleFonts();

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        private struct ConsoleFont
        {
            public uint Index;
            public short SizeX, SizeY;
        }

        private struct RECT
        {
            internal int left;
            internal int top;
            internal int right;
            internal int bottom;
        }

    }
}
