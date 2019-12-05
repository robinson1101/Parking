Imports System.Diagnostics
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Configuration
Public Class CIERRE_CAJA2
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion2, conexion, conexion3 As New MySqlConnection(cadena)
    Dim total, gasto1 As Integer
    Dim RawPrinterHelper As Object
    Dim strCurrency As String = ""
    Dim acceptableKey As Boolean = False
    Private _titulo As Object
    Dim f_efectivo As String
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd"

        Label23.Text = DateTimePicker1.Text

        Dim query As String
        Try
            query = "select SUM(ingreso_vehiculos.total) AS totalvent FROM ingreso_vehiculos where ingreso_vehiculos.hora_ingreso between '" & Label23.Text & " 00:00:00' and  '" & Label23.Text & " 23:59:59'  "
            Dim cmdtotal As MySqlCommand = New MySqlCommand(query, conexion2)
            Dim lectura_total As MySqlDataReader
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            lectura_total = cmdtotal.ExecuteReader
            If lectura_total.Read() Then
                Me.Label4.Text = lectura_total("totalvent")
                total = FormatNumber(lectura_total.Item("totalvent"))
            End If


        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        End Try

        'Dim query As String
        'Try
        '    query = "select SUM(ingreso_vehiculos.total) AS totalvent FROM ingreso_vehiculos where ingreso_vehiculos.hora_ingreso between ' " & Label23.Text & " 00:00:00' and  ' " & Label23.Text & " 23:59:59'  "
        '    Dim cmdtotal As MySqlCommand = New MySqlCommand(query, conexion2)
        '    Dim lectura_total As MySqlDataReader
        '    If Not conexion2 Is Nothing Then conexion2.Close()
        '    conexion2.Open()
        '    lectura_total = cmdtotal.ExecuteReader
        '    If lectura_total.Read() Then
        '        Me.Label4.Text = lectura_total("totalvent")
        '        'total = FormatNumber(lectura_total("totalvent"))
        '    End If


        'Catch ex As Exception
        '    MsgBox(ex.Message + ex.StackTrace)
        'End Try



        Dim numero1 As Integer
        Dim numero2 As Integer
        Dim numero3 As Integer
        Dim numero4 As Integer

        numero1 = total
        numero3 = Me.Label15.Text
        numero2 = Val(Me.Label10.Text)
        numero4 = Me.Label21.Text


        Me.Label11.Text = ((numero1 - numero3) + numero2) - numero4
        Me.Label18.Text = (numero1 - numero3)

        'listbox empresa

        conexion.Close()
        'listbox cajero
        ' consulta inventario SELECT nomb_product, precio_venta, inventario from articulos


        conexion.Close()
        ListBox1.Items.Add(" ")
        ListBox1.Items.Add(("Fecha Salida Caja:") & Chr(9) & (Me.Label5.Text))
        ListBox1.Items.Add(" ")
        ListBox1.Items.Add(("     Total Ventas:") & Chr(9) & "$ " & (FormatNumber(total, TriState.False)))
        ListBox1.Items.Add(" ")


        'Call fechahora()
        'Call totalventas()
        Label23.Text = DateTimePicker1.Text
        Call impr_inventario()
        'Call actualizar_caja()
        ' cajon()
        PrintDocument1.Print()


        Me.Hide()
        Close()

    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim fnt As New Font("Courier New", 8.5, FontStyle.Bold, GraphicsUnit.Point)

        Dim ListBoxItem As String = String.Empty

        For Each LBItem As String In ListBox1.Items

            ListBoxItem = ListBoxItem & vbCrLf & LBItem
        Next
        ListBoxItem = ListBoxItem.Substring(vbCrLf.Length)
        e.Graphics.DrawString(ListBoxItem, fnt, Brushes.Black, 0, 0)
        e.HasMorePages = False

    End Sub
    'Private Sub cajon()
    '    'Use this code if you are using COM Port
    '    FileOpen(1, AppDomain.CurrentDomain.BaseDirectory & "open.txt", OpenMode.Output)
    '    PrintLine(1, Chr(27) & Chr(112) & Chr(0) & Chr(25) & Chr(250))
    '    FileClose(1)
    '    Shell("print /d:com2 open.txt", AppWinStyle.Hide)
    '    'Shell("print /d:lpt1 open.txt", vbNormalFocus)
    'End Sub


    Private Sub Form8_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        impr_inventario()

    End Sub
    Public Sub impr_inventario()
        If CheckBox1.Checked = True Then



            ListBox1.Items.Add(" INGRESO| SALIDA | Min| TOTAL|PLACA ")

            Dim cmdventas As New MySqlCommand("SELECT ingreso_vehiculos.placa, ingreso_vehiculos.hora_ingreso,ingreso_vehiculos.hora_salida,ingreso_vehiculos.tiempo,ingreso_vehiculos.total from ingreso_vehiculos where ingreso_vehiculos.hora_ingreso between '" & Label23.Text & " 00:00:00' and  '" & Label23.Text & " 23:59:59'", conexion)
            Dim lecturaventas As MySqlDataReader
            If Not conexion Is Nothing Then conexion.Close()
            conexion.Open()
            lecturaventas = cmdventas.ExecuteReader
            Dim lectura As Char
            While lecturaventas.Read()
                Dim item1 As New ListViewItem("item1", 0)
                item1.SubItems.Add("1")
                lectura = Mid(lecturaventas("hora_ingreso"), 14, 4)
                ' ListBox1.Items.Add([String].Format("{0, 0}|{1, -6}|{2, -3}|{3, 4}", Mid(lecturaventas("placa"), 1, 7), lecturaventas("hora_ingreso"), lecturaventas("tiempo"), lecturaventas("total")))
                ListBox1.Items.Add([String].Format("{0,-8}|{1,-8}|{2,-4}|{3,-6}|{4,-6}", Mid(lecturaventas("hora_ingreso"), 11, 8), Mid(lecturaventas("hora_salida"), 11, 8), lecturaventas("tiempo"), lecturaventas("total"), lecturaventas("placa")))


            End While
            ListBox1.Items.Add(" ")
            ListBox1.Items.Add(" ")
            ListBox1.Items.Add("  ")
            conexion.Close()

        End If
    End Sub




    'Public Sub actualizar_caja()
    '    Dim update As String
    '    Try
    '        update = "update ingreso_vehiculos set estado= 1 where estado=0 and hora_salida <>'""' "
    '        varconex.Open()
    '        Dim cmd3 As MySqlCommand = New MySqlCommand(update, varconex)
    '        cmd3.ExecuteNonQuery()

    '        varconex.Close()
    '    Catch ex As Exception
    '        MsgBox("Error", vbExclamation, "Atención      SKYNET")

    '    End Try


    'End Sub


    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged


        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd"

        Label23.Text = DateTimePicker1.Text
    End Sub

    Private Sub Button3_Click_1(sender As Object, e As EventArgs)


    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub



    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Close()
    End Sub



End Class