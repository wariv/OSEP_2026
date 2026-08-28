## Purpose
This artifact attempts to bypass applocker when run via InstallUtil.exe.


## Prerequisites
- Ability to run PE files on target system.
- Access to run InstallUtil.exe


## How to use:

Ok, the important part of this artifact only runs when invoked from InstallUtil.exe
This is important because that is a signed MS binary and many times is not blocked by Applocker.

1.  Run it locally via: `powershell -Command "C:\Windows\Microsoft.NET\Framework64\v4.0.30319\installutil.exe /logfile= /LogToConsole=false /U iu-call-ps-curl.exe"`