using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSEP_2026
{
    public partial class MSFVenom
    {
        private void PopulatePayloads()
        {
            string payloadraw = @"
                windows/x64/meterpreter/reverse_tcp         |x64    |staged
                windows/x64/meterpreter/bind_tcp            |x64    |staged
                windows/x64/meterpreter/reverse_http        |x64    |staged
                windows/x64/meterpreter/reverse_https       |x64    |staged
                windows/x64/meterpreter_reverse_tcp         |x64    |full
                windows/x64/meterpreter_bind_tcp            |x64    |full
                windows/x64/meterpreter_reverse_http        |x64    |full
                windows/x64/meterpreter_reverse_https       |x64    |full

                windows/x64/shell/bind_tcp                  |x64    |staged
                windows/x64/shell/reverse_tcp               |x64    |staged
                windows/x64/shell_bind_tcp                  |x64    |full
                windows/x64/shell_reverse_tcp               |x64    |full

                windows/x64/exec                            |x64    |full

                windows/meterpreter/reverse_tcp             |x86    |staged
                windows/meterpreter/bind_tcp                |x86    |staged
                windows/meterpreter/reverse_http            |x86    |staged
                windows/meterpreter/reverse_https           |x86    |staged
                windows/meterpreter_reverse_tcp             |x86    |full
                windows/meterpreter_bind_tcp                |x86    |full
                windows/meterpreter_reverse_http            |x86    |full
                windows/meterpreter_reverse_https           |x86    |full

                windows/shell/bind_tcp                      |x86    |staged
                windows/shell/reverse_tcp                   |x86    |staged
                windows/shell_bind_tcp                      |x86    |full
                windows/shell_reverse_tcp                   |x86    |full

                windows/exec                                |x86    |full
                ";

            foreach (string s in payloadraw.Split('\n')) {

                try
                {
                    string[] si = s.Split('|');
                    MSFVenomPayload msfvp = new MSFVenomPayload();

                    msfvp.Name = si[0].Trim();

                    if (si[1].Trim() == "x86")
                    {
                        msfvp.Architecture = MSFVenomArch.x86;
                    }
                    else
                    {
                        msfvp.Architecture = MSFVenomArch.x64;
                    }

                    if (si[2].Trim() == "full")
                    {
                        msfvp.staged = false;
                    }
                    else
                    {
                        msfvp.staged = true;
                    }

                    payloads.Add(msfvp);
                }
                catch { }
                
            }
        }
    }
}
