<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_RESEARCH_SUM_CONFIRM.aspx.vb" Inherits="FDA_DRUG.POPUP_RESEARCH_SUM_CONFIRM" %>
<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 30%;
            height: 33%;
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

           $('#ContentPlaceHolder1_btn_load0').click(function () {
               $('#myModal').modal('hide');
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

         <%--<asp:HyperLink ID="hl_reader" runat="server" Target="_blank" CssClass="btn-control" >
                 <input type="button" value="เปิดจาก acrobat reader"   class="btn-lg"   style="  Width:70%;" />
                       </asp:HyperLink>--%>
         <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    <table style="width:100%;height:500px;">
        <tr>
            <td rowspan="2" style="width:70%;">

                <%--<uc1:UC_CONFIRM ID="UC_CONFIRM1" runat="server" />--%>
                <div >
                     <asp:Literal ID="lr_preview" runat="server" ></asp:Literal>
    </div>
            </td>
             <td style="margin:auto; padding-top:40px; height:50%;" valign="top">
                     <center><h2><asp:Label ID="payment_status" runat="server" Text="Label" Visible="False" ForeColor="#00CC00"></asp:Label></h2></center>
                 <center>
                 <table class="table" style="width:90%"> 
                     <tr>
                                    <td>
                                       <%-- <asp:Button ID="Button1" runat="server" Text="จ่ายเงิน" />--%>
                                        <center>
                                        <asp:Button ID="btn_bill_pay" runat="server" CssClass="btn-lg" Width="80%" Text="พิมพ์ใบสั่งชำระ"  OnClientClick="OpenPopup1();" />
                                        </center>
                                    </td>
                                </tr>
                     <%--<tr><td><center><asp:Button ID="btn_confirm" runat="server" Text="ยื่นคำขอ" CssClass="btn-lg"   Width="80%" /></center></td></tr>--%>
                     <tr><td><center><asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg"   Width="80%" OnClientClick="return confirm('คุณต้องการยกเลิกหรือไม่');" /></center></td></tr>
                     <%--<tr><td><center><asp:Button ID="btn_load" runat="server" Text="Download" CssClass="btn-lg"   Width="80%" /></center></td></tr>--%>
                     <tr style="display:none;"><td><center><asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg"   Width="80%" /></center></td></tr>

                 </table>
                 </center>


             </td>
        </tr>
        <tr>
             <td style="margin:auto;">
                 <uc1:UC_GRID_ATTACH runat="server" id="UC_GRID_ATTACH" />
           
             </td>
        </tr>
        </table>
</asp:Content>
