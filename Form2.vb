Imports Microsoft.Win32
Imports System.Diagnostics
Imports System.Runtime.InteropServices
Imports System.IO
Public Class Form2

    Dim setlog As String

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
         

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim objReader As New System.IO.StreamReader("My.Computer.Resources.log.txt")
        Dim logpass As String = objReader.ReadLin

        objReader.Close()
        If logpass = "" Then
            

            If txtsetpass.Text = "" And txtconpass.Text = "" Then


            ElseIf txtsetpass.Text IsNot Nothing And txtconpass.Text IsNot Nothing And txtsetpass.Text = txtconpass.Text Then

                Dim objWriter As New System.IO.StreamWriter("My.Computer.Resources.log.txt")
                setlog = txtconpass.Text
                objWriter.WriteLine(txtconpass.Text)
                objWriter.Close()
                MsgBox("good")
            Else

                Label5.Visible = True
            End If


        Else
            MsgBox("reset password")
        End If
    End Sub

    Private Sub txtsetpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtsetpass.TextChanged
        If txtsetpass.Text = "" Then
            Label5.Visible = False
        End If
    End Sub

    Private Sub txtconpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtconpass.TextChanged
        If txtconpass.Text = "" Then
            Label5.Visible = False
        End If
    End Sub

    Private Sub btnrestpass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnrestpass.Click
        Dim objReader As New System.IO.StreamReader("My.Computer.Resources.log.txt")
        Dim logpass As String = objReader.ReadLine
        'MsgBox(test)
        objReader.Close()
        If txtcurrentpass.Text = logpass Then
            If txtnewpass.Text = txtconfirm.Text Then
                Dim objWriter As New System.IO.StreamWriter("My.Computer.Resources.log.txt")
                objWriter.WriteLine(txtconfirm.Text)
                objWriter.Close()
                MsgBox("password set successful")
            Else
                lblerr3.Visible = True

            End If
        Else
            lblerr2.Visible = True
            txtcurrentpass.Focus()
        End If
    End Sub

    Private Sub txtcurrentpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtcurrentpass.TextChanged
        If txtcurrentpass.Text = "" Then
            lblerr2.Visible = False

        End If
    End Sub

    Private Sub txtnewpass_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnewpass.TextChanged
        If txtnewpass.Text = "" Then
            lblerr3.Visible = False

        End If
    End Sub

    Private Sub txtconfirm_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtconfirm.TextChanged
        If txtconfirm.Text = "" Then
            lblerr3.Visible = False
        End If
    End Sub
End Class
