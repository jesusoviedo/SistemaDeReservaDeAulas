Imports ModeloDeNegocio.Util

Public Class DetalleRol
    Private id_rol As Integer
    Private id_permiso As Integer

    Public Property pId_rol As Integer
        Get
            Return id_rol
        End Get
        Set(value As Integer)
            id_rol = value
        End Set
    End Property

    Public Property pId_permiso As Integer
        Get
            Return id_permiso
        End Get
        Set(value As Integer)
            id_permiso = value
        End Set
    End Property

    'metodos
    Public Sub InsertarDetalleRol()
        Try
            gDatos.Ejecutar("SpInsertarDetalleRol", Me.id_rol, Me.id_permiso)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarDetalleRol()
        Try
            gDatos.Ejecutar("SpActualizarDetalleRol", Me.id_rol, Me.id_permiso)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarDetalleRol()
        Try
            gDatos.Ejecutar("SpEliminarDetalleRol", Me.id_rol, Me.id_permiso)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarDetalleRol() As DataTable
        Try
            Dim dtDetalleRol As New DataTable
            dtDetalleRol = gDatos.TraerDataTable("SpConsultarDetalleRol", 0)
            Return dtDetalleRol
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarDetalleRol(vId_rol As Integer) As DetalleRol
        Try
            Dim dtDetalleRol As New DataTable
            dtDetalleRol = gDatos.TraerDataTable("SpConsultarDetalleRol", vId_rol)
            If dtDetalleRol.Rows.Count > 0 Then
                Dim vDetalleRol As New DetalleRol
                With vDetalleRol
                    .id_rol = dtDetalleRol.Rows(0).Item("id_rol")
                    .id_permiso = dtDetalleRol.Rows(0).Item("id_permiso")
                End With
                Return vDetalleRol
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

