Public Class VALIDAR_REPORTE_ADMIN
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        reportes_Admin.ShowDialog()
    End Sub
End Class