Imports ModeloDeNegocio.Util

Public Class Rol
    Private id_rol As Integer
    Private nombre_rol As String

    Public Property pId_rol As Integer
        Get
            Return id_rol
        End Get
        Set(value As Integer)
            id_rol = value
        End Set
    End Property

    Public Property pNombre_rol As String
        Get
            Return nombre_rol
        End Get
        Set(value As String)
            nombre_rol = value
        End Set
    End Property

    'metodos
    Public Sub InsertarRol()
        Try
            gDatos.Ejecutar("SpInsertarRol", Me.nombre_rol)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarRol()
        Try
            gDatos.Ejecutar("SpActualizarRol", Me.nombre_rol, Me.id_rol)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarRol()
        Try
            gDatos.Ejecutar("SpEliminarRol", Me.id_rol)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarRol() As DataTable
        Try
            Dim dtRol As New DataTable
            dtRol = gDatos.TraerDataTable("SpConsultarRol", 0)
            Return dtRol
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarRol(vId_rol As Integer) As Rol
        Try
            Dim dtRol As New DataTable
            dtRol = gDatos.TraerDataTable("SpConsultarRol", vId_rol)
            If dtRol.Rows.Count > 0 Then
                Dim vRol As New Rol
                With vRol
                    .id_rol = dtRol.Rows(0).Item("id_rol")
                    .nombre_rol = dtRol.Rows(0).Item("nombre_rol")
                End With
                Return vRol
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
