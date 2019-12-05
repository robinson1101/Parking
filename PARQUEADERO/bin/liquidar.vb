Public Class liquidar

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
            total += Convert.ToDouble(fila.Cells("servicio").Value)
        Next
        Label6.Text = 0.4 * total
        Label4.Text = Convert.ToString(total)


    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

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
        Form8.Show()

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

    Private Sub Button3_Click_1(sender As Object, e As EventArgs) Handles Button3.Click
        reportes_Admin.Show()
        Me.Hide()

    End Sub
End Class