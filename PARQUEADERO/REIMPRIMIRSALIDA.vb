
Imports System.Diagnostics
Imports System.IO
Imports MySql.Data
Imports MySql.Data.MySqlClient
Imports System.Configuration
Public Class REIMPRIMIRSALIDA
    Dim cadena As String = ConfigurationManager.ConnectionStrings("cadenaMysql").ToString
    Dim varconex, conexion2, conexion, conexion3 As New MySqlConnection(cadena)
    Dim imagenbarras As Image

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        consulta_datoscopia()
        _dtvdatoscopia.RowFilter = "placa like '%" & TextBox1.Text & "%'"
        Me.DataGridView1.DataSource = _dtvdatoscopia
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim tarifa As Integer

        Lbl_factura.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value
        Lbl_placa.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(1).Value
        Lbl_hora_ingreso.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(2).Value
        Lbl_horasalida.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(3).Value
        Lbl_tiempo.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(4).Value
        Lbl_total.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(5).Value
        Lbl_tarifa.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(6).Value
        ListBox1.Items.Add("          ")
        ListBox1.Items.Add("   PARQUEADERO Y AUTOLAVADO ")
        ListBox1.Items.Add("                      MOMPY")
        ListBox1.Items.Add("            CALLE 94 A N 13-71 ")
        ListBox1.Items.Add("            TEL:3102525836 ")
        ListBox1.Items.Add("            NIT:900364279-4 ")
        ListBox1.Items.Add("   ******************************* ")
        ListBox1.Items.Add(("   FACTURA:     ") & (Me.Lbl_factura.Text))
        ListBox1.Items.Add(("   PLACA:     ") & (Me.Lbl_placa.Text))
        ListBox1.Items.Add(("   INGRESO:") & (Me.Lbl_hora_ingreso.Text))
        ListBox1.Items.Add(("   SALIDA:") & (Me.Lbl_horasalida.Text))
        ListBox1.Items.Add(("   TIEMPO:") & (Me.Lbl_tiempo.Text))
        ListBox1.Items.Add(("   TOTAL:") & (Me.Lbl_total.Text))
        '  ListBox1.Items.Add(("   TOTAL SERVICIOS:  ") & (Me.Lbl_servicios.Text))
        ListBox1.Items.Add("    ******************************* ")
        ' ListBox1.Items.Add(("   TARIFA:") & (Me.Lbl_hora_ingreso.Text))
        If tarifa = 1 Then
            ListBox1.Items.Add("   TARIFA PLENA VEHICULOS: 20.000")
        End If
        If tarifa = 2 Then
            ListBox1.Items.Add("   TARIFA PLENA MOTOS: 10.000")
        End If
        ListBox1.Items.Add("    HORARIO TODOS LOS DIAS ")
        ListBox1.Items.Add("                  24 HORAS ")
        ListBox1.Items.Add("         Poliza de responsabilidad civil   ")
        ListBox1.Items.Add("21-02-101005750 vigencia Hasta 11/11/2019")
        ListBox1.Items.Add(" Resolución DIAN: 18762003223973    ")
        ListBox1.Items.Add("Tarifas carros $ 74 motos $67 bici $10   ")
        ListBox1.Items.Add("          Actividad Económica ICA 204 ")
        ListBox1.Items.Add("             TARIFA 9.66 X 1000")
        ListBox1.Items.Add("     COPIA DE FACTURA")

        ListBox1.Items.Add("     ")
        ListBox1.Items.Add("     ")
        'Try
        '    Dim alto As Single = 0

        '    alto = Convert.ToSingle(60)

        '    Dim bm As Bitmap = Nothing
        '    bm = Codigos.codigo128(Lbl_placa.Text, CheckBox1.Checked, alto)
        '    If Not IsNothing(bm) Then
        '        PictureBox1.Image = bm
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

        'imagenbarras = PictureBox1.Image
        'ListBox1.Items.(imagenbarras)
        PrintDocument1.Print()

        Me.Close()
        Form1.Show()
    End Sub

    Dim total, gasto1 As Integer
    Private Sub REIMPRIMIR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        _dtsdatoscopia.Reset()
    End Sub
    Private Sub PrintDocument1_PrintPage(ByVal sender As System.Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim fnt As New Font("Times New Roman", 10, FontStyle.Regular, GraphicsUnit.Point)
        Dim ListBoxItem As String = String.Empty
        For Each LBItem As String In ListBox1.Items
            ListBoxItem = ListBoxItem & vbCrLf & LBItem
        Next
        ListBoxItem = ListBoxItem.Substring(vbCrLf.Length)
        e.Graphics.DrawString(ListBoxItem, fnt, Brushes.Black, 0, 0)
        ' e.Graphics.DrawImage(PictureBox1.Image, 90, 220)
        e.HasMorePages = False



    End Sub

End Class