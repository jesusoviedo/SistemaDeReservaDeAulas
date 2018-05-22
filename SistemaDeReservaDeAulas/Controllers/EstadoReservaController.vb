Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class EstadoReservaController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtEstadoReserva As New DataTable
            dtEstadoReserva = EstadoReserva.RecuperarEstadoReserva()
            ViewData("EstadosReservas") = dtEstadoReserva.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vEstadoReserva As New EstadoReserva
            With vEstadoReserva
                .pDescripcion = form("txtDescripcion")
                .InsertarEstadoReserva()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim vEstadoReserva As New EstadoReserva
            vEstadoReserva = vEstadoReserva.RecuperarEstadoReserva(id)
            Return View(vEstadoReserva)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vEstadoReserva As New EstadoReserva
            With vEstadoReserva
                .pId_estado_reserva = form("txtId_estado_reserva")
                .pDescripcion = form("txtDescripcion")
                .ActualizarEstadoReserva()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vEstadoReserva As New EstadoReserva
            vEstadoReserva.pId_estado_reserva = id
            vEstadoReserva.EliminarEstadoReserva()
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace