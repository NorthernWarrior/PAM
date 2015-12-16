
using PAM.MVVM;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;

namespace PAM.Commands
{
    public class OpenProcessCommand : Command
    {
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_RESTORE = 9;
        private const int GWL_STYLE = (-16);
        private const int WS_MINIMIZE = 0x20000000;

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hwnd);
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll", SetLastError = true)]
        static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        string fileName;
        Process proc;

        public OpenProcessCommand(string fileName) : base(null)
        {
            proc = null;
            this.fileName = fileName;
        }

        public void CloseProcess()
        {
            if (proc != null && !proc.HasExited)
                proc.CloseMainWindow();
        }

        public override bool CanExecute(object parameter)
        {
            return File.Exists(fileName);
        }

        public override void Execute(object parameter)
        {
            if (proc == null)
            {
                proc = new Process();
                proc.StartInfo = new ProcessStartInfo(fileName);
                try
                {
                    proc.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Failed to open the process \"" + fileName + "\"!\n" + ex.Message);
                    proc = null;
                    return;
                }

            }
            else if (proc.HasExited)
                proc.Start();
            else
            {
                SetForegroundWindow(proc.MainWindowHandle);
                int style = GetWindowLong(proc.MainWindowHandle, GWL_STYLE);
                if ((style & WS_MINIMIZE) == WS_MINIMIZE)
                    ShowWindow(proc.MainWindowHandle, SW_RESTORE);
            }
        }
    }
}
