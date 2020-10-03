Public Class WELCOME
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        While Me.Opacity > 0

            Me.Opacity -= 0.000012

            If Me.Opacity = 0 Then

                Me.Hide()
                inicio.ShowDialog()


            End If


        End While

    End Sub

    Private Sub WELCOME_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
    End Sub
End Class