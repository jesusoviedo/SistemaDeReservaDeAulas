Imports ModeloDeNegocio.Util

Public Class Insumo

    Private id_insumo As Integer
    Private descripcion As String
    Private id_tip_insumo As Integer

    'propiedades 
    Public Property pId_insumo As Integer
        Get
            Return id_insumo
        End Get
        Set(value As Integer)
            id_insumo = value
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

    Public Property pId_tip_insumo As Integer
        Get
            Return id_tip_insumo
        End Get
        Set(value As Integer)
            id_tip_insumo = value
        End Set
    End Property

    'metodos
    Public Sub InsertarInsumo()
        Try
            gDatos.Ejecutar("SpInsertarInsumo", Me.descripcion, Me.id_tip_insumo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarInsumo()
        Try
            gDatos.Ejecutar("SpActualizarInsumo", Me.descripcion, Me.id_tip_insumo, Me.id_insumo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarInsumo()
        Try
            gDatos.Ejecutar("SpEliminarInsumo", Me.id_insumo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarInsumo() As DataTable
        Try
            Dim dtInsumo As New DataTable
            dtInsumo = gDatos.TraerDataTable("SpConsultarInsumo", 0)
            Return dtInsumo
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarInsumo(vId_insumo As Integer) As Insumo
        Try
            Dim dtInsumo As New DataTable
            dtInsumo = gDatos.TraerDataTable("SpConsultarInsumo", vId_insumo)
            If dtInsumo.Rows.Count > 0 Then
                Dim vInsumo As New Insumo
                With vInsumo
                    .id_insumo = dtInsumo.Rows(0).Item("id_insumo")
                    .descripcion = dtInsumo.Rows(0).Item("descripcion")
                    .id_tip_insumo = dtInsumo.Rows(0).Item("id_tip_insumo")
                End With
                Return vInsumo
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
