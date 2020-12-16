<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DS_MAIN.ascx.vb" Inherits="FDA_DRUG.UC_DS_MAIN" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
    <meta http-equiv="Content-Security-Policy" content="upgrade-insecure-requests">
    <script type="text/javascript" >
    



          $(document).ready(function () {
              //$(window).load(function () {
              //    $.ajax({
              //        type: 'POST',
              //        data: { submit: true },
              //        success: function (result) {
              //            $('#spinner').fadeOut(1);

              //        }
              //    });
              //});

              function CloseSpin() {
                  $('#spinner').toggle('slow');
              }

              //$('#ContentPlaceHolder1_btn_upload').click(function () {
              //    var IDA = getQuerystring("IDA");
              //    var process = getQuerystring("process");
              //    Popups('POPUP_LCN_UPLOAD_ATTACH.aspx?IDA=' & IDA  & '&process=' & process & '');
              //    return false;
              //});

              //$('#ContentPlaceHolder1_btn_download').click(function () {
              //    Popups('POPUP_LCN_DOWNLOAD_DRUG.aspx');
              //    return false;
              //});

              function Popups(url) { // สำหรับทำ Div Popup

                  $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                  var i = $('#f1'); // ID ของ iframe   
                  i.attr("src", url); //  url ของ form ที่จะเปิด
              }




              $('#ContentPlaceHolder1_btn_download').click(function () {
                  $('#spinner').fadeIn('slow');

              });

          });
          function close_modal() { // คำสั่งสั่งปิด PopUp
              $('#myModal').modal('hide');
              $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
          }

          function Popups2(url) { // สำหรับทำ Div Popup

              $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
              var i = $('#f1'); // ID ของ iframe   
              i.attr("src", url); //  url ของ form ที่จะเปิด
          }
          function Popups3(url) { // สำหรับทำ Div Popup

              $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
              var i = $('#f3'); // ID ของ iframe   
              i.attr("src", url); //  url ของ form ที่จะเปิด
          }
          function Popups4(url) { // สำหรับทำ Div Popup

              $('#myModal4').modal('toggle'); // เป็นคำสั่งเปิดปิด
              var i = $('#f4'); // ID ของ iframe   
              i.attr("src", url); //  url ของ form ที่จะเปิด
          }
          function spin_space() { // คำสั่งสั่งปิด PopUp
              //    alert('123456');
              $('#spinner').toggle('slow');
              //$('#myModal').modal('hide');
              //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

          }
          function closespinner() {
              alert('Download เสร็จสิ้น');
              $('#spinner').fadeOut('slow');
              $('#ContentPlaceHolder1_Button1').click();
          }
        </script> 
<style type="text/css">
    .auto-style2 {
        height: 49px;
    }
</style>
     
     <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:100px" > 
             <div  class="col-lg-4 col-md-4"><h4 class="auto-style2"> ใบอนุญาต<asp:Label ID="lbl_name_2" runat="server"  Text=""></asp:Label><asp:Label ID="lbl_name" runat="server"  Text=""></asp:Label> </h4>
             </div>
                          <div  class="col-lg-8 col-md-8">
                               <p style="text-align:right;padding-right:5%;">
            <asp:Button ID="btn_download" runat="server" Text="เพิ่มคำขอ" CssClass="btn-lg" Height="50px" style="font-size: large" Width="200px" />
        &nbsp;&nbsp;
            <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดคำขอ" CssClass="btn-lg" Height="50px" style="font-size: large" Width="200px"  />
                                     <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"  />
                                     <asp:Button ID="Button1" runat="server" Text="" style="display:none;"  />
        </p>
                               <p style="text-align:right;padding-right:5%;">
                                   &nbsp;</p>
                          </div>
         </div> 
    </div>
       <div class="panel panel-body"  style="width:100%;padding-left:5%;">
            <br />
            <asp:GridView ID="GV_lcnno" runat="server" Width="100%" DataKeyNames="IDA" CellPadding="4" CssClass="table"
               ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" Font-Size="10pt" style="margin-top: 12px">
               <AlternatingRowStyle BackColor="White" />
               <Columns>
                
                   <asp:BoundField DataField="UPLOAD_DATE" HeaderText="วันเวลาที่ส่งคำขอ" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                       <ItemStyle HorizontalAlign="center" Width="15%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="LCNNO_DISPLAY" HeaderText="รหัสบัญชีรายการยา" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                       <ItemStyle HorizontalAlign="center" Width="20%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="drug_name" HeaderText="ชื่อยา (Th/Eng)" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                       <ItemStyle HorizontalAlign="center" Width="15%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="ID" HeaderText="รหัสดำเนินการ" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">

                       <ItemStyle HorizontalAlign="center" Width="15%"></ItemStyle>
                   </asp:BoundField>
                    <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="center">

                       <ItemStyle HorizontalAlign="center" Width="15%"></ItemStyle>
                   </asp:BoundField>
                   <asp:TemplateField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                       <ItemTemplate>
                           <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล/ยื่นคำขอ" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                           &nbsp; &nbsp; &nbsp;                        
                       </ItemTemplate>

                       <ItemStyle Width="15%" HorizontalAlign="center"></ItemStyle>
                   </asp:TemplateField>
                  
                   </Columns>
               <EmptyDataTemplate>
                   <center>ไม่พบข้อมูล</center>
               </EmptyDataTemplate>
               <EditRowStyle BackColor="#2461BF" />
               <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               <HeaderStyle BackColor="#8CB340 " Font-Bold="True" ForeColor="White" CssClass="row" />
               <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
               <RowStyle BackColor="#EFF3FB" CssClass="row" />
               <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
               <SortedAscendingCellStyle BackColor="#F5F7FB" />
               <SortedAscendingHeaderStyle BackColor="#6D95E1" />
               <SortedDescendingCellStyle BackColor="#E9EBEF" />
               <SortedDescendingHeaderStyle BackColor="#4870BE" />
           </asp:GridView>

                      <div class="h5" style="padding-left:87%;">  
                      <asp:HyperLink ID="hl_pay" runat="server"  target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
                        </div>
                               
    </div>
    
   