Imports FDA_DRUG.Graph3DMultiple
Imports System.Web.Script.Serialization
Public Class FRM_E_TRACKING_WORK
    Inherits System.Web.UI.Page
    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    'Private Sub RadGrid1_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid1.NeedDataSource
    '    Dim dt As New DataTable
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    dt = bao.SP_E_TRACKING_WORK_BY_CITIZEN_ID(txt_citizen.Text)
    '    If dt.Rows.Count = 0 Then
    '        Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script> ")
    '    Else
    '        RadGrid1.DataSource = dt
    '    End If

    'End Sub
    'Sub bind_ddl()
    '    Dim dt As New DataTable
    '    Dim bao As New BAO.ClsDBSqlcommand
    '    dt = bao.SP_E_TRACKING_STAFF_CITIZEN()
    '    ddl_staff.DataSource = dt
    '    ddl_staff.Items.Insert(0, New ListItem("", "---กรุณาเลือก---"))
    '    ddl_staff.DataBind()
    'End Sub
    Sub bind_grid()

        Dim bao As New BAO.ClsDBSqlcommand
        dt = bao.SP_E_TRACKING_WORK_BY_CITIZEN_ID(txt_citizen.Text)
        If dt.Rows.Count = 0 Then
            HiddenField1.Value = ""
            Response.Write("<script type='text/javascript'>alert('ไม่พบข้อมูล');</script> ")
        Else
            RadGrid1.DataSource = dt
            RadGrid1.Rebind()

            bind_graph()
        End If
    End Sub
    Private Sub btn_search_Click(sender As Object, e As EventArgs) Handles btn_search.Click
        bind_grid()
        'RadGrid1.Rebind()
    End Sub
    Sub bind_graph()
        If dt.Rows.Count > 0 Then
            Dim rootobject As New Graph3DMultiple.Rootobject ' Rootobject
            Dim fullname As String = ""
            Try
                fullname = dt(0)("fullname")
            Catch ex As Exception

            End Try

            Dim cha As New Graph3DMultiple.Chart
            cha.caption = "รายงานจำนวนคำขอของ " & fullname
            cha.yaxisname = ""
            cha.canvasbgcolor = "FEFEFE"
            cha.canvasbasecolor = "FEFEFE"
            cha.tooltipbgcolor = "DEDEBE"
            cha.tooltipborder = "889E6D"
            cha.divlinecolor = "999999"
            cha.showcolumnshadow = "0"
            cha.divlineisdashed = "1"
            cha.divlinedashlen = "1"
            cha.divlinedashgap = "2"
            cha.numberprefix = ""
            cha.numbersuffix = ""
            cha.showborder = "0"
            cha.formatnumberscale = "0"
            rootobject.chart = cha

            Dim category As New Category
            For Each dr As DataRow In dt.Rows
                Dim cat As New Category1
                cat.label = dt(0)("PROCESS_NAME")
                category.category.Add(cat)
            Next
            
            rootobject.categories.Add(category)

            Dim datase As New Dataset
            datase.seriesname = "จำนวนคำขอทั้งหมด"
            datase.color = "919191"

            Dim datase2 As New Dataset
            datase2.seriesname = "จำนวนคำขอใหม่"
            datase2.color = "47cdff"

            Dim datase3 As New Dataset
            datase3.seriesname = "จำนวนคำขอรออนุมัติ 1-60 วัน"
            datase3.color = "347c1a"

            Dim datase4 As New Dataset
            datase4.seriesname = "จำนวนคำขอรออนุมัติ 61-120 วัน"
            datase4.color = "f4f6b0"

            Dim datase5 As New Dataset
            datase5.seriesname = "จำนวนคำขอใหม่มากกว่า 120 วัน"
            datase5.color = "df2323"


            For Each dr As DataRow In dt.Rows
                Dim datum As New Datum
                datum.value = dt(0)("all_work")
                datum.link = HttpContext.Current.Request.Url.AbsoluteUri
                datase.data.Add(datum)


                Dim datum2 As New Datum
                datum2.value = dt(0)("zero_work")
                datum2.link = HttpContext.Current.Request.Url.AbsoluteUri
                datase2.data.Add(datum2)

                Dim datum3 As New Datum
                datum3.value = dt(0)("one_to_sixty_work")
                datum3.link = HttpContext.Current.Request.Url.AbsoluteUri
                datase3.data.Add(datum3)

                Dim datum4 As New Datum
                datum4.value = dt(0)("sixty_to_120_work")
                datum4.link = HttpContext.Current.Request.Url.AbsoluteUri
                datase4.data.Add(datum4)

                Dim datum5 As New Datum
                datum5.value = dt(0)("over_120_work")
                datum5.link = HttpContext.Current.Request.Url.AbsoluteUri
                datase5.data.Add(datum5)
            Next

            rootobject.dataset.Add(datase)
            rootobject.dataset.Add(datase2)
            rootobject.dataset.Add(datase3)
            rootobject.dataset.Add(datase4)
            rootobject.dataset.Add(datase5)

            Dim serializer As New JavaScriptSerializer()
            Dim serializedResult = serializer.Serialize(rootobject)

            HiddenField1.Value = serializedResult
        Else
            HiddenField1.Value = ""
        End If
        
    End Sub
End Class