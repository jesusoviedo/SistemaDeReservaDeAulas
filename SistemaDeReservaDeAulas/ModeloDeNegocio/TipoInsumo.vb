Imports ModeloDeNegocio.Util

Public Class TipoInsumo

    Private id_tip_insumo As Integer
    Private descripcion As String

    'propiedades 
    Public Property pId_tip_insumo As Integer
        Get
            Return id_tip_insumo
        End Get
        Set(value As Integer)
            id_tip_insumo = value
        End Set
    End Property

    Public Property pDescripcion As String
        Get
            Return descripcion
        End Get
        Set(value As String)
            descripcion = value
        End Set
    End Property

    'metodos
    Public Sub InsertarTipoInsumo()
        Try
            gDatos.Ejecutar("SpInsertarTipoInsumo", Me.descripcion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarTipoInsumo()
        Try
            gDatos.Ejecutar("SpActualizarTipoInsumo", Me.descripcion, Me.id_tip_insumo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarTipoInsumo()
        Try
            gDatos.Ejecutar("SpEliminarTipoInsumo", Me.id_tip_insumo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarTipoInsumo() As DataTable
        Try
            Dim dtTipoInsumo As New DataTable
            dtTipoInsumo = gDatos.TraerDataTable("SpConsultarTipoInsumo", 0)
            Return dtTipoInsumo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarTipoInsumo(vId_tip_insumo As Integer) As TipoInsumo
        Try
            Dim dtTipoInsumo As New DataTable
            dtTipoInsumo = gDatos.TraerDataTable("SpConsultarTipoInsumo", vId_tip_insumo)
            If dtTipoInsumo.Rows.Count > 0 Then
                Dim vTipoInsumo As New TipoInsumo
                With vTipoInsumo
                    .id_tip_insumo = dtTipoInsumo.Rows(0).Item("id_tip_insumo")
                    .descripcion = dtTipoInsumo.Rows(0).Item("descripcion")
                End With
                Return vTipoInsumo
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
