Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class UsuarioController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            Dim dtUsuario As New DataTable
            dtUsuario = Usuario.RecuperarUsuario()
            ViewData("Usuarios") = dtUsuario.AsEnumerable

            Dim dtPersona As New DataTable
            dtPersona = Persona.RecuperarPersona()
            ViewData("Personas") = dtPersona.AsEnumerable

            Dim dtRol As New DataTable
            dtRol = Rol.RecuperarRol()
            ViewData("Roles") = dtRol.AsEnumerable

            Return View()
        End Function

        <HttpPost()>
        Function Create(id_rol As Integer, id_persona As Integer, user_name As String, password As String) As JsonResult
            Dim vUsuario As New Usuario
            With vUsuario
                .pId_rol = id_rol
                .pId_persona = id_persona
                .pUser_name = user_name
                .pPassword = password
                .InsertarUsuario()
            End With
            Return Json("")
        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult
            Dim vUsuario As New Usuario
            vUsuario = vUsuario.RecuperarUsuario(id)
            Return Json(JsonConvert.SerializeObject(vUsuario))
        End Function

        <HttpPost()>
        Function Edit(id_usuario As Integer, id_rol As Integer, id_persona As Integer, user_name As String) As JsonResult
            Dim vUsuario As New Usuario
            With vUsuario
                .pId_usuario = id_usuario
                .pId_rol = id_rol
                .pId_persona = id_persona
                .pUser_name = user_name
                .ActualizarUsuario()
            End With
            Return Json("")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vUsuario As New Usuario
            With vUsuario
                .pId_usuario = id
                .EliminarUsuario()
            End With
            Return RedirectToAction("Index")
        End Function


    End Class
End Namespace