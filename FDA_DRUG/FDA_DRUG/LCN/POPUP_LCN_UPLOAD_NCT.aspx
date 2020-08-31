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

                 <!-- ขวจ3 -->
                 <asp:Panel ID="Panel123" runat="server" style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc123_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc123_2" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc123_3" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc123_4" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc123_5" runat="server" />
                 </asp:Panel>
                 <!-- ขวจ3 -->
                 <asp:Panel ID="Panel124" runat="server" Style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc124_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc124_2" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc124_3" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc124_4" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc124_5" runat="server" />
                 </asp:Panel>
                 <asp:Panel ID="Panel125" runat="server" Style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc125_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc125_2" runat="server" />
                 </asp:Panel>
                 <asp:Panel ID="Panel126" runat="server" Style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc126_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc126_2" runat="server" />
                 </asp:Panel>
                 <asp:Panel ID="Panel127" runat="server" Style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc127_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc127_2" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc127_3" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc127_4" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc127_5" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc127_6" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc127_7" runat="server" />
                 </asp:Panel>
                 <asp:Panel ID="Panel128" runat="server" Style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc128_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc128_2" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc128_3" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc128_4" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc128_5" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc128_6" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc128_7" runat="server" />
                 </asp:Panel>
                  <asp:Panel ID="Panel129" runat="server" Style="display: none;">
                      <uc1:UC_ATTACH_DRUG ID="uc129_1" runat="server" />
                </asp:Panel>
                 <asp:Panel ID="Panel130" runat="server" Style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc130_1" runat="server" />
                 </asp:Panel>
                 <asp:Panel ID="Panel131" runat="server" Style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc131_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc131_2" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc131_3" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc131_4" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc131_5" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc131_6" runat="server" />
                 </asp:Panel>
                 <asp:Panel ID="Panel132" runat="server" Style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc132_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc132_2" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc132_3" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc132_4" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc132_5" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc132_6" runat="server" />
                 </asp:Panel>
                 <asp:Panel ID="Panel133" runat="server" Style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc133_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc133_2" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc133_3" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc133_4" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc133_5" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc133_6" runat="server" />
                 </asp:Panel>
                 <asp:Panel ID="Panel134" runat="server" Style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc134_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc134_2" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc134_3" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc134_4" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc134_5" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc134_6" runat="server" />
                 </asp:Panel>
                 <asp:Panel ID="Panel135" runat="server" Style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc135_1" runat="server" />
                 </asp:Panel>
                 <asp:Panel ID="Panel136" runat="server" Style="display: none;">
                     <uc1:UC_ATTACH_DRUG ID="uc136_1" runat="server" />
                 </asp:Panel>
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
