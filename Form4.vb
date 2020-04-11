Imports EncryptString
Imports FileEncrypt


Public Class Form4

    Dim Str As New StringEncryptor()
    Public encrypt As New DataEncrytor(Application.StartupPath + "\\")


    Private Sub Form4_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        txtpass.Clear()
        Call NormalMode()

    End Sub

    Private Sub btnpass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnpass.Click
        'Try
        CheckFile(Application.StartupPath + "\log.enc")
            encrypt.FileDetails("log", ".enc", ".txt")
            encrypt.DecryptFile()
            Dim objReader As New System.IO.StreamReader(Application.StartupPath + "\log.txt")
            Dim logpass As String = Str.Decrypt(objReader.ReadLine)
            objReader.Close()
            encrypt.FileType("log", ".txt")
            encrypt.EncryptFile()
            If txtpass.Text = logpass Then
                End
            Else
                lblerror.Visible = True
                txtpass.Focus()
            End If
        'Catch
        '    MessageBox.Show("Unknown Error Occured", "Clear Lock")
        '    End
        'End Try
    End Sub

    Private Sub txtpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtpass.TextChanged
        Timer1.Stop()
        txtpass.UseSystemPasswordChar = True
        If String.IsNullOrEmpty(txtpass.Text) Then
            Timer1.Start()
            lbltime.Text = "0"
            lblerror.Visible = False
        End If
    End Sub

    Private Sub Form4_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Timer1.Enabled = True
        Timer1.Start()
        lbltime.Text = "0"


    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lbltime.Text = Val(lbltime.Text) + 1
        If txtpass.Text = "" And Val(lbltime.Text) = 5 Then
            Me.Visible = False
            lbltime.Text = "0"
            Timer1.Stop()

        End If
    End Sub

    Private Sub txtpass_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpass.KeyPress
        If Keys.Enter Then
            btnpass.PerformClick()
        End If
    End Sub

    Private Sub Form4_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        Me.Hide()
    End Sub
End Class