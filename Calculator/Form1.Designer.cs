namespace Calculator
{
    partial class Calculator
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
            this.start = new System.Windows.Forms.Button();
            this.challenge_input = new System.Windows.Forms.TextBox();
            this.challenge_start = new System.Windows.Forms.Button();
            this.calculatorDisplay = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Dock = System.Windows.Forms.DockStyle.Top;
            this.start.Location = new System.Drawing.Point(0, 0);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(630, 39);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.Start_Click);
            // 
            // challenge_input
            // 
            this.challenge_input.Location = new System.Drawing.Point(0, 45);
            this.challenge_input.Name = "challenge_input";
            this.challenge_input.Size = new System.Drawing.Size(490, 20);
            this.challenge_input.TabIndex = 2;
            this.challenge_input.Text = "1+2";
            // 
            // challenge_start
            // 
            this.challenge_start.Location = new System.Drawing.Point(496, 45);
            this.challenge_start.Name = "challenge_start";
            this.challenge_start.Size = new System.Drawing.Size(134, 23);
            this.challenge_start.TabIndex = 3;
            this.challenge_start.Text = "Do Your Worst";
            this.challenge_start.UseVisualStyleBackColor = true;
            this.challenge_start.Click += new System.EventHandler(this.challenge_start_Click);
            // 
            // calculatorDisplay
            // 
            this.calculatorDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.calculatorDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.calculatorDisplay.Location = new System.Drawing.Point(0, 89);
            this.calculatorDisplay.Name = "calculatorDisplay";
            this.calculatorDisplay.Size = new System.Drawing.Size(630, 402);
            this.calculatorDisplay.TabIndex = 4;
            this.calculatorDisplay.UseCompatibleStateImageBehavior = false;
            this.calculatorDisplay.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Input";
            this.columnHeader1.Width = 315;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Result";
            this.columnHeader2.Width = 315;
            // 
            // Calculator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 491);
            this.Controls.Add(this.calculatorDisplay);
            this.Controls.Add(this.challenge_start);
            this.Controls.Add(this.challenge_input);
            this.Controls.Add(this.start);
            this.Name = "Calculator";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox challenge_input;
        private System.Windows.Forms.Button challenge_start;
        private System.Windows.Forms.ListView calculatorDisplay;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}

