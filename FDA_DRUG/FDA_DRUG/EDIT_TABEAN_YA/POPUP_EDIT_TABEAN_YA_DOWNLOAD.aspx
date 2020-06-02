<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_EDIT_TABEAN_YA_DOWNLOAD.aspx.vb" Inherits="FDA_DRUG.FRM_EDIT_TABEAN_YA_DOWNLOAD" %>
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

             $('#ContentPlaceHolder1_btn_upload').click(function () {
                 var IDA = getQuerystring("IDA");
                 var fk_ida = getQuerystring("fk_ida");
                 var type = getQuerystring("type");
                 //  $('#spinner').toggle('slow');
                 Popups('POPUP_DI_UPLOAD.aspx?IDA=' + IDA + '&fk_ida=' + fk_ida + '&type=' + type);
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

         function Popups2(url) { // สำหรับทำ Div Popup
             $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
             var i = $('#f1'); // ID ของ iframe   
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
        </script> 
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
   <table style="width:100%;text-align:center;">
       <tr>
           <td style="width:50%;">
                <asp:Button ID="btn_auto" runat="server" Text="auto" CssClass="btn-lg" />
           </td>
           <td style="width:50%;">
                <asp:Button ID="btn_manual" runat="server" Text="manual"   CssClass="btn-lg"  />
           </td>
       </tr>
   </table>
    <asp:Button ID="Button1" runat="server" Text="" Style="display:none;"   CssClass="btn-lg"  />
</asp:Content>
