<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_STAFF_EXTEND_TIME_LOCATION_CONFIRM.aspx.vb" Inherits="FDA_DRUG.POPUP_STAFF_EXTEND_TIME_LOCATION_CONFIRM" %>
<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>

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
                       //    $('#spinner').fadeOut('slow');
                   }
               });
           });

           function CloseSpin() {
               $('#spinner').toggle('slow');
           }

           $('#ContentPlaceHolder1_btn_upload').click(function () {

               $('#spinner').toggle('slow');
               Popups('POPUP_LCN_UPLOAD.aspx');
               return false;
           });

           $('#ContentPlaceHolder1_btn_download').click(function () {
               $('#spinner').fadeIn('slow');
               Popups('POPUP_LCN_DOWNLOAD.aspx');
               return false;
           });

           function Popups(url) { // สำหรับทำ Div Popup
               $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
               var i = $('#f1'); // ID ของ iframe   
               i.attr("src", url); //  url ของ form ที่จะเปิด
           }

           function close_modal() { // คำสั่งสั่งปิด PopUp
               $('#myModal').modal('hide');
               $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
           }
       });

       function spin_space() { // คำสั่งสั่งปิด PopUp
           //    alert('123456');
           $('#spinner').toggle('slow');
           //$('#myModal').modal('hide');
           //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

       }
       function closespinner() {
           $('#spinner').fadeOut('slow');
           alert('Download Success');
           Loaddata();
       }
        </script> 
  <div id="spinner" style=" background-color:transparent;display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
                
</div>

    <div>

         <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    <table style="width:100%;">
        <tr>
            <td rowspan="2" style="width:70%;">

                <%--<uc1:UC_CONFIRM ID="UC_CONFIRM1" runat="server" />--%>
                <div >
                     <table class="table" style="width:100%">
                         <tr>
                             <td align="right">เขียนที่ :</td>
                             <td>
                                 <asp:TextBox ID="txt_WRITE_AT" runat="server" CssClass="input-sm" Width="200px" Enabled="false"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td align="right">วันที่ :</td>
                             <td>
                                 <asp:TextBox ID="txt_WRITE_DATE" runat="server" CssClass="input-sm" Width="200px" Enabled="false"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td align="right">ได้รับอนุญาตให้ :</td>
                             <td>
                                 <asp:RadioButtonList ID="RadioButtonList1" runat="server" Enabled="false">
                                     <asp:ListItem Selected="True" Value="1">ขายยาแผนปัจจุบัน</asp:ListItem>
                                     <asp:ListItem Value="2">ขายยาแผนปัจจุบันเฉพาะยาบรรจุเสร็จที่ไม่ใช่ยาอันตรายหรือยาควบคุมพิเศษ</asp:ListItem>
                                     <asp:ListItem Value="3">ขายยาแผนปัจจุบันเฉพาะยาบรรจุเสร็จสำหรับสัตว์</asp:ListItem>
                                     <asp:ListItem Value="4">ขายส่งยาแผนปัจจุบัน</asp:ListItem>
                                 </asp:RadioButtonList>
                             </td>
                         </tr>
                         <tr>
                             <td align="right">เลขที่ใบอนุญาต :</td>
                             <td>
                                 <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td align="right">เพื่อใช้ต่อไปในปี พ.ศ.</td>
                             <td>
                                 <asp:TextBox ID="txt_year" runat="server"></asp:TextBox>
                             </td>
                         </tr>
                     </table>
    </div>
            </td>
             <td style="padding-left:10%;height:50%;">

                 <table class="table" style="width:90%"> 
                     <tr><td>
                                                  <asp:DropDownList ID="ddl_cnsdcd" runat="server" Width="80%" DataTextField="STATUS_NAME" DataValueField="STATUS_ID">
                         </asp:DropDownList>
                         
                         </td></tr>
                     <tr><td><asp:Button ID="btn_confirm" runat="server" Text="ยืนยัน" CssClass="btn-lg"   Width="80%" /></td></tr>
                     <tr><td> <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg"   Width="80%"/></td></tr>
                     <tr><td>  <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg"   Width="80%" /></td></tr>

                 </table>
                 


             </td>
        </tr>
        <tr>
             <td style="width:30%;height:50%;padding-left:10%">
                 &nbsp;</td>
        </tr>
        </table>
</asp:Content>