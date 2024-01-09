namespace chess
{
    partial class Chess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chess));
            this.settingsLabel = new System.Windows.Forms.Label();
            this.timeLimitLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Player1 = new System.Windows.Forms.TextBox();
            this.Player2 = new System.Windows.Forms.TextBox();
            this.TimeLimit = new System.Windows.Forms.TextBox();
            this.cross = new System.Windows.Forms.Label();
            this.startGame = new System.Windows.Forms.Label();
            this.historyLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // settingsLabel
            // 
            this.settingsLabel.AutoSize = true;
            this.settingsLabel.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settingsLabel.Location = new System.Drawing.Point(190, 16);
            this.settingsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.settingsLabel.Name = "settingsLabel";
            this.settingsLabel.Size = new System.Drawing.Size(142, 35);
            this.settingsLabel.TabIndex = 0;
            this.settingsLabel.Text = "SETTINGS";
            this.settingsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeLimitLabel
            // 
            this.timeLimitLabel.AutoSize = true;
            this.timeLimitLabel.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLimitLabel.Location = new System.Drawing.Point(180, 146);
            this.timeLimitLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.timeLimitLabel.Name = "timeLimitLabel";
            this.timeLimitLabel.Size = new System.Drawing.Size(165, 35);
            this.timeLimitLabel.TabIndex = 1;
            this.timeLimitLabel.Text = "Time Limit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(300, 66);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(145, 35);
            this.label3.TabIndex = 2;
            this.label3.Text = "Player 2 ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 35);
            this.label4.TabIndex = 3;
            this.label4.Text = "Player 1 ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Player1
            // 
            this.Player1.Location = new System.Drawing.Point(85, 105);
            this.Player1.Margin = new System.Windows.Forms.Padding(4);
            this.Player1.Name = "Player1";
            this.Player1.Size = new System.Drawing.Size(125, 22);
            this.Player1.TabIndex = 5;
            this.Player1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Player2
            // 
            this.Player2.Location = new System.Drawing.Point(306, 105);
            this.Player2.Margin = new System.Windows.Forms.Padding(4);
            this.Player2.Name = "Player2";
            this.Player2.Size = new System.Drawing.Size(126, 22);
            this.Player2.TabIndex = 6;
            this.Player2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TimeLimit
            // 
            this.TimeLimit.Location = new System.Drawing.Point(186, 185);
            this.TimeLimit.Margin = new System.Windows.Forms.Padding(4);
            this.TimeLimit.Name = "TimeLimit";
            this.TimeLimit.Size = new System.Drawing.Size(150, 22);
            this.TimeLimit.TabIndex = 7;
            this.TimeLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cross
            // 
            this.cross.AutoSize = true;
            this.cross.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cross.Location = new System.Drawing.Point(485, 16);
            this.cross.Name = "cross";
            this.cross.Size = new System.Drawing.Size(36, 35);
            this.cross.TabIndex = 10;
            this.cross.Text = "X";
            this.cross.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cross.Click += new System.EventHandler(this.cross_Click);
            // 
            // startGame
            // 
            this.startGame.AutoSize = true;
            this.startGame.Font = new System.Drawing.Font("Showcard Gothic", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startGame.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(81)))), ((int)(((byte)(109)))));
            this.startGame.Location = new System.Drawing.Point(174, 228);
            this.startGame.Name = "startGame";
            this.startGame.Size = new System.Drawing.Size(180, 35);
            this.startGame.TabIndex = 12;
            this.startGame.Text = "Start Game";
            this.startGame.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.startGame.Click += new System.EventHandler(this.startGame_Click_1);
            // 
            // historyLabel
            // 
            this.historyLabel.AutoSize = true;
            this.historyLabel.Font = new System.Drawing.Font("Showcard Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyLabel.Location = new System.Drawing.Point(224, 263);
            this.historyLabel.Name = "historyLabel";
            this.historyLabel.Size = new System.Drawing.Size(67, 17);
            this.historyLabel.TabIndex = 13;
            this.historyLabel.Text = "history";
            this.historyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.historyLabel.Click += new System.EventHandler(this.history_Click);
            // 
            // Chess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(8)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(533, 328);
            this.Controls.Add(this.historyLabel);
            this.Controls.Add(this.startGame);
            this.Controls.Add(this.cross);
            this.Controls.Add(this.TimeLimit);
            this.Controls.Add(this.Player2);
            this.Controls.Add(this.Player1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.timeLimitLabel);
            this.Controls.Add(this.settingsLabel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(136)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Chess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InitializeGame";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label settingsLabel;
        private System.Windows.Forms.Label timeLimitLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Player1;
        private System.Windows.Forms.TextBox Player2;
        private System.Windows.Forms.TextBox TimeLimit;
        private System.Windows.Forms.Label cross;
        private System.Windows.Forms.Label startGame;
        private System.Windows.Forms.Label historyLabel;
    }
}

