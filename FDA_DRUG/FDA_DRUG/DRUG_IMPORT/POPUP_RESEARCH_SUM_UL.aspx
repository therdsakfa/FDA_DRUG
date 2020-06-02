<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_RESEARCH_SUM_UL.aspx.vb" Inherits="FDA_DRUG.POPUP_RESEARCH_SUM_UL" %>

<%@ Register Src="~/UC/UC_ATTACH_DRUG.ascx" TagPrefix="uc1" TagName="UC_ATTACH_DRUG" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 25%;
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

         <table class="table" id="file_upload" runat="server"> <tr><td class="auto-style1">   ไฟล์รายละเอียดโครงการวิจัย</td><td>   <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" />  </td></tr>
             
<%--             <tr><td colspan="2">      หมายเหตุ : กรุณาจดเลขที่ได้หลังจากทำการอัพโหลดเรียบร้อยแล้ว</td></tr>--%>
         </table>
         <div class="row">
            <div class="col-lg-12">
                <asp:Label ID="Label1" runat="server" Text="<h4>ไฟล์แนบ</h4>"></asp:Label>
            </div>
        </div>
         <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
          <br />
          <br />
         <asp:Button ID="btn_Upload" runat="server" Text="อัพโหลด"   CssClass=" btn-lg" />
                 &nbsp;
                 <asp:Button ID="Button1" runat="server" Text="ปิด"  CssClass=" btn-lg" Width="150px"  />
          <br />
    </div>
</asp:Content>
