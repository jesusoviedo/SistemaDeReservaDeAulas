Imports System.Web.Mvc
Imports ModeloDeNegocio

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

        <HttpGet()>
        Function Create() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vFacultad As New Facultad
            With vFacultad
                .pNombre_facultad = form("txtNombre_facultad")
                .InsertarFacultad()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult

            Dim vFacultad As New Facultad
            vFacultad = vFacultad.RecuperarFacultad(id)

            Return View(vFacultad)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vFacultad As New Facultad
            With vFacultad
                .pId_facultad = form("txtId_facultad")
                .pNombre_facultad = form("txtNombre_facultad")
                .ActualizarFacultad()
            End With
            Return RedirectToAction("Index")
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