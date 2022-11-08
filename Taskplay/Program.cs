using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Taskplay
{
    static class Program
    {
        static bool _isMusicPlaying = false;    // Bool to keep in check if the user is playing music
        static bool _isLightMode = true;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            _isLightMode = Properties.Settings.Default.LightMode;

            //Create system tray icons
            NotifyIcon previousIcon = new NotifyIcon();
            NotifyIcon playIcon = new NotifyIcon();
            NotifyIcon nextIcon = new NotifyIcon();
            //Create the context menu and its items
            ContextMenu contextMenu = new ContextMenu();
            MenuItem contextItemSettings = new MenuItem();
            MenuItem contextItemExit = new MenuItem();

            //Setup the context menu items
            contextItemSettings.Text = "&Settings";
            contextItemExit.Text = "&Exit";
            contextItemSettings.Click += new EventHandler(contextMenuSettings_Click);
            contextItemExit.Click += new EventHandler(contextMenuExit_Click);
            //Add the context menu items to the context menu
            contextMenu.MenuItems.Add(contextItemSettings);
            contextMenu.MenuItems.Add(contextItemExit);
            //Setup nextIcon
            nextIcon.Icon = _isLightMode ? Properties.Resources.Next_B : Properties.Resources.Next_W;
            nextIcon.Text = "Next";
            nextIcon.Visible = true;
            nextIcon.MouseClick += new MouseEventHandler(nextIcon_MouseClick);
            nextIcon.ContextMenu = contextMenu;
            //Setup playIcon
            playIcon.Icon = _isLightMode ? Properties.Resources.Play_B : Properties.Resources.Play_W;
            playIcon.Text = "Play / Pause";
            playIcon.Visible = true;
            playIcon.MouseClick += new MouseEventHandler(playIcon_MouseClick);
            playIcon.ContextMenu = contextMenu;
            //Setup previousIcon
            previousIcon.Icon = _isLightMode ? Properties.Resources.Back_B : Properties.Resources.Back_W;
            previousIcon.Text = "Previous";
            previousIcon.Visible = true;
            previousIcon.MouseClick += new MouseEventHandler(previousIcon_MouseClick);
            previousIcon.ContextMenu = contextMenu;

            //Launch
            Application.Run();
        }

        #region Media Buttons
        private static void previousIcon_MouseClick(object sender, MouseEventArgs e)
        {
            //Send Media Key Previous Track
            if (e.Button == MouseButtons.Left)
            {
                keybd_event(0xB1, 0, 0x0001, IntPtr.Zero);
                keybd_event(0xB1, 0, 0x0002, IntPtr.Zero);
            }
        }

        private static void playIcon_MouseClick(object sender, MouseEventArgs e)
        {
            //Send Media Key Play
            if (e.Button == MouseButtons.Left)
            {
                keybd_event(0xB3, 0, 0x0001, IntPtr.Zero);
                keybd_event(0xB3, 0, 0x0002, IntPtr.Zero);

                // Get the Play-button
                var playIcon = (NotifyIcon)sender;

                if (_isMusicPlaying == false)
                {
                    // Start playing music and show the pause-icon
                    playIcon.Icon = _isLightMode ? Properties.Resources.Pause_B : Properties.Resources.Pause_W;
                    _isMusicPlaying = true;
                }
                else
                {
                    // Pause the music and display the Play-icon
                    playIcon.Icon = _isLightMode ? Properties.Resources.Play_B : Properties.Resources.Play_W;
                    _isMusicPlaying = false;
                }
            }

            if (e.Button == MouseButtons.Middle)
            {
                VolumeChanger.Mute();
            }


            // PLEASE NOTE; this method does NOT check whether the music has been paused by an external source.
            //  This could be added by building in an check that listens to the state of the systems MusicPlayer
            //   I hope this gives a nice base to start with. :)
        }
        private static void playIcon_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 1)
                VolumeChanger.VolumeUp();
            if (e.Delta < 1)
                VolumeChanger.VolumeDown();
        }

        private static void nextIcon_MouseClick(object sender, MouseEventArgs e)
        {
            //Send Media Key Next Track
            if (e.Button == MouseButtons.Left)
            {
                keybd_event(0xB0, 0, 0x0001, IntPtr.Zero);
                keybd_event(0xB0, 0, 0x0002, IntPtr.Zero);
            }
        } 
        #endregion

        #region Context Menu
        private static void contextMenuSettings_Click(object sender, System.EventArgs e)
        {
            //Show Settings form
            new SettingsForm().ShowDialog();
        }

        private static void contextMenuExit_Click(object sender, System.EventArgs e)
        {
            //Exit the app
            Application.Exit();
        } 
        #endregion

        [DllImport("user32.dll", SetLastError = true)]
        public static extern void keybd_event(byte virtualKey, byte scanCode, uint flags, IntPtr extraInfo);
    }


    /// <summary>
    /// Sourced from https://stackoverflow.com/a/38746023. Edited by Bane to fit needs.
    /// </summary>
    class VolumeChanger
    {
        private const byte VK_VOLUME_MUTE = 0xAD;
        private const byte VK_VOLUME_DOWN = 0xAE;
        private const byte VK_VOLUME_UP = 0xAF;
        private const UInt32 KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const UInt32 KEYEVENTF_KEYUP = 0x0002;

        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, UInt32 dwFlags, UInt32 dwExtraInfo);

        [DllImport("user32.dll")]
        static extern Byte MapVirtualKey(UInt32 uCode, UInt32 uMapType);

        public static void VolumeUp()
        {
            keybd_event(VK_VOLUME_UP, MapVirtualKey(VK_VOLUME_UP, 0), KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(VK_VOLUME_UP, MapVirtualKey(VK_VOLUME_UP, 0), KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        public static void VolumeDown()
        {
            keybd_event(VK_VOLUME_DOWN, MapVirtualKey(VK_VOLUME_DOWN, 0), KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(VK_VOLUME_DOWN, MapVirtualKey(VK_VOLUME_DOWN, 0), KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }

        public static void Mute()
        {
            keybd_event(VK_VOLUME_MUTE, MapVirtualKey(VK_VOLUME_MUTE, 0), KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(VK_VOLUME_MUTE, MapVirtualKey(VK_VOLUME_MUTE, 0), KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
    }
}
