Imports System.Data.Odbc
Public Class SURAT_PEGADAIAN_PETUGAS

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        PrintForm1.PrintAction = Printing.PrintAction.PrintToPreview
        PrintForm1.Print()
    End Sub


    Private Sub SURAT_PEGADAIAN_PETUGAS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        gadai()
    End Sub
    Sub gadai()
        Try
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "SELECT  barang.*, nasabah.*, petugas.*, transaksi.* FROM barang, nasabah, petugas, transaksi where transaksi.no_transaksi='" & konfirmasi_gadai_petugas.TextBox1.Text & "' and barang.kodebarang='" & konfirmasi_gadai_petugas.TextBox2.Text & "' and petugas.nip='" & konfirmasi_gadai_petugas.TextBox3.Text & "' and nasabah.ktp='" & konfirmasi_gadai_petugas.TextBox4.Text & "'"
            cmd.CommandText = query
            da = New OdbcDataAdapter(query, con)
            rd = cmd.ExecuteReader
            rd.Read()
            If rd.HasRows() Then
                no.Text = rd("no_transaksi")
                tg.Text = rd("tgl_gadai")
                jt.Text = rd("jatuh_tempo")
                jp.Text = rd("jumlah_pinjaman")
                jtn.Text = rd("jumlah_tebusan")
                kb.Text = rd("barang_kode_barang")
                nip.Text = rd("petugas_nip")
                ktp.Text = rd("nasabah_ktp")
                bg.Text = rd("bunga")
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