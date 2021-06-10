'Imports Odbc.Data.OdbcClient
Imports System.Data.Odbc
Public Class pop_up_nasabah

    Private Sub pop_up_nasabah_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        nasabah()
        atur()
    End Sub
    Sub nasabah()
        ds = New DataSet
        query = "select ktp,nama from nasabah"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Nasabah  : " & ex.Message, "Peringatan", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub atur()
        Try
            With DataGridView1
                .Columns(0).HeaderText = "Nomor KTP"
                .Columns(0).Width = 120
                .Columns(1).HeaderText = "Nama Nasabah"
                .Columns(1).Width = 270
            End With
        Catch ex As Exception

        End Try

    End Sub
    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        ds = New DataSet
        query = "select ktp,nama from nasabah where ktp like '%" & TextBox1.Text & "%' or nama like '%" & TextBox1.Text & "%'"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Nasabah  : " & ex.Message, "Peringatan", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            Formadmin.labelkodenasbahtransaksi.Text = DataGridView1.Item(0, i).Value
            Formadmin.txtnamnasabahtaransaki.Text = DataGridView1.Item(1, i).Value
            'Formpetugas.labelkodenasbahtransaksi.Text = DataGridView1.Item(0, i).Value
            'Formpetugas.txtnamnasabahtaransaki.Text = DataGridView1.Item(1, i).Value
        Catch ex As Exception

        End Try
        'Me.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        nasabah()
    End Sub
End Class