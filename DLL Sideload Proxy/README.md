## Purpose:
- Use this artifact for DLL sideloading /hijacking.


## Prerequisites
You should already have a foothold on the target.
You should already have found an application with a missing DLL NAME_NOT_FOUND issue (5.1 - Client Side Attacks)
You should have write access to place this DLL in the search order location
You should have compiled this artifact with the appropriate proxy code.



## How to use:

Ok, this is one of the only artifacts where you have to make changes to the source code prior to compiling.
So, sorry, couldnt automate this one for you.

1. First You need to add the proxy code to this dll source code.
    - This is so the target application can still function.
    - The OSEP-Helper tool can generate this code for you.
        - Open the tool and go to the "Proxy DLL Generator"
        - Pick the DLL you want to proxy.
        - Replace all the generated code into this artifact's source code (dllmain.cpp).
        - Put your preferred malicous code back in where it say "//START MALICIOUS CODE" (Remember this is C++; not C#)
        - I put a basic Shellcode Runner as an example (in the original source code, you know, before iI told you to copy over it...).
        - Recompile the solution.

2. Place this DLL into the vulnerable location.
3. Hopefully enjoy shell as an elevated user.

