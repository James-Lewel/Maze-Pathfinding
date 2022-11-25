using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze.Helper
{
    public class MazeHelper
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        public void DrawMaze(Control control, Action action)
        {
            const int WM_SETREDRAW = 0x000B;
            try
            {
                control.Refresh();
                SendMessage(control.Handle, WM_SETREDRAW, false, 0);
                action();
            }
            finally
            {
                SendMessage(control.Handle, WM_SETREDRAW, true, 0);
                control.Refresh();
            }
        }
    }
}
