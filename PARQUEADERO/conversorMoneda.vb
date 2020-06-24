Public Class conversorMoneda
    Public Function ajustar_precio(ByVal cadena As String) As String

        Dim Str As String = "0"
        Dim suma As Integer = 0

        If cadena.Length >= 2 Then
            Str = cadena.Substring(cadena.Length - 2)
        ElseIf cadena.Length = 1 Then
            Str = cadena.Substring(cadena.Length - 1)
        End If

        If Val(Str) > 0 And Val(Str) <= 24 Then
            suma = Val(cadena) - Val(Str)
            Str = suma
        ElseIf Val(Str) > 24 And Val(Str) <= 74 Then
            suma = 50 - Val(Str)
            Str = Val(cadena) + suma
        ElseIf Val(Str) >= 75 And Val(Str) <= 100 Then
            suma = 100 - Val(Str)
            Str = Val(cadena) + suma
        ElseIf Val(Str) = 0 Then
            Str = cadena
        End If

        Return Str
    End Function
End Class
