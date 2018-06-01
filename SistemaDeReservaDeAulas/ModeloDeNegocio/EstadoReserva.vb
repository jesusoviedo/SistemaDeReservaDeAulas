Imports ModeloDeNegocio.Util

Public Class EstadoReserva

    Private id_estado_reserva As Integer
    Private descripcion As String

    'propiedades 
    Public Property pId_estado_reserva As Integer
        Get
            Return id_estado_reserva
        End Get
        Set(value As Integer)
            id_estado_reserva = value
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
    Public Sub InsertarEstadoReserva()
        Try
            gDatos.Ejecutar("SpInsertarEstadoReserva", Me.descripcion)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarEstadoReserva()
        Try
            gDatos.Ejecutar("SpActualizarEstadoReserva", Me.descripcion, Me.id_estado_reserva)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarEstadoReserva()
        Try
            gDatos.Ejecutar("SpEliminarEstadoReserva", Me.id_estado_reserva)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarEstadoReserva() As DataTable
        Try
            Dim dtEstadoReserva As New DataTable
            dtEstadoReserva = gDatos.TraerDataTable("SpConsultarEstadoReserva", 0)
            Return dtEstadoReserva
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarEstadoReserva(vId_estado_reserva As Integer) As EstadoReserva
        Try
            Dim dtEstadoReserva As New DataTable
            dtEstadoReserva = gDatos.TraerDataTable("SpConsultarEstadoReserva", vId_estado_reserva)
            If dtEstadoReserva.Rows.Count > 0 Then
                Dim vEstadoReserva As New EstadoReserva
                With vEstadoReserva
                    .id_estado_reserva = dtEstadoReserva.Rows(0).Item("id_estado_reserva")
                    .descripcion = dtEstadoReserva.Rows(0).Item("descripcion")
                End With
                Return vEstadoReserva
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
