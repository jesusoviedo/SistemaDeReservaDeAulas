Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json
Imports System.Timers

Namespace Controllers
    Public Class TurnoController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim dtTurno As New DataTable
                dtTurno = Turno.RecuperarTurno()
                ViewData("Turnos") = dtTurno.AsEnumerable
                Return View()
            End If

        End Function

        <HttpPost()>
        Function Create(descripcion As String, hora_inicio As TimeSpan, hora_fin As TimeSpan) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vTurno As New Turno
                With vTurno
                    .pDescripcion = descripcion
                    .pHora_inicio = hora_inicio
                    .pHora_fin = hora_fin
                    .InsertarTurno()
                End With
                Return Json("")
            End If

        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vTurno As New Turno
                vTurno = vTurno.RecuperarTurno(id)
                Return Json(JsonConvert.SerializeObject(vTurno))
            End If

        End Function

        <HttpPost()>
        Function Edit(id_turno As Integer, descripcion As String, hora_inicio As TimeSpan, hora_fin As TimeSpan) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vTurno As New Turno
                With vTurno
                    .pId_turno = id_turno
                    .pDescripcion = descripcion
                    .pHora_inicio = hora_inicio
                    .pHora_fin = hora_fin
                    .ActualizarTurno()
                End With
                Return Json("")
            End If

        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim vTurno As New Turno
                With vTurno
                    .pId_turno = id
                    .EliminarTurno()
                End With
                Return RedirectToAction("Index")
            End If

        End Function

    End Class
End Namespace