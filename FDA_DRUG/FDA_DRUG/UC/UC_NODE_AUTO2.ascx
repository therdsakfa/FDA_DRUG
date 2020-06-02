<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_NODE_AUTO2.ascx.vb" Inherits="FDA_DRUG.UC_NODE_AUTO2" %>
 <div style=" vertical-align: top;">
    
        <asp:TreeView ID="TreeView1" runat="server"  Font-Size="Medium" NodeWrap="True">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
           <%-- <Nodes>
                
                <asp:TreeNode Text="เภสัชเคมีภัณฑ์" Value="เภสัชเคมีภัณฑ์"> </asp:TreeNode>
                <asp:TreeNode Text="บัญชีรายการขอขึ้นทะเบียนยา" Value="บัญชีรายการขอขึ้นทะเบียนยา">
                </asp:TreeNode>
                <asp:TreeNode Text="นำเข้ายาเฉพาะครั้ง" Value="นำเข้ายาเฉพาะครั้ง">
                    <asp:TreeNode Text="นยม1" Value="นยม1"></asp:TreeNode>
                    <asp:TreeNode Text="นยม2" Value="นยม2"></asp:TreeNode>
                    <asp:TreeNode Text="นยม3" Value="นยม3"></asp:TreeNode>
                    <asp:TreeNode Text="นยม4" Value="นยม4"></asp:TreeNode>
                    <asp:TreeNode Text="นยม5" Value="นยม5"></asp:TreeNode>
                    <asp:TreeNode Text="Placebo" Value="Placebo"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="Certificate" Value="Certificate"></asp:TreeNode>
            </Nodes>--%>
            <NodeStyle Font-Names="Tahoma" Font-Size="Medium" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
    
    </div>