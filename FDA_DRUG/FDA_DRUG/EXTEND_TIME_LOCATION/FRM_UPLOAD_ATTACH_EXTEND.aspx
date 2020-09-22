<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_UPLOAD_ATTACH_EXTEND.aspx.vb" Inherits="FDA_DRUG.FRM_UPLOAD_ATTACH_EXTEND" %>
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
            กรุณาเลือกไฟล์แนบ</h3>

         <table class="table">
             <tr>
                 <td style="width: 15%;">
                     <asp:Label ID="Label1" runat="server" Text="หลักฐานการชำระงิน ค่าธรรมเนียม ต่ออายุใบอนุญาต"></asp:Label>
                 </td>
                 <td>
                     <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" />
                 </td>
             </tr>
             <tr>
                 <td style="width: 15%;">
                     <asp:Label ID="Label2" runat="server" Text="หลักฐานการชำระเงิน ค่าคำขอ ต่ออายุใบอนุญาตฯ"></asp:Label>
                 </td>
                 <td>
                     <asp:FileUpload ID="FileUpload2" runat="server" CssClass="btn-default" />
                 </td>
             </tr>
             <tr>
                 <td style="width: 15%;">
                     <asp:Label ID="Label3" runat="server" Text="หลักฐานการชำระเงินค่าตรวจประเมิน GPP"></asp:Label>
                 </td>
                 <td>
                     <asp:FileUpload ID="FileUpload3" runat="server" CssClass="btn-default" />
                 </td>
             </tr>
             <tr>
                 <td style="width: 15%;">
                     <asp:Label ID="Label4" runat="server" Text="ใบรับรองแพทย์"></asp:Label>
                 </td>
                 <td>
                     <asp:FileUpload ID="FileUpload4" runat="server" CssClass="btn-default" />
                 &nbsp;ระบุ 5 โรค ตามประกาศฯ ( โรคเรื้อน / วัณโคระยะในอันตราย โรคเท้าช้างในระยะปรากฏอาการ
เป็นที่น่ารังเกียจแก่สังคม / โรคติดยาเสพติดให้โทษอย่างร้ายแรง / โรคพิษสุราเรื้อรัง ) ออกให้ไม่เกิน 3 เดือน ของ
ผู้รับอนุญาต /ผู้ดำเนินกิจการ และผู้มีหน้าที่ปฏิบัติการ
                 </td>
             </tr>
             <%--<tr>
                 <td style="width: 15%;">
                     <asp:Label ID="Label5" runat="server" Text="รูปถ่ายของผู้รับอนุญาต ผู้ดำเนินกิจการ (รูปถ่ายสีขนาด 3 x 4 ชม. ถ่ายไว้ไม่เกิน 6 เดือนจำนวน 3 รูป ต่อประเภทใบอนุญาต ( หน้าตรงไม่ยิ้ม ไม่สวมแว่นตาและหมวก พื้นหลังสีเรียบ )"></asp:Label>
                 </td>
                 <td>
                     <asp:FileUpload ID="FileUpload5" runat="server" CssClass="btn-default" />
                 </td>
             </tr>--%>
             <tr>
                 <td style="width: 15%;">
                     <asp:Label ID="Label6" runat="server" Text="คำรับรองของผู้มีหน้าที่ปฏิบัติการทุกคน"></asp:Label>
                 </td>
                 <td>
                     <asp:FileUpload ID="FileUpload6" runat="server" CssClass="btn-default" /> เฉพาะ ข.ย.1 2 3 4&nbsp; (รวมไฟล์เดียว)</td>
             </tr>
              <tr>
                 <td style="width: 15%;">
                     <asp:Label ID="Label7" runat="server" Text="แผนที่ แสดงที่ตั้งของสถานที่ที่ขออนุญาต แนบเอกสารพร้อมใส่พิกัด"></asp:Label>
                 </td>
                 <td>
                     <asp:FileUpload ID="FileUpload7" runat="server" CssClass="btn-default" /> 
                 </td>
             </tr>
             <tr>
                 <td style="width: 15%;">
                     <asp:Label ID="Label8" runat="server" Text="รูปถ่ายด้านหน้าของสถานที่ที่ได้รับอนุญาต (เห็นป้ายชื่อสถานที่) พร้อมลงนามรับรองโดย ผู้รับอนุญาตผู้ดำเนินกิจการ ว่าเป็นภาพ ณ ปัจจุบันจากสถานที่จริง ณ ปัจจุบัน"></asp:Label>
                 </td>
                 <td>
                     <asp:FileUpload ID="FileUpload8" runat="server" CssClass="btn-default" /> 
                     <br />
                     แนบเอกสาร 3 รูป</td>
             </tr>
             <tr><td colspan="2"> <asp:Button ID="btn_Upload" runat="server" Text="อัพโหลด"   CssClass=" btn-lg" />
         </table>

    </div>
</asp:Content>
