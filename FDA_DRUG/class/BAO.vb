Imports System.Data
Imports System.Data.SqlClient
Imports System.Web

Imports System.IO
Imports System.Xml.Serialization
Imports iTextSharp.text.pdf
Imports System.Xml
Namespace BAO

#Region "old"
    Public Class FIELDS_ADDR_NAME

        Private _Txt_CitiID As String
        Public Property Txt_CitiID() As String
            Get
                Return _Txt_CitiID
            End Get
            Set(ByVal value As String)
                _Txt_CitiID = value
            End Set
        End Property

        Private _Txt_HouseNo As String
        Public Property Txt_HouseNo() As String
            Get
                Return _Txt_HouseNo
            End Get
            Set(ByVal value As String)
                _Txt_HouseNo = value
            End Set
        End Property

        Private _Txt_Name As String
        Public Property Txt_Name() As String
            Get
                Return _Txt_Name
            End Get
            Set(ByVal value As String)
                _Txt_Name = value
            End Set
        End Property


        Private _Txt_Address As String
        Public Property Txt_Address() As String
            Get
                Return _Txt_Address
            End Get
            Set(ByVal value As String)
                _Txt_Address = value
            End Set
        End Property

        Private _Txt_Name_Location As String
        Public Property Txt_Name_Location() As String
            Get
                Return _Txt_Name_Location
            End Get
            Set(ByVal value As String)
                _Txt_Name_Location = value
            End Set
        End Property


        Private _Txt_Tel As String
        Public Property Txt_Tel() As String
            Get
                Return _Txt_Tel
            End Get
            Set(ByVal value As String)
                _Txt_Tel = value
            End Set
        End Property


    End Class


    Public Class FIELDS_RECEIVE_NORMAL

        Private _Txt_Date_Expire As String
        Public Property Txt_Date_Expire() As String
            Get
                Return _Txt_Date_Expire
            End Get
            Set(ByVal value As String)
                _Txt_Date_Expire = value
            End Set
        End Property

        Private _Txt_Remark As String
        Public Property Txt_Remark() As String
            Get
                Return _Txt_Remark
            End Get
            Set(ByVal value As String)
                _Txt_Remark = value
            End Set
        End Property

        Private _Txt_Machine As String
        Public Property Txt_Machine() As String
            Get
                Return _Txt_Machine
            End Get
            Set(ByVal value As String)
                _Txt_Machine = value
            End Set
        End Property


        Private _Txt_Person As String
        Public Property Txt_Person() As String
            Get
                Return _Txt_Person
            End Get
            Set(ByVal value As String)
                _Txt_Person = value
            End Set
        End Property

        Private _DD_Style As String
        Public Property DD_Style() As String
            Get
                Return _DD_Style
            End Get
            Set(ByVal value As String)
                _DD_Style = value
            End Set
        End Property

        Private _Txt_Status As String
        Public Property Txt_Status() As String
            Get
                Return _Txt_Status
            End Get
            Set(ByVal value As String)
                _Txt_Status = value
            End Set
        End Property
    End Class

    Public Class Fields_Food_Kind

        Private _FOOD_KIND_ID As String
        Public Property FOOD_KIND_ID() As String
            Get
                Return _FOOD_KIND_ID
            End Get
            Set(ByVal value As String)
                _FOOD_KIND_ID = value
            End Set
        End Property

        Private _FOOD_KIND_NAME As String
        Public Property FOOD_KIND_NAME() As String
            Get
                Return _FOOD_KIND_NAME
            End Get
            Set(ByVal value As String)
                _FOOD_KIND_NAME = value
            End Set
        End Property

    End Class


    Public Class Fields_Food_Process

        Private _FOOD_PROCESS_ID As String
        Public Property FOOD_PROCESS_ID() As String
            Get
                Return _FOOD_PROCESS_ID
            End Get
            Set(ByVal value As String)
                _FOOD_PROCESS_ID = value
            End Set
        End Property

        Private _FOOD_PROCESS_NAME As String
        Public Property FOOD_PROCESS_NAME() As String
            Get
                Return _FOOD_PROCESS_NAME
            End Get
            Set(ByVal value As String)
                _FOOD_PROCESS_NAME = value
            End Set
        End Property

    End Class

    Public Class Fields_Food_Format

        Private _FOOD_Format_ID As String
        Public Property FOOD_Format_ID() As String
            Get
                Return _FOOD_Format_ID
            End Get
            Set(ByVal value As String)
                _FOOD_Format_ID = value
            End Set
        End Property

        Private _FOOD_Format_NAME As String
        Public Property FOOD_Format_NAME() As String
            Get
                Return _FOOD_Format_NAME
            End Get
            Set(ByVal value As String)
                _FOOD_Format_NAME = value
            End Set
        End Property

    End Class

    Public Class Fields_Food_Other

        Private _FOOD_OTHER_ID As String
        Public Property FOOD_OTHER_ID() As String
            Get
                Return _FOOD_OTHER_ID
            End Get
            Set(ByVal value As String)
                _FOOD_OTHER_ID = value
            End Set
        End Property

        Private _FOOD_OTHER_NAME As String
        Public Property FOOD_OTHER_NAME() As String
            Get
                Return _FOOD_OTHER_NAME
            End Get
            Set(ByVal value As String)
                _FOOD_OTHER_NAME = value
            End Set
        End Property

    End Class


    Public Class Fields_Food_Type
        Private _Txt_Type_Food As String
        Public Property Txt_Type_Food() As String
            Get
                Return _Txt_Type_Food
            End Get
            Set(ByVal value As String)
                _Txt_Type_Food = value
            End Set
        End Property

    End Class


    Public Class Fields_Food_Keep
        Private _Txt_Food_Keep As String
        Public Property Txt_Food_Keep() As String
            Get
                Return _Txt_Food_Keep
            End Get
            Set(ByVal value As String)
                _Txt_Food_Keep = value
            End Set
        End Property


    End Class

    Public Class Fields_Person_List
        Private _Txt_Person_List As String
        Public Property Txt_Person_List() As String
            Get
                Return _Txt_Person_List
            End Get
            Set(ByVal value As String)
                _Txt_Person_List = value
            End Set
        End Property
    End Class
    Public Class ClsDBSqlCommand
        Public dt As New DataTable
        Dim rdr As SqlDataReader
        'Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LGTFOODConnectionString").ConnectionString)
        Dim conn As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LGT_DRUGConnectionString").ConnectionString)
        Dim conn_CPN As New SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("LGTCPNConnectionString").ConnectionString)
        Dim SqlCmd As SqlCommand
        Dim dtAdapter As SqlDataAdapter
        Dim objds As New DataSet
        Dim strSQL As String = String.Empty
        Public Sub FAGenID(ByVal colum As String, ByVal table As String)
            Dim year As String = Date.Today.Year.ToString()
            If (Integer.Parse(year) < 2500) Then
                Dim intyear As Integer = Integer.Parse(year) + 543
                year = intyear.ToString()
            End If
            strSQL = "SELECT  MAX([" + colum + "]) FROM [fda].[" + table + "] "
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            'SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = strName
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
        End Sub
        Public Sub FAGenID_CPN(ByVal colum As String, ByVal table As String)
            Dim year As String = Date.Today.Year.ToString()
            If (Integer.Parse(year) < 2500) Then
                Dim intyear As Integer = Integer.Parse(year) + 543
                year = intyear.ToString()
            End If
            strSQL = "SELECT  MAX([" + colum + "]) FROM [dbo].[" + table + "] "
            SqlCmd = New SqlCommand(strSQL, conn_CPN)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            'SqlCmd.CommandType = CommandType.StoredProcedure
            'SqlCmd.Parameters.Add("@Name", SqlDbType.NVarChar).Value = strName
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
        End Sub

        Public Sub Get_User(ByVal User As String)
            strSQL = "select * from  OPENQUERY(LGTCPN,'select v_usrlogin.*,decrypt_char(v_usrlogin.pwd,v_usrlogin.usrid) as pass,sysusrid.lcnsid "
            strSQL += "       from v_usrlogin,outer sysdvn, sysusrid "
            strSQL += "        where v_usrlogin.divcode = sysdvn.dvcd And "
            strSQL += "       v_usrlogin.usrid = sysusrid.usrid;')"
            strSQL += "       Where usrid = '" + User.Trim() + "' "
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
        End Sub
        Public Sub CountLcnno()
            strSQL = "SELECT  MAX([lcnno]) FROM [FDA_FOOD].[fda].[falcn] "
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
        End Sub
        Public Sub CountRegntfno()
            strSQL = "SELECT  MAX([regntfno]) FROM [FDA_FOOD].[fda].[fregntf] "
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
        End Sub

        Public Sub GetDataby_lcnsid_thanm(ByVal lcnsid As Integer)
            strSQL = "SP_MEMBER_LCNSID_THANM"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            ' sqlcmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = 2
            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid
            'sqlcmd.Parameters.Add("@lcnscd", SqlDbType.NVarChar).Value = intlctCode
            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub GetDataby_lcnsid_type_status(ByVal lcnsid As Integer, ByVal type As Integer)

            strSQL = "SP_MEMBER_LCNSID_TYPE_STATUS"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            ' sqlcmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = 2
            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid
            SqlCmd.Parameters.Add("@type", SqlDbType.VarChar).Value = type
            'sqlcmd.Parameters.Add("@lcnscd", SqlDbType.NVarChar).Value = intlctCode

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub GetDataby_thanm_thanm(ByVal thanm As String)

            strSQL = "SP_MEMBER_THANM_THANM"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            ' sqlcmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = 2
            SqlCmd.Parameters.Add("@thanm", SqlDbType.VarChar).Value = thanm

            'sqlcmd.Parameters.Add("@lcnscd", SqlDbType.NVarChar).Value = intlctCode

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub



        Public Sub GetDataby_lcnsid_addr(ByVal lcnsid As Integer)

            strSQL = "SP_MEMBER_LCNSID_ADDR"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            ' sqlcmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = 2
            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid

            'sqlcmd.Parameters.Add("@lcnscd", SqlDbType.NVarChar).Value = intlctCode

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub


        Public Sub SP_MEMBER_LCNSID_FULLADDR(ByVal lcnsid As Integer)

            strSQL = "SP_MEMBER_LCNSID_FULLADDR"
            SqlCmd = New SqlCommand(strSQL, conn_CPN)
            If (conn_CPN.State = ConnectionState.Open) Then
                conn_CPN.Close()
            End If
            conn_CPN.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn_CPN.Close()

        End Sub




        Public Sub GetDataby_lcnsid_dalcn(ByVal lcnsid As Integer)

            strSQL = "SP_DRUG_DALCN_LCNSID"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            ' sqlcmd.Parameters.Add("@id", SqlDbType.NVarChar).Value = 2
            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid

            'sqlcmd.Parameters.Add("@lcnscd", SqlDbType.NVarChar).Value = intlctCode

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub
        Public Sub GetDataby_lcnno_dalcn(ByVal lcnno As Integer)

            strSQL = "SP_DRUG_DALCN_LCNNO"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure
            SqlCmd.Parameters.Add("@lcnno", SqlDbType.VarChar).Value = lcnno


            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub GetDataby_lcnsid_darqt(ByVal lcnsid As Integer)

            strSQL = "SP_DRUG_DARQT_LCNSID"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid



            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

        Public Sub GetDataby_lcnno_darqt(ByVal lcnno As Integer, ByVal lcnsid As Integer)

            strSQL = "SP_DRUG_DARQT_LCNNO"
            SqlCmd = New SqlCommand(strSQL, conn)
            If (conn.State = ConnectionState.Open) Then
                conn.Close()
            End If
            conn.Open()
            SqlCmd.CommandType = CommandType.StoredProcedure

            SqlCmd.Parameters.Add("@lcnno", SqlDbType.VarChar).Value = lcnno
            SqlCmd.Parameters.Add("@lcnsid", SqlDbType.VarChar).Value = lcnsid

            dtAdapter = New SqlDataAdapter(SqlCmd)
            dtAdapter.Fill(dt)
            conn.Close()

        End Sub

    End Class

    Public Class GenNumber

       
    End Class
#End Region





End Namespace