Public Class UC_GRID_ATTACH
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub
    ''' <summary>
    ''' ใส่ข้อมูลลงตารางไฟล์แนบ
    ''' </summary>
    ''' <param name="TR_ID"></param>
    ''' <remarks></remarks>
    Public Sub load_gv(ByVal TR_ID As String)
        If TR_ID <> "" And TR_ID <> "0" Then
            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH 'เรียกใช้classตารางไฟล์แนบ
            dao.GetDataby_TR_ID(TR_ID) 'ดึงข้อมูลโดยการ where TR_ID
            gv2.DataSource = dao.datas 'ใส่ข้อมูลลงตาราง
            gv2.DataBind() 'รันข้อมูลทุกrowของตาราง
        End If

    End Sub
    Public Sub loadatteachfromdrugimportupload(ByVal ida As String, ByVal type As Integer)               'MINทำนะ
        If ida <> "" And ida <> "0" Then
            Dim dao As New DAO_DRUG_IMPORT.ClsDBDRUG_IMPORT_UPLOAD 'เรียกใช้classตารางไฟล์แนบ
            dao.GetDataby_IDAandtype(ida, type) 'ดึงข้อมูลโดยการ where ida ,type
            gv2.DataSource = dao.datas 'ใส่ข้อมูลลงตาราง
            gv2.DataBind() 'รันข้อมูลทุกrowของตาราง
        End If

    End Sub
    Public Sub load_gv_V2(ByVal TR_ID As String, ByVal process As String)
        If TR_ID <> "" And TR_ID <> "0" Then
            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH 'เรียกใช้classตารางไฟล์แนบ
            dao.GetDataby_TR_ID_And_Process(TR_ID, process) 'ดึงข้อมูลโดยการ where TR_ID
            gv2.DataSource = dao.datas 'ใส่ข้อมูลลงตาราง
            gv2.DataBind() 'รันข้อมูลทุกrowของตาราง
        End If

    End Sub
    Public Sub load_gv_V3(ByVal TR_ID As String, ByVal type As Integer)
        If TR_ID <> "" And TR_ID <> "0" Then
            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH 'เรียกใช้classตารางไฟล์แนบ
            dao.GetDataby_TR_ID_type(TR_ID, type) 'ดึงข้อมูลโดยการ where TR_ID
            gv2.DataSource = dao.datas 'ใส่ข้อมูลลงตาราง
            gv2.DataBind() 'รันข้อมูลทุกrowของตาราง
        End If

    End Sub
    Public Sub load_gv_V4(ByVal TR_ID As String, ByVal type As Integer, ByVal process As String)
        If TR_ID <> "" And TR_ID <> "0" Then
            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH 'เรียกใช้classตารางไฟล์แนบ
            dao.GetDataby_TR_ID_type(TR_ID, type) 'ดึงข้อมูลโดยการ where TR_ID
            gv2.DataSource = dao.datas 'ใส่ข้อมูลลงตาราง
            gv2.DataBind() 'รันข้อมูลทุกrowของตาราง
        End If

    End Sub
    ''' <summary>
    ''' ระบุURL ของแต่ละ row เพื่อเรียก PDF
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub gv2_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gv2.RowDataBound 'สร้างอีเวนท์วนทุก row เมื่อมีการโหลดตาราง
        If e.Row.RowType = DataControlRowType.DataRow Then 'ให้ทำในrowที่มีข้อมูล
            Dim btn_Select As HyperLink = DirectCast(e.Row.FindControl("btn_Select"), HyperLink) 'สร้าง HyperLink จำลองแทน HyperLink ของแต่ละ row 
            Dim index As Integer = e.Row.RowIndex 'เลขที่ลำดับของแต่ละ row
            Dim str_ID As String = gv2.DataKeys.Item(index).Value.ToString() 'ดึง DataKeys ของแต่ละ row มาเก็บใน str_ID
            Dim dao As New DAO_DRUG.ClsDBFILE_ATTACH 'เรียกใช้classตารางไฟล์แนบ
            dao.GetDataby_IDA(str_ID) 'ดึงข้อมูลโดยการ where IDA ที่ใช้เป็น DataKeys ของแต่ละ row 
            btn_Select.NavigateUrl = "~\PDF\FRM_ATTACH_PREVIEW_ALL.aspx\" & dao.fields.NAME_FAKE 'ระบุ URL ของ HyperLink ในแต่ละ row โดยส่งชื่อไฟล์เพื่อเพื่อหาไฟล์PDFที่ต้องการแสดง

        End If
    End Sub
End Class