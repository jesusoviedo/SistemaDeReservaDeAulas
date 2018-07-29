Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class MateriaController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim dtMateria As New DataTable
                dtMateria = Materia.RecuperarMateria()
                ViewData("Materias") = dtMateria.AsEnumerable

                Dim dtDpto As New DataTable
                dtDpto = Departamento.RecuperarDepartamento()
                ViewData("Departamentos") = dtDpto.AsEnumerable

                Return View()
            End If

        End Function

        <HttpPost()>
        Function Create(descripcion As String, id_departamento As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vMateria As New Materia
                With vMateria
                    .pDescripcion = descripcion
                    .pId_departamento = id_departamento
                    .InsertarMateria()
                End With
                Return Json("")
            End If

        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vMateria As New Materia
                vMateria = vMateria.RecuperarMateria(id)
                Return Json(JsonConvert.SerializeObject(vMateria))
            End If

        End Function

        <HttpPost()>
        Function Edit(id_materia As Integer, descripcion As String, id_departamento As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vMateria As New Materia
                With vMateria
                    .pId_materia = id_materia
                    .pDescripcion = descripcion
                    .pId_departamento = id_departamento
                    .ActualizarMateria()
                End With
                Return Json("")
            End If

        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim vMateria As New Materia
                With vMateria
                    .pId_materia = id
                    .EliminarMateria()
                End With
                Return RedirectToAction("Index")
            End If

        End Function

    End Class
End Namespace