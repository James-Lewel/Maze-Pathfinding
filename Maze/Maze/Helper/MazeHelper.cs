using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Maze.Helper
{
    public class MazeHelper
    {
        Point point;

        int row;
        int column;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        public void DrawMaze(Control control, Action action)
        {
            const int WM_SETREDRAW = 0x000B;
            try
            {
                // Disables drawing
                SendMessage(control.Handle, WM_SETREDRAW, false, 0);
                action();
            }
            finally
            {
                // Enables drawing
                SendMessage(control.Handle, WM_SETREDRAW, true, 0);
                control.Refresh();
            }
        }

        public Point GeneratePoint(int maxRow, int maxColumn)
        {
            Random random = new Random((DateTime.Now.Millisecond + DateTime.Now.Second) * 
                                       (DateTime.Now.Millisecond - DateTime.Now.Second));
            
            // Generates random number in range
            row = random.Next(0, maxRow);
            column = random.Next(0, maxColumn);

            // Creates new point
            point.X = row;
            point.Y = column;

            return point;
        }
    }
}
