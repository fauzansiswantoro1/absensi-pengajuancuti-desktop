Public Class FormMenuUtama
    Private Sub UpdateJabatanToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateJabatanToolStripMenuItem.Click
        FormJabatan.Show()
    End Sub

    Private Sub UpdateGolonganToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateGolonganToolStripMenuItem.Click
        FormGolongan.Show()
    End Sub

    Private Sub UpdatePegawaiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdatePegawaiToolStripMenuItem.Click
        FormPegawai.Show()
    End Sub

    Private Sub UpdateJenisCutiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateJenisCutiToolStripMenuItem.Click
        FormJenisCuti.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormAbsensi.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormPengajuanCuti.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FormPenerimaanPengajuanCuti.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FormKonfirmasiSelesaiCuti.Show()
    End Sub

    Private Sub DataMasterToolStripMenuItem_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub LaporanAbsensiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanAbsensiToolStripMenuItem.Click
        FormLapAbsensi.Show()
    End Sub

    Private Sub LaporanCutiToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanCutiToolStripMenuItem.Click
        FormLapCuti.Show()
    End Sub
End Class