Imports System
Imports System.Collections.Generic 
Imports System.Text

Namespace ReservaAula.Datos
    Public Class DatosSQLServer
        Inherits gDatos
        Shared ColComandos As New System.Collections.Hashtable()

        Public Overloads Overrides Property CadenaConexion() As String
            Get
                If Me.mCadenaConexion.Length = 0 Then
                    If Me.mBase.Length <> 0 AndAlso Me.mServidor.Length <> 0 Then
                        Dim sCadena As New System.Text.StringBuilder("")
                        sCadena.Append("data source=<SERVIDOR>;")
                        sCadena.Append("initial catalog=<BASE>;password=<PASSWORD>;")
                        sCadena.Append("persist security info=True;")
                        sCadena.Append("user id=<USER>;packet size=4096")
                        sCadena.Replace("<SERVIDOR>", Me.Servidor)
                        sCadena.Replace("<BASE>", Me.Base)
                        sCadena.Replace("<USER>", Me.Ususario)
                        sCadena.Replace("<PASSWORD>", Me.Password)

                        Return sCadena.ToString()
                    Else
                        Dim Ex As New System.Exception("No se puede establecer la cadena de conexión")
                        Throw Ex
                    End If
                End If
                Return Nothing
            End Get
            Set(ByVal value As String)
                Me.mCadenaConexion = value
            End Set
        End Property

        Protected Overloads Overrides Sub CargarParametros(ByVal Com As System.Data.IDbCommand, ByVal Args As Object())
            Dim Limite As Integer = Com.Parameters.Count
            For i As Integer = 1 To Com.Parameters.Count - 1
                Dim P As System.Data.SqlClient.SqlParameter = DirectCast(Com.Parameters(i), System.Data.SqlClient.SqlParameter)
                If i <= Args.Length Then
                    P.Value = Args(i - 1)
                Else
                    P.Value = Nothing
                End If
            Next
        End Sub

        Protected Overloads Overrides Function Comando(ByVal ProcedimientoAlmacenado As String) As System.Data.IDbCommand
            Dim Com As System.Data.SqlClient.SqlCommand
            If ColComandos.Contains(ProcedimientoAlmacenado) Then
                Com = DirectCast(ColComandos(ProcedimientoAlmacenado), System.Data.SqlClient.SqlCommand)
            Else
                Dim Con2 As New System.Data.SqlClient.SqlConnection(Me.CadenaConexion)
                Con2.Open()
                Com = New System.Data.SqlClient.SqlCommand(ProcedimientoAlmacenado, Con2)
                Com.CommandType = System.Data.CommandType.StoredProcedure
                System.Data.SqlClient.SqlCommandBuilder.DeriveParameters(Com)
                Con2.Close()
                Con2.Dispose()

                ColComandos.Add(ProcedimientoAlmacenado, Com)
            End If
            Com.Connection = DirectCast(Me.Conexion, System.Data.SqlClient.SqlConnection)
            Com.Transaction = DirectCast(Me.mTransaccion, System.Data.SqlClient.SqlTransaction)
            Return DirectCast(Com, System.Data.IDbCommand)
        End Function

        Protected Overloads Overrides Function CrearConexion(ByVal CadenaConexion As String) As System.Data.IDbConnection
            Return DirectCast(New System.Data.SqlClient.SqlConnection(CadenaConexion), System.Data.IDbConnection)
        End Function

        Protected Overloads Overrides Function CrearDataAdapter(ByVal ProcedimientoAlmacenado As String, ByVal ParamArray Args As Object()) As System.Data.IDataAdapter
            Dim Da As New System.Data.SqlClient.SqlDataAdapter(DirectCast(Comando(ProcedimientoAlmacenado), System.Data.SqlClient.SqlCommand))
            If Args.Length <> 0 Then
                CargarParametros(Da.SelectCommand, Args)
            End If
            Return DirectCast(Da, System.Data.IDataAdapter)
        End Function

        Public Sub New()
            ' 
            ' TODO: agregar aquí la lógica del constructor 
            ' 
            Me.Base = "DataMex"
            Me.Servidor = "DatamexDesa"
            Me.Ususario = "sa"
            Me.Password = "soloyose"
        End Sub

        Public Sub New(ByVal CadenaConexion As String)
            Me.CadenaConexion = CadenaConexion
        End Sub
        Public Sub New(ByVal Servidor As String, ByVal Base As String)
            Me.Base = Base
            Me.Servidor = Servidor
        End Sub
        Public Sub New(ByVal Servidor As String, ByVal Base As String, ByVal User As String, ByVal Password As String)
            Me.Base = Base
            Me.Servidor = Servidor
            Me.Ususario = User
            Me.Password = Password
        End Sub

    End Class
End Namespace