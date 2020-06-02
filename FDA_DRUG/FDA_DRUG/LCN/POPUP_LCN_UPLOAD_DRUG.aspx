<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_UPLOAD_DRUG.aspx.vb" Inherits="FDA_DRUG.POPUP_LCN_UPLOAD_DRUG" %>
<%@ Register src="../UC/UC_ATTACH_DRUG.ascx" tagname="UC_ATTACH_DRUG" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 126px;
        }
    </style>
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
    <div id="spinner" style=" background-color:transparent; " >
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: -18px; left: 313px; height: 185px; width: 207px;" />
</div>
      <div style="width:100% ; text-align:left"  >
          <div style="width:auto ; float:left ;text-align:center;display:none">
              <h4>
         ยื่นข้อมูลที่&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="rbtn_bangkok" runat="server" Checked="True" GroupName="pvn" text="ศูนย์ อย."/>  &nbsp;&nbsp;&nbsp;&nbsp;  <asp:RadioButton ID="rbtn_other" runat="server" GroupName="pvn" Text="ต่างจังหวัด" />
      </h4>
    </div>

        <h3>
            &nbsp;</h3>
          <h3>
            กรุณาเลือกไฟล์ที่อยู่ของpdf


        <div style="width:auto ; float:left">
    
             </div>
        
    </div>
    <hr />
    <h4>
        หมายเหตุ : กรุณาจดเลขที่ได้หลังจากทำการอัพโหลดเรียบร้อยแล้ว
    </h4>

    <table class="table" style="width:100%">
        <tr class="row"><td colspan="2">กรุณาเลือกไฟล์ที่อยู่ของpdf</td><td rowspan="5">
    
      <asp:Button ID="btn_Upload" runat="server" Text="อัพโหลด"   CssClass=" btn-lg" />
             </td></tr>
        <tr class="row"><td style="width:145px;">ไฟล์ PDF</td><td>&nbsp;</td></tr>
        <tr class="row"><td colspan="3"><uc1:UC_ATTACH_DRUG ID="UC_ATTACH_DRUG1" runat="server" /></td></tr>
        <tr class="row"><td colspan="3"></td></tr>
        <tr class="row"><td colspan="3"></td></tr>
    </table>


    <table class="table"> <tr class="row"><td>ไฟล์ PDF</td><td class="auto-style1"><asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" />   </td><td rowspan="5"></td></tr> <tr class="row"><td>&nbsp;</td><td class="auto-style1">&nbsp;</td></tr> <tr class="row"><td>&nbsp;</td><td class="auto-style1">&nbsp;</td></tr> <tr class="row"><td>&nbsp;</td><td class="auto-style1">&nbsp;</td></tr> <tr class="row"><td>&nbsp;</td><td class="auto-style1">&nbsp;</td></tr></table>
     <asp:Panel ID="Panel1" runat="server">
         <uc1:UC_ATTACH_DRUG ID="UC_ATTACH_DRUG2" runat="server" />
         <uc1:UC_ATTACH_DRUG ID="UC_ATTACH_DRUG4" runat="server" />
         <uc1:UC_ATTACH_DRUG ID="UC_ATTACH_DRUG5" runat="server" />
     </asp:Panel>
     <br />
</asp:Content>
