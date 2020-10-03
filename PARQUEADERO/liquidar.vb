Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class liquidar
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim conexion2 As New MySqlConnection(cadena)
    Dim conversorMoneda As New conversorMoneda
    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick

    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick
        TextBox2.Text = DataGridView2.Rows(DataGridView2.CurrentRow.Index).Cells(0).Value
        Dim operario As String
        operario = TextBox2.Text
        Label10.Text = operario
    End Sub

    Private Sub liquidar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        _dtsliquidado.Reset()
        '_dtsoperario.Reset()
        _dtslistaoperarios.Reset()
        consulta_datos3()
        '  consulta_datos31()
        consulta_datos4()
        DataGridView1.DataSource = _dtvdatos3
        DataGridView2.DataSource = _dtvdatos4
        'DataGridView3.DataSource = _dtvdatos31
        Dim operario As String
        operario = TextBox2.Text
        DataGridView2.Columns(0).Width = 250
        DataGridView2.Columns(1).Width = 128

        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 130
        DataGridView1.Columns(2).Width = 60
        DataGridView1.Columns(4).Width = 28
        DataGridView1.Columns(3).Width = 60
        DataGridView1.Columns(5).Width = 155

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Dim cam As Integer
        TextBox1.Text = UCase(TextBox1.Text)
        cam = Len(TextBox1.Text)
        TextBox1.SelectionStart = cam
        If TextBox1.Text <> "" Then
            ' Button1.Enabled = True
        End If
        _dtvdatos4.RowFilter = "nombre like '%" & TextBox1.Text & "%'"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim porcentaje As String = "0"
        Dim cmd2 As New MySqlCommand("SELECT SUM((ingreso_vehiculos.servicio *`servicioRealOp`)/100) as 'SERVICIO' from ingreso_vehiculos where operario ='" & TextBox2.Text & "'  and liquidado =0 and hora_salida != '' ", conexion2)
        Try
            Dim lectura3 As MySqlDataReader
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            lectura3 = cmd2.ExecuteReader()
            If lectura3.Read() Then
                porcentaje = lectura3(0)

            End If
            conexion2.Close()
        Catch ex As Exception

        End Try

        _dtsliquidado.Reset()
            consulta_datos3()
            DataGridView1.DataSource = _dtvdatos3

            Dim total As Double = 0
            Label4.Text = 0
            ' Dim datos2 As New class_datos
            'Dim conexion As New class_int
            Dim fila As DataGridViewRow = New DataGridViewRow()
        For Each fila In DataGridView1.Rows
            ' el porcentaje se calcula de acuerdo al valor del servicio no del total de la factura
            total += Convert.ToDouble(fila.Cells("VENTA").Value)
        Next


        Label6.Text = conversorMoneda.ajustar_precio(Math.Round(Convert.ToDouble(porcentaje)))

        Label4.Text = conversorMoneda.ajustar_precio(total)



    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim datos As New class_datos
            datos.liquidado = 1
            Dim conexion As New class_int
            If conexion.realizarcierre2(datos) Then
                'consulta_datos4()
                'DataGridView1.DataSource = _dtvdatosc
                ' MessageBox.Show("datos guardados")
            Else
                ' MessageBox.Show("no se realizo registro")
            End If
            _dtsliquidado.Reset()
            factura_liquidar.imprimir()
            Label4.Text = "0"
            Label6.Text = "0"
            MsgBox("OPERARIO LIQUIDADO EXITOSAMENTE")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)


        'Dim datos As New class_datos
        'datos.liquidadov = 1
        'Dim conexion As New class_int
        'If conexion.actualizardatos4(datos) Then
        '    'consulta_datos4()
        '    'DataGridView1.DataSource = _dtvdatosc
        '    ' MessageBox.Show("datos guardados")
        'Else
        '    ' MessageBox.Show("no se realizo registro")
        'End If
        '_dtsliquidadov.Reset()
        'Form8.Show()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        '_dtsliquidadov.Reset()
        'consulta_datos31()
        ''DataGridView3.DataSource = _dtvdatos31

        'Dim total As Double = 0
        'Label4.Text = 0
        '' Dim datos2 As New class_datos
        ''Dim conexion As New class_int
        'Dim fila As DataGridViewRow = New DataGridViewRow()
        'For Each fila In DataGridView3.Rows
        '    ' el porcentaje se calcula de acuerdo al valor del servicio no del total de la factura
        '    total += Convert.ToDouble(fila.Cells("comision_vendedor").Value)
        'Next
        'Label6.Text = total
        'Label4.Text = Convert.ToString(total)

    End Sub


    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Me.Close()
    End Sub
End Class