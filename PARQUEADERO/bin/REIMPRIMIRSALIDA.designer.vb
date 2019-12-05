<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class REIMPRIMIRSALIDA
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Lbl_placa = New System.Windows.Forms.Label()
        Me.Lbl_hora_ingreso = New System.Windows.Forms.Label()
        Me.Lbl_servicios = New System.Windows.Forms.Label()
        Me.Lbl_tarifa = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Lbl_horasalida = New System.Windows.Forms.Label()
        Me.Lbl_factura = New System.Windows.Forms.Label()
        Me.Lbl_tiempo = New System.Windows.Forms.Label()
        Me.Lbl_total = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(384, 38)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "BUSCAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(34, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "INGRESE PLACA"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(151, 40)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(147, 20)
        Me.TextBox1.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 102)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(455, 170)
        Me.DataGridView1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(206, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(209, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "REIMPRIMIR ENTRADA DE VEHICULOS"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(489, 11)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(275, 381)
        Me.ListBox1.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(134, 334)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 55)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "IMPRIMIR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'PrintDocument1
        '
        '
        'Lbl_placa
        '
        Me.Lbl_placa.AutoSize = True
        Me.Lbl_placa.Location = New System.Drawing.Point(356, 286)
        Me.Lbl_placa.Name = "Lbl_placa"
        Me.Lbl_placa.Size = New System.Drawing.Size(41, 13)
        Me.Lbl_placa.TabIndex = 7
        Me.Lbl_placa.Text = "PLACA"
        '
        'Lbl_hora_ingreso
        '
        Me.Lbl_hora_ingreso.AutoSize = True
        Me.Lbl_hora_ingreso.Location = New System.Drawing.Point(356, 302)
        Me.Lbl_hora_ingreso.Name = "Lbl_hora_ingreso"
        Me.Lbl_hora_ingreso.Size = New System.Drawing.Size(65, 13)
        Me.Lbl_hora_ingreso.TabIndex = 8
        Me.Lbl_hora_ingreso.Text = "hora ingreso"
        '
        'Lbl_servicios
        '
        Me.Lbl_servicios.AutoSize = True
        Me.Lbl_servicios.Location = New System.Drawing.Point(356, 315)
        Me.Lbl_servicios.Name = "Lbl_servicios"
        Me.Lbl_servicios.Size = New System.Drawing.Size(48, 13)
        Me.Lbl_servicios.TabIndex = 9
        Me.Lbl_servicios.Text = "servicios"
        '
        'Lbl_tarifa
        '
        Me.Lbl_tarifa.AutoSize = True
        Me.Lbl_tarifa.Location = New System.Drawing.Point(356, 405)
        Me.Lbl_tarifa.Name = "Lbl_tarifa"
        Me.Lbl_tarifa.Size = New System.Drawing.Size(59, 13)
        Me.Lbl_tarifa.TabIndex = 11
        Me.Lbl_tarifa.Text = "tarifa plena"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(13, 421)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(13, 334)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        '
        'Lbl_horasalida
        '
        Me.Lbl_horasalida.AutoSize = True
        Me.Lbl_horasalida.Location = New System.Drawing.Point(356, 334)
        Me.Lbl_horasalida.Name = "Lbl_horasalida"
        Me.Lbl_horasalida.Size = New System.Drawing.Size(58, 13)
        Me.Lbl_horasalida.TabIndex = 14
        Me.Lbl_horasalida.Text = "hora salida"
        '
        'Lbl_factura
        '
        Me.Lbl_factura.AutoSize = True
        Me.Lbl_factura.Location = New System.Drawing.Point(357, 355)
        Me.Lbl_factura.Name = "Lbl_factura"
        Me.Lbl_factura.Size = New System.Drawing.Size(40, 13)
        Me.Lbl_factura.TabIndex = 15
        Me.Lbl_factura.Text = "factura"
        '
        'Lbl_tiempo
        '
        Me.Lbl_tiempo.AutoSize = True
        Me.Lbl_tiempo.Location = New System.Drawing.Point(357, 376)
        Me.Lbl_tiempo.Name = "Lbl_tiempo"
        Me.Lbl_tiempo.Size = New System.Drawing.Size(38, 13)
        Me.Lbl_tiempo.TabIndex = 16
        Me.Lbl_tiempo.Text = "tiempo"
        '
        'Lbl_total
        '
        Me.Lbl_total.AutoSize = True
        Me.Lbl_total.Location = New System.Drawing.Point(357, 392)
        Me.Lbl_total.Name = "Lbl_total"
        Me.Lbl_total.Size = New System.Drawing.Size(27, 13)
        Me.Lbl_total.TabIndex = 17
        Me.Lbl_total.Text = "total"
        '
        'REIMPRIMIRSALIDA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Lbl_total)
        Me.Controls.Add(Me.Lbl_tiempo)
        Me.Controls.Add(Me.Lbl_factura)
        Me.Controls.Add(Me.Lbl_horasalida)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Lbl_tarifa)
        Me.Controls.Add(Me.Lbl_servicios)
        Me.Controls.Add(Me.Lbl_hora_ingreso)
        Me.Controls.Add(Me.Lbl_placa)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "REIMPRIMIRSALIDA"
        Me.Text = "REIMPRIMIRSALIDA"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Button2 As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Lbl_placa As Label
    Friend WithEvents Lbl_hora_ingreso As Label
    Friend WithEvents Lbl_servicios As Label
    Friend WithEvents Lbl_tarifa As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Lbl_horasalida As Label
    Friend WithEvents Lbl_factura As Label
    Friend WithEvents Lbl_tiempo As Label
    Friend WithEvents Lbl_total As Label
End Class
