namespace BouncingBall
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
            this.Ball = new System.Windows.Forms.PictureBox();
            this.BallStepLabel = new System.Windows.Forms.Label();
            this.Racket = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Racket)).BeginInit();
            this.SuspendLayout();
            // 
            // Ball
            // 
            this.Ball.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.Ball.Location = new System.Drawing.Point(231, 217);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(100, 67);
            this.Ball.TabIndex = 0;
            this.Ball.TabStop = false;
            this.Ball.Click += new System.EventHandler(this.Ball_Click);
            // 
            // BallStepLabel
            // 
            this.BallStepLabel.AutoSize = true;
            this.BallStepLabel.Location = new System.Drawing.Point(50, 25);
            this.BallStepLabel.Name = "BallStepLabel";
            this.BallStepLabel.Size = new System.Drawing.Size(35, 13);
            this.BallStepLabel.TabIndex = 1;
            this.BallStepLabel.Text = "label1";
            // 
            // Racket
            // 
            this.Racket.BackColor = System.Drawing.Color.Teal;
            this.Racket.Location = new System.Drawing.Point(210, 326);
            this.Racket.Name = "Racket";
            this.Racket.Size = new System.Drawing.Size(249, 31);
            this.Racket.TabIndex = 2;
            this.Racket.TabStop = false;
            this.Racket.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Racket_MouseDown);
            this.Racket.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Racket_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Racket);
            this.Controls.Add(this.BallStepLabel);
            this.Controls.Add(this.Ball);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Racket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Ball;
        private System.Windows.Forms.Label BallStepLabel;
        private System.Windows.Forms.PictureBox Racket;
    }
}

