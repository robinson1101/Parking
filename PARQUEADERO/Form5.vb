Public Class Form5
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Label4.Text = Form1.Label11.Text

        Timer1.Start()
        Label4.Text = Form1.Label11.Text
        Label5.Text = Form4.Label3.Text
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
End Class