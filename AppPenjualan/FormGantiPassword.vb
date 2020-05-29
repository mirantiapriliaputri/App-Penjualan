Imports System.Data.Odbc
Public Class FormGantiPassword


    Private Sub FormGantiPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()

    End Sub
    Sub KondisiAwal()
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        TextBox1.Enabled = True
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox1.PasswordChar = "*"
        TextBox2.PasswordChar = "*"
        TextBox3.PasswordChar = "*"
    End Sub
    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            Call Koneksi()
            Cmd = New OdbcCommand("Select * From tbl_admin where kode_admin='" & FormMenuUtama.STLabel2.Text & "'and password_admin='" & TextBox1.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                TextBox2.Enabled = True
                TextBox3.Enabled = True
                TextBox1.Enabled = False
            Else
                MsgBox("Password Lama Salah!")
                TextBox1.Text = ""

            End If
        End If
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Password Baru Harus Di Isi!")
        Else
            If TextBox2.Text <> TextBox3.Text Then
                MsgBox("Password Baru Dan Konfirmasi Password Baru Harus Sama!")
            Else
                Call Koneksi()
                Dim UpdateData As String = "Update tbl_admin set password_admin='" & TextBox3.Text & "' where kode_admin='" & FormMenuUtama.STLabel2.Text & "'"
                Cmd = New OdbcCommand(UpdateData, Conn)
                Cmd.ExecuteNonQuery()
                MsgBox("Password Berhasil Di Update")
                Call KondisiAwal()
            End If
        End If
    End Sub
End Class