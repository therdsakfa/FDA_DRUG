<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_NODE.Master" CodeBehind="FRM_STAFF_PORYORBOR5_MAIN.aspx.vb" Inherits="FDA_DRUG.WebForm83" %>

<%@ Register Src="~/UC/UC_HEADER_STAFF.ascx" TagPrefix="uc1" TagName="UC_HEADER_STAFF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    
    <uc1:UC_HEADER_STAFF runat="server" id="UC_HEADER_STAFF" />
       <div style="padding:0 5% 0 5%;">

 <asp:GridView ID="gv" Width="100%" CssClass="table" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
    
     <AlternatingRowStyle BackColor="White" />
     <Columns>
         <asp:BoundField HeaderText="เลขใบอนุญาต" DataField="lcnno" />
         <%--<asp:BoundField HeaderText="เลขสารบบ" DataField="fdpdtno" />--%>
         <%--<asp:BoundField HeaderText="ชื่อผลิตภัณฑ์" DataField="prdnmt" />--%>
         <%--<asp:BoundField HeaderText="ชื่อบริษัท" DataField="thanm" />--%>
         
          <asp:BoundField HeaderText="เลขรับ" DataField="rcvno" />
          <asp:BoundField HeaderText="เลขTransection" DataField="ID"  InsertVisible="false" />
         <%--<asp:BoundField HeaderText="ประเภท" DataField="PROCESS_NAME"   InsertVisible="false" />--%>
         <asp:BoundField HeaderText="ประเภท" DataField="PROCESS_ID"   InsertVisible="false" />
          <asp:BoundField HeaderText="วันที่ยื่นคำขอ" DataField="rcvdate"   DataFormatString="{0:d}"  InsertVisible="false" />
     </Columns>
           <EditRowStyle BackColor="#2461BF" />
     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
     <HeaderStyle BackColor="#8cb340" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
     <RowStyle BackColor="#EFF3FB" />
     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
     <SortedAscendingCellStyle BackColor="#F5F7FB" />
     <SortedAscendingHeaderStyle BackColor="#6D95E1" />
     <SortedDescendingCellStyle BackColor="#E9EBEF" />
     <SortedDescendingHeaderStyle BackColor="#4870BE" />
           </asp:GridView>
       </div>


      <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
