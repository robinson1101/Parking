Public Class class_datos
    Private Factura As Integer
    Private _placa As String
    Private _placas As String
    Private _marca As String
    Private _color As String
    Private _hora_ingreso As String
    Private _tipo As String
    Private _hora_salida As String
    Private _liquidado As String
    Private _liquidadov As String
    Private _tiempo As String
    Private _total As String
    Private _servicio As String
    Private _telefono As String
    Private _nombre_cliente As String
    Private _cliente As String
    Private _cedula As String
    Private _tarifa As String
    Private _documento As String
    Private _operario As String
    ' Private _comision_vendedor As String


    Public Property placa() As String
        Get
            Return _placa
        End Get

        Set(ByVal value As String)
            _placa = value

        End Set
    End Property
    Public Property tarifa() As String
        Get
            Return _tarifa
        End Get

        Set(ByVal value As String)
            _tarifa = value

        End Set
    End Property



    Public Property marca() As String
        Get
            Return _marca
        End Get

        Set(ByVal value As String)
            _marca = value

        End Set
    End Property
    Public Property color() As String
        Get
            Return _color
        End Get

        Set(ByVal value As String)
            _color = value

        End Set
    End Property

    Public Property cliente() As String
        Get
            Return _cliente
        End Get

        Set(ByVal value As String)
            _cliente = value

        End Set
    End Property
    Public Property liquidado() As String
        Get
            Return _liquidado
        End Get

        Set(ByVal value As String)
            _liquidado = value

        End Set
    End Property

    Public Property liquidadov() As String
        Get
            Return _liquidadov
        End Get

        Set(ByVal value As String)
            _liquidadov = value

        End Set
    End Property


    Public Property placas() As String
        Get
            Return _placas
        End Get

        Set(ByVal value As String)
            _placas = value

        End Set
    End Property
    Public Property documento() As String
        Get
            Return _documento
        End Get

        Set(ByVal value As String)
            _documento = value

        End Set
    End Property
    Public Property servicio() As String
        Get
            Return _servicio
        End Get

        Set(ByVal value As String)
            _servicio = value

        End Set
    End Property

    Public Property hora_ingreso() As String
        Get
            Return _hora_ingreso
        End Get

        Set(ByVal value As String)
            _hora_ingreso = value

        End Set
    End Property

    Public Property tipo() As String
        Get
            Return _tipo
        End Get

        Set(ByVal value As String)
            _tipo = value

        End Set
    End Property

    Public Property hora_salida() As String
        Get
            Return _hora_salida
        End Get

        Set(ByVal value As String)
            _hora_salida = value

        End Set
    End Property

    Public Property tiempo() As String
        Get
            Return _tiempo
        End Get

        Set(ByVal value As String)
            _tiempo = value

        End Set
    End Property
    Public Property total() As String
        Get
            Return _total
        End Get

        Set(ByVal value As String)
            _total = value

        End Set
    End Property

    'nombre_cliente,cedula,telefono,operario

    Public Property nombre_cliente() As String
        Get
            Return _nombre_cliente
        End Get

        Set(ByVal value As String)
            _nombre_cliente = value

        End Set
    End Property
    Public Property cedula() As String
        Get
            Return _cedula
        End Get

        Set(ByVal value As String)
            _cedula = value

        End Set
    End Property

    Public Property telefono() As String
        Get
            Return _telefono
        End Get

        Set(ByVal value As String)
            _telefono = value

        End Set
    End Property
    Public Property operario() As String
        Get
            Return _operario
        End Get

        Set(ByVal value As String)
            _operario = value

        End Set
    End Property
    'Public Property comision_vendedor() As String
    '    Get
    '        Return _comision_Vendedor
    '    End Get

    '    Set(ByVal value As String)
    '        _comision_vendedor = value

    '    End Set
    'End Property


End Class
