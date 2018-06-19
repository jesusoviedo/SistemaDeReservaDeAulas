Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class PermisoController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtPermiso As New DataTable
            dtPermiso = Permiso.RecuperarPermiso()
            ViewData("Permisos") = dtPermiso.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vPermiso As New Permiso
            With vPermiso
                .pNombre_permiso = form("txtNombre_permiso")
                .InsertarPermiso()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim vPermiso As New Permiso
            vPermiso = vPermiso.RecuperarPermiso(id)

            Return View(vPermiso)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vPermiso As New Permiso
            With vPermiso
                .pId_permiso = form("txtId_permiso")
                .pNombre_permiso = form("txtNombre_permiso")
                .ActualizarPermiso()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vPermiso As New Permiso
            With vPermiso
                .pId_permiso = id
                .EliminarPermiso()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace