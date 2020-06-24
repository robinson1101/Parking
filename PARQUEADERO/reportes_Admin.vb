
Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Diagnostics
Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices


Public Class reportes_Admin
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion2, conexion3 As New MySqlConnection(cadena)
    Dim datos, datos2, codata, codata3 As New DataSet 'los datos que estan en la base de datos son clases 
    Dim fila As Integer
    Dim conversorMoneda As New conversorMoneda
    Public sql, cmd, sql2 As New MySqlCommand


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) 
        Me.Close()
        liquidar.Show()
    End Sub

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
        Dim parqueo As String = "0"
        Dim PORCENTAJE As String = "0"

        Dim cmd1 As New MySqlCommand("SELECT SUM(`ingreso_vehiculos`.`parqueaderoReal`) as total, SUM(`servicioReal`-((`servicio`*`servicioRealOp`)/100)) as SUMA  FROM ingreso_vehiculos WHERE ingreso_vehiculos.hora_salida BETWEEN '" & Label1.Text & "' AND '" & Label2.Text & "' and hora_salida != '' ", conexion3)
        Try
            Dim lectura2 As MySqlDataReader
            If Not conexion3 Is Nothing Then conexion3.Close()
            conexion3.Open()
            lectura2 = cmd1.ExecuteReader()
            If lectura2.Read() Then

                parqueo = lectura2(0)
                PORCENTAJE = lectura2(1)

            End If
            conexion3.Close()
        Catch ex As Exception

        End Try

        Label10.Text = conversorMoneda.ajustar_precio(parqueo)


        PORCENTAJE = conversorMoneda.ajustar_precio(Math.Round(Convert.ToDouble(PORCENTAJE)))

        Dim utilidad As String = "0"
        utilidad = Val(Label10.Text) + Val(PORCENTAJE)
        Label13.Text = conversorMoneda.ajustar_precio(PORCENTAJE)
        Label14.Text = conversorMoneda.ajustar_precio(utilidad)

    End Sub
    Sub consultar_admin()
        Dim NoCaja As String = "SELECT SUM(`ingreso_vehiculos`.`total`)as total  FROM ingreso_vehiculos WHERE ingreso_vehiculos.hora_salida BETWEEN '" & Label1.Text & "' AND '" & Label2.Text & "' and hora_salida != '' "
        If varconex.State = ConnectionState.Closed Then varconex.Open()
        Dim da2 As New MySqlDataAdapter(NoCaja, varconex)

        Dim nomb_caja As String


        nomb_caja = ""
        Label6.Text = "0"

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
            Label6.Text = conversorMoneda.ajustar_precio(nomb_caja)
        Catch ex As Exception
            Label6.Text = "0"
            Label8.Text = "0"
            Label10.Text = "0"
            Label13.Text = "0"
            Label14.Text = "0"
            MessageBox.Show(" No hay facturas en ese lapso de tiempo")
            Me.Show()
        End Try

    End Sub
    Sub consultar_admin2()
        Dim NoCaja As String = "SELECT SUM(`ingreso_vehiculos`.`servicioReal`) as total  FROM ingreso_vehiculos WHERE ingreso_vehiculos.hora_salida BETWEEN '" & Label1.Text & "' AND '" & Label2.Text & "' and hora_salida != '' "
        If varconex.State = ConnectionState.Closed Then varconex.Open()
        Dim da2 As New MySqlDataAdapter(NoCaja, varconex)

        Dim nomb_caja As String
        Dim id_caja As String

        nomb_caja = "0"


        sql.CommandText = NoCaja
        sql.Connection = varconex
        da2.SelectCommand = sql
        codata.Clear()
        da2.Fill(codata)
        If codata.Tables(0).Rows.Count > 0 Then
            nomb_caja = Convert.ToString(codata.Tables(0).Rows(0).Item("total"))
            'id_caja = codata.Tables(0).Rows(0).Item("id_caja")
        End If
        If nomb_caja = "" Then
            nomb_caja = "0"
        End If
        Label8.Text = conversorMoneda.ajustar_precio(nomb_caja)
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged

    End Sub
End Class