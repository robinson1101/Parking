Public Class Form2
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Text = Form1.TextBox1.Text
        Timer1.Start()
        Label22.Text = Form1.TextBox10.Text
        TextBox2.Text = Form1.TextBox9.Text


        Try
                Dim alto As Single = 0

            alto = Convert.ToSingle(60)

            Dim bm As Bitmap = Nothing
            bm = Codigos.codigo128(Label4.Text, CheckBox1.Checked, alto)
            If Not IsNothing(bm) Then
                    PictureBox1.Image = bm
                End If
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        'PrintForm1.Print()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Try
            'PrintForm1.PrinterSettings.DefaultPageSettings.Landscape = True

            PrintForm1.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
            'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 0
            'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 0
            'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Top = 0
            'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0
            PrintForm1.Print()
            Timer1.Stop()
            Me.Close()


        Catch ex As Exception
            Form1.Show()
        End Try


    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub tiquet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Text = Form1.TextBox1.Text
        Label6.Text = Form1.Label6.Text
        Form1.Show()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label2_Click_1(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs) Handles Label17.Click

    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged

    End Sub
End Class