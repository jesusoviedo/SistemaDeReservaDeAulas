Imports ModeloDeNegocio.Util

Public Class Turno

    Private id_turno As Integer
    Private descripcion As String
    Private hora_inicio As DateTime
    Private hora_fin As DateTime

    'propiedades 
    Public Property pId_turno As Integer
        Get
            Return id_turno
        End Get
        Set(value As Integer)
            id_turno = value
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

    Public Property pHora_inicio As Date
        Get
            Return hora_inicio
        End Get
        Set(value As Date)
            hora_inicio = value
        End Set
    End Property

    Public Property pHora_fin As Date
        Get
            Return hora_fin
        End Get
        Set(value As Date)
            hora_fin = value
        End Set
    End Property

    'metodos
    Public Sub InsertarTurno()
        Try
            gDatos.Ejecutar("SpInsertarTurno", Me.descripcion, Me.hora_inicio, Me.hora_fin)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarTurno()
        Try
            gDatos.Ejecutar("SpActualizarTurno", Me.descripcion, Me.hora_inicio, Me.hora_fin, Me.id_turno)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarTurno()
        Try
            gDatos.Ejecutar("SpEliminarTurno", Me.id_turno)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarTurno() As DataTable
        Try
            Dim dtTurno As New DataTable
            dtTurno = gDatos.TraerDataTable("SpConsultarTurno", 0)
            Return dtTurno
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarTurno(vId_turno As Integer) As Turno
        Try
            Dim dtTurno As New DataTable
            dtTurno = gDatos.TraerDataTable("SpConsultarTurno", vId_turno)
            If dtTurno.Rows.Count > 0 Then
                Dim vTurno As New Turno
                With vTurno
                    .id_turno = dtTurno.Rows(0).Item("id_turno")
                    .descripcion = dtTurno.Rows(0).Item("descripcion")
                    .hora_inicio = dtTurno.Rows(0).Item("hora_inicio")
                    .hora_fin = dtTurno.Rows(0).Item("hora_fin")
                End With
                Return vTurno
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
