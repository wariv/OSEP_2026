## Purpose:
- This artifact is used to demonstrate C# code has been executed from a dll.
- It should be used to see if a running code from a dll bypasses applocker.


## Prerequisites
You should be able to reliably execute PowerShell on the target before using this.


## How to use:
1. Host `call-invokable.dll` on your webserver. Ensure it has proper permissions e.g. 776
2. Use PowerShell to invoke the dll method
    - `ps_invoke_dll_callback.ps1` is a good example.






