Imports System.Data.SqlClient
Module Module1
    Public Conn As SqlConnection
    Public Cmd As SqlCommand
    Public Ds As DataSet
    Public Da As SqlDataAdapter
    Public Rd As SqlDataReader
    Public MyDB As String
    Public Sub koneksi()
        MyDB = "Data Source=DESKTOP-DCFT083;initial catalog=db_kantor;integrated security=true"
        Conn = New SqlConnection(MyDB)
        If Conn.State = ConnectionState.Closed Then Conn.Open()
    End Sub
End Module
