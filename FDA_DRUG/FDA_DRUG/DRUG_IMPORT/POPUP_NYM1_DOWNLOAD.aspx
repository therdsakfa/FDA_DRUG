<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_NYM1_DOWNLOAD.aspx.vb" Inherits="FDA_DRUG.POPUP_NYM1_DOWNLOAD" %>

<%@ Register Src="~/UC/UC_ATTACH_DRUG.ascx" TagPrefix="uc1" TagName="UC_ATTACH_DRUG" %>


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
         <script type="text/javascript" >
              function closespinner() {
                  $('#spinner').fadeOut('slow');
                  alert('Download Success');
                  $('#ContentPlaceHolder1_Button1').click();

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
            กรุณาเลือกไฟล์ที่ต้องการดาวน์โหลด</h3>

         <table class="table"> 
             <tr><td class="auto-style1">   ชื่อโครงการ</td><td>   
                 <asp:DropDownList ID="DropDownList1" runat="server">
                 </asp:DropDownList>
                 </td></tr>
             <%--<tr><td class="auto-style1">เพิ่มขนาดบรรจุ</td><td>   
                 <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True">
                 </asp:DropDownList>
                 </td></tr>--%>
<%--             <tr><td class="auto-style1"></td><td>   
                 จำนวน&nbsp; <asp:TextBox ID="txt_size1" runat="server" AutoPostBack="True"></asp:TextBox>
                &nbsp;
                <asp:Label ID="lbl_size_5" runat="server" AutoPostBack="true"></asp:Label>
                &nbsp; ใน&nbsp;
                <asp:DropDownList ID="ddl_size6" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm" AutoPostBack="True"></asp:DropDownList>
 
                <br />
 
                จำนวน&nbsp;
 
                <asp:TextBox ID="txt_size3" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Label ID="lbl_size_m" runat="server" AutoPostBack="True"></asp:Label>
                &nbsp; ใน&nbsp;
                <asp:DropDownList ID="ddl_size4" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm"></asp:DropDownList>
                <br />
            <asp:label ID="lbl_unite_ida" runat="server" DataTextField="lbl_unite_ida" DataValueField="lbl_unite_ida" AutoPostBack="True" Visible="False"></asp:label>
                 <asp:Label ID="lbl_pidfkida" runat="server" Visible="False"></asp:Label>
                <br />
                ชื่อขนาดบรรจุ :
                <asp:TextBox ID="txt_package_name" runat="server"></asp:TextBox>
&nbsp;
                 <br />
                 หมายเลขบาร์โค้ด :
                <asp:TextBox ID="txt_barcode" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:button ID="btn_add" runat="server" Text="บันทึกขนาดบรรจุ"></asp:button>
                 </td></tr>--%>
             <tr><td class="auto-style1">   ใบคำขอ</td><td>   
                 <asp:Button ID="Button2" runat="server" Text="ดาวน์โหลดใบคำขอ" CssClass="btn-lg"/>
                 </td></tr>
             <tr><td colspan="2"> &nbsp;
                 <asp:Button ID="Button1" runat="server" Text="" style="display:none;"  />
                 </td></tr>
         </table>

    </div>
</asp:Content>
