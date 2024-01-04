namespace chess
{
    partial class Form2
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
            this.components = new System.ComponentModel.Container();
            this.Timer2 = new System.Windows.Forms.TextBox();
            this.Player2_Name = new System.Windows.Forms.Label();
            this.Player1_Name = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.TextBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.blackTimer = new System.Windows.Forms.Timer(this.components);
            this.whiteTimer = new System.Windows.Forms.Timer(this.components);
            this.Board = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Board)).BeginInit();
            this.SuspendLayout();
            // 
            // Timer2
            // 
            this.Timer2.BackColor = System.Drawing.SystemColors.Control;
            this.Timer2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Timer2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Timer2.Location = new System.Drawing.Point(518, 646);
            this.Timer2.Name = "Timer2";
            this.Timer2.Size = new System.Drawing.Size(104, 13);
            this.Timer2.TabIndex = 7;
            // 
            // Player2_Name
            // 
            this.Player2_Name.AutoSize = true;
            this.Player2_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2_Name.Location = new System.Drawing.Point(40, 646);
            this.Player2_Name.Name = "Player2_Name";
            this.Player2_Name.Size = new System.Drawing.Size(70, 25);
            this.Player2_Name.TabIndex = 8;
            this.Player2_Name.Text = "label1";
            // 
            // Player1_Name
            // 
            this.Player1_Name.AutoSize = true;
            this.Player1_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1_Name.Location = new System.Drawing.Point(40, 10);
            this.Player1_Name.Name = "Player1_Name";
            this.Player1_Name.Size = new System.Drawing.Size(70, 25);
            this.Player1_Name.TabIndex = 9;
            this.Player1_Name.Text = "label2";
            // 
            // Timer1
            // 
            this.Timer1.BackColor = System.Drawing.SystemColors.Control;
            this.Timer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Timer1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Timer1.Location = new System.Drawing.Point(518, 12);
            this.Timer1.Name = "Timer1";
            this.Timer1.Size = new System.Drawing.Size(104, 13);
            this.Timer1.TabIndex = 10;
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 12;
            this.label1.Text = "time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(196, 641);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 25);
            this.label2.TabIndex = 13;
            this.label2.Text = "turn";
            // 
            // blackTimer
            // 
            this.blackTimer.Interval = 1000;
            // 
            // whiteTimer
            // 
            this.whiteTimer.Interval = 1000;
            // 
            // Board
            // 
            this.Board.Image = global::chess.Properties.Resources.Board;
            this.Board.Location = new System.Drawing.Point(25, 38);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(600, 600);
            this.Board.TabIndex = 11;
            this.Board.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 680);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Board);
            this.Controls.Add(this.Timer1);
            this.Controls.Add(this.Player1_Name);
            this.Controls.Add(this.Player2_Name);
            this.Controls.Add(this.Timer2);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.Board)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Timer2;
        private System.Windows.Forms.Label Player2_Name;
        private System.Windows.Forms.Label Player1_Name;
        private System.Windows.Forms.TextBox Timer1;
        private System.Windows.Forms.PictureBox Board;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer blackTimer;
        private System.Windows.Forms.Timer whiteTimer;
    }
}