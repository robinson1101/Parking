<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class REIMPRIMIR
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
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Lbl_placa = New System.Windows.Forms.Label()
        Me.Lbl_hora_ingreso = New System.Windows.Forms.Label()
        Me.Lbl_servicios = New System.Windows.Forms.Label()
        Me.Lbl_tarifa = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblFactura = New System.Windows.Forms.Label()
        Me.PrintPreviewControl1 = New System.Windows.Forms.PrintPreviewControl()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(275, 29)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "BUSCAR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "INGRESE PLACA"
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(122, 29)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(147, 20)
        Me.TextBox1.TabIndex = 2
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(13, 58)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(455, 170)
        Me.DataGridView1.TabIndex = 3
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(147, 294)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(108, 55)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "IMPRIMIR"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Lbl_placa
        '
        Me.Lbl_placa.AutoSize = True
        Me.Lbl_placa.Location = New System.Drawing.Point(50, 299)
        Me.Lbl_placa.Name = "Lbl_placa"
        Me.Lbl_placa.Size = New System.Drawing.Size(41, 13)
        Me.Lbl_placa.TabIndex = 7
        Me.Lbl_placa.Text = "PLACA"
        Me.Lbl_placa.Visible = False
        '
        'Lbl_hora_ingreso
        '
        Me.Lbl_hora_ingreso.AutoSize = True
        Me.Lbl_hora_ingreso.Location = New System.Drawing.Point(57, 315)
        Me.Lbl_hora_ingreso.Name = "Lbl_hora_ingreso"
        Me.Lbl_hora_ingreso.Size = New System.Drawing.Size(65, 13)
        Me.Lbl_hora_ingreso.TabIndex = 8
        Me.Lbl_hora_ingreso.Text = "hora ingreso"
        Me.Lbl_hora_ingreso.Visible = False
        '
        'Lbl_servicios
        '
        Me.Lbl_servicios.AutoSize = True
        Me.Lbl_servicios.Location = New System.Drawing.Point(50, 328)
        Me.Lbl_servicios.Name = "Lbl_servicios"
        Me.Lbl_servicios.Size = New System.Drawing.Size(48, 13)
        Me.Lbl_servicios.TabIndex = 9
        Me.Lbl_servicios.Text = "servicios"
        Me.Lbl_servicios.Visible = False
        '
        'Lbl_tarifa
        '
        Me.Lbl_tarifa.AutoSize = True
        Me.Lbl_tarifa.Location = New System.Drawing.Point(50, 343)
        Me.Lbl_tarifa.Name = "Lbl_tarifa"
        Me.Lbl_tarifa.Size = New System.Drawing.Size(59, 13)
        Me.Lbl_tarifa.TabIndex = 11
        Me.Lbl_tarifa.Text = "tarifa plena"
        Me.Lbl_tarifa.Visible = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(393, 299)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(81, 17)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        Me.CheckBox1.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(22, 233)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 50)
        Me.PictureBox1.TabIndex = 13
        Me.PictureBox1.TabStop = False
        Me.PictureBox1.Visible = False
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(270, 294)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(108, 55)
        Me.Button3.TabIndex = 14
        Me.Button3.Text = "CERRAR"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lblFactura
        '
        Me.lblFactura.AutoSize = True
        Me.lblFactura.Location = New System.Drawing.Point(195, 233)
        Me.lblFactura.Name = "lblFactura"
        Me.lblFactura.Size = New System.Drawing.Size(40, 13)
        Me.lblFactura.TabIndex = 15
        Me.lblFactura.Text = "factura"
        '
        'PrintPreviewControl1
        '
        Me.PrintPreviewControl1.AutoZoom = False
        Me.PrintPreviewControl1.Location = New System.Drawing.Point(491, 12)
        Me.PrintPreviewControl1.Name = "PrintPreviewControl1"
        Me.PrintPreviewControl1.Size = New System.Drawing.Size(297, 393)
        Me.PrintPreviewControl1.TabIndex = 16
        Me.PrintPreviewControl1.Zoom = 0.85R
        '
        'REIMPRIMIR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gray
        Me.ClientSize = New System.Drawing.Size(800, 425)
        Me.ControlBox = False
        Me.Controls.Add(Me.PrintPreviewControl1)
        Me.Controls.Add(Me.lblFactura)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Lbl_tarifa)
        Me.Controls.Add(Me.Lbl_servicios)
        Me.Controls.Add(Me.Lbl_hora_ingreso)
        Me.Controls.Add(Me.Lbl_placa)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "REIMPRIMIR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "REIMPRIMIR ENTRADA"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents Lbl_placa As Label
    Friend WithEvents Lbl_hora_ingreso As Label
    Friend WithEvents Lbl_servicios As Label
    Friend WithEvents Lbl_tarifa As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button3 As Button
    Friend WithEvents lblFactura As Label
    Friend WithEvents PrintPreviewControl1 As PrintPreviewControl
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
End Class
