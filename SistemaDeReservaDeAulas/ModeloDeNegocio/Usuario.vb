Imports ModeloDeNegocio.Util
Public Class Usuario
    Inherits Persona

    Protected id_usuario As Integer
    Protected id_rol As Integer
    Protected id_persona As Integer
    Protected user_name As String
    Protected password As String

    Public Property pId_usuario As Integer
        Get
            Return id_usuario
        End Get
        Set(value As Integer)
            id_usuario = value
        End Set
    End Property

    Public Property pId_rol As Integer
        Get
            Return id_rol
        End Get
        Set(value As Integer)
            id_rol = value
        End Set
    End Property



    Public Property pUser_name As String
        Get
            Return user_name
        End Get
        Set(value As String)
            user_name = value
        End Set
    End Property

    Public Property pPassword As String
        Get
            Return password
        End Get
        Set(value As String)
            password = value
        End Set
    End Property

    Public Overrides Sub InsertarUsuario()
        Try
            gDatos.Ejecutar("SpInsertarUsuario", Me.id_rol, Me.id_persona, Me.user_name, Me.password)
        Catch ex As Exception
            Throw ex
        End Try
        MyBase.InsertarPersona()
    End Sub

    Public Overrides Sub ActualizarUsuario()
        Try
            gDatos.Ejecutar("SpActualizarUsuario", Me.id_rol, Me.id_persona, Me.user_name, Me.password, Me.id_usuario)
        Catch ex As Exception
            Throw ex
        End Try
        MyBase.ActualizarPersona()
    End Sub

    Public Overrides Sub EliminarUsuario()
        Try
            gDatos.Ejecutar("SpEliminarUsuario", Me.id_usuario)
        Catch ex As Exception
            Throw ex
        End Try
        'MyBase.EliminarPersona()
    End Sub

    Public Shared Function RecuperarUsuario() As DataTable
        Try
            Dim dtUsuario As New DataTable
            dtUsuario = gDatos.TraerDataTable("SpConsultarUsuario", 0)
            Return dtUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarUsuario(vId_usuario As Integer) As Usuario
        Try
            Dim dtUsuario As New DataTable
            dtUsuario = gDatos.TraerDataTable("SpConsultarUsuario", vId_usuario)
            If dtUsuario.Rows.Count > 0 Then
                Dim vUsuario As New Usuario

                With vUsuario
                    .id_usuario = dtUsuario.Rows(0).Item("id_usuario")
                    .id_rol = dtUsuario.Rows(0).Item("id_rol")
                    .user_name = dtUsuario.Rows(0).Item("user_name")
                    .password = dtUsuario.Rows(0).Item("password")
                    .id_persona = dtUsuario.Rows(0).Item("id_persona")
                    .pDocumento = dtUsuario.Rows(0).Item("documento")
                    .pId_tipo_doc = dtUsuario.Rows(0).Item("id_tipo_doc")
                    .pNombre = dtUsuario.Rows(0).Item("nombre")
                    .pApellido = dtUsuario.Rows(0).Item("apellido")
                    .pFecha_naci = dtUsuario.Rows(0).Item("fecha_naci")
                    .pEmail = dtUsuario.Rows(0).Item("email")
                End With



                Return vUsuario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
