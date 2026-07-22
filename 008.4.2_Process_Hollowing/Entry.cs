using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static _008._4._2_Process_Hollowing.Entry;

namespace _008._4._2_Process_Hollowing
{

    internal class Entry
    {
        
        static void Main(string[] args)
        {
            byte[] buf = { };

            CreateHollowProcess chp = new CreateHollowProcess(@"C:\Windows\System32\svchost.exe", buf);
            chp.StartProcess();

        }
    }
}
