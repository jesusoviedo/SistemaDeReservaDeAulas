Imports ModeloDeNegocio.Util

Public Class DetalleCurso
    Private nro_curso As Integer
    Private id_dia As Integer

    Public Property pNro_curso As Integer
        Get
            Return nro_curso
        End Get
        Set(value As Integer)
            nro_curso = value
        End Set
    End Property

    Public Property pId_dia As Integer
        Get
            Return id_dia
        End Get
        Set(value As Integer)
            id_dia = value
        End Set
    End Property

    'metodos
    Public Sub InsertarDetalleCurso()
        Try
            gDatos.Ejecutar("SpInsertarDetalleCurso", Me.nro_curso, Me.id_dia)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarDetalleCurso()
        Try
            gDatos.Ejecutar("SpActualizarDetalleCurso", Me.nro_curso, Me.id_dia)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarDetalleCurso()
        Try
            gDatos.Ejecutar("SpEliminarDetalleCurso", Me.nro_curso, Me.id_dia)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarDetalleCurso() As DataTable
        Try
            Dim dtDetalleCurso As New DataTable
            dtDetalleCurso = gDatos.TraerDataTable("SpConsultarDetalleCurso", 0)
            Return dtDetalleCurso
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarDetalleCurso(vNro_Curso As Integer) As DetalleCurso
        Try
            Dim dtDetalleCurso As New DataTable
            dtDetalleCurso = gDatos.TraerDataTable("SpConsultarDetalleCurso", vNro_Curso)
            If dtDetalleCurso.Rows.Count > 0 Then
                Dim vDetalleCurso As New DetalleCurso
                With vDetalleCurso
                    .nro_curso = dtDetalleCurso.Rows(0).Item("nro_curso")
                    .id_dia = dtDetalleCurso.Rows(0).Item("id_dia")
                End With
                Return vDetalleCurso
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
