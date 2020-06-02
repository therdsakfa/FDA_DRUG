<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_EXTEND_TIME_LOCATION_SAVE.aspx.vb" Inherits="FDA_DRUG.FRM_EXTEND_TIME_LOCATION_SAVE" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 407px;
        }
    </style>
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
                               
                             <td align="right" class="auto-style1">ประเภทคำขอ :</td>
                             <td>
                                 <asp:Label ID="lbl_lcntpcd" runat="server" Text="-"></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" class="auto-style1">เลขที่ใบอนุญาต :</td>
                             <td>
                                <asp:Label ID="lbl_lcnno_display_full" runat="server" Text="-"></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" class="auto-style1">ชื่อสถานที่ :</td>
                             <td>
                                  <asp:Label ID="lbl_thanm" runat="server" Text="-"></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" class="auto-style1">ที่อยู่ :</td>
                             <td>
                                 <asp:Label ID="lbl_thanm_address" runat="server" Text="-"></asp:Label>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" class="auto-style1">ชื่อผู้ดำเนินกิจการ :</td>
                             <td>
                                 <asp:Label ID="lbl_grannm_lo" runat="server" Text="-"></asp:Label>
                             </td>
                         </tr>
                             <td align="right" class="auto-style1">จังหวัด :</td>
                             <td>
                                 <asp:Label ID="lbl_thachngwtnm" runat="server" Text="-"></asp:Label>
                             </td>
                         </tr>
                            <td align="right" class="auto-style1">ปีที่หมดอายุ :</td>
                             <td>
                                 <asp:Label ID="lbl_expyear" runat="server" Text="-"></asp:Label>
                             </td>
                         </tr>
                            <td align="right" class="auto-style1">สถานะการชำระเงิน :</td>
                             <td>
                                 <asp:Label ID="lbl_status_pay" runat="server" Text="-"></asp:Label>
                             </td>
                         </tr>
                     </table>
    </div>
            </td>
             <td style="padding-left:10%;height:50%;">

                 <table class="table" style="width:90%"> 
                       <tr>
                         <td>&nbsp; เจ้าหน้าที่ :
                             <asp:Label ID="lbl_staff" runat="server" Text="-"></asp:Label>

                         </td>
                     </tr>
                     <tr>
                         <td>&nbsp;

                         วันที่รับ :
                             <asp:Label ID="lbl_date" runat="server" Text="-"></asp:Label>

                         </td>
                     </tr>
                      <tr>
                         <td>&nbsp;

                         วันที่อนุมัติ :
                             <asp:Label ID="lbl_app_date" runat="server" Text="-"></asp:Label>

                         </td>
                     </tr>
                    <%-- <tr>
                         <td>&nbsp;

                         วันที่คาดว่าจะอนุมัติ :
                             <asp:Label ID="lbl_app_date" runat="server" Text="-"></asp:Label>

                         </td>
                     </tr>--%>
                     <tr><td>
                                                  <asp:DropDownList ID="ddl_cnsdcd" runat="server" Width="80%" DataTextField="STATUS_NAME" DataValueField="STATUS_ID">
                                                      <%--<asp:ListItem Value="1">รอชำระเงิน</asp:ListItem>
                                                      <asp:ListItem Value="2">รับคำขอ</asp:ListItem>
                                                      <asp:ListItem Value="3">อนุมัติ</asp:ListItem>--%>

                         </asp:DropDownList>
                         
                         </td></tr>
                     <tr><td><asp:Button ID="btn_confirm" runat="server" Text="ยืนยัน" CssClass="btn-lg"   Width="80%" /></td></tr>
                    <%-- <tr><td> <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg"   Width="80%"/></td></tr>--%>
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