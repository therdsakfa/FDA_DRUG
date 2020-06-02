Public Class FRM_FRGN_ADD_INSERT_EDIT
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            If Request.QueryString("act") = "edit" Then
                lbl_head.Text = "แก้ไขที่อยู่ผู้ผลิตต่างประเทศ"
            ElseIf Request.QueryString("act") = "insert" Then
                lbl_head.Text = "เพิ่มที่อยู่ผู้ผลิตต่างประเทศ"
            End If
            bind_nat()
            Try
                Dim dao_frgn As New DAO_DRUG.ClsDBsyspdcfrgn
                dao_frgn.GetData_by_frgncd(Request.QueryString("frgncd"))
                lbl_frgn_name.Text = dao_frgn.fields.engfrgnnm
            Catch ex As Exception

            End Try
            If Request.QueryString("act") = "edit" Then
                Dim dao_addr As New DAO_DRUG.ClsDBdrfrgnaddr
                dao_addr.GetDataByIDA(Request.QueryString("IDA"))
                Getdata(dao_addr)
            End If
        End If
    End Sub
    Sub bind_nat()
        Dim bao As New BAO_MASTER
        Dim dt As New DataTable
        dt = bao.SP_MASTER_sysisocnt()
        rcb_national.DataSource = dt
        rcb_national.DataTextField = "engcntnm"
        rcb_national.DataValueField = "alpha3"
        rcb_national.DataBind()

    End Sub

    Protected Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        If Request.QueryString("act") <> "edit" Then
            Dim dao_MAX As New DAO_DRUG.ClsDBdrfrgnaddr
            Dim max_id As Integer = 0
            Try
                dao_MAX.GET_MAX_frgnlctcd(Request.QueryString("frgncd"))
                max_id = dao_MAX.fields.frgnlctcd
            Catch ex As Exception

            End Try
            Dim dao_addr As New DAO_DRUG.ClsDBdrfrgnaddr
            Setdata(dao_addr)
            dao_addr.fields.frgnlctcd = max_id + 1
            dao_addr.fields.frgncd = Request.QueryString("frgncd")
            dao_addr.fields.lmdfdate = Date.Now
            dao_addr.insert()

            alert("บันทึกเรียบร้อยแล้ว")
        Else
            Dim dao_addr As New DAO_DRUG.ClsDBdrfrgnaddr
            dao_addr.GetDataByIDA(Request.QueryString("IDA"))
            Setdata(dao_addr)
            dao_addr.fields.lmdfdate = Date.Now
            dao_addr.update()
            alert("แก้ไขเรียบร้อยแล้ว")
        End If


    End Sub
    Sub Getdata(ByRef dao As DAO_DRUG.ClsDBdrfrgnaddr)
        txt_addr.Text = dao.fields.addr
        txt_district.Text = dao.fields.district
        txt_fax.Text = dao.fields.fax
        txt_mu.Text = dao.fields.mu
        txt_Province.Text = dao.fields.province
        txt_road.Text = dao.fields.road
        txt_soi.Text = dao.fields.soi
        txt_subdiv.Text = dao.fields.subdiv
        txt_tel.Text = dao.fields.tel
        txt_zipcode.Text = dao.fields.zipcode
        Try
            rcb_national.SelectedValue = dao.fields.cntcd
        Catch ex As Exception

        End Try
    End Sub

    Sub Setdata(ByRef dao As DAO_DRUG.ClsDBdrfrgnaddr)
        dao.fields.addr = txt_addr.Text
        dao.fields.district = txt_district.Text
        dao.fields.fax = txt_fax.Text
        dao.fields.mu = txt_mu.Text
        dao.fields.province = txt_Province.Text
        dao.fields.road = txt_road.Text
        dao.fields.soi = txt_soi.Text
        dao.fields.subdiv = txt_subdiv.Text
        dao.fields.tel = txt_tel.Text
        dao.fields.zipcode = txt_zipcode.Text
        Try
            dao.fields.cntcd = rcb_national.SelectedValue
        Catch ex As Exception

        End Try
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
End Class