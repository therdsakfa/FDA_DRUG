Public Class UC_NODE_EDIT
    Inherits System.Web.UI.UserControl
    Private _IDA As String = ""
    Private _FK_IDA As String = ""
    Sub runQuery()
        _IDA = Request.QueryString("IDA")
        _fk_ida = Request.QueryString("FK_IDA")
    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        runQuery()
    End Sub
    ''' <summary>
    ''' เลือกข้อมูลบนnode
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub TreeView1_SelectedNodeChanged(sender As Object, e As EventArgs) Handles TreeView1.SelectedNodeChanged

        If TreeView1.SelectedValue = TreeView1.SelectedNode.ValuePath Then
            If TreeView1.Nodes(0).Selected = True Then
                'บัญขีขอขึ้นทะเบียนยา
                'Response.Redirect("../EDIT_TABEAN_YA/FRM_EDIT_TABEAN_YA_MAIN.aspx?process=335&IDA=" & _IDA & "&FK_IDA=" & _fk_ida & "&EDIT_TYPE=1")
            End If
        Else
            If TreeView1.Nodes(0).ChildNodes(1).Selected = True Then
                'มากกว่า1
                Response.Redirect("../EDIT_TABEAN_YA/FRM_EDIT_TABEAN_YA_MAIN.aspx?PROCESS=335&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA & "&EDIT_TYPE=10" & "&AUTO_TYPE=MANUAL")

            ElseIf TreeView1.Nodes(0).ChildNodes(0).ChildNodes(0).Selected = True Then
                'ฉลาก
                Response.Redirect("../EDIT_TABEAN_YA/FRM_EDIT_TABEAN_YA_MAIN.aspx?PROCESS=335&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA & "&EDIT_TYPE=0" & "&AUTO_TYPE=AUTO")
            ElseIf TreeView1.Nodes(0).ChildNodes(0).ChildNodes(1).Selected = True Then
                'เอกสารกำกับยา
                Response.Redirect("../EDIT_TABEAN_YA/FRM_EDIT_TABEAN_YA_MAIN.aspx?PROCESS=335&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA & "&EDIT_TYPE=1" & "&AUTO_TYPE=AUTO")
            ElseIf TreeView1.Nodes(0).ChildNodes(0).ChildNodes(2).Selected = True Then
                'ขนาดบรรจุ
                Response.Redirect("../EDIT_TABEAN_YA/FRM_EDIT_TABEAN_YA_MAIN.aspx?PROCESS=335&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA & "&EDIT_TYPE=2" & "&AUTO_TYPE=AUTO")
            ElseIf TreeView1.Nodes(0).ChildNodes(0).ChildNodes(3).Selected = True Then
                'ชื่อยา
                Response.Redirect("../EDIT_TABEAN_YA/FRM_EDIT_TABEAN_YA_MAIN.aspx?PROCESS=335&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA & "&EDIT_TYPE=3" & "&AUTO_TYPE=AUTO")
            ElseIf TreeView1.Nodes(0).ChildNodes(0).ChildNodes(4).Selected = True Then
                'ลักษณะยา
                Response.Redirect("../EDIT_TABEAN_YA/FRM_EDIT_TABEAN_YA_MAIN.aspx?PROCESS=335&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA & "&EDIT_TYPE=4" & "&AUTO_TYPE=AUTO")
            ElseIf TreeView1.Nodes(0).ChildNodes(0).ChildNodes(5).Selected = True Then
                'สูตรยา
                Response.Redirect("../EDIT_TABEAN_YA/FRM_EDIT_TABEAN_YA_MAIN.aspx?PROCESS=335&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA & "&EDIT_TYPE=5" & "&AUTO_TYPE=AUTO")
            ElseIf TreeView1.Nodes(0).ChildNodes(0).ChildNodes(6).Selected = True Then
                'วิธีวิเคราะห์และข้อกำหนดมาตรฐาน
                Response.Redirect("../EDIT_TABEAN_YA/FRM_EDIT_TABEAN_YA_MAIN.aspx?PROCESS=335&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA & "&EDIT_TYPE=6" & "&AUTO_TYPE=AUTO")
            ElseIf TreeView1.Nodes(0).ChildNodes(0).ChildNodes(7).Selected = True Then
                'อื่นๆ เกี่ยวกับผลิตภัณฑ์ยา
                Response.Redirect("../EDIT_TABEAN_YA/FRM_EDIT_TABEAN_YA_MAIN.aspx?PROCESS=335&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA & "&EDIT_TYPE=7" & "&AUTO_TYPE=AUTO")
          
            End If

        End If

    End Sub

End Class