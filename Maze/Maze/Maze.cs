using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Maze
{
    public partial class Maze : Form
    {
        Point? startCellPosition;
        Point? endCellPosition;

        public Maze()
        {
            InitializeComponent();
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

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (textBox_row.Text.Count() <= 0 || textBox_column.Text.Count() <= 0)
            {
                textBox_row.Text = "0";
                textBox_column.Text = "0";
            }

            int row = int.Parse(textBox_row.Text);
            row = row > 0 ? row : 1;

            int column = int.Parse(textBox_column.Text);
            column = column > 0 ? column : 1;

            // Resets all properties in table layout panel
            mazeGrid.Controls.Clear();
            mazeGrid.RowStyles.Clear();
            mazeGrid.ColumnStyles.Clear();
            startCellPosition = null;
            endCellPosition = null;

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
        }

        private void mazeGrid_MouseClick(object sender, MouseEventArgs e)
        {
            // Gets cell position on mouse click
            var cellPosition = new Point(e.X / (mazeGrid.Width / mazeGrid.ColumnCount), 
                                         e.Y / (mazeGrid.Height / mazeGrid.RowCount));
            Control control;

            // Checks for mouse button
            switch (e.Button)
            {
                case MouseButtons.Left:
                    // Remove start cell and color
                    if (startCellPosition != null)
                    {
                        control = mazeGrid.GetControlFromPosition(startCellPosition.Value.X, startCellPosition.Value.Y);
                        control.BackColor = Color.White;

                        // If start is placed in end then reset
                        if (startCellPosition == endCellPosition)
                        {
                            endCellPosition = null;
                        }
                    }

                    // Place start cell and color
                    control = mazeGrid.GetControlFromPosition(cellPosition.X, cellPosition.Y);
                    control.BackColor = Color.Green;

                    startCellPosition = cellPosition;
                    break;

                case MouseButtons.Right:
                    // Remove end cell and color
                    if (endCellPosition != null)
                    {
                        control = mazeGrid.GetControlFromPosition(endCellPosition.Value.X, endCellPosition.Value.Y);
                        control.BackColor = Color.White;

                        // If end is placed in start then reset
                        if (endCellPosition == startCellPosition)
                        {
                            startCellPosition = null;
                        }
                    }

                    // Place start cell and color
                    control = mazeGrid.GetControlFromPosition(cellPosition.X, cellPosition.Y);
                    control.BackColor = Color.Red;

                    endCellPosition = cellPosition;
                    break;
            }
        }

        private void mazeGrid_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
        }

    }
}
