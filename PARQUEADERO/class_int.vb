
Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient
Imports System.Configuration

Public Class class_int
    Private _adaptador As New MySqlDataAdapter
    Public Function insertardatos(ByVal datos As class_datos) As Boolean

        Dim estado As Boolean = True
        Try
            conexion_global()
            _adaptador.InsertCommand = New MySqlCommand("insert into ingreso_vehiculos (placa,hora_ingreso,tipo,servicio,nombre_cliente,cedula,telefono,operario,tarifa,servicioRealOp,estado) values (@placa,@hora_ingreso,@tipo, @servicio,@nombre_cliente,@cedula,@telefono,@operario,@tarifa,@porcentajeOperario,@estado)", _conexion)
            _adaptador.InsertCommand.Parameters.Add("@placa", MySqlDbType.VarChar, 50).Value = datos.placa
            _adaptador.InsertCommand.Parameters.Add("@hora_ingreso", MySqlDbType.VarChar, 50).Value = datos.hora_ingreso
            _adaptador.InsertCommand.Parameters.Add("@tipo", MySqlDbType.VarChar, 50).Value = datos.tipo
            _adaptador.InsertCommand.Parameters.Add("@servicio", MySqlDbType.VarChar, 50).Value = datos.servicio
            _adaptador.InsertCommand.Parameters.Add("@nombre_cliente", MySqlDbType.VarChar, 50).Value = datos.nombre_cliente
            _adaptador.InsertCommand.Parameters.Add("@cedula", MySqlDbType.VarChar, 50).Value = datos.cedula
            _adaptador.InsertCommand.Parameters.Add("@telefono", MySqlDbType.VarChar, 50).Value = datos.telefono
            _adaptador.InsertCommand.Parameters.Add("@operario", MySqlDbType.VarChar, 50).Value = datos.operario
            _adaptador.InsertCommand.Parameters.Add("@tarifa", MySqlDbType.VarChar, 50).Value = datos.tarifa
            _adaptador.InsertCommand.Parameters.Add("@porcentajeOperario", MySqlDbType.VarChar, 50).Value = costos.lblPorcentajeOperario.Text
            _adaptador.InsertCommand.Parameters.Add("@estado", MySqlDbType.VarChar, 50).Value = Form1.TextBox9.Text.Trim

            _conexion.Open()
            _adaptador.InsertCommand.Connection = _conexion
            _adaptador.InsertCommand.ExecuteNonQuery()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            estado = False
        Finally
            cerrar()
        End Try
        Return estado
    End Function

    Public Function actualizardatos(ByVal datos As class_datos) As Boolean
        Dim estado As Boolean = True

        '                                                                                  placa like '%" & TextBox3.Text & "%'"
        Try
            conexion_global()
            _adaptador.UpdateCommand = New MySqlCommand("UPDATE  `parqueadero`.`ingreso_vehiculos` Set  `hora_salida` =  '" & Form1.Label11.Text & "',`tiempo` =  '" & Form1.Label9.Text & "',`total` =  '" & Form1.Label14.Text & "' WHERE  `ingreso_vehiculos`.Factura= " & Form1.Label16.Text & "", _conexion)
            '_adaptador.UpdateCommand = New MySqlCommand("UPDATE  `parqueadero`.`ingreso_vehiculos` Set  `hora_salida` =  '" & Form1.Label11.Text & "',`tiempo` =  '" & Form1.Label9.Text & "',`total` =  '" & Form1.Label14.Text & "' WHERE  `ingreso_vehiculos`.placa= " & Form1.TextBox3.Text & "", _conexion)
            _adaptador.UpdateCommand.Parameters.Add("@hora_salida", MySqlDbType.VarChar, 50).Value = datos.hora_salida
            _adaptador.UpdateCommand.Parameters.Add("@tiempo", MySqlDbType.VarChar, 50).Value = datos.tiempo
            _adaptador.UpdateCommand.Parameters.Add("@total", MySqlDbType.VarChar, 50).Value = datos.total
            _conexion.Open()
            _adaptador.UpdateCommand.Connection = _conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            estado = False

        Finally
            cerrar()
        End Try
        Return estado
    End Function




    Public Function realizarcierre() As Boolean
        Dim update As String
        Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
        Dim varconex As New MySqlConnection(cadena)
        Try
            update = "update ingreso_vehiculos set estado= 1 where estado=0 and hora_salida <>'""' "
            varconex.Open()
            Dim cmd3 As MySqlCommand = New MySqlCommand(update, varconex)
            cmd3.ExecuteNonQuery()

            varconex.Close()
        Catch ex As Exception
            MsgBox("Error", vbExclamation, "Atención      SKYNET")

        End Try
        Return 1
    End Function
    Public Function insertardatos3(ByVal datos As class_datos) As Boolean

        Dim estado As Boolean = True
        Try
            conexion_global()
            _adaptador.InsertCommand = New MySqlCommand("insert into clientes (placas,cliente,documento,telefono,color,marca) values (@placas,@cliente,@documento,@telefono,@color,@marca)", _conexion)
            _adaptador.InsertCommand.Parameters.Add("@placas", MySqlDbType.VarChar, 50).Value = datos.placas
            _adaptador.InsertCommand.Parameters.Add("@cliente", MySqlDbType.VarChar, 50).Value = datos.cliente
            _adaptador.InsertCommand.Parameters.Add("@documento", MySqlDbType.VarChar, 50).Value = datos.documento
            _adaptador.InsertCommand.Parameters.Add("@telefono", MySqlDbType.VarChar, 50).Value = datos.telefono
            _adaptador.InsertCommand.Parameters.Add("@color", MySqlDbType.VarChar, 50).Value = datos.color
            _adaptador.InsertCommand.Parameters.Add("@marca", MySqlDbType.VarChar, 50).Value = datos.marca

            _conexion.Open()
            _adaptador.InsertCommand.Connection = _conexion
            _adaptador.InsertCommand.ExecuteNonQuery()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            estado = False
        Finally
            cerrar()
        End Try
        Return estado
    End Function


    Public Function actualizardatos3(ByVal datos As class_datos) As Boolean
        Dim estado As Boolean = True


        Try
            conexion_global()
            _adaptador.UpdateCommand = New MySqlCommand("UPDATE  `parqueadero`.`ingreso_vehiculos` Set  `liquidado` =  " & 1 & " WHERE  `ingreso_vehiculos`.`operario` = " & liquidar.Label10.Text & "", _conexion)
            '_adaptador.UpdateCommand = New MySqlCommand("UPDATE  `parqueadero`.`ingreso_vehiculos` Set  `hora_salida` =  '" & Form1.Label11.Text & "',`tiempo` =  '" & Form1.Label9.Text & "',`total` =  '" & Form1.Label14.Text & "' WHERE  `ingreso_vehiculos`.placa= " & Form1.TextBox3.Text & "", _conexion)
            _adaptador.UpdateCommand.Parameters.Add("@liquidado", MySqlDbType.VarChar, 50).Value = datos.liquidado

            _conexion.Open()
            _adaptador.UpdateCommand.Connection = _conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            estado = False

        Finally
            cerrar()
        End Try
        Return estado
    End Function

    'Public Function actualizardatos4(ByVal datos As class_datos) As Boolean
    '    Dim estado As Boolean = True


    '    Try
    '        conexion_global()
    '        _adaptador.UpdateCommand = New MySqlCommand("UPDATE  `parqueadero`.`ingreso_vehiculos` Set  `liq_vendedor` =  " & 1 & " WHERE  `ingreso_vehiculos`.`liq_vendedor`= " & 0 & "", _conexion)
    '        '_adaptador.UpdateCommand = New MySqlCommand("UPDATE  `parqueadero`.`ingreso_vehiculos` Set  `hora_salida` =  '" & Form1.Label11.Text & "',`tiempo` =  '" & Form1.Label9.Text & "',`total` =  '" & Form1.Label14.Text & "' WHERE  `ingreso_vehiculos`.placa= " & Form1.TextBox3.Text & "", _conexion)
    '        _adaptador.UpdateCommand.Parameters.Add("@liquidadov", MySqlDbType.VarChar, 50).Value = datos.liquidadov

    '        _conexion.Open()
    '        _adaptador.UpdateCommand.Connection = _conexion
    '        _adaptador.UpdateCommand.ExecuteNonQuery()

    '    Catch ex As MySqlException
    '        MessageBox.Show(ex.Message)
    '        estado = False

    '    Finally
    '        cerrar()
    '    End Try
    '    Return estado
    'End Function

    Public Function realizarcierre2(ByVal datos As class_datos) As Boolean
        Dim estado As Boolean = True
        Dim varcierre As String
        varcierre = 1
        ' estados del vehiculo
        ' 0= cuando el vehiculo ingresa al parqueadero
        ' 1= cuando el vehiculo es retirado delparqueadero  '                                                                                  placa like '%" & TextBox3.Text & "%'"
        Try
            conexion_global()
            _adaptador.UpdateCommand = New MySqlCommand("UPDATE  `parqueadero`.`ingreso_vehiculos` Set  `liquidado` =  " & 1 & "  where `ingreso_vehiculos`.operario like '%" & liquidar.Label10.Text & "%'", _conexion)
            '_adaptador.UpdateCommand = New MySqlCommand("UPDATE  `parqueadero`.`ingreso_vehiculos` Set  `hora_salida` =  '" & Form1.Label11.Text & "',`tiempo` =  '" & Form1.Label9.Text & "',`total` =  '" & Form1.Label14.Text & "' WHERE  `ingreso_vehiculos`.placa= " & Form1.TextBox3.Text & "", _conexion)
            _adaptador.UpdateCommand.Parameters.Add("@liquidado", MySqlDbType.VarChar, 50).Value = datos.liquidado
            '_adaptador.UpdateCommand.Parameters.Add("@tiempo", MySqlDbType.VarChar, 50).Value = datos.tiempo
            '_adaptador.UpdateCommand.Parameters.Add("@total", MySqlDbType.VarChar, 50).Value = datos.total
            _conexion.Open()
            _adaptador.UpdateCommand.Connection = _conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
            estado = False

        Finally
            cerrar()
        End Try
        Return estado
    End Function
End Class
