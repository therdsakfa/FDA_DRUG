<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DS_UPLOAD2.aspx.vb" Inherits="FDA_DRUG.POPUP_DS_UPLOAD2" %>
<%@ Register Src="~/UC/UC_ATTACH_CUS.ascx" TagPrefix="uc1" TagName="UC_ATTACH_CUS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 20%;
        }
    </style>
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

         <table class="table"> <tr><td class="auto-style1">   แบบคำขอ ย.8</td><td>   <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" />  </td></tr>
             <tr><td colspan="2"> &nbsp;
         <tr>
            <td colspan="2">
                แนบเอกสารเพิ่มเติม </td>
        </tr>
             <tr><td class="auto-style1"><asp:Label ID="lbl_attach1" runat="server" Text="-"></asp:Label></td>
                 <td><asp:FileUpload ID="FileUpload2" runat="server" CssClass="btn-default" /></td></tr>        
            <tr><td class="auto-style1"><asp:Label ID="lbl_attach2" runat="server" Text="-"></asp:Label></td>
            <td><asp:FileUpload ID="FileUpload3" runat="server" CssClass="btn-default"  /></td></tr>           
            <%--<tr><td class="auto-style1"><asp:Label ID="lbl_attach3" runat="server" Text="-"></asp:Label><br /></td>          
            <td><asp:FileUpload ID="FileUpload4" runat="server" CssClass="btn-default"  /></td></tr> --%>

                 </td></tr>
             <tr><td colspan="2">&nbsp;</td></tr>
             <tr><td colspan="2"> <asp:Button ID="btn_Upload" runat="server" Text="อัพโหลด"   CssClass=" btn-lg" />
                 &nbsp;
                 <asp:Button ID="Button1" runat="server" Text="ปิด"  CssClass=" btn-lg" Width="150px"  />
                 </td></tr>
             <tr><td colspan="2">      หมายเหตุ : กรุณาแนบเอกสารเพิ่มเติมให้ครบทั้ง 2 ข้อ ในรูปแบบ PDF<br />
                 </td></tr>
         </table>

    </div>
                  <div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  /> 
              </div>  
   
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>รายละเอียด CER</div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>


<%--<%@ Register src="../UC/UC_ATTACH_DRUG.ascx" tagname="UC_ATTACH_DRUG" tagprefix="uc1" %>
<%@ Register Src="~/UC/UC_ATTACH_DRUG.ascx" TagPrefix="uc2" TagName="UC_ATTACH_DRUG" %>--%>




<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                      Popups('POPUP_DS_UPLOAD.aspx');
                      return false;
                  });

                  $('#ContentPlaceHolder1_btn_download').click(function () {
                      $('#spinner').fadeIn('slow');
                      Popups('POPUP_DS_DOWNLOAD.aspx');
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
    <style>
        .css-set-line{
            border-bottom: 0.5px solid gainsboro;
        }
        td{
            height: 50px;
        }
    </style>
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

         <table style="width:100%"> <tr  class="css-set-line"><td style="width:600px">   ใบคำขอ</td><td>   <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" />  </td></tr>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder> 
            
             <tr><td colspan="2">&nbsp;</td></tr>
             <tr><td colspan="2"> <asp:Button ID="btn_Upload" runat="server" Text="อัพโหลด"   CssClass=" btn-lg" />
                 &nbsp;
                 <asp:Button ID="Button1" runat="server" Text="ปิด"  CssClass=" btn-lg" Width="150px"  />
                 </td></tr>
             <tr><td colspan="2">      หมายเหตุ : กรุณาจดเลขที่ได้หลังจากทำการอัพโหลดเรียบร้อยแล้ว</td></tr>
         </table>
       
    </div>
</asp:Content>--%>

