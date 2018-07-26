Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class DetalleRolController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            Dim dtRol As New DataTable
            dtRol = Rol.RecuperarRol()
            ViewData("Roles") = dtRol.AsEnumerable

            Dim dtPermiso As New DataTable
            dtPermiso = Permiso.RecuperarPermiso()
            ViewData("Permisos") = dtPermiso.AsEnumerable

            Return View()
        End Function

        <HttpPost()>
        Function Create(id_rol As Integer, id_permiso As Integer) As JsonResult
            Dim vDetalleRol As New DetalleRol
            With vDetalleRol
                .pId_rol = id_rol
                .pId_permiso = id_permiso
                .InsertarDetalleRol()
            End With
            Return Json("")
        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult
            Dim vDetalleRol As New DataTable
            vDetalleRol = DetalleRol.RecuperarDetalleRol(id)
            Return Json(JsonConvert.SerializeObject(vDetalleRol))
        End Function

        <HttpPost()>
        Function Delete(id_rol As Integer, id_permiso As Integer) As JsonResult
            Dim vDetalleRol As New DetalleRol
            With vDetalleRol
                .pId_rol = id_rol
                .pId_permiso = id_permiso
                .EliminarDetalleRol()
            End With
            Return Json("")
        End Function

    End Class
End Namespace