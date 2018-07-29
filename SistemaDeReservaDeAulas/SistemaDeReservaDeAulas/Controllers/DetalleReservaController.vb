Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class DetalleReservaController
        Inherits Controller

        '<HttpGet()>
        'Function Index() As ActionResult

        '    If Session("user") Is Nothing Then
        '        Return RedirectToAction("ErrorSesion", "Home")
        '    Else
        '        Dim dtDetalleReserva As New DataTable
        '        dtDetalleReserva = DetalleReserva.RecuperarDetalleReserva()
        '        ViewData("DetallesReservas") = dtDetalleReserva.AsEnumerable
        '        Return View()
        '    End If

        'End Function

        <HttpGet()>
        Function Create() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim dtInsumo As New DataTable
                dtInsumo = Insumo.RecuperarInsumo()
                ViewData("Insumos") = dtInsumo.AsEnumerable
                Return View()
            End If

        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim vDetalleReserva As New DetalleReserva
                With vDetalleReserva
                    .pId_reserva = form("txtId_reserva")
                    .pId_insumo = form("txtId_insumo")
                    .pCantidad = form("txtCantidad")
                    .InsertarDetalleReserva()
                End With
                Return RedirectToAction("Index")
            End If

        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim dtInsumo As New DataTable
                dtInsumo = Insumo.RecuperarInsumo()
                ViewData("Insumos") = dtInsumo.AsEnumerable

                Dim vDetalleReserva As New DetalleReserva
                vDetalleReserva = vDetalleReserva.RecuperarDetalleReserva(id)
                Return View(vDetalleReserva)
            End If

        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim vDetalleReserva As New DetalleReserva
                With vDetalleReserva
                    .pId_reserva = form("txtId_reserva")
                    .pId_insumo = form("txtId_insumo")
                    .pCantidad = form("txtCantidad")
                    .ActualizarDetalleReserva()
                End With
                Return RedirectToAction("Index")
            End If

        End Function

        <HttpGet()>
        Function Delete(idReserva As Integer, idInsumo As Integer) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim vDetalleReserva As New DetalleReserva
                With vDetalleReserva
                    .pId_reserva = idReserva
                    .pId_insumo = idInsumo
                    .EliminarDetalleReserva()
                End With
                Return RedirectToAction("Index")
            End If

        End Function


        <HttpPost()>
        Function Consult(id_reserva As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vDetalleReserva As New DataTable
                vDetalleReserva = DetalleReserva.RecuperarDetalleInsumo(id_reserva)
                Return Json(JsonConvert.SerializeObject(vDetalleReserva))
            End If

        End Function

    End Class
End Namespace