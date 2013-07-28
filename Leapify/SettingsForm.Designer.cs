namespace Leapify
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.swipeFingersRequired = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.swipeToolsRequired = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.distanceRequired = new System.Windows.Forms.TrackBar();
            this.speedRequired = new System.Windows.Forms.TrackBar();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tapFingersRequired = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.tapToolsRequired = new System.Windows.Forms.NumericUpDown();
            this.lblDistanceValue = new System.Windows.Forms.Label();
            this.lblSpeedValue = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label9 = new System.Windows.Forms.Label();
            this.timeBeforeNextAction = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.swipeFingersRequired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swipeToolsRequired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceRequired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedRequired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tapFingersRequired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tapToolsRequired)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBeforeNextAction)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Swipe Settings";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Fingers Required";
            // 
            // swipeFingersRequired
            // 
            this.swipeFingersRequired.Location = new System.Drawing.Point(109, 38);
            this.swipeFingersRequired.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.swipeFingersRequired.Name = "swipeFingersRequired";
            this.swipeFingersRequired.Size = new System.Drawing.Size(50, 20);
            this.swipeFingersRequired.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Tools Required";
            // 
            // swipeToolsRequired
            // 
            this.swipeToolsRequired.Location = new System.Drawing.Point(109, 64);
            this.swipeToolsRequired.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.swipeToolsRequired.Name = "swipeToolsRequired";
            this.swipeToolsRequired.Size = new System.Drawing.Size(50, 20);
            this.swipeToolsRequired.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(197, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Distance Required";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 85);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Speed Required";
            // 
            // distanceRequired
            // 
            this.distanceRequired.LargeChange = 500;
            this.distanceRequired.Location = new System.Drawing.Point(299, 34);
            this.distanceRequired.Maximum = 1000;
            this.distanceRequired.Minimum = 100;
            this.distanceRequired.Name = "distanceRequired";
            this.distanceRequired.Size = new System.Drawing.Size(104, 45);
            this.distanceRequired.SmallChange = 100;
            this.distanceRequired.TabIndex = 3;
            this.distanceRequired.TickFrequency = 100;
            this.distanceRequired.Value = 100;
            this.distanceRequired.Scroll += new System.EventHandler(this.distanceRequired_Scroll);
            // 
            // speedRequired
            // 
            this.speedRequired.LargeChange = 500;
            this.speedRequired.Location = new System.Drawing.Point(299, 76);
            this.speedRequired.Maximum = 2000;
            this.speedRequired.Minimum = 100;
            this.speedRequired.Name = "speedRequired";
            this.speedRequired.Size = new System.Drawing.Size(104, 45);
            this.speedRequired.SmallChange = 100;
            this.speedRequired.TabIndex = 3;
            this.speedRequired.TickFrequency = 100;
            this.speedRequired.Value = 100;
            this.speedRequired.Scroll += new System.EventHandler(this.speedRequired_Scroll);
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(384, 241);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(88, 23);
            this.btnSaveSettings.TabIndex = 4;
            this.btnSaveSettings.Text = "Save && Close";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(13, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Tap Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 162);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Fingers Required";
            // 
            // tapFingersRequired
            // 
            this.tapFingersRequired.Location = new System.Drawing.Point(110, 160);
            this.tapFingersRequired.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tapFingersRequired.Name = "tapFingersRequired";
            this.tapFingersRequired.Size = new System.Drawing.Size(50, 20);
            this.tapFingersRequired.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 188);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Tools Required";
            // 
            // tapToolsRequired
            // 
            this.tapToolsRequired.Location = new System.Drawing.Point(110, 186);
            this.tapToolsRequired.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.tapToolsRequired.Name = "tapToolsRequired";
            this.tapToolsRequired.Size = new System.Drawing.Size(50, 20);
            this.tapToolsRequired.TabIndex = 2;
            // 
            // lblDistanceValue
            // 
            this.lblDistanceValue.AutoSize = true;
            this.lblDistanceValue.Location = new System.Drawing.Point(410, 37);
            this.lblDistanceValue.Name = "lblDistanceValue";
            this.lblDistanceValue.Size = new System.Drawing.Size(25, 13);
            this.lblDistanceValue.TabIndex = 5;
            this.lblDistanceValue.Text = "100";
            // 
            // lblSpeedValue
            // 
            this.lblSpeedValue.AutoSize = true;
            this.lblSpeedValue.Location = new System.Drawing.Point(410, 76);
            this.lblSpeedValue.Name = "lblSpeedValue";
            this.lblSpeedValue.Size = new System.Drawing.Size(25, 13);
            this.lblSpeedValue.TabIndex = 5;
            this.lblSpeedValue.Text = "100";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(484, 276);
            this.shapeContainer1.TabIndex = 6;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.Color.Silver;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 22;
            this.lineShape1.X2 = 468;
            this.lineShape1.Y1 = 121;
            this.lineShape1.Y2 = 121;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(228, 160);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 13);
            this.label9.TabIndex = 7;
            this.label9.Text = "Time Before Next Action";
            // 
            // timeBeforeNextAction
            // 
            this.timeBeforeNextAction.Location = new System.Drawing.Point(231, 179);
            this.timeBeforeNextAction.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.timeBeforeNextAction.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.timeBeforeNextAction.Name = "timeBeforeNextAction";
            this.timeBeforeNextAction.Size = new System.Drawing.Size(62, 20);
            this.timeBeforeNextAction.TabIndex = 8;
            this.timeBeforeNextAction.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(299, 181);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(63, 13);
            this.label10.TabIndex = 9;
            this.label10.Text = "milliseconds";
            // 
            // lineShape2
            // 
            this.lineShape2.BorderColor = System.Drawing.Color.Silver;
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 216;
            this.lineShape2.X2 = 216;
            this.lineShape2.Y1 = 139;
            this.lineShape2.Y2 = 260;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(228, 135);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(93, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Global Settings";
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 276);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.timeBeforeNextAction);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lblSpeedValue);
            this.Controls.Add(this.lblDistanceValue);
            this.Controls.Add(this.btnSaveSettings);
            this.Controls.Add(this.speedRequired);
            this.Controls.Add(this.distanceRequired);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tapToolsRequired);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.swipeToolsRequired);
            this.Controls.Add(this.tapFingersRequired);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.swipeFingersRequired);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.shapeContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Leapify Settings";
            this.Load += new System.EventHandler(this.SettingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.swipeFingersRequired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swipeToolsRequired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distanceRequired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedRequired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tapFingersRequired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tapToolsRequired)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeBeforeNextAction)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown swipeFingersRequired;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown swipeToolsRequired;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar distanceRequired;
        private System.Windows.Forms.TrackBar speedRequired;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown tapFingersRequired;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown tapToolsRequired;
        private System.Windows.Forms.Label lblDistanceValue;
        private System.Windows.Forms.Label lblSpeedValue;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown timeBeforeNextAction;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}