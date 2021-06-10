
Imports System.Data.Odbc
'Imports System.IO
Public Class Formadmin
  
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel6.Text = Today
        ToolStripStatusLabel4.Text = TimeOfDay
    End Sub
    Sub nama()
        dt = New DataTable()
        query = "select *from petugas where password='" & Formlogin.TextBox2.Text & "'"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(dt)
            ToolStripStatusLabel1.Text = dt.Rows(0)(1)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub Formadmin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try


            'TODO: This line of code loads data into the 'DataSet_KU.data_transaksi' table. You can move, or remove it, as needed.
            'Me.data_transaksiTableAdapter.Fill(Me.DataSet_KU.data_transaksi)
            ''TODO: This line of code loads data into the 'DataSet_KU.datapetugas' table. You can move, or remove it, as needed.
            'Me.datapetugasTableAdapter.Fill(Me.DataSet_KU.datapetugas)
            ''TODO: This line of code loads data into the 'DataSet_KU.data_nasabah' table. You can move, or remove it, as needed.
            'Me.data_nasabahTableAdapter.Fill(Me.DataSet_KU.data_nasabah)
            ''TODO: This line of code loads data into the 'DataSet_KU.data_brang' table. You can move, or remove it, as needed.
            'Me.data_brangTableAdapter.Fill(Me.DataSet_KU.data_brang)


            '============ laporan
            koneksi()
            nama()
            '=========barang
            barang()
            kodebarang()
            '==========nsabah
            nasabah()
            '===========petugas
            petugas()
            kodepetugas()
            '=============transaksi
            transaksigadai()
            nippetugas()
            kodetransaksi()
            transaksi()
            transaksitebusan()
            '============fitur lain
            aturdgv()
            '================REFRESH
            segar()
        Catch ex As Exception

        End Try
    End Sub

    Sub segar()
        nama()
        barang()
        nasabah()
        petugas()
        nippetugas()
        transaksi()
        transaksigadai()
        transaksitebusan()
        kodebarang()
        kodepetugas()
        kodetransaksi()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlogout.Click
        If MsgBox("Yakin ingin logout ?", vbYesNo) = vbYes Then
            Formlogin.Show()
            Me.Close()
        End If

    End Sub


    '=================== BARANG ==================================================================================

    Sub barang()
        ds = New DataSet
        query = "select*from barang"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            databarang.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Barang  : " & ex.Message, "Peringatan", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
    Sub barang1()
        ds = New DataSet
        query = "select*from barang"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            Formpetugas.databarang.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Barang  : " & ex.Message, "Peringatan", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
    Sub kodebarang()
        Try
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "select * from barang order by kodebarang desc"
            cmd.CommandText = query
            da = New OdbcDataAdapter(query, con)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                txtkodebarang.Text = "BR" + "0001"
            Else
                txtkodebarang.Text = Val(Microsoft.VisualBasic.Mid(rd.Item("kodebarang").ToString, 4, 3)) + 1
                If Len(txtkodebarang.Text) = 1 Then
                    txtkodebarang.Text = "BR000" & txtkodebarang.Text & ""
                ElseIf Len(txtkodebarang.Text) = 2 Then
                    txtkodebarang.Text = "BR00" & txtkodebarang.Text & ""
                ElseIf Len(txtkodebarang.Text) = 3 Then
                    txtkodebarang.Text = "BR0" & txtkodebarang.Text & ""
                End If
            End If

        Catch ex As Exception

        End Try
        rd.Close()
    End Sub
    Private Sub EditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem.Click
        Try

            With databarang
                txtkodebarang.Text = .Item(0, .CurrentRow.Index).Value
                txtnamabarang.Text = .Item(1, .CurrentRow.Index).Value
                txttypebarang.Text = .Item(2, .CurrentRow.Index).Value
                txtwarnabarang.Text = .Item(3, .CurrentRow.Index).Value
                btnsimpanbarang.Visible = False
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncelarbarang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncelarbarang.Click
        CLEAR()
    End Sub
    Sub CLEAR()
        kodebarang()
        txtnamabarang.Clear()
        txttypebarang.Clear()
        txtwarnabarang.Clear()
        txtnamabarang.Focus()
        btnsimpanbarang.Visible = True
    End Sub

    Private Sub HapusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HapusToolStripMenuItem.Click

        With databarang
            labelkode.Text = .Item(0, .CurrentRow.Index).Value
        End With
        If MsgBox("Yakin barang ingin dihapus ?", vbYesNo) = vbYes Then
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "DELETE FROM `barang` WHERE kodebarang='" & labelkode.Text & "'"
            cmd.CommandText = query
            Try
                cmd.ExecuteNonQuery()
                barang()
                barang1()
                CLEAR()
                'data_brangTableAdapter.Fill(Me.DataSet_KU.data_brang)
                'laporanbarang.RefreshReport()
            Catch ex As Exception
                MessageBox.Show("Barang : " & ex.Message, "Hapus Barang", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If

    End Sub

    Private Sub btnsimpanbarang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpanbarang.Click

        If txtkodebarang.Text = "" Or txtnamabarang.Text = "" Or txttypebarang.Text = "" Or txtwarnabarang.Text = "" Then
            MsgBox("Field Harus Lengkap !")
        Else
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "insert into barang values('" & txtkodebarang.Text & "','" & txtnamabarang.Text & "','" & txttypebarang.Text & "','" & txtwarnabarang.Text & "','" & labelstatus.Text & "')"
            cmd.CommandText = query
            Try
                cmd.ExecuteNonQuery()
                barang()
                barang1()
                CLEAR()
                'data_brangTableAdapter.Fill(Me.DataSet_KU.data_brang)
                'laporanbarang.RefreshReport()
            Catch ex As Exception
                MessageBox.Show("Barang : " & ex.Message, "Simpan Barang", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub btneditbarang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneditbarang.Click
        If txtkodebarang.Text = "" Or txtnamabarang.Text = "" Or txttypebarang.Text = "" Or txtwarnabarang.Text = "" Then
            MsgBox("Field Harus Lengkap !")
        Else
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "UPDATE barang SET namabarang = '" & txtnamabarang.Text & "', type = '" & txttypebarang.Text & "', warna='" & txtwarnabarang.Text & "' where kodebarang='" & txtkodebarang.Text & "'"
            cmd.CommandText = query
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Edit barang berhasil ")
                barang()
                barang1()
                CLEAR()
                'data_brangTableAdapter.Fill(Me.DataSet_KU.data_brang)
                'laporanbarang.RefreshReport()
            Catch ex As Exception
                MessageBox.Show("Barang : " & ex.Message, "Edit Barang", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub


    Private Sub TXTFILTERBARANG2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TXTFILTERBARANG2.TextChanged
        ds = New DataSet
        query = "select*from barang where kodebarang like '%" & TXTFILTERBARANG2.Text & "%' or namabarang like '%" & TXTFILTERBARANG2.Text & "%' or type like '%" & TXTFILTERBARANG2.Text & "%' or warna like '%" & TXTFILTERBARANG2.Text & "%' or status like '%" & TXTFILTERBARANG2.Text & "%'"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            databarang.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Barang : " & ex.Message, "Pencarian Barang", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    '============================= NASABAH ====================================================================

    Sub nasabah()
        ds = New DataSet
        query = "select*from nasabah"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            datanasabah.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Nasabah : " & ex.Message, "Data Nasabah", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
    Sub nasabah1()
        ds = New DataSet
        query = "select*from nasabah"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            Formpetugas.datanasabah.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Nasabah : " & ex.Message, "Data Nasabah", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub
    Private Sub btnsimpannasabah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpannasabah.Click
        If txtnamansabah.Text = "" Or txtnohpnasabah.Text = "" Or txtnoktpnasabah.Text = "" Or txtalamatnasabah.Text = "" Then
            MsgBox("Field Harus Lengkap !")
        Else
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "insert into nasabah values('" & txtnoktpnasabah.Text & "','" & txtnamansabah.Text & "'," & _
                "'" & txtalamatnasabah.Text & "','" & txtnohpnasabah.Text & "')"
            cmd.CommandText = query
            Try
                cmd.ExecuteNonQuery()
                nasabah()
                nasabah1()
                bersihnasabah()
                'data_nasabahTableAdapter.Fill(Me.DataSet_KU.data_nasabah)
                'laporannasabah.RefreshReport()
            Catch ex As Exception
                MessageBox.Show("Nasabah : " & ex.Message, "Simpan Nasabah", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub btneditnasabah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneditnasabah.Click
        If txtnamansabah.Text = "" Or txtnohpnasabah.Text = "" Or txtnoktpnasabah.Text = "" Or txtalamatnasabah.Text = "" Then
            MsgBox("Field Harus Lengkap !")
        Else
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "update  nasabah set ktp='" & txtnoktpnasabah.Text & "',nama='" & txtnamansabah.Text & "',alamat='" & txtalamatnasabah.Text & "',hp='" & txtnohpnasabah.Text & "' where ktp='" & labelkodenasabah.Text & "'"
            cmd.CommandText = query
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Edit nasabah berhasil ")
                nasabah()
                nasabah1()
                bersihnasabah()
                'data_nasabahTableAdapter.Fill(Me.DataSet_KU.data_nasabah)
                'laporannasabah.RefreshReport()
            Catch ex As Exception
                MessageBox.Show("Nasabah : " & ex.Message, "Edit Nasabah", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub btncancelnasabah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelnasabah.Click
        bersihnasabah()
    End Sub

    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        Try

            With datanasabah
                labelkodenasabah.Text = .Item(0, .CurrentRow.Index).Value
                txtnoktpnasabah.Text = .Item(0, .CurrentRow.Index).Value
                txtnamansabah.Text = .Item(1, .CurrentRow.Index).Value
                txtalamatnasabah.Text = .Item(2, .CurrentRow.Index).Value
                txtnohpnasabah.Text = .Item(3, .CurrentRow.Index).Value
                btnsimpannasabah.Visible = False
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        With datanasabah
            labelkodenasabah.Text = .Item(0, .CurrentRow.Index).Value
        End With
        If MsgBox("Yakin Nasabah ingin dihapus ?", vbYesNo) = vbYes Then
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "DELETE FROM `nasabah` WHERE ktp='" & labelkodenasabah.Text & "'"
            cmd.CommandText = query
            Try
                cmd.ExecuteNonQuery()
                nasabah()
                nasabah1()
                bersihnasabah()
                'data_nasabahTableAdapter.Fill(Me.DataSet_KU.data_nasabah)
                'laporannasabah.RefreshReport()
            Catch ex As Exception
                MessageBox.Show("Nasabah : " & ex.Message, "Hapus Nasabah", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Sub bersihnasabah()
        txtnoktpnasabah.Text = ""
        txtnohpnasabah.Text = ""
        txtalamatnasabah.Text = ""
        txtnamansabah.Text = ""
        txtnoktpnasabah.Focus()
        btnsimpannasabah.Visible = True
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        ds = New DataSet
        query = "select*from nasabah where ktp like '%" & TextBox5.Text & "%' or nama like '%" & TextBox5.Text & "%' or alamat like '%" & TextBox5.Text & "%' or hp like '%" & TextBox5.Text & "%' "
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            datanasabah.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Nasabah : " & ex.Message, "Pencarian Nasabah", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub txtnoktpnasabah_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtnoktpnasabah.TextChanged
        If txtnoktpnasabah.TextLength = 16 Then
            txtnoktpnasabah.ForeColor = Color.Green
        Else
            txtnoktpnasabah.ForeColor = Color.Red
        End If
    End Sub

    '==============================PETUGAS ======================================================================

    Sub petugas()
        ds = New DataSet
        query = "select*from petugas"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            datapetugas.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Petugas : " & ex.Message, "Data Petugas", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    Sub kodepetugas()
        Try

            cmd = New OdbcCommand
            cmd.Connection = con
            query = "select * from petugas order by nip desc"
            cmd.CommandText = query
            da = New OdbcDataAdapter(query, con)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                txtnippetugas.Text = "P" + "0001"
            Else
                txtnippetugas.Text = Val(Microsoft.VisualBasic.Mid(rd.Item("nip").ToString, 4, 3)) + 1
                If Len(txtnippetugas.Text) = 1 Then
                    txtnippetugas.Text = "P000" & txtnippetugas.Text & ""
                ElseIf Len(txtnippetugas.Text) = 2 Then
                    txtnippetugas.Text = "P00" & txtnippetugas.Text & ""
                ElseIf Len(txtnippetugas.Text) = 3 Then
                    txtnippetugas.Text = "P0" & txtnippetugas.Text & ""
                End If

            End If

        Catch ex As Exception

        End Try
        rd.Close()
    End Sub

    Private Sub btnsimpanpetugas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpanpetugas.Click
        If txtnippetugas.Text = "" Or txtnamapetugas.Text = "" Or combohakakses.Text = "" Or txtpassword.Text = "" Or txtusername.Text = "" Or txtalamatpetugas.Text = "" Then
            MsgBox("Field Harus Lengkap !")
        Else
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "insert into petugas values('" & txtnippetugas.Text & "','" & txtnamapetugas.Text & "'," & _
                "'" & txtalamatpetugas.Text & "','" & txtusername.Text & "','" & txtpassword.Text & "','" & combohakakses.Text & "')"
            cmd.CommandText = query
            Try
                cmd.ExecuteNonQuery()
                petugas()
                bersihpetugas()
                'datapetugasTableAdapter.Fill(Me.DataSet_KU.datapetugas)
                'laporanpetugas.RefreshReport()
            Catch ex As Exception
                MessageBox.Show("Petugas : " & ex.Message, "Simpan Petugas", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub btneditpetugas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btneditpetugas.Click
        If txtnippetugas.Text = "" Or txtnamapetugas.Text = "" Or combohakakses.Text = "" Or txtpassword.Text = "" Or txtusername.Text = "" Or txtalamatpetugas.Text = "" Then
            MsgBox("Field Harus Lengkap !")
        Else
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "update petugas set nip='" & txtnippetugas.Text & "',namapetugas='" & txtnamapetugas.Text & "',alamat='" & txtalamatpetugas.Text & "',username='" & txtusername.Text & "',hakakses='" & combohakakses.Text & "' where nip='" & Labelnip.Text & "'"
            cmd.CommandText = query
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Edit petugas berhasil ")
                petugas()
                bersihpetugas()
                nama()
                nippetugas()
                'datapetugasTableAdapter.Fill(Me.DataSet_KU.datapetugas)
                'laporanpetugas.RefreshReport()
                txtpassword.Enabled = True
            Catch ex As Exception
                MessageBox.Show("Petugas : " & ex.Message, "Edit Petugas", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub btncancelpetugas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelpetugas.Click
        bersihpetugas()
    End Sub

    Private Sub ToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem3.Click
        Try
            With datapetugas
                Labelnip.Text = .Item(0, .CurrentRow.Index).Value
                txtnippetugas.Text = .Item(0, .CurrentRow.Index).Value
                txtnamapetugas.Text = .Item(1, .CurrentRow.Index).Value
                txtalamatpetugas.Text = .Item(2, .CurrentRow.Index).Value
                txtusername.Text = .Item(3, .CurrentRow.Index).Value
                txtpassword.Text = .Item(4, .CurrentRow.Index).Value
                combohakakses.Text = .Item(5, .CurrentRow.Index).Value
                btnsimpanpetugas.Visible = False
                txtpassword.Enabled = False
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem4.Click
        With datapetugas
            Labelnip.Text = .Item(0, .CurrentRow.Index).Value
        End With
        If MsgBox("Yakin Petugas ingin dihapus ?", vbYesNo) = vbYes Then
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "DELETE FROM `petugas` WHERE nip = '" & Labelnip.Text & "'"
            cmd.CommandText = query
            Try
                cmd.ExecuteNonQuery()
                petugas()
                bersihpetugas()
                'datapetugasTableAdapter.Fill(Me.DataSet_KU.datapetugas)
                'laporanpetugas.RefreshReport()
            Catch ex As Exception
                MessageBox.Show("Petugas : " & ex.Message, "Hapus Petugas", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub

    Private Sub TextBox6_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox6.TextChanged
        ds = New DataSet
        query = "select*from petugas where nip like '%" & TextBox6.Text & "%' or namapetugas like '%" & TextBox6.Text & "%' or alamat like '%" & TextBox6.Text & "%' or username like '%" & TextBox6.Text & "%' "
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            datapetugas.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Petugas : " & ex.Message, "Pencarian Petugas", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub bersihpetugas()
        txtnippetugas.Text = ""
        txtnamapetugas.Text = ""
        txtalamatpetugas.Text = ""
        txtusername.Text = ""
        txtpassword.Text = ""
        combohakakses.Text = "--pilih--"
        txtnippetugas.Focus()
        btnsimpanpetugas.Visible = True
        kodepetugas()
    End Sub

    '=============================== FITUR LAINNYA========================================================

    Sub aturdgv()
        Try

            With databarang

                .Columns(0).HeaderText = "KODE"
                .Columns(0).Width = 120
                .Columns(1).HeaderText = "Nama Barang"
                .Columns(1).Width = 270
                .Columns(2).HeaderText = "Type"
                .Columns(2).Width = 130
                .Columns(3).HeaderText = "Warna"
                .Columns(3).Width = 150
                .Columns(4).HeaderText = "Status"
                .Columns(4).Width = 210


                databarang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                databarang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                databarang.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver
            End With

            With datanasabah

                .Columns(0).HeaderText = "KTP"
                .Columns(0).Width = 120
                .Columns(1).HeaderText = "Nama Nasabah"
                .Columns(1).Width = 270
                .Columns(2).HeaderText = "Alamat"
                .Columns(2).Width = 270
                .Columns(3).HeaderText = "NO.HP"
                .Columns(3).Width = 150


                datanasabah.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                datanasabah.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                datanasabah.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver
            End With

            With datapetugas

                .Columns(0).HeaderText = "NIP"
                .Columns(0).Width = 120
                .Columns(1).HeaderText = "Nama Petugas"
                .Columns(1).Width = 230
                .Columns(2).HeaderText = "Alamat"
                .Columns(2).Width = 230
                .Columns(3).HeaderText = "Username"
                .Columns(3).Width = 170
                .Columns(4).HeaderText = "Password"
                .Columns(4).Width = 150
                .Columns(5).HeaderText = "Hak Akses"
                .Columns(5).Width = 100


                databarang.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                databarang.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                databarang.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver
            End With

            With datagadai

                .Columns(0).HeaderText = "NO"
                .Columns(0).Width = 70
                .Columns(1).HeaderText = "Nama Petugas"
                .Columns(1).Width = 250
                .Columns(2).HeaderText = "Nama Nasabah"
                .Columns(2).Width = 200
                .Columns(3).HeaderText = "Nama Barang"
                .Columns(3).Width = 200
                .Columns(4).HeaderText = "Tanggal Gadai"
                .Columns(4).Width = 100
                .Columns(5).HeaderText = "Jatuh Tempo"
                .Columns(5).Width = 100
                .Columns(6).HeaderText = "Jumlah Pinjaman"
                .Columns(6).Width = 100
                .Columns(7).HeaderText = "Bunga"
                .Columns(7).Width = 100
                .Columns(8).HeaderText = "Jumlah Tebusan"
                .Columns(8).Width = 100
                .Columns(9).HeaderText = "Status"
                .Columns(9).Width = 100
                .Columns(10).HeaderText = "NIP Petugas"
                .Columns(11).HeaderText = "KTP Nasabah"
                .Columns(12).HeaderText = "Kode Barang"


                datagadai.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                datagadai.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                datagadai.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver
            End With
            With datatebusan

                .Columns(0).HeaderText = "NO"
                .Columns(0).Width = 70
                .Columns(1).HeaderText = "Nama Petugas"
                .Columns(1).Width = 250
                .Columns(2).HeaderText = "Nama Nasabah"
                .Columns(2).Width = 250
                .Columns(3).HeaderText = "Nama Barang"
                .Columns(3).Width = 250
                .Columns(4).HeaderText = "Tanggal Tebusan"
                .Columns(4).Width = 100
                .Columns(5).HeaderText = "Total Tebusan"
                .Columns(5).Width = 100
                .Columns(6).HeaderText = "Denda"
                .Columns(6).Width = 100
                .Columns(7).HeaderText = "Keterangan"
                .Columns(7).Width = 300
                .Columns(8).HeaderText = "Bayar"
                .Columns(8).Width = 100
                .Columns(9).HeaderText = "Kembalian"
                .Columns(9).Width = 100
                .Columns(10).HeaderText = "Status"
                .Columns(10).Width = 100
                .Columns(11).HeaderText = "NIP Petugas"
                .Columns(12).HeaderText = "KTP Nasabah"
                .Columns(13).HeaderText = "Kode Barang"


                datatebusan.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                datatebusan.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
                datatebusan.ColumnHeadersDefaultCellStyle.BackColor = Color.Silver
            End With

        Catch ex As Exception

        End Try
    End Sub

    '======================================TRANSAKSI - GADAI ================================================================
    Sub nippetugas()
        dt = New DataTable()
        query = "select * from petugas where namapetugas='" & ToolStripStatusLabel1.Text & "'"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(dt)
            txtnippetugastransaksi.Text = dt.Rows(0)(0)
            txtnamapetugastransaksi.Text = dt.Rows(0)(1)
        Catch ex As Exception

        End Try
    End Sub
    Sub transaksigadai()
        Dim status As String
        status = "Tergadai"
        ds = New DataSet
        query = "select transaksi.no_transaksi,petugas.namapetugas,nasabah.nama,barang.namabarang,transaksi.tgl_gadai,transaksi.jatuh_tempo, " & _
            "transaksi.jumlah_pinjaman,transaksi.bunga,transaksi.jumlah_tebusan,barang.status,transaksi.petugas_nip,transaksi.nasabah_ktp,transaksi.barang_kode_barang from transaksi,petugas,nasabah,barang where transaksi.petugas_nip= " & _
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
    Sub transaksigadai1()
        Dim status As String
        status = "Tergadai"
        ds = New DataSet
        query = "select transaksi.no_transaksi,petugas.namapetugas,nasabah.nama,barang.namabarang,transaksi.tgl_gadai,transaksi.jatuh_tempo, " & _
            "transaksi.jumlah_pinjaman,transaksi.bunga,transaksi.jumlah_tebusan,barang.status,transaksi.petugas_nip,transaksi.nasabah_ktp,transaksi.barang_kode_barang from transaksi,petugas,nasabah,barang where transaksi.petugas_nip= " & _
            "petugas.nip and transaksi.nasabah_ktp=nasabah.ktp and transaksi.barang_kode_barang=barang.kodebarang and status='" & status & "'"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            Formpetugas.datagadai.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Transaksi : " & ex.Message, "Data Transaksi", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub kodetransaksi()
        Try
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "select * from transaksi order by no_transaksi desc"
            cmd.CommandText = query
            da = New OdbcDataAdapter(query, con)
            rd = cmd.ExecuteReader
            rd.Read()
            If Not rd.HasRows Then
                txtnotransaksi.Text = "TR" + "0001"
            Else
                txtnotransaksi.Text = Val(Microsoft.VisualBasic.Mid(rd.Item("no_transaksi").ToString, 4, 3)) + 1
                If Len(txtnotransaksi.Text) = 1 Then
                    txtnotransaksi.Text = "TR000" & txtnotransaksi.Text & ""
                ElseIf Len(txtnotransaksi.Text) = 2 Then
                    txtnotransaksi.Text = "TR00" & txtnotransaksi.Text & ""
                ElseIf Len(txtnotransaksi.Text) = 3 Then
                    txtnotransaksi.Text = "TR0" & txtnotransaksi.Text & ""
                End If
            End If

        Catch ex As Exception

        End Try
        rd.Close()
    End Sub

    Private Sub btnsimpangadai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpangadai.Click
        Dim perjanjian As String
        perjanjian = "JIKA BARANG JAMINAN TIDAK DILUNASKAN DAN TIDAK DIPERPANJANG SEBELUM TANGGAL JATUH TEMPO MAKA PIHAK PEGGADAIAN AKAN LELANG BARANG JAMINAN ANDA,PADA 1 HARI SETELAH TANGGAL JATUH TEMPO"
        If txtnotransaksi.Text = "" Or txtnippetugastransaksi.Text = "" Or txtnamapetugastransaksi.Text = "" Or labelkodenasbahtransaksi.Text = "" Or _
            labelkodebrang.Text = "" Or txttanggalgadai.Text = "" Or txtjatuhtempo.Text = "" Or txtjmlpinjma.Text = "" _
             Or labelkodenasbahtransaksi.Text = "" Or labelkodenasbahtransaksi.Text = "" Then
            MsgBox("Field Harus Lengkap !")
        Else
            Dim status As String
            status = "Tergadai"
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "INSERT INTO `transaksi`(`No_transaksi`, `Tgl_gadai`, `Jatuh_tempo`, `Jumlah_pinjaman`, `Tgl_tebusan`, `Jumlah_tebusan`, `denda`, `Bunga`, `total_tebusan`, `Keterangan`, `Barang_Kode_barang`, `Petugas_Nip`, `Nasabah_Ktp`, `bayar`, `kembalian`, `perjanjian`) VALUES ('" & txtnotransaksi.Text & "','" & txttanggalgadai.Text & "'," & _
                "'" & txtjatuhtempo.Text & "','" & txtjmlpinjma.Text & "',null,'" & txtjmltebusan.Text & "',null,'" & txtbunga.Text & "',null,null ," & _
                "'" & labelkodebrang.Text & "','" & txtnippetugastransaksi.Text & "','" & labelkodenasbahtransaksi.Text & "',null,null,'" & perjanjian & "')" ',update barang set status='" & status & "' where kodebarang='" & labelkodebrang.Text & "'"
            cmd.CommandText = query
            Try
                cmd.ExecuteNonQuery()
                updatestatus()
                MsgBox("Penggadaian Behasil ! ")
                transaksigadai()
                transaksigadai1()
                transaksi()
                transaksi1()
                kodetransaksi()
                bersihgadai()
                barang()
                barang1()
                'data_transaksiTableAdapter.Fill(Me.DataSet_KU.data_transaksi)
                'laporantransaksi.RefreshReport()
            Catch ex As Exception
                MessageBox.Show("Transaksi Gadai : " & ex.Message, "Simpan Gadai", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub
    Sub updatestatus()
        Dim status As String
        status = "Tergadai"
        cmd = New OdbcCommand
        cmd.Connection = con
        query = "update barang set status='" & status & "' where kodebarang='" & labelkodebrang.Text & "'"
        cmd.CommandText = query
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btncancelgadai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelgadai.Click
        bersihgadai()
    End Sub

    Private Sub ToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem6.Click
        With datagadai
            txtnotransaksi.Text = .Item(0, .CurrentRow.Index).Value
            labelnamabarang.Text = .Item(3, .CurrentRow.Index).Value
        End With
        If MsgBox("Yakin Data GADAI ingin dihapus ?", vbYesNo) = vbYes Then
            Dim status As String
            status = "Tersedia"
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "DELETE FROM `transaksi` WHERE no_transaksi = '" & txtnotransaksi.Text & "'"
            cmd.CommandText = query
            Try
                cmd.ExecuteNonQuery()
                updatestatus2()
                transaksigadai()
                transaksigadai1()
                barang1()
                transaksi1()
                bersihgadai()
                kodetransaksi()
                barang()
                transaksi()
                'data_transaksiTableAdapter.Fill(Me.DataSet_KU.data_transaksi)
                'laporantransaksi.RefreshReport()
            Catch ex As Exception
                MessageBox.Show("Gadai : " & ex.Message, "Hapus Data Gadai", _
                MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub
    Sub updatestatus2()
        Dim status As String
        status = "Tersedia"
        cmd = New OdbcCommand
        cmd.Connection = con
        query = "update barang set status='" & status & "'where namabarang='" & labelnamabarang.Text & "'"
        cmd.CommandText = query
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

            If txtjmlpinjma.Text = "" Or TextBox7.Text = "" Then

                MsgBox("Jumlah Pinjam/Bunga Tidak Boleh Kosong !")
            Else
                txtjmltebusan.Text = Val(txtjmlpinjma.Text) + Val((txtjmlpinjma.Text * TextBox7.Text) / 100)
                txtbunga.Text = Val(txtjmlpinjma.Text * TextBox7.Text) / 100
            End If

        Catch ex As Exception

        End Try

    End Sub
    Sub bersihgadai()
        txtnamabarangtarnsaksi.Text = ""
        txtnamnasabahtaransaki.Text = ""
        txtjmlpinjma.Text = ""
        txtjmltebusan.Text = ""
        txtbunga.Text = ""
        TextBox7.Text = ""
        txttanggalgadai.Refresh()
        txtjatuhtempo.Refresh()
        txtjmlpinjma.Focus()
    End Sub

    Private Sub btncarabarang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncarabarang.Click
        pop_up_barang.Show()
    End Sub

    Private Sub btncarinasabah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncarinasabah.Click
        pop_up_nasabah.Show()
    End Sub

    Private Sub TextBox3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox3.TextChanged
        Dim status As String
        status = "Tergadai"
        ds = New DataSet
        query = "select transaksi.no_transaksi,petugas.namapetugas,nasabah.nama,barang.namabarang,transaksi.tgl_gadai,transaksi.jatuh_tempo, " & _
           "transaksi.jumlah_pinjaman,transaksi.bunga,transaksi.jumlah_tebusan,barang.status,transaksi.petugas_nip,transaksi.nasabah_ktp,transaksi.barang_kode_barang from transaksi,petugas,nasabah,barang where transaksi.petugas_nip= " & _
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


    '=================================== TRANSAKSI TEBUSAN ===========================================================
    Sub transaksitebusan()
        Dim status As String
        status = "Sudah Ditebus"
        ds = New DataSet
        query = "select transaksi.no_transaksi,petugas.namapetugas,nasabah.nama,barang.namabarang, " & _
            "transaksi.tgl_tebusan,transaksi.total_tebusan,transaksi.denda,transaksi.keterangan,transaksi.bayar,transaksi.kembalian,barang.status,transaksi.petugas_nip,transaksi.nasabah_ktp,transaksi.barang_kode_barang from transaksi,petugas,nasabah,barang where transaksi.petugas_nip= " & _
            "petugas.nip and transaksi.nasabah_ktp=nasabah.ktp and transaksi.barang_kode_barang=barang.kodebarang and status='" & status & "'"
        '   query = "select*from transaksi"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            datatebusan.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Transaksi : " & ex.Message, "Data Transaksi", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub transaksitebusan1()
        Dim status As String
        status = "Sudah Ditebus"
        ds = New DataSet
        query = "select transaksi.no_transaksi,petugas.namapetugas,nasabah.nama,barang.namabarang, " & _
            "transaksi.tgl_tebusan,transaksi.total_tebusan,transaksi.denda,transaksi.keterangan,transaksi.bayar,transaksi.kembalian,barang.status,transaksi.petugas_nip,transaksi.nasabah_ktp,transaksi.barang_kode_barang from transaksi,petugas,nasabah,barang where transaksi.petugas_nip= " & _
            "petugas.nip and transaksi.nasabah_ktp=nasabah.ktp and transaksi.barang_kode_barang=barang.kodebarang and status='" & status & "'"
        '   query = "select*from transaksi"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            Formpetugas.datatebusan.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Transaksi : " & ex.Message, "Data Transaksi", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub btnhitungtebusan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnhitungtebusan.Click
        Try
            txtkembalian.Text = Val(txtbayar.Text) - Val(txttotaltebusan.Text)
            btnhitungtebusan.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            txttotaltebusan.Text = Val(txtdenda.Text) + Val(txttotaltebusan.Text)
            Button2.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtbayar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtbayar.TextChanged
        If txttotaltebusan.Text > txtbayar.Text Then
            txtbayar.ForeColor = Color.Red
        Else
            txtbayar.ForeColor = Color.Green
        End If
    End Sub

    Private Sub EditToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditToolStripMenuItem1.Click
        pop_up_perpanjangan.Show()
        Try
            With datagadai
                pop_up_perpanjangan.Labelno.Text = .Item(0, .CurrentRow.Index).Value
                pop_up_perpanjangan.DateTimePicker3.Text = .Item(5, .CurrentRow.Index).Value
                pop_up_perpanjangan.Labelpinjman.Text = .Item(6, .CurrentRow.Index).Value
                pop_up_perpanjangan.Labelbunga.Text = .Item(7, .CurrentRow.Index).Value
                pop_up_perpanjangan.Labeltebusan.Text = .Item(8, .CurrentRow.Index).Value
            End With
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btncanceltebusan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncanceltebusan.Click
        bersihtebusan()
    End Sub
    Sub bersihtebusan()
        txtnotransaksitebusan.Text = ""
        'txtnippetugastransaksi.Text = ""
        'txtnamapetugastransaksi.Text = ""
        txtnamabarangtarnsaksi.Text = ""
        txtnamnasabahtaransaki.Text = ""
        txtjumlahpinjamatebusan.Text = ""
        txtjumlahtebusan_.Text = ""
        txtbayar.Text = ""
        txtkembalian.Text = ""
        txtdenda.Text = ""
        txtketerangan.Text = ""
        txtjatuhtempo_.Refresh()
        txttanggalgadai_.Refresh()
        txttanggaltebusan.Refresh()
        btnhitungtebusan.Enabled = True
        Button2.Enabled = True
    End Sub

    Private Sub datatebusan_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles datatebusan.CellClick
        'Try
        '    Dim i As Integer
        '    i = datatebusan.CurrentRow.Index
        '    txtnotransaksitebusan.Text = datatebusan.Item(0, i).Value
        '    txtjumlahpinjamatebusan.Text = datatebusan.Item(6, i).Value
        '    txtjumlahtebusan_.Text = datatebusan.Item(8, i).Value
        '    txttotaltebusan.Text = datatebusan.Item(8, i).Value
        '    txttanggalgadai_.Text = datatebusan.Item(4, i).Value
        '    txtjatuhtempo_.Text = datatebusan.Item(5, i).Value
        'Catch ex As Exception

        'End Try
    End Sub

    Private Sub TextBox8_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox8.TextChanged
        Dim status As String
        status = "Sudah Ditebus"
        ds = New DataSet
        query = "select transaksi.no_transaksi,petugas.namapetugas,nasabah.nama,barang.namabarang,transaksi.tgl_tebusan,transaksi.total_tebusan, " & _
           "transaksi.denda,transaksi.keterangan,transaksi.bayar,transaksi.kembalian,barang.status,transaksi.petugas_nip,transaksi.nasabah_ktp,transaksi.barang_kode_barang from transaksi,petugas,nasabah,barang where transaksi.petugas_nip= " & _
           "petugas.nip and transaksi.nasabah_ktp=nasabah.ktp and transaksi.barang_kode_barang=barang.kodebarang and status='" & status & "' and no_transaksi like '%" & TextBox8.Text & "%'"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            datatebusan.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Tebusan : " & ex.Message, "Pencarian Tebusan", _
              MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnsimpantebusan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsimpantebusan.Click

        If txtnotransaksitebusan.Text = "" Or _
            txttotaltebusan.Text = "" Or _
            txttanggaltebusan.Text = "" Then
            MsgBox("Field Tidak Boleh Kosong")
        Else
            Dim status As String
            status = "Sudah Ditebus"
            cmd = New OdbcCommand
            cmd.Connection = con
            query = "update transaksi set tgl_tebusan='" & txttanggaltebusan.Text & "',denda='" & txtdenda.Text & "',total_tebusan='" & txttotaltebusan.Text & "', " & _
                "keterangan='" & txtketerangan.Text & "',bayar='" & txtbayar.Text & "',kembalian='" & txtkembalian.Text & "' where no_transaksi='" & txtnotransaksitebusan.Text & "'"
            cmd.CommandText = query
            Try
                cmd.ExecuteNonQuery()
                MsgBox("Tebusan Berhasil ")
                updatestatus3()
                transaksitebusan()
                transaksitebusan1()
                transaksigadai()
                transaksigadai1()
                barang()
                barang1()
                transaksi()
                transaksi1()
                bersihtebusan()
                'data_transaksiTableAdapter.Fill(Me.DataSet_KU.data_transaksi)
                'laporantransaksi.RefreshReport()
            Catch ex As Exception
                MessageBox.Show("Transaksi : " & ex.Message, "Data Transaksi", _
            MessageBoxButtons.OK, MessageBoxIcon.Information)
            End Try
        End If
    End Sub
    Sub updatestatus3()
        Dim status As String
        status = "Sudah Ditebus"
        cmd = New OdbcCommand
        cmd.Connection = con
        query = "update barang set status='" & status & "'where kodebarang='" & labelkodebarang_.Text & "'"
        cmd.CommandText = query
        Try
            cmd.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem7.Click
        'With datagadai
        '    txtnotransaksitebusan.Text = .Item(0, .CurrentRow.Index).Value
        '    labelnamabarang.Text = .Item(3, .CurrentRow.Index).Value
        'End With
        'If MsgBox("Yakin Data TEBUSAN ingin dihapus ?", vbYesNo) = vbYes Then
        '    Dim status As String
        '    status = "Tersedia"
        '    cmd = New OdbcCommand
        '    cmd.Connection = con
        '    query = "DELETE FROM `transaksi` WHERE no_transaksi = '" & txtnotransaksitebusan.Text & "';update barang set status='" & status & "'where namabarang='" & labelnamabarang.Text & "'"
        '    cmd.CommandText = query
        '    Try
        '        cmd.ExecuteNonQuery()
        '        transaksigadai()
        '        bersihgadai()
        '        kodetransaksi()
        '        barang()
        '    Catch ex As Exception
        '        MessageBox.Show("Tebusan : " & ex.Message, "Hapus Data Tebusan", _
        '        MessageBoxButtons.OK, MessageBoxIcon.Information)
        '    End Try
        ' End If
    End Sub

    '========================================= RIWAYAT TRANSAKSI ================================================================

    Sub transaksi()
        ds = New DataSet
        query = "SELECT  transaksi.*, barang.status FROM   transaksi, barang where transaksi.barang_kode_barang=barang.kodebarang"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            riwayattransaksi.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Transaksi : " & ex.Message, "Data Transaksi", _
          MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Sub transaksi1()
        ds = New DataSet
        query = "SELECT  transaksi.*, barang.status FROM   transaksi, barang where transaksi.barang_kode_barang=barang.kodebarang"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            Formpetugas.riwayattransaksi.DataSource = ds.Tables(0)
        Catch ex As Exception
            MessageBox.Show("Transaksi : " & ex.Message, "Data Transaksi", _
          MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub TextBox10_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox10.TextChanged
        ds = New DataSet
        query = "SELECT  transaksi.*, barang.status FROM   transaksi, barang where transaksi.Barang_Kode_Barang=barang.kodebarang and no_transaksi like ='" & TextBox10.Text & "'"
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            riwayattransaksi.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try
    End Sub


    'CETAK TRANSAKSI

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        Try
            konfirmasi_tebusan.Show()
            With datatebusan
                konfirmasi_tebusan.TextBox1.Text = .Item(0, .CurrentRow.Index).Value
                konfirmasi_tebusan.TextBox2.Text = .Item(13, .CurrentRow.Index).Value
                konfirmasi_tebusan.TextBox3.Text = .Item(11, .CurrentRow.Index).Value
                konfirmasi_tebusan.TextBox4.Text = .Item(12, .CurrentRow.Index).Value
            End With

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CETAKSURATToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CETAKSURATToolStripMenuItem.Click

        Try
            konfirmasi_gadai.Show()
            With datagadai
                konfirmasi_gadai.TextBox1.Text = .Item(0, .CurrentRow.Index).Value
                konfirmasi_gadai.TextBox2.Text = .Item(12, .CurrentRow.Index).Value
                konfirmasi_gadai.TextBox3.Text = .Item(10, .CurrentRow.Index).Value
                konfirmasi_gadai.TextBox4.Text = .Item(11, .CurrentRow.Index).Value
            End With

        Catch ex As Exception

        End Try
    End Sub
    '====================================
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        If ComboBox1.Text = "All" Then
            ds = New DataSet
            query = "SELECT  transaksi.*, barang.status FROM   transaksi, barang where transaksi.barang_kode_barang=barang.kodebarang"
            da = New OdbcDataAdapter(query, con)
            Try
                da.Fill(ds)
                riwayattransaksi.DataSource = ds.Tables(0)
            Catch ex As Exception

            End Try
        ElseIf ComboBox1.Text = "Tergadai" Then
            ds = New DataSet
            query = "SELECT  transaksi.*, barang.status FROM   transaksi, barang where transaksi.barang_kode_barang=barang.kodebarang and status='" & ComboBox1.Text & "'"
            da = New OdbcDataAdapter(query, con)
            Try
                da.Fill(ds)
                riwayattransaksi.DataSource = ds.Tables(0)
            Catch ex As Exception

            End Try
        ElseIf ComboBox1.Text = "Sudah Ditebus" Then
            ds = New DataSet
            query = "SELECT  transaksi.*, barang.status FROM   transaksi, barang where transaksi.barang_kode_barang=barang.kodebarang and status='" & ComboBox1.Text & "'"
            da = New OdbcDataAdapter(query, con)
            Try
                da.Fill(ds)
                riwayattransaksi.DataSource = ds.Tables(0)
            Catch ex As Exception

            End Try

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        pop_up_transaksi.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        segar()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        kodebarang()
    End Sub

   
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        kodetransaksi()
    End Sub

    Private Sub Button7_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
       If ComboBox2.Text = "Tampilkan Semua" Then
            Dim ExcelApp As Object, ExcelBook As Object
            Dim ExcelSheet As Object
            Dim i As Integer
            Dim j As Integer
            ExcelApp = CreateObject("Excel.Application")
            ExcelBook = ExcelApp.WorkBooks.Add
            ExcelSheet = ExcelBook.WorkSheets(1)
            With ExcelSheet
                For i = 1 To Me.databarang.RowCount
                    .cells(i, 1) = Me.databarang.Rows(i - 1).Cells(0).Value
                    For j = 1 To databarang.Columns.Count - 1
                        .cells(i, j + 1) = databarang.Rows(i - 1).Cells(j).Value
                    Next
                Next
            End With
            ExcelApp.Visible = True
            ExcelSheet = Nothing
            ExcelBook = Nothing
            ExcelApp = Nothing
        ElseIf ComboBox2.Text = "Tampilkan Beberapa" Then
            baranglaporan()
            Dim ExcelApp As Object, ExcelBook As Object
            Dim ExcelSheet As Object
            Dim i As Integer
            Dim j As Integer
            ExcelApp = CreateObject("Excel.Application")
            ExcelBook = ExcelApp.WorkBooks.Add
            ExcelSheet = ExcelBook.WorkSheets(1)
            With ExcelSheet
                For i = 1 To Me.databarang.RowCount
                    .cells(i, 1) = Me.databarang.Rows(i - 1).Cells(0).Value
                    For j = 1 To databarang.Columns.Count - 1
                        .cells(i, j + 1) = databarang.Rows(i - 1).Cells(j).Value
                    Next
                Next
            End With
            ExcelApp.Visible = True
            ExcelSheet = Nothing
            ExcelBook = Nothing
            ExcelApp = Nothing
        End If
    End Sub
    Sub baranglaporan()
        cmd = New OdbcCommand
        cmd.Connection = con
        ds = New DataSet
        query = "select*from barang where kodebarang between '" & TextBox12.Text & "' and '" & TextBox13.Text & "'"
        cmd.CommandText = query
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            databarang.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
 
    Sub transaksilaporan()
        cmd = New OdbcCommand
        cmd.Connection = con
        ds = New DataSet
        query = "select*from transaksi where no_transaksi between '" & TextBox14.Text & "' and '" & TextBox15.Text & "'"
        cmd.CommandText = query
        da = New OdbcDataAdapter(query, con)
        Try
            da.Fill(ds)
            riwayattransaksi.DataSource = ds.Tables(0)
        Catch ex As Exception

        End Try
    End Sub
 

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If ComboBox2.Text = "Tampilkan Beberapa" Then
            TextBox12.Enabled = True
            TextBox13.Enabled = True
        Else
            TextBox12.Enabled = False
            TextBox13.Enabled = False
        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Dim ExcelApp As Object, ExcelBook As Object
        Dim ExcelSheet As Object
        Dim i As Integer
        Dim j As Integer
        ExcelApp = CreateObject("Excel.Application")
        ExcelBook = ExcelApp.WorkBooks.Add
        ExcelSheet = ExcelBook.WorkSheets(1)
        With ExcelSheet
            For i = 1 To Me.datanasabah.RowCount
                .cells(i, 1) = Me.datanasabah.Rows(i - 1).Cells(0).Value
                For j = 1 To datanasabah.Columns.Count - 1
                    .cells(i, j + 1) = datanasabah.Rows(i - 1).Cells(j).Value
                Next
            Next
        End With
        ExcelApp.Visible = True
        ExcelSheet = Nothing
        ExcelBook = Nothing
        ExcelApp = Nothing
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim ExcelApp As Object, ExcelBook As Object
        Dim ExcelSheet As Object
        Dim i As Integer
        Dim j As Integer
        ExcelApp = CreateObject("Excel.Application")
        ExcelBook = ExcelApp.WorkBooks.Add
        ExcelSheet = ExcelBook.WorkSheets(1)
        With ExcelSheet
            For i = 1 To Me.datapetugas.RowCount
                .cells(i, 1) = Me.datapetugas.Rows(i - 1).Cells(0).Value
                For j = 1 To datapetugas.Columns.Count - 1
                    .cells(i, j + 1) = datapetugas.Rows(i - 1).Cells(j).Value
                Next
            Next
        End With
        ExcelApp.Visible = True
        ExcelSheet = Nothing
        ExcelBook = Nothing
        ExcelApp = Nothing
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        If ComboBox3.Text = "Tampilkan Beberapa" Then
            TextBox14.Enabled = True
            TextBox15.Enabled = True
        Else
            TextBox14.Enabled = False
            TextBox15.Enabled = False
        End If
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        If ComboBox3.Text = "Tampilkan Beberapa" Then
            transaksilaporan()
            Dim ExcelApp As Object, ExcelBook As Object
            Dim ExcelSheet As Object
            Dim i As Integer
            Dim j As Integer
            ExcelApp = CreateObject("Excel.Application")
            ExcelBook = ExcelApp.WorkBooks.Add
            ExcelSheet = ExcelBook.WorkSheets(1)
            With ExcelSheet
                For i = 1 To Me.riwayattransaksi.RowCount
                    .cells(i, 1) = Me.riwayattransaksi.Rows(i - 1).Cells(0).Value
                    For j = 1 To riwayattransaksi.Columns.Count - 1
                        .cells(i, j + 1) = riwayattransaksi.Rows(i - 1).Cells(j).Value
                    Next
                Next
            End With
            ExcelApp.Visible = True
            ExcelSheet = Nothing
            ExcelBook = Nothing
            ExcelApp = Nothing

        ElseIf ComboBox3.Text = "Tampilkan Semua" Then
            Dim ExcelApp As Object, ExcelBook As Object
            Dim ExcelSheet As Object
            Dim i As Integer
            Dim j As Integer
            ExcelApp = CreateObject("Excel.Application")
            ExcelBook = ExcelApp.WorkBooks.Add
            ExcelSheet = ExcelBook.WorkSheets(1)
            With ExcelSheet
                For i = 1 To Me.riwayattransaksi.RowCount
                    .cells(i, 1) = Me.riwayattransaksi.Rows(i - 1).Cells(0).Value
                    For j = 1 To riwayattransaksi.Columns.Count - 1
                        .cells(i, j + 1) = riwayattransaksi.Rows(i - 1).Cells(j).Value
                    Next
                Next
            End With
            ExcelApp.Visible = True
            ExcelSheet = Nothing
            ExcelBook = Nothing
            ExcelApp = Nothing
        ElseIf ComboBox3.Text = "Tampilkan Beberapa" Then
            transaksilaporan()
            Dim ExcelApp As Object, ExcelBook As Object
            Dim ExcelSheet As Object
            Dim i As Integer
            Dim j As Integer
            ExcelApp = CreateObject("Excel.Application")
            ExcelBook = ExcelApp.WorkBooks.Add
            ExcelSheet = ExcelBook.WorkSheets(1)
            With ExcelSheet
                For i = 1 To Me.riwayattransaksi.RowCount
                    .cells(i, 1) = Me.riwayattransaksi.Rows(i - 1).Cells(0).Value
                    For j = 1 To riwayattransaksi.Columns.Count - 1
                        .cells(i, j + 1) = riwayattransaksi.Rows(i - 1).Cells(j).Value
                    Next
                Next
            End With
            ExcelApp.Visible = True
            ExcelSheet = Nothing
            ExcelBook = Nothing
            ExcelApp = Nothing
        End If
    End Sub
End Class