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
            this.sbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.sbLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.tpProxyDLL = new System.Windows.Forms.TabPage();
            this.txtProxyPath = new System.Windows.Forms.TextBox();
            this.btnProxyLoad = new System.Windows.Forms.Button();
            this.txtProxyOut = new System.Windows.Forms.RichTextBox();
            this.tpExportScan = new System.Windows.Forms.TabPage();
            this.btn_Export_Scanner_chdir = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Export_Scanner_Dir = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Export_Scanner_Search_Term = new System.Windows.Forms.TextBox();
            this.txt_Export_Scanner_Out = new System.Windows.Forms.RichTextBox();
            this.btn_Export_Scanner_Search = new System.Windows.Forms.Button();
            this.tpCustomEncoder = new System.Windows.Forms.TabPage();
            this.btnCSE_Encode = new System.Windows.Forms.Button();
            this.txtCSE_out = new System.Windows.Forms.RichTextBox();
            this.tpVSO = new System.Windows.Forms.TabPage();
            this.txtVSO_out = new System.Windows.Forms.RichTextBox();
            this.btnVSO_Obfuscate = new System.Windows.Forms.Button();
            this.txtVSO_In = new System.Windows.Forms.RichTextBox();
            this.tpEncodeAssembly = new System.Windows.Forms.TabPage();
            this.txtEA_out = new System.Windows.Forms.RichTextBox();
            this.btnEA_Encode = new System.Windows.Forms.Button();
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
            this.btnCSE_Decode = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
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
            this.tpProxyDLL.SuspendLayout();
            this.tpExportScan.SuspendLayout();
            this.tpCustomEncoder.SuspendLayout();
            this.tpVSO.SuspendLayout();
            this.tpEncodeAssembly.SuspendLayout();
            this.gnEnviroment.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sbProgress,
            this.sbLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 649);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip1.Size = new System.Drawing.Size(947, 23);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sbProgress
            // 
            this.sbProgress.Name = "sbProgress";
            this.sbProgress.Size = new System.Drawing.Size(67, 17);
            // 
            // sbLabel1
            // 
            this.sbLabel1.Name = "sbLabel1";
            this.sbLabel1.Size = new System.Drawing.Size(118, 18);
            this.sbLabel1.Text = "toolStripStatusLabel1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(947, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // tcMain
            // 
            this.tcMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tcMain.Controls.Add(this.tpMsfVenom);
            this.tcMain.Controls.Add(this.tpProxyDLL);
            this.tcMain.Controls.Add(this.tpExportScan);
            this.tcMain.Controls.Add(this.tpCustomEncoder);
            this.tcMain.Controls.Add(this.tpVSO);
            this.tcMain.Controls.Add(this.tpEncodeAssembly);
            this.tcMain.Location = new System.Drawing.Point(8, 109);
            this.tcMain.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(927, 529);
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
            this.tpMsfVenom.Location = new System.Drawing.Point(4, 22);
            this.tpMsfVenom.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpMsfVenom.Name = "tpMsfVenom";
            this.tpMsfVenom.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpMsfVenom.Size = new System.Drawing.Size(919, 503);
            this.tpMsfVenom.TabIndex = 0;
            this.tpMsfVenom.Text = "    msfvenom    ";
            this.tpMsfVenom.UseVisualStyleBackColor = true;
            // 
            // txtMsvListener
            // 
            this.txtMsvListener.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsvListener.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsvListener.Location = new System.Drawing.Point(12, 421);
            this.txtMsvListener.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMsvListener.Name = "txtMsvListener";
            this.txtMsvListener.Size = new System.Drawing.Size(885, 84);
            this.txtMsvListener.TabIndex = 12;
            this.txtMsvListener.Text = "";
            // 
            // txtMsvGenerator
            // 
            this.txtMsvGenerator.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsvGenerator.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsvGenerator.Location = new System.Drawing.Point(12, 301);
            this.txtMsvGenerator.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMsvGenerator.Name = "txtMsvGenerator";
            this.txtMsvGenerator.Size = new System.Drawing.Size(885, 84);
            this.txtMsvGenerator.TabIndex = 11;
            this.txtMsvGenerator.Text = "";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 397);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Listener";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 278);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Generator";
            // 
            // btnMsvGenerate
            // 
            this.btnMsvGenerate.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMsvGenerate.Location = new System.Drawing.Point(135, 177);
            this.btnMsvGenerate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnMsvGenerate.Name = "btnMsvGenerate";
            this.btnMsvGenerate.Size = new System.Drawing.Size(600, 63);
            this.btnMsvGenerate.TabIndex = 8;
            this.btnMsvGenerate.Text = "Generate";
            this.btnMsvGenerate.UseVisualStyleBackColor = true;
            this.btnMsvGenerate.Click += new System.EventHandler(this.btnMsvGenerate_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.numMsvNopSled);
            this.groupBox6.Location = new System.Drawing.Point(773, 14);
            this.groupBox6.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox6.Size = new System.Drawing.Size(137, 122);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "NOP Sled";
            // 
            // numMsvNopSled
            // 
            this.numMsvNopSled.Location = new System.Drawing.Point(4, 16);
            this.numMsvNopSled.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numMsvNopSled.Name = "numMsvNopSled";
            this.numMsvNopSled.Size = new System.Drawing.Size(129, 20);
            this.numMsvNopSled.TabIndex = 2;
            this.numMsvNopSled.ValueChanged += new System.EventHandler(this.numMsvNopSled_ValueChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Controls.Add(this.txtMsvFilename);
            this.groupBox5.Controls.Add(this.cbMsvOutput);
            this.groupBox5.Location = new System.Drawing.Point(351, 14);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox5.Size = new System.Drawing.Size(137, 122);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Output";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Filename";
            // 
            // txtMsvFilename
            // 
            this.txtMsvFilename.Location = new System.Drawing.Point(4, 60);
            this.txtMsvFilename.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMsvFilename.Name = "txtMsvFilename";
            this.txtMsvFilename.Size = new System.Drawing.Size(118, 20);
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
            this.cbMsvOutput.Location = new System.Drawing.Point(4, 16);
            this.cbMsvOutput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbMsvOutput.Name = "cbMsvOutput";
            this.cbMsvOutput.Size = new System.Drawing.Size(118, 21);
            this.cbMsvOutput.TabIndex = 1;
            this.cbMsvOutput.Text = "raw";
            this.cbMsvOutput.SelectedIndexChanged += new System.EventHandler(this.cbMsvOutput_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbMsvEncryption);
            this.groupBox4.Location = new System.Drawing.Point(632, 14);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox4.Size = new System.Drawing.Size(137, 122);
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
            this.cbMsvEncryption.Location = new System.Drawing.Point(4, 16);
            this.cbMsvEncryption.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbMsvEncryption.Name = "cbMsvEncryption";
            this.cbMsvEncryption.Size = new System.Drawing.Size(118, 21);
            this.cbMsvEncryption.TabIndex = 1;
            this.cbMsvEncryption.Text = "None";
            this.cbMsvEncryption.SelectedIndexChanged += new System.EventHandler(this.cbMsvEncryption_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.numMsvEncIteration);
            this.groupBox3.Controls.Add(this.cbMsvEncoding);
            this.groupBox3.Location = new System.Drawing.Point(491, 14);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(137, 122);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Encoding";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Iterations";
            // 
            // numMsvEncIteration
            // 
            this.numMsvEncIteration.Location = new System.Drawing.Point(4, 60);
            this.numMsvEncIteration.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.numMsvEncIteration.Name = "numMsvEncIteration";
            this.numMsvEncIteration.Size = new System.Drawing.Size(117, 20);
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
            "x64/zutto_dekiru",
            "x86/shikata_ga_nai"});
            this.cbMsvEncoding.Location = new System.Drawing.Point(4, 16);
            this.cbMsvEncoding.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbMsvEncoding.Name = "cbMsvEncoding";
            this.cbMsvEncoding.Size = new System.Drawing.Size(118, 21);
            this.cbMsvEncoding.TabIndex = 1;
            this.cbMsvEncoding.Text = "None";
            this.cbMsvEncoding.SelectedIndexChanged += new System.EventHandler(this.cbMsvEncoding_SelectedIndexChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbMsvFull);
            this.groupBox2.Controls.Add(this.rbMsvStaged);
            this.groupBox2.Controls.Add(this.cbMsvPayload);
            this.groupBox2.Location = new System.Drawing.Point(97, 14);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(249, 122);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Payload";
            // 
            // rbMsvFull
            // 
            this.rbMsvFull.AutoSize = true;
            this.rbMsvFull.Location = new System.Drawing.Point(92, 44);
            this.rbMsvFull.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbMsvFull.Name = "rbMsvFull";
            this.rbMsvFull.Size = new System.Drawing.Size(41, 17);
            this.rbMsvFull.TabIndex = 2;
            this.rbMsvFull.Text = "Full";
            this.rbMsvFull.UseVisualStyleBackColor = true;
            this.rbMsvFull.CheckedChanged += new System.EventHandler(this.rbMsvFull_CheckedChanged);
            // 
            // rbMsvStaged
            // 
            this.rbMsvStaged.AutoSize = true;
            this.rbMsvStaged.Checked = true;
            this.rbMsvStaged.Location = new System.Drawing.Point(4, 46);
            this.rbMsvStaged.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbMsvStaged.Name = "rbMsvStaged";
            this.rbMsvStaged.Size = new System.Drawing.Size(59, 17);
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
            this.cbMsvPayload.Location = new System.Drawing.Point(4, 16);
            this.cbMsvPayload.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbMsvPayload.Name = "cbMsvPayload";
            this.cbMsvPayload.Size = new System.Drawing.Size(240, 21);
            this.cbMsvPayload.TabIndex = 0;
            this.cbMsvPayload.Text = "windows/meterpreter/reverse_tcp";
            this.cbMsvPayload.SelectedIndexChanged += new System.EventHandler(this.cbMsvPayload_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbMsv86);
            this.groupBox1.Controls.Add(this.rbMsv64);
            this.groupBox1.Location = new System.Drawing.Point(12, 14);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(81, 122);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Architecture";
            // 
            // rbMsv86
            // 
            this.rbMsv86.AutoSize = true;
            this.rbMsv86.Location = new System.Drawing.Point(13, 51);
            this.rbMsv86.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbMsv86.Name = "rbMsv86";
            this.rbMsv86.Size = new System.Drawing.Size(42, 17);
            this.rbMsv86.TabIndex = 1;
            this.rbMsv86.Text = "x86";
            this.rbMsv86.UseVisualStyleBackColor = true;
            this.rbMsv86.CheckedChanged += new System.EventHandler(this.rbMsv86_CheckedChanged);
            // 
            // rbMsv64
            // 
            this.rbMsv64.AutoSize = true;
            this.rbMsv64.Checked = true;
            this.rbMsv64.Location = new System.Drawing.Point(13, 25);
            this.rbMsv64.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbMsv64.Name = "rbMsv64";
            this.rbMsv64.Size = new System.Drawing.Size(42, 17);
            this.rbMsv64.TabIndex = 0;
            this.rbMsv64.TabStop = true;
            this.rbMsv64.Text = "x64";
            this.rbMsv64.UseVisualStyleBackColor = true;
            this.rbMsv64.CheckedChanged += new System.EventHandler(this.rbMsv64_CheckedChanged);
            // 
            // tpProxyDLL
            // 
            this.tpProxyDLL.Controls.Add(this.txtProxyPath);
            this.tpProxyDLL.Controls.Add(this.btnProxyLoad);
            this.tpProxyDLL.Controls.Add(this.txtProxyOut);
            this.tpProxyDLL.Location = new System.Drawing.Point(4, 22);
            this.tpProxyDLL.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpProxyDLL.Name = "tpProxyDLL";
            this.tpProxyDLL.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpProxyDLL.Size = new System.Drawing.Size(919, 503);
            this.tpProxyDLL.TabIndex = 1;
            this.tpProxyDLL.Text = "    Proxy DLL Generator    ";
            this.tpProxyDLL.UseVisualStyleBackColor = true;
            // 
            // txtProxyPath
            // 
            this.txtProxyPath.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProxyPath.Location = new System.Drawing.Point(12, 10);
            this.txtProxyPath.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtProxyPath.Name = "txtProxyPath";
            this.txtProxyPath.Size = new System.Drawing.Size(801, 20);
            this.txtProxyPath.TabIndex = 2;
            // 
            // btnProxyLoad
            // 
            this.btnProxyLoad.Location = new System.Drawing.Point(815, 8);
            this.btnProxyLoad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnProxyLoad.Name = "btnProxyLoad";
            this.btnProxyLoad.Size = new System.Drawing.Size(94, 23);
            this.btnProxyLoad.TabIndex = 1;
            this.btnProxyLoad.Text = "Analyze DLL";
            this.btnProxyLoad.UseVisualStyleBackColor = true;
            this.btnProxyLoad.Click += new System.EventHandler(this.btnProxyLoad_Click);
            // 
            // txtProxyOut
            // 
            this.txtProxyOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProxyOut.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProxyOut.Location = new System.Drawing.Point(12, 43);
            this.txtProxyOut.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtProxyOut.Name = "txtProxyOut";
            this.txtProxyOut.Size = new System.Drawing.Size(899, 454);
            this.txtProxyOut.TabIndex = 0;
            this.txtProxyOut.Text = "";
            // 
            // tpExportScan
            // 
            this.tpExportScan.Controls.Add(this.btn_Export_Scanner_chdir);
            this.tpExportScan.Controls.Add(this.label7);
            this.tpExportScan.Controls.Add(this.txt_Export_Scanner_Dir);
            this.tpExportScan.Controls.Add(this.label6);
            this.tpExportScan.Controls.Add(this.txt_Export_Scanner_Search_Term);
            this.tpExportScan.Controls.Add(this.txt_Export_Scanner_Out);
            this.tpExportScan.Controls.Add(this.btn_Export_Scanner_Search);
            this.tpExportScan.Location = new System.Drawing.Point(4, 22);
            this.tpExportScan.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpExportScan.Name = "tpExportScan";
            this.tpExportScan.Size = new System.Drawing.Size(919, 503);
            this.tpExportScan.TabIndex = 2;
            this.tpExportScan.Text = "    DLL Export Scanner    ";
            this.tpExportScan.UseVisualStyleBackColor = true;
            // 
            // btn_Export_Scanner_chdir
            // 
            this.btn_Export_Scanner_chdir.Location = new System.Drawing.Point(677, 47);
            this.btn_Export_Scanner_chdir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Export_Scanner_chdir.Name = "btn_Export_Scanner_chdir";
            this.btn_Export_Scanner_chdir.Size = new System.Drawing.Size(50, 21);
            this.btn_Export_Scanner_chdir.TabIndex = 6;
            this.btn_Export_Scanner_chdir.Text = "  ...  ";
            this.btn_Export_Scanner_chdir.UseVisualStyleBackColor = true;
            this.btn_Export_Scanner_chdir.Click += new System.EventHandler(this.btn_Export_Scanner_chdir_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "In";
            // 
            // txt_Export_Scanner_Dir
            // 
            this.txt_Export_Scanner_Dir.Location = new System.Drawing.Point(80, 47);
            this.txt_Export_Scanner_Dir.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Export_Scanner_Dir.Name = "txt_Export_Scanner_Dir";
            this.txt_Export_Scanner_Dir.Size = new System.Drawing.Size(595, 20);
            this.txt_Export_Scanner_Dir.TabIndex = 4;
            this.txt_Export_Scanner_Dir.Text = "C:\\Windows\\System32\\";
            this.txt_Export_Scanner_Dir.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 18);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Search Term";
            // 
            // txt_Export_Scanner_Search_Term
            // 
            this.txt_Export_Scanner_Search_Term.Location = new System.Drawing.Point(80, 16);
            this.txt_Export_Scanner_Search_Term.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Export_Scanner_Search_Term.Name = "txt_Export_Scanner_Search_Term";
            this.txt_Export_Scanner_Search_Term.Size = new System.Drawing.Size(666, 20);
            this.txt_Export_Scanner_Search_Term.TabIndex = 2;
            this.txt_Export_Scanner_Search_Term.Text = "Alloc";
            // 
            // txt_Export_Scanner_Out
            // 
            this.txt_Export_Scanner_Out.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Export_Scanner_Out.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Export_Scanner_Out.Location = new System.Drawing.Point(12, 84);
            this.txt_Export_Scanner_Out.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Export_Scanner_Out.Name = "txt_Export_Scanner_Out";
            this.txt_Export_Scanner_Out.Size = new System.Drawing.Size(898, 415);
            this.txt_Export_Scanner_Out.TabIndex = 1;
            this.txt_Export_Scanner_Out.Text = "";
            // 
            // btn_Export_Scanner_Search
            // 
            this.btn_Export_Scanner_Search.Location = new System.Drawing.Point(775, 16);
            this.btn_Export_Scanner_Search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Export_Scanner_Search.Name = "btn_Export_Scanner_Search";
            this.btn_Export_Scanner_Search.Size = new System.Drawing.Size(134, 47);
            this.btn_Export_Scanner_Search.TabIndex = 0;
            this.btn_Export_Scanner_Search.Text = "Search Exports";
            this.btn_Export_Scanner_Search.UseVisualStyleBackColor = true;
            this.btn_Export_Scanner_Search.Click += new System.EventHandler(this.btn_Export_Scanner_Search_Click);
            // 
            // tpCustomEncoder
            // 
            this.tpCustomEncoder.Controls.Add(this.btnCSE_Decode);
            this.tpCustomEncoder.Controls.Add(this.btnCSE_Encode);
            this.tpCustomEncoder.Controls.Add(this.txtCSE_out);
            this.tpCustomEncoder.Location = new System.Drawing.Point(4, 22);
            this.tpCustomEncoder.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpCustomEncoder.Name = "tpCustomEncoder";
            this.tpCustomEncoder.Size = new System.Drawing.Size(919, 503);
            this.tpCustomEncoder.TabIndex = 3;
            this.tpCustomEncoder.Text = "Custom Shellcode Encoder";
            this.tpCustomEncoder.UseVisualStyleBackColor = true;
            // 
            // btnCSE_Encode
            // 
            this.btnCSE_Encode.Location = new System.Drawing.Point(12, 14);
            this.btnCSE_Encode.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCSE_Encode.Name = "btnCSE_Encode";
            this.btnCSE_Encode.Size = new System.Drawing.Size(78, 22);
            this.btnCSE_Encode.TabIndex = 3;
            this.btnCSE_Encode.Text = "Encode";
            this.btnCSE_Encode.UseVisualStyleBackColor = true;
            this.btnCSE_Encode.Click += new System.EventHandler(this.btnCSE_Encode_Click);
            // 
            // txtCSE_out
            // 
            this.txtCSE_out.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCSE_out.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCSE_out.Location = new System.Drawing.Point(12, 51);
            this.txtCSE_out.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCSE_out.Name = "txtCSE_out";
            this.txtCSE_out.Size = new System.Drawing.Size(899, 445);
            this.txtCSE_out.TabIndex = 0;
            this.txtCSE_out.Text = "";
            // 
            // tpVSO
            // 
            this.tpVSO.AllowDrop = true;
            this.tpVSO.Controls.Add(this.txtVSO_out);
            this.tpVSO.Controls.Add(this.btnVSO_Obfuscate);
            this.tpVSO.Controls.Add(this.txtVSO_In);
            this.tpVSO.Location = new System.Drawing.Point(4, 22);
            this.tpVSO.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tpVSO.Name = "tpVSO";
            this.tpVSO.Size = new System.Drawing.Size(919, 503);
            this.tpVSO.TabIndex = 4;
            this.tpVSO.Text = "VBA String Obfuscator";
            this.tpVSO.UseVisualStyleBackColor = true;
            // 
            // txtVSO_out
            // 
            this.txtVSO_out.Location = new System.Drawing.Point(12, 163);
            this.txtVSO_out.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtVSO_out.Name = "txtVSO_out";
            this.txtVSO_out.Size = new System.Drawing.Size(898, 333);
            this.txtVSO_out.TabIndex = 2;
            this.txtVSO_out.Text = "";
            // 
            // btnVSO_Obfuscate
            // 
            this.btnVSO_Obfuscate.Location = new System.Drawing.Point(397, 101);
            this.btnVSO_Obfuscate.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnVSO_Obfuscate.Name = "btnVSO_Obfuscate";
            this.btnVSO_Obfuscate.Size = new System.Drawing.Size(121, 40);
            this.btnVSO_Obfuscate.TabIndex = 1;
            this.btnVSO_Obfuscate.Text = "Obfuscate";
            this.btnVSO_Obfuscate.UseVisualStyleBackColor = true;
            this.btnVSO_Obfuscate.Click += new System.EventHandler(this.btnVSO_Obfuscate_Click);
            // 
            // txtVSO_In
            // 
            this.txtVSO_In.Location = new System.Drawing.Point(12, 12);
            this.txtVSO_In.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtVSO_In.Name = "txtVSO_In";
            this.txtVSO_In.Size = new System.Drawing.Size(898, 79);
            this.txtVSO_In.TabIndex = 0;
            this.txtVSO_In.Text = "";
            // 
            // tpEncodeAssembly
            // 
            this.tpEncodeAssembly.Controls.Add(this.txtEA_out);
            this.tpEncodeAssembly.Controls.Add(this.btnEA_Encode);
            this.tpEncodeAssembly.Location = new System.Drawing.Point(4, 22);
            this.tpEncodeAssembly.Name = "tpEncodeAssembly";
            this.tpEncodeAssembly.Size = new System.Drawing.Size(919, 503);
            this.tpEncodeAssembly.TabIndex = 5;
            this.tpEncodeAssembly.Text = "Encode Assembly";
            this.tpEncodeAssembly.UseVisualStyleBackColor = true;
            // 
            // txtEA_out
            // 
            this.txtEA_out.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEA_out.Location = new System.Drawing.Point(11, 117);
            this.txtEA_out.Name = "txtEA_out";
            this.txtEA_out.Size = new System.Drawing.Size(898, 374);
            this.txtEA_out.TabIndex = 1;
            this.txtEA_out.Text = "";
            // 
            // btnEA_Encode
            // 
            this.btnEA_Encode.Location = new System.Drawing.Point(11, 88);
            this.btnEA_Encode.Name = "btnEA_Encode";
            this.btnEA_Encode.Size = new System.Drawing.Size(142, 23);
            this.btnEA_Encode.TabIndex = 0;
            this.btnEA_Encode.Text = "Encode Assembly";
            this.btnEA_Encode.UseVisualStyleBackColor = true;
            this.btnEA_Encode.Click += new System.EventHandler(this.btnEA_Encode_Click);
            // 
            // txtLHOST
            // 
            this.txtLHOST.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLHOST.Location = new System.Drawing.Point(57, 21);
            this.txtLHOST.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLHOST.Name = "txtLHOST";
            this.txtLHOST.Size = new System.Drawing.Size(104, 20);
            this.txtLHOST.TabIndex = 3;
            this.txtLHOST.Text = "tun0";
            this.txtLHOST.TextChanged += new System.EventHandler(this.txtLHOST_TextChanged);
            // 
            // lbLHOST
            // 
            this.lbLHOST.AutoSize = true;
            this.lbLHOST.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLHOST.Location = new System.Drawing.Point(12, 24);
            this.lbLHOST.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLHOST.Name = "lbLHOST";
            this.lbLHOST.Size = new System.Drawing.Size(43, 13);
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
            this.gnEnviroment.Location = new System.Drawing.Point(8, 23);
            this.gnEnviroment.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gnEnviroment.Name = "gnEnviroment";
            this.gnEnviroment.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gnEnviroment.Size = new System.Drawing.Size(924, 81);
            this.gnEnviroment.TabIndex = 5;
            this.gnEnviroment.TabStop = false;
            this.gnEnviroment.Text = "Environment";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(373, 55);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Command:";
            // 
            // txtMsvCmd
            // 
            this.txtMsvCmd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMsvCmd.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMsvCmd.Location = new System.Drawing.Point(431, 52);
            this.txtMsvCmd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtMsvCmd.Name = "txtMsvCmd";
            this.txtMsvCmd.Size = new System.Drawing.Size(482, 20);
            this.txtMsvCmd.TabIndex = 15;
            this.txtMsvCmd.Text = "whoami";
            this.txtMsvCmd.TextChanged += new System.EventHandler(this.txtMsvCmd_TextChanged);
            // 
            // lbPASS
            // 
            this.lbPASS.AutoSize = true;
            this.lbPASS.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPASS.Location = new System.Drawing.Point(189, 52);
            this.lbPASS.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbPASS.Name = "lbPASS";
            this.lbPASS.Size = new System.Drawing.Size(37, 13);
            this.lbPASS.TabIndex = 14;
            this.lbPASS.Text = "Pass:";
            // 
            // txtPASS
            // 
            this.txtPASS.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPASS.Location = new System.Drawing.Point(235, 49);
            this.txtPASS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPASS.Name = "txtPASS";
            this.txtPASS.PasswordChar = '*';
            this.txtPASS.Size = new System.Drawing.Size(104, 20);
            this.txtPASS.TabIndex = 13;
            this.txtPASS.Text = "lab";
            this.txtPASS.WordWrap = false;
            this.txtPASS.TextChanged += new System.EventHandler(this.txtPASS_TextChanged);
            // 
            // lbUSER
            // 
            this.lbUSER.AutoSize = true;
            this.lbUSER.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUSER.Location = new System.Drawing.Point(12, 52);
            this.lbUSER.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbUSER.Name = "lbUSER";
            this.lbUSER.Size = new System.Drawing.Size(37, 13);
            this.lbUSER.TabIndex = 12;
            this.lbUSER.Text = "User:";
            // 
            // txtUSER
            // 
            this.txtUSER.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUSER.Location = new System.Drawing.Point(57, 49);
            this.txtUSER.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUSER.Name = "txtUSER";
            this.txtUSER.Size = new System.Drawing.Size(104, 20);
            this.txtUSER.TabIndex = 11;
            this.txtUSER.Text = "offsec";
            this.txtUSER.TextChanged += new System.EventHandler(this.txtUSER_TextChanged);
            // 
            // lbRPORT
            // 
            this.lbRPORT.AutoSize = true;
            this.lbRPORT.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRPORT.Location = new System.Drawing.Point(561, 20);
            this.lbRPORT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRPORT.Name = "lbRPORT";
            this.lbRPORT.Size = new System.Drawing.Size(43, 13);
            this.lbRPORT.TabIndex = 10;
            this.lbRPORT.Text = "RPORT:";
            // 
            // txtRPORT
            // 
            this.txtRPORT.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRPORT.Location = new System.Drawing.Point(606, 18);
            this.txtRPORT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRPORT.Name = "txtRPORT";
            this.txtRPORT.Size = new System.Drawing.Size(104, 20);
            this.txtRPORT.TabIndex = 9;
            this.txtRPORT.Text = "80";
            this.txtRPORT.TextChanged += new System.EventHandler(this.txtRPORT_TextChanged);
            // 
            // lbLPORT
            // 
            this.lbLPORT.AutoSize = true;
            this.lbLPORT.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLPORT.Location = new System.Drawing.Point(373, 21);
            this.lbLPORT.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbLPORT.Name = "lbLPORT";
            this.lbLPORT.Size = new System.Drawing.Size(43, 13);
            this.lbLPORT.TabIndex = 8;
            this.lbLPORT.Text = "LPORT:";
            // 
            // txtLPORT
            // 
            this.txtLPORT.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLPORT.Location = new System.Drawing.Point(419, 19);
            this.txtLPORT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtLPORT.Name = "txtLPORT";
            this.txtLPORT.Size = new System.Drawing.Size(104, 20);
            this.txtLPORT.TabIndex = 7;
            this.txtLPORT.Text = "4444";
            this.txtLPORT.TextChanged += new System.EventHandler(this.txtLPORT_TextChanged);
            // 
            // lbRHOST
            // 
            this.lbRHOST.AutoSize = true;
            this.lbRHOST.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbRHOST.Location = new System.Drawing.Point(189, 23);
            this.lbRHOST.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbRHOST.Name = "lbRHOST";
            this.lbRHOST.Size = new System.Drawing.Size(43, 13);
            this.lbRHOST.TabIndex = 6;
            this.lbRHOST.Text = "RHOST:";
            // 
            // txtRHOST
            // 
            this.txtRHOST.Font = new System.Drawing.Font("Consolas", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRHOST.Location = new System.Drawing.Point(235, 20);
            this.txtRHOST.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRHOST.Name = "txtRHOST";
            this.txtRHOST.Size = new System.Drawing.Size(104, 20);
            this.txtRHOST.TabIndex = 5;
            this.txtRHOST.Text = "192.168.0.10";
            this.txtRHOST.TextChanged += new System.EventHandler(this.txtRHOST_TextChanged);
            // 
            // btnCSE_Decode
            // 
            this.btnCSE_Decode.Location = new System.Drawing.Point(117, 14);
            this.btnCSE_Decode.Margin = new System.Windows.Forms.Padding(2);
            this.btnCSE_Decode.Name = "btnCSE_Decode";
            this.btnCSE_Decode.Size = new System.Drawing.Size(78, 22);
            this.btnCSE_Decode.TabIndex = 4;
            this.btnCSE_Decode.Text = "Decode";
            this.btnCSE_Decode.UseVisualStyleBackColor = true;
            this.btnCSE_Decode.Click += new System.EventHandler(this.btnCSE_Decode_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 672);
            this.Controls.Add(this.gnEnviroment);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(961, 705);
            this.Name = "Form1";
            this.Text = "OSEP 2026";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
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
            this.tpProxyDLL.ResumeLayout(false);
            this.tpProxyDLL.PerformLayout();
            this.tpExportScan.ResumeLayout(false);
            this.tpExportScan.PerformLayout();
            this.tpCustomEncoder.ResumeLayout(false);
            this.tpVSO.ResumeLayout(false);
            this.tpEncodeAssembly.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tpProxyDLL;
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
        private System.Windows.Forms.TextBox txtProxyPath;
        private System.Windows.Forms.Button btnProxyLoad;
        private System.Windows.Forms.RichTextBox txtProxyOut;
        private System.Windows.Forms.TabPage tpExportScan;
        private System.Windows.Forms.RichTextBox txt_Export_Scanner_Out;
        private System.Windows.Forms.Button btn_Export_Scanner_Search;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Export_Scanner_Dir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Export_Scanner_Search_Term;
        private System.Windows.Forms.Button btn_Export_Scanner_chdir;
        private System.Windows.Forms.ToolStripProgressBar sbProgress;
        private System.Windows.Forms.ToolStripStatusLabel sbLabel1;
        private System.Windows.Forms.TabPage tpCustomEncoder;
        private System.Windows.Forms.RichTextBox txtCSE_out;
        private System.Windows.Forms.Button btnCSE_Encode;
        private System.Windows.Forms.TabPage tpVSO;
        private System.Windows.Forms.RichTextBox txtVSO_out;
        private System.Windows.Forms.Button btnVSO_Obfuscate;
        private System.Windows.Forms.RichTextBox txtVSO_In;
        private System.Windows.Forms.TabPage tpEncodeAssembly;
        private System.Windows.Forms.Button btnEA_Encode;
        private System.Windows.Forms.RichTextBox txtEA_out;
        private System.Windows.Forms.Button btnCSE_Decode;
    }
}

