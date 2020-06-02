<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_EDIT_DRUG_FOR_RESEARCH.aspx.vb" Inherits="FDA_DRUG.POPUP_EDIT_DRUG_FOR_RESEARCH" %>

<%@ Register Src="~/UC/UC_ATTACH_DRUG.ascx" TagPrefix="uc1" TagName="UC_ATTACH_DRUG" %>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 50%;
        }
        .auto-style2 {
            border-collapse: collapse;
            width: 79%;
            max-width: 100%;
            margin-bottom: 20px;
        }
        
        #pj_sum {
            /*font-family: "Trebuchet MS", Arial, Helvetica, sans-serif;*/
            border-collapse: collapse;
            width: 100%;
        }

        #pj_sum td, #pj_sum th {
            border: 1px solid #ddd;
            padding: 8px;
        }

        #pj_sum tr:nth-child(even){background-color: #f2f2f2;}

        #pj_sum th {
            padding-top: 12px;
            padding-bottom: 12px;
            text-align: left;
            background-color: #4CAF50;
            color: white;
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
              <asp:ScriptManager ID="ScriptManager1" runat="server">
              </asp:ScriptManager>
          </h3>
         <table class="auto-style2" id="pj_sum"> 
             <%--<tr><td class="auto-style1">   เลขบัญชีรายการยาที่ใช้ในโครงการ</td><td>   
                 <asp:TextBox ID="txt_drug" runat="server" Width="150px"></asp:TextBox>
&nbsp;
                 <asp:Button ID="Button7" runat="server" Text="เพิ่ม" />
                 <asp:Label ID="lbl_drug_id1" runat="server" Visible="False"></asp:Label>
                 <br />
                 <asp:Label ID="lbl_error" runat="server" ForeColor="#CC0000" Text="ไม่พบบัญชีรายการยา" Visible="False"></asp:Label>
                 <br />
                 <asp:Label ID="lbl_drug" runat="server"></asp:Label>
                 <br />
                 </td></tr>--%>
             <tr><td class="auto-style1">   ชื่อการค้า</td><td>   
                 <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                 </tr>
             <tr><td class="auto-style1">   ชื่อสามัญ</td><td>   
                 <asp:TextBox ID="TextBox2" runat="server" Width="200px"></asp:TextBox>
                 </tr>
             <tr><td class="auto-style1">   ชื่ออื่น</td><td>   
                 <asp:TextBox ID="TextBox7" runat="server" Width="200px"></asp:TextBox>
                 </tr>
             <tr><td class="auto-style1">   รหัสยา</td><td>   
                 <asp:TextBox ID="TextBox3" runat="server" Width="200px"></asp:TextBox>
                 </tr>
             <tr><td class="auto-style1">   รูปแบบยา</td><td>   
                 <asp:TextBox ID="TextBox4" runat="server" Width="200px"></asp:TextBox>
                 </tr>
             <tr><td class="auto-style1">   ตัวยาสำคัญ (Active Ingredients)</td><td>   
                 <asp:Label ID="lbl_activelist" runat="server"></asp:Label>
                 </tr>
             <tr><td class="auto-style1">   ความแรง</td><td>   
                 <asp:TextBox ID="TextBox5" runat="server" Width="200px"></asp:TextBox>
                 </tr>
             <tr><td class="auto-style1">   ขนาดยาที่ให้ และ Washout Period(ถ้ามี)</td><td>   
                 <asp:TextBox ID="TextBox6" runat="server" Width="200px"></asp:TextBox>
                 </tr>
             <tr><td class="auto-style1">   ประเภทผลิตภัณฑ์</td><td>   
                 <asp:RadioButton ID="rb_drtype1" runat="server" GroupName="dr_type" Text="ยาวิจัย" />
                 <br />
                 <asp:RadioButton ID="rb_drtype2" runat="server" GroupName="dr_type" Text="ยาเปรียบเทียบ" />
                 <br />
                 <asp:RadioButton ID="rb_drtype3" runat="server" GroupName="dr_type" Text="ยาที่ใช้ร่วม" />
                 <br />
                 <asp:RadioButton ID="rb_drtype4" runat="server" GroupName="dr_type" Text="ยาหลอก" />
                 <br />
                 <asp:RadioButton ID="rb_drtype5" runat="server" GroupName="dr_type" Text="ผลิตภัณฑ์อื่น" />
                 &nbsp;
                 <asp:TextBox ID="TextBox9" runat="server" Width="300px"></asp:TextBox>
                 </tr>
             <tr><td class="auto-style1">   ขนาดบรรจุ</td><td>   
                 จำนวน&nbsp; <asp:TextBox ID="txt_size1" runat="server" AutoPostBack="True"></asp:TextBox>
                &nbsp;
                 <asp:DropDownList ID="ddl_sunit" runat="server">
                 </asp:DropDownList>
                &nbsp; ใน&nbsp;
                <asp:DropDownList ID="ddl_munit" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm" AutoPostBack="True"></asp:DropDownList>
 
                <br />
 
                จำนวน&nbsp;
 
                <asp:TextBox ID="txt_size3" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Label ID="lbl_size_m" runat="server" AutoPostBack="True"></asp:Label>
                &nbsp; ใน&nbsp;
                <asp:DropDownList ID="ddl_bunit" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm" AutoPostBack="True"></asp:DropDownList>
                <br />
                <br />
                ชื่อขนาดบรรจุ :
                <asp:TextBox ID="txt_package_name" runat="server"></asp:TextBox>
&nbsp;
                 <br />
                 หมายเลขบาร์โค้ด :
                <asp:TextBox ID="txt_barcode" runat="server"></asp:TextBox>
                 <br />
                 จำนวนนำเข้า : <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                &nbsp;
                 <asp:Label ID="lbl_bunit" runat="server"></asp:Label>
                <br />
                <br />
                 </tr>
             <tr><td colspan="2"> &nbsp;
                 <asp:Button ID="Button1" runat="server" Text="" style="display:none;"  />
                 <asp:Button ID="btn_save" CssClass="btn-lg" runat="server" Text="บันทึกการแก้ไข" />
                 </td></tr>
         </table>

    </div>
</asp:Content>
