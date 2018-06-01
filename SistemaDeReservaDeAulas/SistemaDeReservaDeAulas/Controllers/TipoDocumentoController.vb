Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class TipoDocumentoController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtTipoDocumento As New DataTable
            dtTipoDocumento = TipoDocumento.RecuperarTipoDocumento()
            ViewData("TiposDocumentos") = dtTipoDocumento.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vTipoDocumento As New TipoDocumento
            With vTipoDocumento
                .pDescripcion = form("txtDescripcion")
                .InsertarTipoDocumento()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim vTipoDocumento As New TipoDocumento
            vTipoDocumento = vTipoDocumento.RecuperarTipoDocumento(id)
            Return View(vTipoDocumento)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vTipoDocumento As New TipoDocumento
            With vTipoDocumento
                .pId_tipo_doc = form("txtId_tipo_doc")
                .pDescripcion = form("txtDescripcion")
                .ActualizarTipoDocumento()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vTipoDocumento As New TipoDocumento
            With vTipoDocumento
                .pId_tipo_doc = id
                .EliminarTipoDocumento()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace