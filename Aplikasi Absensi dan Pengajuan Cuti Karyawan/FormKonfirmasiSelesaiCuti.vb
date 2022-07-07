Imports System.Data.SqlClient
Public Class FormKonfirmasiSelesaiCuti
    Sub KondisiAwal()
        TBKODEPEGAWAICUTI.Text = ""
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox7.Text = ""
        TBJENISCUTI.Text = ""
        TT1.Text = ""
        TT2.Text = ""
        Call koneksi()
        Da = New SqlDataAdapter("Select * From tbl_pegawaicuti", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_pegawaicuti")
        DataGridView1.DataSource = Ds.Tables("tbl_pegawaicuti")
    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TBKODEPEGAWAICUTI.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TBJENISCUTI.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value
        TT1.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value
        TT2.Text = DataGridView1.Rows(e.RowIndex).Cells(10).Value
    End Sub
    Private Sub FormKonfirmasiSelesaiCuti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim cmd1 As New SqlCommand
        Dim Cmd2 As New SqlCommand
        If TBKODEPEGAWAICUTI.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox7.Text = "" Then
            MsgBox("Pastikan Anda Sudah Mengklik Data Cuti Pegawi yang Ingin Melakukan Konfirmasi Selesai Cuti")
        Else
            Call koneksi()
            Dim HapusData As String = "delete from tbl_pegawaicuti where KodePegawaiCuti='" & TBKODEPEGAWAICUTI.Text & "'"
            Dim InputData As String = "Insert into tbl_pegawaiaktif values ('" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
            cmd1 = New SqlCommand(HapusData, Conn)
            Cmd2 = New SqlCommand(InputData, Conn)
            cmd1.ExecuteNonQuery()
            Cmd2.ExecuteNonQuery()
            MsgBox("Konfirmasi Selesai Cuti Berhasil!")
            Call KondisiAwal()
        End If
    End Sub
End Class