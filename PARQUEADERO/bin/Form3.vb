Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports MySql.Data

Imports System.Diagnostics
Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices
Public Class Form3
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion As New MySqlConnection(cadena)

    Private Sub Label10_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'PrintForm1.PrinterSettings.DefaultPageSettings.Landscape = True
        Try
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

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        Label12.Text = Form1.TextBox3.Text
        Label14.Text = Form1.Label12.Text
        Label16.Text = Form1.Label11.Text
        'Label7.Text = Form1.Label9.Text
        '''''''''''''''''''''''''''''''''''''Label9.Text = Form1.Label14.Text
        Label19.Text = Form1.Label16.Text
        'form 1.label 14 es el valor del servicio de lavados
        'label 17 es el valor de parqueadero
        'si  hay lavado se descuenta una hora deparqueadero y si hay tapizado no se cobra parqueo

        'Dim totalfact As Double
        'Label17.Text = Form1.Label24.Text

        'If Label17.Text = 1 Then
        '    Form1.Label17.Text = 20000
        'End If
        'If Label17.Text = 2 Then
        '    Form1.Label17.Text = 10000
        'End If
        ''FORM1 LABEL 9 TIENEN EL TIEMPO DE PARQUEO
        ''LABEL 9 FORM 3 ESTE TIENE LA INFO DEL SERVICIO
        'If Label9.Text > 15999 And Form1.Label9.Text < 59 Then
        '    Form1.Label17.Text = Val(Form1.Label17.Text)
        'End If
        'Dim tiempo_descontado As Integer
        'Dim TIEMPO As Integer
        'If Label9.Text > 15999 And Form1.Label9.Text > 60 Then
        '    TIEMPO = Val(Form1.Label9.Text)
        '    tiempo_descontado = TIEMPO - 60
        '    Form1.Label17.Text = Val(Form1.Label17.Text)
        'End If

        'If Label9.Text > 120000 Then
        '    Form1.Label17.Text = 0
        'End If

        'totalfact = Val(Label9.Text) + Val(Form1.Label17.Text)

        'Me.Label9.Text = CStr(Math.Round(totalfact / 50) * 50)
        Label9.Text = Form1.Label34.Text
        Dim iva As Integer
        Dim subtotal As Integer
        iva = Val(Form1.Label34.Text) * 19 / 100
        subtotal = Val(Form1.Label34.Text) - iva
        Label28.Text = subtotal
        Label30.Text = iva
        Dim tiempos As String
        tiempos = Form1.Label9.Text
        Label33.Text = tiempos
        Dim conexion As New class_int
        Dim datos As New class_datos
        ' Dim placa_salida As String




        Dim Query As String
        Try
            If varconex.State = ConnectionState.Open Then varconex.Close()

            Query = "update ingreso_vehiculos SET  total= " & Label9.Text & "  where Factura= " & Form1.Label16.Text & ""
            varconex.Open()
            Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd2.ExecuteNonQuery()

            varconex.Close()


        Catch ex As Exception
            MsgBox("fallo de actualización", vbExclamation, "Atención      SKYNET")


        End Try



    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub

    Private Sub Label17_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label20_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs) Handles Label19.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click

    End Sub

    Private Sub Label24_Click(sender As Object, e As EventArgs) Handles Label24.Click

    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label22_Click(sender As Object, e As EventArgs) Handles Label22.Click

    End Sub

    Private Sub Label10_Click_1(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label34_Click(sender As Object, e As EventArgs) Handles Label34.Click

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click

    End Sub
End Class

