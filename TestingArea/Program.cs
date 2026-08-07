using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TestingArea
{
    internal class Program
    {

        [DllImport("kernel32.dll")]
        public static extern void Sleep(uint dwMilliseconds);


        static void Main(string[] args)
        {



            uint milliseconds = 2000;

            DateTime t1 = DateTime.Now;
            Sleep(milliseconds);
            double t2 = DateTime.Now.Subtract(t1).TotalSeconds;
            double x = milliseconds * 0.75;
            if ((t2 * 1000) < x)
            {
                Environment.Exit(0);
            }
        }
    }
}
