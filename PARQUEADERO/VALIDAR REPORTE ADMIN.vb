Public Class VALIDAR_REPORTE_ADMIN
    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Hide()
        reportes_Admin.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim usuario As String
        Dim contraseña As String
        usuario = ""
        contraseña = ""

        If ((TextBox1.Text = usuario) And (TextBox2.Text = contraseña)) Then

            reportes_Admin.ShowDialog()
        Else
            MessageBox.Show(" los datos ingresados no son correctos")
        End If
    End Sub
End Class