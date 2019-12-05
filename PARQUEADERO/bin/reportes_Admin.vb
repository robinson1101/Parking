
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Diagnostics
Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices


Public Class reportes_Admin
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion2 As New MySqlConnection(cadena)
    Dim datos, datos2, codata, codata3 As New DataSet 'los datos que estan en la base de datos son clases 
    Dim fila As Integer
    Public sql, cmd, sql2 As New MySqlCommand

    Private Sub reportes_Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim fecha As String = DateTimePicker1.Value.ToString("yyyy/MM/dd")
        Dim fecha2 As String = DateTimePicker2.Value.ToString("yyyy/MM/dd")
        Dim hora_inicio As String
        hora_inicio = " 00:00:00"
        Dim hora_fin As String
        hora_fin = " 23:59:59"
        Label1.Text = fecha + hora_inicio
        Label2.Text = fecha2 + hora_fin


        consultar_admin()
        consultar_admin2()
        Dim parqueo As String
        parqueo = Val(Label6.Text) - Val(Label8.Text)
        Label10.Text = parqueo
        Dim PORCENTAJE As Decimal
        PORCENTAJE = Val(Label8.Text) * 60 / 100
        Dim utilidad As String
        utilidad = Val(Label10.Text) + PORCENTAJE
        Label13.Text = PORCENTAJE
        Label14.Text = utilidad

    End Sub
    Sub consultar_admin()
        Dim NoCaja As String = "SELECT SUM(`ingreso_vehiculos`.`total`)as total  FROM ingreso_vehiculos WHERE ingreso_vehiculos.hora_salida BETWEEN '" & Label1.Text & "' AND '" & Label2.Text & "' "
        If varconex.State = ConnectionState.Closed Then varconex.Open()
        Dim da2 As New MySqlDataAdapter(NoCaja, varconex)

        Dim nomb_caja As String


        nomb_caja = ""


        sql.CommandText = NoCaja
        Sql.Connection = varconex
        da2.SelectCommand = Sql
        codata.Clear()
        da2.Fill(codata)
        Try
            If codata.Tables(0).Rows.Count > 0 Then
                nomb_caja = codata.Tables(0).Rows(0).Item("total")
                'id_caja = codata.Tables(0).Rows(0).Item("id_caja")

            End If
            Label6.Text = nomb_caja
        Catch ex As Exception
            MessageBox.Show(" No hay facturas de ese lapso de tiempo, en el siguiente mensaje de click en continuar")
            Me.Show()
        End Try

    End Sub
    Sub consultar_admin2()
        Dim NoCaja As String = "SELECT SUM(`ingreso_vehiculos`.`servicio`)as total  FROM ingreso_vehiculos WHERE ingreso_vehiculos.hora_salida BETWEEN '" & Label1.Text & "' AND '" & Label2.Text & "' "
        If varconex.State = ConnectionState.Closed Then varconex.Open()
        Dim da2 As New MySqlDataAdapter(NoCaja, varconex)

        Dim nomb_caja As String
        Dim id_caja As String

        nomb_caja = ""


        sql.CommandText = NoCaja
        sql.Connection = varconex
        da2.SelectCommand = sql
        codata.Clear()
        da2.Fill(codata)
        If codata.Tables(0).Rows.Count > 0 Then
            nomb_caja = codata.Tables(0).Rows(0).Item("total")
            'id_caja = codata.Tables(0).Rows(0).Item("id_caja")

        End If
        Label8.Text = nomb_caja
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
End Class