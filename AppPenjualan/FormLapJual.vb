Public Class FormLapJual

   
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        AxCrystalReport1.SelectionFormula = "totext({tbl_Jual.Tgl_Jual})='" & DateTimePicker1.Value & "'"
        AxCrystalReport1.ReportFileName = "LaporanHarian.rpt"
        AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport1.RetrieveDataFiles()
        AxCrystalReport1.Action = 1
    End Sub

    Private Sub FormLapJual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("01 - JANUARI")
        ComboBox1.Items.Add("02 - FEBRUARI")
        ComboBox1.Items.Add("03 - MARET")
        ComboBox1.Items.Add("04 - APRIL")
        ComboBox1.Items.Add("05 - MEI")
        ComboBox1.Items.Add("06 - JUNI")
        ComboBox1.Items.Add("07 - JULI")
        ComboBox1.Items.Add("08 - AGUSTUS")
        ComboBox1.Items.Add("09 - SEPTEMBER")
        ComboBox1.Items.Add("10 - OKTOBER")
        ComboBox1.Items.Add("11 - NOVEMBER")
        ComboBox1.Items.Add("12 - DESEMBER")


        ComboBox2.Items.Clear()
        ComboBox2.Text = Date.Now.Year
        For i As Integer = 0 To 5
            ComboBox2.Items.Add(Date.Now.Year - i)
        Next
        Label7.Text = "2020, 04, 10"
        Label8.Text = "2020, 04, 12"

        Label7.Text = Format(DateTimePicker2.Value, "yyyy, MM, dd")
        Label8.Text = Format(DateTimePicker3.Value, "yyyy, MM, dd")

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If ComboBox1.Text = "" Or ComboBox2.Text = "" Then
            MsgBox("Silahkan Isi Bulan Dan Tahunnya Terlebih Dahulu!")
        Else
            AxCrystalReport1.SelectionFormula = "Month({tbl_Jual.Tgl_Jual})=" & Val(ComboBox1.Text) & " and year({tbl_Jual.Tgl_Jual})=" & Val(ComboBox2.Text)
            AxCrystalReport1.ReportFileName = "LaporanBulanan.rpt"
            AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
            AxCrystalReport1.RetrieveDataFiles()
            AxCrystalReport1.Action = 1
        End If
       
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        AxCrystalReport1.SelectionFormula = "{tbl_Jual.Tgl_Jual} in date (" & Label7.Text & ") to date (" & Label8.Text & ")"
        'AxCrystalReport1.SelectionFormula = "{tbl_Jual.Tgl_Jual} in date (" & DateTimePicker2.Value & ") to date (" & DateTimePicker3.Value & ")"

        AxCrystalReport1.ReportFileName = "LaporanMingguan.rpt"
        AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
        AxCrystalReport1.RetrieveDataFiles()
        AxCrystalReport1.Action = 1
    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        Label7.Text = Format(DateTimePicker2.Value, "yyyy, MM, dd")
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker3.ValueChanged
        Label8.Text = Format(DateTimePicker3.Value, "yyyy, MM, dd")
    End Sub
End Class