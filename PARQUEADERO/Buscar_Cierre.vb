Imports System.Configuration
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient

Public Class BUSCAR_CIERRE
    Dim conversorMoneda As New conversorMoneda
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim conexion2, conexion3 As New MySqlConnection(cadena)
    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

        Dim cmd2 As New MySqlCommand("SELECT `totalServicios` AS 'SERVICIOS',`totalParqueadero` AS 'PARQUEADERO',`totalVentas` AS 'TOTAL_VENTAS' FROM `fecha_cierre` WHERE id_fecha=" & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value & "", conexion2)

        'Try
        Dim lectura3 As MySqlDataReader
        If Not conexion2 Is Nothing Then conexion2.Close()
        conexion2.Open()
        lectura3 = cmd2.ExecuteReader()
        If lectura3.Read() Then
            Label3.Text = conversorMoneda.ajustar_precio((lectura3(2)))
            Label7.Text = conversorMoneda.ajustar_precio((lectura3(0)))
            Label6.Text = conversorMoneda.ajustar_precio((lectura3(1)))
        End If

        Dim _adaptadorC As New MySqlDataAdapter
        Dim _dtsdatoscierreC As New DataSet
        conexion_global()
        _adaptadorC.SelectCommand = New MySqlCommand("SELECT  placa as 'PLACA',hora_ingreso as 'HORA_INGRESO',hora_salida as 'HORA_SALIDA',total as 'TOTAL' FROM cierre_caja where id_fecha=" & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value & "", _conexion)
        _adaptadorC.Fill(_dtsdatoscierreC)
        DataGridView2.DataSource = _dtsdatoscierreC.Tables(0)
        _conexion.Open()
        _adaptadorC.SelectCommand.Connection = _conexion
        _adaptadorC.SelectCommand.ExecuteNonQuery()
        _conexion.Close()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    Label3.Text = "0"
        '    Label7.Text = "0"
        '    Label6.Text = "0"
        'End Try
        Button1.Enabled = True
    End Sub

    Private Sub BUSCAR_CIERRE_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim _adaptadorA As New MySqlDataAdapter
        Dim _adaptadorB As New MySqlDataAdapter
        Dim _dtsdatoscierreA As New DataSet
        Dim _dtsdatoscierreB As New DataSet
        Try

            conexion_global()
            _adaptadorA.SelectCommand = New MySqlCommand("SELECT id_fecha as 'ID',`fechaCierre` as 'FECHA_CIERRE' FROM `fecha_cierre` ORDER BY id_fecha DESC", _conexion)
            _adaptadorA.Fill(_dtsdatoscierreA)
            DataGridView1.DataSource = _dtsdatoscierreA.Tables(0)
            _conexion.Open()
            _adaptadorA.SelectCommand.Connection = _conexion
            _adaptadorA.SelectCommand.ExecuteNonQuery()
            _conexion.Close()

            DataGridView1.Columns(0).Width = 45
            DataGridView1.Columns(1).Width = 125


            conexion_global()
            _adaptadorB.SelectCommand = New MySqlCommand("SELECT  placa as 'PLACA',hora_ingreso as 'HORA_INGRESO',hora_salida as 'HORA_SALIDA',total as 'TOTAL' FROM cierre_caja where id_cierre='hola'", _conexion)
            _adaptadorB.Fill(_dtsdatoscierreB)
            DataGridView2.DataSource = _dtsdatoscierreB.Tables(0)
            _conexion.Open()
            _adaptadorB.SelectCommand.Connection = _conexion
            _adaptadorB.SelectCommand.ExecuteNonQuery()
            _conexion.Close()

            DataGridView2.Columns(0).Width = 65
            DataGridView2.Columns(1).Width = 125
            DataGridView2.Columns(2).Width = 125

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        AddHandler Me.PrintDocument1.PrintPage, AddressOf PrintDocument2_PrintPage
        PrintDocument1.Print()
    End Sub


    Public Sub PrintDocument2_PrintPage(sender As Object, e As PrintPageEventArgs)

        Dim fechaactual As String = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value

        Dim textFormat As StringFormat = New StringFormat
        textFormat.Alignment = StringAlignment.Center


        ' imprimimos la cadena en el margen izquierdo
        Dim xPos As Single = e.MarginBounds.Left
        ' La fuente a usar
        Dim textFontPred1 As New Font("Courier New", 8.5, FontStyle.Bold, GraphicsUnit.Point)
        Dim textFontPred2 As New Font("Courier New", 8.5, FontStyle.Regular, GraphicsUnit.Point)
        Dim textFontPred3 As New Font("Courier New", 10.5, FontStyle.Bold, GraphicsUnit.Point)


        ' la posición superior
        Dim yPosPred1 As Single = textFontPred1.GetHeight(e.Graphics)
        Dim yPosPred2 As Single = textFontPred2.GetHeight(e.Graphics)
        Dim yPosPred3 As Single = textFontPred3.GetHeight(e.Graphics)
        Dim yIncrement As Single = 15




        ' imprimimos la cadena
        e.Graphics.DrawString("CIERRE DE CAJA", textFontPred3, Brushes.Black, 156, yPosPred3 + yIncrement, textFormat)
        yIncrement += 20
        e.Graphics.DrawString(fechaactual, textFontPred2, Brushes.Black, 156, yPosPred2 + yIncrement, textFormat)
        yIncrement += 15
        e.Graphics.DrawString("TOTAL SERVICIOS: $" & Label7.Text, textFontPred2, Brushes.Black, 156, yPosPred2 + yIncrement, textFormat)
        yIncrement += 15
        e.Graphics.DrawString("TOTAL PARQUEADERO: $" & Label6.Text, textFontPred2, Brushes.Black, 156, yPosPred2 + yIncrement, textFormat)
        yIncrement += 15
        e.Graphics.DrawString("TOTAL VENTAS: $" & Label3.Text, textFontPred2, Brushes.Black, 156, yPosPred2 + yIncrement, textFormat)
        yIncrement += 15
        e.Graphics.DrawString("PLACA | INGRESO | SALIDA | TOTAL ", textFontPred1, Brushes.Black, 40, yPosPred1 + yIncrement)

        Dim cmdventas As New MySqlCommand("SELECT placa,hora_ingreso,hora_salida,total from cierre_caja where id_fecha=" & DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value & "", conexion3)
        Dim lecturaventas As MySqlDataReader
        'Dim BASE As String
        conexion3.Open()
        lecturaventas = cmdventas.ExecuteReader
        'Dim lectura As Char
        While lecturaventas.Read()
            'Dim item1 As New ListViewItem("item1", 0)
            'item1.SubItems.Add("1")
            'lectura = Mid(lecturaventas("hora_ingreso"), 14, 4)
            Dim cadena As String = [String].Format("{0,-6}|{1,-9}|{2,-8}|{3,-7}", lecturaventas("placa"), Mid(lecturaventas("hora_ingreso"), 12, 8), Mid(lecturaventas("hora_salida"), 12, 8), lecturaventas("total"))
            yIncrement += 10
            e.Graphics.DrawString(cadena, textFontPred2, Brushes.Black, 40, yPosPred2 + yIncrement)

        End While
        conexion3.Close()



        e.HasMorePages = False
    End Sub

End Class