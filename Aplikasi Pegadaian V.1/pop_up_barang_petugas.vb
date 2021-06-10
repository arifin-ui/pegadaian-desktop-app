Imports System.Data.Odbc
Public Class pop_up_barang_petugas

    Private Sub pop_up_barang_petugas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        barang()
        atur()
    End Sub
    Sub barang()
        Dim status1 As String
        status1 = "Tersedia"
        ds = New DataSet
        query = "select kodebarang,namabarang from barang where status='" & status1 & "'"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Barang  : " & ex.Message, "Peringatan", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub atur()
        Try
            With DataGridView1
                .Columns(0).HeaderText = "KODE"
                .Columns(0).Width = 120
                .Columns(1).HeaderText = "Nama Barang"
                .Columns(1).Width = 270
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        ds = New DataSet
        query = "select kodebarang,namabarang from barang where kodebarang like '%" & TextBox1.Text & "%' or namabarang like '%" & TextBox1.Text & "%'"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            DataGridView1.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Barang  : " & ex.Message, "Peringatan", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim i As Integer
            i = DataGridView1.CurrentRow.Index
            Formpetugas.labelkodebrang.Text = DataGridView1.Item(0, i).Value
            Formpetugas.txtnamabarangtarnsaksi.Text = DataGridView1.Item(1, i).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        barang()
    End Sub
End Class