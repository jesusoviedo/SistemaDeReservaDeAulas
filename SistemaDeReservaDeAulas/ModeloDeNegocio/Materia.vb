Imports ModeloDeNegocio.Util
Public Class Materia
    Private id_materia As Integer
    Private descripcion As String
    Private id_departamento As Integer

    Public Property pId_materia As Integer
        Get
            Return id_materia
        End Get
        Set(value As Integer)
            id_materia = value
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

    Public Property pId_departamento As Integer
        Get
            Return id_departamento
        End Get
        Set(value As Integer)
            id_departamento = value
        End Set
    End Property

    Public Sub InsertarMateria()
        Try
            gDatos.Ejecutar("SpInsertarMateria", Me.descripcion, Me.id_departamento)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarMateria()
        Try
            gDatos.Ejecutar("SpActualizarMateria", Me.descripcion, Me.id_departamento, Me.id_materia)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarMateria()
        Try
            gDatos.Ejecutar("SpEliminarMateria", Me.id_materia)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarMateria() As DataTable
        Try
            Dim dtMateria As New DataTable
            dtMateria = gDatos.TraerDataTable("SpConsultarMateria", 0)
            Return dtMateria
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarMateria(vId_materia As Integer) As Materia
        Try
            Dim dtMateria As New DataTable
            dtMateria = gDatos.TraerDataTable("SpConsultarmateria", vId_materia)
            If dtMateria.Rows.Count > 0 Then
                Dim vMateria As New Materia
                With vMateria
                    .id_materia = dtMateria.Rows(0).Item("id_materia")
                    .descripcion = dtMateria.Rows(0).Item("descripcion")
                    .id_departamento = dtMateria.Rows(0).Item("id_departamento")
                End With
                Return vMateria
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
