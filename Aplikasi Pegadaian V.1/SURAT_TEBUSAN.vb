Imports System.Data.Odbc
Public Class SURAT_TEBUSAN

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        PrintForm1.Print()
    End Sub

    Private Sub SURAT_TEBUSAN_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        tebusan()
    End Sub
    Sub tebusan()
        Try
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "SELECT  barang.*, nasabah.*, petugas.*, transaksi.* FROM barang, nasabah, petugas, transaksi where transaksi.no_transaksi='" & konfirmasi_tebusan.TextBox1.Text & "' and barang.kodebarang='" & konfirmasi_tebusan.TextBox2.Text & "' and petugas.nip='" & konfirmasi_tebusan.TextBox3.Text & "' and nasabah.ktp='" & konfirmasi_tebusan.TextBox4.Text & "'"
            cmd.CommandText = query
            da = New OdbcDataAdapter(query, con)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows() Then
                no.Text = rd("no_transaksi")
                tanggaltebusan.Text = rd("tgl_tebusan")
                totaltebusa.Text = rd("total_tebusan")
                denda.Text = rd("denda")
                keteranagan.Text = rd("keterangan")
                nb.Text = rd("namabarang")
                kodebarang.Text = rd("barang_kode_barang")
                nip.Text = rd("petugas_nip")
                ktp.Text = rd("nasabah_ktp")
                bayar.Text = rd("bayar")
                kembalain.Text = rd("kembalian")
                nb.Text = rd("namabarang")
                nn.Text = rd("nama")
                nm1.Text = rd("nama")
                np2.Text = rd("namapetugas")
                np.Text = rd("namapetugas")
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class