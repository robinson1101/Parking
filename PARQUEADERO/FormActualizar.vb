Imports System.Configuration
Imports System.IO
Imports MySql
Imports MySql.Data.MySqlClient

Public Class Form_actualizar
    Dim _adaptador As New MySqlDataAdapter
    Dim conversorMoneda As New conversorMoneda
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconez As New MySqlConnection(cadena)
    Private Sub _TextChanged(sender As Object, e As EventArgs) Handles TextBoxNombreEmpresa.TextChanged

    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click

        If TextBoxNombreEmpresa.Text <> "" Then


            conexion_global()
            _adaptador.InsertCommand = New MySqlCommand("update title set company_title=@empresa")
            _adaptador.InsertCommand.Parameters.Add("@empresa", MySqlDbType.VarChar, 50).Value = TextBoxNombreEmpresa.Text
            _conexion.Open()
            _adaptador.InsertCommand.Connection = _conexion
            _adaptador.InsertCommand.ExecuteNonQuery()

            Form1.Label18.Text = TextBoxNombreEmpresa.Text

            MsgBox("NOMBRE MODIFICADO CORRECTAMENTE")
            Me.Close()
        Else
            MsgBox("PORFAVOR INGRESE UN VALOR VALIDO")
        End If

    End Sub
    Private Sub ButtonNombreEmp_Click_1(sender As Object, e As EventArgs) Handles ButtonNombreEmp.Click
        PanelTarifas.Visible = False
        PanelOperarios.Visible = False
        PanelTitulo.Visible = True
        TextBoxNombreEmpresa.Focus()
        PanelServicios.Visible = False
        PictureBox1.Visible = False
        PanelDescuento.Visible = False
    End Sub

    Private Sub ButtonDos_Click(sender As Object, e As EventArgs) Handles ButtonDos.Click
        tablaServicios()
        PanelOperarios.Visible = False
        PanelTarifas.Visible = False
        PanelTitulo.Visible = False
        PanelServicios.Visible = True
        PictureBox1.Visible = False
        PanelDescuento.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PanelTarifas.Visible = False
        PanelOperarios.Visible = False
        PanelTitulo.Visible = False
        PanelServicios.Visible = False
        PictureBox1.Visible = True
        PanelDescuento.Visible = False
    End Sub

    Private Sub ButtonTarifas_Click(sender As Object, e As EventArgs) Handles ButtonTarifas.Click
        tablaTarifas()
        PanelOperarios.Visible = False
        PanelTarifas.Visible = True
        PanelTitulo.Visible = False
        PanelServicios.Visible = False
        PictureBox1.Visible = False
        PanelDescuento.Visible = False
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        If ComboBox3.SelectedItem = "" Then
            MsgBox("DEBE SELECCIONAR EL ITEM CORRESPONDIENTE A VEHICULO", vbExclamation, "")
        ElseIf TextBox2.Text.Trim = "" Then
            MsgBox("DEBE INGRESAR EL VALOR DE LA TARIFA", vbExclamation, "")
        Else
            Try
                conexion_global()
                _adaptador.InsertCommand = New MySqlCommand("update tipo set TARIFA=@TARIFA where tipo='" & ComboBox3.SelectedItem & "'")
                _adaptador.InsertCommand.Parameters.Add("@TARIFA", MySqlDbType.VarChar, 10).Value = TextBox2.Text.Trim
                _conexion.Open()
                _adaptador.InsertCommand.Connection = _conexion
                _adaptador.InsertCommand.ExecuteNonQuery()
                _conexion.Close()
                TextBox2.Text = ""
                tablaTarifas()
                MsgBox("ACTUALIZACIÓN REALIZADA CORRECTAMENTE", vbInformation, "")


                'CONSULTA PARA OBTENER LOS COSTES DE LA TARIFA PARA DESPUES ENVIARLOS A EL FORM COSTOS  
                Dim _adaptador2 As MySqlDataReader
                Dim contador As Integer
                Dim cmd1 As New MySqlCommand("select TARIFA from tipo", _conexion)
                _conexion.Open()
                _adaptador2 = cmd1.ExecuteReader()
                contador = 0
                While _adaptador2.Read
                    If contador = 0 Then
                        costos.otro.Text = _adaptador2(0)
                    End If
                    If contador = 1 Then
                        costos.carro.Text = _adaptador2(0)
                    End If
                    If contador = 2 Then
                        costos.moto.Text = _adaptador2(0)
                    End If
                    If contador = 3 Then
                        costos.bicicleta.Text = _adaptador2(0)
                    End If

                    contador = contador + 1
                End While

                _conexion.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tablaDescuentos()
        PanelOperarios.Visible = False
        PanelTarifas.Visible = False
        PanelTitulo.Visible = False
        PanelServicios.Visible = False
        PictureBox1.Visible = False
        PanelDescuento.Visible = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click


        If ComboBox1.SelectedItem = "" Or ComboBox2.SelectedItem = "" Then
            MsgBox("DEBE SELECCIONAR LOS ITEMS CORRESPONDIENTES A SERVICIO Y VEHICULO", vbExclamation, "")
        ElseIf TextBox1.Text.Trim = "" Then
            MsgBox("DEBE INGRESAR EL VALOR DEL SERVICIO", vbExclamation, "")
        Else
            Try
                Dim _adaptador1 As MySqlDataReader
                conexion_global()
                _adaptador.InsertCommand = New MySqlCommand("update servicios set valor=@valor where tipo_servicio='" & ComboBox1.SelectedItem & " " & ComboBox2.SelectedItem & "'")
                _adaptador.InsertCommand.Parameters.Add("@valor", MySqlDbType.VarChar, 10).Value = conversorMoneda.ajustar_precio(TextBox1.Text.Trim)
                _conexion.Open()
                _adaptador.InsertCommand.Connection = _conexion
                _adaptador.InsertCommand.ExecuteNonQuery()
                _conexion.Close()
                TextBox1.Text = ""
                tablaServicios()
                MsgBox("ACTUALIZACIÓN REALIZADA CORRECTAMENTE", vbInformation, "")

                'CONSULTA PARA OBTENER LOS COSTES DE LOS SERVICIOS PARA DESPUES ENVIARLOS A EL FORM COSTOS
                conexion_global()
                Dim cmd As New MySqlCommand("select valor from servicios", _conexion)
                _conexion.Open()
                _adaptador1 = cmd.ExecuteReader()

                Dim contador As Integer = 1
                While _adaptador1.Read
                    If contador = 1 Then
                        costos.enjuagueAutomovil.Text = _adaptador1(0)
                    End If
                    If contador = 2 Then
                        costos.enjuagueCamioneta.Text = _adaptador1(0)
                    End If
                    If contador = 3 Then
                        costos.enjuagueMoto.Text = _adaptador1(0)
                    End If
                    If contador = 4 Then
                        costos.enjuagueOtro.Text = _adaptador1(0)
                    End If
                    If contador = 5 Then
                        costos.generalAutomovil.Text = _adaptador1(0)
                    End If
                    If contador = 6 Then
                        costos.generalCamioneta.Text = _adaptador1(0)
                    End If
                    If contador = 7 Then
                        costos.generalMoto.Text = _adaptador1(0)
                    End If
                    If contador = 8 Then
                        costos.generalOtro.Text = _adaptador1(0)
                    End If
                    If contador = 9 Then
                        costos.tapiceriaAutomovil.Text = _adaptador1(0)
                    End If
                    If contador = 10 Then
                        costos.tapiceriaCamioneta.Text = _adaptador1(0)
                    End If
                    If contador = 11 Then
                        costos.tapiceriaOtro.Text = _adaptador1(0)
                    End If
                    If contador = 12 Then
                        costos.motorAutomovil.Text = _adaptador1(0)
                    End If
                    If contador = 13 Then
                        costos.motorCamioneta.Text = _adaptador1(0)
                    End If
                    If contador = 14 Then
                        costos.motorOtro.Text = _adaptador1(0)
                    End If

                    contador = contador + 1

                End While
                _conexion.Close()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        End If


    End Sub

    Public Sub tablaServicios()
        Dim _dtsservicios As New DataSet

        Try
            conexion_global()
            _adaptador.SelectCommand = New MySqlCommand("select id_servicio as 'ID',tipo_servicio as 'TIPO',valor as 'SERVICIO' from servicios", _conexion)
            _adaptador.Fill(_dtsservicios)
            DataGridViewServicios.DataSource = _dtsservicios.Tables(0)
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()
            _conexion.Close()

            DataGridViewServicios.Columns(1).Width = 207
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            cerrar()
        End Try
    End Sub
    Public Sub tablaTarifas()
        Dim _dtsservicios As New DataSet

        Try
            conexion_global()
            _adaptador.SelectCommand = New MySqlCommand("select id_tipo as 'ID',tipo as 'TIPO',TARIFA from tipo", _conexion)
            _adaptador.Fill(_dtsservicios)
            DataGridViewTarifas.DataSource = _dtsservicios.Tables(0)
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()
            _conexion.Close()


        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        Finally
            cerrar()
        End Try
    End Sub

    Private Sub ButtonOperarios_Click(sender As Object, e As EventArgs) Handles ButtonOperarios.Click
        PanelOperarios.Visible = True
        PanelTarifas.Visible = False
        PanelTitulo.Visible = False
        PanelServicios.Visible = False
        PictureBox1.Visible = False
        tablaOperarios()
        PanelDescuento.Visible = False
    End Sub

    Private Sub Form_actualizar_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub ButtonGuardar_Click(sender As Object, e As EventArgs) Handles ButtonGuardar.Click

        Try
            conexion_global()
            _adaptador.InsertCommand = New MySqlCommand("insert into operarios (nombre,documento,direccion,telefono) values (@nombre,@documento,@direccion,@telefono)", _conexion)
            _adaptador.InsertCommand.Parameters.Add("@nombre", MySqlDbType.VarChar, 50).Value = TextBoxNombre.Text.Trim
            _adaptador.InsertCommand.Parameters.Add("@documento", MySqlDbType.VarChar, 50).Value = TextBoxDocumento.Text.Trim
            _adaptador.InsertCommand.Parameters.Add("@direccion", MySqlDbType.VarChar, 50).Value = TextBoxDireccion.Text.Trim
            _adaptador.InsertCommand.Parameters.Add("@telefono", MySqlDbType.VarChar, 50).Value = TextBoxTelefono.Text.Trim


            _conexion.Open()
            _adaptador.InsertCommand.Connection = _conexion
            _adaptador.InsertCommand.ExecuteNonQuery()
            _conexion.Close()
            tablaOperarios()

            _dtsoperario.Reset()
            consulta_datos1()
            Form1.ComboBox1.DataSource = _dtsoperario.Tables("operarios")
            Form1.ComboBox1.DisplayMember = "nombre"

            MsgBox("OPERARIO CREADO CORRECTAMENTE", vbInformation, "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Public Sub tablaOperarios()
        Dim _dtsoperarios As New DataSet

        Try
            conexion_global()
            _adaptador.SelectCommand = New MySqlCommand("select id_operario as 'ID',nombre as 'NOMBRE',documento as 'DOCUMENTO',direccion as 'DIRECCION',telefono as 'TELEFONO' from operarios", _conexion)
            _adaptador.Fill(_dtsoperarios)
            DataGridViewOperarios.DataSource = _dtsoperarios.Tables(0)
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()
            _conexion.Close()

            DataGridViewOperarios.Columns(0).Width = 30
            DataGridViewOperarios.Columns(1).Width = 120
            DataGridViewOperarios.Columns(4).Width = 80
            DataGridViewOperarios.Columns(2).Width = 80
            DataGridViewOperarios.Columns(3).Width = 127
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles radioPorcentaje.CheckedChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles txtDescuento.TextChanged

    End Sub

    Private Sub btnGuradarDto_Click(sender As Object, e As EventArgs) Handles btnGuradarDto.Click
        Dim dto As String = "0"
        Dim tipo As String = "0"
        Dim siNo As String = "0"
        Dim aplicable As String = "0"

        If checkHabilitar.Checked = True Then
            siNo = "SI"
        ElseIf checkHabilitar.Checked = False Then
            siNo = "NO"
        End If

        If checkParqueadero.Checked = True And checkServicios.Checked = False Then
            aplicable = "P"
        ElseIf checkParqueadero.Checked = False And checkServicios.Checked = True Then
            aplicable = "S"
        ElseIf checkParqueadero.Checked = True And checkServicios.Checked = True Then
            aplicable = "P+S"
        End If

        If radioPesos.Checked = True Then
            tipo = "$"
        ElseIf radioPorcentaje.Checked = True Then
            tipo = "%"
        End If

        If Val(txtDescuento.Text.Trim) <> 0 Then
            If Val(txtDescuento.Text.Trim) > 100 And radioPorcentaje.Checked = True Then
                MsgBox("INTENTE NUEVAMENTE CON UN VALOR DIFERENTE", vbInformation, "")
            Else
                dto = txtDescuento.Text.Trim
            End If
        Else
            MsgBox("INTENTE NUEVAMENTE CON UN VALOR DIFERENTE", vbInformation, "")
        End If

        conexion_global()
        _adaptador.InsertCommand = New MySqlCommand("update title set descuento=@descuento,tipoDescuento=@tipoDescuento,aplicable=@aplicable,activo=@activo")
        _adaptador.InsertCommand.Parameters.Add("@descuento", MySqlDbType.VarChar, 10).Value = dto
        _adaptador.InsertCommand.Parameters.Add("@tipoDescuento", MySqlDbType.VarChar, 10).Value = tipo
        _adaptador.InsertCommand.Parameters.Add("@activo", MySqlDbType.VarChar, 10).Value = siNo
        _adaptador.InsertCommand.Parameters.Add("@aplicable", MySqlDbType.VarChar, 10).Value = aplicable

        _conexion.Open()
        _adaptador.InsertCommand.Connection = _conexion
        _adaptador.InsertCommand.ExecuteNonQuery()
        _conexion.Close()

        checkHabilitar.Checked = False
        checkParqueadero.Checked = False
        checkServicios.Checked = False
        radioPesos.Checked = False
        radioPorcentaje.Checked = False
        txtDescuento.Text = ""

        tablaDescuentos()
        MsgBox("ACTUALIZACIÓN REALIZADA CORRECTAMENTE", vbInformation, "")
    End Sub
    Public Sub tablaDescuentos()
        Dim _dtsdescuento As New DataSet

        Try
            conexion_global()
            _adaptador.SelectCommand = New MySqlCommand("select descuento as 'DESCUENTO',tipoDescuento as 'TIPO',aplicable as 'APLICABLE',activo as 'ACTIVO' from title", _conexion)
            _adaptador.Fill(_dtsdescuento)
            DataGridViewDescuento.DataSource = _dtsdescuento.Tables(0)
            _conexion.Open()
            _adaptador.SelectCommand.Connection = _conexion
            _adaptador.SelectCommand.ExecuteNonQuery()
            _conexion.Close()

            'DataGridViewOperarios.Columns(0).Width = 30
            DataGridViewDescuento.Columns(1).Width = 55
            'DataGridViewOperarios.Columns(4).Width = 80
            DataGridViewDescuento.Columns(2).Width = 75
            'DataGridViewOperarios.Columns(3).Width = 127
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)

        End Try
    End Sub

    Private Sub LinkLabelFactura_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabelFactura.LinkClicked
        ELIMINAR.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        If TextBoxClave.Text.Trim = "contrasena" Then
            Label1.Visible = True
            TextBoxNombreEmpresa.Visible = True
            ButtonNuevo.Visible = True
            LinkLabelFactura.Visible = True
            LinkLabel1.Visible = True
            Button6.Visible = True

            Label14.Visible = False
            TextBoxClave.Visible = False
            Button5.Visible = False

        Else
            MsgBox("La contraseña es incorrecta")
        End If

    End Sub

    Private Sub Form_actualizar_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Me.Dispose()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked

        abrir_imagen()

    End Sub

    Private Sub abrir_imagen()
        Dim filename As String
        Dim openfiler As New OpenFileDialog
        'Definiendo propiedades al openfiledialog
        With openfiler
            'directorio inicial
            .InitialDirectory = "C:\"
            'archivos que se pueden abrir
            .Filter = "Archivos de imágen(*.jpg)|*.jpg|All Files (*.*)|*.*"
            'indice del archivo de lectura por defecto
            .FilterIndex = 1
            'restaurar el directorio al cerrar el dialogo
            .RestoreDirectory = True
        End With
        '
        'Evalua si el usuario hace click en el boton abrir
        If openfiler.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            'Obteniendo la ruta completa del archivo xml
            filename = openfiler.FileName
            Try
                Form1.PictureBoxImg.Image = Image.FromFile(filename)
                LinkLabel1.Text = openfiler.FileName
            Catch ex As Exception
                MsgBox("NO FUE POSIBLE CARGAR LA IMAGEN", vbInformation, "")
            End Try


        Else
            openfiler.Dispose()
            LinkLabel1.Text = "Cargar imagen"
            Form1.PictureBoxImg.Image = Nothing
        End If
    End Sub

    'convertir imagen a binario
    Private Function Imagen_Bytes(ByVal Imagen As Image) As Byte()
        'si hay imagen
        If Not Imagen Is Nothing Then
            'variable de datos binarios en stream(flujo)
            Dim Bin As New MemoryStream
            'convertir a bytes
            Imagen.Save(Bin, Imaging.ImageFormat.Jpeg)
            'retorna binario
            Return Bin.GetBuffer
        Else
            Return Nothing
        End If
    End Function

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim img As Byte() = Nothing
        img = Imagen_Bytes(Form1.PictureBoxImg.Image)


        Try
            varconez.Open()
            Dim cmd As New MySqlCommand("update title set img=?imagen", varconez)
            cmd.Parameters.AddWithValue("?imagen", img)


            cmd.ExecuteNonQuery()
            varconez.Close()
            MsgBox("Imagen guardada correctamente")
        Catch ex As Exception
            MsgBox("SICOVEH ", ex.ToString)
        End Try

    End Sub
End Class