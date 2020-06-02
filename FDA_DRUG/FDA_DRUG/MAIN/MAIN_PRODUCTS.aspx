<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Product.Master" CodeBehind="MAIN_PRODUCTS.aspx.vb" Inherits="FDA_DRUG.MAIN_PRODUCTS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4> รายการใบอนุญาตที่ได้รับการอนุญาต</h4> </div>

         </div>
    
    </div>
    <div class="panel panel-body" style="width: 100%; padding-left: 5%;">
    <asp:GridView ID="GV_lcnno" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" CssClass="table" DataKeyNames="IDA" Font-Size="10pt" ForeColor="#333333" GridLines="None" PageSize="10" Width="100%">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <%--<asp:BoundField DataField="pay_stat" HeaderText="การชำระเงิน" ItemStyle-Width ="10%" />--%><%--<asp:BoundField DataField="rcvno" HeaderText="เลขที่รับ" ItemStyle-Width ="10%" ItemStyle-HorizontalAlign="Left" />
      
         <asp:BoundField DataField="rcvdate"  DataFormatString="{0:d}" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width ="20%" >
<ItemStyle Width="20%"></ItemStyle>
         </asp:BoundField>
         <asp:BoundField HeaderText="วันที่รับพิจารณา" DataFormatString="{0:d}" />
         <asp:BoundField HeaderText="วันที่แล้วเสร็จ" DataFormatString="{0:d}" />--%><%--<asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                     <ItemTemplate>
                          <asp:Label ID="lbl_status" runat="server" ></asp:Label>
                     </ItemTemplate>
                </asp:TemplateField>--%>
            <asp:BoundField DataField="LCNNO_MANUAL" HeaderText="เลขที่ใบอนุญาต" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%">
            <ItemStyle HorizontalAlign="Left" Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="PROCESS_NAME" HeaderText="ประเภท" ItemStyle-Width="10%">
            <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="thanameplace" HeaderText="ชื่อสถานที่" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="20%">
            <ItemStyle HorizontalAlign="Left" Width="20%" />
            </asp:BoundField>
            <asp:BoundField DataField="fulladdr" HeaderText="ที่อยู่" ItemStyle-Width="30%">
            <ItemStyle Width="30%" />
            </asp:BoundField>
            <asp:BoundField DataField="lcnsid" HeaderText="รหัสผู้ประกอบการ" ItemStyle-Width="10%" Visible="false">
            <ItemStyle Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="HOUSENO" HeaderText="เลขสถานที่" ItemStyle-HorizontalAlign="Left" ItemStyle-Width="10%">
            <ItemStyle HorizontalAlign="Left" Width="10%" />
            </asp:BoundField>
            <asp:BoundField DataField="TRANSECTION_ID_UPLOAD" HeaderText="เลขดำเนินการ" ItemStyle-Width="10%">
            <ItemStyle Width="10%" />
            </asp:BoundField>

        </Columns>
        <EmptyDataTemplate>
            <center>
                ไม่พบข้อมูล</center>
        </EmptyDataTemplate>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#8CB340 " CssClass="row" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" CssClass="row" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView>
    <div class="h5" style="padding-left: 87%;">
        
    </div>
</div>
</asp:Content>
