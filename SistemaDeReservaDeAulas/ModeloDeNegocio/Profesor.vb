Imports ModeloDeNegocio.Util
Public Class Profesor

    Private id_profesor As Integer
    Private id_persona As Integer

    Public Property pId_profesor As Integer
        Get
            Return id_profesor
        End Get
        Set(value As Integer)
            id_profesor = value
        End Set
    End Property

    Public Property pId_persona As Integer
        Get
            Return id_persona
        End Get
        Set(value As Integer)
            id_persona = value
        End Set
    End Property

    Public Sub InsertarProfesor()
        Try
            gDatos.Ejecutar("SpInsertarProfesor", Me.Id_persona)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarProfesor()
        Try
            gDatos.Ejecutar("SpEliminarProfesor", Me.id_persona)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarProfesor() As DataTable
        Try
            Dim dtProfesor As New DataTable
            dtProfesor = gDatos.TraerDataTable("SpConsultarProfesor", 0)
            Return dtProfesor
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarProfesor(vId_profesor As Integer) As Profesor
        Try
            Dim dtProfesor As New DataTable
            dtProfesor = gDatos.TraerDataTable("SpConsultarProfesor", vId_profesor)
            If dtProfesor.Rows.Count > 0 Then
                Dim vProfesor As New Profesor
                With vProfesor
                    .id_profesor = dtProfesor.Rows(0).Item("id_profesor")
                    .Id_persona = dtProfesor.Rows(0).Item("id_persona")
                End With
                Return vProfesor
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
