Imports System.Drawing.Printing

Public Class ELIMINAR2


    Public Sub PrintDocument1_PrintPage(sender As Object, e As PrintPageEventArgs)

        Dim textFormat As StringFormat = New StringFormat
        textFormat.Alignment = StringAlignment.Center


        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita

        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left
        ' La fuente a usar
        Dim textFont1 As New Font("Arial", ELIMINAR.NumericUpDown1.Value, ELIMINAR.style1)
        Dim textFont2 As New Font("Arial", ELIMINAR.NumericUpDown2.Value, ELIMINAR.style2)
        Dim textFont3 As New Font("Arial", ELIMINAR.NumericUpDown3.Value, ELIMINAR.style3)
        Dim textFont4 As New Font("Arial", ELIMINAR.NumericUpDown4.Value, ELIMINAR.style4)
        Dim textFont5 As New Font("Arial", ELIMINAR.NumericUpDown5.Value, ELIMINAR.style5)
        Dim textFont6 As New Font("Arial", ELIMINAR.NumericUpDown6.Value, ELIMINAR.style6)
        Dim textFont7 As New Font("Arial", ELIMINAR.NumericUpDown7.Value, ELIMINAR.style7)
        Dim textFont8 As New Font("Arial", ELIMINAR.NumericUpDown8.Value, ELIMINAR.style8)
        Dim textFont9 As New Font("Arial", ELIMINAR.NumericUpDown9.Value, ELIMINAR.style9)
        Dim textFont10 As New Font("Arial", ELIMINAR.NumericUpDown10.Value, ELIMINAR.style10)
        Dim textFont11 As New Font("Arial", ELIMINAR.NumericUpDown11.Value, ELIMINAR.style11)
        Dim textFont12 As New Font("Arial", ELIMINAR.NumericUpDown12.Value, ELIMINAR.style12)
        Dim textFontPred1 As New Font("Arial", 8, FontStyle.Regular)
        Dim textFontPred2 As New Font("Arial", 8, FontStyle.Bold)


        ' la posición superior
        Dim yPos1 As Single = textFont1.GetHeight(e.Graphics)
        Dim yPos2 As Single = textFont2.GetHeight(e.Graphics)
        Dim yPos3 As Single = textFont3.GetHeight(e.Graphics)
        Dim yPos4 As Single = textFont4.GetHeight(e.Graphics)
        Dim yPos5 As Single = textFont5.GetHeight(e.Graphics)
        Dim yPos6 As Single = textFont6.GetHeight(e.Graphics)
        Dim yPos7 As Single = textFont7.GetHeight(e.Graphics)
        Dim yPos8 As Single = textFont8.GetHeight(e.Graphics)
        Dim yPos9 As Single = textFont9.GetHeight(e.Graphics)
        Dim yPos10 As Single = textFont10.GetHeight(e.Graphics)
        Dim yPos11 As Single = textFont11.GetHeight(e.Graphics)
        Dim yPos12 As Single = textFont12.GetHeight(e.Graphics)
        Dim yPosPred1 As Single = textFontPred1.GetHeight(e.Graphics)
        Dim yPosPred2 As Single = textFontPred2.GetHeight(e.Graphics)
        Dim yIncrement As Single = 20

        ' imprimimos la cadena
        If ELIMINAR.TextBox1.Text.Trim <> "" Then

            e.Graphics.DrawString(ELIMINAR.TextBox1.Text, textFont1, Brushes.Black, 156, yPos1 + yIncrement, textFormat)

        End If

        If ELIMINAR.TextBox2.Text.Trim <> "" Then
            yIncrement += 20
            e.Graphics.DrawString(ELIMINAR.TextBox2.Text, textFont2, Brushes.Black, 156, yPos2 + yIncrement, textFormat)
        End If

        If ELIMINAR.TextBox3.Text.Trim <> "" Then
            yIncrement += 20
            e.Graphics.DrawString(ELIMINAR.TextBox3.Text, textFont3, Brushes.Black, 156, yPos3 + yIncrement, textFormat)
        End If

        If ELIMINAR.TextBox4.Text.Trim <> "" Then
            yIncrement += 20
            e.Graphics.DrawString(ELIMINAR.TextBox4.Text, textFont4, Brushes.Black, 156, yPos4 + yIncrement, textFormat)
        End If

        If ELIMINAR.TextBox5.Text.Trim <> "" Then
            yIncrement += 20
            e.Graphics.DrawString(ELIMINAR.TextBox5.Text, textFont5, Brushes.Black, 156, yPos5 + yIncrement, textFormat)
        End If

        If ELIMINAR.TextBox6.Text.Trim <> "" Then
            yIncrement += 20
            e.Graphics.DrawString(ELIMINAR.TextBox6.Text, textFont6, Brushes.Black, 156, yPos6 + yIncrement, textFormat)
        End If

        yIncrement += 20
        e.Graphics.DrawString("**********************************************************************", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)
        yIncrement += 20
        e.Graphics.DrawString("FACTURA No:  200", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString("PLACA: XXX00X", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString("VEHICULO: MOTO", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString("INGRESO: 0000/00/00 00:00:00", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString("SALIDA: 0000/00/00 00:00:00", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString("**********************************************************************", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)
        yIncrement += 20
        e.Graphics.DrawString("PARQUEADERO", textFontPred2, Brushes.Black, 156, yPosPred2 + yIncrement, textFormat)
        yIncrement += 20
        e.Graphics.DrawString("MINUTOS: 37", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString(" ", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)
        yIncrement += 20
        e.Graphics.DrawString("TOTAL PARQUEADERO: $1600", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString("DTO 50%: $800", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString("SUBTOTAL: $800", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString("------------------------------------------------------------", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)
        yIncrement += 20
        e.Graphics.DrawString("SERVICIOS", textFontPred2, Brushes.Black, 156, yPosPred2 + yIncrement, textFormat)
        yIncrement += 20
        e.Graphics.DrawString("ENJUAGUE: $8000", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString("GENERAL: $10000", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString("OTRO: $12500", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString(" ", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)
        yIncrement += 20
        e.Graphics.DrawString("SUBTOTAL: $30500", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString("------------------------------------------------------------", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)
        yIncrement += 20
        e.Graphics.DrawString("IVA 19%: $6100", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString("TOTAL FACTURA: $31300", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 20
        e.Graphics.DrawString("**********************************************************************", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)

        If ELIMINAR.TextBox7.Text.Trim <> "" Then
            yIncrement += 20
            e.Graphics.DrawString(ELIMINAR.TextBox7.Text, textFont7, Brushes.Black, 156, yPos7 + yIncrement, textFormat)

        End If

        If ELIMINAR.TextBox8.Text.Trim <> "" Then
            yIncrement += 20
            e.Graphics.DrawString(ELIMINAR.TextBox8.Text, textFont8, Brushes.Black, 156, yPos8 + yIncrement, textFormat)
        End If

        If ELIMINAR.TextBox9.Text.Trim <> "" Then
            yIncrement += 20
            e.Graphics.DrawString(ELIMINAR.TextBox9.Text, textFont9, Brushes.Black, 156, yPos9 + yIncrement, textFormat)
        End If

        If ELIMINAR.TextBox10.Text.Trim <> "" Then
            yIncrement += 20
            e.Graphics.DrawString(ELIMINAR.TextBox10.Text, textFont10, Brushes.Black, 156, yPos10 + yIncrement, textFormat)
        End If

        If ELIMINAR.TextBox11.Text.Trim <> "" Then
            yIncrement += 20
            e.Graphics.DrawString(ELIMINAR.TextBox11.Text, textFont11, Brushes.Black, 156, yPos11 + yIncrement, textFormat)
        End If

        If ELIMINAR.TextBox12.Text.Trim <> "" Then
            yIncrement += 20
            e.Graphics.DrawString(ELIMINAR.TextBox12.Text, textFont12, Brushes.Black, 156, yPos12 + yIncrement, textFormat)
        End If




        ' indicamos que ya no hay nada más que imprimir
        ' (el valor predeterminado de esta propiedad es False)
        e.HasMorePages = False
    End Sub


    Public Sub CreatePrintPreviewControl(ByVal docToPrint As PrintDocument)
        Dim ppc = New PrintPreviewControl()
        ppc.Name = "PrintPreviewControl1"
        ppc.Dock = DockStyle.Fill
        ppc.Location = New Point(88, 80)
        ppc.Document = docToPrint
        ppc.Zoom = 0.9
        ppc.Document.DocumentName = "c:\"
        ppc.UseAntiAlias = True
        'AddHandler docToPrint.PrintPage, AddressOf PrintPage 'Agregar PrintPreviewControl a los controles del formulario.Add (ppc) 
        Controls.Add(ppc)
    End Sub

    Private Sub ELIMINAR2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class