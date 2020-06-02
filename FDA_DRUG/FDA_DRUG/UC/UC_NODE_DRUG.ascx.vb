Public Class UC_NODE_DRUG
    Inherits System.Web.UI.UserControl
    Private _IDA As String = ""
    Private _FK_IDA As String = ""
    Sub runQuery()
        _IDA = Request.QueryString("IDA")
        ' If Request.QueryString("FK_IDA") = "" Then
        _FK_IDA = Request.QueryString("FK_IDA")
        ' End If
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
                'cer
                Response.Redirect("../DI/FRM_DI_MAIN.aspx?process=6&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(1).Selected = True Then
                'เภสัชเคมีภัณฑ์ยา
                
            ElseIf TreeView1.Nodes(2).Selected = True Then
                'งานวิจัย

            ElseIf TreeView1.Nodes(3).Selected = True Then
                'บัญชีขอขึ้นทะเบียนยา

            ElseIf TreeView1.Nodes(4).Selected = True Then
                'เพิ่มสาร
                Response.Redirect("../CHEMICAL/FRM_CHEMICAL_MAIN.aspx?process=30&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(5).Selected = True Then
                'โอนย้ายยา
                Response.Redirect("../TRANFER_LOCATION/FRM_TRANFER_LOCATION_MAIN.aspx?process=30&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            End If
            '------------------------------ย่อย---------------------------------------------
        Else
            'CER
            If TreeView1.Nodes(0).ChildNodes(0).Selected = True Then
                Response.Redirect("../DI/FRM_DI_MAIN.aspx?process=31&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(0).ChildNodes(1).Selected = True Then
                Response.Redirect("../DI/FRM_DI_MAIN.aspx?process=32&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(0).ChildNodes(2).Selected = True Then
                Response.Redirect("../DI/FRM_DI_MAIN.aspx?process=33&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(0).ChildNodes(3).Selected = True Then
                Response.Redirect("../DI/FRM_DI_MAIN.aspx?process=34&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(0).ChildNodes(4).Selected = True Then
                Response.Redirect("../DI/FRM_DI_MAIN.aspx?process=35&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(0).ChildNodes(5).Selected = True Then
                Response.Redirect("../DI/FRM_DI_MAIN.aspx?process=36&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)

                'เภสัชเคมีภัณฑ์
            ElseIf TreeView1.Nodes(1).ChildNodes(0).Selected = True Then
                Response.Redirect("../DH/FRM_DH_MAIN.aspx?process=14&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(1).ChildNodes(1).Selected = True Then
                Response.Redirect("../DH/FRM_DH_MAIN.aspx?process=15&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(1).ChildNodes(2).Selected = True Then
                Response.Redirect("../DH/FRM_DH_MAIN.aspx?process=16&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(1).ChildNodes(3).Selected = True Then
                Response.Redirect("../DH/FRM_DH_MAIN.aspx?process=17&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(1).ChildNodes(4).Selected = True Then
                Response.Redirect("../DH/FRM_DH_MAIN.aspx?process=18&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
                '-------------------------------------------------------------------------------------------------
                'บัญชียา
            ElseIf TreeView1.Nodes(2).ChildNodes(0).Selected = True Then
                Response.Redirect("../REGISTRATION/FEM_REGISTRATION_MAIN.aspx?process=9&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(2).ChildNodes(1).Selected = True Then
                Response.Redirect("../REGISTRATION/FEM_REGISTRATION_MAIN.aspx?process=19&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
                '-------------------------------------------------------------------------------------------------
                'นยม
            ElseIf TreeView1.Nodes(3).ChildNodes(0).Selected = True Then
                'นยม1 
                Response.Redirect("../DRUG_PROJECT/FRM_DRUG_PROJECT_MAIN.aspx?process=12&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(3).ChildNodes(1).Selected = True Then
                'นยม2
                Response.Redirect("../DRUG_CUSTOMER_NORYORMOR_2_to_5/FRM_NORYORMOR_2_to_5_MAIN.aspx?process=2&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(3).ChildNodes(2).Selected = True Then
                'นยม3
                Response.Redirect("../DRUG_CUSTOMER_NORYORMOR_2_to_5/FRM_NORYORMOR_2_to_5_MAIN.aspx?process=3&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(3).ChildNodes(3).Selected = True Then
                'นยม4
                Response.Redirect("../DRUG_CUSTOMER_NORYORMOR_2_to_5/FRM_NORYORMOR_2_to_5_MAIN.aspx?process=4&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(3).ChildNodes(4).Selected = True Then
                'นยม5
                Response.Redirect("../DRUG_CUSTOMER_NORYORMOR_2_to_5/FRM_NORYORMOR_2_to_5_MAIN.aspx?process=5&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)
            ElseIf TreeView1.Nodes(3).ChildNodes(5).Selected = True Then
                'Placebo
                Response.Redirect("../DP/FRM_DP_MAIN.aspx?process=8&IDA=" & _IDA & "&FK_IDA=" & _FK_IDA)



            End If
        End If
    End Sub
End Class