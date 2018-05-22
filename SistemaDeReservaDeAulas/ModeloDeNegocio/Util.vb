Imports AccesoDatos.ReservaAula.Datos

Public Class Util
    Public Shared gDatos As gDatos

    Public Shared Function inicializaSesion(ByVal vsNombreServidor As String, ByVal vsBaseDatos As String, ByVal vUsuario As String, ByVal vPassword As String) As Boolean
        Try
            gDatos = New DatosSQLServer(vsNombreServidor, vsBaseDatos, vUsuario, vPassword)
            If gDatos.Autenticar() Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw New ApplicationException(ex.Message)
            Return False
        End Try


    End Function
End Class
