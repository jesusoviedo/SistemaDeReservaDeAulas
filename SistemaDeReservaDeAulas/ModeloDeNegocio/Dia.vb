Imports ModeloDeNegocio.Util

Public Class Dia
    Private id_dia As Integer
    Private descripcion As String
    Private cod_dia As Char

    Public Property pId_dia As Integer
        Get
            Return id_dia
        End Get
        Set(value As Integer)
            id_dia = value
        End Set
    End Property

    Public Property pDescripcion As String
        Get
            Return descripcion
        End Get
        Set(value As String)
            descripcion = value
        End Set
    End Property

    Public Property pCod_dia As Char
        Get
            Return cod_dia
        End Get
        Set(value As Char)
            cod_dia = value
        End Set
    End Property

    'metodos
    Public Sub InsertarDia()
        Try
            gDatos.Ejecutar("SpInsertarDia", Me.descripcion, Me.cod_dia)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarDia()
        Try
            gDatos.Ejecutar("SpActualizarDia", Me.descripcion, Me.cod_dia,
            Me.id_dia)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarDia()
        Try
            gDatos.Ejecutar("SpEliminarDia", Me.id_dia)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarDia() As DataTable
        Try
            Dim dtDia As New DataTable
            dtDia = gDatos.TraerDataTable("SpConsultarDia", 0)
            Return dtDia
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarDia(vId_dia As Integer) As Dia
        Try
            Dim dtDia As New DataTable
            dtDia = gDatos.TraerDataTable("SpConsultarDia", vId_dia)
            If dtDia.Rows.Count > 0 Then
                Dim vDia As New Dia
                With vDia
                    .pId_dia = dtDia.Rows(0).Item("id_dia")
                    .pDescripcion = dtDia.Rows(0).Item("descripcion")
                    .pCod_dia = dtDia.Rows(0).Item("cod_dia")
                End With
                Return vDia
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
