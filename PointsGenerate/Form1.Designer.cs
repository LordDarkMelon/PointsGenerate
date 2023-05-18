namespace PointsGenerate
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox_TotalExpectedPoints = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            pictureBox = new PictureBox();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // textBox_TotalExpectedPoints
            // 
            textBox_TotalExpectedPoints.Location = new Point(488, 25);
            textBox_TotalExpectedPoints.Name = "textBox_TotalExpectedPoints";
            textBox_TotalExpectedPoints.Size = new Size(48, 23);
            textBox_TotalExpectedPoints.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(691, 20);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(48, 23);
            textBox2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(418, 28);
            label1.Name = "label1";
            label1.Size = new Size(68, 15);
            label1.TabIndex = 2;
            label1.Text = "Total Points";
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(62, 88);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(599, 328);
            pictureBox.TabIndex = 3;
            pictureBox.TabStop = false;
            pictureBox.SizeChanged += pictureBox_SizeChanged;
            pictureBox.Paint += Paint;
            // 
            // button1
            // 
            button1.Location = new Point(563, 28);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "Refresh";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(pictureBox);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox_TotalExpectedPoints);
            Name = "Form1";
            Text = "Form1";
            Resize += Form1_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_TotalExpectedPoints;
        private TextBox textBox2;
        private Label label1;
        private PictureBox pictureBox;
        private Button button1;
    }
}