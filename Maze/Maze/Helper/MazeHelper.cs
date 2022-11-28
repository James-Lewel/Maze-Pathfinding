using Maze.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Maze.Helper
{
    public class MazeHelper
    {
        Point point;

        public Graphics outline;
        int row, column;
        public int maxRow, maxColumn;

        // Cell Size
        public int maxHeight;
        public int maxWidth;

        // Cell objects
        TableLayoutPanel mazeGrid;
        public Cell[] gridCells;
        Cell startCell;
        Cell endCell;
        Cell currentCell;
        Cell nextCell;
        Stack<Cell> cellsVisited = new Stack<Cell>();

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        public void DrawGrid(Control control, Action action)
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

        public Point GeneratePoint()
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

        public void GenerateWalls(TableLayoutPanel mazeGrid, Point? startCellPosition, Point? endCellPosition)
        {
            this.mazeGrid = mazeGrid;
            gridCells = new Cell[maxRow * maxColumn];

            for (int i = 0, index = 0; i < maxRow; i++)
            {
                for(int j = 0; j < maxColumn; j++, index++)
                {
                    gridCells[index] = new Cell(j, i);
                }
            }

            startCell = gridCells[startCellPosition.Value.X + startCellPosition.Value.Y * maxColumn];
            endCell = gridCells[endCellPosition.Value.X + endCellPosition.Value.Y * maxColumn];

            Control control = mazeGrid.GetControlFromPosition(startCell.x, startCell.y);
            maxHeight = control.Height;
            maxWidth = control.Width;

            currentCell = startCell;

            while (true)
            {
                currentCell.hasVisited = true;
                //CheckNeighborCells(currentCell);
                //nextCell = cells.Count > 0 ? cells.Pop() : null;
                nextCell = CheckRandomNeighborCells(currentCell);

                if (nextCell != null)
                {
                    nextCell.hasVisited = true;
                    cellsVisited.Push(nextCell);
                    RemoveWall(currentCell, nextCell);
                    control = mazeGrid.GetControlFromPosition(nextCell.x, nextCell.y);
                    currentCell = nextCell;
                    if (control.BackColor.Name == "Green" || control.BackColor.Name == "Red")
                    {
                        continue;
                    }
                    else if(control.BackColor.Name == "Gray")
                    {
                        control.BackColor = Color.DarkGray;
                    }
                    else
                    {
                        control.BackColor = Color.Gray;
                    }
                }
                else if (cellsVisited.Count > 0)
                {
                    currentCell = cellsVisited.Pop();
                }
                else
                {
                    break;
                }
                mazeGrid.Refresh();
                //MessageBox.Show("x : " + currentCell.x + "\ny : " + currentCell.y);
            }
            mazeGrid.Refresh();
        }
        public void DrawOutline(Graphics outline)
        {
            Control control;
            Pen pen = new Pen(Color.Orange, 5);
            if(gridCells != null)
            {
                for (int i = 0, index = 0; i < maxRow; i++)
                {
                    for (int j = 0; j < maxColumn; j++, index++)
                    {
                        control = mazeGrid.GetControlFromPosition(j, i);

                        if (gridCells[index].walls["top"])
                        {
                            outline.DrawLine(pen, new Point(control.Left - 5, control.Top - 5), new Point(control.Right + 5, control.Top - 5));
                        }
                        if (gridCells[index].walls["bottom"])
                        {
                            outline.DrawLine(pen, new Point(control.Left - 5, control.Bottom + 5), new Point(control.Right + 5, control.Bottom + 5));
                        }
                        if (gridCells[index].walls["right"])
                        {
                            outline.DrawLine(pen, new Point(control.Right + control.Width + 10, control.Top - 5), new Point(control.Right + control.Width + 10 , control.Bottom + 4));
                        }
                        if (gridCells[index].walls["left"])
                        {
                            outline.DrawLine(pen, new Point(control.Left - control.Width - 10, control.Top - 5), new Point(control.Left - control.Width - 10, control.Bottom + 4));
                        }
                    }
                }
            }
        }

        public Cell CheckCells(int x, int y)
        {
            if (x < 0 || y < 0 || x > maxRow - 1 || y > maxColumn - 1)
            {
                return null;
            }

            return gridCells[x + y * maxColumn];
        }

        public void CheckNeighborCells(Cell cell)
        {
            Cell top = CheckCells(cell.x, cell.y - 1);
            Cell bottom = CheckCells(cell.x, cell.y + 1);
            Cell left = CheckCells(cell.x - 1, cell.y);
            Cell right = CheckCells(cell.x + 1, cell.y);

            if (top != null && top.hasVisited == false)
            {
                cellsVisited.Push(top);
            }
            if(bottom != null && bottom.hasVisited == false)
            {
                cellsVisited.Push(bottom);
            }
            if(left != null && left.hasVisited == false)
            {
                cellsVisited.Push(left);
            }
            if(right != null && right.hasVisited == false)
            {
                cellsVisited.Push(right);
            }
        }

        List<Cell> randomCells = new List<Cell>();
        public Cell CheckRandomNeighborCells(Cell cell)
        {
            randomCells.Clear();
            Cell top = CheckCells(cell.x, cell.y - 1);
            Cell bottom = CheckCells(cell.x, cell.y + 1);
            Cell left = CheckCells(cell.x - 1, cell.y);
            Cell right = CheckCells(cell.x + 1, cell.y);

            if (top != null && top.hasVisited == false)
            {
                randomCells.Add(top);
            }
            if (bottom != null && bottom.hasVisited == false)
            {
                randomCells.Add(bottom);
            }
            if (left != null && left.hasVisited == false)
            {
                randomCells.Add(left);
            }
            if (right != null && right.hasVisited == false)
            {
                randomCells.Add(right);
            }

            int index = new Random().Next(randomCells.Count);

            return randomCells.Count == 0 ? null : randomCells.ElementAt(index);
        }

        public void RemoveWall(Cell currentCell, Cell nextCell)
        {
            int dx = currentCell.x - nextCell.x;
            int dy = currentCell.y - nextCell.y;

            if (dx == 1)
            {
                currentCell.walls["left"] = false;
                nextCell.walls["right"] = false;
            }
            else if (dx == -1)
            {
                currentCell.walls["right"] = false;
                nextCell.walls["left"] = false;
            }

            if(dy == 1)
            {
                currentCell.walls["top"] = false;
                nextCell.walls["bottom"] = false;
            }
            else if(dy == -1)
            {
                currentCell.walls["bottom"] = false;
                nextCell.walls["top"] = false;
            }
            gridCells[currentCell.x + currentCell.y * maxColumn] = currentCell;
            gridCells[nextCell.x + nextCell.y * maxColumn] = nextCell;
        }

        public void DrawPath(Point? path)
        {
            Control control = mazeGrid.GetControlFromPosition(startCell.x, startCell.y);

            for (int i = 0, index = 0; i < maxRow; i++)
            {
                for (int j = 0; j < maxColumn; j++, index++)
                {
                    gridCells[index].hasVisited = false;
                }
            }

            currentCell = startCell;
            
            while (true)
            {
                currentCell.hasVisited = true;
                
                CheckNeighborCells(currentCell);
                nextCell = cellsVisited.Count > 0 ? cellsVisited.Pop() : null;
                nextCell = CheckRandomNeighborCells(currentCell);

                if (nextCell != null)
                {
                    if(nextCell.x == path.Value.X && nextCell.y == path.Value.Y)
                    {
                        break;
                    }
                    nextCell.hasVisited = true;
                    cellsVisited.Push(nextCell);
                    RemoveWall(currentCell, nextCell);
                    control = mazeGrid.GetControlFromPosition(nextCell.x, nextCell.y);
                    currentCell = nextCell;
                    if (control.BackColor.Name == "Green" || control.BackColor.Name == "Red")
                    {
                        continue;
                    }
                    else if (control.BackColor.Name == "Gray")
                    {
                        control.BackColor = Color.Aqua;
                    }
                    else
                    {
                        control.BackColor = Color.Aqua;
                    }
                }
                else if (cellsVisited.Count > 0)
                {
                    currentCell = cellsVisited.Pop();
                }
                else
                {
                    break;
                }
                mazeGrid.Refresh();
                //MessageBox.Show("x : " + currentCell.x + "\ny : " + currentCell.y);
            }
            mazeGrid.Refresh();
        }
    }
}
