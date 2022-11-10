namespace Taskplay
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.aboutBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // aboutBox
            // 
            this.aboutBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.aboutBox.CausesValidation = false;
            this.aboutBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.aboutBox.ForeColor = System.Drawing.Color.Black;
            this.aboutBox.HideSelection = false;
            this.aboutBox.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.aboutBox.Location = new System.Drawing.Point(12, 12);
            this.aboutBox.Name = "aboutBox";
            this.aboutBox.ReadOnly = true;
            this.aboutBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.aboutBox.ShortcutsEnabled = false;
            this.aboutBox.Size = new System.Drawing.Size(309, 200);
            this.aboutBox.TabIndex = 26;
            this.aboutBox.Text = resources.GetString("aboutBox.Text");
            this.aboutBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.aboutBox_LinkClicked);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 168);
            this.Controls.Add(this.aboutBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutForm";
            this.Text = "Taskplay {0}";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox aboutBox;
    }
}