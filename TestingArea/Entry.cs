using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OSEP
{
    internal class Entry
    {




        static void Main(string[] args)
        {
            
            Debug.RunDebug("--- Testing_Area_Start ---");
            Debug.RunDebug($"[+] {args[0]} {args[1]}");



#if X64
            Console.WriteLine("Hello x64");
#elif X86
            Console.WriteLine("Hello x86");
#endif



        }
    }
}
