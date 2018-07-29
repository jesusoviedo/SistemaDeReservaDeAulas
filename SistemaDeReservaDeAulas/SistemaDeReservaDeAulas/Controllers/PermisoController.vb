Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class PermisoController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim dtPermiso As New DataTable
                dtPermiso = Permiso.RecuperarPermiso()
                ViewData("Permisos") = dtPermiso.AsEnumerable
                Return View()
            End If

        End Function

        <HttpPost()>
        Function Create(nombre_permiso As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vPermiso As New Permiso
                With vPermiso
                    .pNombre_permiso = nombre_permiso
                    .InsertarPermiso()
                End With
                Return Json("")
            End If

        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vPermiso As New Permiso
                vPermiso = vPermiso.RecuperarPermiso(id)
                Return Json(JsonConvert.SerializeObject(vPermiso))
            End If

        End Function

        <HttpPost()>
        Function Edit(id_permiso As Integer, nombre_permiso As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vPermiso As New Permiso
                With vPermiso
                    .pId_permiso = id_permiso
                    .pNombre_permiso = nombre_permiso
                    .ActualizarPermiso()
                End With
                Return Json("")
            End If

        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim vPermiso As New Permiso
                With vPermiso
                    .pId_permiso = id
                    .EliminarPermiso()
                End With
                Return RedirectToAction("Index")
            End If

        End Function

    End Class
End Namespace