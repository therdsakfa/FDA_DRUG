<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_NODE.Master" CodeBehind="FRM_DI_DOWNLOAD.aspx.vb" Inherits="FDA_FOOD.FRM_DI_DOWNLOAD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="form-control">
            
        <h3>ประเภทอาหาร</h3>
        
          License number :  <asp:Label ID="lbl_lcnno" runat="server" Text=""></asp:Label>
    </div>
    

<div class="panel-info" style="text-align:right ;width:100%">
     <p style="text-align:right;padding-right:5%;">
            <%--<asp:Button ID="btn_download" runat="server" Text="ดาวโหลด" CssClass="btn-primary" Visible="false" />--%>
        &nbsp;&nbsp;
            <asp:Button ID="btn_upload" runat="server" Text="อัพโหลด" CssClass="btn-danger"  />
        </p>
    </div>
    <asp:GridView ID="GridView1" runat="server" DataKeyNames="fdtypecd,fdtypenm,grptypecd" Width="90%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
      
         <asp:BoundField DataField="fdtypecd" HeaderText="รหัส" ItemStyle-Width ="10%" Visible="false"  />
      
         <asp:BoundField DataField="fdtypenm" HeaderText="ชื่อประเภท" ItemStyle-Width ="50%"   >    </asp:BoundField>
        <asp:BoundField DataField="grptypenm" HeaderText="ชื่อกลุ่ม" ItemStyle-Width ="20%"   > </asp:BoundField>
              <asp:BoundField DataField="grptypecd" HeaderText="รหัสกลุ่ม" ItemStyle-Width ="10%"  Visible="false"  > </asp:BoundField>
        
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>
    <br />
     <div style="text-align:center;"> 
                 
              </div>  
</asp:Content>
