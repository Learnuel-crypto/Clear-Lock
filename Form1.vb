Imports Microsoft.Win32
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.IO
Imports EncryptString


Public Class Form1

    Dim checke As String

    Dim MousePosition1 As Point
    Dim TempFile As System.IO.File
    Dim TempRead As System.IO.StreamReader
    Dim TempWrite As System.IO.StreamWriter
    Dim Str As New StringEncryptor
    Dim frm4 As New Form4
    Private Declare Function ShowWindow Lib "user32" Alias "SetWindowA" (ByVal hwnd As Long, ByVal nCmdShow As Long) As Long
    Private Declare Function FindWindow Lib "user32" Alias "FindWindowA" (ByVal lpClassName As String, ByVal lpWindowName As String) As Long
    Private Const SW_HIDE = 1
    Private Const SW_SHOW = 0

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Form4.Visible = True
        Timer1.Start()
        Form4.txtpass.Clear()

    End Sub

    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Form4.Visible = True
        Timer1.Start()
        Form4.txtpass.Clear()

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.ShowInTaskbar = False

    End Sub

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        ''Try
        frm4.ShowDialog()
        ''Catch

        ''End Try

    End Sub

    Private Sub Form1_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Call FullScreen(WindowState)

    End Sub


    Private Declare Function SetWindowPos Lib "user32.dll" _
        Alias "SetWindowPos" (ByVal hWnd As IntPtr,
                              ByVal hWndIntertAfter As IntPtr,
                              ByVal X As Integer,
                              ByVal Y As Integer,
                              ByVal cx As Integer,
                              ByVal cy As Integer,
                              ByVal uFlags As Integer) As Boolean

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        frm4.ShowDialog()

    End Sub
End Class