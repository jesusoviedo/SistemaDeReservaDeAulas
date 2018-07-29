Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class DepartamentoController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim dtDpto As New DataTable
                dtDpto = Departamento.RecuperarDepartamento()
                ViewData("Departamentos") = dtDpto.AsEnumerable

                Dim dtFacultad As New DataTable
                dtFacultad = Facultad.RecuperarFacultad()
                ViewData("Facultades") = dtFacultad.AsEnumerable

                Return View()
            End If

        End Function

        <HttpPost()>
        Function Create(nombre_dpto As String, id_facultad As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vDpto As New Departamento
                With vDpto
                    .pNombre_dpto = nombre_dpto
                    .pId_facultad = id_facultad
                    .InsertarDepartamento()
                End With
                Return Json("")
            End If

        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vDpto As New Departamento
                vDpto = vDpto.RecuperarDepartamento(id)
                Return Json(JsonConvert.SerializeObject(vDpto))
            End If

        End Function

        <HttpPost()>
        Function Edit(id_dpto As Integer, nombre_dpto As String, id_facultad As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vDpto As New Departamento
                With vDpto
                    .pId_dpto = id_dpto
                    .pNombre_dpto = nombre_dpto
                    .pId_facultad = id_facultad
                    .ActualizarDepartamento()
                End With
                Return Json("")
            End If
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim vDpto As New Departamento
                With vDpto
                    .pId_dpto = id
                    .EliminarDepartamento()
                End With
                Return RedirectToAction("Index")
            End If
        End Function

    End Class
End Namespace