Public Class inicio
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

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

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class