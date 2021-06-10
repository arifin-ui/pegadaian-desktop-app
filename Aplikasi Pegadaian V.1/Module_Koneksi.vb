Imports System.Data.Odbc
'Imports Odbc.Data.OdbcClient
'Imports System.Data.OleDb
Module Module_koneksi
    Public con As OdbcConnection
    Public cmd As OdbcCommand
    Public query As String
    Public da As OdbcDataAdapter
    Public ds As DataSet
    Public dt As DataTable
    Public rd As OdbcDataReader

    Sub koneksi()
        con = New OdbcConnection("DSN=admin")
        Try
            If con.State = ConnectionState.Closed Then
                con.Open()

            End If
        Catch ex As Exception
            MessageBox.Show("Koneksi error : " & ex.Message, "Error", _
               MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Module

