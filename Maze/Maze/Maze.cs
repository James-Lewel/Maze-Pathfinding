using Maze.Helper;
using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        int row;
        int column;

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
            // Disables button
            generateGridButton.Enabled = false;

            // If true, sets default text to 0
            if (textBox_row.Text.Count() <= 0 || textBox_column.Text.Count() <= 0)
            {
                textBox_row.Text = "0";
                textBox_column.Text = "0";
            }

            row = int.Parse(textBox_row.Text);
            row = row > 0 ? row : 1;

            column = int.Parse(textBox_column.Text);
            column = column > 0 ? column : 1;

            // Resets position
            startCellPosition = null;
            endCellPosition = null;

            // Creates a separate thread
            mazeHelper.DrawMaze(mazeGrid, async () =>
            {
                // Sets progress bar values
                progressBar.Value = 0;
                progressBar.Minimum = 0;
                progressBar.Maximum = (row * column) + mazeGrid.Controls.Count;
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

                mazeGrid.RowCount = row;
                mazeGrid.ColumnCount = column;
                for (int i = 0; i < row; i++)
                {
                    // Adds row to table layout panel
                    mazeGrid.RowStyles.Add(new RowStyle(SizeType.Percent, .50f));
                    for (int j = 0; j < column; j++)
                    {
                        // Adds column to table layout panel
                        mazeGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, .50f));

                        // Adds control to table cells
                        mazeGrid.Controls.Add(new Panel { Dock = DockStyle.Fill, Enabled = false });

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
                    }
                    break;

                case MouseButtons.Right:
                    // If end is placed in start then reset
                    if (endCellPosition == startCellPosition)
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
