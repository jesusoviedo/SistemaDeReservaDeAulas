Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

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

        <HttpPost()>
        Function Create(descripcion As String) As JsonResult
            Dim vTipoAula As New TipoAula
            With vTipoAula
                .pDescripcion = descripcion
                .InsertarTipoAula()
            End With
            Return Json("")
        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult
            Dim vTipoAula As New TipoAula
            vTipoAula = vTipoAula.RecuperarTipoAula(id)
            Return Json(JsonConvert.SerializeObject(vTipoAula))
        End Function

        <HttpPost()>
        Function Edit(id_tipo_aula As Integer, descripcion As String) As JsonResult
            Dim vTipoAula As New TipoAula
            With vTipoAula
                .pId_tipo_aula = id_tipo_aula
                .pDescripcion = descripcion
                .ActualizarTipoAula()
            End With
            Return Json("")
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