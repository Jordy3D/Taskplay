using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;

namespace Taskplay
{
    public partial class SettingsForm : Form
    {
        Microsoft.Win32.RegistryKey autorun;

        bool needToRestart = true;

        bool _isLightMode = Properties.Settings.Default.LightMode;

        public SettingsForm()
        {
            InitializeComponent();
            autorun = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);

            restartLabel.Visible = false;
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            checkBoxAutorun.Checked = (autorun.GetValue("Taskplay") != null);
            checkBoxLight.Checked = Properties.Settings.Default.LightMode;
            checkBoxHideSkipControls.Checked = Properties.Settings.Default.HideSkipControls;

            ApplyTheme();
        }

        void ApplyTheme()
        {
            this.BackColor = ColorTranslator.FromHtml(_isLightMode ? "#f0f0f0" : "#1f1f1f");
            this.ForeColor = ColorTranslator.FromHtml(_isLightMode ? "#000" : "#fff");

            foreach (Button but in flowLayoutPanel1.Controls)
            {
                but.BackColor = ColorTranslator.FromHtml(_isLightMode ? "#ffffff" : "#2e2e2e");
                but.ForeColor = ColorTranslator.FromHtml(_isLightMode ? "#000" : "#fff");
            }
        }


        private void SaveSettings()
        {
            if (checkBoxAutorun.Checked)
                autorun.SetValue("Taskplay", Application.ExecutablePath);
            else
                autorun.DeleteValue("Taskplay", false);

            Properties.Settings.Default.LightMode = checkBoxLight.Checked;
            Properties.Settings.Default.HideSkipControls = checkBoxHideSkipControls.Checked;

            Properties.Settings.Default.Save();

            if (needToRestart)
                Application.Restart();
        }

        #region Buttons
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveSettings();
            Close();
        }
        #endregion



        private void checkBoxLight_CheckedChanged(object sender, EventArgs e)
        {
            needToRestart = checkBoxLight.Checked != Properties.Settings.Default.LightMode;
            restartLabel.Visible = needToRestart;
        }

        private void checkBoxHideSkipControls_CheckedChanged(object sender, EventArgs e)
        {
            needToRestart = checkBoxHideSkipControls.Checked != Properties.Settings.Default.HideSkipControls;
            restartLabel.Visible = needToRestart;
        }
    }
}
