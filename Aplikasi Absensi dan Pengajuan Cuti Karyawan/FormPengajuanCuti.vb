Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Net
Public Class FormPengajuanCuti
    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        ComboBox1.Text = ""
        TextBox8.Text = ""
        Call koneksi()
        Da = New SqlDataAdapter("Select * From tbl_pengajuancuti", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_pengajuancuti")
        DataGridView1.DataSource = Ds.Tables("tbl_pengajuancuti")
    End Sub
    Sub TampilJenisCuti()
        koneksi()
        Da = New SqlClient.SqlDataAdapter("SELECT JenisCuti FROM tbl_jeniscuti", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "tbl_jeniscuti")
        ComboBox1.DataSource = (Ds.Tables("tbl_jeniscuti"))
        Me.ComboBox1.ValueMember = "JenisCuti"
        Me.ComboBox1.DisplayMember = "JenisCuti"
    End Sub
    Private Sub FormPengajuanCuti_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Call TampilJenisCuti()
    End Sub

    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress, TextBox3.KeyPress, TextBox4.KeyPress, TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            Cmd = New SqlCommand("Select * from tbl_pegawaiaktif where NIP ='" & TextBox2.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                TextBox3.Text = Rd.Item("Nama")
                TextBox4.Text = Rd.Item("Jabatan")
                TextBox5.Text = Rd.Item("Golongan")
            Else
                MsgBox("Data Tidak Ada")
            End If
        End If

    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox3.KeyPress, TextBox4.KeyPress, TextBox5.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            Cmd = New SqlCommand("Select * from tbl_pengajuancuti where KodePengajuanCuti ='" & TextBox1.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                TextBox2.Text = Rd.Item("NIP")
                TextBox3.Text = Rd.Item("Nama")
                TextBox4.Text = Rd.Item("Jabatan")
                TextBox5.Text = Rd.Item("Golongan")
                ComboBox1.Text = Rd.Item("JenisCuti")
                TextBox6.Text = Rd.Item("AlasanCuti")
                TextBox7.Text = Rd.Item("DurasiCuti")
                DateTimePicker1.Value = Rd.Item("TanggalMulaiCuti")
                DateTimePicker2.Value = Rd.Item("TanggalCutiSelesai")
                TextBox8.Text = Rd.Item("AlamatKetikaCuti")
            Else
                MsgBox("Data Tidak Ada")
            End If
        End If

    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TextBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TextBox2.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        TextBox3.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        TextBox4.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TextBox5.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        ComboBox1.Text = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        TextBox6.Text = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        TextBox7.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        DateTimePicker1.Value = DataGridView1.Rows(e.RowIndex).Cells(8).Value
        DateTimePicker2.Value = DataGridView1.Rows(e.RowIndex).Cells(9).Value
        TextBox8.Text = DataGridView1.Rows(e.RowIndex).Cells(10).Value
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
            MsgBox("Pastikan Semua Field Sudah Terisi")
        Else
            Call koneksi()
            Dim InputData As String = "Insert into tbl_pengajuancuti values ('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "','" & ComboBox1.Text & "','" & TextBox6.Text & "','" & TextBox7.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & Format(DateTimePicker2.Value, "yyyy-MM-dd") & "','" & TextBox8.Text & "','" & TextBox9.Text & "')"
            Cmd = New SqlCommand(InputData, Conn)
            Cmd.ExecuteNonQuery()
            insertpengajuancutikemysql()
            MsgBox("Pengajuan Cuti Berhasil Diajukan!")
            Call KondisiAwal()

        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Cmd As New SqlCommand
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
            MsgBox("Pastikan Semua Field Sudah Terisi")
        Else
            Call koneksi()
            Dim HapusData As String = "delete from tbl_pengajuancuti where KodePengajuanCuti='" & TextBox1.Text & "'"
            Cmd = New SqlCommand(HapusData, Conn)
            Cmd.ExecuteNonQuery()
            deletepengajuancutidimysql()
            MsgBox("Pengajuan Cuti Berhasil Dihapus!")
            Call KondisiAwal()
        End If
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


    Sub insertpengajuancutikemysql()
        If TextBox1.Text <> Nothing AndAlso
                TextBox2.Text <> Nothing AndAlso
                TextBox3.Text <> Nothing AndAlso
                TextBox4.Text <> Nothing AndAlso
                TextBox5.Text <> Nothing AndAlso
                ComboBox1.Text <> Nothing AndAlso
                TextBox6.Text <> Nothing AndAlso
                TextBox7.Text <> Nothing AndAlso
                DateTimePicker1.Value <> Nothing AndAlso
                DateTimePicker2.Value <> Nothing AndAlso
            TextBox8.Text <> Nothing Then
            Try
                Dim request As HttpWebRequest = CType(WebRequest.Create("http://localhost/e-absensi/addpengajuancuti.php"), HttpWebRequest)
                request.Method = "POST"
                request.ContentType = "application/x-www-form-urlencoded"
                Dim Post As String = ("KodePengajuanCuti=" & TextBox1.Text &
                    "&NIP=" & TextBox2.Text &
                    "&Nama=" & TextBox3.Text &
                    "&Jabatan=" & TextBox4.Text &
                    "&Golongan=" & TextBox5.Text &
                    "&JenisCuti=" & ComboBox1.Text &
                    "&AlasanCuti=" & TextBox6.Text &
                    "&DurasiCuti=" & TextBox7.Text &
                    "&TanggalMulaiCuti=" & Format(DateTimePicker1.Value, "yyyy-MM-dd") &
                    "&TanggalCutiSelesai=" & Format(DateTimePicker2.Value, "yyyy-MM-dd") &
                    "&AlamatKetikaCuti=" & TextBox8.Text &
                    "&Status=" & TextBox9.Text)
                Dim byteArray() As Byte = Encoding.UTF8.GetBytes(Post)
                request.ContentLength = byteArray.Length
                Dim DataStream As Stream = request.GetRequestStream()
                DataStream.Write(byteArray, 0, byteArray.Length)
                DataStream.Close()
                Dim Response As HttpWebResponse = request.GetResponse()
                DataStream = Response.GetResponseStream()
                Dim Reader As New StreamReader(DataStream)
                Dim ServerResponse As String = Reader.ReadToEnd()
                MsgBox("Pengajuan Cuti berhasil ditambahkan ke website!")
                Reader.Close()
                DataStream.Close()
                Response.Close()
            Catch ex As Exception
                MsgBox("Tidak terhubung dengan server!", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Sub deletepengajuancutidimysql()
        If TextBox1.Text <> Nothing AndAlso
                TextBox2.Text <> Nothing AndAlso
                TextBox3.Text <> Nothing AndAlso
                TextBox4.Text <> Nothing AndAlso
                TextBox5.Text <> Nothing AndAlso
                ComboBox1.Text <> Nothing AndAlso
                TextBox6.Text <> Nothing AndAlso
                TextBox7.Text <> Nothing AndAlso
                DateTimePicker1.Value <> Nothing AndAlso
                DateTimePicker2.Value <> Nothing AndAlso
            TextBox8.Text <> Nothing Then
            Try
                Dim request As HttpWebRequest = CType(WebRequest.Create("http://localhost/e-absensi/deletepengajuancuti.php"), HttpWebRequest)
                request.Method = "POST"
                request.ContentType = "application/x-www-form-urlencoded"
                Dim Post As String = ("KodePengajuanCuti=" & TextBox1.Text)
                Dim byteArray() As Byte = Encoding.UTF8.GetBytes(Post)
                request.ContentLength = byteArray.Length
                Dim DataStream As Stream = request.GetRequestStream()
                DataStream.Write(byteArray, 0, byteArray.Length)
                DataStream.Close()
                Dim Response As HttpWebResponse = request.GetResponse()
                DataStream = Response.GetResponseStream()
                Dim Reader As New StreamReader(DataStream)
                Dim ServerResponse As String = Reader.ReadToEnd()
                MsgBox("Pengajuan Cuti berhasil dihapus di website!")
                Reader.Close()
                DataStream.Close()
                Response.Close()
            Catch ex As Exception
                MsgBox("Tidak terhubung dengan server!", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ListView1.Items.Clear()
        Dim k As Integer = 0
        Dim uri As New Uri("http://localhost/e-absensi/tampilDataPengajuancutiMySQL.php")
        Dim str As String
        Dim strArr() As String
        Dim strArr1() As String
        Dim str2 As String
        If (uri.Scheme = Uri.UriSchemeHttp) Then
            Dim request As HttpWebRequest = HttpWebRequest.Create(uri)
            request.Method = WebRequestMethods.Http.Get
            Dim response As HttpWebResponse = request.GetResponse()
            Dim reader As New StreamReader(response.GetResponseStream())
            Dim pagehtml As String = reader.ReadToEnd()
            response.Close()
            str = pagehtml
            strArr = str.Split(";")
            For count = 0 To strArr.GetUpperBound(0)
                ReDim Preserve strArr1(k)
                strArr1(k) = strArr(count)
                str2 = strArr1(k)
                Dim words As String() = strArr1(k).Split(New Char() {"*"c})
                If str2 = "" Then
                    Exit For
                End If
                ListView1.Items.Add(words(0))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(words(1))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(words(2))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(words(3))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(words(4))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(words(5))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(words(6))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(words(7))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(words(8))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(words(9))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(words(10))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add(words(11))
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add("-")
                k += 1
            Next
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox6.Text = "" Or TextBox7.Text = "" Then
            MsgBox("Pastikan Semua Field Sudah Terisi")
        Else
            Call koneksi()
            Dim InputData As String = "Update tbl_pengajuancuti set Status ='" & TextBox9.Text & "' where KodePengajuanCuti ='" & TextBox1.Text & "'"
            Cmd = New SqlCommand(InputData, Conn)
            Cmd.ExecuteNonQuery()
            MsgBox("Pengajuan cuti berhasil diupdate pada aplikasi desktop!")
            Call KondisiAwal()

        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = ListView1.SelectedItems(0)
            TextBox1.Text = item.SubItems(0).Text
            TextBox2.Text = item.SubItems(1).Text
            TextBox3.Text = item.SubItems(2).Text
            TextBox4.Text = item.SubItems(3).Text
            TextBox5.Text = item.SubItems(4).Text
            ComboBox1.Text = item.SubItems(5).Text
            TextBox6.Text = item.SubItems(6).Text
            TextBox7.Text = item.SubItems(7).Text
            DateTimePicker1.Value = item.SubItems(8).Text
            DateTimePicker2.Value = item.SubItems(9).Text
            TextBox8.Text = item.SubItems(10).Text
            TextBox9.Text = item.SubItems(11).Text
        End If
    End Sub
End Class


