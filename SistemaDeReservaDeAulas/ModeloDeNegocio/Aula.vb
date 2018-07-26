Imports ModeloDeNegocio.Util

Public Class Aula

    Private id_aula As Integer
    Private nro_aula As String
    Private id_tipo_aula As Integer
    Private id_piso As Integer
    Private posee_proyector As String
    Private capacidad As Integer

    'propiedades 
    Public Property pId_aula As Integer
        Get
            Return id_aula
        End Get
        Set(value As Integer)
            id_aula = value
        End Set
    End Property

    Public Property pNro_aula As String
        Get
            Return nro_aula
        End Get
        Set(value As String)
            nro_aula = value
        End Set
    End Property

    Public Property pId_tipo_aula As Integer
        Get
            Return id_tipo_aula
        End Get
        Set(value As Integer)
            id_tipo_aula = value
        End Set
    End Property

    Public Property pId_piso As Integer
        Get
            Return id_piso
        End Get
        Set(value As Integer)
            id_piso = value
        End Set
    End Property

    Public Property pPosee_proyector As String
        Get
            Return posee_proyector
        End Get
        Set(value As String)
            posee_proyector = value
        End Set
    End Property

    Public Property pCapacidad As Integer
        Get
            Return capacidad
        End Get
        Set(value As Integer)
            capacidad = value
        End Set
    End Property

    'metodos
    Public Sub InsertarAula()
        Try
            gDatos.Ejecutar("SpInsertarAula",
                            Me.nro_aula,
                            Me.id_tipo_aula,
                            Me.id_piso,
                            Me.posee_proyector,
                            Me.capacidad
                            )
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub ActualizarAula()
        Try
            gDatos.Ejecutar("SpActualizarAula",
                            Me.nro_aula,
                            Me.id_tipo_aula,
                            Me.id_piso,
                            Me.posee_proyector,
                            Me.capacidad,
                            Me.id_aula
)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub EliminarAula()
        Try
            gDatos.Ejecutar("SpEliminarAula", Me.id_aula)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function RecuperarAula() As DataTable
        Try
            Dim dtAula As New DataTable
            dtAula = gDatos.TraerDataTable("SpConsultarAula", 0)
            Return dtAula
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function RecuperarAula(vId_aula As Integer) As Aula
        Try
            Dim dtAula As New DataTable
            dtAula = gDatos.TraerDataTable("SpConsultarAula", vId_aula)
            If dtAula.Rows.Count > 0 Then
                Dim vAula As New Aula
                With vAula
                    .id_aula = dtAula.Rows(0).Item("id_aula")
                    .nro_aula = dtAula.Rows(0).Item("nro_aula")
                    .id_tipo_aula = dtAula.Rows(0).Item("id_tipo_aula")
                    .id_piso = dtAula.Rows(0).Item("id_piso")
                    .posee_proyector = dtAula.Rows(0).Item("posee_proyector")
                    .capacidad = dtAula.Rows(0).Item("capacidad")
                End With
                Return vAula
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
