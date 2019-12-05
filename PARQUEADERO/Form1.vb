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

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        ComboBox1.DataSource = _dtsoperario.Tables("operarios")
        ComboBox1.DisplayMember = "nombre"
        Try
            conexion1.ConnectionString = "server =localhost; user=root;password =cielito;database=parqueadero"
            conexion1.Open()


        Catch ex As Exception

        End Try

    End Sub

    Private Sub GroupBox2_Enter(sender As Object, e As EventArgs)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim conexion As New class_int
        Dim datos As New class_datos
        Dim tipo_vehiculo As String = 0
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
            otro = TextBox8.Text
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

        ' TARIFA 0 ES NORMAL, TARIFA 
        Dim tarifas As String
        tarifas = 0
        If CheckBox25.Checked = True And tipo_vehiculo = 1 Then
            tarifas = 1
            'TARIFA PLENA PARA VEHICULOS
        End If
        If CheckBox25.Checked = True And tipo_vehiculo = 2 Then
            tarifas = 2
            'TARIFA PLENA PARA MOTOS
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
            _dtsdatos.Reset()
            consulta_datos()
            DataGridView1.DataSource = _dtvdatos
            ' MessageBox.Show("datos guardados")
        Else
            ' MessageBox.Show("no se realizo registro")
        End If
        TIKETINGRESO.Show()
        'Form2.Show()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox8.Clear()
        ComboBox1.ResetText()
        TextBox9.Clear()
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
        Dim costo As String
        Dim vehi As String
        Dim servicio As Double
        costo = 0
        vehi = 0
        servicio = Val(Label4.Text)
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
        Dim tarifa As Integer
        tarifa = Label24.Text


        '''''''FORM1 LABEL 9 TIENEN EL TIEMPO DE PARQUEO''''''informacion otro formulario
        '''''''LABEL 9 FORM 3 ESTE TIENE LA INFO DEL SERVICIO'''''
        Dim TIEMPO As Integer
        Dim servicios_lavado As Integer
        servicios_lavado = Label4.Text
        If servicios_lavado > 15999 And minutos < 59 And tarifa <> 1 And tarifa <> 2 Then
            totalfact = Val(Label4.Text)

        ElseIf servicios_lavado > 15999 And minutos > 60 And tarifa <> 1 And tarifa <> 2 Then
            TIEMPO = Val(minutos) - 60
            'ingresar  tarifa para carro y moto en otro condicional
            If Label13.Text = 1 Then
                costo = 74 * TIEMPO
                vehi = "CARRO"

            End If
            If Label13.Text = 2 Then
                costo = 67 * TIEMPO
                vehi = "MOTO"
            End If

        ElseIf servicio > 120000 Then
            costo = 0
        ElseIf Label13.Text = 1 Then
            costo = 74 * Label9.Text
            vehi = "CARRO"

        ElseIf Label13.Text = 2 Then
            costo = 67 * Label9.Text
            vehi = "MOTO"
        ElseIf Label13.Text = 3 Then
            costo = 10 * Label9.Text
            vehi = "BICI"

        End If
        If tarifa = 1 Then
            costo = 20000
        End If
        If tarifa = 2 Then
            costo = 10000
        End If

        totalfact = servicio + costo

        totalfact = CStr(Math.Round(totalfact / 50) * 50)
        Label34.Text = totalfact

        Label17.Text = costo
        Label14.Text = servicio
        Label15.Text = vehi

        If conexion.actualizardatos(datos) Then
            _dtsdatos.Reset()

            consulta_datos()
            DataGridView1.DataSource = _dtvdatos
            ' MessageBox.Show("datos guardados")
        Else
            ' MessageBox.Show("no se realizo registro")
        End If
        COBRAR.Show()
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

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If Label38.Text > 0 Then
            MessageBox.Show("Debe sacar los vehiculos del sistema para cierre")
        Else

            VALIDAR_CIERRE.Show()
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Start()

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label19_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Close()
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
                Dim general_motor As Integer
                Dim tapizado As Integer

                Dim servicio As Double

                If ((TextBox1.Text = "")) Then
                    Button1.Enabled = False
                Else
                    Button1.Enabled = True
                End If

                If CheckBox22.Checked = True Then
                    If CheckBox7.Checked = True Then
                        juagada = 18000
                    Else
                        juagada = 0
                    End If
                    If CheckBox8.Checked = True Then
                        general = 35000
                    Else
                        general = 0
                    End If
                    If CheckBox9.Checked = True Then
                        general_motor = 45000
                    Else
                        general_motor = 0
                    End If
                    If CheckBox11.Checked = True Then
                        tapizado = 120000
                    Else
                        tapizado = 0
                    End If

                End If

                If CheckBox23.Checked = True Then
                    If CheckBox7.Checked = True Then
                        juagada = 24000
                    Else
                        juagada = 0
                    End If
                    If CheckBox8.Checked = True Then
                        general = 40000
                    Else
                        general = 0
                    End If
                    If CheckBox9.Checked = True Then
                        general_motor = 55000
                    Else
                        general_motor = 0
                    End If
                    If CheckBox11.Checked = True Then
                        tapizado = 130000
                    Else
                        tapizado = 0
                    End If

                End If

                If CheckBox2.Checked = True Then
                    If CheckBox7.Checked = True Then
                        juagada = 16000
                    Else
                        juagada = 0
                    End If


                End If


                Dim otro As Double
                If TextBox8.Text = "" Then
                    otro = 0
                Else
                    otro = TextBox8.Text
                End If


                Dim tipo_vehiculo As Integer = 1

                servicio = juagada + general + general_motor + tapizado + otro
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

                If CheckBox7.Checked = False Then
                    CheckBox7.BackColor = Color.PowderBlue
                End If
                If CheckBox8.Checked = False Then
                    CheckBox8.BackColor = Color.PowderBlue
                End If
                If CheckBox9.Checked = False Then
                    CheckBox9.BackColor = Color.PowderBlue
                End If
                If CheckBox10.Checked = False Then
                    CheckBox10.BackColor = Color.PowderBlue
                End If
                If CheckBox4.Checked = False Then
                    CheckBox4.BackColor = Color.PowderBlue
                End If
                If CheckBox11.Checked = False Then
                    CheckBox11.BackColor = Color.PowderBlue
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
    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown

        If e.KeyCode = Keys.Enter Then
            Button2.PerformClick()

            'ToolStripButton1.PerformClick()
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
            CheckBox7.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged

        If CheckBox8.Checked = True Then
            CheckBox8.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged

        If CheckBox9.Checked = True Then
            CheckBox9.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub CheckBox10_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox10.CheckedChanged

        If CheckBox10.Checked = True Then
            CheckBox10.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub CheckBox11_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox11.CheckedChanged

        If CheckBox11.Checked = True Then
            CheckBox11.BackColor = Color.DarkRed
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Form6.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
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
            ' MessageBox.Show("no se realizo registro")
        End If



    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Form7.Show()

    End Sub

    Private Sub Label19_Click_1(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub TextBox10_TextChanged(sender As Object, e As EventArgs) Handles TextBox10.TextChanged



    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick

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

    Private Sub CheckBox19_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox19.CheckedChanged
        If CheckBox19.Checked = True Then
            CheckBox19.BackColor = Color.DarkRed
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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        REIMPRIMIR.Show()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        REIMPRIMIRSALIDA.Show()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        CIERRE_CAJA2.Show()
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        REPORTES.Show()
        Me.Hide()
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label25_Click(sender As Object, e As EventArgs) Handles Label25.Click

    End Sub

    Private Sub Label29_Click(sender As Object, e As EventArgs) Handles Label29.Click

    End Sub

    Private Sub Label30_Click(sender As Object, e As EventArgs) Handles Label30.Click

    End Sub

    Private Sub Label31_Click(sender As Object, e As EventArgs) Handles Label31.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Label32_Click(sender As Object, e As EventArgs) Handles Label32.Click

    End Sub

    Private Sub GroupBox4_Enter(sender As Object, e As EventArgs) Handles GroupBox4.Enter

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs)

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

    Private Sub DataGridView1_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellEnter

    End Sub

    Private Sub DataGridView1_Enter(sender As Object, e As EventArgs) Handles DataGridView1.Enter

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        MessageBox.Show("hola")
    End Sub
End Class
