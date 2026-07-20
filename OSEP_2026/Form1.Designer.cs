namespace OSEP_2026
{
    partial class Form1
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tpMsfVenom = new System.Windows.Forms.TabPage();
            this.txtMsvListener = new System.Windows.Forms.RichTextBox();
            this.txtMsvGenerator = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMsvGenerate = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.numMsvNopSled = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMsvFilename = new System.Windows.Forms.TextBox();
            this.cbMsvOutput = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbMsvEncryption = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numMsvEncIteration = new System.Windows.Forms.NumericUpDown();
            this.cbMsvEncoding = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbMsvFull = new System.Windows.Forms.RadioButton();
            this.rbMsvStaged = new System.Windows.Forms.RadioButton();
            this.cbMsvPayload = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbMsv86 = new System.Windows.Forms.RadioButton();
            this.rbMsv64 = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtLHOST = new System.Windows.Forms.TextBox();
            this.lbLHOST = new System.Windows.Forms.Label();
            this.gnEnviroment = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMsvCmd = new System.Windows.Forms.TextBox();
            this.lbPASS = new System.Windows.Forms.Label();
            this.txtPASS = new System.Windows.Forms.TextBox();
            this.lbUSER = new System.Windows.Forms.Label();
            this.txtUSER = new System.Windows.Forms.TextBox();
            this.lbRPORT = new System.Windows.Forms.Label();
            this.txtRPORT = new System.Windows.Forms.TextBox();
            this.lbLPORT = new System.Windows.Forms.Label();
            this.txtLPORT = new System.Windows.Forms.TextBox();
            this.lbRHOST = new System.Windows.Forms.Label();
            this.txtRHOST = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tpMsfVenom.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMsvNopSled)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMsvEncIteration)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.gnEnviroment.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Location = new System.Drawing.Point(0, 995);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1414, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1414, 33);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tpMsfVenom);
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Location = new System.Drawing.Point(12, 167);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(1390, 814);
            this.tcMain.TabIndex = 2;
            // 
            // tpMsfVenom
            // 
            this.tpMsfVenom.Controls.Add(this.txtMsvListener);
            this.tpMsfVenom.Controls.Add(this.txtMsvGenerator);
            this.tpMsfVenom.Controls.Add(this.label4);
            this.tpMsfVenom.Controls.Add(this.label3);
            this.tpMsfVenom.Controls.Add(this.btnMsvGenerate);
            this.tpMsfVenom.Controls.Add(this.groupBox6);
            this.tpMsfVenom.Controls.Add(this.groupBox5);
            this.tpMsfVenom.Controls.Add(this.groupBox4);
            this.tpMsfVenom.Controls.Add(this.groupBox3);
            this.tpMsfVenom.Controls.Add(this.groupBox2);
            this.tpMsfVenom.Controls.Add(this.groupBox1);
            this.tpMsfVenom.Location = new System.Drawing.Point(4, 29);
            this.tpMsfVenom.Name = "tpMsfVenom";
            this.tpMsfVenom.Padding = new System.Windows.Forms.Padding(3);
            this.tpMsfVenom.Size = new System.Drawing.Size(1382, 781);
            this.tpMsfVenom.TabIndex = 0;
            this.tpMsfVenom.Text = "msfvenom";
            this.tpMsfVenom.UseVisualStyleBackColor = true;
            // 
            // txtMsvListener
            // 
            this.txtMsvListener.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsvListener.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsvListener.Location = new System.Drawing.Point(18, 647);
            this.txtMsvListener.Name = "txtMsvListener";
            this.txtMsvListener.Size = new System.Drawing.Size(1325, 127);
            this.txtMsvListener.TabIndex = 12;
            this.txtMsvListener.Text = "";
            // 
            // txtMsvGenerator
            // 
            this.txtMsvGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsvGenerator.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsvGenerator.Location = new System.Drawing.Point(18, 463);
            this.txtMsvGenerator.Name = "txtMsvGenerator";
            this.txtMsvGenerator.Size = new System.Drawing.Size(1325, 127);
            this.txtMsvGenerator.TabIndex = 11;
            this.txtMsvGenerator.Text = "";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 611);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 29);
            this.label4.TabIndex = 10;
            this.label4.Text = "Listener";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 29);
            this.label3.TabIndex = 9;
            this.label3.Text = "Generator";
            // 
            // btnMsvGenerate
            // 
            this.btnMsvGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMsvGenerate.Location = new System.Drawing.Point(202, 273);
            this.btnMsvGenerate.Name = "btnMsvGenerate";
            this.btnMsvGenerate.Size = new System.Drawing.Size(900, 97);
            this.btnMsvGenerate.TabIndex = 8;
            this.btnMsvGenerate.Text = "Generate";
            this.btnMsvGenerate.UseVisualStyleBackColor = true;
            this.btnMsvGenerate.Click += new System.EventHandler(this.btnMsvGenerate_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.numMsvNopSled);
            this.groupBox6.Location = new System.Drawing.Point(1159, 22);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(205, 187);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "NOP Sled";
            // 
            // numMsvNopSled
            // 
            this.numMsvNopSled.Location = new System.Drawing.Point(6, 25);
            this.numMsvNopSled.Name = "numMsvNopSled";
            this.numMsvNopSled.Size = new System.Drawing.Size(193, 26);
            this.numMsvNopSled.TabIndex = 2;
            this.numMsvNopSled.ValueChanged += new System.EventHandler(this.numMsvNopSled_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtMsvFilename);
            this.groupBox5.Controls.Add(this.cbMsvOutput);
            this.groupBox5.Location = new System.Drawing.Point(526, 22);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(205, 187);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filename";
            // 
            // txtMsvFilename
            // 
            this.txtMsvFilename.Location = new System.Drawing.Point(6, 93);
            this.txtMsvFilename.Name = "txtMsvFilename";
            this.txtMsvFilename.Size = new System.Drawing.Size(175, 26);
            this.txtMsvFilename.TabIndex = 2;
            this.txtMsvFilename.TextChanged += new System.EventHandler(this.txtMsvFilename_TextChanged);
            // 
            // cbMsvOutput
            // 
            this.cbMsvOutput.FormattingEnabled = true;
            this.cbMsvOutput.Items.AddRange(new object[] {
            "--- Languages ---",
            "raw",
            "hex",
            "c",
            "csharp",
            "powershell",
            "python",
            "vbscript",
            "",
            "--- Binaries ---",
            "exe",
            "exe-service",
            "dll",
            "elf",
            "elf-so",
            "hta-psh",
            "jar",
            "war",
            "vbs",
            "psh-cmd",
            "psh-net",
            "psh-reflection"});
            this.cbMsvOutput.Location = new System.Drawing.Point(6, 25);
            this.cbMsvOutput.Name = "cbMsvOutput";
            this.cbMsvOutput.Size = new System.Drawing.Size(175, 28);
            this.cbMsvOutput.TabIndex = 1;
            this.cbMsvOutput.Text = "raw";
            this.cbMsvOutput.SelectedIndexChanged += new System.EventHandler(this.cbMsvOutput_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbMsvEncryption);
            this.groupBox4.Location = new System.Drawing.Point(948, 22);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(205, 187);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Encryption";
            // 
            // cbMsvEncryption
            // 
            this.cbMsvEncryption.FormattingEnabled = true;
            this.cbMsvEncryption.Items.AddRange(new object[] {
            "None",
            "aes256",
            "rc4"});
            this.cbMsvEncryption.Location = new System.Drawing.Point(6, 25);
            this.cbMsvEncryption.Name = "cbMsvEncryption";
            this.cbMsvEncryption.Size = new System.Drawing.Size(175, 28);
            this.cbMsvEncryption.TabIndex = 1;
            this.cbMsvEncryption.Text = "None";
            this.cbMsvEncryption.SelectedIndexChanged += new System.EventHandler(this.cbMsvEncryption_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.numMsvEncIteration);
            this.groupBox3.Controls.Add(this.cbMsvEncoding);
            this.groupBox3.Location = new System.Drawing.Point(737, 22);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(205, 187);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encoding";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Iterations";
            // 
            // numMsvEncIteration
            // 
            this.numMsvEncIteration.Location = new System.Drawing.Point(6, 93);
            this.numMsvEncIteration.Name = "numMsvEncIteration";
            this.numMsvEncIteration.Size = new System.Drawing.Size(175, 26);
            this.numMsvEncIteration.TabIndex = 2;
            this.numMsvEncIteration.ValueChanged += new System.EventHandler(this.numMsvEncIteration_ValueChanged);
            // 
            // cbMsvEncoding
            // 
            this.cbMsvEncoding.FormattingEnabled = true;
            this.cbMsvEncoding.Items.AddRange(new object[] {
            "None",
            "x64/xor",
            "x64/xor_dynamic",
            "x86/shikata_ga_nai"});
            this.cbMsvEncoding.Location = new System.Drawing.Point(6, 25);
            this.cbMsvEncoding.Name = "cbMsvEncoding";
            this.cbMsvEncoding.Size = new System.Drawing.Size(175, 28);
            this.cbMsvEncoding.TabIndex = 1;
            this.cbMsvEncoding.Text = "None";
            this.cbMsvEncoding.SelectedIndexChanged += new System.EventHandler(this.cbMsvEncoding_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbMsvFull);
            this.groupBox2.Controls.Add(this.rbMsvStaged);
            this.groupBox2.Controls.Add(this.cbMsvPayload);
            this.groupBox2.Location = new System.Drawing.Point(146, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 187);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payload";
            // 
            // rbMsvFull
            // 
            this.rbMsvFull.AutoSize = true;
            this.rbMsvFull.Location = new System.Drawing.Point(138, 68);
            this.rbMsvFull.Name = "rbMsvFull";
            this.rbMsvFull.Size = new System.Drawing.Size(59, 24);
            this.rbMsvFull.TabIndex = 2;
            this.rbMsvFull.Text = "Full";
            this.rbMsvFull.UseVisualStyleBackColor = true;
            this.rbMsvFull.CheckedChanged += new System.EventHandler(this.rbMsvFull_CheckedChanged);
            // 
            // rbMsvStaged
            // 
            this.rbMsvStaged.AutoSize = true;
            this.rbMsvStaged.Checked = true;
            this.rbMsvStaged.Location = new System.Drawing.Point(6, 70);
            this.rbMsvStaged.Name = "rbMsvStaged";
            this.rbMsvStaged.Size = new System.Drawing.Size(86, 24);
            this.rbMsvStaged.TabIndex = 1;
            this.rbMsvStaged.TabStop = true;
            this.rbMsvStaged.Text = "Staged";
            this.rbMsvStaged.UseVisualStyleBackColor = true;
            this.rbMsvStaged.CheckedChanged += new System.EventHandler(this.rbMsvStaged_CheckedChanged);
            // 
            // cbMsvPayload
            // 
            this.cbMsvPayload.FormattingEnabled = true;
            this.cbMsvPayload.Items.AddRange(new object[] {
            "windows/meterpreter/reverse_tcp",
            "windows/meterpreter/reverse_https",
            "windows/meterpreter/reverse_http",
            "windows/meterpreter/reverse_named_pipe",
            "windows/x64/shell/reverse_tcp",
            "windows/x64/shell/bind_tcp"});
            this.cbMsvPayload.Location = new System.Drawing.Point(6, 25);
            this.cbMsvPayload.Name = "cbMsvPayload";
            this.cbMsvPayload.Size = new System.Drawing.Size(358, 28);
            this.cbMsvPayload.TabIndex = 0;
            this.cbMsvPayload.Text = "windows/meterpreter/reverse_tcp";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbMsv86);
            this.groupBox1.Controls.Add(this.rbMsv64);
            this.groupBox1.Location = new System.Drawing.Point(18, 22);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(122, 187);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Architecture";
            // 
            // rbMsv86
            // 
            this.rbMsv86.AutoSize = true;
            this.rbMsv86.Location = new System.Drawing.Point(19, 78);
            this.rbMsv86.Name = "rbMsv86";
            this.rbMsv86.Size = new System.Drawing.Size(59, 24);
            this.rbMsv86.TabIndex = 1;
            this.rbMsv86.Text = "x86";
            this.rbMsv86.UseVisualStyleBackColor = true;
            this.rbMsv86.CheckedChanged += new System.EventHandler(this.rbMsv86_CheckedChanged);
            // 
            // rbMsv64
            // 
            this.rbMsv64.AutoSize = true;
            this.rbMsv64.Checked = true;
            this.rbMsv64.Location = new System.Drawing.Point(19, 38);
            this.rbMsv64.Name = "rbMsv64";
            this.rbMsv64.Size = new System.Drawing.Size(59, 24);
            this.rbMsv64.TabIndex = 0;
            this.rbMsv64.TabStop = true;
            this.rbMsv64.Text = "x64";
            this.rbMsv64.UseVisualStyleBackColor = true;
            this.rbMsv64.CheckedChanged += new System.EventHandler(this.rbMsv64_CheckedChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1382, 781);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtLHOST
            // 
            this.txtLHOST.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLHOST.Location = new System.Drawing.Point(86, 33);
            this.txtLHOST.Name = "txtLHOST";
            this.txtLHOST.Size = new System.Drawing.Size(154, 26);
            this.txtLHOST.TabIndex = 3;
            this.txtLHOST.Text = "tun0";
            this.txtLHOST.TextChanged += new System.EventHandler(this.txtLHOST_TextChanged);
            // 
            // lbLHOST
            // 
            this.lbLHOST.AutoSize = true;
            this.lbLHOST.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLHOST.Location = new System.Drawing.Point(18, 37);
            this.lbLHOST.Name = "lbLHOST";
            this.lbLHOST.Size = new System.Drawing.Size(63, 19);
            this.lbLHOST.TabIndex = 4;
            this.lbLHOST.Text = "LHOST:";
            // 
            // gnEnviroment
            // 
            this.gnEnviroment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gnEnviroment.Controls.Add(this.label5);
            this.gnEnviroment.Controls.Add(this.txtMsvCmd);
            this.gnEnviroment.Controls.Add(this.lbPASS);
            this.gnEnviroment.Controls.Add(this.txtPASS);
            this.gnEnviroment.Controls.Add(this.lbUSER);
            this.gnEnviroment.Controls.Add(this.txtUSER);
            this.gnEnviroment.Controls.Add(this.lbRPORT);
            this.gnEnviroment.Controls.Add(this.txtRPORT);
            this.gnEnviroment.Controls.Add(this.lbLPORT);
            this.gnEnviroment.Controls.Add(this.txtLPORT);
            this.gnEnviroment.Controls.Add(this.lbRHOST);
            this.gnEnviroment.Controls.Add(this.txtRHOST);
            this.gnEnviroment.Controls.Add(this.lbLHOST);
            this.gnEnviroment.Controls.Add(this.txtLHOST);
            this.gnEnviroment.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gnEnviroment.Location = new System.Drawing.Point(12, 36);
            this.gnEnviroment.Name = "gnEnviroment";
            this.gnEnviroment.Size = new System.Drawing.Size(1386, 125);
            this.gnEnviroment.TabIndex = 5;
            this.gnEnviroment.TabStop = false;
            this.gnEnviroment.Text = "Environment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(560, 84);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 19);
            this.label5.TabIndex = 16;
            this.label5.Text = "Command:";
            // 
            // txtMsvCmd
            // 
            this.txtMsvCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsvCmd.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsvCmd.Location = new System.Drawing.Point(647, 80);
            this.txtMsvCmd.Name = "txtMsvCmd";
            this.txtMsvCmd.Size = new System.Drawing.Size(721, 26);
            this.txtMsvCmd.TabIndex = 15;
            this.txtMsvCmd.Text = "whoami";
            this.txtMsvCmd.TextChanged += new System.EventHandler(this.txtMsvCmd_TextChanged);
            // 
            // lbPASS
            // 
            this.lbPASS.AutoSize = true;
            this.lbPASS.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPASS.Location = new System.Drawing.Point(284, 80);
            this.lbPASS.Name = "lbPASS";
            this.lbPASS.Size = new System.Drawing.Size(54, 19);
            this.lbPASS.TabIndex = 14;
            this.lbPASS.Text = "Pass:";
            // 
            // txtPASS
            // 
            this.txtPASS.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPASS.Location = new System.Drawing.Point(352, 76);
            this.txtPASS.Name = "txtPASS";
            this.txtPASS.PasswordChar = '*';
            this.txtPASS.Size = new System.Drawing.Size(154, 26);
            this.txtPASS.TabIndex = 13;
            this.txtPASS.Text = "lab";
            this.txtPASS.WordWrap = false;
            this.txtPASS.TextChanged += new System.EventHandler(this.txtPASS_TextChanged);
            // 
            // lbUSER
            // 
            this.lbUSER.AutoSize = true;
            this.lbUSER.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUSER.Location = new System.Drawing.Point(18, 80);
            this.lbUSER.Name = "lbUSER";
            this.lbUSER.Size = new System.Drawing.Size(54, 19);
            this.lbUSER.TabIndex = 12;
            this.lbUSER.Text = "User:";
            // 
            // txtUSER
            // 
            this.txtUSER.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUSER.Location = new System.Drawing.Point(86, 76);
            this.txtUSER.Name = "txtUSER";
            this.txtUSER.Size = new System.Drawing.Size(154, 26);
            this.txtUSER.TabIndex = 11;
            this.txtUSER.Text = "offsec";
            this.txtUSER.TextChanged += new System.EventHandler(this.txtUSER_TextChanged);
            // 
            // lbRPORT
            // 
            this.lbRPORT.AutoSize = true;
            this.lbRPORT.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRPORT.Location = new System.Drawing.Point(841, 31);
            this.lbRPORT.Name = "lbRPORT";
            this.lbRPORT.Size = new System.Drawing.Size(63, 19);
            this.lbRPORT.TabIndex = 10;
            this.lbRPORT.Text = "RPORT:";
            // 
            // txtRPORT
            // 
            this.txtRPORT.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRPORT.Location = new System.Drawing.Point(909, 27);
            this.txtRPORT.Name = "txtRPORT";
            this.txtRPORT.Size = new System.Drawing.Size(154, 26);
            this.txtRPORT.TabIndex = 9;
            this.txtRPORT.Text = "80";
            this.txtRPORT.TextChanged += new System.EventHandler(this.txtRPORT_TextChanged);
            // 
            // lbLPORT
            // 
            this.lbLPORT.AutoSize = true;
            this.lbLPORT.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLPORT.Location = new System.Drawing.Point(560, 33);
            this.lbLPORT.Name = "lbLPORT";
            this.lbLPORT.Size = new System.Drawing.Size(63, 19);
            this.lbLPORT.TabIndex = 8;
            this.lbLPORT.Text = "LPORT:";
            // 
            // txtLPORT
            // 
            this.txtLPORT.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLPORT.Location = new System.Drawing.Point(628, 29);
            this.txtLPORT.Name = "txtLPORT";
            this.txtLPORT.Size = new System.Drawing.Size(154, 26);
            this.txtLPORT.TabIndex = 7;
            this.txtLPORT.Text = "4444";
            this.txtLPORT.TextChanged += new System.EventHandler(this.txtLPORT_TextChanged);
            // 
            // lbRHOST
            // 
            this.lbRHOST.AutoSize = true;
            this.lbRHOST.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRHOST.Location = new System.Drawing.Point(284, 35);
            this.lbRHOST.Name = "lbRHOST";
            this.lbRHOST.Size = new System.Drawing.Size(63, 19);
            this.lbRHOST.TabIndex = 6;
            this.lbRHOST.Text = "RHOST:";
            // 
            // txtRHOST
            // 
            this.txtRHOST.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRHOST.Location = new System.Drawing.Point(352, 31);
            this.txtRHOST.Name = "txtRHOST";
            this.txtRHOST.Size = new System.Drawing.Size(154, 26);
            this.txtRHOST.TabIndex = 5;
            this.txtRHOST.Text = "192.168.0.10";
            this.txtRHOST.TextChanged += new System.EventHandler(this.txtRHOST_TextChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 1017);
            this.Controls.Add(this.gnEnviroment);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1436, 1073);
            this.Name = "Form1";
            this.Text = "OSEP 2026";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tpMsfVenom.ResumeLayout(false);
            this.tpMsfVenom.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numMsvNopSled)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMsvEncIteration)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gnEnviroment.ResumeLayout(false);
            this.gnEnviroment.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.TabControl tcMain;
        private System.Windows.Forms.TabPage tpMsfVenom;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtLHOST;
        private System.Windows.Forms.Label lbLHOST;
        private System.Windows.Forms.GroupBox gnEnviroment;
        private System.Windows.Forms.Label lbLPORT;
        private System.Windows.Forms.TextBox txtLPORT;
        private System.Windows.Forms.Label lbRHOST;
        private System.Windows.Forms.TextBox txtRHOST;
        private System.Windows.Forms.Label lbPASS;
        private System.Windows.Forms.TextBox txtPASS;
        private System.Windows.Forms.Label lbUSER;
        private System.Windows.Forms.TextBox txtUSER;
        private System.Windows.Forms.Label lbRPORT;
        private System.Windows.Forms.TextBox txtRPORT;
        private System.Windows.Forms.ComboBox cbMsvPayload;
        private System.Windows.Forms.ComboBox cbMsvEncoding;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numMsvEncIteration;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbMsv86;
        private System.Windows.Forms.RadioButton rbMsv64;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbMsvEncryption;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMsvFilename;
        private System.Windows.Forms.ComboBox cbMsvOutput;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.NumericUpDown numMsvNopSled;
        private System.Windows.Forms.RichTextBox txtMsvListener;
        private System.Windows.Forms.RichTextBox txtMsvGenerator;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMsvGenerate;
        private System.Windows.Forms.RadioButton rbMsvFull;
        private System.Windows.Forms.RadioButton rbMsvStaged;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMsvCmd;
    }
}

