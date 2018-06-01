Imports ModeloDeNegocio.Util

Public Class TipoDocumento

    Private id_tipo_doc As Integer
    Private descripcion As String

    'propiedades 
    Public Property pId_tipo_doc As Integer
        Get
            Return id_tipo_doc
        End Get
        Set(value As Integer)
            id_tipo_doc = value
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
    Public Sub InsertarTipoDocumento()
        Try
            gDatos.Ejecutar("SpInsertarTipoDocumento", Me.descripcion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarTipoDocumento()
        Try
            gDatos.Ejecutar("SpActualizarTipoDocumento", Me.descripcion, Me.id_tipo_doc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarTipoDocumento()
        Try
            gDatos.Ejecutar("SpEliminarTipoDocumento", Me.id_tipo_doc)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarTipoDocumento() As DataTable
        Try
            Dim dtTipoDocumento As New DataTable
            dtTipoDocumento = gDatos.TraerDataTable("SpConsultarTipoDocumento", 0)
            Return dtTipoDocumento
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarTipoDocumento(vId_tipo_doc As Integer) As TipoDocumento
        Try
            Dim dtTipoDocumento As New DataTable
            dtTipoDocumento = gDatos.TraerDataTable("SpConsultarTipoDocumento", vId_tipo_doc)
            If dtTipoDocumento.Rows.Count > 0 Then
                Dim vTipoDocumento As New TipoDocumento
                With vTipoDocumento
                    .id_tipo_doc = dtTipoDocumento.Rows(0).Item("id_tipo_doc")
                    .descripcion = dtTipoDocumento.Rows(0).Item("descripcion")
                End With
                Return vTipoDocumento
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
