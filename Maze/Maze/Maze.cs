using Maze.Helper;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Maze
{
    public partial class Maze : Form
    {
        MazeHelper mazeHelper = new MazeHelper();
        PositionHelper positionHelper = new PositionHelper();

        Point? startCellPosition;
        Point? endCellPosition;

        bool isManualMode = true;

        public Maze()
        {
            InitializeComponent();

            // Temporarily disables maze grid
            mazeGrid.Enabled = false;

            // Sets default & temporarily disable radio buttons
            manualRadioButton.Checked = true;
            manualRadioButton.Enabled = false;
            randomRadioButton.Enabled = false;
        }

        private void Maze_Load(object sender, EventArgs e)
        {

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
            // If true, sets default text to 0
            if (textBox_row.Text.Count() <= 0 || textBox_column.Text.Count() <= 0)
            {
                textBox_row.Text = "0";
                textBox_column.Text = "0";
            }

            int row = int.Parse(textBox_row.Text);
            row = row > 0 ? row : 1;

            int column = int.Parse(textBox_column.Text);
            column = column > 0 ? column : 1;

            // Resets position
            startCellPosition = null;
            endCellPosition = null;

            mazeHelper.DrawMaze(mazeGrid, () =>
            {
                // Resets all properties in table layout panel
                mazeGrid.RowStyles.Clear();
                mazeGrid.ColumnStyles.Clear();
                mazeGrid.Enabled = true;

                for (int i = mazeGrid.Controls.Count - 1; i >= 0; --i)
                {
                    mazeGrid.Controls[i].Dispose();
                }

                // Adds row to table layout panel
                // Adds column to table layout panel
                mazeGrid.RowCount = row;
                mazeGrid.ColumnCount = column;
                for (int i = 0; i < row; i++)
                {
                    mazeGrid.RowStyles.Add(new RowStyle(SizeType.Percent, .50f));
                    for (int j = 0; j < column; j++)
                    {
                        mazeGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, .50f));
                        mazeGrid.Controls.Add(new Panel { Dock = DockStyle.Fill, Enabled = false });
                    }
                }
            });

            // Resets radio button
            manualRadioButton.Enabled = true;
            manualRadioButton.Checked = true;
            isManualMode = true;
            randomRadioButton.Enabled = true;
            randomRadioButton.Checked = false;
        }

        private void mazeGrid_MouseClick(object sender, MouseEventArgs e)
        {
            if(isManualMode == false)
            {
                return;
            }

            // Gets cell position on mouse click
            var currentCellPosition = new Point(e.X / (mazeGrid.Width / mazeGrid.ColumnCount), 
                                                e.Y / (mazeGrid.Height / mazeGrid.RowCount));

            // Checks for mouse button
            switch (e.Button)
            {
                case MouseButtons.Left:
                    // If start is placed in end then reset
                    if (startCellPosition == endCellPosition)
                    {
                        endCellPosition = null;
                    }

                    if (startCellPosition == currentCellPosition)
                    {
                        positionHelper.RemoveStart(mazeGrid, startCellPosition);
                        startCellPosition = null;
                    }
                    else
                    {
                        positionHelper.PlaceStart(mazeGrid, startCellPosition, currentCellPosition);
                        startCellPosition = currentCellPosition;
                    }
                    break;

                case MouseButtons.Right:
                    // If end is placed in start then reset
                    if (endCellPosition == startCellPosition)
                    {
                        startCellPosition = null;
                    }

                    if (endCellPosition == currentCellPosition)
                    {
                        positionHelper.RemoveEnd(mazeGrid, endCellPosition);
                        endCellPosition = null;
                    }
                    else
                    {
                        positionHelper.PlaceEnd(mazeGrid, endCellPosition, currentCellPosition);
                        endCellPosition = currentCellPosition;
                    }
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
        }

        private void mazeGrid_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
        }
    }
}
