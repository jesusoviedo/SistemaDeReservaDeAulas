Imports ModeloDeNegocio.Util
Public Class Profesor
    Inherits Persona

    Protected id_profesor As Integer
    Protected id_persona As Integer

    Public Property pId_profesor As Integer
        Get
            Return id_profesor
        End Get
        Set(value As Integer)
            id_profesor = value
        End Set
    End Property



    Public Overrides Sub InsertarProfesor()
        Try
            gDatos.Ejecutar("SpInsertarProfesor", Me.id_persona)
        Catch ex As Exception
            Throw ex
        End Try
        MyBase.InsertarPersona()
    End Sub

    Public Overrides Sub ActualizarProfesor()
        Try
            gDatos.Ejecutar("SpActualizarProfesor", Me.id_persona, Me.id_profesor)
        Catch ex As Exception
            Throw ex
        End Try
        MyBase.ActualizarPersona()
    End Sub

    Public Overrides Sub EliminarProfesor()
        Try
            gDatos.Ejecutar("SpEliminarProfesor", Me.id_profesor)
        Catch ex As Exception
            Throw ex
        End Try
        'MyBase.EliminarPersona()
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
                    .id_persona = dtProfesor.Rows(0).Item("id_persona")
                    .pDocumento = dtProfesor.Rows(0).Item("documento")
                    .pId_tipo_doc = dtProfesor.Rows(0).Item("id_tipo_doc")
                    .pNombre = dtProfesor.Rows(0).Item("nombre")
                    .pApellido = dtProfesor.Rows(0).Item("apellido")
                    .pFecha_naci = dtProfesor.Rows(0).Item("fecha_naci")
                    .pEmail = dtProfesor.Rows(0).Item("email")
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
