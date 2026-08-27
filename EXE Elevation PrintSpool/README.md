

//basically this works by getting spoolsvc to talk to your named pipe.
//Use https://github.com/leechristensen/SpoolSample to get spoolsvc to exec.
//Provide it a pipe name  with a foward slash e.g. appsrv01/test
//it will normalize it and make spoolsvc(SYSTEM) connect to appsrv01\test\pipe\spoolss
//SOOOO, run this app with the pipename \\.\pipe\test\pipe\spoolss to catch that request.

//If you want an all in one solution. It exists here:
//https://github.com/itm4n/PrintSpoofer



## Purpose
This artifact should be used for privilege escalation to SYSTEM

## Prerequisites
- You should have a foothold on the target system
- You should be able to run PEs


## How to Use

1. Run this tool with a pipename like: `\\.\pipe\test\spoolss`
2. Run SpoolSample.exe if a pipename like: `appsrv01/test` (Very important it is a forward slash here)
3. Hopefully catch a shell as SYSTEM.