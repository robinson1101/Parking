﻿Imports System.Configuration
Imports MySql.Data.MySqlClient

Public Class VALIDAR_REPORTE_ADMIN

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
        Dim conexion As New MySqlConnection(cadena)
        Dim usuario As String
        Dim contraseña As String
        usuario = ""
        contraseña = ""
        Dim cmd2 As New MySqlCommand("SELECT user,clave from usuarios where user='" & TextBox1.Text & "' and clave='" & TextBox2.Text & "'", conexion)
        Try
            Dim lectura2 As MySqlDataReader
            If Not conexion Is Nothing Then conexion.Close()
            conexion.Open()
            lectura2 = cmd2.ExecuteReader
            If lectura2.Read() Then
                usuario = lectura2(0)
                contraseña = lectura2(1)
            End If
            conexion.Close()

            If ((TextBox1.Text = usuario) And (TextBox2.Text = contraseña) And (TextBox1.Text <> "" And TextBox2.Text <> "")) Then
                TextBox1.Text = ""
                TextBox2.Text = ""
                reportes_Admin.ShowDialog()
                Me.Close()

            Else
                MsgBox("DATOS DE SESION INCORRECTOS", MessageBoxIcon.Exclamation, "ACCESO DENEGADO")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try






    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        Me.Close()
    End Sub

    Private Sub VALIDAR_REPORTE_ADMIN_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class