using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Threading.Tasks;

namespace EXE_Powershell_Runspace_Static
{
    internal class Entry
    {
        static void Main(string[] args)
        {
            Debug.RunDebug("\nMain started");

            string cmd = CONFIG.STATIC_COMMAND;


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
