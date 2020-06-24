Imports System.Configuration
Imports System.Drawing.Printing
Imports System.Timers
Imports MySql.Data.MySqlClient

Module factura_cobrar
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconez, varconex, conexion1 As New MySqlConnection(cadena)
    Dim conexion2 As New MySqlConnection(cadena)
    Dim conversorMoneda As New conversorMoneda
    Dim total_factura As String = ""  'lblTotalFactura.text
    Dim iva_bd As String = "" 'label30.text
    Dim preview As New PrintPreviewDialog

    Public Sub cobrar()

        Dim PrintDocument1 As New PrintDocument

        preview.Opacity = 0

        AddHandler PrintDocument1.PrintPage, AddressOf PrintDocument2_PrintPage

        Dim hora As String
        hora = Form1.Label12.Text
        hora = Mid(hora, 11, 9)

        Dim valor As Integer
        ' valor = MsgBox("Desea Imprimir la Factura?", vbYesNo, "Factura")
        valor = MsgBox("TOTAL A PAGAR: $" & (total_factura) & " " + Chr(13) + "" + Chr(13) + "    Minutos:  " & Form1.Label9.Text & " " + Chr(13) + "" + Chr(13) + "    HORA INGRESO:  " & hora & "" + Chr(13) + "" + Chr(13) + "" + Chr(13) + "   ¿DESEA IMPRIMIR EL RECIBO?", vbYesNo, "COBRAR")


        If valor = 6 Then
            PrintDocument1.Print()
        Else
            preview.Visible = True
            preview.Document = PrintDocument1
        End If


    End Sub


    Public Sub PrintDocument2_PrintPage(sender As Object, e As PrintPageEventArgs)

        Dim enjuague As String = "0"
        Dim general As String = "0"
        Dim tapiceria As String = "0"
        Dim Motor As String = "0"
        Dim otro As String = "0"
        Dim parqueadero As String = "0"
        Dim descuento As String = "0"
        Dim aplicable As String = "0"
        Dim tipoDescuento As String = "0"

        Dim cmd1 As New MySqlCommand("SELECT servicio1, servicio2, servicio3, servicio4, servicio5, servicio6, servicio7, servicio8, servicio9, servicio10, servicio11, servicio12,servicio13,servicio14, otro,parqueadero,descuento,tipoDescuento,aplicable FROM ventas WHERE factura='" & Form1.Label16.Text & "'", conexion1)
        Try
            Dim lectura2 As MySqlDataReader
            If Not conexion1 Is Nothing Then conexion1.Close()
            conexion1.Open()
            lectura2 = cmd1.ExecuteReader()
            If lectura2.Read() Then
                enjuague = Val(lectura2(0)) + Val(lectura2(1)) + Val(lectura2(2)) + Val(lectura2(3))
                general = Val(lectura2(4)) + Val(lectura2(5)) + Val(lectura2(6)) + Val(lectura2(7))
                tapiceria = Val(lectura2(8)) + Val(lectura2(9)) + Val(lectura2(10))
                Motor = Val(lectura2(11)) + Val(lectura2(12)) + Val(lectura2(13))
                otro = conversorMoneda.ajustar_precio(Convert.ToString(lectura2(14)))
                parqueadero = conversorMoneda.ajustar_precio(Convert.ToString(lectura2(15)))
                descuento = Val(lectura2(16))
                tipoDescuento = lectura2(17)
                aplicable = lectura2(18)

            End If
            conexion1.Close()
        Catch ex As Exception

        End Try

        '555555555555

        '55555555555
        Dim factura As Double = 0
        Dim iva As String = 0
        Dim ivaPesos As Double = 0
        Dim cmd2 As New MySqlCommand("SELECT iva FROM title", conexion2)
        Try
            Dim lectura3 As MySqlDataReader
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            lectura3 = cmd2.ExecuteReader()
            If lectura3.Read() Then
                iva = lectura3(0)
                conexion2.Close()
            End If

        Catch ex As Exception

        End Try
        Dim Query2 As String
        Try
            If varconez.State = ConnectionState.Open Then varconez.Close()

            Query2 = "update ventas SET  iva='" & iva & "',auto='" & costos.carro.Text & "',moto='" & costos.moto.Text & "',bicicleta='" & costos.bicicleta.Text & "',otroVehiculo='" & costos.otro.Text & "'  WHERE factura='" & Form1.Label16.Text & "'"
            varconez.Open()
            Dim cmd4 As MySqlCommand = New MySqlCommand(Query2, varconez)
            cmd4.ExecuteNonQuery()

            varconez.Close()


        Catch ex As Exception
            MsgBox("fallo de actualización", vbExclamation, "Atención      SKYNET")


        End Try


        Dim subtotal As Double = 0
        Dim conexion As New class_int
        Dim datos As New class_datos
        Dim tiempos As String
        Dim desServicio As Double = 0
        Dim desParqueadero As Double = 0
        Dim desParqueaderoServicio As Double = 0



        If descuento <> "0" And tipoDescuento <> "0" And aplicable <> "0" Then

            If tipoDescuento = "$" Then

                If aplicable = "P" Then

                    desParqueadero = Val(descuento)

                ElseIf aplicable = "S" Then

                    desServicio = Val(descuento)

                ElseIf aplicable = "P+S" Then

                    desParqueaderoServicio = Val(descuento)

                End If

            End If

            If tipoDescuento = "%" Then

                If aplicable = "P" Then

                    desParqueadero = (Val(parqueadero) * Val(descuento)) / 100

                ElseIf aplicable = "S" Then

                    desServicio = ((Val(enjuague) + Val(tapiceria) + Val(general) + Val(Motor) + Val(otro)) * Val(descuento)) / 100

                ElseIf aplicable = "P+S" Then

                    desParqueaderoServicio = (((Val(enjuague) + Val(tapiceria) + Val(general) + Val(Motor) + Val(parqueadero) + Val(otro)) * Val(descuento)) / 100)

                End If

            End If

        End If




        Dim totalDescuento As Double = 0
        totalDescuento = desParqueadero + desServicio + desParqueaderoServicio

        ivaPesos = Convert.ToDouble(conversorMoneda.ajustar_precio(Convert.ToString((Val(Val(enjuague) + Val(general) + Val(Motor) + Val(tapiceria) + Val(parqueadero) + Val(otro)) / (1 + (Val(iva) / 100)))) * (Val(iva) / 100)))
        subtotal = Convert.ToDouble(conversorMoneda.ajustar_precio(Convert.ToString(Val(Val(enjuague) + Val(general) + Val(Motor) + Val(tapiceria) + Val(parqueadero) + Val(otro)) - totalDescuento)))

        total_factura = conversorMoneda.ajustar_precio(Convert.ToString(subtotal + ivaPesos))
        iva_bd = ivaPesos
        tiempos = Form1.Label9.Text


        Dim tipo1 As FontStyle = FontStyle.Regular
        Dim tipo2 As FontStyle = FontStyle.Regular
        Dim tipo3 As FontStyle = FontStyle.Regular
        Dim tipo4 As FontStyle = FontStyle.Regular
        Dim tipo5 As FontStyle = FontStyle.Regular
        Dim tipo6 As FontStyle = FontStyle.Regular
        Dim tipo7 As FontStyle = FontStyle.Regular
        Dim tipo8 As FontStyle = FontStyle.Regular
        Dim tipo9 As FontStyle = FontStyle.Regular
        Dim tipo10 As FontStyle = FontStyle.Regular
        Dim tipo11 As FontStyle = FontStyle.Regular
        Dim tipo12 As FontStyle = FontStyle.Regular

        Dim tamaño1 As Integer = 1
        Dim tamaño2 As Integer = 1
        Dim tamaño3 As Integer = 1
        Dim tamaño4 As Integer = 1
        Dim tamaño5 As Integer = 1
        Dim tamaño6 As Integer = 1
        Dim tamaño7 As Integer = 1
        Dim tamaño8 As Integer = 1
        Dim tamaño9 As Integer = 1
        Dim tamaño10 As Integer = 1
        Dim tamaño11 As Integer = 1
        Dim tamaño12 As Integer = 1

        Dim texto1 As String = ""
        Dim texto2 As String = ""
        Dim texto3 As String = ""
        Dim texto4 As String = ""
        Dim texto5 As String = ""
        Dim texto6 As String = ""
        Dim texto7 As String = ""
        Dim texto8 As String = ""
        Dim texto9 As String = ""
        Dim texto10 As String = ""
        Dim texto11 As String = ""
        Dim texto12 As String = ""

        Dim cmd5 As New MySqlCommand("SELECT * FROM config_factura", conexion2)


        Try

            Dim lectura3 As MySqlDataReader
            conexion2.Open()
            lectura3 = cmd5.ExecuteReader()
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

                If lectura3(0) = 7 Then
                    texto7 = lectura3(1)
                    tamaño7 = lectura3(2)
                    If lectura3(3) = "Bold" Then
                        tipo7 = FontStyle.Bold
                    End If
                End If

                If lectura3(0) = 8 Then
                    texto8 = lectura3(1)
                    tamaño8 = lectura3(2)
                    If lectura3(3) = "Bold" Then
                        tipo8 = FontStyle.Bold
                    End If
                End If

                If lectura3(0) = 9 Then
                    texto9 = lectura3(1)
                    tamaño9 = lectura3(2)
                    If lectura3(3) = "Bold" Then
                        tipo9 = FontStyle.Bold
                    End If
                End If

                If lectura3(0) = 10 Then
                    texto10 = lectura3(1)
                    tamaño10 = lectura3(2)
                    If lectura3(3) = "Bold" Then
                        tipo10 = FontStyle.Bold
                    End If
                End If

                If lectura3(0) = 11 Then
                    texto11 = lectura3(1)
                    tamaño11 = lectura3(2)
                    If lectura3(3) = "Bold" Then
                        tipo11 = FontStyle.Bold
                    End If
                End If

                If lectura3(0) = 12 Then
                    texto12 = lectura3(1)
                    tamaño12 = lectura3(2)
                    If lectura3(3) = "Bold" Then
                        tipo12 = FontStyle.Bold
                    End If
                End If

            End While
            conexion2.Close()
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
        Dim textFont7 As New Font("Arial", tamaño7, tipo7)
        Dim textFont8 As New Font("Arial", tamaño8, tipo8)
        Dim textFont9 As New Font("Arial", tamaño9, tipo9)
        Dim textFont10 As New Font("Arial", tamaño10, tipo10)
        Dim textFont11 As New Font("Arial", tamaño11, tipo11)
        Dim textFont12 As New Font("Arial", tamaño12, tipo12)
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
        Dim yIncrement As Single = 15

        ' imprimimos la cadena
        If texto1 <> "" Then

            e.Graphics.DrawString(texto1, textFont1, Brushes.Black, 156, yPos1 + yIncrement, textFormat)

        End If

        If texto2 <> "" Then
            yIncrement += 15
            e.Graphics.DrawString(texto2, textFont2, Brushes.Black, 156, yPos2 + yIncrement, textFormat)
        End If

        If texto3 <> "" Then
            yIncrement += 15
            e.Graphics.DrawString(texto3, textFont3, Brushes.Black, 156, yPos3 + yIncrement, textFormat)
        End If

        If texto4 <> "" Then
            yIncrement += 15
            e.Graphics.DrawString(texto4, textFont4, Brushes.Black, 156, yPos4 + yIncrement, textFormat)
        End If

        If texto5 <> "" Then
            yIncrement += 15
            e.Graphics.DrawString(texto5, textFont5, Brushes.Black, 156, yPos5 + yIncrement, textFormat)
        End If

        If texto6 <> "" Then
            yIncrement += 15
            e.Graphics.DrawString(texto6, textFont6, Brushes.Black, 156, yPos6 + yIncrement, textFormat)
        End If

        yIncrement += 15
        e.Graphics.DrawString("**********************************************************************", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)
        yIncrement += 15
        e.Graphics.DrawString("FACTURA No: " & Form1.Label16.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("PLACA: " & Form1.TextBox3.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)


        Dim contador As Integer = 0
        Dim letras As String
        For i = 1 To Form1.TextBox3.TextLength
            letras = Mid(Form1.TextBox3.Text, i, 1)
            If letras = "0" Or letras = "1" Or letras = "2" Or letras = "3" Or letras = "4" Or letras = "5" Or letras = "6" Or letras = "7" Or letras = "8" Or letras = "9" Then
                contador = contador + 1
            End If
        Next

        If contador <> 3 And contador <> 2 And contador <> 0 Then
            yIncrement += 15
            e.Graphics.DrawString("VEHICULO: OTRO", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        End If
        If contador = 3 Then
            yIncrement += 15
            e.Graphics.DrawString("VEHICULO: AUTO", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        End If
        If contador = 2 Then
            yIncrement += 15
            e.Graphics.DrawString("VEHICULO: MOTO", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        End If
        If contador = 0 Then
            yIncrement += 15
            e.Graphics.DrawString("VEHICULO: BICICLETA", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        End If

        yIncrement += 15
        e.Graphics.DrawString("INGRESO: " & Form1.Label12.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("SALIDA: " & Form1.Label11.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)

        yIncrement += 15
        e.Graphics.DrawString("**********************************************************************", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)

        If parqueadero <> 0 Then

            yIncrement += 15
            e.Graphics.DrawString("PARQUEADERO", textFontPred2, Brushes.Black, 156, yPosPred2 + yIncrement, textFormat)

            yIncrement += 15
            e.Graphics.DrawString("MINUTOS: " & Form1.Label9.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            yIncrement += 15
            e.Graphics.DrawString(" ", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            yIncrement += 15
            e.Graphics.DrawString("PARQUEADERO: $" & conversorMoneda.ajustar_precio(Convert.ToString(parqueadero)), textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)

            If descuento <> "0" And tipoDescuento <> "0" And aplicable <> "0" And aplicable = "P" Then
                If tipoDescuento = "%" Then
                    yIncrement += 15
                    e.Graphics.DrawString("DTO " & descuento & "%: $" & desParqueadero, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
                ElseIf tipoDescuento = "$" Then
                    yIncrement += 15
                    e.Graphics.DrawString("DTO: $" & descuento, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
                End If
            End If

            yIncrement += 15
            e.Graphics.DrawString("----------------------------------------------", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)

        End If



        If enjuague <> 0 Or general <> 0 Or tapiceria <> 0 Or Motor <> 0 Or otro <> 0 Then

            yIncrement += 15
            e.Graphics.DrawString("SERVICIOS", textFontPred2, Brushes.Black, 156, yPosPred2 + yIncrement, textFormat)

            If enjuague <> 0 Then
                yIncrement += 15
                e.Graphics.DrawString("ENJUAGUE: $ " & conversorMoneda.ajustar_precio(Convert.ToString(enjuague)), textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            End If
            If general <> 0 Then
                yIncrement += 15
                e.Graphics.DrawString("GENERAL: $" & conversorMoneda.ajustar_precio(Convert.ToString(general)), textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            End If
            If tapiceria <> 0 Then
                yIncrement += 15
                e.Graphics.DrawString("TAPICERIA: $" & conversorMoneda.ajustar_precio(Convert.ToString(tapiceria)), textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            End If
            If Motor <> 0 Then
                yIncrement += 15
                e.Graphics.DrawString("MOTOR: $" & conversorMoneda.ajustar_precio(Convert.ToString(Motor)), textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            End If
            If otro <> 0 Then
                yIncrement += 15
                e.Graphics.DrawString("OTROS: $" & conversorMoneda.ajustar_precio(Convert.ToString(otro)), textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            End If
            yIncrement += 15
            e.Graphics.DrawString(" ", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)

            If descuento <> "0" And tipoDescuento <> "0" And aplicable <> "0" And aplicable = "S" Then
                If tipoDescuento = "%" Then
                    yIncrement += 15
                    e.Graphics.DrawString("DTO " & descuento & "%: $" & desServicio, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
                ElseIf tipoDescuento = "$" Then
                    yIncrement += 15
                    e.Graphics.DrawString("DTO: $" & descuento, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
                End If
            End If

            yIncrement += 15
            e.Graphics.DrawString("---------------------------------------------- ", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)

            If varconex.State = ConnectionState.Open Then varconex.Close()
            Dim Query3 As String
            Query3 = "update ingreso_vehiculos SET  servicioReal='" & conversorMoneda.ajustar_precio(Convert.ToString(((Val(enjuague) + Val(general) + Val(tapiceria) + Val(Motor) + Val(otro)) - desServicio))) & "' where Factura='" & Form1.Label16.Text & "'"
            varconex.Open()
            Dim cmd3 As MySqlCommand = New MySqlCommand(Query3, varconex)
            cmd3.ExecuteNonQuery()

            varconex.Close()

        End If

        If descuento <> "0" And tipoDescuento <> "0" And aplicable <> "0" And aplicable = "P+S" Then
            If tipoDescuento = "%" Then
                yIncrement += 15
                e.Graphics.DrawString("DTO " & descuento & "%: $" & desParqueaderoServicio, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            ElseIf tipoDescuento = "$" Then
                yIncrement += 15
                e.Graphics.DrawString("DTO: $" & descuento, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            End If
        End If

        yIncrement += 15
        e.Graphics.DrawString("SUBTOTAL: $" & (conversorMoneda.ajustar_precio(Convert.ToString(subtotal))), textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("IVA " & iva & "%: $" & iva_bd, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("TOTAL FACTURA: $" & total_factura, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)


        yIncrement += 15
        e.Graphics.DrawString("**********************************************************************", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)
        yIncrement += 15
        e.Graphics.DrawString("TARIFAS DE PARQUEO", textFontPred2, Brushes.Black, 156, yPosPred2 + yIncrement, textFormat)
        yIncrement += 15
        e.Graphics.DrawString("AUTO $" & costos.carro.Text & " MOTO $" & costos.moto.Text & " BICI $" & costos.bicicleta.Text & " OTROS $" & costos.otro.Text, textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)



        If texto7 <> "" Then
            yIncrement += 15
            e.Graphics.DrawString(texto7, textFont7, Brushes.Black, 156, yPos7 + yIncrement, textFormat)

        End If

        If texto8 <> "" Then
            yIncrement += 15
            e.Graphics.DrawString(texto8, textFont8, Brushes.Black, 156, yPos8 + yIncrement, textFormat)
        End If

        If texto9 <> "" Then
            yIncrement += 15
            e.Graphics.DrawString(texto9, textFont9, Brushes.Black, 156, yPos9 + yIncrement, textFormat)
        End If

        If texto10 <> "" Then
            yIncrement += 15
            e.Graphics.DrawString(texto10, textFont10, Brushes.Black, 156, yPos10 + yIncrement, textFormat)
        End If

        If texto11 <> "" Then
            yIncrement += 15
            e.Graphics.DrawString(texto11, textFont11, Brushes.Black, 156, yPos11 + yIncrement, textFormat)
        End If

        If texto12 <> "" Then
            yIncrement += 15
            e.Graphics.DrawString(texto12, textFont12, Brushes.Black, 156, yPos12 + yIncrement, textFormat)
        End If

        Dim hora As String
        hora = Form1.Label12.Text
        hora = Mid(hora, 11, 9)

        ' MessageBox.Show("   TOTAL A PAGAR: " & (Form1.Label34.Text) & " " + Chr(13) + "" + Chr(13) + "   Minutos:" & Form1.Label9.Text & " " + Chr(13) + "" + Chr(13) + "   HORA INGRESO:" & hora & "")



        Dim Query As String
        Try
            If varconex.State = ConnectionState.Open Then varconex.Close()

            Query = "update ingreso_vehiculos SET  total='" & total_factura & "',parqueaderoReal='" & conversorMoneda.ajustar_precio(Convert.ToString((Val(parqueadero) - desParqueadero))) & "'  where Factura= " & Form1.Label16.Text & ""
            varconex.Open()
            Dim cmd3 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd3.ExecuteNonQuery()

            varconex.Close()


        Catch ex As Exception
            MsgBox("fallo de actualización", vbExclamation, "Atención      SKYNET")


        End Try




        ' indicamos que ya no hay nada más que imprimir
        ' (el valor predeterminado de esta propiedad es False)
        e.HasMorePages = False

        Try
            preview.Visible = False
        Catch ex As Exception

        End Try
    End Sub


End Module
