<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_RGT_UPLOAD.aspx.vb" Inherits="FDA_DRUG.FRM_RGT_UPLOAD" %>
<%@ Register src="../UC/UC_ATTACH_DRUG.ascx" tagname="UC_ATTACH_DRUG" tagprefix="uc1" %>
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

         <table class="table" style="width:100%;"> <tr><td style="width:15%;">   ใบคำขอ</td><td>   <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" />  </td></tr>
             <tr><td style="width:15%;">   โปรดระบุวิธียื่นเอกสารประกอบคำขอ</td><td>   
                 <table style="width:100%;">
                     <tr>
                         <td>
                             <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                                 <asp:ListItem Value="1">1. ยื่นผ่านระบบ eReview/docuBridge</asp:ListItem>
                                 <asp:ListItem Value="2">2. ยื่นผ่านระบบ Skynet Smart Dropbox</asp:ListItem>
                                 <asp:ListItem Value="3">3. ยื่นผ่านระบบ PDF ผ่านระบบนี้ </asp:ListItem>
                                 <asp:ListItem Value="4">4. ยื่นผ่านระบบ walk in</asp:ListItem>
                             </asp:RadioButtonList>
                         </td>
                     </tr>
                     <tr>
                         <td>
                    กรณีเลือกข้อ 1 และ 2 ให้ระบุเลข identifier/รหัสอ้างอิง <span style="padding-left:10px;"></span><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                 </td>
                     </tr>
                 </table>
                
                 
                 </td></tr>
             <tr><td colspan="2">  
                 <asp:Panel ID="Panel101" runat="server" >
                     <%--<uc1:UC_ATTACH_DRUG ID="uc102_1" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc102_2" runat="server" />--%>
                     <uc1:UC_ATTACH_DRUG ID="uc102_3" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc102_4" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc102_5" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc102_6" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc102_7" runat="server" />
                     <uc1:UC_ATTACH_DRUG ID="uc102_8" runat="server" />
                 </asp:Panel>
                 <asp:Panel ID="Panel201" runat="server" >
                     <table>
                         <tr>
                             <td>
                                 <uc1:UC_ATTACH_DRUG ID="uc201" runat="server" />
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <uc1:UC_ATTACH_DRUG ID="uc202" runat="server" />
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <table>
                                     <tr>
                                         <td><uc1:UC_ATTACH_DRUG ID="uc203" runat="server" /></td><td><font color="red">*</font></td>
                                     </tr>
                                 </table>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <uc1:UC_ATTACH_DRUG ID="uc204" runat="server" />
                             </td>
                         </tr>
                     </table>
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

