Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class Form_actualizar
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion, conexion2, conexion3, conexionIns As New MySqlConnection(cadena)

    Private Sub TextBoxNombreEmpresa_TextChanged(sender As Object, e As EventArgs) Handles TextBoxNombreEmpresa.TextChanged
        Form1.Label18.Text = TextBoxNombreEmpresa.Text
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        Dim insercion As String
        insercion = "INSERT INTO `title`(`id_Title`, `company_title`) VALUES (null,'" & TextBoxNombreEmpresa.Text & "')"


    End Sub
End Class