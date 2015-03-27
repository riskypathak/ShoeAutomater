namespace JustCopIt.UserControls
{
    partial class CartView
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
            this.spiderSimulator = new JustCopIt.UserControls.SimulatorView();
            this.SuspendLayout();
            // 
            // spiderSimulator
            // 
            this.spiderSimulator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spiderSimulator.Location = new System.Drawing.Point(0, 0);
            this.spiderSimulator.Name = "spiderSimulator";
            this.spiderSimulator.Size = new System.Drawing.Size(728, 440);
            this.spiderSimulator.TabIndex = 2;
            // 
            // CartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.spiderSimulator);
            this.Name = "CartView";
            this.Size = new System.Drawing.Size(728, 440);
            this.ResumeLayout(false);

        }

        #endregion

        private SimulatorView spiderSimulator;
    }
}
