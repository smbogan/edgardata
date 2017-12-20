namespace EdgarData
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.subsGrid = new System.Windows.Forms.DataGridView();
            this.filter = new System.Windows.Forms.TextBox();
            this.numsGrid = new System.Windows.Forms.DataGridView();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.subsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // subsGrid
            // 
            this.subsGrid.AllowUserToAddRows = false;
            this.subsGrid.AllowUserToDeleteRows = false;
            this.subsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.subsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.subsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.subsGrid.Location = new System.Drawing.Point(12, 68);
            this.subsGrid.Name = "subsGrid";
            this.subsGrid.ReadOnly = true;
            this.subsGrid.Size = new System.Drawing.Size(439, 581);
            this.subsGrid.TabIndex = 2;
            this.subsGrid.SelectionChanged += new System.EventHandler(this.subsGrid_SelectionChanged);
            // 
            // filter
            // 
            this.filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filter.Location = new System.Drawing.Point(12, 42);
            this.filter.Name = "filter";
            this.filter.Size = new System.Drawing.Size(322, 20);
            this.filter.TabIndex = 3;
            this.filter.TextChanged += new System.EventHandler(this.filter_TextChanged);
            // 
            // numsGrid
            // 
            this.numsGrid.AllowUserToAddRows = false;
            this.numsGrid.AllowUserToDeleteRows = false;
            this.numsGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.numsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.numsGrid.Location = new System.Drawing.Point(469, 68);
            this.numsGrid.Name = "numsGrid";
            this.numsGrid.ReadOnly = true;
            this.numsGrid.Size = new System.Drawing.Size(622, 581);
            this.numsGrid.TabIndex = 4;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(175, 13);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 661);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.numsGrid);
            this.Controls.Add(this.filter);
            this.Controls.Add(this.subsGrid);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.subsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DataGridView subsGrid;
        private System.Windows.Forms.TextBox filter;
        private System.Windows.Forms.DataGridView numsGrid;
        private System.Windows.Forms.Button button3;
    }
}

