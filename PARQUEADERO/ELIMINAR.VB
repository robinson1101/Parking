Imports System.Configuration
Imports System.Drawing.Printing
Imports MySql.Data.MySqlClient

Public Class ELIMINAR
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim conexion2 As New MySqlConnection(cadena)

    Public style1 As FontStyle = FontStyle.Regular
    Public style2 As FontStyle = FontStyle.Regular
    Public style3 As FontStyle = FontStyle.Regular
    Public style4 As FontStyle = FontStyle.Regular
    Public style5 As FontStyle = FontStyle.Regular
    Public style6 As FontStyle = FontStyle.Regular
    Public style7 As FontStyle = FontStyle.Regular
    Public style8 As FontStyle = FontStyle.Regular
    Public style9 As FontStyle = FontStyle.Regular
    Public style10 As FontStyle = FontStyle.Regular
    Public style11 As FontStyle = FontStyle.Regular
    Public style12 As FontStyle = FontStyle.Regular



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        validar_styles()



        ELIMINAR2.Show()
        ' ejemplo simple para imprimir en .NET
        ' Usamos una clase del tipo PrintDocument
        Dim printDoc As New PrintDocument
        ' asignamos el método de evento para cada página a imprimir





        AddHandler printDoc.PrintPage, AddressOf ELIMINAR2.PrintDocument1_PrintPage
        ' indicamos que queremos imprimir
        'impresion.CreatePrintPreviewControl(printDoc)
        printDoc.Print()
    End Sub




    Sub validar_styles()
        If RadioButton1.Checked = True Then
            style1 = FontStyle.Regular
        ElseIf RadioButton2.Checked = True Then
            style1 = FontStyle.Bold
        End If

        If RadioButton3.Checked = True Then
            style2 = FontStyle.Regular
        ElseIf RadioButton4.Checked = True Then
            style2 = FontStyle.Bold
        End If

        If RadioButton5.Checked = True Then
            style3 = FontStyle.Regular
        ElseIf RadioButton6.Checked = True Then
            style3 = FontStyle.Bold
        End If

        If RadioButton7.Checked = True Then
            style4 = FontStyle.Regular
        ElseIf RadioButton8.Checked = True Then
            style4 = FontStyle.Bold
        End If

        If RadioButton9.Checked = True Then
            style5 = FontStyle.Regular
        ElseIf RadioButton10.Checked = True Then
            style5 = FontStyle.Bold
        End If

        If RadioButton11.Checked = True Then
            style6 = FontStyle.Regular
        ElseIf RadioButton12.Checked = True Then
            style6 = FontStyle.Bold
        End If

        If RadioButton13.Checked = True Then
            style7 = FontStyle.Regular
        ElseIf RadioButton14.Checked = True Then
            style7 = FontStyle.Bold
        End If

        If RadioButton15.Checked = True Then
            style8 = FontStyle.Regular
        ElseIf RadioButton16.Checked = True Then
            style8 = FontStyle.Bold
        End If

        If RadioButton17.Checked = True Then
            style9 = FontStyle.Regular
        ElseIf RadioButton18.Checked = True Then
            style9 = FontStyle.Bold
        End If

        If RadioButton19.Checked = True Then
            style10 = FontStyle.Regular
        ElseIf RadioButton20.Checked = True Then
            style10 = FontStyle.Bold
        End If

        If RadioButton21.Checked = True Then
            style11 = FontStyle.Regular
        ElseIf RadioButton22.Checked = True Then
            style11 = FontStyle.Bold
        End If

        If RadioButton23.Checked = True Then
            style12 = FontStyle.Regular
        ElseIf RadioButton24.Checked = True Then
            style12 = FontStyle.Bold
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        validar_styles()
        ELIMINAR2.Show()
        ' ejemplo simple para imprimir en .NET
        ' Usamos una clase del tipo PrintDocument
        Dim printDoc As New PrintDocument
        ' asignamos el método de evento para cada página a imprimir





        AddHandler printDoc.PrintPage, AddressOf ELIMINAR2.PrintDocument1_PrintPage
        ' indicamos que queremos imprimir
        ELIMINAR2.CreatePrintPreviewControl(printDoc)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim estilo1 As String = "Regular"
        Dim estilo2 As String = "Regular"
        Dim estilo3 As String = "Regular"
        Dim estilo4 As String = "Regular"
        Dim estilo5 As String = "Regular"
        Dim estilo6 As String = "Regular"
        Dim estilo7 As String = "Regular"
        Dim estilo8 As String = "Regular"
        Dim estilo9 As String = "Regular"
        Dim estilo10 As String = "Regular"
        Dim estilo11 As String = "Regular"
        Dim estilo12 As String = "Regular"


        If RadioButton1.Checked = True Then
            estilo1 = "Regular"
        ElseIf RadioButton2.Checked = True Then
            estilo1 = "Bold"
        End If

        If RadioButton3.Checked = True Then
            estilo2 = "Regular"
        ElseIf RadioButton4.Checked = True Then
            estilo2 = "Bold"
        End If

        If RadioButton5.Checked = True Then
            estilo3 = "Regular"
        ElseIf RadioButton6.Checked = True Then
            estilo3 = "Bold"
        End If

        If RadioButton7.Checked = True Then
            estilo4 = "Regular"
        ElseIf RadioButton8.Checked = True Then
            estilo4 = "Bold"
        End If

        If RadioButton9.Checked = True Then
            estilo5 = "Regular"
        ElseIf RadioButton10.Checked = True Then
            estilo5 = "Bold"
        End If

        If RadioButton11.Checked = True Then
            estilo6 = "Regular"
        ElseIf RadioButton12.Checked = True Then
            estilo6 = "Bold"
        End If

        If RadioButton13.Checked = True Then
            estilo7 = "Regular"
        ElseIf RadioButton14.Checked = True Then
            estilo7 = "Bold"
        End If

        If RadioButton15.Checked = True Then
            estilo8 = "Regular"
        ElseIf RadioButton16.Checked = True Then
            estilo8 = "Bold"
        End If

        If RadioButton17.Checked = True Then
            estilo9 = "Regular"
        ElseIf RadioButton18.Checked = True Then
            estilo9 = "Bold"
        End If

        If RadioButton19.Checked = True Then
            estilo10 = "Regular"
        ElseIf RadioButton20.Checked = True Then
            estilo10 = "Bold"
        End If

        If RadioButton21.Checked = True Then
            estilo11 = "Regular"
        ElseIf RadioButton22.Checked = True Then
            estilo11 = "Bold"
        End If

        If RadioButton23.Checked = True Then
            estilo12 = "Regular"
        ElseIf RadioButton24.Checked = True Then
            estilo12 = "Bold"
        End If



        Try
            Dim cmd1 As New MySqlCommand("update config_factura set texto='" & TextBox1.Text.Trim & "',tamaño=" & NumericUpDown1.Value & ",tipo='" & estilo1 & "' where id_config=1 ", conexion2)
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            cmd1.ExecuteReader()

            conexion2.Close()


            Dim cmd2 As New MySqlCommand("update config_factura set texto='" & TextBox2.Text.Trim & "',tamaño=" & NumericUpDown2.Value & ",tipo='" & estilo2 & "' where id_config=2 ", conexion2)
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            cmd2.ExecuteReader()

            conexion2.Close()


            Dim cmd3 As New MySqlCommand("update config_factura set texto='" & TextBox3.Text.Trim & "',tamaño=" & NumericUpDown3.Value & ",tipo='" & estilo3 & "' where id_config=3 ", conexion2)
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            cmd3.ExecuteReader()

            conexion2.Close()

            Dim cmd4 As New MySqlCommand("update config_factura set texto='" & TextBox4.Text.Trim & "',tamaño=" & NumericUpDown4.Value & ",tipo='" & estilo4 & "' where id_config=4 ", conexion2)
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            cmd4.ExecuteReader()

            conexion2.Close()

            Dim cmd5 As New MySqlCommand("update config_factura set texto='" & TextBox5.Text.Trim & "',tamaño=" & NumericUpDown5.Value & ",tipo='" & estilo5 & "' where id_config=5 ", conexion2)
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            cmd5.ExecuteReader()

            conexion2.Close()

            Dim cmd6 As New MySqlCommand("update config_factura set texto='" & TextBox6.Text.Trim & "',tamaño=" & NumericUpDown6.Value & ",tipo='" & estilo6 & "' where id_config=6 ", conexion2)
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            cmd6.ExecuteReader()

            conexion2.Close()

            Dim cmd7 As New MySqlCommand("update config_factura set texto='" & TextBox7.Text.Trim & "',tamaño=" & NumericUpDown7.Value & ",tipo='" & estilo7 & "' where id_config=7 ", conexion2)
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            cmd7.ExecuteReader()

            conexion2.Close()

            Dim cmd8 As New MySqlCommand("update config_factura set texto='" & TextBox8.Text.Trim & "',tamaño=" & NumericUpDown8.Value & ",tipo='" & estilo8 & "' where id_config=8 ", conexion2)
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            cmd8.ExecuteReader()

            conexion2.Close()

            Dim cmd9 As New MySqlCommand("update config_factura set texto='" & TextBox9.Text.Trim & "',tamaño=" & NumericUpDown9.Value & ",tipo='" & estilo9 & "' where id_config=9 ", conexion2)
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            cmd9.ExecuteReader()

            conexion2.Close()

            Dim cmd10 As New MySqlCommand("update config_factura set texto='" & TextBox10.Text.Trim & "',tamaño=" & NumericUpDown10.Value & ",tipo='" & estilo10 & "' where id_config=10 ", conexion2)
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            cmd10.ExecuteReader()

            conexion2.Close()

            Dim cmd11 As New MySqlCommand("update config_factura set texto='" & TextBox11.Text.Trim & "',tamaño=" & NumericUpDown11.Value & ",tipo='" & estilo11 & "' where id_config=11 ", conexion2)
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            cmd11.ExecuteReader()

            conexion2.Close()

            Dim cmd12 As New MySqlCommand("update config_factura set texto='" & TextBox12.Text.Trim & "',tamaño=" & NumericUpDown12.Value & ",tipo='" & estilo12 & "' where id_config=12 ", conexion2)
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            cmd12.ExecuteReader()

            conexion2.Close()



            MsgBox("CONFIGURACION GUARDADA EXITOSAMENTE")

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ELIMINAR_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class