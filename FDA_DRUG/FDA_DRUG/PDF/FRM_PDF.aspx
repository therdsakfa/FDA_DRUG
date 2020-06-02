<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_PDF.aspx.vb" Inherits="FDA_DRUG.WebForm1" %>
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




           });


        </script> 
    <div id="spinner" style=" background-color:transparent; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 40px; left: 266px; height: 199px; width: 297px;" />
</div>
    <div style="text-align:center;">
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large"></asp:Label>
    </div>
</asp:Content>
