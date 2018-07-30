Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class EstadoReservaController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim dtEstadoReserva As New DataTable
                dtEstadoReserva = EstadoReserva.RecuperarEstadoReserva()
                ViewData("EstadosReservas") = dtEstadoReserva.AsEnumerable
                Return View()
            End If

        End Function

        <HttpPost()>
        Function Create(id_estado_reserva As String, descripcion As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vEstadoReserva As New EstadoReserva
                With vEstadoReserva
                    .pId_estado_reserva = id_estado_reserva.Substring(0, 1)
                    .pDescripcion = descripcion
                    .InsertarEstadoReserva()
                End With
                Return Json("")
            End If

        End Function

        <HttpPost()>
        Function Consult(id As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vEstadoReserva As New EstadoReserva
                vEstadoReserva = vEstadoReserva.RecuperarEstadoReserva(id)
                Return Json(JsonConvert.SerializeObject(vEstadoReserva))
            End If

        End Function

        <HttpPost()>
        Function Edit(id_estado_reserva As String, descripcion As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vEstadoReserva As New EstadoReserva
                With vEstadoReserva
                    .pId_estado_reserva = id_estado_reserva
                    .pDescripcion = descripcion
                    .ActualizarEstadoReserva()
                End With
                Return Json("")
            End If

        End Function

        <HttpGet()>
        Function Delete(id As String) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim vEstadoReserva As New EstadoReserva
                With vEstadoReserva
                    .pId_estado_reserva = id
                    .EliminarEstadoReserva()
                End With
                Return RedirectToAction("Index")
            End If

        End Function

    End Class
End Namespace