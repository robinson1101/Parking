﻿Imports System.Configuration
Imports MySql
Imports MySql.Data.MySqlClient

Public Class Form_actualizar
    Dim _adaptador As New MySqlDataAdapter

    Private Sub _TextChanged(sender As Object, e As EventArgs) Handles TextBoxNombreEmpresa.TextChanged
        Form1.Label18.Text = TextBoxNombreEmpresa.Text
    End Sub

    Private Sub ButtonNuevo_Click(sender As Object, e As EventArgs) Handles ButtonNuevo.Click
        If TextBoxNombreEmpresa.Text <> "" Then


            conexion_global()
            _adaptador.InsertCommand = New MySqlCommand("update title set company_title=@empresa")
            _adaptador.InsertCommand.Parameters.Add("@empresa", MySqlDbType.VarChar, 50).Value = TextBoxNombreEmpresa.Text
            _conexion.Open()
            _adaptador.InsertCommand.Connection = _conexion
            _adaptador.InsertCommand.ExecuteNonQuery()

            MsgBox("NOMBRE MODIFICADO CORRECTAMENTE")
            Me.Close()
        Else
            MsgBox("PORFAVOR INGRESE UN VALOR VALIDO")
        End If

    End Sub
    Private Sub ButtonNombreEmp_Click_1(sender As Object, e As EventArgs) Handles ButtonNombreEmp.Click
        PanelTarifas.Visible = False
        PanelTitulo.Visible = True
        TextBoxNombreEmpresa.Focus()
        PanelServicios.Visible = False
        PictureBox1.Visible = False
    End Sub

    Private Sub ButtonDos_Click(sender As Object, e As EventArgs) Handles ButtonDos.Click
        PanelTarifas.Visible = False
        PanelTitulo.Visible = False
        PanelServicios.Visible = True
        PictureBox1.Visible = False
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        PanelTarifas.Visible = False
        PanelTitulo.Visible = False
        PanelServicios.Visible = False
        PictureBox1.Visible = True
    End Sub

    Private Sub ButtonTarifas_Click(sender As Object, e As EventArgs) Handles ButtonTarifas.Click
        PanelTarifas.Visible = True
        PanelTitulo.Visible = False
        PanelServicios.Visible = False
        PictureBox1.Visible = False
    End Sub
End Class