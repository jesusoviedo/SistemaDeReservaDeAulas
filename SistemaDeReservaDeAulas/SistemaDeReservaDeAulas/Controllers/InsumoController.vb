Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class InsumoController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtInsumo As New DataTable
            dtInsumo = Insumo.RecuperarInsumo()
            ViewData("Insumos") = dtInsumo.AsEnumerable

            Dim dtTipoInsumo As New DataTable
            dtTipoInsumo = TipoInsumo.RecuperarTipoInsumo()
            ViewData("TiposInsumos") = dtTipoInsumo.AsEnumerable

            Return View()
        End Function

        <HttpPost()>
        Function Create(descripcion As String, id_tip_insumo As Integer) As JsonResult
            Dim vInsumo As New Insumo
            With vInsumo
                .pDescripcion = descripcion
                .pId_tip_insumo = id_tip_insumo
                .InsertarInsumo()
            End With
            Return Json("")
        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult
            Dim vInsumo As New Insumo
            vInsumo = vInsumo.RecuperarInsumo(id)
            Return Json(JsonConvert.SerializeObject(vInsumo))
        End Function

        <HttpPost()>
        Function Edit(id_insumo As Integer, descripcion As String, id_tip_insumo As Integer) As JsonResult
            Dim vInsumo As New Insumo
            With vInsumo
                .pId_insumo = id_insumo
                .pDescripcion = descripcion
                .pId_tip_insumo = id_tip_insumo
                .ActualizarInsumo()
            End With
            Return Json("")
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