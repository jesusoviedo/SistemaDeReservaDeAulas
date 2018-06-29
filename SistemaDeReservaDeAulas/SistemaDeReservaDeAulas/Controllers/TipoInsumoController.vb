Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

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

        <HttpPost()>
        Function Create(descripcion As String) As JsonResult
            Dim vTipoInsumo As New TipoInsumo
            With vTipoInsumo
                .pDescripcion = descripcion
                .InsertarTipoInsumo()
            End With
            Return Json("")
        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult
            Dim vTipoInsumo As New TipoInsumo
            vTipoInsumo = vTipoInsumo.RecuperarTipoInsumo(id)
            Return Json(JsonConvert.SerializeObject(vTipoInsumo))
        End Function

        <HttpPost()>
        Function Edit(id_tip_insumo As Integer, descripcion As String) As JsonResult
            Dim vTipoInsumo As New TipoInsumo
            With vTipoInsumo
                .pId_tip_insumo = id_tip_insumo
                .pDescripcion = descripcion
                .ActualizarTipoInsumo()
            End With
            Return Json("")
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