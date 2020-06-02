Public Class UC_HACCP
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
        Try
            lbl_CERTIFICATION_NUMBER_ALL.Text = dao.fields.CERTIFICATION_NUMBER_ALL
        Catch ex As Exception

        End Try
        Dim dao_mf As New DAO_DRUG.TB_CER_DETAIL_MANUFACTURE
        dao_mf.GetDataby_FK_IDA(_IDA)
        Try
            lbl_NAME_ADDRESS.Text = dao_mf.fields.NAME_ADDRESS
        Catch ex As Exception

        End Try
        Try
            lbl_ADDRESS_NUMBER.Text = dao_mf.fields.ADDRESS_NUMBER
        Catch ex As Exception

        End Try
        Try
            lbl_ADDRESS_CITY.Text = dao_mf.fields.ADDRESS_CITY
        Catch ex As Exception

        End Try
        Try
            Dim dao_iso As New DAO_DRUG.clsDBsysisocnt
            dao_iso.GetDataby_IDA(Trim(dao_mf.fields.COUNTRY_ID))
            lbl_country.Text = dao_iso.fields.engcntnm
        Catch ex As Exception

        End Try
        Try
            lbl_zipcode.Text = dao_mf.fields.ZIPCODE
        Catch ex As Exception

        End Try
        Try
            lbl_MANUFACTURER_LICENCE_NUMBER.Text = dao.fields.MANUFACTURER_LICENCE_NUMBER
        Catch ex As Exception

        End Try
        Try
            lbl_GLN.Text = dao.fields.GLN
        Catch ex As Exception

        End Try
        Try
            Dim DOCUMENT_DATE As Date = CDate(dao.fields.DOCUMENT_DATE)
            If Year(DOCUMENT_DATE) > 2500 Then
                DOCUMENT_DATE = DateAdd(DateInterval.Year, -543, DOCUMENT_DATE)
            End If
            lbl_DOCUMENT_DATE.Text = DOCUMENT_DATE
        Catch ex As Exception

        End Try
        Try
            Dim EXP_DOCUMENT_DATE As Date = CDate(dao.fields.EXP_DOCUMENT_DATE)
            If Year(EXP_DOCUMENT_DATE) > 2500 Then
                EXP_DOCUMENT_DATE = DateAdd(DateInterval.Year, -543, EXP_DOCUMENT_DATE)
            End If

            lbl_EXP_DOCUMENT_DATE.Text = EXP_DOCUMENT_DATE
        Catch ex As Exception

        End Try
       
        Try
            lbl_CER_SCOPE.Text = dao.fields.CER_SCOPE
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
        Dim bao_master As New BAO_MASTER
        Dim dt As New DataTable
        dt = bao_master.SP_CER_DETAIL_CASCHEMICAL_by_FK_IDA(_IDA)
        RadGrid1.DataSource = dt
    End Sub
End Class