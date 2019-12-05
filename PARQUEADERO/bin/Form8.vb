Imports System.Drawing.Printing

Public Class Form8
    Private PrintForm1 As Object

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        PrintForm2.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
        'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 0
        'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 0
        'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Top = 0
        'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0
        PrintForm2.Print()
        Timer1.Stop()
        Me.Close()

    End Sub

    Private Sub Form8_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Label9.Text = liquidar.Label6.Text
        Label8.Text = liquidar.TextBox2.Text
        Label10.Text = Form1.Label11.Text
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs)

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PrintForm2_BeginPrint(sender As Object, e As PrintEventArgs) Handles PrintForm2.BeginPrint

    End Sub
End Class