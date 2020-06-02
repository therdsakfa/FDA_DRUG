<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_NODE_EDIT.ascx.vb" Inherits="FDA_DRUG.UC_NODE_EDIT" %>
<asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows" Font-Size="Medium" NodeWrap="True">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <Nodes>
                <asp:TreeNode Text="คำขอแก้ไข" Value="คำขอแก้ไข">
                    <asp:TreeNode Text="รายการขอแก้ไข 1 รายการ"  Value="รายการขอแก้ไข 1 รายการ">
                        <asp:TreeNode Text="ฉลาก" Value="ฉลาก"></asp:TreeNode>
                        <asp:TreeNode Text="เอกสารกำกับยา" Value="เอกสารกำกับยา"></asp:TreeNode>
                        <asp:TreeNode Text="ขนาดบรรจุ" Value="ขนาดบรรจุ"></asp:TreeNode>
                        <asp:TreeNode Text="ชื่อยา" Value="ชื่อยา"></asp:TreeNode>
                        <asp:TreeNode Text="ลักษณะยา" Value="ลักษณะยา"></asp:TreeNode>
                        <asp:TreeNode Text="สูตรยา" Value="สูตรยา"></asp:TreeNode>
                        <asp:TreeNode Text="วิธีวิเคราะห์และข้อกำหนดมาตรฐาน" Value="วิธีวิเคราะห์และข้อกำหนดมาตรฐาน"></asp:TreeNode>
                        <asp:TreeNode Text="อื่นๆ เกี่ยวกับผลิตภัณฑ์ยา" Value="อื่นๆ เกี่ยวกับผลิตภัณฑ์ยา"></asp:TreeNode> 
                    </asp:TreeNode>
                    <asp:TreeNode Text="รายการขอแก้ไขมากกว่า 1 รายการ" Value="รายการขอแก้ไขมากกว่า 1 รายการ"></asp:TreeNode>
                </asp:TreeNode>
               
                
                
            </Nodes>
            <NodeStyle Font-Names="Tahoma" Font-Size="Medium" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>