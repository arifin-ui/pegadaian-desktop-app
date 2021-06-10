Imports System.Data.Odbc
'Imports Odbc.Data.OdbcClient
Public Class Formlogin

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        cmd = New OdbcCommand
        cmd.Connection = con
        query = "select*from petugas where username='" & TextBox1.Text & "' and password='" & TextBox2.Text & "'and hakakses='" & ComboBox1.Text & "'"
        cmd.CommandText = query
        da = New OdbcDataAdapter(query, con)
        dt = New DataTable()
        Try
            da.Fill(dt)
            If (dt.Rows.Count > 0) Then
                MsgBox("Login Sebagai : " + dt.Rows(0)(1))
                If (dt.Rows(0)(5) = "Admin") Then
                    Formadmin.Show()
                    Me.Close()
                ElseIf (dt.Rows(0)(5) = "Kasir") Then
                    Formpetugas.Show()
                    Me.Close()
                End If
            Else
                gagal()
            End If
        Catch ex As Exception
            MessageBox.Show("There was error : " & ex.Message, "Error", _
              MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Sub gagal()
        MsgBox("Username Dan Passwor Salah !!", vbOKOnly, "PERHATIAN")
        TextBox1.Text = ""
        TextBox2.Text = ""
        ComboBox1.Text = "--pilih--"
        TextBox1.Focus()
    End Sub


    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.UseSystemPasswordChar = False
        Else
            TextBox2.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Labeljam.Text = TimeOfDay
        Labeltanggal.Text = Today
    End Sub
End Class
