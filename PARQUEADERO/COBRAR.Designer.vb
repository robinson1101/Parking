<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class COBRAR
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
        Me.Lbl_total = New System.Windows.Forms.Label()
        Me.Lbl_tiempo = New System.Windows.Forms.Label()
        Me.Lbl_factura = New System.Windows.Forms.Label()
        Me.Lbl_horasalida = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Lbl_tarifa = New System.Windows.Forms.Label()
        Me.Lbl_servicios = New System.Windows.Forms.Label()
        Me.Lbl_hora_ingreso = New System.Windows.Forms.Label()
        Me.Lbl_placa = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Lbl_total
        '
        Me.Lbl_total.AutoSize = True
        Me.Lbl_total.Location = New System.Drawing.Point(369, 394)
        Me.Lbl_total.Name = "Lbl_total"
        Me.Lbl_total.Size = New System.Drawing.Size(27, 13)
        Me.Lbl_total.TabIndex = 34
        Me.Lbl_total.Text = "total"
        '
        'Lbl_tiempo
        '
        Me.Lbl_tiempo.AutoSize = True
        Me.Lbl_tiempo.Location = New System.Drawing.Point(369, 378)
        Me.Lbl_tiempo.Name = "Lbl_tiempo"
        Me.Lbl_tiempo.Size = New System.Drawing.Size(38, 13)
        Me.Lbl_tiempo.TabIndex = 33
        Me.Lbl_tiempo.Text = "tiempo"
        '
        'Lbl_factura
        '
        Me.Lbl_factura.AutoSize = True
        Me.Lbl_factura.Location = New System.Drawing.Point(369, 357)
        Me.Lbl_factura.Name = "Lbl_factura"
        Me.Lbl_factura.Size = New System.Drawing.Size(40, 13)
        Me.Lbl_factura.TabIndex = 32
        Me.Lbl_factura.Text = "factura"
        '
        'Lbl_horasalida
        '
        Me.Lbl_horasalida.AutoSize = True
        Me.Lbl_horasalida.Location = New System.Drawing.Point(368, 336)
        Me.Lbl_horasalida.Name = "Lbl_horasalida"
        Me.Lbl_horasalida.Size = New System.Drawing.Size(58, 13)
        Me.Lbl_horasalida.TabIndex = 31
        Me.Lbl_horasalida.Text = "hora salida"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(25, 423)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 29
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Lbl_tarifa
        '
        Me.Lbl_tarifa.AutoSize = True
        Me.Lbl_tarifa.Location = New System.Drawing.Point(368, 407)
        Me.Lbl_tarifa.Name = "Lbl_tarifa"
        Me.Lbl_tarifa.Size = New System.Drawing.Size(59, 13)
        Me.Lbl_tarifa.TabIndex = 28
        Me.Lbl_tarifa.Text = "tarifa plena"
        '
        'Lbl_servicios
        '
        Me.Lbl_servicios.AutoSize = True
        Me.Lbl_servicios.Location = New System.Drawing.Point(368, 317)
        Me.Lbl_servicios.Name = "Lbl_servicios"
        Me.Lbl_servicios.Size = New System.Drawing.Size(48, 13)
        Me.Lbl_servicios.TabIndex = 27
        Me.Lbl_servicios.Text = "servicios"
        '
        'Lbl_hora_ingreso
        '
        Me.Lbl_hora_ingreso.AutoSize = True
        Me.Lbl_hora_ingreso.Location = New System.Drawing.Point(368, 303)
        Me.Lbl_hora_ingreso.Name = "Lbl_hora_ingreso"
        Me.Lbl_hora_ingreso.Size = New System.Drawing.Size(65, 13)
        Me.Lbl_hora_ingreso.TabIndex = 26
        Me.Lbl_hora_ingreso.Text = "hora ingreso"
        '
        'Lbl_placa
        '
        Me.Lbl_placa.AutoSize = True
        Me.Lbl_placa.Location = New System.Drawing.Point(368, 288)
        Me.Lbl_placa.Name = "Lbl_placa"
        Me.Lbl_placa.Size = New System.Drawing.Size(41, 13)
        Me.Lbl_placa.TabIndex = 25
        Me.Lbl_placa.Text = "PLACA"
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(501, 13)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(275, 381)
        Me.ListBox1.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(218, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "IMPRIMIR SALIDA"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(24, 104)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(455, 170)
        Me.DataGridView1.TabIndex = 21
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(163, 42)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(147, 20)
        Me.TextBox1.TabIndex = 20
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(46, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 13)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "INGRESE PLACA"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(396, 40)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "AUTO"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(245, 317)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 13)
        Me.Label9.TabIndex = 35
        Me.Label9.Text = "Label9"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(245, 347)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(45, 13)
        Me.Label30.TabIndex = 36
        Me.Label30.Text = "Label30"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(245, 394)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(45, 13)
        Me.Label33.TabIndex = 37
        Me.Label33.Text = "Label33"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(251, 369)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(45, 13)
        Me.Label28.TabIndex = 38
        Me.Label28.Text = "Label28"
        '
        'COBRAR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Lbl_total)
        Me.Controls.Add(Me.Lbl_tiempo)
        Me.Controls.Add(Me.Lbl_factura)
        Me.Controls.Add(Me.Lbl_horasalida)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Lbl_tarifa)
        Me.Controls.Add(Me.Lbl_servicios)
        Me.Controls.Add(Me.Lbl_hora_ingreso)
        Me.Controls.Add(Me.Lbl_placa)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "COBRAR"
        Me.Text = "COBRAR"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Lbl_total As Label
    Friend WithEvents Lbl_tiempo As Label
    Friend WithEvents Lbl_factura As Label
    Friend WithEvents Lbl_horasalida As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Lbl_tarifa As Label
    Friend WithEvents Lbl_servicios As Label
    Friend WithEvents Lbl_hora_ingreso As Label
    Friend WithEvents Lbl_placa As Label
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Label9 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label28 As Label
End Class
