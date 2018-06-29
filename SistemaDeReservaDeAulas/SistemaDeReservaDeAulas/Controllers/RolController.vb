Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

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

        <HttpPost()>
        Function Create(nombre_rol As String) As JsonResult
            Dim vRol As New Rol
            With vRol
                .pNombre_rol = nombre_rol
                .InsertarRol()
            End With
            Return Json("")
        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult
            Dim vRol As New Rol
            vRol = vRol.RecuperarRol(id)
            Return Json(JsonConvert.SerializeObject(vRol))
        End Function

        <HttpPost()>
        Function Edit(id_rol As Integer, nombre_rol As String) As JsonResult
            Dim vRol As New Rol
            With vRol
                .pId_rol = id_rol
                .pNombre_rol = nombre_rol
                .ActualizarRol()
            End With
            Return Json("")
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