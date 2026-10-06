using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PreBuild
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (CONFIG.ENCODED == false)
                return; //This aint our scene.

            Console.WriteLine("##########################################\n ENCODING FILE");
            CONFIG.EncodeCONFIG();
        }

        


        
    }
}
