Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class TipoInsumoController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtTipoInsumo As New DataTable
            dtTipoInsumo = TipoInsumo.RecuperarTipoInsumo()
            ViewData("TiposInsumos") = dtTipoInsumo.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vTipoInsumo As New TipoInsumo
            With vTipoInsumo
                .pDescripcion = form("txtDescripcion")
                .InsertarTipoInsumo()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim vTipoInsumo As New TipoInsumo
            vTipoInsumo = vTipoInsumo.RecuperarTipoInsumo(id)
            Return View(vTipoInsumo)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vTipoInsumo As New TipoInsumo
            With vTipoInsumo
                .pId_tip_insumo = form("txtId_tip_insumo")
                .pDescripcion = form("txtDescripcion")
                .ActualizarTipoInsumo()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vTipoInsumo As New TipoInsumo
            With vTipoInsumo
                .pId_tip_insumo = id
                .EliminarTipoInsumo()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace