<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_LCT_KEEP_UPLOAD.aspx.vb" Inherits="FDA_DRUG.POPUP_LCN_LCT_KEEP_UPLOAD" %>

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



             $('#ContentPlaceHolder1_btn_Upload').click(function () {
                 //    $('#spinner').center();
                 $('#spinner').fadeIn('slow');
                 //   alert('123');
             });



         });


        </script> 
      <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../DESIGN/imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    

    <table class="table" style="width:100%">
        <tr ><td style="width:20%"> <asp:Label ID="Label1" runat="server" Text="ใบคำขอ"></asp:Label> </td>
            <td><asp:FileUpload ID="FileUpload1" runat="server"  /></td><td>
    
            &nbsp;</td></tr>
        <tr ><td colspan="3"> 
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            </td>
            </tr>
        <tr ><td colspan="3"> 
    
      <asp:Button ID="btn_Upload" runat="server" Text="ยืนยัน"   CssClass=" btn-lg" Width="100px" />
             &nbsp;<asp:Button ID="btn_Upload0" runat="server" Text="ย้อนกลับ"   CssClass=" btn-lg" Width="100px"  />
            </td>
            </tr></table>
    <h4>
        หมายเหตุ : กรุณาจดเลขที่ได้หลังจากทำการอัพโหลดเรียบร้อยแล้ว
    </h4>
</asp:Content>
