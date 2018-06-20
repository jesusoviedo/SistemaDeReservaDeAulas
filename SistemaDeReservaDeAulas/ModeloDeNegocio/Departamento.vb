Imports ModeloDeNegocio.Util
Public Class Departamento
    Private id_dpto As Integer
    Private nombre_dpto As String
    Private id_facultad As Integer

    Public Property pId_dpto As Integer
        Get
            Return id_dpto
        End Get
        Set(value As Integer)
            id_dpto = value
        End Set
    End Property

    Public Property pNombre_dpto As String
        Get
            Return nombre_dpto
        End Get
        Set(value As String)
            nombre_dpto = value
        End Set
    End Property

    Public Property pId_facultad As Integer
        Get
            Return id_facultad
        End Get
        Set(value As Integer)
            id_facultad = value
        End Set
    End Property

    Public Sub InsertarDepartamento()
        Try
            gDatos.Ejecutar("SpInsertarDepartamento", Me.nombre_dpto, Me.id_facultad)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarDepartamento()
        Try
            gDatos.Ejecutar("SpActualizarDepartamento", Me.nombre_dpto, Me.id_facultad, Me.id_dpto)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarDepartamento()
        Try
            gDatos.Ejecutar("SpEliminarDepartamento", Me.id_dpto)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarDepartamento() As DataTable
        Try
            Dim dtDpto As New DataTable
            dtDpto = gDatos.TraerDataTable("SpConsultarDepartamento", 0)
            Return dtDpto
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarDepartamento(vId_dpto As Integer) As Departamento
        Try
            Dim dtDpto As New DataTable
            dtDpto = gDatos.TraerDataTable("SpConsultarDepartamento", vId_dpto)
            If dtDpto.Rows.Count > 0 Then
                Dim vDpto As New Departamento
                With vDpto
                    .id_dpto = dtDpto.Rows(0).Item("id_dpto")
                    .nombre_dpto = dtDpto.Rows(0).Item("nombre_dpto")
                    .id_facultad = dtDpto.Rows(0).Item("id_facultad")
                End With
                Return vDpto
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
