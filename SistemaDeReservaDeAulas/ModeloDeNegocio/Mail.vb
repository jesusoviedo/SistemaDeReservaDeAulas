﻿Imports System.Net.Mail
Imports System.Threading

Public Class Mail

    Private cuerpoMensaje As String
    Private emailDestinatario As String

    Private Sub SendMail()
        Thread.Sleep(3000)
        Dim correo As New MailMessage
        Dim smtp As New SmtpClient()

        correo.To.Add(emailDestinatario)
        correo.Body = cuerpoMensaje

        correo.From = New MailAddress("reservaaula2018@gmail.com", "Sistema de Reserva de Aulas", System.Text.Encoding.UTF8)
        correo.SubjectEncoding = System.Text.Encoding.UTF8
        correo.Subject = "Notificacion de Reserva de Aulas"

        correo.BodyEncoding = System.Text.Encoding.UTF8
        correo.IsBodyHtml = True
        correo.Priority = MailPriority.High

        smtp.Credentials = New System.Net.NetworkCredential("reservaaula2018@gmail.com", "45jj.55bhh")
        smtp.Port = 587
        smtp.Host = "smtp.gmail.com"
        smtp.EnableSsl = True

        smtp.Send(correo)

    End Sub

    Public Sub EnvioMail(id_reserva As Integer, operacion As String)
        Dim vReserva As New Reserva
        Dim vAula As New Aula
        Dim vUsuario As New Usuario
        Dim vPersona As New Persona

        Dim vEstado As String

        Dim reserva As Reserva
        Dim aula As Aula
        Dim usuario As Usuario
        Dim persona As Persona

        reserva = vReserva.RecuperarReserva(id_reserva)
        aula = vAula.RecuperarAula(reserva.pId_aula)
        usuario = vUsuario.RecuperarUsuario(reserva.pId_usuario)
        persona = vPersona.RecuperarPersona(usuario.pId_persona)

        If reserva.pId_estado_reserva = "A" Then
            vEstado = "Aprobada"
        End If
        If reserva.pId_estado_reserva = "R" Then
            vEstado = "Rechazada"
        End If
        If reserva.pId_estado_reserva = "P" Then
            vEstado = "Recibida"
        End If
        If reserva.pId_estado_reserva = "X" Then
            vEstado = "Anulada"
        End If

        cuerpoMensaje = "<h3>Estimado Usuario</h3>" +
                    "<p>Le informamos que la solicitud de la reserva realizada para la fecha " +
                    reserva.pFecha_reserva + " (desde las " + reserva.pHora_inicio + " hasta las " +
                    reserva.pHora_fin + ") para el aula " + aula.pNro_aula + " fue <b><i>" +
                    vEstado + "</i></b> </p>"

        emailDestinatario = persona.pEmail


        Dim SendMailAsync As New Thread(AddressOf SendMail)
        SendMailAsync.Start()

    End Sub

    Public Sub EnvioMailPassword(user As String, pass As String, email As String)
        Dim url As String = "http://www.reservaaulasuaa.somee.com/Home/login"

        cuerpoMensaje = "<h3>Estimado Usuario</h3>" +
                    "<p>Le informamos que se ha generado las credenciales para acceder al Sistema de Reserva de Aulas.<br>" +
                    "<br><b>Usuario:<i>" + user + "</i></b>" +
                    "<br><b>Contraseña:<i>" + pass + "</i></b>" +
                    "<br><br><b><a href=""" + url + """>Ingresar</a></b>"

        emailDestinatario = email
        Dim SendMailAsync As New Thread(AddressOf SendMail)
        SendMailAsync.Start()
    End Sub

End Class