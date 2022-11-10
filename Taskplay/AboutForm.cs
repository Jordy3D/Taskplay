using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Taskplay
{
    public partial class AboutForm : Form
    {
        bool _isLightMode = Properties.Settings.Default.LightMode;

        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            this.Text = String.Format("Taskplay {0}", Application.ProductVersion);
            _isLightMode = Properties.Settings.Default.LightMode;

            ApplyTheme();
        }

        void ApplyTheme()
        {
            this.BackColor = ColorTranslator.FromHtml(_isLightMode ? "#f0f0f0" : "#1f1f1f");
            this.ForeColor = ColorTranslator.FromHtml(_isLightMode ? "#000" : "#fff");

            aboutBox.BackColor = ColorTranslator.FromHtml(_isLightMode ? "#f0f0f0" : "#1f1f1f");
            aboutBox.ForeColor = ColorTranslator.FromHtml(_isLightMode ? "#000" : "#fff");
        }

        Process p = new Process();

        private void aboutBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            p = Process.Start(e.LinkText);
        }
    }
}
