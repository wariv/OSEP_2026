using System;
using System.Collections.Generic;
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
#if X64
            Console.WriteLine("Hello x64");
#elif X86
            Console.WriteLine("Hello x86");
#endif



        }
    }
}
