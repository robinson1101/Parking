
Imports System.Diagnostics
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports System.Drawing.Printing

Public Class TIKETINGRESO
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion2, conexion, conexion3 As New MySqlConnection(cadena)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Try


            AddHandler PrintDocument1.PrintPage, AddressOf PrintDocument2_PrintPage
            AddHandler PrintDocument1.PrintPage, AddressOf PrintDocument1_PrintPage

            Dim alto As Single = 0

            alto = Convert.ToSingle(60)

            Dim bm As Bitmap = Nothing
            bm = Codigos.codigo128(Form1.TextBox1.Text, CheckBox1.Checked, alto)
            If Not IsNothing(bm) Then
                PictureBox1.Image = bm
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'imagenbarras = PictureBox1.Image
        'ListBox1.Items.Add(imagenbarras)
        PrintDocument1.Print()

        Me.Close()
        Form1.Show()
    End Sub

    Dim imagenbarras As Image
    Private Sub TIKETINGRESO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.PerformClick()
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage

        Dim fnt As New Font("Arial", 8, FontStyle.Regular)
        Dim fnt0 As New Font("Arial", 8, FontStyle.Bold)

        Dim textFormat As StringFormat = New StringFormat
        textFormat.Alignment = StringAlignment.Center


        e.Graphics.DrawImage(PictureBox1.Image, 102, 210)
        e.Graphics.DrawString(Form1.TextBox1.Text, fnt, Brushes.Black, 156, 275, textFormat)
        e.HasMorePages = False

    End Sub

    Public Sub PrintDocument2_PrintPage(sender As Object, e As PrintPageEventArgs)
        Dim vehiculo As String = ""
        Dim contador As Integer = 0
        Dim letras As String

        For i = 1 To Form1.TextBox1.Text.Length
            letras = Mid(Form1.TextBox1.Text, i, 1)
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

        Dim estado As String
        estado = Form1.TextBox9.Text.Trim
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
        e.Graphics.DrawString("PLACA: " & Form1.TextBox1.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("VEHICULO: " & vehiculo, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("INGRESO: " & Form1.Label6.Text, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)
        yIncrement += 15
        e.Graphics.DrawString("ESTADO: " & estado, textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)

        e.HasMorePages = False
    End Sub

End Class