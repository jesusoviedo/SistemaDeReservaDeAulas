Imports ModeloDeNegocio.Util

Public Class Permiso
    Private id_permiso As Integer
    Private nombre_permiso As String

    Public Property pId_permiso As Integer
        Get
            Return id_permiso
        End Get
        Set(value As Integer)
            id_permiso = value
        End Set
    End Property

    Public Property pNombre_permiso As String
        Get
            Return nombre_permiso
        End Get
        Set(value As String)
            nombre_permiso = value
        End Set
    End Property

    'metodos
    Public Sub InsertarPermiso()
        Try
            gDatos.Ejecutar("SpInsertarPermiso", Me.nombre_permiso)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarPermiso()
        Try
            gDatos.Ejecutar("SpActualizarPermiso", Me.nombre_permiso, Me.id_permiso)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarPermiso()
        Try
            gDatos.Ejecutar("SpEliminarPermiso", Me.id_permiso)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarPermiso() As DataTable
        Try
            Dim dtPermiso As New DataTable
            dtPermiso = gDatos.TraerDataTable("SpConsultarPermiso", 0)
            Return dtPermiso
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarPermiso(vId_permiso As Integer) As Permiso
        Try
            Dim dtPermiso As New DataTable
            dtPermiso = gDatos.TraerDataTable("SpConsultarPermiso", vId_permiso)
            If dtPermiso.Rows.Count > 0 Then
                Dim vPermiso As New Permiso
                With vPermiso
                    .id_permiso = dtPermiso.Rows(0).Item("id_permiso")
                    .nombre_permiso = dtPermiso.Rows(0).Item("nombre_permiso")
                End With
                Return vPermiso
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
