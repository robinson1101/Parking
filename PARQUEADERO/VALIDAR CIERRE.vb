Public Class VALIDAR_CIERRE
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim usuario As String
        Dim contraseña As String
        usuario = ""
        contraseña = ""

        If ((TextBox1.Text = usuario) And (TextBox2.Text = contraseña)) Then
            Form4.Show()
            Close()
        Else
            MessageBox.Show(" los datos ingresados no son correctos")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.Show()
        Close()
    End Sub

    Private Sub VALIDAR_CIERRE_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class