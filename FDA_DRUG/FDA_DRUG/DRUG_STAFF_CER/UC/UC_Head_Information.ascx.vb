Public Class UC_Head_Information
    Inherits System.Web.UI.UserControl
    Private _IDA As String
    Private _TR_ID As String
    Private _FK_IDA As String
    Private _CLS As New CLS_SESSION
    Private _ProcessID As String
    Private _YEARS As String

    Sub RunSession()
        Try
            _ProcessID = Request.QueryString("ProcessID")
            _IDA = Request.QueryString("IDA")
            _FK_IDA = Request.QueryString("FK_IDA")
            _TR_ID = Request.QueryString("TR_ID")
            _CLS = Session("CLS")
            _YEARS = con_year(Date.Now.Year)
        Catch ex As Exception
            Response.Redirect("http://privus.fda.moph.go.th/")
        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunSession()
        If Not IsPostBack Then
            Set_Label()
        End If
    End Sub

    Sub Set_Label()
        Dim dao As New DAO_DRUG.TB_CER
        dao.GetDataby_IDA2(_IDA)
        Dim dao_lcn As New DAO_DRUG.ClsDBdalcn
        dao_lcn.GetDataby_IDA(dao.fields.FK_IDA)
        Dim dao_dalcntype As New DAO_DRUG.ClsDBdalcntype
        dao_dalcntype.GetDataby_lcntpcd(dao_lcn.fields.lcntpcd)

        Dim dao_up As New DAO_DRUG.ClsDBTRANSACTION_UPLOAD
        If Len(_TR_ID) >= 9 Then
            dao_up.GetDataby_TR_ID_Process(_TR_ID, dao.fields.PROCESS_ID)
        Else
            dao_up.GetDataby_IDA(_TR_ID)
        End If

        Dim PROCESS_ID As String = dao.fields.PROCESS_ID
        Dim Year As String = dao_up.fields.YEAR.ToString()
        Dim TR_ID As String = _TR_ID 'dao_up.fields.ID.ToString()
        Dim CITIZEN_ID As String = dao_up.fields.CITIEZEN_ID
        'dao_up.GetDataby_IDA(dao.fields.TR_ID)

        Dim lcnno_auto As Integer
        lcnno_auto = dao_lcn.fields.lcnno
        Dim lcnno_format As String = ""
        Try
            If Len(lcnno_auto) > 0 Then

                If Right(Left(lcnno_auto, 3), 1) = "5" Then
                    lcnno_format = "จ. " & CStr(CInt(Right(lcnno_auto, 4))) & "/25" & Left(lcnno_auto, 2)
                Else
                    lcnno_format = dao_lcn.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
                End If
                'lcnno_format = dao.fields.pvnabbr & " " & CStr(CInt(Right(lcnno_auto, 5))) & "/25" & Left(lcnno_auto, 2)
            End If
        Catch ex As Exception

        End Try
        Dim bao_show As New BAO_SHOW
        Dim dt12 As New DataTable
        Dim dt9 As New DataTable
        dt12 = bao_show.SP_SYSLCNSNM_BY_LCNSID_AND_IDENTIFYV2(dao_up.fields.CITIEZEN_ID_AUTHORIZE, dao.fields.LCNSID)
        dt9 = bao_show.SP_LOCATION_ADDRESS_by_LOCATION_ADDRESS_IDA(dao_lcn.fields.FK_IDA)

        lbl_lcnno_format.Text = lcnno_format
        lbl_lcntpnm.Text = dao_dalcntype.fields.lcntpnm
        Try
            For Each dr As DataRow In dt12.Rows
                lbl_licen_name.Text = dr("thanm")
            Next

        Catch ex As Exception

        End Try
        Try
            For Each dr As DataRow In dt9.Rows
                lbl_thanameplace.Text = dr("thanameplace")
                lbl_addr.Text = dr("fulladdr2")
                lbl_tel.Text = dr("tel")
                lbl_fax.Text = dr("fax")
            Next
        Catch ex As Exception

        End Try
        Try

        Catch ex As Exception

        End Try
    End Sub
End Class