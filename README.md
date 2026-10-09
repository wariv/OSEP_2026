This is my personal tool set to assist with OSEP. It's not all me though. I had some great technical contributions by Senshi and others. Thank you all who contributed.


# How to use
1. Open the solution.
2. Goto the "Configuration" project.
3. Open OSEPGlobals.cs
4. Update the following settings
  - ATTACKER_IP - This should be your Tun0 IP
  - ENCODED - Set true if you want custom shellcode encoding enabled.
  - SHELLCODE64 - Generate your preferred payload shellcode x64
  - SHELLCODE86 - Generate your preferred payload shellcode x64
5. Build -> Rebuild Solution
6. Enjoy your payloads in "ARTIFACTS" (created in the solution directory)

> [!IMPORTANT] 
> You need to disable Defender when you build the solution IF you want DotNet2JScript functionality to work. Please review the code. Don't take my word for it.


# ARTIFACTS
So what gets created?

TLDR; Automatically generate macro docm files, scripts, tools tailored to your environment. You only need update the setting in configuration.

1. Any vba file under /templates/vba will get placed, as a macro, into a docm file. 
2. All the binaries generated in the projects will be sorted and aggregated here.
3. All the various ps1 scripts and files in templates/scripts will aggregated here.




### ENCODING
I have written a unique enough xor encoder. Nothing fancy. However, it is enough to bypass anything you encounter in OSEP. If you elect to enable encoding a few things will happen.

1. Prebuild will replace the shellcode in OSEPGlobals.cs with encoded shellcode.
2. The project will build with this encoded shellcode.
3. Logic will be added to all  binaries, docm, and scripts to decode the shellcode at runtime.
4. The build projects last task will replace the orginal shellcode back into OSEPGlobals.cs




### NAMING CONVENTIONS
lol, good luck with this one. here are my mad scientist translations for naming of binaries.


- iu = Made to run with IntallUtil
- ea = Uses Reflection
- ps = Uses PowerShell
- rs = Uses PowerShell Runspaces
- st = Looks for a static file dll, script, etc on the target machine.
- dy = Looks for a dynamic file over HTTP (Thats you!!!)
- sc = Shellcode involved





### FINAL THOUGHTS
For the most part it all just works. This is the product of a mad scientist and I am not trying to win any coding awards with it. Use it at your own risk. I make no assertions that you will pass OSEP using it.

All the same I hope you find it interesting and useful. Eventually I will get around to making it a bit more coherent.

This tool contains resources that were not created by me.

Namely Dotnet2Jscript, winpeas, and powerview.


https://github.com/tyranid/DotNetToJScript

https://github.com/PowerShellEmpire/PowerTools/blob/master/PowerView/powerview.ps1

https://github.com/peass-ng/PEASS-ng/blob/master/winPEAS/winPEASexe/README.md


