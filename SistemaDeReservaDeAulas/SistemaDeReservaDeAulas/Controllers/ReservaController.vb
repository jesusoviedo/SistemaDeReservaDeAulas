Imports System.Web.Mvc
Imports ModeloDeNegocio
Imports Newtonsoft.Json

Namespace Controllers
    Public Class ReservaController
        Inherits Controller

        <HttpGet()>
        Function Index() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim dtTipoAula As New DataTable
                dtTipoAula = TipoAula.RecuperarTipoAula()
                ViewData("TiposAulas") = dtTipoAula.AsEnumerable

                Dim dtCurso As New DataTable
                dtCurso = Curso.RecuperarCurso()
                ViewData("Cursos") = dtCurso.AsEnumerable

                Dim dtInsumo As New DataTable
                dtInsumo = Insumo.RecuperarInsumo()
                ViewData("Insumos") = dtInsumo.AsEnumerable

                Return View()
            End If

        End Function

        <HttpPost()>
        Function ConsultarAulasDisponibles(fecha_reserva As String, id_tipo_aula As Integer, cantidadAlumno As Integer, hora_inicio As String, hora_fin As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vDetalleAulasDisponibles As New DataTable
                vDetalleAulasDisponibles = Reserva.AulasDisponibles(fecha_reserva, id_tipo_aula, cantidadAlumno, hora_inicio, hora_fin)
                Return Json(JsonConvert.SerializeObject(vDetalleAulasDisponibles))
            End If

        End Function

        <HttpPost()>
        Function Create(fecha_reserva As String, id_aula As Integer, nro_curso As Integer, observacion As String, hora_inicio As String, hora_fin As String, insumos() As String, cant_insumos() As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vOperacion As String = "S"
                Dim vMail As New Mail
                Dim vReserva As New Reserva
                With vReserva
                    .pFecha_reserva = fecha_reserva
                    .pId_aula = id_aula
                    .pNro_curso = nro_curso
                    .pObservacion = observacion
                    .pHora_inicio = hora_inicio
                    .pHora_fin = hora_fin
                    .pId_usuario = Session("id_usuario")
                    .InsertarReserva()
                End With

                If insumos IsNot Nothing Then
                    For indiceDetalleReserva As Integer = 0 To insumos.Length - 1
                        Dim vDetalleReserva As New DetalleReserva
                        With vDetalleReserva
                            .pId_reserva = vReserva.pId_reserva
                            .pId_insumo = insumos(indiceDetalleReserva)
                            .pCantidad = cant_insumos(indiceDetalleReserva)
                            .InsertarDetalleReserva()
                        End With
                    Next
                End If

                vMail.EnvioMail(vReserva.pId_reserva, vOperacion)

                Return Json("")
            End If

        End Function


        <HttpGet()>
        Function Pendiente() As ActionResult

            If Session("user") Is Nothing Then
                Return RedirectToAction("ErrorSesion", "Home")
            Else
                Dim dtReserva As New DataTable
                dtReserva = Reserva.ConsultarReservaPendientes(Session("id_dpto"))
                ViewData("ReservasPendientes") = dtReserva.AsEnumerable

                Dim dtEstadoReserva As New DataTable
                dtEstadoReserva = EstadoReserva.RecuperarEstadoReserva()
                ViewData("EstadosReservas") = dtEstadoReserva.AsEnumerable

                Return View()
            End If

        End Function

        <HttpPost()>
        Function Consult(id_reserva As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim vReserva As New Reserva
                vReserva = vReserva.RecuperarReserva(id_reserva)
                Return Json(JsonConvert.SerializeObject(vReserva))
            End If

        End Function

        <HttpPost()>
        Function AprobarRechazar(id_reserva As Integer, operacion As String) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Reserva.AutorizarRechazarReserva(id_reserva, operacion)

                Dim vMail As New Mail
                vMail.EnvioMail(id_reserva, operacion)

                Return Json("")
            End If

        End Function

        <HttpPost()>
        Function ConsultarCantidadReserva() As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Dim dtReserva As New DataTable
                dtReserva = Reserva.ConsultarCantidadReserva()
                Return Json(JsonConvert.SerializeObject(dtReserva))
            End If

        End Function

        <HttpPost()>
        Function Anular(id_reserva As Integer) As JsonResult

            If Session("user") Is Nothing Then
                Return Json("")
            Else
                Reserva.AnularReserva(id_reserva)

                Dim vMail As New Mail
                vMail.EnvioMail(id_reserva, "X")

                Return Json("")
            End If

        End Function

    End Class
End Namespace