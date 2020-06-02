<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_PRODUCT_PHESAJ.Master" CodeBehind="FRM_CHEMICAL_MAINV2.aspx.vb" Inherits="FDA_DRUG.FRM_CHEMICAL_MAINV2" %>
<%@ Register src="../UC/UC_Information.ascx" tagname="UC_Information" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <script type="text/javascript" >
           $(document).ready(function () {
               $(window).load(function () {
                   $.ajax({
                       type: 'POST',
                       data: { submit: true },
                       success: function (result) {
                           // $('#spinner').fadeOut('slow');
                       }
                   });
               });

               function CloseSpin() {
                   $('#spinner').toggle('slow');
               }

               $('#ContentPlaceHolder1_btn_add').click(function () {
                   var IDA = getQuerystring("lcn_ida");
                   var mt = getQuerystring("mt");
                   var st = getQuerystring("st");
                   //Popups('POPUP_DH_UPLOAD.aspx?fk_ida=' + IDA);
                   Popups('FRM_CHEMICAL_MAIN_INSERT_AND_UPDATE.aspx?lcn_ida=' + IDA + '&mt=' + mt + '&st=' + st);
                   return false;
               });

               $('#ContentPlaceHolder1_btn_download').click(function () {
                   $('#spinner').fadeIn('slow');

               });

               function Popups(url) { // สำหรับทำ Div Popup
                   $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                   var i = $('#f1'); // ID ของ iframe   
                   i.attr("src", url); //  url ของ form ที่จะเปิด
               }


           });
           function getQuerystring(key, default_) {
               if (default_ == null) default_ = "";
               key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
               var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
               var qs = regex.exec(window.location.href);
               if (qs == null)
                   return default_;
               else
                   return qs[1];
           }
           function Popups2(url) { // สำหรับทำ Div Popup
               $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
               var i = $('#f2'); // ID ของ iframe   
               i.attr("src", url); //  url ของ form ที่จะเปิด
           }
           function close_modal() { // คำสั่งสั่งปิด PopUp
               $('#myModal').modal('hide');
               $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
           }
           function spin_space() { // คำสั่งสั่งปิด PopUp
               //    alert('123456');
               $('#spinner').toggle('slow');
               //$('#myModal').modal('hide');
               //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
           }
           function closespinner() {
               $('#spinner').fadeOut('slow');
               alert('Download Success');
               $('#ContentPlaceHolder1_Button1').click();

           }
        </script> 
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
         <h2>
             <asp:Label ID="lbl_name_page" runat="server"></asp:Label>
         </h2>
        </div>
    <div class="panel-info" style="text-align: right; width: 100%">
        <div style="text-align: right; padding-left: 5%; height: 60px;">
            <asp:Button ID="btn_add" runat="server" Text="เพิ่มสาร" Width="170px" CssClass="btn-lg " />
            <asp:Button ID="btn_download" runat="server" Text="ดาวน์โหลดคำขอ" Width="170px" CssClass="btn-lg " style="display: none" />
            &nbsp;&nbsp;
       <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดคำขอ" Width="170px" CssClass="btn-lg " style="display: none"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
            <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
        </div>
    </div>
  
   <hr />
   <div>
       <asp:GridView ID="GV_data" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
           <AlternatingRowStyle BackColor="White" />
           <Columns>

               <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="0%" Visible="false">
                   <ItemStyle Width="0%"></ItemStyle>
               </asp:BoundField>
               <%--<asp:BoundField DataField="drug_no" HeaderText="เลขยา" ItemStyle-Width="20%">
                   <ItemStyle Width="10%"></ItemStyle>
               </asp:BoundField>--%>
       <asp:BoundField DataField="rcvno" HeaderText="เลขรับ" ItemStyle-Width="20%">
                   <ItemStyle Width="10%"></ItemStyle>
               </asp:BoundField>
               <asp:BoundField DataField="iowanm" HeaderText="ชื่อสาร" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
                <asp:BoundField DataField="stat" HeaderText="สถานะ" ItemStyle-Width="10%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
               <asp:BoundField DataField="iowa" HeaderText="iowa" ItemStyle-Width="10%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
               <asp:TemplateField ItemStyle-Width="20%" Visible="false">
                   <ItemTemplate>
                       <asp:Button ID="btn_edit" runat="server" Text="แก้ไข/ดูข้อมูล" CommandName="_edit" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                   </ItemTemplate>
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="20%">
                   <ItemTemplate>
                       <asp:Button ID="btn_accept" runat="server" OnClientClick="return confirm('คุณต้องการยืนยันข้อมูลหรือไม่');" Text="ยืนยันข้อมูล" CommandName="accept" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                   </ItemTemplate>
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:TemplateField>
           </Columns>
           <EditRowStyle BackColor="#2461BF" />
           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#8CB343" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#EFF3FB" />
           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
           <SortedAscendingCellStyle BackColor="#F5F7FB" />
           <SortedAscendingHeaderStyle BackColor="#6D95E1" />
           <SortedDescendingCellStyle BackColor="#E9EBEF" />
           <SortedDescendingHeaderStyle BackColor="#4870BE" />
       </asp:GridView>
       <%--<asp:GridView ID="GV_data" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
           <AlternatingRowStyle BackColor="White" />
           <Columns>

               <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="0%" Visible="false">
                   <ItemStyle Width="0%"></ItemStyle>
               </asp:BoundField>
       
               <asp:BoundField DataField="rcvno" HeaderText="เลขที่คำขอ" ItemStyle-Width="10%">
                   <ItemStyle Width="10%"></ItemStyle>
               </asp:BoundField>
                  
               <asp:BoundField DataField="rcvdate" DataFormatString="{0:d}" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
        
               <asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                   <ItemTemplate>
                       <asp:Label ID="lbl_status" runat="server"></asp:Label>
                   </ItemTemplate>

                   <ItemStyle Width="10%"></ItemStyle>
               </asp:TemplateField>
               <asp:TemplateField ItemStyle-Width="10%" HeaderText="รหัสการดำเนินการ">
                   <ItemTemplate>
                       <asp:Label ID="lbl_transession" runat="server"></asp:Label>
                   </ItemTemplate>

                   <ItemStyle Width="10%"></ItemStyle>
               </asp:TemplateField>
               <asp:TemplateField ItemStyle-Width="20%">
                   <ItemTemplate>

                       <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                       <asp:Button ID="btn_Preview" runat="server" Text="ดูข้อมูล" CommandName="preview" Width="0%" CssClass="btn-link" Visible="false" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                   </ItemTemplate>

                   <ItemStyle Width="20%"></ItemStyle>
               </asp:TemplateField>
           </Columns>
           <EditRowStyle BackColor="#2461BF" />
           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#8CB343" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#EFF3FB" />
           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
           <SortedAscendingCellStyle BackColor="#F5F7FB" />
           <SortedAscendingHeaderStyle BackColor="#6D95E1" />
           <SortedDescendingCellStyle BackColor="#E9EBEF" />
           <SortedDescendingHeaderStyle BackColor="#4870BE" />
       </asp:GridView>--%>

              <br />

              <div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  /> 
              </div>  
        </div>
    <div class=" modal fade" id="myModal">
        <div class="panel panel-info" style="width: 100%;">
            <div class="panel-heading  text-center">
                <h1>เพิ่มชื่อสาร </h1>
            </div>
            <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
            <div class="panel-body">
                <iframe id="f1" style="width: 100%; height: 550px;"></iframe>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>
    <div class=" modal fade" id="myModal2">
        <div class="panel panel-info" style="width: 100%;">
            <div class="panel-heading  text-center">
                <h1>เพิ่มชื่อสาร </h1>
            </div>
            <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
            <div class="panel-body">
                <iframe id="f2" style="width: 100%; height: 550px;"></iframe>
            </div>
            <div class="panel-footer"></div>
        </div>
    </div>
</asp:Content>
