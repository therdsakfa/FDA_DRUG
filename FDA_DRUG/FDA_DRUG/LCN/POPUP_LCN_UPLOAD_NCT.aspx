<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_UPLOAD_NCT.aspx.vb" Inherits="FDA_DRUG.POPUP_LCN_UPLOAD_NCT" %>
<%@ Register src="../UC/UC_ATTACH_DRUG.ascx" tagname="UC_ATTACH_DRUG" tagprefix="uc1" %>
<%@ Register Src="~/UC/UC_ATTACH_DRUG.ascx" TagPrefix="uc2" TagName="UC_ATTACH_DRUG" %>

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

         <table class="table"> <tr><td style="width:15%;">   ใบคำขอ</td><td>   <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" />  </td></tr>
             <tr><td colspan="2">
                 <!-- ข.จ.2 --> 
                 <asp:Panel ID="Panel201" runat="server" style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc101_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc101_2" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc101_3" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc101_4" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc101_5" runat="server" />
                 </asp:Panel>

                 <!-- จ.ย.ส.3 -->
                 <asp:Panel ID="Panel202" runat="server" style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc102_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc102_2" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc102_3" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc102_4" runat="server" />
                     </asp:Panel>

                 <%--<!-- ขย.3 -->
                 <asp:Panel ID="Panel103" runat="server" style="display:none;">
                     <uc1:UC_ATTACH_DRUG ID="uc103_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc103_2" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc103_3" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc103_4" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc103_5" runat="server" />
                 </asp:Panel>

                 <!-- ขย.4 -->
                 <asp:Panel ID="Panel104" runat="server" style="display:none;">
                     <uc2:UC_ATTACH_DRUG runat="server" ID="uc104_1" />
                     <uc2:UC_ATTACH_DRUG runat="server" ID="uc104_2" />
                     <uc2:UC_ATTACH_DRUG runat="server" ID="uc104_3" />
                     <uc2:UC_ATTACH_DRUG runat="server" ID="uc104_4" />
                     <uc2:UC_ATTACH_DRUG runat="server" ID="uc104_5" />
                 </asp:Panel>

                 <!-- นย.1 -->
                 <asp:Panel ID="Panel105" runat="server" style="display:none;">
                     <uc2:UC_ATTACH_DRUG ID="uc105_1" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc105_2" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc105_3" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc105_4" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc105_5" runat="server" />
                 </asp:Panel>

                 <!-- ผย.1 -->
                 <asp:Panel ID="Panel106" runat="server" style="display:none;">
                     <uc2:UC_ATTACH_DRUG ID="uc106_1" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc106_2" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc106_3" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc106_4" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc106_5" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc106_6" runat="server" />
                 </asp:Panel>

                 <!-- ขยบ. -->
                 <asp:Panel ID="Panel107" runat="server" style="display:none;">
                     <uc2:UC_ATTACH_DRUG ID="uc107_1" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc107_2" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc107_3" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc107_4" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc107_5" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc107_6" runat="server" />
                 </asp:Panel>

                 <!-- นยบ. -->
                 <asp:Panel ID="Panel108" runat="server" style="display:none;">
                     <uc2:UC_ATTACH_DRUG ID="uc108_1" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc108_2" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc108_3" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc108_4" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc108_5" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc108_6" runat="server" />
                 </asp:Panel>

                 <!-- ผยบ. -->
                 <asp:Panel ID="Panel109" runat="server" style="display:none;">
                     <uc2:UC_ATTACH_DRUG ID="uc109_1" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc109_2" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc109_3" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc109_4" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc109_5" runat="server" />
                     <uc2:UC_ATTACH_DRUG ID="uc109_6" runat="server" />
                 </asp:Panel>--%>
                 </td></tr>
             <tr><td colspan="2">&nbsp;</td></tr>
             <tr><td colspan="2"> <asp:Button ID="btn_Upload" runat="server" Text="อัพโหลด"   CssClass=" btn-lg" />
                 &nbsp;
                 <asp:Button ID="Button1" runat="server" Text="ปิด"  CssClass=" btn-lg" Width="150px"  />
                 </td></tr>
             <tr><td colspan="2">      หมายเหตุ : กรุณาจดเลขที่ได้หลังจากทำการอัพโหลดเรียบร้อยแล้ว</td></tr>
         </table>

    </div>
</asp:Content>
