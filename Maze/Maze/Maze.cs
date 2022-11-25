using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Maze
{
    public partial class Maze : Form
    {
        public Maze()
        {
            InitializeComponent();
        }

        private void Maze_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox_row_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_row_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;

                // Notifies user input must be an integer
                MessageBox.Show("Input must be an integer");
            }
        }

        private void textBox_row_KeyUp(object sender, KeyEventArgs e)
        {
            textBox_column.Text = textBox_row.Text;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            if (textBox_row.Text.Count() <= 0) textBox_row.Text = "0";

            int row = int.Parse(textBox_row.Text);
            row = row > 0 ? row : 1;

            int column = int.Parse(textBox_column.Text);
            column = column > 0 ? column : 1;

            mazeGrid.Controls.Clear();
            mazeGrid.RowStyles.Clear();
            mazeGrid.ColumnStyles.Clear();

            mazeGrid.RowCount = row;
            for(int i = 0; i <= row; i++)
            {
                mazeGrid.RowStyles.Add(new RowStyle(SizeType.Percent, .50f));
            }

            mazeGrid.ColumnCount = column;
            for (int i = 0; i <= column; i++)
            {
                mazeGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, .50f));
            }
        }
    }
}
