Imports System.Data.Odbc
Public Class pop_up_transaksi_petugas

    Private Sub pop_up_transaksi_petugas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        koneksi()
        transaksigadai()
    End Sub

    Sub transaksigadai()
        Dim status As String
        status = "Tergadai"
        ds = New DataSet
        query = "select transaksi.no_transaksi,petugas.namapetugas,nasabah.nama,barang.namabarang,transaksi.tgl_gadai,transaksi.jatuh_tempo, " & _
           "transaksi.jumlah_pinjaman,transaksi.bunga,transaksi.jumlah_tebusan,barang.kodebarang,barang.status from transaksi,petugas,nasabah,barang where transaksi.petugas_nip= " & _
           "petugas.nip and transaksi.nasabah_ktp=nasabah.ktp and transaksi.barang_kode_barang=barang.kodebarang and status='" & status & "'"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            datagadai.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Transaksi : " & ex.Message, "Data Transaksi", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Dim status As String
        status = "Tergadai"
        ds = New DataSet
        query = "select transaksi.no_transaksi,petugas.namapetugas,nasabah.nama,barang.namabarang,transaksi.tgl_gadai,transaksi.jatuh_tempo, " & _
           "transaksi.jumlah_pinjaman,transaksi.bunga,transaksi.jumlah_tebusan,barang.kodebarang,barang.status from transaksi,petugas,nasabah,barang where transaksi.petugas_nip= " & _
           "petugas.nip and transaksi.nasabah_ktp=nasabah.ktp and transaksi.barang_kode_barang=barang.kodebarang and status='" & status & "' and no_transaksi like '%" & TextBox3.Text & "%'"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            datagadai.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Gadai : " & ex.Message, "Pencarian gadai", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub datagadai_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles datagadai.CellClick
        Try
            Dim i As Integer
            i = datagadai.CurrentRow.Index
            'admin
            'Formadmin.txtnotransaksitebusan.Text = datagadai.Item(0, i).Value
            'Formadmin.txtjumlahpinjamatebusan.Text = datagadai.Item(6, i).Value
            'Formadmin.txtjumlahtebusan_.Text = datagadai.Item(8, i).Value
            'Formadmin.txttotaltebusan.Text = datagadai.Item(8, i).Value
            'Formadmin.txttanggalgadai_.Text = datagadai.Item(4, i).Value
            'Formadmin.txtjatuhtempo_.Text = datagadai.Item(5, i).Value
            'Formadmin.labelkodebarang_.Text = datagadai.Item(9, i).Value
            'petugas
            Formpetugas.txtnotransaksitebusan.Text = datagadai.Item(0, i).Value
            Formpetugas.txtjumlahpinjamatebusan.Text = datagadai.Item(6, i).Value
            Formpetugas.txtjumlahtebusan_.Text = datagadai.Item(8, i).Value
            Formpetugas.txttotaltebusan.Text = datagadai.Item(8, i).Value
            Formpetugas.txttanggalgadai_.Text = datagadai.Item(4, i).Value
            Formpetugas.txtjatuhtempo_.Text = datagadai.Item(5, i).Value
            Formpetugas.labelkodebarang_.Text = datagadai.Item(9, i).Value
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        transaksigadai()
    End Sub
End Class