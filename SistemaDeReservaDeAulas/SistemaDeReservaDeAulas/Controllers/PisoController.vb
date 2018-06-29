Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

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

        <HttpPost()>
        Function Create(descripcion As String) As JsonResult
            Dim vPiso As New Piso
            With vPiso
                .pDescripcion = descripcion
                .InsertarPiso()
            End With
            Return Json("")
        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult
            Dim vPiso As New Piso
            vPiso = vPiso.RecuperarPiso(id)
            Return Json(JsonConvert.SerializeObject(vPiso))
        End Function

        <HttpPost()>
        Function Edit(id_piso As Integer, descripcion As String) As JsonResult
            Dim vPiso As New Piso
            With vPiso
                .pId_piso = id_piso
                .pDescripcion = descripcion
                .ActualizarPiso()
            End With
            Return Json("")
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