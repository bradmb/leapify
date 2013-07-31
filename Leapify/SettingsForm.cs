using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leapify
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private async void btnSaveSettings_Click(object sender, EventArgs e)
        {
            var settings = new Models.Settings
            {
                TimeBeforeNextAction = (int)timeBeforeNextAction.Value,
                TapToolsRequired = (int)tapToolsRequired.Value,
                TapFingersRequired = (int)tapFingersRequired.Value,
                SwipeToolsRequired = (int)swipeToolsRequired.Value,
                SwipeFingersRequired = (int)swipeFingersRequired.Value,
                SpeedRequired = (int)speedRequired.Value,
                DistanceRequired = (int)distanceRequired.Value
            };

            var settingsFile = new LeapifySettings();
            await settingsFile.Update(settings);

            this.Close();
        }

        private void distanceRequired_Scroll(object sender, EventArgs e)
        {
            lblDistanceValue.Text = string.Format("{0}", distanceRequired.Value);
        }

        private void speedRequired_Scroll(object sender, EventArgs e)
        {
            lblSpeedValue.Text = string.Format("{0}", speedRequired.Value);
        }

        private async void SettingsForm_Load(object sender, EventArgs e)
        {
            this.Icon = Images.leapify_active;

            var settingsFile = new LeapifySettings();
            var settings = await settingsFile.Read();

            timeBeforeNextAction.Value = settings.TimeBeforeNextAction;
            swipeFingersRequired.Value = settings.SwipeFingersRequired;
            swipeToolsRequired.Value = settings.SwipeToolsRequired;
            distanceRequired.Value = settings.DistanceRequired;
            speedRequired.Value = settings.SpeedRequired;
            tapToolsRequired.Value = settings.TapToolsRequired;
            tapFingersRequired.Value = settings.TapFingersRequired;
        }
    }
}
