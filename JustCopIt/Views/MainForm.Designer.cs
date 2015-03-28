namespace JustCopIt.Views
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControlSpider = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnFootLockerViewCart = new System.Windows.Forms.Button();
            this.btnFootactionViewCart = new System.Windows.Forms.Button();
            this.btnEastbayViewCart = new System.Windows.Forms.Button();
            this.btnChampViewCart = new System.Windows.Forms.Button();
            this.cboFootLockerSize = new System.Windows.Forms.ComboBox();
            this.cboFootactionSize = new System.Windows.Forms.ComboBox();
            this.cboEastbaySize = new System.Windows.Forms.ComboBox();
            this.cboChampSize = new System.Windows.Forms.ComboBox();
            this.txtFootLockerUrl = new System.Windows.Forms.TextBox();
            this.txtFootactionUrl = new System.Windows.Forms.TextBox();
            this.txtEastbayUrl = new System.Windows.Forms.TextBox();
            this.txtChampUrl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblFootLocker = new System.Windows.Forms.Label();
            this.lblFootaction = new System.Windows.Forms.Label();
            this.lblEastbay = new System.Windows.Forms.Label();
            this.lblChamp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lblVersion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tabChampsSports = new System.Windows.Forms.TabPage();
            this.tabEastbay = new System.Windows.Forms.TabPage();
            this.tabFootaction = new System.Windows.Forms.TabPage();
            this.tabFootLocker = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.timerProcess = new System.Windows.Forms.Timer(this.components);
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panelLog = new System.Windows.Forms.Panel();
            this.rtxtLog = new System.Windows.Forms.RichTextBox();
            this.cartViewChampsSports = new JustCopIt.UserControls.CartView();
            this.cartViewEastbay = new JustCopIt.UserControls.CartView();
            this.cartViewFootaction = new JustCopIt.UserControls.CartView();
            this.cartViewFootLocker = new JustCopIt.UserControls.CartView();
            this.tabControlSpider.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tabChampsSports.SuspendLayout();
            this.tabEastbay.SuspendLayout();
            this.tabFootaction.SuspendLayout();
            this.tabFootLocker.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panelLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlSpider
            // 
            this.tabControlSpider.Controls.Add(this.tabMain);
            this.tabControlSpider.Controls.Add(this.tabChampsSports);
            this.tabControlSpider.Controls.Add(this.tabEastbay);
            this.tabControlSpider.Controls.Add(this.tabFootaction);
            this.tabControlSpider.Controls.Add(this.tabFootLocker);
            this.tabControlSpider.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSpider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlSpider.Location = new System.Drawing.Point(0, 0);
            this.tabControlSpider.Name = "tabControlSpider";
            this.tabControlSpider.SelectedIndex = 0;
            this.tabControlSpider.Size = new System.Drawing.Size(884, 561);
            this.tabControlSpider.TabIndex = 0;
            this.tabControlSpider.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControlSpider_Selecting);
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.panel4);
            this.tabMain.Location = new System.Drawing.Point(4, 22);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(876, 535);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.panelLog);
            this.panel4.Controls.Add(this.progressBar);
            this.panel4.Controls.Add(this.panel3);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.panel6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(870, 529);
            this.panel4.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClearLog);
            this.panel3.Controls.Add(this.btnStop);
            this.panel3.Controls.Add(this.btnExit);
            this.panel3.Controls.Add(this.btnStart);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 211);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(870, 40);
            this.panel3.TabIndex = 7;
            // 
            // btnClearLog
            // 
            this.btnClearLog.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClearLog.Location = new System.Drawing.Point(415, 8);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(80, 23);
            this.btnClearLog.TabIndex = 2;
            this.btnClearLog.Text = "Reset";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStop.Location = new System.Drawing.Point(315, 8);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(80, 23);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnExit.Location = new System.Drawing.Point(515, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(80, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStart.Location = new System.Drawing.Point(215, 8);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(80, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnFootLockerViewCart);
            this.panel2.Controls.Add(this.btnFootactionViewCart);
            this.panel2.Controls.Add(this.btnEastbayViewCart);
            this.panel2.Controls.Add(this.btnChampViewCart);
            this.panel2.Controls.Add(this.cboFootLockerSize);
            this.panel2.Controls.Add(this.cboFootactionSize);
            this.panel2.Controls.Add(this.cboEastbaySize);
            this.panel2.Controls.Add(this.cboChampSize);
            this.panel2.Controls.Add(this.txtFootLockerUrl);
            this.panel2.Controls.Add(this.txtFootactionUrl);
            this.panel2.Controls.Add(this.txtEastbayUrl);
            this.panel2.Controls.Add(this.txtChampUrl);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.lblFootLocker);
            this.panel2.Controls.Add(this.lblFootaction);
            this.panel2.Controls.Add(this.lblEastbay);
            this.panel2.Controls.Add(this.lblChamp);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 72);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(870, 139);
            this.panel2.TabIndex = 6;
            // 
            // btnFootLockerViewCart
            // 
            this.btnFootLockerViewCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFootLockerViewCart.Enabled = false;
            this.btnFootLockerViewCart.Location = new System.Drawing.Point(783, 108);
            this.btnFootLockerViewCart.Name = "btnFootLockerViewCart";
            this.btnFootLockerViewCart.Size = new System.Drawing.Size(80, 23);
            this.btnFootLockerViewCart.TabIndex = 11;
            this.btnFootLockerViewCart.Text = "View Cart";
            this.btnFootLockerViewCart.UseVisualStyleBackColor = true;
            this.btnFootLockerViewCart.Click += new System.EventHandler(this.btnFootLockerViewCart_Click);
            // 
            // btnFootactionViewCart
            // 
            this.btnFootactionViewCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFootactionViewCart.Enabled = false;
            this.btnFootactionViewCart.Location = new System.Drawing.Point(783, 76);
            this.btnFootactionViewCart.Name = "btnFootactionViewCart";
            this.btnFootactionViewCart.Size = new System.Drawing.Size(80, 23);
            this.btnFootactionViewCart.TabIndex = 8;
            this.btnFootactionViewCart.Text = "View Cart";
            this.btnFootactionViewCart.UseVisualStyleBackColor = true;
            this.btnFootactionViewCart.Click += new System.EventHandler(this.btnFootactionViewCart_Click);
            // 
            // btnEastbayViewCart
            // 
            this.btnEastbayViewCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEastbayViewCart.Enabled = false;
            this.btnEastbayViewCart.Location = new System.Drawing.Point(783, 44);
            this.btnEastbayViewCart.Name = "btnEastbayViewCart";
            this.btnEastbayViewCart.Size = new System.Drawing.Size(80, 23);
            this.btnEastbayViewCart.TabIndex = 5;
            this.btnEastbayViewCart.Text = "View Cart";
            this.btnEastbayViewCart.UseVisualStyleBackColor = true;
            this.btnEastbayViewCart.Click += new System.EventHandler(this.btnEastbayViewCart_Click);
            // 
            // btnChampViewCart
            // 
            this.btnChampViewCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnChampViewCart.Enabled = false;
            this.btnChampViewCart.Location = new System.Drawing.Point(783, 12);
            this.btnChampViewCart.Name = "btnChampViewCart";
            this.btnChampViewCart.Size = new System.Drawing.Size(80, 23);
            this.btnChampViewCart.TabIndex = 2;
            this.btnChampViewCart.Text = "View Cart";
            this.btnChampViewCart.UseVisualStyleBackColor = true;
            this.btnChampViewCart.Click += new System.EventHandler(this.btnChampViewCart_Click);
            // 
            // cboFootLockerSize
            // 
            this.cboFootLockerSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFootLockerSize.FormattingEnabled = true;
            this.cboFootLockerSize.Location = new System.Drawing.Point(704, 108);
            this.cboFootLockerSize.Name = "cboFootLockerSize";
            this.cboFootLockerSize.Size = new System.Drawing.Size(60, 21);
            this.cboFootLockerSize.TabIndex = 10;
            // 
            // cboFootactionSize
            // 
            this.cboFootactionSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboFootactionSize.FormattingEnabled = true;
            this.cboFootactionSize.Location = new System.Drawing.Point(704, 76);
            this.cboFootactionSize.Name = "cboFootactionSize";
            this.cboFootactionSize.Size = new System.Drawing.Size(60, 21);
            this.cboFootactionSize.TabIndex = 7;
            // 
            // cboEastbaySize
            // 
            this.cboEastbaySize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboEastbaySize.FormattingEnabled = true;
            this.cboEastbaySize.Location = new System.Drawing.Point(704, 44);
            this.cboEastbaySize.Name = "cboEastbaySize";
            this.cboEastbaySize.Size = new System.Drawing.Size(60, 21);
            this.cboEastbaySize.TabIndex = 4;
            // 
            // cboChampSize
            // 
            this.cboChampSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboChampSize.FormattingEnabled = true;
            this.cboChampSize.Location = new System.Drawing.Point(704, 12);
            this.cboChampSize.Name = "cboChampSize";
            this.cboChampSize.Size = new System.Drawing.Size(60, 21);
            this.cboChampSize.TabIndex = 1;
            // 
            // txtFootLockerUrl
            // 
            this.txtFootLockerUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFootLockerUrl.Location = new System.Drawing.Point(120, 108);
            this.txtFootLockerUrl.Name = "txtFootLockerUrl";
            this.txtFootLockerUrl.Size = new System.Drawing.Size(530, 20);
            this.txtFootLockerUrl.TabIndex = 9;
            this.txtFootLockerUrl.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // txtFootactionUrl
            // 
            this.txtFootactionUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFootactionUrl.Location = new System.Drawing.Point(120, 76);
            this.txtFootactionUrl.Name = "txtFootactionUrl";
            this.txtFootactionUrl.Size = new System.Drawing.Size(530, 20);
            this.txtFootactionUrl.TabIndex = 6;
            this.txtFootactionUrl.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // txtEastbayUrl
            // 
            this.txtEastbayUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEastbayUrl.Location = new System.Drawing.Point(120, 44);
            this.txtEastbayUrl.Name = "txtEastbayUrl";
            this.txtEastbayUrl.Size = new System.Drawing.Size(530, 20);
            this.txtEastbayUrl.TabIndex = 3;
            this.txtEastbayUrl.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // txtChampUrl
            // 
            this.txtChampUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtChampUrl.Location = new System.Drawing.Point(120, 12);
            this.txtChampUrl.Name = "txtChampUrl";
            this.txtChampUrl.Size = new System.Drawing.Size(530, 20);
            this.txtChampUrl.TabIndex = 0;
            this.txtChampUrl.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Foot Locker";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Footaction";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Eastbay";
            // 
            // lblFootLocker
            // 
            this.lblFootLocker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFootLocker.AutoSize = true;
            this.lblFootLocker.Location = new System.Drawing.Point(668, 112);
            this.lblFootLocker.Name = "lblFootLocker";
            this.lblFootLocker.Size = new System.Drawing.Size(25, 13);
            this.lblFootLocker.TabIndex = 0;
            this.lblFootLocker.Text = "size";
            // 
            // lblFootaction
            // 
            this.lblFootaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFootaction.AutoSize = true;
            this.lblFootaction.Location = new System.Drawing.Point(668, 80);
            this.lblFootaction.Name = "lblFootaction";
            this.lblFootaction.Size = new System.Drawing.Size(25, 13);
            this.lblFootaction.TabIndex = 0;
            this.lblFootaction.Text = "size";
            // 
            // lblEastbay
            // 
            this.lblEastbay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEastbay.AutoSize = true;
            this.lblEastbay.Location = new System.Drawing.Point(668, 48);
            this.lblEastbay.Name = "lblEastbay";
            this.lblEastbay.Size = new System.Drawing.Size(25, 13);
            this.lblEastbay.TabIndex = 0;
            this.lblEastbay.Text = "size";
            // 
            // lblChamp
            // 
            this.lblChamp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblChamp.AutoSize = true;
            this.lblChamp.Location = new System.Drawing.Point(668, 16);
            this.lblChamp.Name = "lblChamp";
            this.lblChamp.Size = new System.Drawing.Size(25, 13);
            this.lblChamp.TabIndex = 0;
            this.lblChamp.Text = "size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Champs Sports";
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.lblVersion);
            this.panel6.Controls.Add(this.pictureBox1);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel6.Location = new System.Drawing.Point(0, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(870, 72);
            this.panel6.TabIndex = 0;
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.Location = new System.Drawing.Point(800, 0);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(63, 13);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version: 2.0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::JustCopIt.Properties.Resources.banner;
            this.pictureBox1.Location = new System.Drawing.Point(0, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(870, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // tabChampsSports
            // 
            this.tabChampsSports.Controls.Add(this.cartViewChampsSports);
            this.tabChampsSports.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabChampsSports.Location = new System.Drawing.Point(4, 22);
            this.tabChampsSports.Name = "tabChampsSports";
            this.tabChampsSports.Padding = new System.Windows.Forms.Padding(3);
            this.tabChampsSports.Size = new System.Drawing.Size(876, 535);
            this.tabChampsSports.TabIndex = 1;
            this.tabChampsSports.Text = "Champs Sports";
            this.tabChampsSports.UseVisualStyleBackColor = true;
            // 
            // tabEastbay
            // 
            this.tabEastbay.Controls.Add(this.cartViewEastbay);
            this.tabEastbay.Location = new System.Drawing.Point(4, 22);
            this.tabEastbay.Name = "tabEastbay";
            this.tabEastbay.Padding = new System.Windows.Forms.Padding(3);
            this.tabEastbay.Size = new System.Drawing.Size(876, 535);
            this.tabEastbay.TabIndex = 2;
            this.tabEastbay.Text = "Eastbay";
            this.tabEastbay.UseVisualStyleBackColor = true;
            // 
            // tabFootaction
            // 
            this.tabFootaction.Controls.Add(this.cartViewFootaction);
            this.tabFootaction.Location = new System.Drawing.Point(4, 22);
            this.tabFootaction.Name = "tabFootaction";
            this.tabFootaction.Padding = new System.Windows.Forms.Padding(3);
            this.tabFootaction.Size = new System.Drawing.Size(876, 535);
            this.tabFootaction.TabIndex = 3;
            this.tabFootaction.Text = "Footaction";
            this.tabFootaction.UseVisualStyleBackColor = true;
            // 
            // tabFootLocker
            // 
            this.tabFootLocker.Controls.Add(this.panel5);
            this.tabFootLocker.Location = new System.Drawing.Point(4, 22);
            this.tabFootLocker.Name = "tabFootLocker";
            this.tabFootLocker.Padding = new System.Windows.Forms.Padding(3);
            this.tabFootLocker.Size = new System.Drawing.Size(876, 535);
            this.tabFootLocker.TabIndex = 4;
            this.tabFootLocker.Text = "Foot Locker";
            this.tabFootLocker.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.cartViewFootLocker);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(870, 529);
            this.panel5.TabIndex = 0;
            // 
            // timerProcess
            // 
            this.timerProcess.Interval = 1000;
            this.timerProcess.Tick += new System.EventHandler(this.TimerProcess_Tick);
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 509);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(870, 20);
            this.progressBar.TabIndex = 9;
            // 
            // panelLog
            // 
            this.panelLog.Controls.Add(this.rtxtLog);
            this.panelLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLog.Location = new System.Drawing.Point(0, 251);
            this.panelLog.Name = "panelLog";
            this.panelLog.Size = new System.Drawing.Size(870, 258);
            this.panelLog.TabIndex = 10;
            // 
            // rtxtLog
            // 
            this.rtxtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtLog.Location = new System.Drawing.Point(0, 0);
            this.rtxtLog.Name = "rtxtLog";
            this.rtxtLog.Size = new System.Drawing.Size(870, 258);
            this.rtxtLog.TabIndex = 2;
            this.rtxtLog.Text = "";
            // 
            // cartViewChampsSports
            // 
            this.cartViewChampsSports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartViewChampsSports.Location = new System.Drawing.Point(3, 3);
            this.cartViewChampsSports.Name = "cartViewChampsSports";
            this.cartViewChampsSports.Size = new System.Drawing.Size(870, 529);
            this.cartViewChampsSports.SpiderLogging = null;
            this.cartViewChampsSports.TabIndex = 0;
            // 
            // cartViewEastbay
            // 
            this.cartViewEastbay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartViewEastbay.Location = new System.Drawing.Point(3, 3);
            this.cartViewEastbay.Name = "cartViewEastbay";
            this.cartViewEastbay.Size = new System.Drawing.Size(870, 529);
            this.cartViewEastbay.SpiderLogging = null;
            this.cartViewEastbay.TabIndex = 0;
            // 
            // cartViewFootaction
            // 
            this.cartViewFootaction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartViewFootaction.Location = new System.Drawing.Point(3, 3);
            this.cartViewFootaction.Name = "cartViewFootaction";
            this.cartViewFootaction.Size = new System.Drawing.Size(870, 529);
            this.cartViewFootaction.SpiderLogging = null;
            this.cartViewFootaction.TabIndex = 0;
            // 
            // cartViewFootLocker
            // 
            this.cartViewFootLocker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cartViewFootLocker.Location = new System.Drawing.Point(0, 0);
            this.cartViewFootLocker.Name = "cartViewFootLocker";
            this.cartViewFootLocker.Size = new System.Drawing.Size(870, 529);
            this.cartViewFootLocker.SpiderLogging = null;
            this.cartViewFootLocker.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.tabControlSpider);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JustCopIt 4 in 1 Bot";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControlSpider.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tabChampsSports.ResumeLayout(false);
            this.tabEastbay.ResumeLayout(false);
            this.tabFootaction.ResumeLayout(false);
            this.tabFootLocker.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panelLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlSpider;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabChampsSports;
        private System.Windows.Forms.TabPage tabEastbay;
        private System.Windows.Forms.TabPage tabFootaction;
        private System.Windows.Forms.TabPage tabFootLocker;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private UserControls.CartView cartViewFootLocker;
        private UserControls.CartView cartViewChampsSports;
        private UserControls.CartView cartViewEastbay;
        private UserControls.CartView cartViewFootaction;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFootLockerViewCart;
        private System.Windows.Forms.Button btnFootactionViewCart;
        private System.Windows.Forms.Button btnEastbayViewCart;
        private System.Windows.Forms.Button btnChampViewCart;
        private System.Windows.Forms.ComboBox cboFootLockerSize;
        private System.Windows.Forms.ComboBox cboFootactionSize;
        private System.Windows.Forms.ComboBox cboEastbaySize;
        private System.Windows.Forms.ComboBox cboChampSize;
        private System.Windows.Forms.TextBox txtFootLockerUrl;
        private System.Windows.Forms.TextBox txtFootactionUrl;
        private System.Windows.Forms.TextBox txtEastbayUrl;
        private System.Windows.Forms.TextBox txtChampUrl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblFootLocker;
        private System.Windows.Forms.Label lblFootaction;
        private System.Windows.Forms.Label lblEastbay;
        private System.Windows.Forms.Label lblChamp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerProcess;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Panel panelLog;
        private System.Windows.Forms.RichTextBox rtxtLog;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

