namespace chess
{
    partial class ChessGame
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
            this.Player1_Name = new System.Windows.Forms.Label();
            this.Player2_Name = new System.Windows.Forms.Label();
            this.Timer1 = new System.Windows.Forms.TextBox();
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.history = new System.Windows.Forms.Label();
            this.currentPlayerLabel = new System.Windows.Forms.Label();
            this.blackTimer = new System.Windows.Forms.Timer(this.components);
            this.whiteTimer = new System.Windows.Forms.Timer(this.components);
            this.cross = new System.Windows.Forms.Label();
            this.turn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Timer2
            // 
            this.Timer2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(40)))));
            this.Timer2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Timer2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Timer2.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timer2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(81)))), ((int)(((byte)(109)))));
            this.Timer2.Location = new System.Drawing.Point(691, 832);
            this.Timer2.Margin = new System.Windows.Forms.Padding(4);
            this.Timer2.Name = "Timer2";
            this.Timer2.ReadOnly = true;
            this.Timer2.Size = new System.Drawing.Size(139, 34);
            this.Timer2.TabIndex = 7;
            this.Timer2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Player1_Name
            // 
            this.Player1_Name.AutoSize = true;
            this.Player1_Name.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player1_Name.Location = new System.Drawing.Point(32, 832);
            this.Player1_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player1_Name.Name = "Player1_Name";
            this.Player1_Name.Size = new System.Drawing.Size(133, 35);
            this.Player1_Name.TabIndex = 8;
            this.Player1_Name.Text = "PLAYER2";
            this.Player1_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Player2_Name
            // 
            this.Player2_Name.AutoSize = true;
            this.Player2_Name.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Player2_Name.Location = new System.Drawing.Point(32, 16);
            this.Player2_Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Player2_Name.Name = "Player2_Name";
            this.Player2_Name.Size = new System.Drawing.Size(132, 35);
            this.Player2_Name.TabIndex = 9;
            this.Player2_Name.Text = "PLAYER1";
            this.Player2_Name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Timer1
            // 
            this.Timer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(40)))));
            this.Timer1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Timer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Timer1.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Timer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(81)))), ((int)(((byte)(109)))));
            this.Timer1.Location = new System.Drawing.Point(691, 17);
            this.Timer1.Margin = new System.Windows.Forms.Padding(4);
            this.Timer1.Name = "Timer1";
            this.Timer1.ReadOnly = true;
            this.Timer1.Size = new System.Drawing.Size(139, 34);
            this.Timer1.TabIndex = 10;
            this.Timer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // timer3
            // 
            this.timer3.Interval = 1000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // history
            // 
            this.history.AutoSize = true;
            this.history.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.history.Location = new System.Drawing.Point(368, 23);
            this.history.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(60, 26);
            this.history.TabIndex = 12;
            this.history.Text = "time";
            this.history.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // currentPlayerLabel
            // 
            this.currentPlayerLabel.AutoSize = true;
            this.currentPlayerLabel.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPlayerLabel.ForeColor = System.Drawing.Color.White;
            this.currentPlayerLabel.Location = new System.Drawing.Point(359, 838);
            this.currentPlayerLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.currentPlayerLabel.Name = "currentPlayerLabel";
            this.currentPlayerLabel.Size = new System.Drawing.Size(80, 26);
            this.currentPlayerLabel.TabIndex = 13;
            this.currentPlayerLabel.Text = "WHITE";
            this.currentPlayerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // blackTimer
            // 
            this.blackTimer.Interval = 1000;
            // 
            // whiteTimer
            // 
            this.whiteTimer.Interval = 1000;
            // 
            // cross
            // 
            this.cross.AutoSize = true;
            this.cross.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cross.Location = new System.Drawing.Point(828, 16);
            this.cross.Name = "cross";
            this.cross.Size = new System.Drawing.Size(36, 35);
            this.cross.TabIndex = 14;
            this.cross.Text = "X";
            this.cross.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cross.Click += new System.EventHandler(this.cross_Click);
            // 
            // turn
            // 
            this.turn.AutoSize = true;
            this.turn.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.turn.Location = new System.Drawing.Point(441, 838);
            this.turn.Name = "turn";
            this.turn.Size = new System.Drawing.Size(66, 26);
            this.turn.TabIndex = 15;
            this.turn.Text = "TURN";
            // 
            // ChessGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(900, 900);
            this.ControlBox = false;
            this.Controls.Add(this.turn);
            this.Controls.Add(this.cross);
            this.Controls.Add(this.currentPlayerLabel);
            this.Controls.Add(this.history);
            this.Controls.Add(this.Timer1);
            this.Controls.Add(this.Player2_Name);
            this.Controls.Add(this.Player1_Name);
            this.Controls.Add(this.Timer2);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(136)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChessGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChessGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Timer2;
        private System.Windows.Forms.Label Player1_Name;
        private System.Windows.Forms.Label Player2_Name;
        private System.Windows.Forms.TextBox Timer1;
        private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Label history;
        private System.Windows.Forms.Label currentPlayerLabel;
        private System.Windows.Forms.Timer blackTimer;
        private System.Windows.Forms.Timer whiteTimer;
        private System.Windows.Forms.Label cross;
        private System.Windows.Forms.Label turn;
    }
}