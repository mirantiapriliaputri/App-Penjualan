Imports System.Data.Odbc
Public Class FormTransJual
    Dim TglMySQL As String
    Sub KondisiAwal()
        LBLNamaPlg.Text = ""
        LBLAlamat.Text = ""
        LBLTelepon.Text = ""
        LBLTanggal.Text = Today
        LBLAdmin.Text = FormMenuUtama.STLabel4.Text
        LBLKembali.Text = ""
        TextBox2.Text = ""
        LBLNamaBarang.Text = ""
        LBLHargaBarang.Text = ""
        TextBox3.Text = ""
        TextBox3.Enabled = False
        LBLItem.Text = ""
        Call MunculKodePelanggan()
        Call NomorOtomatis()
        Call BuatKolom()
        Label9.Text = "0"
        TextBox1.Text = ""
        Call Koneksi()
        Da = New OdbcDataAdapter("Select * From tbl_barang", Conn)
        Ds = New DataSet
        Da.Fill(Ds, "tbl_barang")
        DataGridView2.DataSource = Ds.Tables("tbl_barang")
        DataGridView2.ReadOnly = True

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LBLJam.Text = TimeOfDay
    End Sub

    Private Sub FormTransJual_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call KondisiAwal()
        'Call MunculListBox()

       
    End Sub
    Sub MunculKodePelanggan()
        Call Koneksi()
        ComboBox1.Items.Clear()
        Cmd = New OdbcCommand("Select * from tbl_Pelanggan", Conn)
        Rd = Cmd.ExecuteReader
        Do While Rd.Read
            ComboBox1.Items.Add(Rd.Item(0))
        Loop
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from tbl_Pelanggan where kode_pelanggan='" & ComboBox1.Text & "'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            LBLNamaPlg.Text = Rd!Nama_Pelanggan
            LBLAlamat.Text = Rd!Alamat_Pelanggan
            LBLTelepon.Text = Rd!Telepon_Pelanggan
        End If
    End Sub
    Sub NomorOtomatis()
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from tbl_jual where no_jual in(select max(no_jual) from tbl_jual)", Conn)
        Dim UrutanKode As String
        Dim Hitung As Long
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Not Rd.HasRows Then
            UrutanKode = "J" + Format(Now, "yyMMdd") + "001"
        Else
            Hitung = Microsoft.VisualBasic.Right(Rd.GetString(0), 9) + 1
            UrutanKode = "J" + Format(Now, "yyMMdd") + Microsoft.VisualBasic.Right("000" & Hitung, 3)
        End If
        LBLNoJual.Text = UrutanKode
    End Sub
    Sub BuatKolom()
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("Kode", "Kode")
        DataGridView1.Columns.Add("Nama", "Nama Barang")
        DataGridView1.Columns.Add("Harga", "Harga")
        DataGridView1.Columns.Add("Jumlah", "Jumlah")
        DataGridView1.Columns.Add("Subtotal", "Subtotal")
    End Sub
    Private Sub TextBox2_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Call Koneksi()
            Cmd = New OdbcCommand("Select * From tbl_barang where kode_barang='" & TextBox2.Text & "'", Conn)
            Rd = Cmd.ExecuteReader
            Rd.Read()
            If Not Rd.HasRows Then
                MsgBox("Kode barang Tidak Ada")
            Else
                TextBox2.Text = Rd.Item("Kode_barang")
                LBLNamaBarang.Text = Rd.Item("Nama_barang")
                LBLHargaBarang.Text = Rd.Item("Harga_barang")
                LBLJumlahBrg.Text = Rd.Item("Jumlah_Barang")
                'TextBox4.Text = Rd.Item("Jumlah_barang")
                'ComboBox1.Text = Rd.Item("Satuan_barang")
                TextBox3.Enabled = True
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If LBLNamaBarang.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Silahkan Masukkan Kode Barang Dan Tekan Enter")
        Else
            If Val(LBLJumlahBrg.Text) < Val(TextBox3.Text) Then
                MsgBox("Stok Barang Kurang!")
            Else
                DataGridView1.Rows.Add(New String() {TextBox2.Text, LBLNamaBarang.Text, LBLHargaBarang.Text, TextBox3.Text, Val(LBLHargaBarang.Text) * Val(TextBox3.Text)})
                Call RumusSubtotal()
                TextBox2.Text = ""
                LBLNamaBarang.Text = ""
                LBLHargaBarang.Text = ""
                TextBox3.Text = ""
                TextBox3.Enabled = False
                Call RumusCariItem()
            End If
          
        End If

    End Sub
    Sub RumusSubtotal()
        Dim Hitung As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            Hitung = Hitung + DataGridView1.Rows(i).Cells(4).Value
            Label9.Text = Hitung
        Next
    End Sub

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            If Val(TextBox1.Text) < Val(Label9.Text) Then
                MsgBox("Pembayaran Kurang!")
            ElseIf Val(TextBox1.Text) = Val(Label9.Text) Then
                LBLKembali.Text = 0
            ElseIf Val(TextBox1.Text) > Val(Label9.Text) Then
                LBLKembali.Text = Val(TextBox1.Text) - Val(Label9.Text)
                Button1.Focus()
            End If
        End If
    End Sub
    Sub RumusCariItem()
        Dim HitungItem As Integer = 0
        For i As Integer = 0 To DataGridView1.Rows.Count - 1
            HitungItem = HitungItem + DataGridView1.Rows(i).Cells(3).Value
            LBLItem.Text = HitungItem
        Next
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If LBLKembali.Text = "" Or LBLNamaPlg.Text = "" Or Label9.Text = "" Then
            MsgBox("Transaksi Tidak Ada,Silahkan Lakukan Transaksi Terlebih Dahulu")
        Else
            TglMySQL = Format(Today, "yyyy-MM-dd")
            Dim SimpanJual As String = "Insert into tbl_jual values('" & LBLNoJual.Text & "','" & TglMySQL & "','" & LBLJam.Text & "','" & LBLItem.Text & "','" & Label9.Text & "','" & TextBox1.Text & "','" & LBLKembali.Text & "','" & ComboBox1.Text & "','" & FormMenuUtama.STLabel2.Text & "')"
            Cmd = New OdbcCommand(SimpanJual, Conn)
            Cmd.ExecuteNonQuery()

            For Baris As Integer = 0 To DataGridView1.Rows.Count - 2
                Dim SimpanDetail As String = "Insert into tbl_detailjual values('" & LBLNoJual.Text & "','" & DataGridView1.Rows(Baris).Cells(0).Value & "','" & DataGridView1.Rows(Baris).Cells(1).Value & "','" & DataGridView1.Rows(Baris).Cells(2).Value & "','" & DataGridView1.Rows(Baris).Cells(3).Value & "','" & DataGridView1.Rows(Baris).Cells(4).Value & "')"
                Cmd = New OdbcCommand(SimpanDetail, Conn)
                Cmd.ExecuteNonQuery()

                Cmd = New OdbcCommand("Select * from tbl_barang where kode_barang='" & DataGridView1.Rows(Baris).Cells(0).Value & "'", Conn)
                Rd = Cmd.ExecuteReader
                Rd.Read()
                Dim KurangiStok As String = "Update tbl_barang set Jumlah_Barang= '" & Rd.Item("Jumlah_Barang") - DataGridView1.Rows(Baris).Cells(3).Value & "' where kode_barang='" & DataGridView1.Rows(Baris).Cells(0).Value & "'"
                Cmd = New OdbcCommand(KurangiStok, Conn)
                Cmd.ExecuteNonQuery()
            Next

            If MessageBox.Show("Apakah Anda Ingin Mencetak Nota Ini??", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                AxCrystalReport1.SelectionFormula = "totext({tbl_Jual.No_Jual})='" & LBLNoJual.Text & "'"
                AxCrystalReport1.ReportFileName = "notajual.rpt"
                AxCrystalReport1.WindowState = Crystal.WindowStateConstants.crptMaximized
                AxCrystalReport1.RetrieveDataFiles()
                AxCrystalReport1.Action = 1
                Call KondisiAwal()
                'MsgBox("Transaksi Telah Berhasil Disimpan")
            Else


                Call KondisiAwal()
                MsgBox("Transaksi Telah Berhasil Disimpan")
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub LBLTanggal_Click(sender As Object, e As EventArgs) Handles LBLTanggal.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
    'Sub MunculListBox()
    'Call Koneksi()
    'ListBox1.Items.Clear()
    'Cmd = New OdbcCommand("Select * From tbl_barang", Conn)
    'Rd = Cmd.ExecuteReader
    'Rd.Read()

    'If Rd.HasRows Then
    'ListBox1.Items.Add(Rd.Item(0).ToString & " " & Rd.Item(1).ToString & " " & Rd.Item(2).ToString & " " & Rd.Item(3).ToString & " " & Rd.Item(4).ToString)
    'Do While Rd.Read
    'ListBox1.Items.Add(Rd.Item(0).ToString & " " & Rd.Item(1).ToString & " " & Rd.Item(2).ToString & " " & Rd.Item(3).ToString & " " & Rd.Item(4).ToString)
    'Loop
    'End If
    'End Sub

    'Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
    'Dim pilihan As String
    'Dim i As Integer

    'pilihan = ""
    'For i = 1 To ListBox1.SelectedItems.Count
    'pilihan = pilihan + ListBox1.Items(1)
    'pilihan = pilihan + ListBox1.SelectedItems.Item(i - 1) + vbCrLf

    'Next
    'TextBox2.Text = pilihan
    'End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Call Koneksi()
        Cmd = New OdbcCommand("Select * from tbl_barang where nama_barang like '%" & TextBox4.Text & "%'", Conn)
        Rd = Cmd.ExecuteReader
        Rd.Read()
        If Rd.HasRows Then
            Call Koneksi()
            Da = New OdbcDataAdapter("Select * from tbl_barang where nama_barang like '%" & TextBox4.Text & "%'", Conn)
            Ds = New DataSet
            Da.Fill(Ds, "KetemuData")
            DataGridView2.DataSource = Ds.Tables("KetemuData")
            DataGridView2.ReadOnly = True
        End If

    End Sub

   
End Class