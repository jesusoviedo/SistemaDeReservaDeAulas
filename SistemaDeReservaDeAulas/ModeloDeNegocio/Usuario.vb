Imports ModeloDeNegocio.Util
Public Class Usuario

    Private id_usuario As Integer
    Private id_rol As Integer
    Private id_persona As Integer
    Private user_name As String
    Private password As String
    Private id_dpto As Integer
    Private resultado As Integer
    Private nombre_rol As String
    Private nombre_persona As String

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

    Public Property pId_persona As Integer
        Get
            Return id_persona
        End Get
        Set(value As Integer)
            id_persona = value
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

    Public Property pId_dpto As Integer
        Get
            Return id_dpto
        End Get
        Set(value As Integer)
            id_dpto = value
        End Set
    End Property

    Public Property pResultado As Integer
        Get
            Return resultado
        End Get
        Set(value As Integer)
            resultado = value
        End Set
    End Property

    Public Property pNombre_rol As String
        Get
            Return nombre_rol
        End Get
        Set(value As String)
            nombre_rol = value
        End Set
    End Property

    Public Property pNombre_persona As String
        Get
            Return nombre_persona
        End Get
        Set(value As String)
            nombre_persona = value
        End Set
    End Property

    Public Sub InsertarUsuario()
        Try
            gDatos.Ejecutar("SpInsertarUsuario", Me.id_rol, Me.id_persona, Me.user_name, Me.password, Me.id_dpto)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarUsuario()
        Try
            gDatos.Ejecutar("SpActualizarUsuario", Me.id_rol, Me.id_persona, Me.user_name, Me.id_dpto, Me.id_usuario)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarUsuario()
        Try
            gDatos.Ejecutar("SpEliminarUsuario", Me.id_usuario)
        Catch ex As Exception
            Throw ex
        End Try
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
                    .id_persona = dtUsuario.Rows(0).Item("id_persona")
                    .id_dpto = dtUsuario.Rows(0).Item("id_dpto")
                End With
                Return vUsuario
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function Ingresar(vUser_name As String, vPassword As String) As Usuario
        Try
            Dim dtUsuario As New DataTable
            dtUsuario = gDatos.TraerDataTable("SpLoginUsuario", vUser_name, vPassword)
            If dtUsuario.Rows.Count > 0 Then
                Dim vUsuario As New Usuario

                With vUsuario
                    .id_usuario = dtUsuario.Rows(0).Item("id_usuario")
                    .id_rol = dtUsuario.Rows(0).Item("id_rol")
                    .nombre_rol = dtUsuario.Rows(0).Item("nombre_rol")
                    .user_name = dtUsuario.Rows(0).Item("user_name")
                    .id_persona = dtUsuario.Rows(0).Item("id_persona")
                    .id_dpto = dtUsuario.Rows(0).Item("id_dpto")
                    .nombre_persona = dtUsuario.Rows(0).Item("nombre")
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
