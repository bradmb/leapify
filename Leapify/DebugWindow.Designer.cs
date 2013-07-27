namespace Leapify
{
    partial class DebugWindow
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
            this.lblSpotify = new System.Windows.Forms.Label();
            this.lblSpotifyStatus = new System.Windows.Forms.Label();
            this.lblLeap = new System.Windows.Forms.Label();
            this.lblLeapStatus = new System.Windows.Forms.Label();
            this.lblLeapMessages = new System.Windows.Forms.Label();
            this.txtLeapMessages = new System.Windows.Forms.TextBox();
            this.spotifyCheck = new System.Windows.Forms.Timer(this.components);
            this.leapMotionCheck = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // lblSpotify
            // 
            this.lblSpotify.AutoSize = true;
            this.lblSpotify.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpotify.Location = new System.Drawing.Point(12, 9);
            this.lblSpotify.Name = "lblSpotify";
            this.lblSpotify.Size = new System.Drawing.Size(46, 13);
            this.lblSpotify.TabIndex = 0;
            this.lblSpotify.Text = "Spotify";
            // 
            // lblSpotifyStatus
            // 
            this.lblSpotifyStatus.AutoSize = true;
            this.lblSpotifyStatus.Location = new System.Drawing.Point(107, 9);
            this.lblSpotifyStatus.Name = "lblSpotifyStatus";
            this.lblSpotifyStatus.Size = new System.Drawing.Size(67, 13);
            this.lblSpotifyStatus.TabIndex = 0;
            this.lblSpotifyStatus.Text = "Not Running";
            // 
            // lblLeap
            // 
            this.lblLeap.AutoSize = true;
            this.lblLeap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeap.Location = new System.Drawing.Point(12, 35);
            this.lblLeap.Name = "lblLeap";
            this.lblLeap.Size = new System.Drawing.Size(77, 13);
            this.lblLeap.TabIndex = 0;
            this.lblLeap.Text = "Leap Motion";
            // 
            // lblLeapStatus
            // 
            this.lblLeapStatus.AutoSize = true;
            this.lblLeapStatus.Location = new System.Drawing.Point(107, 35);
            this.lblLeapStatus.Name = "lblLeapStatus";
            this.lblLeapStatus.Size = new System.Drawing.Size(73, 13);
            this.lblLeapStatus.TabIndex = 0;
            this.lblLeapStatus.Text = "Disconnected";
            // 
            // lblLeapMessages
            // 
            this.lblLeapMessages.AutoSize = true;
            this.lblLeapMessages.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeapMessages.Location = new System.Drawing.Point(12, 64);
            this.lblLeapMessages.Name = "lblLeapMessages";
            this.lblLeapMessages.Size = new System.Drawing.Size(137, 13);
            this.lblLeapMessages.TabIndex = 0;
            this.lblLeapMessages.Text = "Leap Motion Messages";
            // 
            // txtLeapMessages
            // 
            this.txtLeapMessages.Location = new System.Drawing.Point(15, 81);
            this.txtLeapMessages.Multiline = true;
            this.txtLeapMessages.Name = "txtLeapMessages";
            this.txtLeapMessages.Size = new System.Drawing.Size(257, 168);
            this.txtLeapMessages.TabIndex = 1;
            // 
            // spotifyCheck
            // 
            this.spotifyCheck.Tick += new System.EventHandler(this.spotifyCheck_Tick);
            // 
            // leapMotionCheck
            // 
            this.leapMotionCheck.Tick += new System.EventHandler(this.leapMotionCheck_Tick);
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.txtLeapMessages);
            this.Controls.Add(this.lblLeapStatus);
            this.Controls.Add(this.lblSpotifyStatus);
            this.Controls.Add(this.lblLeapMessages);
            this.Controls.Add(this.lblLeap);
            this.Controls.Add(this.lblSpotify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DebugWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Debug Window";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSpotify;
        private System.Windows.Forms.Label lblSpotifyStatus;
        private System.Windows.Forms.Label lblLeap;
        private System.Windows.Forms.Label lblLeapStatus;
        private System.Windows.Forms.Label lblLeapMessages;
        private System.Windows.Forms.TextBox txtLeapMessages;
        private System.Windows.Forms.Timer spotifyCheck;
        private System.Windows.Forms.Timer leapMotionCheck;
    }
}

