Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class inicio
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim conexion As New MySqlConnection(cadena)

    Private Sub Button1_Click(sender As Object, e As EventArgs)

        Dim usuario As String
        Dim contraseña As String
        usuario = ""
        contraseña = ""

        If ((TextBox1.Text = usuario) And (TextBox2.Text = contraseña)) Then
            TextBox1.Text = ""
            TextBox2.Text = ""
            Form1.Show()


        Else
            MessageBox.Show(" los datos ingresados no son correctos")
            TextBox1.Text = ""
            TextBox2.Text = ""
        End If
        Me.Hide()
    End Sub

    Private Sub inicio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label3.Text = consulta_empresa()
        Form1.ITEMUSUARIO.BackColor = Color.AliceBlue
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBoxIngreso_Click(sender As Object, e As EventArgs) Handles PictureBoxIngreso.Click
        Dim usuario As String
        Dim contraseña As String
        usuario = ""
        contraseña = ""
        Dim cmd2 As New MySqlCommand("SELECT user,clave,nombre from usuarios where user='" & TextBox1.Text & "' and clave='" & TextBox2.Text & "'", conexion)
        Try
            Dim lectura2 As MySqlDataReader
            If Not conexion Is Nothing Then conexion.Close()
            conexion.Open()
            lectura2 = cmd2.ExecuteReader
            If lectura2.Read() Then
                Form1.ITEMUSUARIO.Text = lectura2(2)
                usuario = lectura2(0)
                contraseña = lectura2(1)
            End If
            conexion.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim _adaptador1 As MySqlDataReader
        Dim _adaptador2 As MySqlDataReader
        Dim _adaptador3 As MySqlDataReader


        If ((TextBox1.Text = usuario) And (TextBox2.Text = contraseña) And (TextBox1.Text <> "") And (TextBox2.Text <> "")) Then
            TextBox1.Text = ""
            TextBox2.Text = ""

            Form1.Show()
            Me.Hide()

        Else
            MessageBox.Show(" los datos ingresados no son correctos")
            TextBox1.Text = ""
            TextBox2.Text = ""


        End If



        Try

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

            'CONSULTA PARA OBTENER LOS COSTES DE LA TARIFA PARA DESPUES ENVIARLOS A EL FORM COSTOS  

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


            'CARGAR VALOR DE PORCENTAJE DEL OPERARIO
            Dim cmd3 As New MySqlCommand("select porcentajeOperario from title", _conexion)
            _conexion.Open()
            _adaptador3 = cmd3.ExecuteReader()

            If _adaptador3.Read Then
                costos.lblPorcentajeOperario.Text = _adaptador3(0)
            End If

            _conexion.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try


    End Sub
    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        'codigo para ejecutar el evento del enter
        If e.KeyCode = Keys.Enter Then
            PictureBoxIngreso_Click(sender, e)
        End If
    End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            PictureBoxIngreso_Click(sender, e)
        End If
    End Sub
End Class