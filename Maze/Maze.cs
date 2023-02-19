using Maze.Helper;
using Maze.Model;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Maze
{
    public partial class Maze : Form
    {
        // Helper classes
        MazeHelper mazeHelper = new MazeHelper();
        PositionHelper positionHelper = new PositionHelper();

        // Maze Points position
        Point? startCellPosition;
        Point? endCellPosition;

        // Maze Rows x Columns
        int maxRow = 0;
        int maxColumn = 0;

        bool isManualMode = true;

        public Maze()
        {
            InitializeComponent();

            this.DoubleBuffered = true;

            // Sets default & temporarily disable radio buttons
            manualRadioButton.Checked = true;
            manualRadioButton.Enabled = false;
            randomRadioButton.Enabled = false;

        }

        private void textBox_row_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Checks if input is letter
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

                // Notifies user input must be an integer
                MessageBox.Show("Input must be an integer");
            }
        }

        private void textBox_row_KeyUp(object sender, KeyEventArgs e)
        {
            // Copies input from row to column
            textBox_column.Text = textBox_row.Text;
        }

        private void generateGridButton_Click(object sender, EventArgs e)
        {
            // Disables button
            generateGridButton.Enabled = false;
            mazeHelper.outline = outline;
            // If true, sets default text to 0
            if (textBox_row.Text.Count() <= 0 || textBox_column.Text.Count() <= 0)
            {
                textBox_row.Text = "0";
                textBox_column.Text = "0";
            }

            // Sets rows/columns
            maxRow = int.Parse(textBox_row.Text);
            maxRow = maxRow > 0 ? maxRow : 1;
            maxColumn = int.Parse(textBox_column.Text);
            maxColumn = maxColumn > 0 ? maxColumn : 1;

            // Resets position
            mazeHelper.gridCells = null;
            startCellPosition = null;
            endCellPosition = null;

            // Creates a separate thread
            mazeHelper.DrawGrid(mazeGrid, async () =>
            {
                // Sets progress bar values
                progressBar.Value = 0;
                progressBar.Minimum = 0;
                progressBar.Maximum = (maxRow * maxColumn) + mazeGrid.Controls.Count;
                progressBar.Visible = true;
                progressBar.Style = ProgressBarStyle.Continuous;

                // Resets all properties in table layout panel
                mazeGrid.RowStyles.Clear();
                mazeGrid.ColumnStyles.Clear();
                mazeGrid.Enabled = true;

                // Removes all controls
                for (int i = mazeGrid.Controls.Count - 1; i >= 0; --i)
                {
                    mazeGrid.Controls[i].Dispose();
                    
                    // Show progress
                    progressBar.Value++;
                }

                mazeHelper.maxRow = maxRow;
                mazeHelper.maxColumn = maxColumn;
                mazeGrid.RowCount = maxRow;
                mazeGrid.ColumnCount = maxColumn;
                for (int i = 0; i < maxRow; i++)
                {
                    // Adds row to table layout panel
                    mazeGrid.RowStyles.Add(new RowStyle(SizeType.Percent, .50f));
                    for (int j = 0; j < maxColumn; j++)
                    {
                        // Adds column to table layout panel
                        mazeGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, .50f));

                        // Adds control to table cells
                        mazeGrid.Controls.Add(new Panel { Dock = DockStyle.Fill, Enabled = false, BackColor = Color.Transparent });

                        // Show progress
                        progressBar.Value++;
                    }
                }

                // Resets progress bar values
                progressBar.Visible = false;

                // Enables button
                generateGridButton.Enabled = true;
                manualRadioButton.Enabled = true;
                randomRadioButton.Enabled = true;

                // Sets radio button properties
                isManualMode = true;
                manualRadioButton.Checked = true;
                randomRadioButton.Checked = false;
            });

        }

        private void mazeGrid_MouseClick(object sender, MouseEventArgs e)
        {
            // Gets cell position on mouse click
            Point? currentCellPosition = new Point(e.X / (mazeGrid.Width / mazeGrid.ColumnCount), 
                                                e.Y / (mazeGrid.Height / mazeGrid.RowCount));

            if (isManualMode == false)
            {
                switch (e.Button)
                {
                    case MouseButtons.Left:
                        Cell temp = mazeHelper.gridCells[currentCellPosition.Value.X + currentCellPosition.Value.Y * maxColumn]; 
                        MessageBox.Show("Grid cell: " + currentCellPosition.Value.X + currentCellPosition.Value.Y +
                                        "\nTop : " + temp.walls["top"] + "\nBottom : " + temp.walls["bottom"] +
                                        "\nLeft : " + temp.walls["left"] + "\nRight : " + temp.walls["right"]);
                        break;

                    case MouseButtons.Right:
                        break;

                    case MouseButtons.Middle:
                        mazeHelper.DrawPath(currentCellPosition);
                        currentPathLabel.Text = currentCellPosition != null ?
                        "Current Path : " + startCellPosition.Value.X + ", " + startCellPosition.Value.Y + " to " +
                        currentCellPosition.Value.X + ", " + currentCellPosition.Value.Y :
                        "Current Path : ";
                        break;
                }
                return;
            }
            // Checks for mouse button
            switch (e.Button)
            {
                case MouseButtons.Left:
                    // If start is placed in end then reset
                    if (currentCellPosition == endCellPosition)
                    {
                        endCellPosition = null;
                    }

                    // Removes start position if clicked on end position
                    if (startCellPosition == currentCellPosition)
                    {
                        positionHelper.RemoveStart(mazeGrid, startCellPosition);
                        startCellPosition = null;
                    }
                    // Adds start position
                    else
                    {
                        positionHelper.PlaceStart(mazeGrid, startCellPosition, currentCellPosition);
                        startCellPosition = currentCellPosition;
                        MessageBox.Show(startCellPosition.Value.ToString());
                    }

                    startLabel.Text = startCellPosition != null ?
                        "Start Position : " + "X - " + startCellPosition.Value.X + ",Y - " + startCellPosition.Value.Y :
                        "Start Position : ";
                    break;

                case MouseButtons.Right:
                    // If end is placed in start then reset
                    if (currentCellPosition == startCellPosition)
                    {
                        startCellPosition = null;
                    }

                    // Removes end position if clicked on end position
                    if (endCellPosition == currentCellPosition)
                    {
                        positionHelper.RemoveEnd(mazeGrid, endCellPosition);
                        endCellPosition = null;
                    }
                    // Adds end position
                    else
                    {
                        positionHelper.PlaceEnd(mazeGrid, endCellPosition, currentCellPosition);
                        endCellPosition = currentCellPosition;
                        MessageBox.Show(endCellPosition.Value.ToString());
                    }

                    endLabel.Text = endCellPosition != null ?
                        "End Position : " + "X - " + endCellPosition.Value.X + ",Y - " + endCellPosition.Value.Y :
                        "End Position : ";
                    break;
                case MouseButtons.Middle:
                    mazeHelper.DrawPath(currentCellPosition);
                    currentPathLabel.Text = currentCellPosition != null ?
                    "Current Path : " + startCellPosition.Value.X + ", " + startCellPosition.Value.Y + " to " +
                    currentCellPosition.Value.X + ", " + currentCellPosition.Value.Y :
                    "Current Path : ";
                    break;
            }
        }

        private void manualRadioButton_Click(object sender, EventArgs e)
        {
            randomRadioButton.Checked = false;
            isManualMode = true;
        }

        private void randomRadioButton_Click(object sender, EventArgs e)
        {
            manualRadioButton.Checked = false;
            isManualMode = false;

            Point? randomStartCellPosition = null;
            Point? randomEndCellPosition = null;

            // Generates random point for start/end
            while (randomStartCellPosition == randomEndCellPosition)
            {
                randomStartCellPosition = mazeHelper.GeneratePoint();
                randomEndCellPosition = mazeHelper.GeneratePoint();
            }    

            // Applies color to cell
            positionHelper.RemoveStart(mazeGrid, startCellPosition);
            positionHelper.RemoveEnd(mazeGrid, endCellPosition);
            startCellPosition = randomStartCellPosition;
            endCellPosition = randomEndCellPosition;
            positionHelper.PlaceStart(mazeGrid, startCellPosition, randomStartCellPosition);
            positionHelper.PlaceEnd(mazeGrid, endCellPosition, randomEndCellPosition);

            // Sets new value for start/end
            startCellPosition = randomStartCellPosition;
            endCellPosition = randomEndCellPosition;

            startLabel.Text = startCellPosition != null ?
                        "Start Position : " + "X - " + startCellPosition.Value.X + ",Y - " + startCellPosition.Value.Y :
                        "Start Position : ";

            endLabel.Text = endCellPosition != null ?
                "End Position : " + "X - " + endCellPosition.Value.X + ",Y - " + endCellPosition.Value.Y :
                "End Position : ";
        }

        private void mazeGrid_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
        }

        private void generateMazeButton_Click(object sender, EventArgs e)
        {
            if(startCellPosition == null)
            {
                MessageBox.Show("Place a start position!");
                return;
            }
            if(endCellPosition == null)
            {
                MessageBox.Show("Place an end position!");
                return;
            }

            mazeHelper.GenerateWalls(mazeGrid, startCellPosition, endCellPosition);
        }

        Graphics outline;
        private void mazeGrid_Paint(object sender, PaintEventArgs e)
        {
            outline = e.Graphics;
            
            mazeHelper.DrawOutline(outline);
        }

        private void mazeGrid_MouseHover(object sender, EventArgs e)
        {
            if(startCellPosition == null)
            {
                return;
            }
            
            // Gets cell position on mouse click
            Point? currentCellPosition = new Point(Cursor.Position.X / (mazeGrid.Width / mazeGrid.ColumnCount), 
                                                Cursor.Position.Y / (mazeGrid.Height / mazeGrid.RowCount));

            currentPathLabel.Text = currentCellPosition != null ?
            "Current Path : " + startCellPosition.Value.X + ", " + startCellPosition.Value.Y + " to " +
            currentCellPosition.Value.X + ", " + currentCellPosition.Value.Y :
            "Current Path : ";
        }

        private void mazeGrid_MouseLeave(object sender, EventArgs e)
        {
            // Gets cell position on mouse click
            Point? currentCellPosition = new Point(Cursor.Position.X / (mazeGrid.Width / mazeGrid.ColumnCount),
                                                Cursor.Position.Y / (mazeGrid.Height / mazeGrid.RowCount));

            currentPathLabel.Text = "Current Path : ";
        }

        private void solveButton_Click(object sender, EventArgs e)
        {
            if (endCellPosition == null || startCellPosition == null) return;
            mazeHelper.DrawPath(endCellPosition);
            currentPathLabel.Text = endCellPosition != null ?
                    "Current Path : " + startCellPosition.Value.X + ", " + startCellPosition.Value.Y + " to " +
                    endCellPosition.Value.X + ", " + endCellPosition.Value.Y :
                    "Current Path : ";
        }
    }
}
