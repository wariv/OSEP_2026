## Purpose
- This artifact is used to run shellcode from a dll.


## Prerequisites
You should be able to reliably execute PowerShell on the target before using this.


## How to use:
1. Host `/ARTIFACTS/Shellcode invokable/sc-invokable.dll` on your webserver. Ensure it has proper permissions e.g. 776
2. Use PowerShell to invoke the dll method
    - `ps_invoke_dll.ps1` is a good example.



> Note: an error stating "unable to load (1) assembly or somethign liek taht is indicative taht Defender ahs blocked execution.


