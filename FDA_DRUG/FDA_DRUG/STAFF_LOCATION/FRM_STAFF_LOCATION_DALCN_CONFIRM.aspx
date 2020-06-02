<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LOCATION_DALCN_CONFIRM.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_LOCATION_DALCN_CONFIRM" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker-th.js"></script>
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/jsdatemain_mol3.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_txt_app_date"));
        });

        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <script type="text/javascript" >
          $(document).ready(function () {
              $(window).load(function () {
                  $.ajax({
                      type: 'POST',
                      data: { submit: true },
                      success: function (result) {
                          //    $('#spinner').fadeOut('slow');
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
          function closespinner() {
              $('#spinner').fadeOut('slow');
              alert('Download Success');
              Loaddata();
          }
        </script> 
  <div id="spinner" style=" background-color:transparent;display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
                
</div>

    <div>
        
         <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    <table style="width:100%;height:500px;">
        <tr>
            <td rowspan="2" style="width:70%;">

                <%--<uc1:UC_CONFIRM ID="UC_CONFIRM1" runat="server" />--%>
                <div >
                    <table style="width:100%">

                    <tr>
                        <td style="width:30%  ; padding-left:15%; text-align:left">
                            
                    <h2><asp:Label ID="Label1" runat="server" Text="ประเภทสถานที่"></asp:Label></h2>
                        </td>
                        <td  style="width:70%  ; text-align:left">

                             <asp:RadioButtonList ID="rdl_place_type" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                                 <asp:ListItem Value="1" Selected="True">ที่ตั้ง</asp:ListItem>
                                 <asp:ListItem Value="2">สถานที่เก็บ</asp:ListItem>
                             </asp:RadioButtonList>

                        </td>
                    </tr>
                </table>
                     <table style="width:100%">
                         <tr>
                             <td colspan="2" style="width:30%  ; padding-left:15%; text-align:left">
                                 <h2>
                                     <asp:Label ID="Label21" runat="server" Text="ชื่อสถานที่"></asp:Label>
                                 </h2>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:right"></td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_thanameplace_lo" runat="server" Text="ชื่อสถานที่ (ภาษาไทย)"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_thanameplace_lo" runat="server" Width="70%"> </asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_engnameplace_lo" runat="server" Text="ชื่อสถานที่ (ภาษาอังกฤษ)"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_engnameplace_lo" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30% ; padding-left:15%; text-align:left">
                                 <h2>
                                     <asp:Label ID="Label24" runat="server" Text="ที่ตั้งสถานที่"></asp:Label>
                                 </h2>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:right"></td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_thacode_id_lo" runat="server" Text="รหัสประจำบ้าน"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_thacode_id_lo" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_thaaddr_lo" runat="server" Text="เลขที่"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_thaaddr_lo" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_thabuilding_lo" runat="server" Text="อาคาร/ตึก"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_thabuilding_lo" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_thafloor_lo" runat="server" Text="ชั้น"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_thafloor_lo" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_tharoom_lo" runat="server" Text="ห้อง"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_tharoom_lo" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_thamu_lo" runat="server" Text="หมู่"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_thamu_lo" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_thasoi_lo" runat="server" Text="ซอย"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_thasoi_lo" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_tharoad_lo" runat="server" Text="ถนน"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_tharoad_lo" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_thachngwtnm_lo" runat="server" Text="จังหวัด"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left ">
                                 <asp:DropDownList ID="ddl_chngwt" runat="server" AutoPostBack="True" CssClass="dropdown" Width="70%">
                                 </asp:DropDownList>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_thaamphrnm_lo" runat="server" Text="เขต/อำเภอ"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:DropDownList ID="ddl_amphr" runat="server" AutoPostBack="True" CssClass="dropdown" Width="70%">
                                 </asp:DropDownList>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_thathmblnm_lo" runat="server" Text="แขวง/ตำบล"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70% ;  text-align:left">
                                 <asp:DropDownList ID="ddl_thumbol" runat="server" AutoPostBack="True" CssClass="dropdown" Width="70%">
                                 </asp:DropDownList>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_zipcode_lo" runat="server" Text="รหัสไปรษณีย์"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_zipcode_lo" runat="server" MaxLength="5" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_tel_lo" runat="server" Text="โทรศัพท์"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_tel_lo" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_mobile_lo" runat="server" Text="โทรศัพท์มือถือ"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_mobile_lo" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_fax_lo" runat="server" Text="โทรสาร"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_fax_lo" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_latitude" runat="server" Text="latitude(ถ้าไม่มีใส่ 0)"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_latitude" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2" style="width:30%  ; text-align:right">
                                 <asp:Label ID="Lb_longitude" runat="server" Text="longitude(ถ้าไม่มีใส่ 0)"></asp:Label>
                             </td>
                             <td colspan="2" style="width:70%  ; text-align:left">
                                 <asp:TextBox ID="txt_longitude" runat="server" Width="70%"></asp:TextBox>
                             </td>
                         </tr>
                     </table>
    </div>
            </td>
             <td style="padding-left:10%;height:50%;vertical-align:top;">

                 <table class="table" style="width:90%"> 
                     
                     <tr><td>สถานะ</td></tr>
                     
                     <tr><td>
                         <asp:DropDownList ID="ddl_status" runat="server"  CssClass="form-control">
            <%--                  
                             <asp:ListItem Value="8">อนุมัติ</asp:ListItem>
                             <asp:ListItem Value="7">คืนคำขอ</asp:ListItem>--%>
                         </asp:DropDownList>
                     
                         </td></tr>
                     <tr>
                         <td>
                             
                             วันที่ : &nbsp;
                             <asp:TextBox ID="txt_app_date" runat="server"></asp:TextBox>
                         </td>
                     </tr>
                     <tr><td> <asp:Button ID="btn_confirm" runat="server" Text="บันทึก" CssClass="btn-lg"   Width="80%" /></td></tr>
                     <tr><td>  <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg"   Width="80%" /></td></tr>

                 </table>
                 


             </td>
        </tr>
        <tr>
             <td style="width:30%;height:50%;padding-left:10%;display:none;">
                
                 <uc1:uc_grid_attach runat="server" id="UC_GRID_ATTACH" />
           
             </td>
        </tr>
        </table>
</asp:Content>
