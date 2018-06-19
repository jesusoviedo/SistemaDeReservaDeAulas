Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class DiaController
        Inherits Controller

        Function Index() As ActionResult
            Dim dtDia As New DataTable
            dtDia = Dia.RecuperarDia()
            ViewData("Dias") = dtDia.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vDia As New Dia
            With vDia
                .pDescripcion = form("txtDescripcion")
                .pCod_dia = form("txtCod_dia")
                .InsertarDia()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim vDia As New Dia
            vDia = vDia.RecuperarDia(id)
            Return View(vDia)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vDia As New Dia
            With vDia
                .pId_dia = form("txtid_dia")
                .pDescripcion = form("txtDescripcion")
                .pCod_dia = form("txtcod_dia")
                .ActualizarDia()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vDia As New Dia
            With vDia
                .pId_dia = id
                .EliminarDia()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace