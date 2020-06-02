<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MAIN.Master" CodeBehind="FRM_LCN_TYPE_1.aspx.vb" Inherits="FDA_DRUG.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
 <%--  <div style="text-align:center;" >  เลขที่ใบอนุญาตสถานที่&nbsp;&nbsp;&nbsp;&nbsp;  <asp:DropDownList ID="ddl_lcnno" runat="server" CssClass="input-lg"  Width="20%"></asp:DropDownList> &nbsp;
       <asp:Button ID="Btn_ok" runat="server" Text="ยืนยัน" CssClass="btn-info" Width="67px"/>
       <br />
    </div>--%>
    

     <div class="panel-info" style="text-align:right ;width:100%">
     <p style="text-align:right;padding-right:5%;">
            <asp:Button ID="btn_download" runat="server" Text="ดาวโหลด" CssClass="btn-primary"  />
        &nbsp;&nbsp;
            <asp:Button ID="btn_upload" runat="server" Text="อัพโหลด" CssClass="btn-danger"   />
        </p>
    </div>
       <div class="panel panel-body"  style="width:100%;padding-left:5%;">
<asp:GridView ID="GV_lcnno" runat="server" Width="90%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
          <asp:TemplateField ItemStyle-Width="10%">
                     <ItemTemplate>
                      
                   <asp:Button ID="btn_pdf" runat="server" Text="ดาวโหลดPDF" CommandName="pdf" Width="80%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />
            </ItemTemplate>
                </asp:TemplateField>
         <asp:BoundField DataField="lcnsid" HeaderText="รหัสผู้ประกอบการ" ItemStyle-Width ="10%" Visible="false"  />
        <asp:BoundField DataField="lcnno" HeaderText="เลขใบอนุญาตสถานที่" ItemStyle-Width ="10%" />
        <asp:BoundField DataField="fulladdr" HeaderText="ที่อยู่" ItemStyle-Width ="50%" />

         <asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                     <ItemTemplate>
                          <asp:Label ID="lbl_status" runat="server" ></asp:Label>
                     </ItemTemplate>
                </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="10%">
                     <ItemTemplate>
                          
                   <asp:Button ID="btn_Select" runat="server" Text="ยืนยัน" CommandName="sel" Width="50%" CssClass="btn-link"   CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />
            </ItemTemplate>
                </asp:TemplateField>
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
    </div>
   
          <%--  <div class="panel panel-body"  style="width:100%;padding-left:5%;">
<asp:GridView ID="GV_data" runat="server" Width="90%" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
         <asp:BoundField DataField="lcnsid" HeaderText="รหัสผู้ประกอบการ" ItemStyle-Width ="15%"  />
        <asp:BoundField DataField="lcnno" HeaderText="เลขที่ใบอุญาตสถานที่" ItemStyle-Width ="20%" >
<ItemStyle Width="20%"></ItemStyle>
         </asp:BoundField>
         <asp:BoundField DataField="comno" HeaderText="เลขที่คำขอ" ItemStyle-Width ="20%" >
<ItemStyle Width="20%"></ItemStyle>
         </asp:BoundField>
        <asp:BoundField  DataField="prdnmt" HeaderText="ชื่อผลิตภัณฑ์" ItemStyle-Width ="55%" >
       
<ItemStyle Width="55%"></ItemStyle>
         </asp:BoundField>
         <asp:BoundField DataField="appvdate" HeaderText="วันที่อนุมัติ" />
       
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
            </div>--%>

    &nbsp;
</asp:Content>
