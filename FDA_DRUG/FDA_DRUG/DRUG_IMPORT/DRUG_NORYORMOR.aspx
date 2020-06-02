<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_PRODUCT_ID.Master" CodeBehind="DRUG_NORYORMOR.aspx.vb" Inherits="FDA_DRUG.WebForm28" %>

<%@ Register src="../DS/UC/UC_DS_GRID_TABLE.ascx" tagname="UC_DS_GRID_TABLE" tagprefix="uc1" %>


        <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
             <%--<script type="text/javascript" >
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

                     $('#ContentPlaceHolder1_UC_DS_GRID_TABLE1_btn_upload').click(function () {

                         //  $('#spinner').toggle('slow');
                         //Popups('../DS/POPUP_DS_UPLOAD_NORYORMOR.aspx');
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
             </script> --%>
        <uc1:UC_DS_GRID_TABLE ID="UC_DS_GRID_TABLE1" runat="server" />

                 
        </asp:Content>
