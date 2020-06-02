<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DS_UPLOAD_NORYORMOR.aspx.vb" Inherits="FDA_DRUG.POPUP_DS_UPLOAD_NORYORMOR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../../Scripts/jquery-1.8.2.js"></script>
    <script src="../../../Jsdate/ui.datepicker.js"></script>
    <script src="../../../Jsdate/ui.datepicker-th.js"></script>
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

              $(function () {
                  $("#ContentPlaceHolder1_txt_start_date").datepicker({
                      changeMonth: true,
                      changeYear: true,
                      //format: 'mm/yyyy'
                  });
              });
              $(function () {
                  $("#ContentPlaceHolder1_txt_end_date").datepicker({
                      changeMonth: true,
                      changeYear: true,
                      //format: 'mm/yyyy'
                  });
              });
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

         <table class="table"> <tr>
             <td class="auto-style1">   ใบคำขอ</td><td>   <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" />  </td></tr>
             <tr><td colspan="2">&nbsp;</td></tr>
             <tr><td colspan="2"> แนบเอกสารหลักฐาน</td></tr>
             <tr><td class="auto-style1">   
                 <asp:Label ID="lbl_attach1" runat="server" Text="-"></asp:Label>
                 </td><td>   <asp:FileUpload ID="FileUpload2" runat="server" CssClass="btn-default" />  </td></tr>
             <tr><td class="auto-style1">   
                 <asp:Label ID="lbl_attach3" runat="server" Text="-"></asp:Label>
                 </td><td>   <asp:FileUpload ID="FileUpload3" runat="server" CssClass="btn-default" />  </td></tr>
             <tr  id="tbox0" style="display:none;" runat="server"><td class="auto-style1">   
                 <asp:Label ID="lbl_attach4" runat="server" Text="-"></asp:Label>
                 </td><td>   <asp:FileUpload ID="FileUpload4" runat="server" CssClass="btn-default" />  
                 </td></tr>
             <tr id="nym3" style="display:none;" runat="server"><td class="auto-style1">
                 </td><td>
                     วันเริ่มนิทรรศการ :
                     <asp:TextBox ID="txt_start_date" runat="server"></asp:TextBox>
                     <br />
                     วันสิ้นสุดนิทรรศการ :
                     <asp:TextBox ID="txt_end_date" runat="server"></asp:TextBox>
                 </td></tr>
             <tr style="display:none;"><td class="auto-style1">   
                 <asp:Label ID="lbl_attach5" runat="server" Text="-"></asp:Label>
                 </td><td>   <asp:FileUpload ID="FileUpload5" runat="server" CssClass="btn-default" />  </td></tr>
             <tr style="display:none;"><td class="auto-style1 " >   
                 <asp:Label ID="lbl_attach6" runat="server" Text="-" Visible="False"></asp:Label>
                 </td><td>   <asp:FileUpload ID="FileUpload6" runat="server" CssClass="btn-default" Visible="False" />  </td></tr>
             <tr style="display:none;"><td class="auto-style1">   
                 <asp:Label ID="lbl_attach7" runat="server" Text="-" Visible="False"></asp:Label>
                 </td><td>   <asp:FileUpload ID="FileUpload7" runat="server" CssClass="btn-default" Visible="False" />  </td></tr>
             <tr style="display:none;"><td class="auto-style1">   
                 <asp:Label ID="lbl_attach8" runat="server" Text="-" Visible="False"></asp:Label>
                 </td><td>   <asp:FileUpload ID="FileUpload8" runat="server" CssClass="btn-default" Visible="False" />  </td></tr>
             <tr style="display:none;"><td class="auto-style1">   
                 <asp:Label ID="lbl_attach9" runat="server" Text="-" Visible="False"></asp:Label>
                 </td><td>   <asp:FileUpload ID="FileUpload9" runat="server" CssClass="btn-default" Visible="False" />  </td></tr>
             <tr id="tbox1" style="display:none;" runat="server"><td class="auto-style1">   
                 <asp:Label ID="lbl_email_submit" runat="server"></asp:Label>
                 </td><td>   
                     <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
                 </td></tr>
             <tr id="tbox2" style="display:none;" runat="server"><td class="auto-style1">   
                     <asp:Label ID="lbl_citizen_submit" runat="server"></asp:Label>
                 </td><td>   
                     <asp:TextBox ID="txt_citizen_submit" runat="server" Width="300px"></asp:TextBox>
                 </td></tr>
             <tr id="tbox3" style="display:none;" runat="server"><td class="auto-style1">   
                 <asp:Label ID="lbl_email" runat="server"></asp:Label>

                 </td><td>   
                     <asp:TextBox ID="TextBox2" runat="server" Width="300px"></asp:TextBox>               
                 </td></tr>
              <tr id="tbox4" style="display:none;" runat="server"><td class="auto-style1">   
                 <asp:Label ID="lbl_citizen_rcv" runat="server"></asp:Label>
                 </td><td>   
                     <asp:TextBox ID="txt_citizen_rcv" runat="server" Width="300px"></asp:TextBox>
                 </td></tr>
             <tr><td colspan="2"> <asp:Button ID="btn_Upload" runat="server" Text="อัพโหลด"   CssClass=" btn-lg"/>
                 &nbsp;
                 <asp:Button ID="Button1" runat="server" Text="ปิด"  CssClass=" btn-lg" Width="150px"  />
                 &nbsp;</td></tr>
             <tr><td colspan="2">      หมายเหตุ : กรุณาจดเลขที่ได้หลังจากทำการอัพโหลดเรียบร้อยแล้ว</td></tr>
         </table>

    </div>
</asp:Content>
