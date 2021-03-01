<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DR_UPLOAD.aspx.vb" Inherits="FDA_DRUG.POPUP_DR_UPLOAD" %>

<%@ Register Src="~/UC/UC_ATTACH_DRUG.ascx" TagPrefix="uc1" TagName="UC_ATTACH_DRUG" %>

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
        </script> 
  <div id="spinner" style=" background-color:transparent;display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>
     <div style="width:100% ; text-align:left"  >
          <div style="width:auto ; float:left ;text-align:center;display:none">
              <h4>
         ยื่นข้อมูลที่&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:RadioButton ID="rbtn_bangkok" runat="server" Checked="True" GroupName="pvn" text="ศูนย์ อย."/>  &nbsp;&nbsp;&nbsp;&nbsp;  <asp:RadioButton ID="rbtn_other" runat="server" GroupName="pvn" Text="ต่างจังหวัด" />
      </h4>
    </div>

          <h3>
            กรุณาเลือกไฟล์ที่อยู่ของpdf
        </h3>

         <table class="table"> <tr><td style="width:15%;">   แบบคำขอ ย.1</td><td>   <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" />  </td></tr>
             <tr><td style="width:15%;"> <asp:Label ID="lbl_niti" runat="server" Text="เลขนิติฯ แห่งใหม่(กรณี Transfer)"></asp:Label>  </td><td>   
                 <asp:TextBox ID="txt_citizenid" runat="server"></asp:TextBox>
                 </td></tr>
             <tr><td style="width:15%;">   
                 <asp:Label ID="Label1" runat="server" Text="เลขดำเนินการ ยบ.8/ชื่อผลิตภัณฑ์" style="display:none;"></asp:Label>
                 </td><td>   
                     <asp:DropDownList ID="ddl_yor8" runat="server" style="display:none;">
                     </asp:DropDownList>
                 </td></tr>
             
             <tr><td colspan="2"> &nbsp;</td>
                 <asp:Panel ID="Panel101" runat="server" style="display:none;">
                     <uc1:UC_ATTACH_DRUG ID="uc_upload_1" runat="server" />
                    <%-- <uc1:UC_ATTACH_DRUG ID="uc_upload_9" runat="server" />--%>
                     <uc1:UC_ATTACH_DRUG ID="uc_upload_2" runat="server" />
                    <%-- <uc1:UC_ATTACH_DRUG ID="uc_upload_3" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc_upload_4" runat="server" />--%>
                      <uc1:UC_ATTACH_DRUG ID="uc_upload_5" runat="server" />
                      <uc1:UC_ATTACH_DRUG ID="uc_upload_6" runat="server" />
                      <%--<uc1:UC_ATTACH_DRUG ID="uc_upload_7" runat="server" />--%>
                      <uc1:UC_ATTACH_DRUG ID="uc_upload_8" runat="server" />
                     
                 </asp:Panel>
             </tr>
             <tr><td style="width:15%;">   
                 </td><td>   
                     <asp:CheckBox ID="cb_herbal" runat="server" Text="ขอรับรองว่ามาตรฐานของผลิตภัณฑ์นี้เป็นไปตามข้อกำหนดที่กำหนดไว้" style="display:none;" />
                 </td></tr>
             <tr><td colspan="2">&nbsp;</td></tr>
             <tr><td colspan="2"> <asp:Button ID="btn_Upload" runat="server" Text="อัพโหลด"   CssClass=" btn-lg" />
                 &nbsp;
                 <asp:Button ID="Button1" runat="server" Text="ปิด"  CssClass=" btn-lg" Width="150px"  />
                 </td></tr>
             <tr><td colspan="2">      หมายเหตุ : กรุณาแนบเอกสารเพิ่มเติมให้ครบทั้ง 6 ข้อ ในรูปแบบ PDF</td></tr>
         </table>

    </div>
</asp:Content>
