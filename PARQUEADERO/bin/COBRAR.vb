
Imports MySql.Data.MySqlClient
Imports System.Configuration
Imports MySql.Data

Imports System.Diagnostics
Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices

Public Class COBRAR
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion As New MySqlConnection(cadena)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Add("   PARQUEADERO Y AUTOLAVADO ")
        ListBox1.Items.Add("                      MOMPY")
        ListBox1.Items.Add("            CALLE 94 A N 13-71 ")
        ListBox1.Items.Add("            TEL:3102525836 ")
        ListBox1.Items.Add("            NIT:900364279-4 ")
        ListBox1.Items.Add("   ******************************* ")
        ListBox1.Items.Add(("   FACTURA No:     ") & (Form1.Label16.Text))
        ListBox1.Items.Add(("   PLACA:     ") & (Form1.TextBox3.Text))
        ListBox1.Items.Add(("   INGRESO:") & (Form1.Label12.Text))
        ListBox1.Items.Add(("   SALIDA:") & (Form1.Label11.Text))
        ListBox1.Items.Add(("   MINUTOS:") & (Form1.Label9.Text))
        ListBox1.Items.Add(("   TOTAL FACTURA:  ") & (Form1.Label34.Text))
        ListBox1.Items.Add(("   SUBTOTAL:  ") & (Label28.Text))
        ListBox1.Items.Add(("    IVA:  ") & (Label30.Text))
        ListBox1.Items.Add("    ******************************* ")

        If Val(Form1.Label24.Text) = 1 Then

            ListBox1.Items.Add("    Tarifa plena carros 20.000 ")
        End If
        If Val(Form1.TextBox10.Text) > 15999 Then

            ListBox1.Items.Add("    1 HORA DE PARQUEADERO GRATIS")
        End If
        If Val(Form1.Label24.Text) = 2 Then

            ListBox1.Items.Add("    Tarifa plena moto 10.000 ")
        End If
        ListBox1.Items.Add("    HORARIO TODOS LOS DIAS ")
        ListBox1.Items.Add("                  24 HORAS ")
        ListBox1.Items.Add("     SIN RECIBO NO SE ENTREGA")
        ListBox1.Items.Add("              EL VEHICULO")
        ListBox1.Items.Add("         Poliza de responsabilidad civil   ")
        ListBox1.Items.Add("21-02-101005750 vigencia Hasta 11/11/2019")
        ListBox1.Items.Add(" Resolución DIAN: 18762003223973    ")
        ListBox1.Items.Add("Tarifas carros $ 74 motos $67 bici $10   ")
        ListBox1.Items.Add("          Actividad Económica ICA 204 ")
        ListBox1.Items.Add("             TARIFA 9.66 X 1000")

        Dim hora As String
        hora = Form1.Label12.Text
        hora = Mid(hora, 11, 9)

        ' MessageBox.Show("   TOTAL A PAGAR: " & (Form1.Label34.Text) & " " + Chr(13) + "" + Chr(13) + "   Minutos:" & Form1.Label9.Text & " " + Chr(13) + "" + Chr(13) + "   HORA INGRESO:" & hora & "")

        Dim valor As Integer
        ' valor = MsgBox("Desea Imprimir la Factura?", vbYesNo, "Factura")
        valor = MsgBox("    TOTAL A PAGAR:  " & (Form1.Label34.Text) & " " + Chr(13) + "" + Chr(13) + "    Minutos:  " & Form1.Label9.Text & " " + Chr(13) + "" + Chr(13) + "    HORA INGRESO:  " & hora & "" + Chr(13) + "" + Chr(13) + "" + Chr(13) + "   ¿  DESEA IMPRIMIR RECIBO ?", vbYesNo, "Factura")


        If valor = 6 Then
            PrintDocument1.Print()
        Else
            'MessageBox.Show(" total: " & (Form1.Label34.Text) & "")

        End If

        Dim Query As String
        Try
            If varconex.State = ConnectionState.Open Then varconex.Close()

            Query = "update ingreso_vehiculos SET  total= " & Form1.Label34.Text & "  where Factura= " & Form1.Label16.Text & ""
            varconex.Open()
            Dim cmd2 As MySqlCommand = New MySqlCommand(Query, varconex)
            cmd2.ExecuteNonQuery()

            varconex.Close()


        Catch ex As Exception
            MsgBox("fallo de actualización", vbExclamation, "Atención      SKYNET")


        End Try

        'imagenbarras = PictureBox1.Image
        'ListBox1.Items.Add(imagenbarras)
        'PrintDocument1.Print()

        Me.Close()
        Form1.Show()
    End Sub

    Private Sub COBRAR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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



        Button1.PerformClick()
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim fnt As New Font("Times New Roman", 10, FontStyle.Regular, GraphicsUnit.Point)
        Dim ListBoxItem As String = String.Empty
        For Each LBItem As String In ListBox1.Items
            ListBoxItem = ListBoxItem & vbCrLf & LBItem
        Next
        ListBoxItem = ListBoxItem.Substring(vbCrLf.Length)
        e.Graphics.DrawString(ListBoxItem, fnt, Brushes.Black, 0, 0)
        ' e.Graphics.DrawImage(PictureBox1.Image, 90, 230)
        e.HasMorePages = False



    End Sub
End Class