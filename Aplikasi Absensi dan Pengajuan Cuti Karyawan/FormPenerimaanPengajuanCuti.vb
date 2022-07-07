Imports System.Data.SqlClient
Public Class FormPenerimaanPengajuanCuti
    Sub KondisiAwal()
        TBKODEPEGAWAICUTI.Text = ""
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TBJENISCUTI.Text = ""
        TextBox8.Text = ""
        TT1.Text = ""
        TT2.Text = ""
        Call koneksi()
        Da = New SqlDataAdapter("Select * From tbl_pengajuancuti", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_pengajuancuti")
        DataGridView1.DataSource = Ds.Tables("tbl_pengajuancuti")
    End Sub

    Sub TampilTabelPegawaiCuti()
        Call koneksi()
        Da = New SqlDataAdapter("Select * From tbl_pegawaicuti", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_pegawaicuti")
        DataGridView2.DataSource = Ds.Tables("tbl_pegawaicuti")
    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        TBJENISCUTI.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        TT1.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value
        TT2.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value
        TextBox8.Text = DataGridView1.Rows(e.RowIndex).Cells(10).Value
    End Sub

    Private Sub FormPenerimaanPengajuanCuti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Call TampilTabelPegawaiCuti()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Call koneksi()
        Cmd = New SqlCommand("SELECT * from tbl_pengajuancuti where NIP like '%" & txtcari.Text.Replace("'", "''") & "%' or Nama like '%" & txtcari.Text.Replace("'", "''") & "%'", Conn)
        Da = New SqlDataAdapter
        Da.SelectCommand = Cmd
        Ds = New DataSet
        Da.Fill(Ds, "tbl_pengajuancuti")
        DataGridView1.DataSource = Ds.Tables("tbl_pengajuancuti")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Cmd1 As New SqlCommand
        Dim Cmd2 As New SqlCommand
        Dim Cmd3 As New SqlCommand
        If TBKODEPEGAWAICUTI.Text = "" Or TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
            MsgBox("Pastikan Kode Pegawai Cuti Sudah Terisi")
        Else
            Call koneksi()
            Dim InputData As String = "Insert into tbl_pegawaicuti values ('" & TBKODEPEGAWAICUTI.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & TBJENISCUTI.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & TT1.Text & "','" & TT2.Text & "','" & TextBox8.Text & "')"
            Dim HapusData1 As String = "delete from tbl_pegawaiaktif where NIP='" & TextBox2.Text & "'"
            Dim HapusData2 As String = "delete from tbl_pengajuancuti where KodePengajuanCuti='" & TextBox1.Text & "'"
            Cmd1 = New SqlCommand(InputData, Conn)
            Cmd2 = New SqlCommand(HapusData1, Conn)
            Cmd3 = New SqlCommand(HapusData2, Conn)
            Cmd1.ExecuteNonQuery()
            Cmd2.ExecuteNonQuery()
            Cmd3.ExecuteNonQuery()
            MsgBox("Pengajuan Cuti Berhasil Diterima!")
            Call KondisiAwal()
            Me.Refresh()
            Call TampilTabelPegawaiCuti()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call koneksi()
        Dim HapusData As String = "delete from tbl_pengajuancuti where KodePengajuanCuti='" & TextBox1.Text & "'"
        Cmd = New SqlCommand(HapusData, Conn)
        Cmd.ExecuteNonQuery()
        MsgBox("Pengajuan Cuti Berhasil Ditolak")
        Call KondisiAwal()
    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub txtcari_TextChanged(sender As Object, e As EventArgs) Handles txtcari.TextChanged

    End Sub
End Class