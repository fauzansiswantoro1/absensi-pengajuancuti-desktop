Imports System.Data.SqlClient
Imports System.IO
Imports System.Text
Imports System.Net
Public Class FormAbsensi
    Sub KondisiAwal()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        Call koneksi()
        Da = New SqlDataAdapter("Select * From tbl_absensi", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_absensi")
        DataGridView1.DataSource = Ds.Tables("tbl_absensi")
    End Sub

    Private Sub FormAbsensi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()


    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress, TextBox4.KeyPress, TextBox5.KeyPress, TextBox6.KeyPress, tbKodeAbsen.KeyPress
        If e.KeyChar = Chr(13) Then
            Call koneksi()
            Cmd = New SqlCommand("Select * from tbl_pegawaiaktif where NIP ='" & TextBox1.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Rd.HasRows Then
                TextBox2.Text = Rd.Item("Nama")
                TextBox3.Text = Rd.Item("Jabatan")
                TextBox4.Text = Date.Now.ToString("dd-MM-yyyy")
                TextBox5.Text = Date.Now.ToString("HH:mm:ss")
                Dim timeinteger As Integer = CInt(Date.Now.ToString("HH"))
                If timeinteger <= 8 Then
                    TextBox6.Text = "Tepat Waktu"
                Else
                    TextBox6.Text = "Terlambat"
                End If
            Else
                MsgBox("Data Tidak Ada")
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Then
            MsgBox("Pastikan NIP Sudah Terisi")
        Else
            Call koneksi()
            Dim InputData As String = "Insert into tbl_absensi values ('" & tbKodeAbsen.Text & "','" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "', '" & TextBox4.Text & "', '" & TextBox5.Text & "', '" & TextBox6.Text & "')"
            Cmd = New SqlCommand(InputData, Conn)
            Cmd.ExecuteNonQuery()
            insertabsenkemysql()
            MsgBox("Absen Berhasil")
            Call KondisiAwal()

        End If

    End Sub

    Sub insertabsenkemysql()
        If tbKodeAbsen.Text <> Nothing AndAlso
                TextBox1.Text <> Nothing AndAlso
                TextBox2.Text <> Nothing AndAlso
                TextBox3.Text <> Nothing AndAlso
                TextBox4.Text <> Nothing AndAlso
                TextBox5.Text <> Nothing AndAlso
                TextBox6.Text <> Nothing Then
            Try
                Dim request As HttpWebRequest = CType(WebRequest.Create("http://localhost/e-absensi/addabsensi.php"), HttpWebRequest)
                request.Method = "POST"
                request.ContentType = "application/x-www-form-urlencoded"
                Dim Post As String = ("KodeAbsensi=" & tbKodeAbsen.Text &
                    "&NIP=" & TextBox1.Text &
                    "&Nama=" & TextBox2.Text &
                    "&Jabatan=" & TextBox3.Text &
                    "&TanggalAbsen=" & TextBox4.Text &
                    "&WaktuAbsen=" & TextBox5.Text &
                    "&Status=" & TextBox6.Text)
                Dim byteArray() As Byte = Encoding.UTF8.GetBytes(Post)
                request.ContentLength = byteArray.Length
                Dim DataStream As Stream = request.GetRequestStream()
                DataStream.Write(byteArray, 0, byteArray.Length)
                DataStream.Close()
                Dim Response As HttpWebResponse = request.GetResponse()
                DataStream = Response.GetResponseStream()
                Dim Reader As New StreamReader(DataStream)
                Dim ServerResponse As String = Reader.ReadToEnd()
                MsgBox("Absensi berhasil ditambahkan ke website!")
                Reader.Close()
                DataStream.Close()
                Response.Close()
            Catch ex As Exception
                MsgBox("Tidak terhubung dengan server!", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ListView1.Items.Clear()
        Dim k As Integer = 0
        Dim uri As New Uri("http://localhost/e-absensi/tampilDataAbsensiMySQL.php")
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
                ListView1.Items(ListView1.Items.Count - 1).SubItems.Add("-")
                k += 1
            Next
        End If
    End Sub
End Class