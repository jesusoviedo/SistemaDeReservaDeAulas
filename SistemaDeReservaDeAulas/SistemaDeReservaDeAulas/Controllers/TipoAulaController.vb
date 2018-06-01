Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class TipoAulaController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtTipoAula As New DataTable
            dtTipoAula = TipoAula.RecuperarTipoAula()
            ViewData("TiposAulas") = dtTipoAula.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vTipoAula As New TipoAula
            With vTipoAula
                .pDescripcion = form("txtDescripcion")
                .InsertarTipoAula()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim vTipoAula As New TipoAula
            vTipoAula = vTipoAula.RecuperarTipoAula(id)
            Return View(vTipoAula)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vTipoAula As New TipoAula
            With vTipoAula
                .pId_tipo_aula = form("txtId_tipo_aula")
                .pDescripcion = form("txtDescripcion")
                .ActualizarTipoAula()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vTipoAula As New TipoAula
            With vTipoAula
                .pId_tipo_aula = id
                .EliminarTipoAula()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace