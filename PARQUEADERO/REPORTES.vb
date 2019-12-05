Imports System.Diagnostics
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing
Imports System.Configuration
Public Class REPORTES
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion2, conexion, conexion3 As New MySqlConnection(cadena)
    Dim total, gasto1 As Integer

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        Form1.Show()
    End Sub

    Dim RawPrinterHelper As Object
    Dim strCurrency As String = ""
    Private Sub REPORTES_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        Label5.Text = DateTimePicker1.Text

        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy/MM/dd"

        Label6.Text = DateTimePicker1.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        Label5.Text = DateTimePicker1.Text

        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "yyyy/MM/dd"

        Label6.Text = DateTimePicker2.Text
        Dim query As String
        Try
            query = "select SUM(ingreso_vehiculos.total) AS totalvent FROM ingreso_vehiculos where ingreso_vehiculos.hora_ingreso between '" & Label5.Text & " 00:00:00' and  '" & Label6.Text & " 23:59:59'  "
            Dim cmdtotal As MySqlCommand = New MySqlCommand(query, conexion2)
            Dim lectura_total As MySqlDataReader
            If Not conexion2 Is Nothing Then conexion2.Close()
            conexion2.Open()
            lectura_total = cmdtotal.ExecuteReader
            If lectura_total.Read() Then
                Me.Label4.Text = lectura_total("totalvent")
                total = FormatNumber(lectura_total.Item("totalvent"))
            End If


        Catch ex As Exception
            MsgBox(ex.Message + ex.StackTrace)
        End Try
    End Sub
End Class