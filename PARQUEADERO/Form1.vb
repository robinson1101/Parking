Imports MySql.Data.MySqlClient
Imports MySql.Data
Imports System.Configuration
Imports System.Diagnostics
Imports System.IO
Imports System.Drawing.Printing
Imports System.Runtime.InteropServices

Public Class Form1
    Dim nuevo As Boolean
    Dim conexion1 As New MySqlConnection
    Dim datos As DataSet
    Dim adaptador As New MySqlDataAdapter
    Dim comandos As New MySqlCommand
    Dim acceptableKey As Boolean = False
    Dim conversorMoneda As New conversorMoneda

    Private ComBuffer As Byte()
    Private Delegate Sub UpdateFormDelegate()
    Private UpdateFormDelegate1 As UpdateFormDelegate
    Dim strReturn As String
    Dim strPeso As String
    Dim car As String
    Dim salir As Integer
    Private dsusuario As New DataSet
    Private dausuario As New MySqlDataAdapter
    Private cmdusuario As New MySqlCommand
    Dim Xdist
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion, conexion2, conexion3, conexionIns As New MySqlConnection(cadena)
    Public verdata, verSdata, comArtdata, codata, solidata, endata, sadata, candata, datostotal, datositem As New DataSet


    Private Function Bytes_Imagen(ByVal Imagen As Byte()) As Image
        Try
            'si hay imagen
            If Not Imagen Is Nothing Then
                'caturar array con memorystream hacia Bin
                Dim Bin As New MemoryStream(Imagen)
                'con el método FroStream de Image obtenemos imagen
                Dim Resultado As Image = Image.FromStream(Bin)
                'y la retornamos
                Return Resultado
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Sub cargarImagen()

        Try
            Dim valor As Byte() = Nothing
            Dim almacenar As MySqlDataReader
            Dim consulta As New MySqlCommand("select img from title", varconex)
            varconex.Open()
            almacenar = consulta.ExecuteReader

            If almacenar.Read Then
                Try
                    valor = almacenar(0)
                Catch ex As Exception
                    valor = Nothing
                End Try

            End If
            varconex.Close()

            If valor Is Nothing Then
                Me.PictureBoxImg.Image = My.Resources.img1
            Else
                Me.PictureBoxImg.Image = Bytes_Imagen(valor)
            End If
        Catch ex As Exception
            MsgBox("SICOVEH", ex.Message)
        End Try

    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarImagen()
        TimerHora.Enabled = True

        Label18.Text = consulta_empresa()
        inicio.Label3.Text = consulta_empresa()
        Timer4.Start()


        If conexion_global() Then
            'MessageBox.Show("conectado")
        Else
            'MessageBox.Show("xxxx")
        End If

        If TextBox3.Text = "" Then
            ' Button2.Enabled = False
        End If

        _dtsdatos.Reset()
        _dtsoperario.Reset()
        consulta_datos()
        consulta_datos1()
        DataGridView1.DataSource = _dtvdatos
        DataGridView1.Columns(1).MinimumWidth = 5
        ComboBox1.DataSource = _dtsoperario.Tables("operarios")
        ComboBox1.DisplayMember = "nombre"
        Try
            conexion1.ConnectionString = "server =localhost; user=root;password =cielito;database=parqueadero"
            conexion1.Open()


        Catch ex As Exception

        End Try
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 80
        DataGridView1.Columns(2).Width = 125
        DataGridView1.Columns(3).Width = 30
        DataGridView1.Columns(4).Width = 95
        DataGridView1.Columns(5).Width = 125
        DataGridView1.Columns(6).Width = 60
        DataGridView1.Columns(7).Width = 80
        DataGridView1.Columns(8).Width = 150
        DataGridView1.Columns(9).Width = 80
        DataGridView1.Columns(10).Width = 125
        DataGridView1.Columns(11).Width = 90
        DataGridView1.Columns(12).Width = 85
        DataGridView1.Columns(13).Width = 153
    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conexion As New class_int
        Dim datos As New class_datos
        Dim tipo_vehiculo As String = 0 'otro tipo de vehiculo diferente al 1,2 y 3.
        Dim servicio As Double
        Dim promo As Double
        Dim hora_ingreso As String = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
        Label6.Text = hora_ingreso
        If TextBox1.Text = "" Then
            MsgBox("DEBE INGRESAR LA PLACA DEL VEHICULO")

        End If

        Dim otro As Double
        If TextBox8.Text = "" Then
            otro = 0
        Else
            otro = conversorMoneda.ajustar_precio(TextBox8.Text)
        End If
        ' LABEL 5 CONTIENE LA INFORMACION DE DE CUANTOS NUMEROS HAY EN LA PLACA PARA LA ASIGNACION DE TIPO DE VEHICULO
        If Label5.Text = 3 Then
            tipo_vehiculo = 1
            ' automovil y camioneta
        End If
        If Label5.Text = 2 Then
            tipo_vehiculo = 2
            'moto
        End If
        If Label5.Text = 0 Then
            tipo_vehiculo = 3
            'bicicleta
        End If


        Dim aplicable As String = "0"
        Dim tipoDescuento As String = "0"
        Dim descuento As String = "0"
        If checkDescParqueadero.Checked = True And checkDescServicios.Checked = True Then
            aplicable = "P+S"
        ElseIf checkDescParqueadero.Checked = True And checkDescServicios.Checked = False Then
            aplicable = "P"
        ElseIf checkDescParqueadero.Checked = False And checkDescServicios.Checked = True Then
            aplicable = "S"
        End If

        If CheckPesos.Checked = True Then
            tipoDescuento = "$"
        ElseIf CheckPorcentaje.Checked = True Then
            tipoDescuento = "%"
        End If

        If txtDescuento.Text.Trim <> "" Or txtDescuento.Text.Trim <> "0" Then
            descuento = txtDescuento.Text.Trim
        End If

        'VALIDAR TIPO DE SERVICIO
        Dim TIPO_SERVICIO As String = ""
        Dim servicio1 As String = "0"
        Dim servicio2 As String = "0"
        Dim servicio3 As String = "0"
        Dim servicio4 As String = "0"
        Dim servicio5 As String = "0"
        Dim servicio6 As String = "0"
        Dim servicio7 As String = "0"
        Dim servicio8 As String = "0"
        Dim servicio9 As String = "0"
        Dim servicio10 As String = "0"
        Dim servicio11 As String = "0"
        Dim servicio12 As String = "0"
        Dim servicio13 As String = "0"
        Dim servicio14 As String = "0"
        Dim servicioOtros As String = "0"
        Dim servicioAdicional As String = "0"



        If CheckBox7.Checked = True Then
            If TIPO_SERVICIO = "" Then
                TIPO_SERVICIO = TIPO_SERVICIO + "1"
            ElseIf TIPO_SERVICIO <> "" Then
                TIPO_SERVICIO = TIPO_SERVICIO + "+1"
            End If


            If CheckBox22.Checked = True Then
                servicio1 = costos.enjuagueAutomovil.Text
            ElseIf CheckBox23.Checked = True Then
                servicio2 = costos.enjuagueCamioneta.Text
            ElseIf CheckBox2.Checked = True Then
                servicio3 = costos.enjuagueMoto.Text
            ElseIf CheckBox3.Checked = True Then
                servicio4 = costos.enjuagueOtro.Text
            End If

        End If

        If CheckBox8.Checked = True Then
            If TIPO_SERVICIO = "" Then
                TIPO_SERVICIO = TIPO_SERVICIO + "2"
            ElseIf TIPO_SERVICIO <> "" Then
                TIPO_SERVICIO = TIPO_SERVICIO + "+2"
            End If


            If CheckBox22.Checked = True Then
                servicio5 = costos.generalAutomovil.Text
            ElseIf CheckBox23.Checked = True Then
                servicio6 = costos.generalCamioneta.Text
            ElseIf CheckBox2.Checked = True Then
                servicio7 = costos.generalMoto.Text
            ElseIf CheckBox3.Checked = True Then
                servicio8 = costos.generalOtro.Text
            End If
        End If

        If CheckBox11.Checked = True Then
            If TIPO_SERVICIO = "" Then
                TIPO_SERVICIO = TIPO_SERVICIO + "3"
            ElseIf TIPO_SERVICIO <> "" Then
                TIPO_SERVICIO = TIPO_SERVICIO + "+3"
            End If


            If CheckBox22.Checked = True Then
                servicio9 = costos.tapiceriaAutomovil.Text
            ElseIf CheckBox23.Checked = True Then
                servicio10 = costos.tapiceriaCamioneta.Text
            ElseIf CheckBox3.Checked = True Then
                servicio11 = costos.tapiceriaOtro.Text
            End If
        End If

        If CheckBox9.Checked = True Then
            If TIPO_SERVICIO = "" Then
                TIPO_SERVICIO = TIPO_SERVICIO + "4"
            ElseIf TIPO_SERVICIO <> "" Then
                TIPO_SERVICIO = TIPO_SERVICIO + "+4"
            End If


            If CheckBox22.Checked = True Then
                servicio12 = costos.motorAutomovil.Text
            ElseIf CheckBox23.Checked = True Then
                servicio13 = costos.motorCamioneta.Text
            ElseIf CheckBox3.Checked = True Then
                servicio14 = costos.motorOtro.Text
            End If
        End If

        If CheckBox1.Checked = True And TIPO_SERVICIO = "" Then
            TIPO_SERVICIO = TIPO_SERVICIO + "5"
        ElseIf CheckBox1.Checked = True And TIPO_SERVICIO <> "" Then
            TIPO_SERVICIO = TIPO_SERVICIO + "+5"
        End If

        ' VALIDAR SERVICIO PARQUEO OR SERVICIO LAVADO 0R AMBOS
        Dim tarifas As String
        tarifas = ""
        If checkParking.Checked = True Then
            tarifas = "P"

        End If

        If checkLavado.Checked = True Then
            tarifas = "S" + TIPO_SERVICIO
        End If

        If checkMas.Checked = True Then
            tarifas = "P-S" + TIPO_SERVICIO

        End If

        Label39.Text = tarifas
        servicio = TextBox10.Text

        Label20.Text = servicio
        ' comision_vendedor = servicio / 2

        datos.placa = TextBox1.Text
        datos.tarifa = tarifas
        datos.tipo = tipo_vehiculo
        datos.hora_ingreso = Label6.Text
        datos.servicio = Label20.Text
        datos.cedula = TextBox4.Text
        datos.nombre_cliente = TextBox2.Text
        datos.telefono = TextBox5.Text
        datos.operario = ComboBox1.Text
        'datos.comision_vendedor = comision_vendedor
        Dim actualizar As String
        '  promo = Val(TextBox11.Text + 1)
        'If promo = 7 Then
        'promo = 0
        'End If
        'Label33.Text = promo
        ' actualizar = "update parqueadero.clientes  set SERVICIOS ='" & Label33.Text & "'  where documento = " & TextBox4.Text & " "
        '  comandos = New MySqlCommand(actualizar, conexion1)
        '  comandos.ExecuteNonQuery()

        If conexion.insertardatos(datos) Then


            Try



                conexion_global()
                Dim _adaptador As New MySqlDataAdapter
                _adaptador.InsertCommand = New MySqlCommand("insert into ventas (Factura,servicio1, servicio2, servicio3, servicio4, servicio5, servicio6, servicio7, servicio8, servicio9, servicio10, servicio11, servicio12, servicio13, servicio14, otro,descuento,tipoDescuento,aplicable)
                    values ((select max(Factura) from ingreso_vehiculos),@servicio1,@servicio2,@servicio3,@servicio4,@servicio5,@servicio6,@servicio7,@servicio8,@servicio9,@servicio10,@servicio11,@servicio12,@servicio13,@servicio14,@servicioOtro,@descuento,@tipoDescuento,@aplicable)", _conexion)
                _adaptador.InsertCommand.Parameters.Add("@servicio1", MySqlDbType.VarChar, 50).Value = servicio1
                _adaptador.InsertCommand.Parameters.Add("@servicio2", MySqlDbType.VarChar, 50).Value = servicio2
                _adaptador.InsertCommand.Parameters.Add("@servicio3", MySqlDbType.VarChar, 50).Value = servicio3
                _adaptador.InsertCommand.Parameters.Add("@servicio4", MySqlDbType.VarChar, 50).Value = servicio4
                _adaptador.InsertCommand.Parameters.Add("@servicio5", MySqlDbType.VarChar, 50).Value = servicio5
                _adaptador.InsertCommand.Parameters.Add("@servicio6", MySqlDbType.VarChar, 50).Value = servicio6
                _adaptador.InsertCommand.Parameters.Add("@servicio7", MySqlDbType.VarChar, 50).Value = servicio7
                _adaptador.InsertCommand.Parameters.Add("@servicio8", MySqlDbType.VarChar, 50).Value = servicio8
                _adaptador.InsertCommand.Parameters.Add("@servicio9", MySqlDbType.VarChar, 50).Value = servicio9
                _adaptador.InsertCommand.Parameters.Add("@servicio10", MySqlDbType.VarChar, 50).Value = servicio10
                _adaptador.InsertCommand.Parameters.Add("@servicio11", MySqlDbType.VarChar, 50).Value = servicio11
                _adaptador.InsertCommand.Parameters.Add("@servicio12", MySqlDbType.VarChar, 50).Value = servicio12
                _adaptador.InsertCommand.Parameters.Add("@servicio13", MySqlDbType.VarChar, 50).Value = servicio13
                _adaptador.InsertCommand.Parameters.Add("@servicio14", MySqlDbType.VarChar, 50).Value = servicio14
                _adaptador.InsertCommand.Parameters.Add("@servicioOtro", MySqlDbType.VarChar, 50).Value = otro
                _adaptador.InsertCommand.Parameters.Add("@descuento", MySqlDbType.VarChar, 50).Value = descuento
                _adaptador.InsertCommand.Parameters.Add("@tipoDescuento", MySqlDbType.VarChar, 50).Value = tipoDescuento
                _adaptador.InsertCommand.Parameters.Add("@aplicable", MySqlDbType.VarChar, 50).Value = aplicable

                _conexion.Open()
                _adaptador.InsertCommand.Connection = _conexion
                _adaptador.InsertCommand.ExecuteNonQuery()
                _conexion.Close()

            Catch ex As Exception
                MessageBox.Show(ex.Message)

            End Try

            _dtsdatos.Reset()
            consulta_datos()
            DataGridView1.DataSource = _dtvdatos
            ' MessageBox.Show("datos guardados")
        Else
            ' MessageBox.Show("no se realizo registro")
        End If
        TIKETINGRESO.Show()
        'Form2.Show()
        'GroupBox4.Enabled = False
        TextBox1.Enabled = False
        Button5.Enabled = False
        ComboBox1.Enabled = False
        Button8.Enabled = False
        Button1.Enabled = False

        TextBox1.Clear()
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox8.Clear()
        ComboBox1.ResetText()
        TextBox9.Clear()
        CheckBox1.Checked = False
        CheckBox2.Checked = False
        CheckBox3.Checked = False
        CheckBox7.Checked = False
        CheckBox8.Checked = False
        CheckBox9.Checked = False
        CheckBox10.Checked = False
        CheckBox11.Checked = False
        CheckBox12.Checked = False
        CheckBox13.Checked = False
        CheckBox17.Checked = False
        CheckBox20.Checked = False
        CheckBox21.Checked = False
        CheckBox23.Checked = False
        CheckBox22.Checked = False
        CheckBox4.Checked = False
        CheckBox18.Checked = False
        CheckBox19.Checked = False
        CheckBox15.Checked = False
        CheckBox16.Checked = False
        CheckBox14.Checked = False
        CheckBox5.Checked = False
        Button1.Enabled = False
        Label25.ForeColor = Color.WhiteSmoke
        Label29.ForeColor = Color.WhiteSmoke
        Label30.ForeColor = Color.WhiteSmoke
        Label31.ForeColor = Color.WhiteSmoke
        Label32.ForeColor = Color.WhiteSmoke
        datos.tipo = tipo_vehiculo
        datos.hora_ingreso = Label6.Text
        ' TextBox11.Clear()
        CheckBox25.Checked = False
        checkParking.Checked = False
        checkLavado.Checked = False
        checkMas.Checked = False
        CheckPorcentaje.Checked = False
        CheckPesos.Checked = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim conexion As New class_int
        Dim datos As New class_datos
        Dim placa_salida As String
        Dim actualizar As String
        Try
            TextBox3.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value ' placa salida
            Label12.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value 'hora_ingreso
            Label13.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(3).Value 'tipo_vehiculo
            Label24.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(4).Value 'tarifa    
            Label16.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value 'factura
            Label4.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(9).Value ' servico
            txtServicioValidar.Text = Label24.Text

        Catch ex As NullReferenceException

        End Try
        actualizar = "update ingreso_vehiculos SET  hora_salida= " & Label11.Text & ",  tiempo =" & Label9.Text & ", total =" & Label14.Text & " where Factura= " & Label16.Text & ""
        Dim salida As String
        salida = TextBox3.Text
        Dim fechasalida As String = Date.Now.ToString("yyyy/MM/dd HH:mm:ss")
        placa_salida = TextBox3.Text
        Label11.Text = fechasalida
        Form5.Label4.Text = Label11.Text
        datos.placa = placa_salida
        Dim dias As String
        Dim horas As String
        Dim minutos As String
        Dim segundos As String
        Dim costo As Double
        Dim vehi As String
        Dim servicio As Double
        costo = 0
        vehi = 0

        'Dim FechaEntrada As String = "2015/05/01 12:27:42"
        'Dim FechaSalida As String = "2015/05/02  15:28:52"
        'dias = DateDiff(DateInterval.Day, CDate(FechaEntrada), CDate(fechasalida))
        'horas = DateDiff(DateInterval.Hour, CDate(FechaEntrada), CDate(fechasalida))
        minutos = DateDiff(DateInterval.Minute, CDate(Label12.Text), CDate(Label11.Text))
        'segundos = DateDiff(DateInterval.Second, CDate(FechaEntrada), CDate(fechasalida))
        'Label7.Text = dias
        'Label8.Text = horas
        'Label10.Text = segundos
        'If Val(Label9.Text) < 15000 Then
        '    minutos = 0
        'End If
        Label9.Text = minutos

        ' calculo de precios por tarifa de motos
        ' si label 13 es si tipo de vehiculo es 1 es carro 2 es moto y tres cicla

        Dim totalfact As Double
        Dim tarifa As String
        tarifa = Label24.Text


        '''''''FORM1 LABEL 9 TIENEN EL TIEMPO DE PARQUEO''''''informacion otro formulario
        '''''''LABEL 9 FORM 3 ESTE TIENE LA INFO DEL SERVICIO'''''
        Dim TIEMPO As Integer = minutos

        servicio = Val(Label4.Text)


        Dim letras As String
        Dim contador As Integer

        For i = 1 To txtServicioValidar.TextLength
            letras = Mid(txtServicioValidar.Text, i, 1)
            If letras = "P" Then
                contador = contador + 1
            End If
        Next

        If contador = 1 Then
            If Label13.Text = 0 Then
                costo = Val(costos.otro.Text) * TIEMPO
                vehi = "OTRO"
            End If
            If Label13.Text = 1 Then
                costo = Val(costos.carro.Text) * TIEMPO
                vehi = "CARRO"

            End If
            If Label13.Text = 2 Then
                costo = Val(costos.moto.Text) * TIEMPO
                vehi = "MOTO"
            End If
            If Label13.Text = 3 Then
                costo = Val(costos.bicicleta.Text) * TIEMPO
                vehi = "BICI"

            End If
        Else
            costo = 0
        End If



        'If tarifa = 1 Then
        '    costo = 20000
        'End If
        'If tarifa = 2 Then
        '    costo = 10000
        'End If

        totalfact = servicio + costo

        Label34.Text = CStr(totalfact)


        Label17.Text = costo
        Label14.Text = servicio
        Label15.Text = vehi

        Try
            Dim _adaptador As New MySqlDataAdapter
            conexion_global()
            _adaptador.UpdateCommand = New MySqlCommand("UPDATE  ventas Set  parqueadero='" & costo & "' where Factura='" & Label16.Text & "'", _conexion)

            _conexion.Open()
            _adaptador.UpdateCommand.Connection = _conexion
            _adaptador.UpdateCommand.ExecuteNonQuery()
            _conexion.Close()

        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try

        If conexion.actualizardatos(datos) Then
            _dtsdatos.Reset()

            consulta_datos()
            DataGridView1.DataSource = _dtvdatos
            ' MessageBox.Show("datos guardados")
        Else
            ' MessageBox.Show("no se realizo registro")
        End If
        factura_cobrar.cobrar()
        'Form3.Show()
        TextBox3.Clear()
        'Button2.Enabled = False

    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'codigo para cambiar de minusculas a mayusculas cuando se escribe en la caja de texto
        Dim I As Integer
        TextBox1.Text = UCase(TextBox1.Text)
        I = Len(TextBox1.Text)
        TextBox1.SelectionStart = I

        Dim letras As String
        Dim contador As Integer
        Label37.Text = ComboBox1.Text
        For I = 1 To TextBox1.TextLength
            letras = Mid(TextBox1.Text, I, 1)
            If letras = "0" Or letras = "1" Or letras = "2" Or letras = "3" Or letras = "4" Or letras = "5" Or letras = "6" Or letras = "7" Or letras = "8" Or letras = "9" Then
                contador = contador + 1
            End If
        Next
        If TextBox1.Text.Trim = "" Then
            lblVehiculo.Text = "NINGUNO"
        Else
            If contador = 3 Then
                lblVehiculo.Text = "AUTO"
            End If
            If contador = 2 Then
                lblVehiculo.Text = "MOTO"
            End If
            If contador = 0 Then
                lblVehiculo.Text = "BICICLETA"
            End If
            If contador <> 3 And contador <> 2 And contador <> 0 Then
                lblVehiculo.Text = "OTRO"
            End If
        End If
        '

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'DataGridView1.Columns(0).Visible = False
        ' DataGridView1.Columns(1).Width = 10
        ' DataGridView1.Columns(2).Width = 20
        'DataGridView1.Columns(3).Width = 100
        'DataGridView1.Columns(4).Width = 100
        'DataGridView1.Columns(5).Width = 100
        'DataGridView1.Columns(6).Width = 100
        'Me.DataGridView1.Columns(5).Visible = False
    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        TextBox3.Focus()

        Try
            TextBox3.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value
            Label12.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value
            Label13.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(3).Value
            Label24.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(4).Value
            Label16.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
            Label4.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(9).Value
            'Label37.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(13).Value

        Catch ex As NullReferenceException

        End Try
    End Sub


    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click

    End Sub
    Public Sub item()
        Dim cmd As New MySqlCommand("select COUNT(ingreso_vehiculos.hora_salida) as contar FROM ingreso_vehiculos WHERE  ingreso_vehiculos.hora_salida ='' ", conexion)
        Try
            Dim lectura2 As MySqlDataReader
            If Not conexion Is Nothing Then conexion.Close()
            conexion.Open()
            lectura2 = cmd.ExecuteReader
            If lectura2.Read() Then
                Me.Label38.Text = lectura2.Item("contar")
            End If
        Catch ex As Exception
            Me.Label38.Text = 0
        End Try
        conexion.Close()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        Dim cam As Integer
        TextBox3.Text = UCase(TextBox3.Text)
        cam = Len(TextBox3.Text)
        TextBox3.SelectionStart = cam
        If TextBox3.Text <> "" Then
            Button2.Enabled = True
        End If
        _dtvdatos.RowFilter = "placa like '%" & TextBox3.Text & "%'"

    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Start()

    End Sub


    Private num As Integer = 0

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick

        Timer2.Start()
        Call item()
        Dim letras As String
        Dim contador As Integer
        Label37.Text = ComboBox1.Text
        For i = 1 To TextBox1.TextLength
            letras = Mid(TextBox1.Text, i, 1)
            If letras = "0" Or letras = "1" Or letras = "2" Or letras = "3" Or letras = "4" Or letras = "5" Or letras = "6" Or letras = "7" Or letras = "8" Or letras = "9" Then
                contador = contador + 1
            End If
        Next
        Label5.Text = contador


        If (num Mod 2 = 0) Then

            '  _dtsdatos.Reset()
            '  consulta_datos()
            _dtvdatos.RowFilter = "placa like '%" & TextBox3.Text & "%'"

            If TextBox3.Text = "" Then
                Button2.Enabled = False
            End If
            DataGridView1.DataSource = _dtvdatos

            Dim juagada As Integer
            Dim general As Integer
            Dim motor As Integer
            Dim tapizado As Integer


            Dim servicio As Double

            If ((TextBox1.Text = "")) Then
                Button1.Enabled = False
            Else
                Button1.Enabled = True
            End If

            If CheckBox22.Checked = True Then
                If CheckBox7.Checked = True Then
                    juagada = Val(costos.enjuagueAutomovil.Text)
                Else
                    juagada = 0
                End If
                If CheckBox8.Checked = True Then
                    general = Val(costos.generalAutomovil.Text)
                Else
                    general = 0
                End If
                If CheckBox9.Checked = True Then
                    motor = Val(costos.motorAutomovil.Text)
                Else
                    motor = 0
                End If
                If CheckBox11.Checked = True Then
                    tapizado = Val(costos.tapiceriaAutomovil.Text)
                Else
                    tapizado = 0
                End If


            End If

            If CheckBox23.Checked = True Then
                If CheckBox7.Checked = True Then
                    juagada = costos.enjuagueCamioneta.Text
                Else
                    juagada = 0
                End If
                If CheckBox8.Checked = True Then
                    general = costos.generalCamioneta.Text
                Else
                    general = 0
                End If
                If CheckBox9.Checked = True Then
                    motor = costos.motorCamioneta.Text
                Else
                    motor = 0
                End If
                If CheckBox11.Checked = True Then
                    tapizado = costos.tapiceriaCamioneta.Text
                Else
                    tapizado = 0
                End If

            End If

            If CheckBox2.Checked = True Then
                If CheckBox7.Checked = True Then
                    juagada = costos.enjuagueMoto.Text
                Else
                    juagada = 0
                End If
                If CheckBox8.Checked = True Then
                    general = costos.generalMoto.Text
                Else
                    general = 0
                End If

            End If

            If CheckBox3.Checked = True Then
                If CheckBox7.Checked = True Then
                    juagada = costos.enjuagueOtro.Text
                Else
                    juagada = 0
                End If
                If CheckBox8.Checked = True Then
                    general = costos.generalOtro.Text
                Else
                    general = 0
                End If
                If CheckBox9.Checked = True Then
                    motor = costos.motorOtro.Text
                Else
                    motor = 0
                End If
                If CheckBox11.Checked = True Then
                    tapizado = costos.tapiceriaOtro.Text
                Else
                    tapizado = 0
                End If

            End If


            Dim otro As Double
            If TextBox8.Text = "" Then
                otro = 0
            Else
                otro = TextBox8.Text
            End If


            Dim tipo_vehiculo As Integer = 1

            servicio = juagada + general + motor + tapizado + otro
            Label20.Text = servicio
            '  TextBox10.Text = servicio

            TextBox10.Text = servicio


            Dim promo As String

            promo = TextBox11.Text
            If promo = "1" Then
                Label25.ForeColor = ForeColor.Red
            End If
            If promo = "2" Then
                Label25.ForeColor = ForeColor.Red
                Label29.ForeColor = ForeColor.Red
            End If
            If promo = "3" Then
                Label25.ForeColor = ForeColor.Red
                Label29.ForeColor = ForeColor.Red
                Label30.ForeColor = ForeColor.Red
            End If
            If promo = "4" Then
                Label25.ForeColor = ForeColor.Red
                Label29.ForeColor = ForeColor.Red
                Label30.ForeColor = ForeColor.Red
                Label31.ForeColor = ForeColor.Red
            End If

            If promo = "5" Then
                Label25.ForeColor = ForeColor.Red
                Label29.ForeColor = ForeColor.Red
                Label30.ForeColor = ForeColor.Red
                Label31.ForeColor = ForeColor.Red
                Label32.ForeColor = ForeColor.Red

            End If


            If promo = "6" Then
                Label25.ForeColor = ForeColor.Gold
                Label29.ForeColor = ForeColor.Gold
                Label30.ForeColor = ForeColor.Gold
                Label31.ForeColor = ForeColor.Gold
                Label32.ForeColor = ForeColor.Gold

            End If

            If CheckBox12.Checked = False Then
                CheckBox12.BackColor = Color.PowderBlue
            End If


            If CheckBox10.Checked = False Then
                CheckBox10.BackColor = Color.PowderBlue
            End If
            If CheckBox4.Checked = False Then
                CheckBox4.BackColor = Color.PowderBlue
            End If

            If CheckBox13.Checked = False Then
                CheckBox13.BackColor = Color.PowderBlue
            End If
            If CheckBox14.Checked = False Then
                CheckBox14.BackColor = Color.PowderBlue
            End If
            If CheckBox15.Checked = False Then
                CheckBox15.BackColor = Color.PowderBlue
            End If
            If CheckBox16.Checked = False Then
                CheckBox16.BackColor = Color.PowderBlue
            End If
            If CheckBox17.Checked = False Then
                CheckBox17.BackColor = Color.PowderBlue
            End If
            If CheckBox18.Checked = False Then
                CheckBox18.BackColor = Color.PowderBlue
            End If
            If CheckBox19.Checked = False Then
                CheckBox19.BackColor = Color.PowderBlue
            End If
            If CheckBox20.Checked = False Then
                CheckBox20.BackColor = Color.PowderBlue
            End If
            If CheckBox21.Checked = False Then
                CheckBox21.BackColor = Color.PowderBlue
            End If
            If CheckBox5.Checked = False Then
                CheckBox5.BackColor = Color.PowderBlue
            End If

        End If

    End Sub

    Private numa As Integer = 0
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick


    End Sub

    Private Sub CheckBox12_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox12.CheckedChanged

        If CheckBox12.Checked = True Then
            CheckBox12.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged

    End Sub

    Private Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged

        If CheckBox7.Checked = True Then
            CheckBox7.BackColor = Color.Blue
            CheckBox7.ForeColor = Color.White
        Else
            CheckBox7.BackColor = Color.White
            CheckBox7.ForeColor = Color.Black

        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged

        If CheckBox8.Checked = True Then
            CheckBox8.BackColor = Color.Blue
            CheckBox8.ForeColor = Color.White
        Else
            CheckBox8.BackColor = Color.White
            CheckBox8.ForeColor = Color.Black

        End If
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged

        If CheckBox9.Checked = True Then
            CheckBox9.BackColor = Color.Blue
            CheckBox9.ForeColor = Color.White
        Else
            CheckBox9.BackColor = Color.White
            CheckBox9.ForeColor = Color.Black

        End If
    End Sub

    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.CheckedChanged

        If CheckBox10.Checked = True Then
            CheckBox10.BackColor = Color.DarkRed
            CheckBox10.ForeColor = Color.White
        Else
            CheckBox10.ForeColor = Color.White
        End If
    End Sub

    Private Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged

        If CheckBox11.Checked = True Then
            CheckBox11.BackColor = Color.Blue
            CheckBox11.ForeColor = Color.White
        Else
            CheckBox11.BackColor = Color.White
            CheckBox11.ForeColor = Color.Black

        End If
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form6.Show()
    End Sub

    Private Sub CheckBox13_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox13.CheckedChanged
        If CheckBox13.Checked = True Then
            CheckBox13.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub CheckBox20_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox20.CheckedChanged
        If CheckBox20.Checked = True Then
            CheckBox20.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub CheckBox21_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox21.CheckedChanged
        If CheckBox21.Checked = True Then
            CheckBox21.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub CheckBox17_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox17.CheckedChanged
        If CheckBox17.Checked = True Then
            CheckBox17.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub CheckBox14_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox14.CheckedChanged
        If CheckBox14.Checked = True Then
            CheckBox14.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        If CheckBox4.Checked = True Then
            CheckBox4.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        If CheckBox5.Checked = True Then
            CheckBox5.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub CheckBox18_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox18.CheckedChanged
        If CheckBox18.Checked = True Then
            CheckBox18.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub PictureBox4_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox4.MouseLeave
        Me.PictureBox4.Image = My.Resources.automobile
        CheckBox22.ForeColor = Color.Black
    End Sub

    Private Sub PictureBox4_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox4.MouseMove
        Me.PictureBox4.Image = My.Resources.automobile3
        CheckBox22.ForeColor = Color.Red
    End Sub

    Private Sub PictureBox3_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox3.MouseLeave
        Me.PictureBox3.Image = My.Resources.suv
        CheckBox23.ForeColor = Color.Black
    End Sub

    Private Sub PictureBox3_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox3.MouseMove
        Me.PictureBox3.Image = My.Resources.suv1
        CheckBox23.ForeColor = Color.Red
    End Sub


    Private Sub PictureBox2_MouseLeave_1(sender As Object, e As EventArgs) Handles PictureBox2.MouseLeave
        Me.PictureBox2.Image = My.Resources.motorcycle0
        CheckBox2.ForeColor = Color.Black
    End Sub

    Private Sub PictureBox2_MouseMove_1(sender As Object, e As MouseEventArgs) Handles PictureBox2.MouseMove
        Me.PictureBox2.Image = My.Resources.motorcycle
        CheckBox2.ForeColor = Color.Red
    End Sub

    Private Sub CheckBox22_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox22.CheckedChanged
        If CheckBox22.Checked = True Then
            Me.PictureBox4.BorderStyle = BorderStyle.Fixed3D
            Me.PictureBox4.BackColor = Color.Yellow
            CheckBox23.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox7.Enabled = True
            CheckBox8.Enabled = True
            CheckBox9.Enabled = True
            CheckBox11.Enabled = True
            CheckBox1.Enabled = True

        Else
            CheckBox7.Enabled = False
            CheckBox8.Enabled = False
            CheckBox9.Enabled = False
            CheckBox11.Enabled = False
            CheckBox1.Enabled = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox11.Checked = False
            CheckBox1.Checked = False
            Me.PictureBox4.BorderStyle = BorderStyle.None
            Me.PictureBox4.BackColor = Color.White

        End If

    End Sub

    Private Sub CheckBox23_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox23.CheckedChanged
        If CheckBox23.Checked = True Then
            Me.PictureBox3.BorderStyle = BorderStyle.Fixed3D
            Me.PictureBox3.BackColor = Color.Yellow
            CheckBox22.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            CheckBox7.Enabled = True
            CheckBox8.Enabled = True
            CheckBox9.Enabled = True
            CheckBox11.Enabled = True
            CheckBox1.Enabled = True
        Else
            CheckBox7.Enabled = False
            CheckBox8.Enabled = False
            CheckBox9.Enabled = False
            CheckBox11.Enabled = False
            CheckBox1.Enabled = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox11.Checked = False
            CheckBox1.Checked = False
            Me.PictureBox3.BorderStyle = BorderStyle.None
            Me.PictureBox3.BackColor = Color.White
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            Me.PictureBox2.BorderStyle = BorderStyle.Fixed3D
            Me.PictureBox2.BackColor = Color.Yellow
            CheckBox23.Checked = False
            CheckBox22.Checked = False
            CheckBox3.Checked = False
            CheckBox7.Enabled = True
            CheckBox8.Enabled = True
            CheckBox1.Enabled = True
        Else
            CheckBox7.Enabled = False
            CheckBox8.Enabled = False
            CheckBox1.Enabled = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox11.Checked = False
            CheckBox1.Checked = False
            Me.PictureBox2.BorderStyle = BorderStyle.None
            Me.PictureBox2.BackColor = Color.White
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        If CheckBox22.Checked = False Then
            CheckBox22.Checked = True
        ElseIf CheckBox22.Checked = True Then
            CheckBox22.Checked = False
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged

        If CheckBox3.Checked = True Then
            'Me.PictureBox3.BorderStyle = BorderStyle.Fixed3D
            CheckBox23.Checked = False
            CheckBox22.Checked = False
            CheckBox2.Checked = False
            CheckBox7.Enabled = True
            CheckBox8.Enabled = True
            CheckBox9.Enabled = True
            CheckBox11.Enabled = True
            CheckBox1.Enabled = True
        Else
            CheckBox7.Enabled = False
            CheckBox8.Enabled = False
            CheckBox9.Enabled = False
            CheckBox11.Enabled = False
            CheckBox1.Enabled = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox11.Checked = False
            CheckBox1.Checked = False
            Me.PictureBox3.BorderStyle = BorderStyle.None
        End If

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        If CheckBox23.Checked = False Then
            CheckBox23.Checked = True
        ElseIf CheckBox23.Checked = True Then
            CheckBox23.Checked = False
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        If CheckBox2.Checked = False Then
            CheckBox2.Checked = True
        ElseIf CheckBox2.Checked = True Then
            CheckBox2.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox8.Enabled = True
        ElseIf CheckBox1.Checked = False Then
            TextBox8.Enabled = False
        End If

        If CheckBox1.Checked = True Then
            CheckBox1.BackColor = Color.Blue
            CheckBox1.ForeColor = Color.White
        Else
            CheckBox1.BackColor = Color.White
            CheckBox1.ForeColor = Color.Black

        End If
    End Sub


    Private Sub TimerHora_Tick(sender As Object, e As EventArgs) Handles TimerHora.Tick
        ITEMHORA.Text = DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToString("hh:mm:ss")

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        If checkParking.Checked = False Then
            checkParking.Checked = True
        ElseIf checkParking.Checked = True Then
            checkParking.Checked = False
        End If
    End Sub

    Private Sub PictureBox1_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseMove
        Me.PictureBox1.Image = My.Resources.parquear22

    End Sub

    Private Sub PictureBox1_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave
        Me.PictureBox1.Image = My.Resources.parquear11
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick

    End Sub

    Private Sub ToolTipPrincipal_Popup(sender As Object, e As PopupEventArgs) Handles ToolTipPrincipal.Popup

    End Sub

    Private Sub PictureBox6_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox6.MouseLeave
        Me.PictureBox6.Image = My.Resources.lavado11
    End Sub

    Private Sub PictureBox6_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox6.MouseMove
        Me.PictureBox6.Image = My.Resources.lavado21
    End Sub

    Private Sub PictureBox7_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox7.MouseLeave
        Me.PictureBox7.Image = My.Resources.mas11
    End Sub

    Private Sub PictureBox7_MouseMove(sender As Object, e As MouseEventArgs) Handles PictureBox7.MouseMove
        Me.PictureBox7.Image = My.Resources.mas21
    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        If checkLavado.Checked = False Then
            checkLavado.Checked = True
        ElseIf checkLavado.Checked = True Then
            checkLavado.Checked = False
        End If
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        If checkMas.Checked = False Then
            checkMas.Checked = True
        ElseIf checkMas.Checked = True Then
            checkMas.Checked = False
        End If
    End Sub

    Private Sub checkParking_CheckedChanged(sender As Object, e As EventArgs) Handles checkParking.CheckedChanged
        If checkParking.Checked = True Then
            Me.PictureBox1.BorderStyle = BorderStyle.Fixed3D
            Me.PictureBox1.BackColor = Color.GreenYellow
            checkLavado.Checked = False
            checkMas.Checked = False

            PictureBox2.Enabled = False
            PictureBox3.Enabled = False
            PictureBox4.Enabled = False
            CheckBox3.Enabled = False
            CheckBox2.Enabled = False
            CheckBox23.Enabled = False
            CheckBox22.Enabled = False

            TextBox1.Enabled = True
            Button5.Enabled = True
            ComboBox1.Enabled = False
            Button8.Enabled = False


            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox11.Checked = False
            CheckBox1.Checked = False
            CheckBox22.Checked = False
            CheckBox23.Checked = False
            CheckBox2.Checked = False
            CheckBox3.Checked = False
            checkDescParqueadero.Enabled = True
            checkDescServicios.Enabled = False
            checkDescParqueadero.Checked = False
            checkDescServicios.Checked = False
            'CONSULTA PARA AJUSTAR DESCUENTO PREDETERMINADO
            Dim _adaptador2 As MySqlDataReader
            Dim dto As String = "0"
            Dim tipo As String = "0"
            Dim aplicable As String = "0"
            Dim activo As String = "0"

            Try


                Dim cmd1 As New MySqlCommand("select descuento,tipoDescuento,aplicable,activo from title", _conexion)
                _conexion.Open()
                _adaptador2 = cmd1.ExecuteReader()

                If _adaptador2.Read Then
                    dto = _adaptador2(0)
                    tipo = _adaptador2(1)
                    aplicable = _adaptador2(2)
                    activo = _adaptador2(3)

                End If

                _conexion.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            If activo = "SI" And aplicable = "P" Then

                checkDescParqueadero.Checked = True

                If tipo = "%" Then
                    CheckPorcentaje.Checked = True
                ElseIf tipo = "$" Then
                    CheckPesos.Checked = True
                End If
                txtDescuento.Text = dto
            End If

        Else
            Me.PictureBox1.BorderStyle = BorderStyle.None
            Me.PictureBox1.BackColor = Color.Transparent
            TextBox1.Text = ""
            TextBox1.Enabled = False
            Button5.Enabled = False
            checkDescParqueadero.Enabled = False
            checkDescServicios.Enabled = False
            checkDescParqueadero.Checked = False
            checkDescServicios.Checked = False
        End If
    End Sub

    Private Sub checkLavado_CheckedChanged(sender As Object, e As EventArgs) Handles checkLavado.CheckedChanged
        If checkLavado.Checked = True Then
            Me.PictureBox6.BorderStyle = BorderStyle.Fixed3D
            Me.PictureBox6.BackColor = Color.GreenYellow
            checkParking.Checked = False
            checkMas.Checked = False
            PictureBox2.Enabled = True
            PictureBox3.Enabled = True
            PictureBox4.Enabled = True
            CheckBox3.Enabled = True
            CheckBox2.Enabled = True
            CheckBox23.Enabled = True
            CheckBox22.Enabled = True
            TextBox1.Enabled = True
            Button5.Enabled = True
            ComboBox1.Enabled = True
            Button8.Enabled = True
            checkDescParqueadero.Enabled = False
            checkDescServicios.Enabled = True
            checkDescParqueadero.Checked = False
            checkDescServicios.Checked = False
            'CONSULTA PARA AJUSTAR DESCUENTO PREDETERMINADO
            Dim _adaptador2 As MySqlDataReader
            Dim dto As String = "0"
            Dim tipo As String = "0"
            Dim aplicable As String = "0"
            Dim activo As String = "0"

            Try


                Dim cmd1 As New MySqlCommand("select descuento,tipoDescuento,aplicable,activo from title", _conexion)
                _conexion.Open()
                _adaptador2 = cmd1.ExecuteReader()

                If _adaptador2.Read Then
                    dto = _adaptador2(0)
                    tipo = _adaptador2(1)
                    aplicable = _adaptador2(2)
                    activo = _adaptador2(3)

                End If

                _conexion.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            If activo = "SI" And aplicable = "S" Then

                checkDescServicios.Checked = True

                If tipo = "%" Then
                    CheckPorcentaje.Checked = True
                ElseIf tipo = "$" Then
                    CheckPesos.Checked = True
                End If
                txtDescuento.Text = dto
            End If

        Else
            Me.PictureBox6.BorderStyle = BorderStyle.None
            Me.PictureBox6.BackColor = Color.Transparent
            PictureBox2.Enabled = False
            PictureBox3.Enabled = False
            PictureBox4.Enabled = False
            CheckBox3.Enabled = False
            CheckBox2.Enabled = False
            CheckBox23.Enabled = False
            CheckBox22.Enabled = False
            TextBox1.Enabled = False
            Button5.Enabled = False
            ComboBox1.Enabled = False
            Button8.Enabled = False
            CheckBox3.Checked = False
            CheckBox2.Checked = False
            CheckBox23.Checked = False
            CheckBox22.Checked = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox11.Checked = False
            CheckBox1.Checked = False
            ComboBox1.SelectedIndex = 0
            TextBox1.Text = ""
            checkDescParqueadero.Enabled = False
            checkDescServicios.Enabled = False
            checkDescParqueadero.Checked = False
            checkDescServicios.Checked = False
        End If
    End Sub

    Private Sub checkMas_CheckedChanged(sender As Object, e As EventArgs) Handles checkMas.CheckedChanged
        If checkMas.Checked = True Then
            Me.PictureBox7.BorderStyle = BorderStyle.Fixed3D
            Me.PictureBox7.BackColor = Color.GreenYellow
            checkParking.Checked = False
            checkLavado.Checked = False

            PictureBox2.Enabled = True
            PictureBox3.Enabled = True
            PictureBox4.Enabled = True
            CheckBox3.Enabled = True
            CheckBox2.Enabled = True
            CheckBox23.Enabled = True
            CheckBox22.Enabled = True
            TextBox1.Enabled = True
            Button5.Enabled = True
            ComboBox1.Enabled = True
            Button8.Enabled = True
            checkDescParqueadero.Enabled = True
            checkDescServicios.Enabled = True
            checkDescParqueadero.Checked = False
            checkDescServicios.Checked = False
            'CONSULTA PARA AJUSTAR DESCUENTO PREDETERMINADO
            Dim _adaptador2 As MySqlDataReader
            Dim dto As String = "0"
            Dim tipo As String = "0"
            Dim aplicable As String = "0"
            Dim activo As String = "0"

            Try


                Dim cmd1 As New MySqlCommand("select descuento,tipoDescuento,aplicable,activo from title", _conexion)
                _conexion.Open()
                _adaptador2 = cmd1.ExecuteReader()

                If _adaptador2.Read Then
                    dto = _adaptador2(0)
                    tipo = _adaptador2(1)
                    aplicable = _adaptador2(2)
                    activo = _adaptador2(3)

                End If

                _conexion.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            If activo = "SI" And aplicable = "P+S" Then

                checkDescParqueadero.Checked = True
                checkDescServicios.Checked = True

                If tipo = "%" Then
                    CheckPorcentaje.Checked = True
                ElseIf tipo = "$" Then
                    CheckPesos.Checked = True
                End If
                txtDescuento.Text = dto
            End If
        Else
            Me.PictureBox7.BorderStyle = BorderStyle.None
            Me.PictureBox7.BackColor = Color.Transparent
            PictureBox2.Enabled = False
            PictureBox3.Enabled = False
            PictureBox4.Enabled = False
            CheckBox3.Enabled = False
            CheckBox2.Enabled = False
            CheckBox23.Enabled = False
            CheckBox22.Enabled = False
            TextBox1.Enabled = False
            Button5.Enabled = False
            ComboBox1.Enabled = False
            Button8.Enabled = False
            CheckBox3.Checked = False
            CheckBox2.Checked = False
            CheckBox23.Checked = False
            CheckBox22.Checked = False
            CheckBox7.Checked = False
            CheckBox8.Checked = False
            CheckBox9.Checked = False
            CheckBox11.Checked = False
            CheckBox1.Checked = False
            ComboBox1.SelectedIndex = 0
            TextBox1.Text = ""
            checkDescParqueadero.Enabled = False
            checkDescServicios.Enabled = False
            checkDescParqueadero.Checked = False
            checkDescServicios.Checked = False
        End If
    End Sub

    Private Sub CheckPorcentaje_CheckedChanged(sender As Object, e As EventArgs) Handles CheckPorcentaje.CheckedChanged
        If CheckPorcentaje.Checked = True Then
            CheckPesos.Checked = False
            txtDescuento.Enabled = True
        ElseIf CheckPorcentaje.Checked = False Then
            txtDescuento.Enabled = False
            txtDescuento.Text = ""
        End If

    End Sub

    Private Sub CheckPesos_CheckedChanged(sender As Object, e As EventArgs) Handles CheckPesos.CheckedChanged
        If CheckPesos.Checked = True Then
            CheckPorcentaje.Checked = False
            txtDescuento.Enabled = True
        ElseIf CheckPesos.Checked = False Then
            txtDescuento.Enabled = False
            txtDescuento.Text = ""
        End If
    End Sub

    Private Sub checkDescParqueadero_CheckedChanged(sender As Object, e As EventArgs) Handles checkDescParqueadero.CheckedChanged
        If checkDescParqueadero.Checked = True And checkDescServicios.Checked = False Then
            CheckPorcentaje.Enabled = True
            CheckPesos.Enabled = True
        ElseIf checkDescParqueadero.Checked = True And checkDescServicios.Checked = True Then
            CheckPorcentaje.Enabled = True
            CheckPesos.Enabled = True
        ElseIf checkDescParqueadero.Checked = False And checkDescServicios.Checked = False Then
            CheckPorcentaje.Enabled = False
            CheckPesos.Enabled = False
            CheckPorcentaje.Checked = False
            CheckPesos.Checked = False
        End If
    End Sub

    Private Sub checkDescServicios_CheckedChanged(sender As Object, e As EventArgs) Handles checkDescServicios.CheckedChanged
        If checkDescParqueadero.Checked = False And checkDescServicios.Checked = True Then
            CheckPorcentaje.Enabled = True
            CheckPesos.Enabled = True
        ElseIf checkDescParqueadero.Checked = True And checkDescServicios.Checked = True Then
            CheckPorcentaje.Enabled = True
            CheckPesos.Enabled = True
        ElseIf checkDescParqueadero.Checked = False And checkDescServicios.Checked = False Then
            CheckPorcentaje.Enabled = False
            CheckPesos.Enabled = False
            CheckPorcentaje.Checked = False
            CheckPesos.Checked = False
        End If
    End Sub

    Private Sub TextBox3_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyUp
        Select Case (e.KeyCode)
            Case Keys.F1
                Button2_Click(sender, e)
        End Select
    End Sub

    Private Sub TextBox1_KeyUp(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyUp
        Select Case (e.KeyCode)
            Case Keys.F2
                Button1_Click(sender, e)
            Case Keys.F3
                Button5_Click(sender, e)

        End Select
    End Sub

    Private Sub DataGridView1_KeyUp(sender As Object, e As KeyEventArgs) Handles DataGridView1.KeyUp
        TextBox3.Focus()
        Select Case (e.KeyCode)
            Case Keys.Enter

                Try
                    TextBox3.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value
                    Label12.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value
                    Label13.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(3).Value
                    Label24.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(4).Value
                    Label16.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
                    Label4.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(9).Value
                    'Label37.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(13).Value



                Catch ex As NullReferenceException

                End Try

        End Select

    End Sub

    Private Sub OperariosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperariosToolStripMenuItem.Click
        Form7.ShowDialog()
    End Sub

    Private Sub RSalidaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RSalidaToolStripMenuItem.Click
        REIMPRIMIRSALIDA.ShowDialog()
    End Sub

    Private Sub AdministradorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdministradorToolStripMenuItem.Click
        VALIDAR_REPORTE_ADMIN.ShowDialog()

    End Sub

    Private Sub CONFIGURARToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ITEMCONFIGURAR.Click

        Form_actualizar.ShowDialog()

    End Sub


    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing

        Dim Msg As MsgBoxResult
        Msg = MsgBox("         ESTA A PUNTO DE CERRAR EL PROGRAMA" & vbCrLf & "" & vbCrLf & "         ¿Desea salir?..", vbYesNo, "DETENER APLICATIVO")
        If Msg = MsgBoxResult.Yes Then
            Application.ExitThread()
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub TotalFacturadoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TotalFacturadoToolStripMenuItem.Click
        REPORTES.ShowDialog()
    End Sub

    Private Sub TextBox3_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox3.KeyDown
        'codigo para ejecutar el evento del enter
        If e.KeyCode = Keys.Enter Then
            Button2_Click(sender, e)
        End If
    End Sub

    Private Sub SALIRToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ITEMUSUARIO.Click

    End Sub

    Private Sub REntradaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REntradaToolStripMenuItem.Click
        REIMPRIMIR.ShowDialog()
    End Sub



    Private Sub BuscarCierreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BuscarCierreToolStripMenuItem.Click
        BUSCAR_CIERRE.Dispose()
        BUSCAR_CIERRE.ShowDialog()
    End Sub

    Private Sub RealizarCierreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RealizarCierreToolStripMenuItem.Click

        If Label38.Text > 0 Then
            MessageBox.Show("Debe sacar los vehiculos del sistema para cierre")
        Else

            VALIDAR_CIERRE.ShowDialog()
        End If
    End Sub

    Private Sub CheckBox19_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox19.CheckedChanged
        If CheckBox19.Checked = True Then
            CheckBox19.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub TextBox8_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox8.KeyPress

        If (Char.IsDigit(e.KeyChar)) Then

            e.Handled = False

        ElseIf (Char.IsControl(e.KeyChar)) Then

            e.Handled = False

        Else

            e.Handled = True

        End If
    End Sub

    Private Sub CheckBox15_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox15.CheckedChanged
        If CheckBox15.Checked = True Then
            CheckBox15.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub CheckBox16_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox16.CheckedChanged
        If CheckBox16.Checked = True Then
            CheckBox16.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub Label23_Click(sender As Object, e As EventArgs) Handles Label23.Click

    End Sub

    Private Sub Label37_Click(sender As Object, e As EventArgs) Handles Label37.Click



    End Sub



    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click


        Dim Queryw As String



        Try
                If varconex.State = ConnectionState.Open Then varconex.Close()
                varconex.Open()
            Queryw = "update ingreso_vehiculos set operario='" & Label37.Text & "',servicio='" & TextBox10.Text & "'  where Factura='" & Label16.Text & "'"
            Dim cmd2 As MySqlCommand = New MySqlCommand(Queryw, varconex)
            cmd2.ExecuteNonQuery()

            varconex.Close()
            varconex.Close()


            Catch ex As Exception
                MsgBox("fallo de actualización", vbExclamation, "Atención      SKYNET")


            End Try

        _dtsdatos.Reset()
        consulta_datos()
        TextBox3.Text = ""

    End Sub


    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        MessageBox.Show("hola")
    End Sub
End Class
