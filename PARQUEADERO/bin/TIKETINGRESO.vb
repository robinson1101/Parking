
Imports System.Diagnostics
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Public Class TIKETINGRESO
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion2, conexion, conexion3 As New MySqlConnection(cadena)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Add("   PARQUEADERO Y AUTOLAVADO ")
        ListBox1.Items.Add("                      MOMPY")
        ListBox1.Items.Add("            CALLE 94 A N 13-71 ")
        ListBox1.Items.Add("   ******************************* ")
        ListBox1.Items.Add(("   PLACA:     ") & (Form1.TextBox1.Text))
        ListBox1.Items.Add(("   INGRESO:") & (Form1.Label6.Text))
        ListBox1.Items.Add(("   TOTAL SERVICIOS:  ") & (Form1.TextBox10.Text))
        ListBox1.Items.Add("    ******************************* ")

        If Form1.Label39.Text = 1 Then

            ListBox1.Items.Add("    Tarifa plena 20.000 ")
        End If
        If Form1.Label39.Text = 2 Then

            ListBox1.Items.Add("    Tarifa plena 10.000 ")
        End If
        ListBox1.Items.Add("    HORARIO TODOS LOS DIAS ")
        ListBox1.Items.Add("                  24 HORAS ")
        ListBox1.Items.Add("     SIN RECIBO NO SE ENTREGA")
        ListBox1.Items.Add("              EL VEHICULO")
        ListBox1.Items.Add("     ")
        ListBox1.Items.Add("     ")
        Try
            Dim alto As Single = 0

            alto = Convert.ToSingle(60)

            Dim bm As Bitmap = Nothing
            bm = Codigos.codigo128(Form1.TextBox1.Text, CheckBox1.Checked, alto)
            If Not IsNothing(bm) Then
                PictureBox1.Image = bm
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        'imagenbarras = PictureBox1.Image
        'ListBox1.Items.Add(imagenbarras)
        PrintDocument1.Print()

        Me.Close()
        Form1.Show()
    End Sub

    Dim imagenbarras As Image
    Private Sub TIKETINGRESO_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button1.PerformClick()
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim fnt As New Font("Times New Roman", 10, FontStyle.Regular, GraphicsUnit.Point)
        Dim ListBoxItem As String = String.Empty
        For Each LBItem As String In ListBox1.Items
            ListBoxItem = ListBoxItem & vbCrLf & LBItem
        Next
        ListBoxItem = ListBoxItem.Substring(vbCrLf.Length)
        e.Graphics.DrawString(ListBoxItem, fnt, Brushes.Black, 0, 0)
        e.Graphics.DrawImage(PictureBox1.Image, 90, 230)
        e.HasMorePages = False



    End Sub
End Class