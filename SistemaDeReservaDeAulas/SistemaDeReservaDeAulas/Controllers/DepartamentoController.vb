Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class DepartamentoController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtDpto As New DataTable
            dtDpto = Departamento.RecuperarDepartamento()
            ViewData("Departamentos") = dtDpto.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult

            Dim dtFacultad As New DataTable
            dtFacultad = Facultad.RecuperarFacultad()
            ViewData("Facultades") = dtFacultad.AsEnumerable

            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vDpto As New Departamento
            With vDpto
                .pNombre_dpto = form("txtNombre_dpto")
                .pId_facultad = form("txtId_facultad")
                .InsertarDepartamento()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult

            Dim dtFacultad As New DataTable
            dtFacultad = Facultad.RecuperarFacultad()
            ViewData("Facultades") = dtFacultad.AsEnumerable

            Dim vDpto As New Departamento
            vDpto = vDpto.RecuperarDepartamento(id)

            Return View(vDpto)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vDpto As New Departamento
            With vDpto
                .pId_dpto = form("txtId_dpto")
                .pNombre_dpto = form("txtNombre_dpto")
                .pId_facultad = form("txtId_facultad")
                .ActualizarDepartamento()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vDpto As New Departamento
            With vDpto
                .pId_dpto = id
                .EliminarDepartamento()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace