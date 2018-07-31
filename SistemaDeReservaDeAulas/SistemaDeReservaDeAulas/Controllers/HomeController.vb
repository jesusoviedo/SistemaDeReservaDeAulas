Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class HomeController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                If Session("rol") = "Profesor" Then

                    Dim dtReservaSolicitas As New DataTable
                    dtReservaSolicitas = Reserva.ConsultarReservaPorUsuario(Session("id_usuario"), "P")
                    ViewData("ReservasSolicitas") = dtReservaSolicitas.AsEnumerable

                    Dim dtReservaAprovada As New DataTable
                    dtReservaAprovada = Reserva.ConsultarReservaPorUsuario(Session("id_usuario"), "A")
                    ViewData("ReservasAprovadas") = dtReservaAprovada.AsEnumerable

                    Dim dtReservaRechazada As New DataTable
                    dtReservaRechazada = Reserva.ConsultarReservaPorUsuario(Session("id_usuario"), "R")
                    ViewData("ReservasRechazadas") = dtReservaRechazada.AsEnumerable

                    Dim dtReservaAnulada As New DataTable
                    dtReservaAnulada = Reserva.ConsultarReservaPorUsuario(Session("id_usuario"), "X")
                    ViewData("ReservasAnuladas") = dtReservaAnulada.AsEnumerable

                End If

                If Session("rol") = "Aprovador" Or Session("rol") = "Administrador" Then

                    Dim dtReservaSolicitas As New DataTable
                    dtReservaSolicitas = Reserva.ConsultarReservaPorDepartamento(Session("id_dpto"), "P")
                    ViewData("ReservasSolicitas") = dtReservaSolicitas.AsEnumerable

                    Dim dtReservaAprovada As New DataTable
                    dtReservaAprovada = Reserva.ConsultarReservaPorDepartamento(Session("id_dpto"), "A")
                    ViewData("ReservasAprovadas") = dtReservaAprovada.AsEnumerable

                    Dim dtReservaRechazada As New DataTable
                    dtReservaRechazada = Reserva.ConsultarReservaPorDepartamento(Session("id_dpto"), "R")
                    ViewData("ReservasRechazadas") = dtReservaRechazada.AsEnumerable

                End If

                Return View()

            End If

        End Function

        <HttpGet()>
        Function CerrarSesion() As ActionResult

            If Session("user") IsNot Nothing Then
                Session.Contents.RemoveAll()
            End If

            Return RedirectToAction("Login", "Home")

        End Function

        <HttpGet()>
        Function Login() As ActionResult

            If TempData("mensaje") IsNot Nothing Then
                ViewBag.mensaje = TempData("mensaje")
            End If

            Return View()
        End Function

        <HttpGet()>
        Function ErrorSesion() As ActionResult
            Return View()
        End Function

        <HttpPost()>
        Function Ingresar(form As FormCollection) As ActionResult

            Util.inicializaSesion(ConfigurationManager.AppSettings("datoServidor"), ConfigurationManager.AppSettings("datoBase"), ConfigurationManager.AppSettings("datoUsuario"), ConfigurationManager.AppSettings("datoContrasenha"))

            Dim vUsuario As New Usuario
            Dim vUser_name As String
            Dim vPassword As String
            TempData("mensaje") = Nothing

            vUser_name = form("txtUser_name")
            vPassword = form("txtPassword")
            vUsuario = vUsuario.Ingresar(vUser_name, vPassword)

            If vUsuario Is Nothing Then
                TempData("mensaje") = "Usuario o contraseña incorrecta"
                Return RedirectToAction("Login", "Home")
            Else
                Session("id_usuario") = vUsuario.pId_usuario
                Session("user") = vUsuario.pUser_name
                Session("nombre") = vUsuario.pNombre_persona
                Session("id_rol") = vUsuario.pId_rol
                Session("rol") = vUsuario.pNombre_rol
                Session("id_dpto") = vUsuario.pId_dpto
                Session("nombre_dpto") = vUsuario.pNombre_dpto
                Return RedirectToAction("Index", "Home")
            End If

            'para enviar mail
            'Dim vmail As New Mail
            'vmail.EnvioMail()

        End Function


    End Class
End Namespace