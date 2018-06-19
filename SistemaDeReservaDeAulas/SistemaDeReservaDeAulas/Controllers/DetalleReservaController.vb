Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class DetalleReservaController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtDetalleReserva As New DataTable
            dtDetalleReserva = DetalleReserva.RecuperarDetalleReserva()
            ViewData("DetallesReservas") = dtDetalleReserva.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult
            Dim dtInsumo As New DataTable
            dtInsumo = Insumo.RecuperarInsumo()
            ViewData("Insumos") = dtInsumo.AsEnumerable
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vDetalleReserva As New DetalleReserva
            With vDetalleReserva
                .pId_reserva = form("txtId_reserva")
                .pId_insumo = form("txtId_insumo")
                .pCantidad = form("txtCantidad")
                .InsertarDetalleReserva()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim dtInsumo As New DataTable
            dtInsumo = Insumo.RecuperarInsumo()
            ViewData("Insumos") = dtInsumo.AsEnumerable

            Dim vDetalleReserva As New DetalleReserva
            vDetalleReserva = vDetalleReserva.RecuperarDetalleReserva(id)
            Return View(vDetalleReserva)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vDetalleReserva As New DetalleReserva
            With vDetalleReserva
                .pId_reserva = form("txtId_reserva")
                .pId_insumo = form("txtId_insumo")
                .pCantidad = form("txtCantidad")
                .ActualizarDetalleReserva()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(idReserva As Integer, idInsumo As Integer) As ActionResult
            Dim vDetalleReserva As New DetalleReserva
            With vDetalleReserva
                .pId_reserva = idReserva
                .pId_insumo = idInsumo
                .EliminarDetalleReserva()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace