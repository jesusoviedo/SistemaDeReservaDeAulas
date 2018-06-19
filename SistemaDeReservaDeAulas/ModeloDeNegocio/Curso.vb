Imports ModeloDeNegocio.Util

Public Class Curso
    Private nro_curso As Integer
    Private id_aula As Integer
    Private id_materia As Integer
    Private id_turno As Integer
    Private id_profesor As Integer
    Private cant_inscriptos As Integer
    Private anho_lectivo As Integer

    Public Property pNro_curso As Integer
        Get
            Return nro_curso
        End Get
        Set(value As Integer)
            nro_curso = value
        End Set
    End Property

    Public Property pId_aula As Integer
        Get
            Return id_aula
        End Get
        Set(value As Integer)
            id_aula = value
        End Set
    End Property

    Public Property pId_materia As Integer
        Get
            Return id_materia
        End Get
        Set(value As Integer)
            id_materia = value
        End Set
    End Property

    Public Property pId_turno As Integer
        Get
            Return id_turno
        End Get
        Set(value As Integer)
            id_turno = value
        End Set
    End Property

    Public Property pId_profesor As Integer
        Get
            Return id_profesor
        End Get
        Set(value As Integer)
            id_profesor = value
        End Set
    End Property

    Public Property pCant_inscriptos As Integer
        Get
            Return cant_inscriptos
        End Get
        Set(value As Integer)
            cant_inscriptos = value
        End Set
    End Property

    Public Property pAnho_lectivo As Integer
        Get
            Return anho_lectivo
        End Get
        Set(value As Integer)
            anho_lectivo = value
        End Set
    End Property

    'metodos
    Public Sub InsertarCurso()
        Try
            gDatos.Ejecutar("SpInsertarCurso",
                            Me.id_aula,
                            Me.id_materia,
                            Me.id_turno,
                            Me.id_profesor,
                            Me.cant_inscriptos,
                            Me.anho_lectivo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarCurso()
        Try
            gDatos.Ejecutar("SpActualizarCurso",
                            Me.id_aula,
                            Me.id_materia,
                            Me.id_turno,
                            Me.id_profesor,
                            Me.cant_inscriptos,
                            Me.anho_lectivo,
                            Me.nro_curso)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarCurso()
        Try
            gDatos.Ejecutar("SpEliminarCurso", Me.nro_curso)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarCurso() As DataTable
        Try
            Dim dtCurso As New DataTable
            dtCurso = gDatos.TraerDataTable("SpConsultarCurso", 0)
            Return dtCurso
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarCurso(vNroCurso As Integer) As Curso
        Try
            Dim dtCurso As New DataTable
            dtCurso = gDatos.TraerDataTable("SpConsultarCurso", vNroCurso)
            If dtCurso.Rows.Count > 0 Then
                Dim vCurso As New Curso
                With vCurso
                    .nro_curso = dtCurso.Rows(0).Item("nro_curso")
                    .id_aula = dtCurso.Rows(0).Item("id_aula")
                    .id_materia = dtCurso.Rows(0).Item("id_materia")
                    .id_turno = dtCurso.Rows(0).Item("id_turno")
                    .id_profesor = dtCurso.Rows(0).Item("id_profesor")
                    .cant_inscriptos = dtCurso.Rows(0).Item("cant_inscriptos")
                    .anho_lectivo = dtCurso.Rows(0).Item("anho_lectivo")
                End With
                Return vCurso
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
