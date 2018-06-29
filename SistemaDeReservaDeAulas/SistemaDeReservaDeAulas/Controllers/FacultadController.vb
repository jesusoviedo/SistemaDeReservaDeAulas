Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class FacultadController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtFacultad As New DataTable
            dtFacultad = Facultad.RecuperarFacultad()
            ViewData("Facultades") = dtFacultad.AsEnumerable
            Return View()
        End Function

        <HttpPost()>
        Function Create(nombre_facultad As String) As JsonResult
            Dim vFacultad As New Facultad
            With vFacultad
                .pNombre_facultad = nombre_facultad
                .InsertarFacultad()
            End With
            Return Json("")
        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult
            Dim vFacultad As New Facultad
            vFacultad = vFacultad.RecuperarFacultad(id)
            Return Json(JsonConvert.SerializeObject(vFacultad))
        End Function

        <HttpPost()>
        Function Edit(id_facultad As Integer, nombre_facultad As String) As JsonResult
            Dim vFacultad As New Facultad
            With vFacultad
                .pId_facultad = id_facultad
                .pNombre_facultad = nombre_facultad
                .ActualizarFacultad()
            End With
            Return Json("")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vFacultad As New Facultad
            With vFacultad
                .pId_facultad = id
                .EliminarFacultad()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace