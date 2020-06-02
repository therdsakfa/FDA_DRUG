
Imports System.Data
Imports System.Data.SqlClient
Imports System.Web
Namespace BAO_FDA_CFS_CENTER
    Public Class FDA_CFS_CENTER
        Public Function Queryds(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_CFS_CENTERConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        '
        Public Sub Queryds_update(ByVal Commands As String)
            Dim objCmd As New SqlCommand
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_CFS_CENTERConnectionString").ConnectionString)
            MyConnection.Open()
            With objCmd
                .Connection = MyConnection
                .CommandText = Commands
                .CommandType = CommandType.Text
            End With
            Try
                objCmd.ExecuteNonQuery()
                MyConnection.Close()
            Catch ex As Exception
            End Try
        End Sub
        Public Function Queryds_active(ByVal Commands As String) As DataTable
            Dim dt As New DataTable
            Dim MyConnection As SqlConnection = New SqlConnection(ConfigurationManager.ConnectionStrings("FDA_CFS_CENTERConnectionString").ConnectionString)
            Dim mySqlDataAdapter As SqlDataAdapter = New SqlDataAdapter(Commands, MyConnection)
            mySqlDataAdapter.Fill(dt)
            MyConnection.Close()
            Return dt
        End Function
        Public Sub SP_SET_UPDATE_PAYMENT_CER(ByVal IDA As Integer, ByVal PROCESS_ID As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_SET_UPDATE_PAYMENT_CER] @IDA=" & IDA & " ,@PROCESS_ID=" & PROCESS_ID
            dt = Queryds(command)

        End Sub
        Public Function SP_GET_IDA_NCT_FROM_FEE(ByVal ref01 As String, ref02 As String) As Integer
            Dim dt As New DataTable
            Dim IDA As Integer = 0
            Dim command As String = " "
            command = " exec [dbo].[SP_GET_IDA_NCT_FROM_FEE] @ref01='" & ref01 & "', @ref02='" & ref02 & "' "
            dt = Queryds(command)
            For Each dr As DataRow In dt.Rows
                IDA = dr("IDA")
            Next

            Return IDA
        End Function

        Public Sub SP_SET_UPDATE_PAYMENT_CER_DRUG(ByVal IDA As Integer)
            Dim dt As New DataTable
            Dim command As String = " "
            command = " exec [dbo].[SP_SET_UPDATE_PAYMENT_CER_DRUG] @IDA=" & IDA
            Queryds_update(command)
        End Sub
    End Class
End Namespace


