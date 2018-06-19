Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class DetalleRolController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtDetalleRol As New DataTable
            dtDetalleRol = DetalleRol.RecuperarDetalleRol()
            ViewData("DetallesRoles") = dtDetalleRol.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult
            Dim dtRol As New DataTable
            dtRol = Rol.RecuperarRol()
            ViewData("Roles") = dtRol.AsEnumerable

            Dim dtPermiso As New DataTable
            dtPermiso = Permiso.RecuperarPermiso()
            ViewData("Permisos") = dtPermiso.AsEnumerable
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vDetalleRol As New DetalleRol
            With vDetalleRol
                .pId_rol = form("txtId_rol")
                .pId_permiso = form("txtId_permiso")
                .InsertarDetalleRol()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim dtRol As New DataTable
            dtRol = Rol.RecuperarRol()
            ViewData("Roles") = dtRol.AsEnumerable

            Dim dtPermiso As New DataTable
            dtPermiso = Permiso.RecuperarPermiso()
            ViewData("Permisos") = dtPermiso.AsEnumerable

            Dim vDetalleRol As New DetalleRol
            vDetalleRol = vDetalleRol.RecuperarDetalleRol(id)
            Return View(vDetalleRol)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vDetalleRol As New DetalleRol
            With vDetalleRol
                .pId_rol = form("txtId_rol")
                .pId_permiso = form("txtId_permiso")
                .ActualizarDetalleRol()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(idRol As Integer, idPermiso As Integer) As ActionResult
            Dim vDetalleRol As New DetalleRol
            With vDetalleRol
                .pId_rol = idRol
                .pId_permiso = idPermiso
                .EliminarDetalleRol()
            End With
            Return RedirectToAction("Index")
        End Function
    End Class
End Namespace