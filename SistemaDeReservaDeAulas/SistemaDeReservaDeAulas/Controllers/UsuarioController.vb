Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class UsuarioController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else

                Dim dtUsuario As New DataTable
                dtUsuario = Usuario.RecuperarUsuario()
                ViewData("Usuarios") = dtUsuario.AsEnumerable

                Dim dtPersona As New DataTable
                dtPersona = Persona.RecuperarPersona()
                ViewData("Personas") = dtPersona.AsEnumerable

                Dim dtRol As New DataTable
                dtRol = Rol.RecuperarRol()
                ViewData("Roles") = dtRol.AsEnumerable

                Dim dtDpto As New DataTable
                dtDpto = Departamento.RecuperarDepartamento()
                ViewData("Departamentos") = dtDpto.AsEnumerable

                Return View()
            End If

        End Function

        <HttpPost()>
        Function Create(id_rol As String, id_persona As Integer, user_name As String, id_dpto As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vPass As String = Usuario.CrearPassword(5)
                Dim vUsuario As New Usuario
                With vUsuario
                    .pId_rol = id_rol
                    .pId_persona = id_persona
                    .pUser_name = user_name
                    .pPassword = vPass
                    .pId_dpto = id_dpto
                    .InsertarUsuario()
                End With

                Dim vPersona As New Persona
                Dim vEmail As New Mail
                vEmail.EnvioMailPassword(user_name, vPass, vPersona.RecuperarPersona(id_persona).pEmail)

                Return Json("")
            End If

        End Function

        <HttpPost()>
        Function Consult(id As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vUsuario As New Usuario
                vUsuario = vUsuario.RecuperarUsuario(id)
                Return Json(JsonConvert.SerializeObject(vUsuario))
            End If

        End Function

        <HttpPost()>
        Function Edit(id_usuario As Integer, id_rol As String, id_persona As Integer, user_name As String, id_dpto As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vUsuario As New Usuario
                With vUsuario
                    .pId_usuario = id_usuario
                    .pId_rol = id_rol
                    .pId_persona = id_persona
                    .pUser_name = user_name
                    .pId_dpto = id_dpto
                    .ActualizarUsuario()
                End With
                Return Json("")
            End If

        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim vUsuario As New Usuario
                With vUsuario
                    .pId_usuario = id
                    .EliminarUsuario()
                End With
                Return RedirectToAction("Index")
            End If

        End Function

        <HttpPost()>
        Function ActualizarPassword(password As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Usuario.ActualizarPassword(Session("id_usuario"), password)
                Return Json("")
            End If

        End Function

    End Class
End Namespace