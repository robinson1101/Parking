Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class Form4


    Dim conversorMoneda As New conversorMoneda
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        _dtsdatosc.Reset()
    End Sub

    Private Sub Form4_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dtsdatosc.Reset()
        consulta_cierre()

        Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
        Dim conexion2 As New MySqlConnection(cadena)
        Dim cmd2 As New MySqlCommand("Select sum(total),SUM(servicioReal),SUM(parqueaderoReal) from ingreso_vehiculos where ingreso_vehiculos.estado =0", conexion2)
        Try
            Dim lectura3 As MySqlDataReader
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            lectura3 = cmd2.ExecuteReader()
            If lectura3.Read() Then

                Label3.Text = conversorMoneda.ajustar_precio(Convert.ToString(lectura3(0)))
                Label7.Text = conversorMoneda.ajustar_precio(Convert.ToString(lectura3(1)))
                Label6.Text = conversorMoneda.ajustar_precio(Convert.ToString(lectura3(2)))
            End If
            If Label3.Text = "" Or Label7.Text = "" Or Label6.Text = "" Then
                Label3.Text = "0"
                Label7.Text = "0"
                Label6.Text = "0"
            End If
        Catch ex As Exception
            Label3.Text = "0"
            Label7.Text = "0"
            Label6.Text = "0"
        End Try

        If Label3.Text = "" Then
            Label3.Text = "0"
        End If

        DataGridView1.DataSource = _dtvdatosc

        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 120
        DataGridView1.Columns(2).Width = 120
        DataGridView1.Columns(3).Width = 40
        DataGridView1.Columns(4).Width = 60

        'Timer1.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Close()

        Form1.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        PrintForm1.PrinterSettings.DefaultPageSettings.Margins = New System.Drawing.Printing.Margins(0, 0, 0, 0)
        'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Left = 0
        'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Right = 0
        'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Top = 0
        'PrintForm1.PrinterSettings.DefaultPageSettings.Margins.Bottom = 0
        PrintForm1.Print()
        Timer1.Stop()
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If DataGridView1.Rows.Count > 0 Then
            CIERRE_CAJA.Show()
            Dim _adaptador As New MySqlDataAdapter

            'CONEXION PARA CARGAR LA TABLA FECHA_CIERRE
            conexion_global()
            _adaptador.InsertCommand = New MySqlCommand("insert into fecha_cierre (fechaCierre,totalServicios,totalParqueadero,totalVentas) values (@fecha,@servicio,@parqueadero,@ventas)", _conexion)

            _adaptador.InsertCommand.Parameters.Clear()
            _adaptador.InsertCommand.Parameters.Add("@fecha", MySqlDbType.VarChar, 50).Value = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
            _adaptador.InsertCommand.Parameters.Add("@servicio", MySqlDbType.VarChar, 50).Value = Label7.Text
            _adaptador.InsertCommand.Parameters.Add("@parqueadero", MySqlDbType.VarChar, 50).Value = Label6.Text
            _adaptador.InsertCommand.Parameters.Add("@ventas", MySqlDbType.VarChar, 50).Value = Label3.Text

            _conexion.Open()
            _adaptador.InsertCommand.Connection = _conexion
            _adaptador.InsertCommand.ExecuteNonQuery()
            _conexion.Close()

            'CONSULTA PARA OBTENER ID DE LA TABLA FECHA CIERRE
            Dim cadena1 As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
            Dim conexion3 As New MySqlConnection(cadena1)
            Dim ID As Integer = Nothing
            Dim cmd3 As New MySqlCommand("SELECT max(`id_fecha`) FROM `fecha_cierre` ", conexion3)
            Try
                Dim lectura3 As MySqlDataReader
                If Not conexion3 Is Nothing Then conexion3.Close()
                conexion3.Open()
                lectura3 = cmd3.ExecuteReader()
                If lectura3.Read() Then
                    ID = lectura3(0)
                End If

            Catch ex As Exception

            End Try

            For Each Row As DataGridViewRow In DataGridView1.Rows

                Dim estado As Boolean = True
                Try

                    'CONEXION PARA CARGAR LA TABLA CIERRE_CAJA
                    conexion_global()
                    _adaptador.InsertCommand = New MySqlCommand("insert into cierre_caja (id_fecha,placa,hora_ingreso,hora_salida,total) values (@id,@placa,@ingreso,@salida,@total)", _conexion)

                    _adaptador.InsertCommand.Parameters.Clear()

                    _adaptador.InsertCommand.Parameters.Add("@id", MySqlDbType.Int32, 50).Value = ID
                    _adaptador.InsertCommand.Parameters.Add("@placa", MySqlDbType.VarChar, 50).Value = Convert.ToString(Row.Cells("PLACA").Value)
                    _adaptador.InsertCommand.Parameters.Add("@ingreso", MySqlDbType.VarChar, 50).Value = Convert.ToString(Row.Cells("HORA_INGRESO").Value)
                    _adaptador.InsertCommand.Parameters.Add("@salida", MySqlDbType.VarChar, 50).Value = Convert.ToString(Row.Cells("HORA_SALIDA").Value)
                    _adaptador.InsertCommand.Parameters.Add("@total", MySqlDbType.VarChar, 50).Value = Convert.ToString(Row.Cells("TOTAL").Value)


                    _conexion.Open()
                    _adaptador.InsertCommand.Connection = _conexion
                    _adaptador.InsertCommand.ExecuteNonQuery()
                    _conexion.Close()


                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try

            Next

        Else
        End If


        _dtsdatosc.Reset()
        consulta_cierre()

        Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
        Dim conexion2 As New MySqlConnection(cadena)
        Dim cmd2 As New MySqlCommand("Select sum(total),SUM(servicioReal),SUM(parqueaderoReal) from ingreso_vehiculos where ingreso_vehiculos.estado =0", conexion2)
        Try
            Dim lectura3 As MySqlDataReader
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            lectura3 = cmd2.ExecuteReader()
            If lectura3.Read() Then
                Label3.Text = conversorMoneda.ajustar_precio(Convert.ToString(lectura3(0)))
                Label7.Text = conversorMoneda.ajustar_precio(Convert.ToString(lectura3(1)))
                Label6.Text = conversorMoneda.ajustar_precio(Convert.ToString(lectura3(2)))
            End If
            If Label3.Text = "" Or Label7.Text = "" Or Label6.Text = "" Then
                Label3.Text = "0"
                Label7.Text = "0"
                Label6.Text = "0"
            End If
        Catch ex As Exception
            Label3.Text = "0"
            Label7.Text = "0"
            Label6.Text = "0"
        End Try


        DataGridView1.DataSource = _dtvdatosc

        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 120
        DataGridView1.Columns(2).Width = 120
        DataGridView1.Columns(3).Width = 40
        DataGridView1.Columns(4).Width = 60



        ''Me.Hide()
    End Sub
End Class