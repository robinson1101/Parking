﻿Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient

Module mod_consulta
    Private _adaptador As New MySqlDataAdapter
    Public _dtsdatos As New DataSet
    Public _dtsdatoscopia As New DataSet
    Public _dtsdatosreimprimirentrada As New DataSet
    Public _dtsoperario As New DataSet
    Public _dtsliquidado As New DataSet
    Public _dtsliquidadov As New DataSet
    Public _dtslistaoperarios As New DataSet
    Public _dtvdatos As New DataView
    Public _dtvdatoscopia As New DataView
    Public _dtvdatosreimprimirentrada As New DataView
    Public _dtvdatos1 As New DataView
    Public _dtvdatos3 As New DataView
    Public _dtvdatos31 As New DataView
    Public _dtvdatos4 As New DataView
    Public _dtsclientes As New DataSet
    Public _dtvclientes As New DataView

    Public _dtsdatosp As New DataSet
    Public _dtvdatosp As New DataView



    Public Sub consulta_datos()
        Try
            conexion_global()
            _adaptador.SelectCommand = New MySqlCommand("select `Factura` as 'FACTURA', `placa` AS 'PLACA', `hora_ingreso` AS 'HORA DE INGRESO',
`tipo` AS 'TIPO', `tarifa` AS 'TARIFA', `hora_salida` AS 'HORA DE SALIDA', `tiempo` AS 'TIEMPO', `total` AS 'TOTAL', `estado` AS 'ESTADO', `servicio` AS 'SERVICIO',
`nombre_cliente` AS 'NOMBRE DE CLIENTE', `cedula` AS 'CEDULA', `telefono` AS 'TELEFONO', `operario` AS 'OPERARIO' from ingreso_vehiculos where hora_salida =0 and estado=0 ", _conexion)
            _adaptador.Fill(_dtsdatos)
            _dtvdatos.Table = _dtsdatos.Tables(0)
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            cerrar()
        End Try
    End Sub

    Public Sub consulta_datosreimprimirentrada()
        Try
            conexion_global()
            _adaptador.SelectCommand = New MySqlCommand("select Factura,placa,hora_ingreso,servicio,tarifa from ingreso_vehiculos where placa= '" & REIMPRIMIR.TextBox1.Text & "' ", _conexion)
            _adaptador.Fill(_dtsdatosreimprimirentrada)
            _dtvdatosreimprimirentrada.Table = _dtsdatosreimprimirentrada.Tables(0)
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            cerrar()
        End Try
    End Sub
    Public Sub consulta_datoscopia()
        Try
            conexion_global()
            _adaptador.SelectCommand = New MySqlCommand("select Factura,placa,hora_ingreso,hora_salida,tiempo,total,tarifa from ingreso_vehiculos where placa= '" & REIMPRIMIRSALIDA.TextBox1.Text & "' ", _conexion)
            _adaptador.Fill(_dtsdatoscopia)
            _dtvdatoscopia.Table = _dtsdatoscopia.Tables(0)
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            cerrar()
        End Try
    End Sub



    Public Sub consulta_datos1()
        Try
            conexion_global()

            _adaptador.SelectCommand = New MySqlCommand("select * from operarios ", _conexion)
            _adaptador.Fill(_dtsoperario)
            _adaptador.Fill(_dtsoperario, "operarios")
            _dtvdatos1.Table = _dtsdatos.Tables(0)
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            cerrar()
        End Try
    End Sub
    Public Sub consulta_datos2()
        Try
            conexion_global()

            _adaptador.SelectCommand = New MySqlCommand("select id_cliente as 'ID',placas as 'PLACA',cliente as 'CLIENTE',documento as 'DOCUMENTO',telefono as 'TELEFONO',color as 'COLOR',marca as 'MARCA',SERVICIOS from clientes ", _conexion)
            _adaptador.Fill(_dtsclientes)
            _adaptador.Fill(_dtsclientes, "clientes")
            _dtvclientes.Table = _dtsclientes.Tables(0)
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            cerrar()
        End Try
    End Sub


    Public Sub consulta_datos3()
        Try
            conexion_global()
            _adaptador.SelectCommand = New MySqlCommand("SELECT ingreso_vehiculos.Factura as 'FACTURA',ingreso_vehiculos.hora_ingreso as 'HORA INGRESO',ingreso_vehiculos.servicioReal as 'VENTA', ingreso_vehiculos.servicio as 'SERVICIO',ingreso_vehiculos.servicioRealOp as '%', ingreso_vehiculos.operario as 'OPERARIO' from ingreso_vehiculos where servicio > 0 and operario ='" & liquidar.TextBox2.Text & "'  and liquidado =0 and hora_salida <> ''", _conexion)
            _adaptador.Fill(_dtsliquidado)
            _dtvdatos3.Table = _dtsliquidado.Tables(0)
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            cerrar()
        End Try
    End Sub


    'Public Sub consulta_datosadmin()
    '    Try
    '        conexion_global()
    '        _adaptador.SelectCommand = New MySqlCommand("SELECT ingreso_vehiculos.comision_vendedor from ingreso_vehiculos where  liq_vendedor =0 ", _conexion)
    '        _adaptador.Fill(_dtsliquidadov)
    '        _dtvdatos31.Table = _dtsliquidadov.Tables(0)
    '        _conexion.Open()
    '        _adaptador.SelectCommand.Connection = _conexion
    '        _adaptador.SelectCommand.ExecuteNonQuery()

    '    Catch ex As MySqlException
    '        MessageBox.Show(ex.Message)
    '    Finally
    '        cerrar()
    '    End Try
    'End Sub

    Public Sub consulta_datos4()
        Try
            conexion_global()
            _adaptador.SelectCommand = New MySqlCommand("SELECT operarios.nombre as 'NOMBRE', operarios.documento as 'DOCUMENTO'from operarios", _conexion)
            _adaptador.Fill(_dtslistaoperarios)
            _dtvdatos4.Table = _dtslistaoperarios.Tables(0)
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            cerrar()
        End Try
    End Sub

    Public Function consulta_empresa()
        Dim empresa As String = ""
        Try

            conexion_global()
            Dim cmd As New MySqlCommand("SELECT company_title from title", _conexion)
            _conexion.Open()
            Dim leer As MySqlDataReader = cmd.ExecuteReader()
            If leer.Read Then
                empresa = leer(0)
            End If

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            cerrar()
        End Try
        Return empresa
    End Function


End Module
