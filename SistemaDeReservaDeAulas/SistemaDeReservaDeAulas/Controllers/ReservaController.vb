Imports System.Web.Mvc
Imports ModeloDeNegocio

Namespace Controllers
    Public Class ReservaController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult
            Dim dtReserva As New DataTable
            dtReserva = Reserva.RecuperarReserva()
            ViewData("Reservas") = dtReserva.AsEnumerable

            Dim dtEstadoReserva As New DataTable
            dtEstadoReserva = EstadoReserva.RecuperarEstadoReserva()
            ViewData("EstadosReservas") = dtEstadoReserva.AsEnumerable

            Return View()
        End Function

        <HttpGet()>
        Function Create() As ActionResult

            Dim dtAula As New DataTable
            dtAula = Aula.RecuperarAula()
            ViewData("Aulas") = dtAula.AsEnumerable

            Dim dtCurso As New DataTable
            dtCurso = Curso.RecuperarCurso()
            ViewData("Cursos") = dtCurso.AsEnumerable

            Dim dtEstadoReserva As New DataTable
            dtEstadoReserva = EstadoReserva.RecuperarEstadoReserva()
            ViewData("EstadosReservas") = dtEstadoReserva.AsEnumerable

            'Dim dtUsuarios As New DataTable
            'dtUsuarios = Usuario.RecuperarEstadoReserva()
            'ViewData("Usuarios") = dtUsuarios.AsEnumerable

            Return View()
        End Function

        <HttpPost()>
        Function Create(form As FormCollection) As ActionResult
            Dim vReserva As New Reserva
            With vReserva
                .pFecha_reserva = form("txtFecha_reserva")
                .pId_aula = form("txtId_aula")
                .pNro_curso = form("txtNro_curso")
                .pObservacion = form("txtObservacion")
                .pHora_inicio = form("txtHora_inicio")
                .pHora_fin = form("txtHora_fin")
                .pId_estado_reserva = form("txtId_estado_reserva")
                .pId_usuario = form("txtId_usuario")
                .InsertarReserva()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Edit(id As Integer) As ActionResult

            Dim dtAula As New DataTable
            dtAula = Aula.RecuperarAula()
            ViewData("Aulas") = dtAula.AsEnumerable

            Dim dtCurso As New DataTable
            dtCurso = Curso.RecuperarCurso()
            ViewData("Cursos") = dtCurso.AsEnumerable

            Dim dtEstadoReserva As New DataTable
            dtEstadoReserva = EstadoReserva.RecuperarEstadoReserva()
            ViewData("EstadosReservas") = dtEstadoReserva.AsEnumerable

            'Dim dtUsuarios As New DataTable
            'dtUsuarios = Usuario.RecuperarEstadoReserva()
            'ViewData("Usuarios") = dtUsuarios.AsEnumerable

            Dim vReserva As New Reserva
            vReserva = vReserva.RecuperarReserva(id)

            Return View(vReserva)
        End Function

        <HttpPost()>
        Function Edit(form As FormCollection) As ActionResult
            Dim vReserva As New Reserva
            With vReserva
                .pId_reserva = form("txtId_reserva")
                .pFecha_reserva = form("txtFecha_reserva")
                .pId_aula = form("txtId_aula")
                .pNro_curso = form("txtNro_curso")
                .pObservacion = form("txtObservacion")
                .pHora_inicio = form("txtHora_inicio")
                .pHora_fin = form("txtHora_fin")
                .pId_estado_reserva = form("txtId_estado_reserva")
                .pId_usuario = form("txtId_usuario")
                .ActualizarReserva()
            End With
            Return RedirectToAction("Index")
        End Function

        <HttpGet()>
        Function Delete(id As Integer) As ActionResult
            Dim vReserva As New Reserva
            With vReserva
                .pId_reserva = id
                .EliminarReserva()
            End With
            Return RedirectToAction("Index")
        End Function

    End Class
End Namespace