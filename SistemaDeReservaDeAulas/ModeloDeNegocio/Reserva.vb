Imports ModeloDeNegocio.Util

Public Class Reserva
    Private id_reserva As Integer
    Private fecha_reserva As DateTime
    Private id_aula As Integer
    Private nro_curso As Integer
    Private observacion As String
    Private hora_inicio As DateTime
    Private hora_fin As DateTime
    Private id_estado_reserva As Integer
    Private id_usuario As Integer

    'propiedades 
    Public Property pId_reserva As Integer
        Get
            Return id_reserva
        End Get
        Set(value As Integer)
            id_reserva = value
        End Set
    End Property

    Public Property pFecha_reserva As Date
        Get
            Return fecha_reserva
        End Get
        Set(value As Date)
            fecha_reserva = value
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

    Public Property pNro_curso As Integer
        Get
            Return nro_curso
        End Get
        Set(value As Integer)
            nro_curso = value
        End Set
    End Property

    Public Property pObservacion As String
        Get
            Return observacion
        End Get
        Set(value As String)
            observacion = value
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

    Public Property pId_estado_reserva As Integer
        Get
            Return id_estado_reserva
        End Get
        Set(value As Integer)
            id_estado_reserva = value
        End Set
    End Property

    Public Property pId_usuario As Integer
        Get
            Return id_usuario
        End Get
        Set(value As Integer)
            id_usuario = value
        End Set
    End Property

    'metodos
    Public Sub InsertarReserva()
        Try
            gDatos.Ejecutar("SpInsertarReserva",
                            Me.fecha_reserva,
                            Me.id_aula,
                            Me.nro_curso,
                            Me.observacion,
                            Me.hora_inicio,
                            Me.hora_fin,
                            Me.id_estado_reserva,
                            Me.id_usuario
                            )
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarReserva()
        Try
            gDatos.Ejecutar("SpActualizarReserva",
                            Me.fecha_reserva,
                            Me.id_aula,
                            Me.nro_curso,
                            Me.observacion,
                            Me.hora_inicio,
                            Me.hora_fin,
                            Me.id_estado_reserva,
                            Me.id_usuario,
                            Me.id_reserva
                            )
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarReserva()
        Try
            gDatos.Ejecutar("SpEliminarReserva", Me.id_reserva)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarReserva() As DataTable
        Try
            Dim dtReserva As New DataTable
            dtReserva = gDatos.TraerDataTable("SpConsultarReserva", 0)
            Return dtReserva
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarReserva(vId_reserva As Integer) As Reserva
        Try
            Dim dtReserva As New DataTable
            dtReserva = gDatos.TraerDataTable("SpConsultarReserva", vId_reserva)
            If dtReserva.Rows.Count > 0 Then
                Dim vReserva As New Reserva
                With vReserva
                    .id_reserva = dtReserva.Rows(0).Item("id_reserva")
                    .fecha_reserva = dtReserva.Rows(0).Item("fecha_reserva")
                    .id_aula = dtReserva.Rows(0).Item("id_aula")
                    .nro_curso = dtReserva.Rows(0).Item("nro_curso")
                    .observacion = dtReserva.Rows(0).Item("observacion")
                    .hora_inicio = dtReserva.Rows(0).Item("hora_inicio")
                    .hora_fin = dtReserva.Rows(0).Item("hora_fin")
                    .id_estado_reserva = dtReserva.Rows(0).Item("id_estado_reserva")
                    .id_usuario = dtReserva.Rows(0).Item("id_usuario")
                End With
                Return vReserva
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
