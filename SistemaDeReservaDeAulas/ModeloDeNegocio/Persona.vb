Imports ModeloDeNegocio.Util

Public MustInherit Class Persona
    Private id_persona As Integer
    Private documento As String
    Private id_tipo_doc As Integer
    Private nombre As String
    Private apellido As String
    Private fecha_naci As Date
    Private email As String

    Public Property pId_persona As Integer
        Get
            Return id_persona
        End Get
        Set(value As Integer)
            id_persona = value
        End Set
    End Property

    Public Property pDocumento As String
        Get
            Return documento
        End Get
        Set(value As String)
            documento = value
        End Set
    End Property

    Public Property pId_tipo_doc As Integer
        Get
            Return id_tipo_doc
        End Get
        Set(value As Integer)
            id_tipo_doc = value
        End Set
    End Property

    Public Property pNombre As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property pApellido As String
        Get
            Return apellido
        End Get
        Set(value As String)
            apellido = value
        End Set
    End Property

    Public Property pFecha_naci As Date
        Get
            Return fecha_naci
        End Get
        Set(value As Date)
            fecha_naci = value
        End Set
    End Property

    Public Property pEmail As String
        Get
            Return email
        End Get
        Set(value As String)
            email = value
        End Set
    End Property

    Public Sub InsertarPersona()
        Try
            gDatos.Ejecutar("SpInsertarPersona", Me.documento, Me.id_tipo_doc, Me.nombre, Me.apellido, Me.fecha_naci, Me.email)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Overridable Sub InsertarProfesor()

    End Sub
    Public Overridable Sub ActualizarProfesor()

    End Sub
    Public Overridable Sub EliminarProfesor()

    End Sub

    Public Overridable Sub InsertarUsuario()

    End Sub
    Public Overridable Sub ActualizarUsuario()

    End Sub
    Public Overridable Sub EliminarUsuario()

    End Sub


    Public Sub ActualizarPersona()
        Try
            gDatos.Ejecutar("SpActualizarPersona", Me.documento, Me.id_tipo_doc, Me.nombre, Me.apellido, Me.fecha_naci, Me.email, Me.id_persona)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarPersona()
        Try
            gDatos.Ejecutar("SpEliminarPersona", Me.id_persona)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarPersona() As DataTable
        Try
            Dim dtPersona As New DataTable
            dtPersona = gDatos.TraerDataTable("SpConsultarPersona", 0)
            Return dtPersona
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Public Function RecuperarPersona(vId_persona As Integer) As Persona
    '    Try
    '        Dim dtPersona As New DataTable
    '        dtPersona = gDatos.TraerDataTable("SpConsultarPersona", vId_persona)
    '        If dtPersona.Rows.Count > 0 Then
    '            Dim vPersona As New Persona
    '            With vPersona
    '                .id_persona = dtPersona.Rows(0).Item("id_persona")
    '                .documento = dtPersona.Rows(0).Item("documento")
    '                .id_tipo_doc = dtPersona.Rows(0).Item("id_tipo_doc")
    '                .nombre = dtPersona.Rows(0).Item("nombre")
    '                .apellido = dtPersona.Rows(0).Item("apellido")
    '                .fecha_naci = dtPersona.Rows(0).Item("fecha_naci")
    '                .email = dtPersona.Rows(0).Item("email")

    '            End With
    '            Return vPersona
    '        Else
    '            Return Nothing
    '        End If
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Function


End Class
