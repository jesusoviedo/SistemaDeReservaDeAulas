Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class TurnoController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtTurno As New DataTable
            dtTurno = Turno.RecuperarTurno()
            ViewData("Turnos") = dtTurno.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vTurno As New Turno
            With vTurno
                .pDescripcion = form("txtDescripcion")
                .pHora_inicio = form("txtHora_inicio")
                .pHora_fin = form("txtHora_fin")
                .InsertarTurno()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim vTurno As New Turno
            vTurno = vTurno.RecuperarTurno(id)
            Return View(vTurno)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vTurno As New Turno
            With vTurno
                .pId_turno = form("txtId_turno")
                .pDescripcion = form("txtDescripcion")
                .pHora_inicio = form("txtHora_inicio")
                .pHora_fin = form("txtHora_fin")
                .ActualizarTurno()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vTurno As New Turno
            With vTurno
                .pId_turno = id
                .EliminarTurno()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace