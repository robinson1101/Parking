Imports MySql.Data
Imports MySql.Data.Types
Imports MySql.Data.MySqlClient

Module cierre

    Private _adaptadorc As New MySqlDataAdapter
    Public _dtsdatosc As New DataSet
    Public _dtvdatosc As New DataView
    Public _dtsdatosc1 As New DataSet
    Public _dtvdatosc1 As New DataView


    Public Sub consulta_cierre()
        Try
            conexion_global()
            _adaptadorc.SelectCommand = New MySqlCommand("select placa,hora_ingreso,hora_salida,tiempo,total from ingreso_vehiculos where ingreso_vehiculos.estado =0 ", _conexion)
            _adaptadorc.Fill(_dtsdatosc)
            _dtvdatosc.Table = _dtsdatosc.Tables(0)
            _conexion.Open()
            _adaptadorc.SelectCommand.Connection = _conexion
            _adaptadorc.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            cerrar()
        End Try
    End Sub

    Public Sub consulta_cierre1()
        Try
            conexion_global()
            _adaptadorc.SelectCommand = New MySqlCommand("select placa,hora_ingreso,tiempo,total from ingreso_vehiculos where ingreso_vehiculos.estado =0 ", _conexion)
            _adaptadorc.Fill(_dtsdatosc)
            _dtvdatosc.Table = _dtsdatosc.Tables(0)
            _conexion.Open()
            _adaptadorc.SelectCommand.Connection = _conexion
            _adaptadorc.SelectCommand.ExecuteNonQuery()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            cerrar()
        End Try
    End Sub


End Module
