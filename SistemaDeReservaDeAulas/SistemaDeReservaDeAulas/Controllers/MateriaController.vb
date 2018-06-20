Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class MateriaController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtMateria As New DataTable
            dtMateria = Materia.RecuperarMateria()
            ViewData("Materias") = dtMateria.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult

            Dim dtDpto As New DataTable
            dtDpto = Departamento.RecuperarDepartamento()
            ViewData("Departamentos") = dtDpto.AsEnumerable

            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vMateria As New Materia
            With vMateria
                .pDescripcion = form("txtDescripcion")
                .pId_departamento = form("txtId_departamento")
                .InsertarMateria()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult

            Dim dtDpto As New DataTable
            dtDpto = Departamento.RecuperarDepartamento()
            ViewData("Departamentos") = dtDpto.AsEnumerable

            Dim vMateria As New Materia
            vMateria = vMateria.RecuperarMateria(id)

            Return View(vMateria)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vMateria As New Materia
            With vMateria
                .pId_materia = form("txtId_materia")
                .pDescripcion = form("txtDescripcion")
                .pId_departamento = form("txtId_departamento")
                .ActualizarMateria()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vMateria As New Materia
            With vMateria
                .pId_materia = id
                .EliminarMateria()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace