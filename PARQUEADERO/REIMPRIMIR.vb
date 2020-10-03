
Imports System.Diagnostics
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Drawing.Printing

Public Class REIMPRIMIR
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion2, conexion, conexion3 As New MySqlConnection(cadena)
    Dim imagenbarras As Image

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        consulta_datosreimprimirentrada()
        _dtvdatosreimprimirentrada.RowFilter = "placa like '%" & TextBox1.Text & "%'"


        Me.DataGridView1.DataSource = _dtvdatosreimprimirentrada
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        'imagenbarras = PictureBox1.Image
        'ListBox1.Items.Add(imagenbarras)


        PrintDocument1.Print()


    End Sub



    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        Lbl_placa.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value
        Lbl_hora_ingreso.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value
        Lbl_servicios.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(3).Value
        Lbl_tarifa.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(4).Value
        lblFactura.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        ' Usamos una clase del tipo PrintDocument
        Try
            Dim alto As Single = 0

            alto = Convert.ToSingle(60)

            Dim bm As Bitmap = Nothing
            bm = Codigos.codigo128(Lbl_placa.Text, CheckBox1.Checked, alto)
            If Not IsNothing(bm) Then
                PictureBox1.Image = bm
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
        ' asignamos el método de evento para cada página a imprimir

        AddHandler Me.PrintDocument1.PrintPage, AddressOf PrintDocument2_PrintPage
        AddHandler Me.PrintDocument1.PrintPage, AddressOf PrintDocument1_PrintPage
        PrintPreviewControl1.Document = PrintDocument1




    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Dim total, gasto1 As Integer
    Private Sub REIMPRIMIR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dtsdatosreimprimirentrada.Reset()
        consulta_datosreimprimirentrada()
        _dtvdatosreimprimirentrada.RowFilter = "placa like '%" & TextBox1.Text & "%'"


        Me.DataGridView1.DataSource = _dtvdatosreimprimirentrada
        DataGridView1.Columns(0).Width = 50
        DataGridView1.Columns(1).Width = 70
        DataGridView1.Columns(2).Width = 125
    End Sub
    Public Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        Dim fnt As New Font("Arial", 8, FontStyle.Regular)
        Dim fnt0 As New Font("Arial", 8, FontStyle.Bold)

        Dim textFormat As StringFormat = New StringFormat
        textFormat.Alignment = StringAlignment.Center

        e.Graphics.DrawString("COPIA", fnt0, Brushes.Black, 156, 210, textFormat)
        e.Graphics.DrawImage(PictureBox1.Image, 102, 230)
        e.Graphics.DrawString(Lbl_placa.Text, fnt, Brushes.Black, 156, 295, textFormat)
        e.HasMorePages = False


    End Sub


    Public Sub PrintDocument2_PrintPage(sender As Object, e As PrintPageEventArgs)

        Dim vehiculo As String = ""
        Dim contador As Integer = 0
        Dim letras As String

        For i = 1 To Lbl_placa.Text.Length
            letras = Mid(Lbl_placa.Text, i, 1)
            If letras = "0" Or letras = "1" Or letras = "2" Or letras = "3" Or letras = "4" Or letras = "5" Or letras = "6" Or letras = "7" Or letras = "8" Or letras = "9" Then
                contador = contador + 1
            End If
        Next

        If contador <> 3 And contador <> 2 And contador <> 0 Then
            vehiculo = "OTRO"
        End If
        If contador = 3 Then
            vehiculo = "AUTO"
        End If
        If contador = 2 Then
            vehiculo = "MOTO"
        End If
        If contador = 0 Then
            vehiculo = "BICICLETA"
        End If


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

        Dim cmd2 As New MySqlCommand("SELECT * FROM config_factura", conexion2)
        Dim cmd3 As New MySqlCommand("select estado FROM ingreso_vehiculos where Factura=" & lblFactura.Text & "", conexion2)
        Dim estado As String = ""
        Try
            Dim lectura4 As MySqlDataReader

            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            lectura4 = cmd3.ExecuteReader()
            If lectura4.Read Then
                estado = lectura4(0)
            End If
            conexion2.Close()

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
        e.Graphics.DrawString("PLACA: " & Me.Lbl_placa.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("VEHICULO: " & vehiculo, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("INGRESO: " & Me.Lbl_hora_ingreso.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("ESTADO: " & estado, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        'yIncrement += 15
        'e.Graphics.DrawString("**********************************************************************", textFontPred1, Brushes.Black, 156, yPosPred1 + yIncrement, textFormat)

        'If texto7 <> "" Then
        '    yIncrement += 15
        '    e.Graphics.DrawString(texto7, textFont7, Brushes.Black, 156, yPos7 + yIncrement, textFormat)

        'End If

        'If texto8 <> "" Then
        '    yIncrement += 15
        '    e.Graphics.DrawString(texto8, textFont8, Brushes.Black, 156, yPos8 + yIncrement, textFormat)
        'End If

        'If texto9 <> "" Then
        '    yIncrement += 15
        '    e.Graphics.DrawString(texto9, textFont9, Brushes.Black, 156, yPos9 + yIncrement, textFormat)
        'End If

        'If texto10 <> "" Then
        '    yIncrement += 15
        '    e.Graphics.DrawString(texto10, textFont10, Brushes.Black, 156, yPos10 + yIncrement, textFormat)
        'End If

        'If texto11 <> "" Then
        '    yIncrement += 15
        '    e.Graphics.DrawString(texto11, textFont11, Brushes.Black, 156, yPos11 + yIncrement, textFormat)
        'End If

        'If texto12 <> "" Then
        '    yIncrement += 15
        '    e.Graphics.DrawString(texto12, textFont12, Brushes.Black, 156, yPos12 + yIncrement, textFormat)
        'End If




        ' indicamos que ya no hay nada más que imprimir
        ' (el valor predeterminado de esta propiedad es False)
        e.HasMorePages = False
    End Sub


End Class