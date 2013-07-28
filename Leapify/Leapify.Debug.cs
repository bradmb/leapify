#if DEBUG
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leapify
{
    public partial class Leapify
    {
        private void BindDebugWindow()
        {
            var debug = _tray.ContextMenuStrip.Items.Find("debugwindow", false).FirstOrDefault();

            if (debug == null)
            {
                return;
            }

            debug.Click += debug_Click;
        }

        void debug_Click(object sender, EventArgs e)
        {
            this.Stop();

            var debug = new DebugWindow();
            debug.Show();
        }
    }
}
#endif