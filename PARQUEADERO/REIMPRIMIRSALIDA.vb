
Imports System.Diagnostics
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Drawing.Printing

Public Class REIMPRIMIRSALIDA
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion2, conexion, conexion3, conexion1 As New MySqlConnection(cadena)
    Dim imagenbarras As Image
    Dim conversorMoneda As New conversorMoneda
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        consulta_datoscopia()
        _dtvdatoscopia.RowFilter = "placa like '%" & TextBox1.Text & "%'"
        Me.DataGridView1.DataSource = _dtvdatoscopia
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        'Try
        '    Dim alto As Single = 0

        '    alto = Convert.ToSingle(60)

        '    Dim bm As Bitmap = Nothing
        '    bm = Codigos.codigo128(Lbl_placa.Text, CheckBox1.Checked, alto)
        '    If Not IsNothing(bm) Then
        '        PictureBox1.Image = bm
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

        'imagenbarras = PictureBox1.Image
        'ListBox1.Items.(imagenbarras)
        PrintDocument1.Print()

        Me.Close()
        Form1.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        'ListBox1.Items.Clear()

        Lbl_factura.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        Lbl_placa.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value
        Lbl_hora_ingreso.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value
        Lbl_horasalida.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(3).Value
        Lbl_tiempo.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(4).Value
        Lbl_total.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value
        Lbl_tarifa.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(6).Value
        txtPlaca.Text = Lbl_placa.Text
        AddHandler Me.PrintDocument1.PrintPage, AddressOf PrintDocument2_PrintPage
        PrintPreviewControl1.Document = PrintDocument1
        'Dim enjuague As String = "0"
        'Dim general As String = "0"
        'Dim tapiceria As String = "0"
        'Dim Motor As String = "0"
        'Dim otro As String = "0"
        'Dim parqueadero As String = "0"
        'Dim descuento As String = "0"
        'Dim aplicable As String = "0"
        'Dim tipoDescuento As String = "0"
        'Dim iva As String = "0"

        'Dim cmd1 As New MySqlCommand("SELECT servicio1, servicio2, servicio3, servicio4, servicio5, servicio6, servicio7, servicio8, servicio9, servicio10, servicio11, servicio12,servicio13,servicio14, otro,parqueadero,descuento,tipoDescuento,aplicable,iva FROM ventas WHERE factura='" & Lbl_factura.Text & "'", conexion1)
        'Try
        '    Dim lectura2 As MySqlDataReader
        '    If Not conexion1 Is Nothing Then conexion1.Close()
        '    conexion1.Open()
        '    lectura2 = cmd1.ExecuteReader()
        '    If lectura2.Read() Then
        '        enjuague = Val(lectura2(0)) + Val(lectura2(1)) + Val(lectura2(2)) + Val(lectura2(3))
        '        general = Val(lectura2(4)) + Val(lectura2(5)) + Val(lectura2(6)) + Val(lectura2(7))
        '        tapiceria = Val(lectura2(8)) + Val(lectura2(9)) + Val(lectura2(10))
        '        Motor = Val(lectura2(11)) + Val(lectura2(12)) + Val(lectura2(13))
        '        otro = Val(lectura2(14))
        '        parqueadero = Val(lectura2(15))
        '        descuento = Val(lectura2(16))
        '        tipoDescuento = lectura2(17)
        '        aplicable = lectura2(18)
        '        iva = lectura2(19)
        '    End If
        '    conexion1.Close()
        'Catch ex As Exception

        'End Try



        'Dim subtotal As Double = 0
        'Dim desServicio As Double = 0
        'Dim desParqueadero As Double = 0
        'Dim desParqueaderoServicio As Double = 0



        'If descuento <> "0" And tipoDescuento <> "0" And aplicable <> "0" Then

        '    If tipoDescuento = "$" Then

        '        If aplicable = "P" Then

        '            desParqueadero = Val(descuento)

        '        ElseIf aplicable = "S" Then

        '            desServicio = Val(descuento)

        '        ElseIf aplicable = "P+S" Then

        '            desParqueaderoServicio = Val(descuento)

        '        End If

        '    End If

        '    If tipoDescuento = "%" Then

        '        If aplicable = "P" Then

        '            desParqueadero = (Val(parqueadero) * Val(descuento)) / 100

        '        ElseIf aplicable = "S" Then

        '            desServicio = ((Val(enjuague) + Val(tapiceria) + Val(general) + Val(Motor) + Val(otro)) * Val(descuento)) / 100

        '        ElseIf aplicable = "P+S" Then

        '            desParqueaderoServicio = Val(enjuague) + Val(tapiceria) + Val(general) + Val(Motor) + Val(parqueadero) + Val(otro) - (((Val(enjuague) + Val(tapiceria) + Val(general) + Val(Motor) + Val(parqueadero) + Val(otro)) * Val(descuento)) / 100)

        '        End If

        '    End If

        'End If

        'Dim ivaPesos As Double = 0
        'Dim totalDescuento As Double = 0
        'totalDescuento = desParqueadero + desServicio + desParqueaderoServicio
        'ivaPesos = Val(Val(enjuague) + Val(general) + Val(Motor) + Val(tapiceria) + Val(parqueadero) + Val(otro)) * Val(iva) / 100
        'subtotal = (Val(enjuague) + Val(general) + Val(Motor) + Val(tapiceria) + Val(parqueadero) + Val(otro)) - totalDescuento

        'Dim lblTotalFactura As String = "0"
        'lblTotalFactura = conversorMoneda.ajustar_precio(Convert.ToString(subtotal))






        'ListBox1.Items.Add("          ")
        'ListBox1.Items.Add("   PARQUEADERO Y AUTOLAVADO ")
        'ListBox1.Items.Add("                      MOMPY")
        'ListBox1.Items.Add("            CALLE 94 A N 13-71 ")
        'ListBox1.Items.Add("            TEL:3102525836 ")
        'ListBox1.Items.Add("            NIT:900364279-4 ")
        'ListBox1.Items.Add("   ******************************* ")
        'ListBox1.Items.Add(("   FACTURA No:    ") & (Me.Lbl_factura.Text))
        'ListBox1.Items.Add(("   PLACA:     ") & (Me.Lbl_placa.Text))

        'Dim contador As Integer = 0
        'Dim letras As String
        'For i = 1 To Me.txtPlaca.TextLength
        '    letras = Mid(Me.txtPlaca.Text, i, 1)
        '    If letras = "0" Or letras = "1" Or letras = "2" Or letras = "3" Or letras = "4" Or letras = "5" Or letras = "6" Or letras = "7" Or letras = "8" Or letras = "9" Then
        '        contador = contador + 1
        '    End If
        'Next

        'If contador <> 3 And contador <> 2 And contador <> 0 Then
        '    ListBox1.Items.Add("   VEHICULO: OTRO     ")
        'End If
        'If contador = 3 Then
        '    ListBox1.Items.Add("   VEHICULO: AUTO     ")
        'End If
        'If contador = 2 Then
        '    ListBox1.Items.Add("   VEHICULO: MOTO    ")
        'End If
        'If contador = 0 Then
        '    ListBox1.Items.Add("   VEHICULO: BICICLETA    ")
        'End If

        'ListBox1.Items.Add(("   INGRESO:") & (Me.Lbl_hora_ingreso.Text))
        'ListBox1.Items.Add(("   SALIDA:") & (Me.Lbl_horasalida.Text))

        'ListBox1.Items.Add("    ******************************* ")

        'If parqueadero <> 0 Then
        '    ListBox1.Items.Add("                   PARQUEADERO                ")
        '    ListBox1.Items.Add(("   MINUTOS:") & (Me.Lbl_tiempo.Text))
        '    ListBox1.Items.Add("   ")
        '    ListBox1.Items.Add(("   TOTAL PARQUEADERO:$") & (parqueadero))
        '    If descuento <> "0" And tipoDescuento <> "0" And aplicable <> "0" And aplicable = "P" Then
        '        If tipoDescuento = "%" Then
        '            ListBox1.Items.Add(("   DTO " & descuento & "%" & ": ") & ("$" & desParqueadero))
        '        ElseIf tipoDescuento = "$" Then
        '            ListBox1.Items.Add(("   DTO: ") & ("$" & descuento))
        '        End If
        '    End If
        '    ListBox1.Items.Add(("   SUBTOTAL:$") & (parqueadero - desParqueadero))
        '    ListBox1.Items.Add("   ----------------------------------------------")

        'End If



        'If enjuague <> 0 Or general <> 0 Or tapiceria <> 0 Or Motor <> 0 Or otro <> 0 Then

        '    ListBox1.Items.Add("                      SERVICIOS")

        '    If enjuague <> 0 Then

        '        ListBox1.Items.Add(("   ENJUAGUE:$") & (enjuague))
        '    End If
        '    If general <> 0 Then

        '        ListBox1.Items.Add(("   GENERAL:$") & (general))
        '    End If
        '    If tapiceria <> 0 Then

        '        ListBox1.Items.Add(("   TAPICERIA:$") & (tapiceria))
        '    End If
        '    If Motor <> 0 Then
        '        ListBox1.Items.Add(("   GENERAL+MOTOR:$") & (Motor))
        '    End If
        '    If otro <> 0 Then
        '        ListBox1.Items.Add(("   OTRO:$") & (otro))
        '    End If
        '    ListBox1.Items.Add("   ")

        '    If descuento <> "0" And tipoDescuento <> "0" And aplicable <> "0" And aplicable = "S" Then
        '        If tipoDescuento = "%" Then
        '            ListBox1.Items.Add(("   DTO " & descuento & "%" & ": ") & ("$" & desServicio))
        '        ElseIf tipoDescuento = "$" Then
        '            ListBox1.Items.Add(("   DTO: ") & ("$" & descuento))
        '        End If
        '    End If
        '    ListBox1.Items.Add(("   SUBTOTAL: $") & (Val(enjuague) + Val(general) + Val(tapiceria) + Val(Motor) + Val(otro) - desServicio))
        '    ListBox1.Items.Add("   ----------------------------------------------")

        'End If

        'If descuento <> "0" And tipoDescuento <> "0" And aplicable <> "0" And aplicable = "P+S" Then
        '    If tipoDescuento = "%" Then
        '        ListBox1.Items.Add(("   DTO " & descuento & "%" & ":") & ("$" & desParqueaderoServicio))
        '    ElseIf tipoDescuento = "$" Then
        '        ListBox1.Items.Add(("   DTO:") & ("$" & descuento))
        '    End If
        'End If
        'ListBox1.Items.Add(("    IVA " & iva & "%:  ") & (ivaPesos))
        'ListBox1.Items.Add(("   TOTAL FACTURA:$ ") & (lblTotalFactura))

        'ListBox1.Items.Add("    ******************************* ")

        'ListBox1.Items.Add("    HORARIO TODOS LOS DIAS ")
        'ListBox1.Items.Add("                  24 HORAS ")
        'ListBox1.Items.Add("         Poliza de responsabilidad civil   ")
        'ListBox1.Items.Add("21-02-101005750 vigencia Hasta 11/11/2019")
        'ListBox1.Items.Add(" Resolución DIAN: 18762003223973    ")

        'Dim cmd2 As New MySqlCommand("SELECT auto,moto,bicicleta,otroVehiculo FROM ventas WHERE factura='" & Lbl_factura.Text & "'", conexion1)
        'Try
        '    Dim lectura2 As MySqlDataReader
        '    If Not conexion1 Is Nothing Then conexion1.Close()
        '    conexion1.Open()
        '    lectura2 = cmd2.ExecuteReader()
        '    If lectura2.Read() Then
        '        ListBox1.Items.Add("Tarifas carros $" & lectura2(0) & " motos $" & lectura2(1) & " bici $" & lectura2(2) & " otros $" & lectura2(3))
        '    End If
        '    conexion1.Close()
        'Catch ex As Exception

        'End Try


        'ListBox1.Items.Add("          Actividad Económica ICA 204 ")
        'ListBox1.Items.Add("             TARIFA 9.66 X 1000")
        'ListBox1.Items.Add("              COPIA DE FACTURA")

        'ListBox1.Items.Add("     ")
        'ListBox1.Items.Add("     ")
    End Sub

    Dim total, gasto1 As Integer
    Private Sub REIMPRIMIR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dtsdatoscopia.Reset()
        consulta_datoscopia()
        _dtvdatoscopia.RowFilter = "placa like '%" & TextBox1.Text & "%'"
        Me.DataGridView1.DataSource = _dtvdatoscopia
    End Sub
    'Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
    '    Dim fnt As New Font("Times New Roman", 10, FontStyle.Regular, GraphicsUnit.Point)
    '    Dim ListBoxItem As String = String.Empty
    '    For Each LBItem As String In ListBox1.Items
    '        ListBoxItem = ListBoxItem & vbCrLf & LBItem
    '    Next
    '    ListBoxItem = ListBoxItem.Substring(vbCrLf.Length)
    '    e.Graphics.DrawString(ListBoxItem, fnt, Brushes.Black, 0, 0)
    '    ' e.Graphics.DrawImage(PictureBox1.Image, 90, 220)
    '    e.HasMorePages = False



    'End Sub





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
        Dim iva As String = "0"

        Dim cmd1 As New MySqlCommand("SELECT servicio1, servicio2, servicio3, servicio4, servicio5, servicio6, servicio7, servicio8, servicio9, servicio10, servicio11, servicio12,servicio13,servicio14, otro,parqueadero,descuento,tipoDescuento,aplicable,iva FROM ventas WHERE factura='" & Lbl_factura.Text & "'", conexion1)
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
                otro = Val(lectura2(14))
                parqueadero = Val(lectura2(15))
                descuento = Val(lectura2(16))
                tipoDescuento = lectura2(17)
                aplicable = lectura2(18)
                iva = lectura2(19)
            End If
            conexion1.Close()
        Catch ex As Exception

        End Try



        Dim subtotal As Double = 0
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

                    desParqueaderoServicio = Val(enjuague) + Val(tapiceria) + Val(general) + Val(Motor) + Val(parqueadero) + Val(otro) - (((Val(enjuague) + Val(tapiceria) + Val(general) + Val(Motor) + Val(parqueadero) + Val(otro)) * Val(descuento)) / 100)

                End If

            End If

        End If

        Dim ivaPesos As Double = 0
        Dim totalDescuento As Double = 0
        totalDescuento = desParqueadero + desServicio + desParqueaderoServicio
        ivaPesos = Val(Val(enjuague) + Val(general) + Val(Motor) + Val(tapiceria) + Val(parqueadero) + Val(otro)) * Val(iva) / 100
        subtotal = (Val(enjuague) + Val(general) + Val(Motor) + Val(tapiceria) + Val(parqueadero) + Val(otro)) - totalDescuento

        Dim lblTotalFactura As String = "0"
        lblTotalFactura = conversorMoneda.ajustar_precio(Convert.ToString(subtotal))




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
        e.Graphics.DrawString("FACTURA No: " & Me.Lbl_factura.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("PLACA: " & Me.Lbl_placa.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)


        Dim contador As Integer = 0
        Dim letras As String
        For i = 1 To Me.txtPlaca.TextLength
            letras = Mid(Me.txtPlaca.Text, i, 1)
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
        e.Graphics.DrawString("INGRESO: " & Me.Lbl_hora_ingreso.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("SALIDA: " & Me.Lbl_horasalida.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)


        yIncrement += 15
        e.Graphics.DrawString("**********************************************************************", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)

        If parqueadero <> 0 Then

            yIncrement += 15
            e.Graphics.DrawString("PARQUEADERO", textFontPred2, Brushes.Black, 156, yPosPred2 + yIncrement, textFormat)

            yIncrement += 15
            e.Graphics.DrawString("MINUTOS: " & Me.Lbl_tiempo.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            yIncrement += 15
            e.Graphics.DrawString(" ", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            yIncrement += 15
            e.Graphics.DrawString("TOTAL PARQUEADERO: " & parqueadero, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)

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
            e.Graphics.DrawString("SUBTOTAL: $" & parqueadero - desParqueadero, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            yIncrement += 15
            e.Graphics.DrawString("----------------------------------------------", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)

        End If



        If enjuague <> 0 Or general <> 0 Or tapiceria <> 0 Or Motor <> 0 Or otro <> 0 Then

            yIncrement += 15
            e.Graphics.DrawString("SERVICIOS", textFontPred2, Brushes.Black, 156, yPosPred2 + yIncrement, textFormat)

            If enjuague <> 0 Then
                yIncrement += 15
                e.Graphics.DrawString("ENJUAGUE: $ " & enjuague, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            End If
            If general <> 0 Then
                yIncrement += 15
                e.Graphics.DrawString("GENERAL: $" & general, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            End If
            If tapiceria <> 0 Then
                yIncrement += 15
                e.Graphics.DrawString("TAPICERIA: $" & tapiceria, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            End If
            If Motor <> 0 Then
                yIncrement += 15
                e.Graphics.DrawString("MOTOR: $" & Motor, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            End If
            If otro <> 0 Then
                yIncrement += 15
                e.Graphics.DrawString("OTROS: $" & otro, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
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
            e.Graphics.DrawString("SUBTOTAL: $" & (Val(enjuague) + Val(general) + Val(tapiceria) + Val(Motor) + Val(otro) - desServicio), textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
            yIncrement += 15
            e.Graphics.DrawString("---------------------------------------------- ", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)

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
        e.Graphics.DrawString("IVA " & iva & "%: $" & ivaPesos, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("TOTAL FACTURA: $" & lblTotalFactura, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)


        yIncrement += 15
        e.Graphics.DrawString("**********************************************************************", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)
        yIncrement += 15
        e.Graphics.DrawString("TARIFAS DE PARQUEO", textFontPred2, Brushes.Black, 156, yPosPred2 + yIncrement, textFormat)


        Try
            Dim cmd2 As New MySqlCommand("SELECT auto,moto,bicicleta,otroVehiculo FROM ventas WHERE factura='" & Lbl_factura.Text & "'", conexion1)
            Dim lectura2 As MySqlDataReader
            If Not conexion1 Is Nothing Then conexion1.Close()
            conexion1.Open()
            lectura2 = cmd2.ExecuteReader()
            If lectura2.Read() Then
                yIncrement += 15
                e.Graphics.DrawString("AUTO $" & lectura2(0) & " MOTO $" & lectura2(1) & " BICI $" & lectura2(2) & " OTROS $" & lectura2(3), textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)
            End If
            conexion1.Close()
        Catch ex As Exception

        End Try





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




        ' indicamos que ya no hay nada más que imprimir
        ' (el valor predeterminado de esta propiedad es False)
        e.HasMorePages = False

    End Sub


End Class