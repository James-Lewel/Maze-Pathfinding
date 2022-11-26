using System.Drawing;
using System.Windows.Forms;

namespace Maze.Helper
{
    public class PositionHelper
    {
        Control control;

        public void PlaceStart(TableLayoutPanel mazeGrid, Point? startCellPosition, Point? currentCellPosition)
        {
            // Remove start cell and color
            if (startCellPosition != null)
            {
                control = mazeGrid.GetControlFromPosition(startCellPosition.Value.X, startCellPosition.Value.Y);
                control.BackColor = Color.White;
            }

            // Place start cell and color
            control = mazeGrid.GetControlFromPosition(currentCellPosition.Value.X, currentCellPosition.Value.Y);
            control.BackColor = Color.Green;
        }

        public void PlaceEnd(TableLayoutPanel mazeGrid, Point? endCellPosition, Point? currentCellPosition)
        {
            // Remove end cell and color
            if (endCellPosition != null)
            {
                control = mazeGrid.GetControlFromPosition(endCellPosition.Value.X, endCellPosition.Value.Y);
                control.BackColor = Color.White;
            }

            // Place start cell and color
            if (currentCellPosition != endCellPosition)
            {
                control = mazeGrid.GetControlFromPosition(currentCellPosition.Value.X, currentCellPosition.Value.Y);
                control.BackColor = Color.Red;
            }
        }

        public void RemoveStart(TableLayoutPanel mazeGrid, Point? startCellPosition)
        {
            // Remove start cell and color
            if (startCellPosition != null)
            {
                control = mazeGrid.GetControlFromPosition(startCellPosition.Value.X, startCellPosition.Value.Y);
                control.BackColor = Color.White;
            }
        }

        public void RemoveEnd(TableLayoutPanel mazeGrid, Point? endCellPosition)
        {
            // Remove end cell and color
            if (endCellPosition != null)
            {
                control = mazeGrid.GetControlFromPosition(endCellPosition.Value.X, endCellPosition.Value.Y);
                control.BackColor = Color.White;
            }
        }
    }
}
