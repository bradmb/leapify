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
            this.lblLeapFingers = new System.Windows.Forms.Label();
            this.lblLeapFingersValue = new System.Windows.Forms.Label();
            this.lblLeapTools = new System.Windows.Forms.Label();
            this.lblLeapToolsValue = new System.Windows.Forms.Label();
            this.lblLeapRequiredFingers = new System.Windows.Forms.Label();
            this.txtRequiredFingersSwipe = new System.Windows.Forms.TextBox();
            this.lblLeapMinSpeed = new System.Windows.Forms.Label();
            this.txtMinSpeed = new System.Windows.Forms.TextBox();
            this.lblLeapMinDistance = new System.Windows.Forms.Label();
            this.txtMinDistance = new System.Windows.Forms.TextBox();
            this.lblLeapRequiredTools = new System.Windows.Forms.Label();
            this.txtRequiredToolsSwipe = new System.Windows.Forms.TextBox();
            this.lblTimeBetween = new System.Windows.Forms.Label();
            this.txtTimeBetween = new System.Windows.Forms.TextBox();
            this.lblRequiredFingersTap = new System.Windows.Forms.Label();
            this.txtRequiredFingersTap = new System.Windows.Forms.TextBox();
            this.lblRequiredToolsTap = new System.Windows.Forms.Label();
            this.txtRequiredToolsTap = new System.Windows.Forms.TextBox();
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
            this.txtLeapMessages.Size = new System.Drawing.Size(556, 296);
            this.txtLeapMessages.TabIndex = 1;
            // 
            // spotifyCheck
            // 
            this.spotifyCheck.Interval = 1000;
            this.spotifyCheck.Tick += new System.EventHandler(this.spotifyCheck_Tick);
            // 
            // leapMotionCheck
            // 
            this.leapMotionCheck.Interval = 1000;
            this.leapMotionCheck.Tick += new System.EventHandler(this.leapMotionCheck_Tick);
            // 
            // lblLeapFingers
            // 
            this.lblLeapFingers.AutoSize = true;
            this.lblLeapFingers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeapFingers.Location = new System.Drawing.Point(219, 35);
            this.lblLeapFingers.Name = "lblLeapFingers";
            this.lblLeapFingers.Size = new System.Drawing.Size(101, 13);
            this.lblLeapFingers.TabIndex = 0;
            this.lblLeapFingers.Text = "Fingers In Frame";
            // 
            // lblLeapFingersValue
            // 
            this.lblLeapFingersValue.AutoSize = true;
            this.lblLeapFingersValue.Location = new System.Drawing.Point(338, 35);
            this.lblLeapFingersValue.Name = "lblLeapFingersValue";
            this.lblLeapFingersValue.Size = new System.Drawing.Size(13, 13);
            this.lblLeapFingersValue.TabIndex = 0;
            this.lblLeapFingersValue.Text = "0";
            // 
            // lblLeapTools
            // 
            this.lblLeapTools.AutoSize = true;
            this.lblLeapTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeapTools.Location = new System.Drawing.Point(219, 9);
            this.lblLeapTools.Name = "lblLeapTools";
            this.lblLeapTools.Size = new System.Drawing.Size(91, 13);
            this.lblLeapTools.TabIndex = 0;
            this.lblLeapTools.Text = "Tools In Frame";
            // 
            // lblLeapToolsValue
            // 
            this.lblLeapToolsValue.AutoSize = true;
            this.lblLeapToolsValue.Location = new System.Drawing.Point(338, 9);
            this.lblLeapToolsValue.Name = "lblLeapToolsValue";
            this.lblLeapToolsValue.Size = new System.Drawing.Size(13, 13);
            this.lblLeapToolsValue.TabIndex = 0;
            this.lblLeapToolsValue.Text = "0";
            // 
            // lblLeapRequiredFingers
            // 
            this.lblLeapRequiredFingers.AutoSize = true;
            this.lblLeapRequiredFingers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeapRequiredFingers.Location = new System.Drawing.Point(15, 398);
            this.lblLeapRequiredFingers.Name = "lblLeapRequiredFingers";
            this.lblLeapRequiredFingers.Size = new System.Drawing.Size(149, 13);
            this.lblLeapRequiredFingers.TabIndex = 2;
            this.lblLeapRequiredFingers.Text = "Required Fingers (Swipe)";
            // 
            // txtRequiredFingersSwipe
            // 
            this.txtRequiredFingersSwipe.Location = new System.Drawing.Point(179, 395);
            this.txtRequiredFingersSwipe.Name = "txtRequiredFingersSwipe";
            this.txtRequiredFingersSwipe.Size = new System.Drawing.Size(100, 20);
            this.txtRequiredFingersSwipe.TabIndex = 3;
            this.txtRequiredFingersSwipe.Text = "1";
            this.txtRequiredFingersSwipe.TextChanged += new System.EventHandler(this.txtRequiredFingers_TextChanged);
            // 
            // lblLeapMinSpeed
            // 
            this.lblLeapMinSpeed.AutoSize = true;
            this.lblLeapMinSpeed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeapMinSpeed.Location = new System.Drawing.Point(15, 468);
            this.lblLeapMinSpeed.Name = "lblLeapMinSpeed";
            this.lblLeapMinSpeed.Size = new System.Drawing.Size(95, 13);
            this.lblLeapMinSpeed.TabIndex = 2;
            this.lblLeapMinSpeed.Text = "Minimum Speed";
            // 
            // txtMinSpeed
            // 
            this.txtMinSpeed.Location = new System.Drawing.Point(179, 465);
            this.txtMinSpeed.Name = "txtMinSpeed";
            this.txtMinSpeed.Size = new System.Drawing.Size(100, 20);
            this.txtMinSpeed.TabIndex = 3;
            this.txtMinSpeed.Text = "100";
            this.txtMinSpeed.TextChanged += new System.EventHandler(this.txtMinSpeed_TextChanged);
            // 
            // lblLeapMinDistance
            // 
            this.lblLeapMinDistance.AutoSize = true;
            this.lblLeapMinDistance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeapMinDistance.Location = new System.Drawing.Point(299, 468);
            this.lblLeapMinDistance.Name = "lblLeapMinDistance";
            this.lblLeapMinDistance.Size = new System.Drawing.Size(109, 13);
            this.lblLeapMinDistance.TabIndex = 2;
            this.lblLeapMinDistance.Text = "Minimum Distance";
            // 
            // txtMinDistance
            // 
            this.txtMinDistance.Location = new System.Drawing.Point(463, 465);
            this.txtMinDistance.Name = "txtMinDistance";
            this.txtMinDistance.Size = new System.Drawing.Size(100, 20);
            this.txtMinDistance.TabIndex = 3;
            this.txtMinDistance.Text = "100";
            this.txtMinDistance.TextChanged += new System.EventHandler(this.txtMinDistance_TextChanged);
            // 
            // lblLeapRequiredTools
            // 
            this.lblLeapRequiredTools.AutoSize = true;
            this.lblLeapRequiredTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeapRequiredTools.Location = new System.Drawing.Point(299, 398);
            this.lblLeapRequiredTools.Name = "lblLeapRequiredTools";
            this.lblLeapRequiredTools.Size = new System.Drawing.Size(139, 13);
            this.lblLeapRequiredTools.TabIndex = 2;
            this.lblLeapRequiredTools.Text = "Required Tools (Swipe)";
            // 
            // txtRequiredToolsSwipe
            // 
            this.txtRequiredToolsSwipe.Location = new System.Drawing.Point(463, 395);
            this.txtRequiredToolsSwipe.Name = "txtRequiredToolsSwipe";
            this.txtRequiredToolsSwipe.Size = new System.Drawing.Size(100, 20);
            this.txtRequiredToolsSwipe.TabIndex = 3;
            this.txtRequiredToolsSwipe.Text = "0";
            this.txtRequiredToolsSwipe.TextChanged += new System.EventHandler(this.txtRequiredTools_TextChanged);
            // 
            // lblTimeBetween
            // 
            this.lblTimeBetween.AutoSize = true;
            this.lblTimeBetween.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeBetween.Location = new System.Drawing.Point(15, 504);
            this.lblTimeBetween.Name = "lblTimeBetween";
            this.lblTimeBetween.Size = new System.Drawing.Size(133, 13);
            this.lblTimeBetween.TabIndex = 2;
            this.lblTimeBetween.Text = "Time Between Actions";
            // 
            // txtTimeBetween
            // 
            this.txtTimeBetween.Location = new System.Drawing.Point(179, 501);
            this.txtTimeBetween.Name = "txtTimeBetween";
            this.txtTimeBetween.Size = new System.Drawing.Size(100, 20);
            this.txtTimeBetween.TabIndex = 3;
            this.txtTimeBetween.Text = "500";
            this.txtTimeBetween.TextChanged += new System.EventHandler(this.txtTimeBetween_TextChanged);
            // 
            // lblRequiredFingersTap
            // 
            this.lblRequiredFingersTap.AutoSize = true;
            this.lblRequiredFingersTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequiredFingersTap.Location = new System.Drawing.Point(15, 433);
            this.lblRequiredFingersTap.Name = "lblRequiredFingersTap";
            this.lblRequiredFingersTap.Size = new System.Drawing.Size(137, 13);
            this.lblRequiredFingersTap.TabIndex = 2;
            this.lblRequiredFingersTap.Text = "Required Fingers (Tap)";
            // 
            // txtRequiredFingersTap
            // 
            this.txtRequiredFingersTap.Location = new System.Drawing.Point(179, 430);
            this.txtRequiredFingersTap.Name = "txtRequiredFingersTap";
            this.txtRequiredFingersTap.Size = new System.Drawing.Size(100, 20);
            this.txtRequiredFingersTap.TabIndex = 3;
            this.txtRequiredFingersTap.Text = "1";
            this.txtRequiredFingersTap.TextChanged += new System.EventHandler(this.txtRequiredFingersTap_TextChanged);
            // 
            // lblRequiredToolsTap
            // 
            this.lblRequiredToolsTap.AutoSize = true;
            this.lblRequiredToolsTap.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequiredToolsTap.Location = new System.Drawing.Point(299, 433);
            this.lblRequiredToolsTap.Name = "lblRequiredToolsTap";
            this.lblRequiredToolsTap.Size = new System.Drawing.Size(127, 13);
            this.lblRequiredToolsTap.TabIndex = 2;
            this.lblRequiredToolsTap.Text = "Required Tools (Tap)";
            // 
            // txtRequiredToolsTap
            // 
            this.txtRequiredToolsTap.Location = new System.Drawing.Point(463, 430);
            this.txtRequiredToolsTap.Name = "txtRequiredToolsTap";
            this.txtRequiredToolsTap.Size = new System.Drawing.Size(100, 20);
            this.txtRequiredToolsTap.TabIndex = 3;
            this.txtRequiredToolsTap.Text = "0";
            this.txtRequiredToolsTap.TextChanged += new System.EventHandler(this.txtRequiredToolsTap_TextChanged);
            // 
            // DebugWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(583, 548);
            this.Controls.Add(this.txtMinDistance);
            this.Controls.Add(this.lblLeapMinDistance);
            this.Controls.Add(this.txtTimeBetween);
            this.Controls.Add(this.lblTimeBetween);
            this.Controls.Add(this.txtMinSpeed);
            this.Controls.Add(this.lblLeapMinSpeed);
            this.Controls.Add(this.txtRequiredToolsTap);
            this.Controls.Add(this.lblRequiredToolsTap);
            this.Controls.Add(this.txtRequiredToolsSwipe);
            this.Controls.Add(this.txtRequiredFingersTap);
            this.Controls.Add(this.lblLeapRequiredTools);
            this.Controls.Add(this.lblRequiredFingersTap);
            this.Controls.Add(this.txtRequiredFingersSwipe);
            this.Controls.Add(this.lblLeapRequiredFingers);
            this.Controls.Add(this.txtLeapMessages);
            this.Controls.Add(this.lblLeapToolsValue);
            this.Controls.Add(this.lblLeapFingersValue);
            this.Controls.Add(this.lblLeapStatus);
            this.Controls.Add(this.lblSpotifyStatus);
            this.Controls.Add(this.lblLeapTools);
            this.Controls.Add(this.lblLeapFingers);
            this.Controls.Add(this.lblLeapMessages);
            this.Controls.Add(this.lblLeap);
            this.Controls.Add(this.lblSpotify);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "DebugWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Debug Window";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DebugWindow_FormClosing);
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
        private System.Windows.Forms.Label lblLeapFingers;
        private System.Windows.Forms.Label lblLeapFingersValue;
        private System.Windows.Forms.Label lblLeapTools;
        private System.Windows.Forms.Label lblLeapToolsValue;
        private System.Windows.Forms.Label lblLeapRequiredFingers;
        private System.Windows.Forms.TextBox txtRequiredFingersSwipe;
        private System.Windows.Forms.Label lblLeapMinSpeed;
        private System.Windows.Forms.TextBox txtMinSpeed;
        private System.Windows.Forms.Label lblLeapMinDistance;
        private System.Windows.Forms.TextBox txtMinDistance;
        private System.Windows.Forms.Label lblLeapRequiredTools;
        private System.Windows.Forms.TextBox txtRequiredToolsSwipe;
        private System.Windows.Forms.Label lblTimeBetween;
        private System.Windows.Forms.TextBox txtTimeBetween;
        private System.Windows.Forms.Label lblRequiredFingersTap;
        private System.Windows.Forms.TextBox txtRequiredFingersTap;
        private System.Windows.Forms.Label lblRequiredToolsTap;
        private System.Windows.Forms.TextBox txtRequiredToolsTap;
    }
}

