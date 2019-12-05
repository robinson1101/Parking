Public Class Form4



    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        _dtsdatosc.Reset()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dtsdatosc.Reset()
        consulta_cierre()

        DataGridView1.DataSource = _dtvdatosc
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 120
        DataGridView1.Columns(2).Width = 120
        DataGridView1.Columns(3).Width = 40
        DataGridView1.Columns(4).Width = 60

        'Timer1.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim total As Double = 0
        Label3.Text = 0
        Dim datos2 As New class_datos
        Dim conexion As New class_int
        Dim fila As DataGridViewRow = New DataGridViewRow()
        For Each fila In DataGridView1.Rows

            total += Convert.ToDouble(fila.Cells("total").Value)
        Next
        Label3.Text = Convert.ToString(total)

        If conexion.realizarcierre(datos2) Then
            ' consulta_datos()
            '  DataGridView1.DataSource = _dtvdatosc
            ' MessageBox.Show("datos guardados")
        Else
            ' MessageBox.Show("no se realizo registro")
        End If
        Form5.Show()
        Close()
        _dtsdatos.Reset()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()

        Form1.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        PrintForm1.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
        'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 0
        'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 0
        'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Top = 0
        'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0
        PrintForm1.Print()
        Timer1.Stop()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        CIERRE_CAJA.Show()
        Me.Hide()
    End Sub
End Class