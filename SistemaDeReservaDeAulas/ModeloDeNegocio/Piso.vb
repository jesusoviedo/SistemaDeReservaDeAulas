Imports ModeloDeNegocio.Util

Public Class Piso
    Private id_piso As Integer
    Private descripcion As String

    'propiedades 
    Public Property pId_piso As Integer
        Get
            Return id_piso
        End Get
        Set(value As Integer)
            id_piso = value
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
    Public Sub InsertarPiso()
        Try
            gDatos.Ejecutar("SpInsertarPiso", Me.descripcion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarPiso()
        Try
            gDatos.Ejecutar("SpActualizarPiso", Me.descripcion, Me.id_piso)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarPiso()
        Try
            gDatos.Ejecutar("SpEliminarPiso", Me.id_piso)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarPiso() As DataTable
        Try
            Dim dtPiso As New DataTable
            dtPiso = gDatos.TraerDataTable("SpConsultarPiso", 0)
            Return dtPiso
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarPiso(vId_piso As Integer) As Piso
        Try
            Dim dtPiso As New DataTable
            dtPiso = gDatos.TraerDataTable("SpConsultarPiso", vId_piso)
            If dtPiso.Rows.Count > 0 Then
                Dim vPiso As New Piso
                With vPiso
                    .id_piso = dtPiso.Rows(0).Item("id_piso")
                    .descripcion = dtPiso.Rows(0).Item("descripcion")
                End With
                Return vPiso
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
