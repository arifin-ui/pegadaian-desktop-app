Imports System.Data.Odbc
Public Class pop_up_perpanjangan

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            txthasil.Text = Val(Labelpinjman.Text * TextBox2.Text) / 100
            Labeltotalbunga.Text = Val(Labelbunga.Text) + Val(txthasil.Text)
            Labeltotaltebusan.Text = Val(Labeltebusan.Text) + Val(txthasil.Text)
            Button1.Enabled = False
        Catch ex As Exception

        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        cmd = New OdbcCommand
        cmd.Connection = con
        query = "update transaksi set jatuh_tempo='" & DateTimePicker1.Text & "',jumlah_tebusan='" & Labeltotaltebusan.Text & "',bunga='" & Labeltotalbunga.Text & "' where no_transaksi='" & Labelno.Text & "'"
        cmd.CommandText = query
        Try
            cmd.ExecuteNonQuery()
            MsgBox("Perpanjangan Berhasil")
            transaksigadai()
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub
    Sub transaksigadai()
        Dim status As String
        status = "Tergadai"
        ds = New DataSet
        query = "select transaksi.no_transaksi,petugas.namapetugas,nasabah.nama,barang.namabarang,transaksi.tgl_gadai,transaksi.jatuh_tempo, " & _
            "transaksi.jumlah_pinjaman,transaksi.bunga,transaksi.jumlah_tebusan,barang.status from transaksi,petugas,nasabah,barang where transaksi.petugas_nip= " & _
            "petugas.nip and transaksi.nasabah_ktp=nasabah.ktp and transaksi.barang_kode_barang=barang.kodebarang and status='" & status & "'"
        '   query = "select*from transaksi"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            Formadmin.datagadai.DataSource = ds.Tables(0)
            Formpetugas.datagadai.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Gadai : " & ex.Message, "Data Gadai", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub pop_up_perpanjangan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        transaksigadai()
    End Sub
End Class