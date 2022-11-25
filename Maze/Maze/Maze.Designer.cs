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
            this.button2 = new System.Windows.Forms.Button();
            this.label_row = new System.Windows.Forms.Label();
            this.label_column = new System.Windows.Forms.Label();
            this.textBox_row = new System.Windows.Forms.TextBox();
            this.textBox_column = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.mazeGrid.Location = new System.Drawing.Point(3, 3);
            this.mazeGrid.MaximumSize = new System.Drawing.Size(617, 529);
            this.mazeGrid.MinimumSize = new System.Drawing.Size(617, 529);
            this.mazeGrid.Name = "mazeGrid";
            this.mazeGrid.Padding = new System.Windows.Forms.Padding(1);
            this.mazeGrid.RowCount = 1;
            this.mazeGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.mazeGrid.Size = new System.Drawing.Size(617, 529);
            this.mazeGrid.TabIndex = 0;
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
            this.generateButton.Text = "Generate Maze";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.Location = new System.Drawing.Point(643, 126);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(129, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Solve Maze";
            this.button2.UseVisualStyleBackColor = true;
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
            this.label_row.Click += new System.EventHandler(this.label1_Click);
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
            this.label_column.Click += new System.EventHandler(this.label1_Click);
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
            this.textBox_row.TextChanged += new System.EventHandler(this.textBox_row_TextChanged);
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
            // Maze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.textBox_column);
            this.Controls.Add(this.textBox_row);
            this.Controls.Add(this.label_column);
            this.Controls.Add(this.label_row);
            this.Controls.Add(this.button2);
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TableLayoutPanel mazeGrid;
        private System.Windows.Forms.Label label_row;
        private System.Windows.Forms.Label label_column;
        private System.Windows.Forms.TextBox textBox_row;
        private System.Windows.Forms.TextBox textBox_column;
    }
}

