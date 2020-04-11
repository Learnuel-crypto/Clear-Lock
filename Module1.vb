Imports System.IO

Module Module1

    Dim TempFile As System.IO.File
    Dim TempRead As System.IO.StreamReader
    Dim TempWrite As System.IO.StreamWriter
    Public password As String
    Public err As Boolean

    Private Declare Function SetWindowPos Lib "user32.dll" _
        Alias "SetWindowPos" (ByVal hWnd As IntPtr,
                              ByVal hWndIntertAfter As IntPtr,
                              ByVal X As Integer,
                              ByVal Y As Integer,
                              ByVal cx As Integer,
                              ByVal cy As Integer,
                              ByVal uFlags As Integer) As Boolean

    Private HWND_TOP As IntPtr = IntPtr.Zero
    Private Const SWP_SHOWWINDOW As Integer = 64

    ''' <summary>
    ''' Place form into full screen
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="TaskBar">True to hide Windows TaskBar</param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()> _
    Public Sub FullScreen(ByVal sender As Form, ByVal TaskBar As Boolean)

        sender.WindowState = FormWindowState.Maximized
        sender.FormBorderStyle = FormBorderStyle.None
        sender.TopMost = True
        If TaskBar Then

            SetWindowPos(sender.Handle, HWND_TOP, 0, 0,
                         Screen.PrimaryScreen.Bounds.Width,
                         Screen.PrimaryScreen.Bounds.Height,
                         SWP_SHOWWINDOW _
            )

        End If

    End Sub
    ''' <summary>
    ''' Restore to original size/position
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <remarks></remarks>
    <System.Runtime.CompilerServices.Extension()>
    Public Sub NormalMode(ByVal sender As Form)
        sender.TopMost = True
    End Sub



    Public Function CheckFile(ByVal filepath As String) As Boolean

        Dim info As New FileInfo(filepath)
        Dim err As Boolean
        If File.Exists(info.FullName) Then
            err = False
        Else
            Throw New Exception("File not found")
            err = True
        End If
            Return err

    End Function
End Module
