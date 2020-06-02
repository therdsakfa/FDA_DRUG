Imports Telerik.Web.UI
Public Class UC_ANIMAL
    Inherits System.Web.UI.UserControl
    Dim _IDA As String
    Dim STATUS_ID As Integer = 0
    Sub RunQuery()
        _IDA = Request.QueryString("IDA")
        Try
            STATUS_ID = Get_drrqt_Status_by_trid(Request.QueryString("tr_id"))
        Catch ex As Exception

        End Try
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RunQuery()
        If Not IsPostBack Then
            HiddenField1.Value = 0
            hide_btn()
        End If
    End Sub
    Sub hide_btn()
        If HiddenField1.Value = 0 Then
            Button1.Visible = False
        Else
            Button1.Visible = True
        End If
    End Sub
    Public Sub bind_ddl_dramltype()
        Dim dao As New DAO_DRUG.TB_dramltype
        dao.GetDataAll()
        ddl_dramltype.DataSource = dao.datas
        ddl_dramltype.DataTextField = "amltpnm"
        ddl_dramltype.DataValueField = "amltpcd"
        ddl_dramltype.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_dramltype.Items.Insert(0, item)
    End Sub
    Public Sub bind_ddl_dramlsubtp()
        Try
            Dim dao As New DAO_DRUG.TB_dramlsubtp
            dao.GetDataby_amltpcd(ddl_dramltype.SelectedValue)
            ddl_dramlsubtp.DataSource = dao.datas
            ddl_dramlsubtp.DataTextField = "amlsubnm"
            ddl_dramlsubtp.DataValueField = "amlsubcd"
            ddl_dramlsubtp.DataBind()

            Dim item As New ListItem
            item.Text = "--กรุณาเลือก--"
            item.Value = "0"
            ddl_dramlsubtp.Items.Insert(0, item)
        Catch ex As Exception

        End Try

    End Sub
    Public Sub bind_ddl_dramlusetp()
        Dim dao As New DAO_DRUG.TB_dramlusetp
        dao.GetDataAll()
        ddl_dramlusetp.DataSource = dao.datas
        ddl_dramlusetp.DataTextField = "usetpnm"
        ddl_dramlusetp.DataValueField = "usetpcd"
        ddl_dramlusetp.DataBind()

        Dim item As New ListItem
        item.Text = "--กรุณาเลือก--"
        item.Value = "0"
        ddl_dramlusetp.Items.Insert(0, item)
    End Sub

    Private Sub btn_save_Click(sender As Object, e As EventArgs) Handles btn_save.Click
        RunQuery()
        If HiddenField1.Value = 0 Then
            Dim i As Integer = 0
                i = CountEmpty()
                If i = 0 Then
                    Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_ANIMAL
                    With dao.fields
                        .amlsubcd = ddl_dramlsubtp.SelectedValue
                        .amltpcd = ddl_dramltype.SelectedValue
                        .usetpcd = ddl_dramlusetp.SelectedValue
                        '.drgtpcd = dao1.fields.drgtpcd
                        .FK_IDA = _IDA
                        '.pvncd = dao1.fields.pvncd
                        '.rgttpcd = dao1.fields.rgttpcd
                    End With
                    dao.insert()
                    alert("บันทึกเรียบร้อย")
                Else
                    alert("กรุณากรอกข้อมูลให้ครบถ้วน")
                End If
        Else
                Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_ANIMAL
                dao.GetData_by_FK_IDA(_IDA)
                With dao.fields
                    .amlsubcd = ddl_dramlsubtp.SelectedValue
                    .amltpcd = ddl_dramltype.SelectedValue
                    .usetpcd = ddl_dramlusetp.SelectedValue
                End With
                dao.update()
            
            alert("แก้ไขเรียบร้อย")

        End If

        rgAnimals.Rebind()
    End Sub
    Public Sub alert(ByVal text As String)
        Response.Write("<script type='text/javascript'>window.alert('" + text + "');</script> ")
    End Sub
    Function CountEmpty() As Integer
        Dim i As Integer = 0
        If ddl_dramltype.SelectedValue = "0" Then
            i += 1
        End If
        If ddl_dramlsubtp.SelectedValue = "0" Then
            i += 1
        End If
        If ddl_dramlusetp.SelectedValue = "0" Then
            i += 1
        End If
        Return i
    End Function

    Private Sub rgAnimals_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles rgAnimals.ItemCommand
        If TypeOf e.Item Is GridDataItem Then
            Dim item As GridDataItem = e.Item

            Dim IDA As Integer = 0
            Try
                IDA = item("H_IDA").Text
            Catch ex As Exception

            End Try
            If e.CommandName = "_del" Then
                    Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_ANIMAL
                    dao.GetData_by_IDA(IDA)
                    dao.delete()
                    alert("ลบข้อมูลเรียบร้อย")
               
                rgAnimals.Rebind()
            ElseIf e.CommandName = "_sel" Then
                Dim url As String = "../REGISTRATION/FRM_REGISTRATION_SUB_DRUG_ANIMAL.aspx?IDA=" & IDA & "&type=" & Request.QueryString("type") & "&tr_id=" & Request.QueryString("tr_id") & "&r_id=" & _IDA & "&process=" & Request.QueryString("process")
                If Request.QueryString("a") <> "" Then
                    url &= "&a=1"
                End If
                Response.Redirect(url)
            ElseIf e.CommandName = "_edt" Then
                    Dim dao As New DAO_DRUG.TB_DRUG_REGISTRATION_ANIMAL
                    dao.GetData_by_IDA(IDA)
                    With dao.fields
                        Try
                            ddl_dramltype.DropDownSelectData(.amltpcd)
                        Catch ex As Exception

                        End Try
                        bind_ddl_dramlsubtp()
                        Try
                            ddl_dramlsubtp.DropDownSelectData(.amlsubcd)
                        Catch ex As Exception

                        End Try
                        bind_ddl_dramlusetp()
                        Try
                            ddl_dramlusetp.DropDownSelectData(.usetpcd)
                        Catch ex As Exception

                        End Try
                    End With
                HiddenField1.Value = IDA
                hide_btn()
            End If

        End If
    End Sub

    Private Sub rgAnimals_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles rgAnimals.NeedDataSource
        RunQuery()
        Dim bao As New BAO_SHOW
        Dim dt As New DataTable
        dt = bao.SP_DRUG_REGISTRATION_ANIMAL_BY_FK_IDA(_IDA)
        rgAnimals.DataSource = dt
    End Sub

    Private Sub ddl_dramltype_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddl_dramltype.SelectedIndexChanged
        'Dim uri As String = HttpContext.Current.Request.Url.AbsoluteUri.ToString() & "&tab=11"
        'Response.Write("<script type='text/javascript'>window.location='" & uri & "';</script> ")
        bind_ddl_dramlsubtp()
        'Response.Write("<script type='text/javascript'>parent.click_btn1();</script> ")
    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        HiddenField1.Value = 0
        hide_btn()
    End Sub
End Class