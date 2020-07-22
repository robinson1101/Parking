Imports System.Configuration
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient

Module factura_liquidar
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim conexion2 As New MySqlConnection(cadena)
    Dim total As Decimal = 0
    Dim nombre_operario As String = ""
    Dim fecha As String = ""



    Public Sub imprimir()
        total = liquidar.Label6.Text
        nombre_operario = liquidar.TextBox2.Text
        fecha = Form1.ITEMHORA.Text

        Dim PrintDocument1 As New PrintDocument
        AddHandler PrintDocument1.PrintPage, AddressOf PrintDocument2_PrintPage
        PrintDocument1.Print()
    End Sub

    Public Sub PrintDocument2_PrintPage(sender As Object, e As PrintPageEventArgs)


        Dim tipo1 As FontStyle = FontStyle.Regular
        Dim tipo2 As FontStyle = FontStyle.Regular
        Dim tipo3 As FontStyle = FontStyle.Regular
        Dim tipo4 As FontStyle = FontStyle.Regular
        Dim tipo5 As FontStyle = FontStyle.Regular
        Dim tipo6 As FontStyle = FontStyle.Regular


        Dim tamaño1 As Integer = 1
        Dim tamaño2 As Integer = 1
        Dim tamaño3 As Integer = 1
        Dim tamaño4 As Integer = 1
        Dim tamaño5 As Integer = 1
        Dim tamaño6 As Integer = 1


        Dim texto1 As String = ""
        Dim texto2 As String = ""
        Dim texto3 As String = ""
        Dim texto4 As String = ""
        Dim texto5 As String = ""
        Dim texto6 As String = ""


        Dim cmd2 As New MySqlCommand("SELECT * FROM config_factura", conexion2)

        Try

            Dim lectura3 As MySqlDataReader
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            lectura3 = cmd2.ExecuteReader()
            While lectura3.Read()
                If lectura3(0) = 1 Then
                    texto1 = lectura3(1)
                    tamaño1 = lectura3(2)
                    If lectura3(3) = "Bold" Then
                        tipo1 = FontStyle.Bold
                    End If
                End If

                If lectura3(0) = 2 Then
                    texto2 = lectura3(1)
                    tamaño2 = lectura3(2)
                    If lectura3(3) = "Bold" Then
                        tipo2 = FontStyle.Bold
                    End If
                End If

                If lectura3(0) = 3 Then
                    texto3 = lectura3(1)
                    tamaño3 = lectura3(2)
                    If lectura3(3) = "Bold" Then
                        tipo3 = FontStyle.Bold
                    End If
                End If

                If lectura3(0) = 4 Then
                    texto4 = lectura3(1)
                    tamaño4 = lectura3(2)
                    If lectura3(3) = "Bold" Then
                        tipo4 = FontStyle.Bold
                    End If
                End If

                If lectura3(0) = 5 Then
                    texto5 = lectura3(1)
                    tamaño5 = lectura3(2)
                    If lectura3(3) = "Bold" Then
                        tipo5 = FontStyle.Bold
                    End If
                End If

                If lectura3(0) = 6 Then
                    texto6 = lectura3(1)
                    tamaño6 = lectura3(2)
                    If lectura3(3) = "Bold" Then
                        tipo6 = FontStyle.Bold
                    End If
                End If



            End While

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try




        Dim textFormat As StringFormat = New StringFormat
        textFormat.Alignment = StringAlignment.Center


        ' Este evento se producirá cada vez que se imprima una nueva página
        ' imprimir HOLA MUNDO en Arial tamaño 24 y negrita

        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left
        ' La fuente a usar
        Dim textFont1 As New Font("Arial", tamaño1, tipo1)
        Dim textFont2 As New Font("Arial", tamaño2, tipo2)
        Dim textFont3 As New Font("Arial", tamaño3, tipo3)
        Dim textFont4 As New Font("Arial", tamaño4, tipo4)
        Dim textFont5 As New Font("Arial", tamaño5, tipo5)
        Dim textFont6 As New Font("Arial", tamaño6, tipo6)
        Dim textFontPred1 As New Font("Arial", 8, FontStyle.Regular)
        Dim textFontPred2 As New Font("Arial", 8, FontStyle.Bold)


        ' la posición superior
        Dim yPos1 As Single = textFont1.GetHeight(e.Graphics)
        Dim yPos2 As Single = textFont2.GetHeight(e.Graphics)
        Dim yPos3 As Single = textFont3.GetHeight(e.Graphics)
        Dim yPos4 As Single = textFont4.GetHeight(e.Graphics)
        Dim yPos5 As Single = textFont5.GetHeight(e.Graphics)
        Dim yPos6 As Single = textFont6.GetHeight(e.Graphics)
        Dim yPosPred1 As Single = textFontPred1.GetHeight(e.Graphics)
        Dim yPosPred2 As Single = textFontPred2.GetHeight(e.Graphics)
        Dim yIncrement As Single = 0

        ' imprimimos la cadena
        If texto1 <> "" Then
            yIncrement += yPos1 + yIncrement
            e.Graphics.DrawString(texto1, textFont1, Brushes.Black, 156, yIncrement, textFormat)

        End If

        If texto2 <> "" Then
            yIncrement += yPos2 + 3
            e.Graphics.DrawString(texto2, textFont2, Brushes.Black, 156, yIncrement, textFormat)
        End If

        If texto3 <> "" Then
            yIncrement += yPos3 + 3
            e.Graphics.DrawString(texto3, textFont3, Brushes.Black, 156, yIncrement, textFormat)
        End If

        If texto4 <> "" Then
            yIncrement += yPos4 + 3
            e.Graphics.DrawString(texto4, textFont4, Brushes.Black, 156, yIncrement, textFormat)
        End If

        If texto5 <> "" Then
            yIncrement += yPos5 + 3
            e.Graphics.DrawString(texto5, textFont5, Brushes.Black, 156, yIncrement, textFormat)
        End If

        If texto6 <> "" Then
            yIncrement += yPos6 + 3
            e.Graphics.DrawString(texto6, textFont6, Brushes.Black, 156, yIncrement, textFormat)
        End If

        yIncrement += 8
        e.Graphics.DrawString("**********************************************************************", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)
        yIncrement += 15
        e.Graphics.DrawString("PAGO NOMINA", textFontPred2, Brushes.Black, 156, yPosPred2 + yIncrement, textFormat)
        yIncrement += 20
        e.Graphics.DrawString("FECHA CORTE:", textFontPred2, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString(fecha, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("OPERARIO:", textFontPred2, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString(nombre_operario, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("TOTAL: $" & total, textFontPred2, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("FIRMA:", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)


        e.HasMorePages = False
    End Sub








End Module
