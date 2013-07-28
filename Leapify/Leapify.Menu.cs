using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Leapify
{
    /// <summary>
    /// Thanks to Mark Merrens for the great information on a formless tray icon.
    /// I hardly deal with WinForms in my day job, so it helped out a lot.
    /// http://www.codeproject.com/Articles/290013/Formless-System-Tray-Application
    /// </summary>
    internal class Menu
    {
        internal ContextMenuStrip Render()
        {
            var menu = new ContextMenuStrip();

            // Spotify Running Status
            var spotify = new ToolStripMenuItem();
            spotify.Enabled = false;
            spotify.Name = "spotify";
            spotify.Text = "Spotify: Not Running";
            menu.Items.Add(spotify);

            // Leap Motion Connection Status
            var leap = new ToolStripMenuItem();
            leap.Enabled = false;
            leap.Name = "leapmotion";
            leap.Text = "Leap Motion: Disconnected";
            menu.Items.Add(leap);

            menu.Items.Add(new ToolStripSeparator());

            // Setup Menu
            var setup = new ToolStripMenuItem();
            setup.Text = "Configure";
            setup.Click += setup_Click;
            menu.Items.Add(setup);

            menu.Items.Add(new ToolStripSeparator());

            // Debug Menu
            #if DEBUG
            var debug = new ToolStripMenuItem();
            debug.Name = "debugwindow";
            debug.Text = "Debug";
            menu.Items.Add(debug);
            #endif

            // Exit
            var exit = new ToolStripMenuItem();
            exit.Text = "Exit";
            exit.Click += exit_Click;
            menu.Items.Add(exit);

            return menu;
        }

        void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        void setup_Click(object sender, EventArgs e)
        {

        }
    }
}
