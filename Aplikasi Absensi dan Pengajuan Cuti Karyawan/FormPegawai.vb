Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Net
Public Class FormPegawai
    Dim Gender As String
    Sub KondisiAwal()
        TNIP.Text = ""
        TNAMA.Text = ""
        TTEMPATLAHIR.Text = ""
        TALAMAT.Text = ""
        THP.Text = ""
        CJABATAN.Text = ""
        CGOLONGAN.Text = ""
        CAGAMA.Text = ""
        Button1.Text = "INPUT"
        Button2.Text = "EDIT"
        Button3.Text = "HAPUS"
        Button4.Text = "TUTUP"
        Call koneksi()
        Da = New SqlDataAdapter("Select * From tbl_pegawai", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_pegawai")
        DataGridView1.DataSource = Ds.Tables("tbl_pegawai")
    End Sub
    Sub TampilJabatan()
        koneksi()
        Da = New SqlDataAdapter("SELECT NamaJabatan FROM tbl_jabatan", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "tbl_jabatan")
        CJABATAN.DataSource = (Ds.Tables("tbl_jabatan"))
        Me.CJABATAN.ValueMember = "NamaJabatan"
        Me.CJABATAN.DisplayMember = "NamaJabatan"
    End Sub
    Sub TampilGolongan()
        koneksi()
        Da = New SqlDataAdapter("SELECT NamaGolongan FROM tbl_golongan", Conn)
        Ds = New DataSet
        Ds.Clear()
        Da.Fill(Ds, "tbl_golongan")
        CGOLONGAN.DataSource = (Ds.Tables("tbl_golongan"))
        Me.CGOLONGAN.ValueMember = "NamaGolongan"
        Me.CGOLONGAN.DisplayMember = "NamaGolongan"
    End Sub
    Sub tampilkandatacagama()
        Me.CAGAMA.Items.Add("ISLAM")
        Me.CAGAMA.Items.Add("KRISTEN")
        Me.CAGAMA.Items.Add("KATOLIK")
        Me.CAGAMA.Items.Add("HINDU")
        Me.CAGAMA.Items.Add("BUDHA")
        Me.CAGAMA.Items.Add("LAIN")
    End Sub
    Private Sub FormPegawai_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        Call tampilkandatacagama()
        Call TampilJabatan()
        Call TampilGolongan()
    End Sub
    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        TNIP.Text = DataGridView1.Rows(e.RowIndex).Cells(0).Value
        TNAMA.Text = DataGridView1.Rows(e.RowIndex).Cells(1).Value
        CJABATAN.Text = DataGridView1.Rows(e.RowIndex).Cells(2).Value
        CGOLONGAN.Text = DataGridView1.Rows(e.RowIndex).Cells(3).Value
        TTEMPATLAHIR.Text = DataGridView1.Rows(e.RowIndex).Cells(4).Value
        DateTimePicker1.Value = DataGridView1.Rows(e.RowIndex).Cells(5).Value
        Gender = DataGridView1.Rows(e.RowIndex).Cells(6).Value
        CAGAMA.Text = DataGridView1.Rows(e.RowIndex).Cells(7).Value
        TALAMAT.Text = DataGridView1.Rows(e.RowIndex).Cells(8).Value
        THP.Text = DataGridView1.Rows(e.RowIndex).Cells(9).Value
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Cmd1 As New SqlCommand
        Dim Cmd2 As New SqlCommand
        If TNIP.Text = "" Or TNAMA.Text = "" Or TTEMPATLAHIR.Text = "" Or TALAMAT.Text = "" Or THP.Text = "" Then
            MsgBox("Pastikan Semua Field Terisi")
        Else

            Call koneksi()
            If RadioButton1.Checked = True Then
                Gender = RadioButton1.Text
            ElseIf RadioButton2.Checked = True Then
                Gender = RadioButton2.Text
            End If
            Dim InputData1 As String = "Insert into tbl_pegawai values ('" & TNIP.Text & "','" & TNAMA.Text & "','" & CJABATAN.Text & "','" & CGOLONGAN.Text & "','" & TTEMPATLAHIR.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & Gender & "','" & CAGAMA.Text & "','" & TALAMAT.Text & "','" & THP.Text & "')"
            Dim InputData2 As String = "Insert into tbl_pegawaiaktif values ('" & TNIP.Text & "','" & TNAMA.Text & "','" & CJABATAN.Text & "','" & CGOLONGAN.Text & "')"
            Cmd1 = New SqlCommand(InputData1, Conn)
            Cmd2 = New SqlCommand(InputData2, Conn)
            Cmd1.ExecuteNonQuery()
            Cmd2.ExecuteNonQuery()
            insertkemysql()
            MsgBox("Input Data Berhasil")
            Call KondisiAwal()
        End If

    End Sub
    Private Sub TNIP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TNIP.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            Cmd = New SqlCommand("Select * from tbl_pegawai where NIP ='" & TNIP.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                TNAMA.Text = Rd.Item("Nama")
                CJABATAN.Text = Rd.Item("Jabatan")
                CGOLONGAN.Text = Rd.Item("Golongan")
                TTEMPATLAHIR.Text = Rd.Item("TempatLahir")
                DateTimePicker1.Value = Rd.Item("TanggalLahir")
                Gender = Rd.Item("JenisKelamin")
                CAGAMA.Text = Rd.Item("Agama")
                TALAMAT.Text = Rd.Item("Alamat")
                THP.Text = Rd.Item("Telephone")
            Else
                MsgBox("Data tidak ada")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim Cmd1 As New SqlCommand
        Dim Cmd2 As New SqlCommand
        If TNIP.Text = "" Or TNAMA.Text = "" Or TTEMPATLAHIR.Text = "" Or TALAMAT.Text = "" Or THP.Text = "" Then
            MsgBox("Pastikan Semua Field Terisi")
        Else
            Call koneksi()
            Dim EditData1 As String = "Update tbl_pegawai set Nama ='" & TNAMA.Text & "',Jabatan ='" & CJABATAN.Text & "',Golongan ='" & CGOLONGAN.Text & "',TempatLahir ='" & TTEMPATLAHIR.Text & "',TanggalLahir ='" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "',JenisKelamin ='" & Gender & "',Agama ='" & CAGAMA.Text & "',Alamat ='" & TALAMAT.Text & "',Telephone ='" & THP.Text & "' where NIP ='" & TNIP.Text & "'"
            Dim EditData2 As String = "Update tbl_pegawaiaktif set Nama ='" & TNAMA.Text & "',Jabatan ='" & CJABATAN.Text & "',Golongan ='" & CGOLONGAN.Text & "' where NIP ='" & TNIP.Text & "'"
            Cmd1 = New SqlCommand(EditData1, Conn)
            Cmd2 = New SqlCommand(EditData2, Conn)
            Cmd1.ExecuteNonQuery()
            Cmd2.ExecuteNonQuery()
            updatedatakemysql()
            MsgBox("Edit Data Berhasil")
            Call KondisiAwal()
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim Cmd1 As New SqlCommand
        Dim Cmd2 As New SqlCommand
        If TNIP.Text = "" Or TNAMA.Text = "" Or TTEMPATLAHIR.Text = "" Or TALAMAT.Text = "" Or THP.Text = "" Then
            MsgBox("Pastikan Semua Field Terisi")
        Else
            Call koneksi()
            Dim HapusData1 As String = "delete from tbl_pegawai where NIP='" & TNIP.Text & "'"
            Dim HapusData2 As String = "delete from tbl_pegawaiaktif where NIP='" & TNIP.Text & "'"
            Cmd1 = New SqlCommand(HapusData1, Conn)
            Cmd2 = New SqlCommand(HapusData2, Conn)
            Cmd1.ExecuteNonQuery()
            Cmd2.ExecuteNonQuery()
            deletedatadimysql()
            MsgBox("Hapus Data Berhasil")
            Call KondisiAwal()
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Call koneksi()
        Cmd = New SqlCommand("SELECT * from tbl_pegawai where NIP like '%" & txtcari.Text.Replace("'", "''") & "%' or Nama like '%" & txtcari.Text.Replace("'", "''") & "%'", Conn)
        Da = New SqlDataAdapter
        Da.SelectCommand = Cmd
        Ds = New DataSet
        Da.Fill(Ds, "tbl_pegawai")
        DataGridView1.DataSource = Ds.Tables("tbl_pegawai")

    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub


    Sub insertkemysql()
        If TNIP.Text <> Nothing AndAlso
                TNAMA.Text <> Nothing AndAlso
                CJABATAN.Text <> Nothing AndAlso
                CGOLONGAN.Text <> Nothing AndAlso
                TTEMPATLAHIR.Text <> Nothing AndAlso
                DateTimePicker1.Value <> Nothing AndAlso
                Gender <> Nothing AndAlso
                CAGAMA.Text <> Nothing AndAlso
                TALAMAT.Text <> Nothing AndAlso
                THP.Text <> Nothing Then
            Try
                Dim request As HttpWebRequest = CType(WebRequest.Create("http://localhost/e-absensi/addpegawai.php"), HttpWebRequest)
                request.Method = "POST"
                request.ContentType = "application/x-www-form-urlencoded"
                Dim Post As String = ("NIP=" & TNIP.Text &
                    "&Nama=" & TNAMA.Text &
                    "&Jabatan=" & CJABATAN.Text &
                    "&Golongan=" & CGOLONGAN.Text &
                    "&TempatLahir=" & TTEMPATLAHIR.Text &
                    "&TanggalLahir=" & Format(DateTimePicker1.Value, "yyyy-MM-dd") &
                    "&JenisKelamin=" & Gender &
                    "&Agama=" & CAGAMA.Text &
                    "&Alamat=" & TALAMAT.Text &
                    "&Telephone=" & THP.Text)
                Dim byteArray() As Byte = Encoding.UTF8.GetBytes(Post)
                request.ContentLength = byteArray.Length
                Dim DataStream As Stream = request.GetRequestStream()
                DataStream.Write(byteArray, 0, byteArray.Length)
                DataStream.Close()
                Dim Response As HttpWebResponse = request.GetResponse()
                DataStream = Response.GetResponseStream()
                Dim Reader As New StreamReader(DataStream)
                Dim ServerResponse As String = Reader.ReadToEnd()
                MsgBox("Pegawai Berhasil ditambahkan ke website!")
                Reader.Close()
                DataStream.Close()
                Response.Close()
            Catch ex As Exception
                MsgBox("Tidak terhubung dengan server!", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Sub updatedatakemysql()
        If TNIP.Text <> Nothing AndAlso
                TNAMA.Text <> Nothing AndAlso
                CJABATAN.Text <> Nothing AndAlso
                CGOLONGAN.Text <> Nothing AndAlso
                TTEMPATLAHIR.Text <> Nothing AndAlso
                DateTimePicker1.Value <> Nothing AndAlso
                Gender <> Nothing AndAlso
                CAGAMA.Text <> Nothing AndAlso
                TALAMAT.Text <> Nothing AndAlso
                THP.Text <> Nothing Then
            Try
                Dim request As HttpWebRequest = CType(WebRequest.Create("http://localhost/e-absensi/updatepegawai.php"), HttpWebRequest)
                request.Method = "POST"
                request.ContentType = "application/x-www-form-urlencoded"
                Dim Post As String = ("NIP=" & TNIP.Text &
                    "&Nama=" & TNAMA.Text &
                    "&Jabatan=" & CJABATAN.Text &
                    "&Golongan=" & CGOLONGAN.Text &
                    "&TempatLahir=" & TTEMPATLAHIR.Text &
                    "&TanggalLahir=" & Format(DateTimePicker1.Value, "yyyy-MM-dd") &
                    "&JenisKelamin=" & Gender &
                    "&Agama=" & CAGAMA.Text &
                    "&Alamat=" & TALAMAT.Text &
                    "&Telephone=" & THP.Text)
                Dim byteArray() As Byte = Encoding.UTF8.GetBytes(Post)
                request.ContentLength = byteArray.Length
                Dim DataStream As Stream = request.GetRequestStream()
                DataStream.Write(byteArray, 0, byteArray.Length)
                DataStream.Close()
                Dim Response As HttpWebResponse = request.GetResponse()
                DataStream = Response.GetResponseStream()
                Dim Reader As New StreamReader(DataStream)
                Dim ServerResponse As String = Reader.ReadToEnd()
                MsgBox("Pegawai Berhasil diupdate ke website!")
                Reader.Close()
                DataStream.Close()
                Response.Close()
            Catch ex As Exception
                MsgBox("Tidak terhubung dengan server!", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Sub deletedatadimysql()
        If TNIP.Text <> Nothing AndAlso
                TNAMA.Text <> Nothing AndAlso
                CJABATAN.Text <> Nothing AndAlso
                CGOLONGAN.Text <> Nothing AndAlso
                TTEMPATLAHIR.Text <> Nothing AndAlso
                DateTimePicker1.Value <> Nothing AndAlso
                Gender <> Nothing AndAlso
                CAGAMA.Text <> Nothing AndAlso
                TALAMAT.Text <> Nothing AndAlso
                THP.Text <> Nothing Then
            Try
                Dim request As HttpWebRequest = CType(WebRequest.Create("http://localhost/e-absensi/deletepegawai.php"), HttpWebRequest)
                request.Method = "POST"
                request.ContentType = "application/x-www-form-urlencoded"
                Dim Post As String = ("NIP=" & TNIP.Text)
                Dim byteArray() As Byte = Encoding.UTF8.GetBytes(Post)
                request.ContentLength = byteArray.Length
                Dim DataStream As Stream = request.GetRequestStream()
                DataStream.Write(byteArray, 0, byteArray.Length)
                DataStream.Close()
                Dim Response As HttpWebResponse = request.GetResponse()
                DataStream = Response.GetResponseStream()
                Dim Reader As New StreamReader(DataStream)
                Dim ServerResponse As String = Reader.ReadToEnd()
                MsgBox("Pegawai Berhasil di website berhasil di delete!")
                Reader.Close()
                DataStream.Close()
                Response.Close()
            Catch ex As Exception
                MsgBox("Tidak terhubung dengan server!", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        ListView1.Items.Clear()
        Dim k As Integer = 0
        Dim uri As New Uri("http://localhost/e-absensi/tampilDataPegawaiMySQL.php")
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
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add("-")
                k += 1
            Next
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListView1.SelectedIndexChanged
        If ListView1.SelectedItems.Count > 0 Then
            Dim item As ListViewItem = ListView1.SelectedItems(0)
            TNIP.Text = item.SubItems(0).Text
            TNAMA.Text = item.SubItems(1).Text
            CJABATAN.Text = item.SubItems(2).Text
            CGOLONGAN.Text = item.SubItems(3).Text
            TTEMPATLAHIR.Text = item.SubItems(4).Text
            DateTimePicker1.Value = item.SubItems(5).Text
            Gender = item.SubItems(6).Text
            CAGAMA.Text = item.SubItems(7).Text
            TALAMAT.Text = item.SubItems(8).Text
            THP.Text = item.SubItems(9).Text
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim Cmd1 As New SqlCommand
        Dim Cmd2 As New SqlCommand
        If TNIP.Text = "" Or TNAMA.Text = "" Or TTEMPATLAHIR.Text = "" Or TALAMAT.Text = "" Or THP.Text = "" Then
            MsgBox("Pastikan Semua Field Terisi")
        Else

            Call koneksi()
            If RadioButton1.Checked = True Then
                Gender = RadioButton1.Text
            ElseIf RadioButton2.Checked = True Then
                Gender = RadioButton2.Text
            End If
            Dim InputData1 As String = "Insert into tbl_pegawai values ('" & TNIP.Text & "','" & TNAMA.Text & "','" & CJABATAN.Text & "','" & CGOLONGAN.Text & "','" & TTEMPATLAHIR.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "','" & Gender & "','" & CAGAMA.Text & "','" & TALAMAT.Text & "','" & THP.Text & "')"
            Dim InputData2 As String = "Insert into tbl_pegawaiaktif values ('" & TNIP.Text & "','" & TNAMA.Text & "','" & CJABATAN.Text & "','" & CGOLONGAN.Text & "')"
            Cmd1 = New SqlCommand(InputData1, Conn)
            Cmd2 = New SqlCommand(InputData2, Conn)
            Cmd1.ExecuteNonQuery()
            Cmd2.ExecuteNonQuery()
            MsgBox("Input Data Berhasil")
            Call KondisiAwal()
        End If
    End Sub


End Class