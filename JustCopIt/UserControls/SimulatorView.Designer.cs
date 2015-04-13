
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
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
            this.txtNavigateUrl.Location = new System.Drawing.Point(99, 8);
            this.txtNavigateUrl.Name = "txtNavigateUrl";
            this.txtNavigateUrl.Size = new System.Drawing.Size(529, 20);
            this.txtNavigateUrl.TabIndex = 1;
            // 
            // webSimulatorMainTab
            // 
            this.webSimulatorMainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webSimulatorMainTab.Location = new System.Drawing.Point(0, 36);
            this.webSimulatorMainTab.MinimumSize = new System.Drawing.Size(20, 20);
            this.webSimulatorMainTab.Name = "webSimulatorMainTab";
            this.webSimulatorMainTab.ScriptErrorsSuppressed = true;
            this.webSimulatorMainTab.Size = new System.Drawing.Size(632, 294);
            this.webSimulatorMainTab.TabIndex = 0;
            this.webSimulatorMainTab.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webSimulatorMainTab_DocumentCompleted);
            // 
            // trackingTimer
            // 
            this.trackingTimer.Interval = 2000;
            this.trackingTimer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // button1
            // 
            this.button1.Image = global::JustCopIt.Properties.Resources.refresh;
            this.button1.Location = new System.Drawing.Point(65, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(30, 30);
            this.button1.TabIndex = 4;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // button2
            // 
            this.button2.Image = global::JustCopIt.Properties.Resources.back;
            this.button2.Location = new System.Drawing.Point(3, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(30, 30);
            this.button2.TabIndex = 5;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // button3
            // 
            this.button3.Image = global::JustCopIt.Properties.Resources.forward;
            this.button3.Location = new System.Drawing.Point(34, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(30, 30);
            this.button3.TabIndex = 5;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnForward_Click);
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
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}
