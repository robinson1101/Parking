<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3))
        Me.PrintForm1 = New Microsoft.VisualBasic.PowerPacks.Printing.PrintForm(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PrintForm1
        '
        Me.PrintForm1.DocumentName = "document"
        Me.PrintForm1.Form = Me
        Me.PrintForm1.PrintAction = System.Drawing.Printing.PrintAction.PrintToPrinter
        Me.PrintForm1.PrinterSettings = CType(resources.GetObject("PrintForm1.PrinterSettings"), System.Drawing.Printing.PrinterSettings)
        Me.PrintForm1.PrintFileName = Nothing
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 188)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 16)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "PLACA:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(71, 408)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 29)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "TOTAL:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(87, 448)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(21, 29)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "-"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(28, 448)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 29)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "$"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(82, 186)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(13, 18)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "-"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(22, 249)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(14, 20)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "-"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(27, 305)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(14, 20)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "-"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(17, 166)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(112, 13)
        Me.Label18.TabIndex = 32
        Me.Label18.Text = "Factura de Venta No. "
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(159, 166)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(10, 13)
        Me.Label19.TabIndex = 33
        Me.Label19.Text = "-"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(17, 562)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(206, 13)
        Me.Label21.TabIndex = 35
        Me.Label21.Text = "RESOLUCION  DIAN # 18762003223973"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(25, 210)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(191, 13)
        Me.Label23.TabIndex = 37
        Me.Label23.Text = "**********************************************"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(30, 269)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(195, 13)
        Me.Label24.TabIndex = 38
        Me.Label24.Text = "***********************************************"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(28, 334)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(183, 13)
        Me.Label25.TabIndex = 39
        Me.Label25.Text = "********************************************"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(18, 223)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(151, 24)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Hora de ingreso:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(21, 280)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(131, 24)
        Me.Label15.TabIndex = 29
        Me.Label15.Text = "Hora de salida"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(196, 344)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(45, 13)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Label17"
        Me.Label17.Visible = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(97, 20)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(67, 16)
        Me.Label29.TabIndex = 63
        Me.Label29.Text = " MOMPY"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(65, 94)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(128, 16)
        Me.Label20.TabIndex = 62
        Me.Label20.Text = " TEL: 3102525836"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(49, 78)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(144, 16)
        Me.Label1.TabIndex = 61
        Me.Label1.Text = "CALLE 94A N. 13-71"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(17, 137)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(215, 13)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "****************************************************"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(227, 16)
        Me.Label5.TabIndex = 59
        Me.Label5.Text = "PARQUEADERO  Y LAVADERO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 477)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(183, 13)
        Me.Label6.TabIndex = 64
        Me.Label6.Text = "********************************************"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(189, 424)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 65
        Me.Label7.Text = "Label7"
        Me.Label7.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(71, 503)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 16)
        Me.Label8.TabIndex = 68
        Me.Label8.Text = "24 HORAS"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(105, 490)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(111, 13)
        Me.Label10.TabIndex = 67
        Me.Label10.Text = "TODOS LOS DIAS"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(22, 490)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(72, 13)
        Me.Label22.TabIndex = 66
        Me.Label22.Text = "HORARIO :"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(65, 36)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(126, 16)
        Me.Label26.TabIndex = 69
        Me.Label26.Text = "NIT: 900364279-4"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(17, 367)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(100, 16)
        Me.Label27.TabIndex = 70
        Me.Label27.Text = "Base gravable:"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(124, 367)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 16)
        Me.Label28.TabIndex = 71
        Me.Label28.Text = "Label28"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(124, 389)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(56, 16)
        Me.Label30.TabIndex = 73
        Me.Label30.Text = "Label30"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(81, 389)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(32, 16)
        Me.Label31.TabIndex = 72
        Me.Label31.Text = "IVA:"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(17, 347)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(107, 16)
        Me.Label32.TabIndex = 74
        Me.Label32.Text = "Tiempo minutos:"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(126, 347)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(12, 16)
        Me.Label33.TabIndex = 75
        Me.Label33.Text = "-"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(17, 519)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(196, 13)
        Me.Label34.TabIndex = 76
        Me.Label34.Text = "POLIZA DE RESPONSABILIDAD CIVIL"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(58, 532)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(111, 13)
        Me.Label35.TabIndex = 77
        Me.Label35.Text = "No. 21-02-101005750"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(19, 545)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(202, 13)
        Me.Label36.TabIndex = 78
        Me.Label36.Text = "CON  VIGENCIA HASTA EL 11/11/2019"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(17, 575)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(0, 13)
        Me.Label37.TabIndex = 79
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(9, 588)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(245, 12)
        Me.Label38.TabIndex = 80
        Me.Label38.Text = "ACTIVIDAD ECONOMICA ICA 204  TARIFA 9.66 X 1000"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(12, 606)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(219, 13)
        Me.Label39.TabIndex = 81
        Me.Label39.Text = "Tarifas carros  $74   motos $67  bicicleta $10"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(65, 628)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(96, 13)
        Me.Label40.TabIndex = 82
        Me.Label40.Text = "Quejas y reclamos "
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(12, 650)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(206, 13)
        Me.Label41.TabIndex = 83
        Me.Label41.Text = "Superintendencia de Industria  y Comercio"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(73, 663)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(66, 13)
        Me.Label42.TabIndex = 84
        Me.Label42.Text = "tel. 5870000"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(30, 686)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(124, 13)
        Me.Label43.TabIndex = 85
        Me.Label43.Text = "Alcaldia Local Chapinero"
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(159, 686)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(70, 13)
        Me.Label44.TabIndex = 86
        Me.Label44.Text = "Tel. 3486200"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(266, 749)
        Me.Controls.Add(Me.Label44)
        Me.Controls.Add(Me.Label43)
        Me.Controls.Add(Me.Label42)
        Me.Controls.Add(Me.Label41)
        Me.Controls.Add(Me.Label40)
        Me.Controls.Add(Me.Label39)
        Me.Controls.Add(Me.Label38)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label29)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Form3"
        Me.Text = "Form3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PrintForm1 As PowerPacks.Printing.PrintForm
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label9 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label33 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Label44 As Label
    Friend WithEvents Label43 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents Label38 As Label
End Class
