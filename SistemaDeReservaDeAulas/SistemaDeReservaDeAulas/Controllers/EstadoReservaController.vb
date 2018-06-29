Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

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
        Function Create(descripcion As String) As JsonResult
            Dim vEstadoReserva As New EstadoReserva
            With vEstadoReserva
                .pDescripcion = descripcion
                .InsertarEstadoReserva()
            End With
            Return Json("")
        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult
            Dim vEstadoReserva As New EstadoReserva
            vEstadoReserva = vEstadoReserva.RecuperarEstadoReserva(id)
            Return Json(JsonConvert.SerializeObject(vEstadoReserva))
        End Function

        <HttpPost()>
        Function Edit(id_estado_reserva As Integer, descripcion As String) As JsonResult
            Dim vEstadoReserva As New EstadoReserva
            With vEstadoReserva
                .pId_estado_reserva = id_estado_reserva
                .pDescripcion = descripcion
                .ActualizarEstadoReserva()
            End With
            Return Json("")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vEstadoReserva As New EstadoReserva
            With vEstadoReserva
                .pId_estado_reserva = id
                .EliminarEstadoReserva()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace