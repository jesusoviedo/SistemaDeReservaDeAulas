Imports ModeloDeNegocio.Util

Public Class Facultad
    Private id_facultad As Integer
    Private nombre_facultad As String

    Public Property pId_facultad As Integer
        Get
            Return id_facultad
        End Get
        Set(value As Integer)
            id_facultad = value
        End Set
    End Property

    Public Property pNombre_facultad As String
        Get
            Return nombre_facultad
        End Get
        Set(value As String)
            nombre_facultad = value
        End Set
    End Property

    Public Sub InsertarFacultad()
        Try
            gDatos.Ejecutar("SpInsertarFacultad", Me.nombre_facultad)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarFacultad()
        Try
            gDatos.Ejecutar("SpActualizarFacultad", Me.nombre_facultad, Me.id_facultad)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarFacultad()
        Try
            gDatos.Ejecutar("SpEliminarFacultad", Me.id_facultad)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarFacultad() As DataTable
        Try
            Dim dtFacultad As New DataTable
            dtFacultad = gDatos.TraerDataTable("SpConsultarFacultad", 0)
            Return dtFacultad
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarFacultad(vId_facultad As Integer) As Facultad
        Try
            Dim dtFacultad As New DataTable
            dtFacultad = gDatos.TraerDataTable("SpConsultarFacultad", vId_facultad)
            If dtFacultad.Rows.Count > 0 Then
                Dim vFacultad As New Facultad
                With vFacultad
                    .id_facultad = dtFacultad.Rows(0).Item("id_facultad")
                    .nombre_facultad = dtFacultad.Rows(0).Item("nombre_facultad")
                End With
                Return vFacultad
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
