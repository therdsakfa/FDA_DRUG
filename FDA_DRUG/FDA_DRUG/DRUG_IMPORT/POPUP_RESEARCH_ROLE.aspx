<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_RESEARCH_ROLE.aspx.vb" Inherits="FDA_DRUG.POPUP_RESEARCH_ROLE" %>

<%@ Register Src="~/UC/UC_ATTACH_DRUG.ascx" TagPrefix="uc1" TagName="UC_ATTACH_DRUG" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        #role{
            margin: auto;
        }
        .btn-lg{
            font-weight: normal;
            font-size : 16px;
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
              &nbsp;</h3>
         <table class="table" id="role">
             <tr>
                 <th>
                     ผู้สนับสนุนการวิจัยในประเทศไทย (Thai Sponsor)</th>
                 <th>
                     ชื่อหน่วยงาน : <asp:TextBox ID="th_spon_group" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     เลขนิติ : <asp:TextBox ID="thspons_taxno" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ที่อยู่ :
                     <asp:TextBox ID="th_spon_addr" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     จังหวัด :
                     <asp:DropDownList ID="DropDownList2" runat="server">
                     </asp:DropDownList>
                     <br />
                     โทร. :
                     <asp:TextBox ID="th_spon_tel" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     อีเมล์/เว็บไซต์ :
                     <asp:TextBox ID="th_spon_email" runat="server" Width="380px"></asp:TextBox>
                 </th>
             </tr>
             <tr>
                 <th>

                     ผู้สนับสนุนการวิจัยในต่างประเทศ (Foreign Sponsor)</th>
                 <th>

                     ชื่อหน่วยงาน :
                     <asp:TextBox ID="for_spons_groupnm" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ที่อยู่ :
                     <asp:TextBox ID="for_spons_addr" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ประเทศ :
                     <asp:DropDownList ID="DropDownList3" runat="server">
                     </asp:DropDownList>
                     <br />
                     โทร. :
                     <asp:TextBox ID="for_spons_tel" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     อีเมล์/เว็บไซต์ :
                     <asp:TextBox ID="for_spons_email" runat="server" Width="380px"></asp:TextBox>

                 </th>
             </tr>
             <tr>
                 <th>

                     บริษัทหรือหน่วยงานที่กำกับดูแล การวิจัย (Monitor)</th>
                 <th>

                     <asp:RadioButton ID="rb_monitor_type1" runat="server" GroupName="monitor_type" Text="เป็นผู้ยื่นคำขอฯ" />
&nbsp;
                     <asp:RadioButton ID="rb_monitor_type2" runat="server" GroupName="monitor_type" Text="ไม่ใช่ผู้ยื่นคำขอฯ" />
                     <br />
                     ชื่อหน่วยงาน : <asp:TextBox ID="monitor_group" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     เลขนิติ : <asp:TextBox ID="monitor_taxno" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ที่อยู่ :
                     <asp:TextBox ID="monitor_addr" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ประเทศ :
                     <asp:DropDownList ID="DropDownList6" runat="server" AutoPostBack="True">
                     </asp:DropDownList>
&nbsp; <div id="chngwt1" runat="server" style="display:none">จังหวัด :
                     <asp:DropDownList ID="DropDownList7" runat="server">
                     </asp:DropDownList></div>
                     <br />
                     โทร. :
                     <asp:TextBox ID="monitor_tel" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     อีเมล์/เว็บไซต์ :
                     <asp:TextBox ID="monitor_email" runat="server" Width="380px"></asp:TextBox>

                 </th>
             </tr>
             <tr>
                 <th>

                     บริษัทหรือหน่วยงานที่บริหาร จัดการโครงการวิจัย (Project Management)</th>
                 <th>

                     <asp:RadioButton ID="rb_pm_type1" runat="server" GroupName="pm_type" Text="เป็นผู้ยื่นคำขอฯ" />
&nbsp;
                     <asp:RadioButton ID="rb_pm_type2" runat="server" GroupName="pm_type" Text="ไม่ใช่ผู้ยื่นคำขอฯ" />
                     <br />
                     ชื่อหน่วยงาน :
                     <asp:TextBox ID="pm_group" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     เลขนิติ : <asp:TextBox ID="pm_taxno" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ที่อยู่ :
                     <asp:TextBox ID="pm_addr" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ประเทศ :
                     <asp:DropDownList ID="DropDownList4" runat="server" AutoPostBack="True">
                     </asp:DropDownList>
&nbsp; <div id="chngwt2" runat="server" style="display:none">จังหวัด :
                     <asp:DropDownList ID="DropDownList8" runat="server">
                     </asp:DropDownList></div>
                     <br />
                     โทร. :
                     <asp:TextBox ID="pm_tel" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     อีเมล์/เว็บไซต์ :
                     <asp:TextBox ID="pm_email" runat="server" Width="380px"></asp:TextBox>

                 </th>
             </tr>
             <tr>
                 <th>

                     บริษัทหรือหน่วยงานที่บริหาร จัดการข้อมูล (Data Management)</th>
                 <th>

                     <asp:RadioButton ID="rb_dm_type1" runat="server" GroupName="dm_type" Text="เป็นผู้ยื่นคำขอฯ" />
&nbsp;
                     <asp:RadioButton ID="rb_dm_type2" runat="server" GroupName="dm_type" Text="ไม่ใช่ผู้ยื่นคำขอฯ" />
                     <br />
                     ชื่อหน่วยงาน :
                     <asp:TextBox ID="dm_group" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     เลขนิติ : <asp:TextBox ID="dm_taxno" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ที่อยู่ :
                     <asp:TextBox ID="dm_addr" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     ประเทศ :
                     <asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True">
                     </asp:DropDownList>
&nbsp; <div id="chngwt3" runat="server" style="display:none">จังหวัด :
                     <asp:DropDownList ID="DropDownList9" runat="server">
                     </asp:DropDownList></div>
                     <br />
                     โทร. :
                     <asp:TextBox ID="dm_tel" runat="server" Width="400px"></asp:TextBox>
                     <br />
                     อีเมล์/เว็บไซต์ :
                     <asp:TextBox ID="dm_email" runat="server" Width="380px"></asp:TextBox>

                 </th>
             </tr>
         </table>
         <br />
         <center><asp:Button CssClass="btn-lg" ID="Button1" runat="server" Text="บันทึก" /></center>
    </div>
</asp:Content>
