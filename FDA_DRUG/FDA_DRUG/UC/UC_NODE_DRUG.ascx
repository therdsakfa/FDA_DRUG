<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_NODE_DRUG.ascx.vb" Inherits="FDA_DRUG.UC_NODE_DRUG" %>
 <div style=" vertical-align: top;">
    
        <asp:TreeView ID="TreeView1" runat="server" ImageSet="Arrows" Font-Size="Medium" NodeWrap="True">
            <HoverNodeStyle Font-Underline="True" ForeColor="#5555DD" />
            <Nodes>
                
                <asp:TreeNode Text="ลงทะเบียน GMP สถานที่ผลิต" Value="Certificate">
                    <asp:TreeNode Text="Certificate of GMP" Value="Certificate of GMP"></asp:TreeNode>
                    <asp:TreeNode Text="ISO" Value="ISO"></asp:TreeNode>
                    <asp:TreeNode Text="HACCP" Value="HACCP"></asp:TreeNode>
                    <asp:TreeNode Text="หลักฐานการขายไปยังประเทศที่มีระบบควบคุมคุณภาพการผลิตที่ อย ยอมรับ" Value="หลักฐานการขายไปยังประเทศที่มีระบบควบคุมคุณภาพการผลิตที่ อย ยอมรับ"></asp:TreeNode>
                    <asp:TreeNode Text="เอกสารผลการวิเคราะห์วัตถุดิบโดยห้องปฏิบัติที่ อย ให้การยอมรับ" Value="เอกสารผลการวิเคราะห์วัตถุดิบโดยห้องปฏิบัติที่ อย ให้การยอมรับ"></asp:TreeNode>
                    <asp:TreeNode Text="เอกสารอื่นๆ ที่ อย เห็นชอบ" Value="เอกสารอื่นๆ ที่ อย เห็นชอบ"></asp:TreeNode>
                </asp:TreeNode>
                
                <%--<asp:TreeNode Text="เภสัชเคมีภัณฑ์" Value="เภสัชเคมีภัณฑ์">
                     <asp:TreeNode Text="เป็นสารออกฤทธิ์ตามทะเบียนตำรับยา" Value="เคมีภัณฑ์ตามทะเบียน"></asp:TreeNode>
                    <asp:TreeNode Text="เป็นสารออกฤทธิ์ที่ไม่มีในทะเบียนตำรับยา" Value="เคมีภัณฑ์ที่ไม่มีทะเบียน"></asp:TreeNode>
                     <asp:TreeNode Text="ไม่เป็นสารออกฤทธิ์ตามทะเบียนตำรับยา" Value="เคมีภัณฑ์ที่เป็น inert"></asp:TreeNode>
                    <asp:TreeNode Text="ไม่เป็นสารออกฤทธิ์ที่ไม่มีในทะเบียนตำรับยา" Value="ไม่เป็นสารออกฤทธิ์ที่ไม่มีในทะเบียนตำรับยา"></asp:TreeNode>

                     <asp:TreeNode Text="วัตถุดิบสมุนไพรสำหรับยาแผนโบราณ" Value="เคมีภัณฑ์ที่วัตถุดิบสมุนไพร"></asp:TreeNode>

                </asp:TreeNode>
                <asp:TreeNode Text="บัญชีรายการขอขึ้นทะเบียนยา" Value="บัญชีรายการขอขึ้นทะเบียนยา">
                   <asp:TreeNode Text="ยาคน" Value="ยาคน"></asp:TreeNode>
                   <asp:TreeNode Text="ยาสัตว์" Value="ยาสัตว๋"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="นำเข้ายาเฉพาะครั้ง" Value="นำเข้ายาเฉพาะครั้ง">
                    <asp:TreeNode Text="นยม1" Value="นยม1"></asp:TreeNode>
                    <asp:TreeNode Text="นยม2" Value="นยม2"></asp:TreeNode>
                    <asp:TreeNode Text="นยม3" Value="นยม3"></asp:TreeNode>
                    <asp:TreeNode Text="นยม4" Value="นยม4"></asp:TreeNode>
                    <asp:TreeNode Text="นยม5" Value="นยม5"></asp:TreeNode>
                    <asp:TreeNode Text="Placebo" Value="Placebo"></asp:TreeNode>
                </asp:TreeNode>
                <asp:TreeNode Text="เพิ่มสาร" Value="เพิ่มสาร"></asp:TreeNode>--%>
            </Nodes>
            <NodeStyle Font-Names="Tahoma" Font-Size="Medium" ForeColor="Black" HorizontalPadding="5px" NodeSpacing="0px" VerticalPadding="0px" />
            <ParentNodeStyle Font-Bold="False" />
            <SelectedNodeStyle Font-Underline="True" ForeColor="#5555DD" HorizontalPadding="0px" VerticalPadding="0px" />
        </asp:TreeView>
    
    </div>