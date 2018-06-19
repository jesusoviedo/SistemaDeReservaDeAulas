Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class RolController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtRol As New DataTable
            dtRol = Rol.RecuperarRol()
            ViewData("Roles") = dtRol.AsEnumerable
            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vRol As New Rol
            With vRol
                .pNombre_rol = form("txtNombre_rol")
                .InsertarRol()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult
            Dim vRol As New Rol
            vRol = vRol.RecuperarRol(id)

            Return View(vRol)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vRol As New Rol
            With vRol
                .pId_rol = form("txtId_rol")
                .pNombre_rol = form("txtNombre_rol")
                .ActualizarRol()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vRol As New Rol
            With vRol
                .pId_rol = id
                .EliminarRol()
            End With
            Return RedirectToAction("Index")
        End Function


    End Class
End Namespace