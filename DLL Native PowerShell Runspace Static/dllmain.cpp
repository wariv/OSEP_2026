// dllmain.cpp : Defines the entry point for the DLL application.
#include "pch.h"
#include <windows.h>
#include <vcclr.h>
#include "OSEPGlobals.h"

using namespace System;
using namespace System::Management::Automation;
using namespace System::Collections::ObjectModel;

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    switch (ul_reason_for_call)
    {
    case DLL_PROCESS_ATTACH:
        
    case DLL_THREAD_ATTACH:
    case DLL_THREAD_DETACH:
    case DLL_PROCESS_DETACH:
        break;
    }
    return TRUE;
}

static void DebugOut(String^ text)
{
    if (String::IsNullOrEmpty(text))
        return;

    pin_ptr<const wchar_t> pinned = PtrToStringChars(text);
    const wchar_t* raw = pinned;

    OutputDebugStringW(raw);
    OutputDebugStringW(L"\n");
}

extern "C" __declspec(dllexport)
void CALLBACK OSEPExec(
    HWND hwnd,
    HINSTANCE hinst,
    LPSTR lpszCmdLine,
    int nCmdShow
)
{
    try
    {
        PowerShell^ ps = PowerShell::Create();

        System::String^ managedScript = gcnew System::String(PS_STATIC_COMMAND.c_str());

        ps->AddScript(managedScript);

        Collection<PSObject^>^ results = ps->Invoke();

        for each (PSObject ^ item in results)
        {
            if (item)
                DebugOut(item->ToString());
        }

        if (ps->HadErrors)
        {
            for each (ErrorRecord ^ err in ps->Streams->Error)
            {
                DebugOut("PS Error: " + err->ToString());
            }
        }
    }
    catch (Exception^ ex)
    {
        DebugOut("Exception: " + ex->ToString());
    }
}

