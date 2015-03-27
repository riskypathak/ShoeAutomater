
namespace JustCopIt.UserControls
{
    partial class SimulatorView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtNavigateUrl = new System.Windows.Forms.TextBox();
            this.webSimulatorMainTab = new System.Windows.Forms.WebBrowser();
            this.trackingTimer = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtNavigateUrl);
            this.panel1.Controls.Add(this.webSimulatorMainTab);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 328);
            this.panel1.TabIndex = 0;
            // 
            // txtNavigateUrl
            // 
            this.txtNavigateUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNavigateUrl.Location = new System.Drawing.Point(2, 8);
            this.txtNavigateUrl.Name = "txtNavigateUrl";
            this.txtNavigateUrl.Size = new System.Drawing.Size(628, 20);
            this.txtNavigateUrl.TabIndex = 1;
            // 
            // webSimulatorMainTab
            // 
            this.webSimulatorMainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webSimulatorMainTab.Location = new System.Drawing.Point(0, 34);
            this.webSimulatorMainTab.MinimumSize = new System.Drawing.Size(20, 20);
            this.webSimulatorMainTab.Name = "webSimulatorMainTab";
            this.webSimulatorMainTab.ScriptErrorsSuppressed = true;
            this.webSimulatorMainTab.Size = new System.Drawing.Size(632, 294);
            this.webSimulatorMainTab.TabIndex = 0;
            this.webSimulatorMainTab.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webSimulatorMainTab_DocumentCompleted);
            // 
            // trackingTimer
            // 
            this.trackingTimer.Interval = 3000;
            this.trackingTimer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // SimulatorView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "SimulatorView";
            this.Size = new System.Drawing.Size(632, 328);
            this.Load += new System.EventHandler(this.SimulatorView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.WebBrowser webSimulatorMainTab;
        private System.Windows.Forms.Timer trackingTimer;
        private System.Windows.Forms.TextBox txtNavigateUrl;
    }
}
