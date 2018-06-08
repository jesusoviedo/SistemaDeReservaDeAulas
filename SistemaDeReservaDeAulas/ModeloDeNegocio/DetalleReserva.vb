Imports ModeloDeNegocio.Util

Public Class DetalleReserva
    Private id_reserva As Integer
    Private id_insumo As Integer
    Private cantidad As Integer

    'propiedades 
    Public Property pId_reserva As Integer
        Get
            Return id_reserva
        End Get
        Set(value As Integer)
            id_reserva = value
        End Set
    End Property

    Public Property pId_insumo As Integer
        Get
            Return id_insumo
        End Get
        Set(value As Integer)
            id_insumo = value
        End Set
    End Property

    Public Property pCantidad As Integer
        Get
            Return cantidad
        End Get
        Set(value As Integer)
            cantidad = value
        End Set
    End Property

    'metodos
    Public Sub InsertarDetalleReserva()
        Try
            gDatos.Ejecutar("SpInsertarDetalleReserva", Me.id_reserva, Me.id_insumo, Me.cantidad)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarDetalleReserva()
        Try
            gDatos.Ejecutar("SpActualizarDetalleReserva", Me.cantidad, Me.id_reserva, Me.id_insumo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarDetalleReserva()
        Try
            gDatos.Ejecutar("SpEliminarDetalleReserva", Me.id_reserva, Me.id_insumo)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarDetalleReserva() As DataTable
        Try
            Dim dtDetalleReserva As New DataTable
            dtDetalleReserva = gDatos.TraerDataTable("SpConsultarDetalleReserva", 0, 0)
            Return dtDetalleReserva
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarDetalleReserva(vId_reserva As Integer, vId_insumo As Integer) As DetalleReserva
        Try
            Dim dtDetalleReserva As New DataTable
            dtDetalleReserva = gDatos.TraerDataTable("SpConsultarDetalleReserva", vId_reserva, vId_insumo)
            If dtDetalleReserva.Rows.Count > 0 Then
                Dim vDetalleReserva As New DetalleReserva
                With vDetalleReserva
                    .id_reserva = dtDetalleReserva.Rows(0).Item("id_reserva")
                    .id_insumo = dtDetalleReserva.Rows(0).Item("id_insumo")
                    .cantidad = dtDetalleReserva.Rows(0).Item("cantidad")
                End With
                Return vDetalleReserva
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
