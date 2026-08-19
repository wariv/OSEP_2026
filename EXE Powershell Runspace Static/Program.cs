using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace EXE_Powershell_Runspace_Static
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string cmd = "calc.exe";


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
