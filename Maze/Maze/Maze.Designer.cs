namespace Maze
{
    partial class Maze
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.mazeGrid = new System.Windows.Forms.TableLayoutPanel();
            this.generateButton = new System.Windows.Forms.Button();
            this.generateMazeButton = new System.Windows.Forms.Button();
            this.label_row = new System.Windows.Forms.Label();
            this.label_column = new System.Windows.Forms.Label();
            this.textBox_row = new System.Windows.Forms.TextBox();
            this.textBox_column = new System.Windows.Forms.TextBox();
            this.label_ownership = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.manualRadioButton = new System.Windows.Forms.RadioButton();
            this.randomRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.mazeGrid);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(625, 537);
            this.panel1.TabIndex = 0;
            // 
            // mazeGrid
            // 
            this.mazeGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mazeGrid.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.mazeGrid.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.mazeGrid.ColumnCount = 1;
            this.mazeGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mazeGrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mazeGrid.Location = new System.Drawing.Point(3, 3);
            this.mazeGrid.MaximumSize = new System.Drawing.Size(617, 529);
            this.mazeGrid.MinimumSize = new System.Drawing.Size(617, 529);
            this.mazeGrid.Name = "mazeGrid";
            this.mazeGrid.Padding = new System.Windows.Forms.Padding(1);
            this.mazeGrid.RowCount = 1;
            this.mazeGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mazeGrid.Size = new System.Drawing.Size(617, 529);
            this.mazeGrid.TabIndex = 0;
            this.mazeGrid.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.mazeGrid_CellPaint);
            this.mazeGrid.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mazeGrid_MouseClick);
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.Location = new System.Drawing.Point(643, 97);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(129, 23);
            this.generateButton.TabIndex = 1;
            this.generateButton.Text = "Generate Grid";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateGridButton_Click);
            // 
            // generateMazeButton
            // 
            this.generateMazeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.generateMazeButton.Location = new System.Drawing.Point(643, 185);
            this.generateMazeButton.Name = "generateMazeButton";
            this.generateMazeButton.Size = new System.Drawing.Size(129, 23);
            this.generateMazeButton.TabIndex = 1;
            this.generateMazeButton.Text = "Generate Maze";
            this.generateMazeButton.UseVisualStyleBackColor = true;
            // 
            // label_row
            // 
            this.label_row.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_row.AutoSize = true;
            this.label_row.Location = new System.Drawing.Point(640, 15);
            this.label_row.Name = "label_row";
            this.label_row.Size = new System.Drawing.Size(34, 13);
            this.label_row.TabIndex = 2;
            this.label_row.Text = "Rows";
            // 
            // label_column
            // 
            this.label_column.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_column.AutoSize = true;
            this.label_column.Location = new System.Drawing.Point(640, 55);
            this.label_column.Name = "label_column";
            this.label_column.Size = new System.Drawing.Size(47, 13);
            this.label_column.TabIndex = 2;
            this.label_column.Text = "Columns";
            // 
            // textBox_row
            // 
            this.textBox_row.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_row.Location = new System.Drawing.Point(643, 32);
            this.textBox_row.Name = "textBox_row";
            this.textBox_row.Size = new System.Drawing.Size(129, 20);
            this.textBox_row.TabIndex = 3;
            this.textBox_row.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_row_KeyPress);
            this.textBox_row.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_row_KeyUp);
            // 
            // textBox_column
            // 
            this.textBox_column.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_column.Enabled = false;
            this.textBox_column.Location = new System.Drawing.Point(643, 71);
            this.textBox_column.Name = "textBox_column";
            this.textBox_column.Size = new System.Drawing.Size(129, 20);
            this.textBox_column.TabIndex = 3;
            // 
            // label_ownership
            // 
            this.label_ownership.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_ownership.AutoSize = true;
            this.label_ownership.Location = new System.Drawing.Point(649, 510);
            this.label_ownership.Name = "label_ownership";
            this.label_ownership.Size = new System.Drawing.Size(123, 39);
            this.label_ownership.TabIndex = 4;
            this.label_ownership.Text = "Created by: \r\nJames Lewel T. Padecio\r\nBSCS - 3";
            this.label_ownership.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(643, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Solve Maze";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // manualRadioButton
            // 
            this.manualRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.manualRadioButton.AutoSize = true;
            this.manualRadioButton.Location = new System.Drawing.Point(652, 139);
            this.manualRadioButton.Name = "manualRadioButton";
            this.manualRadioButton.Size = new System.Drawing.Size(90, 17);
            this.manualRadioButton.TabIndex = 5;
            this.manualRadioButton.TabStop = true;
            this.manualRadioButton.Text = "Manual Mode";
            this.manualRadioButton.UseVisualStyleBackColor = true;
            this.manualRadioButton.Click += new System.EventHandler(this.manualRadioButton_Click);
            // 
            // randomRadioButton
            // 
            this.randomRadioButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.randomRadioButton.AutoSize = true;
            this.randomRadioButton.Location = new System.Drawing.Point(652, 162);
            this.randomRadioButton.Name = "randomRadioButton";
            this.randomRadioButton.Size = new System.Drawing.Size(95, 17);
            this.randomRadioButton.TabIndex = 5;
            this.randomRadioButton.TabStop = true;
            this.randomRadioButton.Text = "Random Mode";
            this.randomRadioButton.UseVisualStyleBackColor = true;
            this.randomRadioButton.Click += new System.EventHandler(this.randomRadioButton_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(640, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Generation Mode:";
            // 
            // Maze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.randomRadioButton);
            this.Controls.Add(this.manualRadioButton);
            this.Controls.Add(this.label_ownership);
            this.Controls.Add(this.textBox_column);
            this.Controls.Add(this.textBox_row);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_column);
            this.Controls.Add(this.label_row);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.generateMazeButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Maze";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maze - A CS345 Project";
            this.Load += new System.EventHandler(this.Maze_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button generateMazeButton;
        private System.Windows.Forms.TableLayoutPanel mazeGrid;
        private System.Windows.Forms.Label label_row;
        private System.Windows.Forms.Label label_column;
        private System.Windows.Forms.TextBox textBox_row;
        private System.Windows.Forms.TextBox textBox_column;
        private System.Windows.Forms.Label label_ownership;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton manualRadioButton;
        private System.Windows.Forms.RadioButton randomRadioButton;
        private System.Windows.Forms.Label label1;
    }
}

