Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class InsumoController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtInsumo As New DataTable
            dtInsumo = Insumo.RecuperarInsumo()
            ViewData("Insumos") = dtInsumo.AsEnumerable
            Return View()
        End Function


        <HttpGet()>
        Function Create() As ActionResult
            Dim dtTipoInsumo As New DataTable
            dtTipoInsumo = TipoInsumo.RecuperarTipoInsumo()
            ViewData("TiposInsumos") = dtTipoInsumo.AsEnumerable
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vInsumo As New Insumo
            With vInsumo
                .pDescripcion = form("txtDescripcion")
                .pId_tip_insumo = form("txtId_tip_insumo")
                .InsertarInsumo()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim dtTipoInsumo As New DataTable
            dtTipoInsumo = TipoInsumo.RecuperarTipoInsumo()
            ViewData("TiposInsumos") = dtTipoInsumo.AsEnumerable

            Dim vInsumo As New Insumo
            vInsumo = vInsumo.RecuperarInsumo(id)
            Return View(vInsumo)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vInsumo As New Insumo
            With vInsumo
                .pId_insumo = form("txtId_insumo")
                .pDescripcion = form("txtDescripcion")
                .pId_tip_insumo = form("txtId_tip_insumo")
                .ActualizarInsumo()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vInsumo As New Insumo
            With vInsumo
                .pId_insumo = id
                .EliminarInsumo()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace