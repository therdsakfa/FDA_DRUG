<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_UPLOAD_ATTACH_SELECT.aspx.vb" Inherits="FDA_DRUG.POPUP_LCN_UPLOAD_ATTACH_SELECT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
         <script type="text/javascript" >

             jQuery.fn.center = function () {
                 this.css("position", "absolute");

                 this.css("top", Math.max(0, (($(window).height() / 2.0)) +
                                                             $(window).scrollTop()) + "px");
                 this.css("left", Math.max(0, (($(window).width() / 2.0)) +
                                                             $(window).scrollLeft()) + "px");
                 return this;
             }

             $(document).ready(function () {
                 $(window).load(function () {
                     $.ajax({
                         type: 'POST',
                         data: { submit: true },
                         success: function (result) {
                             //   $('#spinner').center();
                             $('#spinner').fadeOut('slow');
                         }
                     });
                 });



                 $('#ContentPlaceHolder1_btn_manufacturt').click(function () {
                     //    $('#spinner').center();
                     $('#spinner').fadeIn('slow');
                     //   alert('123');
                 });

                 $('#ContentPlaceHolder1_btn_manufacturt2').click(function () {
                     //    $('#spinner').center();
                     $('#spinner').fadeIn('slow');
                     //   alert('123');
                 });

                 $('#ContentPlaceHolder1_btn_import').click(function () {
                     //    $('#spinner').center();
                     $('#spinner').fadeIn('slow');
                     //   alert('123');
                 });

                 $('btn').click(function () {
                     //    $('#spinner').center();
                     $('#spinner').fadeIn('slow');
                     //   alert('123');
                 });



             });

             function loadsuccess() {
                 alert('Download เสร็จสิ้น');
                 $('#spinner').fadeOut('slow');
                 $('#ContentPlaceHolder1_Button1').click();
             }

        </script> 
    <div id="spinner" style=" background-color:transparent; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute;  top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>
    <asp:Button ID="btn_1" runat="server" CssClass="btn-lg" Text="ขย 1" />
    &nbsp;&nbsp;&nbsp;
     <asp:Button ID="btn_2" runat="server" CssClass="btn-lg" Text="ขย 2"  />
    &nbsp;&nbsp;&nbsp; 
    &nbsp;<asp:Button ID="btn_3" runat="server" CssClass="btn-lg" Text="ขย 3" />

         <asp:Button ID="Button1" runat="server" Text="Button" style="display:none" />

&nbsp;&nbsp; 
    <asp:Button ID="btn_4" runat="server" CssClass="btn-lg" Text="ขย 4" />
    &nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btn_5" runat="server" CssClass="btn-lg" Text="นย 1" />
    &nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btn_6" runat="server" CssClass="btn-lg" Text="ผย 1" />
    &nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btn_7" runat="server" CssClass="btn-lg" Text="ขยบ" />
    &nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btn_8" runat="server" CssClass="btn-lg" Text="นยบ" />
    &nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btn_9" runat="server" CssClass="btn-lg" Text="ผยบ" />
         <br />
         <br />
    <asp:Button ID="btn_10" runat="server" CssClass="btn-lg" Text="ผลิตวัตถุออกฤทธิ์ฯในประเภท ๓ หรือ ประเภท ๔" />
    &nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btn_11" runat="server" CssClass="btn-lg" Text="ขายวัตถุออกฤทธิ์ฯในประเภท ๓ หรือ ประเภท ๔" />
    &nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btn_12" runat="server" CssClass="btn-lg" Text="ขายวัตถุออกฤทธิ์ฯโดยการขายส่งตรง" />
    &nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btn_13" runat="server" CssClass="btn-lg" Text="นำเข้าวัตถุออกฤทธิ์ฯในประเภท ๓ หรือ ประเภท ๔" />
         &nbsp;&nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btn_15" runat="server" CssClass="btn-lg" Text="ผลิตยาเสพติดให้โทษในประเภท ๓" />
    &nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btn_16" runat="server" CssClass="btn-lg" Text="จำหน่ายยาเสพติดให้โทษในประเภท ๓" />
    &nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btn_17" runat="server" CssClass="btn-lg" Text="นำเข้ายาเสพติดให้โทษในประเภท ๓" />
    &nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btn_18" runat="server" CssClass="btn-lg" Text="ส่งออกยาเสพติดให้โทษในประเภท ๓" />
     &nbsp;&nbsp;&nbsp; 
    <asp:Button ID="btn_19" runat="server" CssClass="btn-lg" Text="ขายส่งยาแผนปัจจุบัน" />

</asp:Content>