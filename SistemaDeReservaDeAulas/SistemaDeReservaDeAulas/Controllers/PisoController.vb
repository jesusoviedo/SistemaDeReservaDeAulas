Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class PisoController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtPiso As New DataTable
            dtPiso = Piso.RecuperarPiso()
            ViewData("Pisos") = dtPiso.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vPiso As New Piso
            With vPiso
                .pDescripcion = form("txtDescripcion")
                .InsertarPiso()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim vPiso As New Piso
            vPiso = vPiso.RecuperarPiso(id)
            Return View(vPiso)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vPiso As New Piso
            With vPiso
                .pId_piso = form("txtId_piso")
                .pDescripcion = form("txtDescripcion")
                .ActualizarPiso()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vPiso As New Piso
            With vPiso
                .pId_piso = id
                .EliminarPiso()
            End With
            Return RedirectToAction("Index")
        End Function
    End Class
End Namespace