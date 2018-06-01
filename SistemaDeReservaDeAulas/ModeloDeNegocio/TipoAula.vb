Imports ModeloDeNegocio.Util

Public Class TipoAula

    Private id_tipo_aula As Integer
    Private descripcion As String

    'propiedades 
    Public Property pId_tipo_aula As Integer
        Get
            Return id_tipo_aula
        End Get
        Set(value As Integer)
            id_tipo_aula = value
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
    Public Sub InsertarTipoAula()
        Try
            gDatos.Ejecutar("SpInsertarTipoAula", Me.descripcion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarTipoAula()
        Try
            gDatos.Ejecutar("SpActualizarTipoAula", Me.descripcion, Me.id_tipo_aula)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarTipoAula()
        Try
            gDatos.Ejecutar("SpEliminarTipoAula", Me.id_tipo_aula)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarTipoAula() As DataTable
        Try
            Dim dtTipoAula As New DataTable
            dtTipoAula = gDatos.TraerDataTable("SpConsultarTipoAula", 0)
            Return dtTipoAula
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarTipoAula(vId_tipo_aula As Integer) As TipoAula
        Try
            Dim dtTipoAula As New DataTable
            dtTipoAula = gDatos.TraerDataTable("SpConsultarTipoAula", vId_tipo_aula)
            If dtTipoAula.Rows.Count > 0 Then
                Dim vTipoAula As New TipoAula
                With vTipoAula
                    .id_tipo_aula = dtTipoAula.Rows(0).Item("id_tipo_aula")
                    .descripcion = dtTipoAula.Rows(0).Item("descripcion")
                End With
                Return vTipoAula
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
