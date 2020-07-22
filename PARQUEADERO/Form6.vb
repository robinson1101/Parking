Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration


Public Class Form6



    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        Try


            _dtvclientes.RowFilter = "PLACA like '%" & TextBox1.Text & "%' OR DOCUMENTO like '%" & TextBox1.Text & "%'"

        Catch ex As Exception

        End Try


    End Sub

    Private Sub Form6_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dtsclientes.Reset()


        consulta_datos2()
        DataGridView1.DataSource = _dtvclientes
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 90
        DataGridView1.Columns(2).Width = 180
        DataGridView1.Columns(7).Width = 60
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        Try
            Dim placa As String = Nothing
            placa = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value
            If placa = "X" Then
                Form1.TextBox1.Text = ""
            Else
                Form1.TextBox1.Text = placa
            End If

            Form1.TextBox2.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value
            Form1.TextBox4.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(3).Value
            Form1.TextBox5.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(4).Value
            Form1.TextBox11.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(7).Value
            Me.Close()
        Catch ex As NullReferenceException

        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs)
        Dim conexion As New class_int
        Dim datos As New class_datos

        datos.placas = TextBox1.Text
        datos.documento = TextBox4.Text
        datos.cliente = TextBox2.Text
        datos.telefono = TextBox5.Text



        If conexion.insertardatos3(datos) Then
            _dtsdatos.Reset()
            consulta_datos()
            DataGridView1.DataSource = _dtvdatos
            MessageBox.Show(" Cliente guardado")
        Else
            MessageBox.Show("no se realizo registro")
        End If


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conexion As New class_int
        Dim datos As New class_datos
        If TextBox2.Text.Trim = "" Then

            MsgBox("DEBE INGRESAR EL NÚMERO DE DOCUMENTO DEL CLIENTE", vbExclamation, "")

        Else

            If TextBox2.Text.Trim = "" Then
                datos.documento = "X"
            Else
                datos.documento = TextBox2.Text
            End If

            If TextBox7.Text.Trim = "" Then
                datos.cliente = "X"
            Else
                datos.cliente = TextBox7.Text
            End If

            If TextBox4.Text.Trim = "" Then
                datos.telefono = "X"
            Else
                datos.telefono = TextBox4.Text
            End If

            If TextBox5.Text.Trim = "" Then
                datos.placas = "X"
            Else
                datos.placas = TextBox5.Text
            End If

            If TextBox3.Text.Trim = "" Then
                datos.marca = "X"
            Else
                datos.marca = TextBox3.Text
            End If

            If TextBox6.Text.Trim = "" Then
                datos.color = "X"
            Else
                datos.color = TextBox6.Text
            End If

            If conexion.insertardatos3(datos) Then
                _dtsclientes.Reset()
                consulta_datos2()
                DataGridView1.DataSource = _dtvclientes
                MessageBox.Show("CLIENTE CREADO")

                TextBox2.Text = ""
                TextBox3.Text = ""
                TextBox4.Text = ""
                TextBox5.Text = ""
                TextBox6.Text = ""
                TextBox7.Text = ""

                TextBox1.Focus()

            Else
                ' MessageBox.Show("no se realizo registro")
            End If

        End If

    End Sub

    Private Sub Form6_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        'codigo para ejecutar el evento del escape
        If e.KeyCode = Keys.Escape Then
            Me.Hide()
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        'codigo para ejecutar el evento del escape
        If e.KeyCode = Keys.Escape Then
            Me.Hide()
        End If
    End Sub

    Private Sub DataGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyDown
        'codigo para ejecutar el evento del esc
        If e.KeyCode = Keys.Escape Then
            Me.Hide()
        End If
    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        'codigo para ejecutar el evento del enter
        If e.KeyCode = Keys.Enter Then
            Button1_Click(sender, e)
        End If
    End Sub
End Class