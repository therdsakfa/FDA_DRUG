<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_EXTEND_TIME_LOCATION_UPLOAD.aspx.vb" Inherits="FDA_DRUG.POPUP_EXTEND_TIME_LOCATION_UPLOAD" %>

<%@ Register Src="~/UC/UC_ATTACH_CUS.ascx" TagPrefix="uc1" TagName="UC_ATTACH_CUS" %>

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
                      Popups('POPUP_DP_UPLOAD.aspx');
                      return false;
                  });

                  $('#ContentPlaceHolder1_btn_download').click(function () {
                      $('#spinner').fadeIn('slow');
                      Popups('POPUP_DP_DOWNLOAD.aspx');
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
        .auto-style1 {
            width: 35%;
            height: 50px;
        }
        .auto-style2 {
            height: 50px;
            width: 8px;
        }
        .auto-style3 {
            width: 100%;
        }
        .auto-style4 {
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
         <table class="auto-style3"> <tr  class="css-set-line"><td class="auto-style1">   ใบคำขอ</td><td class="auto-style2">   <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" />  </td></tr>
            <%--<asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder> --%>
             <tr><td colspan="2" > </td>
                 </tr><td colspan="2" style="width:100%;" >
                 <!-- ขย15 --> 
                     <asp:Panel ID="Panel100741" runat="server" style="display:none;">
                         <table>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100741_1" runat="server" />
                                 </td>
                                 <td><font color="red">*แนบเอกสาร 1-5 เพื่อดำเนินขั้นตอนต่อไป</font></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100741_2" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100741_3" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100741_4" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100741_5" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100741_6" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                         </table>


                         <%--  
                     <uc1:UC_ATTACH_DRUG ID="uc100741_7" runat="server" />--%>
                     </asp:Panel>

                 <!-- ผย9 -->
                                        <asp:Panel ID="Panel100742" runat="server" style="display:none;">
                         <table>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100742_1" runat="server" />
                                 </td>
                                 <td><font color="red">*แนบเอกสาร 1-4 เพื่อดำเนินขั้นตอนต่อไป</font></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100742_2" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100742_3" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100742_4" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100742_5" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                           
                         </table>
                     </asp:Panel>

                 <!-- นย9 -->
                                                             <asp:Panel ID="Panel100743" runat="server" style="display:none;">
                         <table>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100743_1" runat="server" />
                                 </td>
                                 <td><font color="red">*แนบเอกสาร 1-4 เพื่อดำเนินขั้นตอนต่อไป</font></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100743_2" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100743_3" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100743_4" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100743_5" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                           
                         </table>
                     </asp:Panel>

                 <!-- ยบ13 -->
                                                                                  <asp:Panel ID="Panel100744" runat="server" style="display:none;">
                         <table>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100744_1" runat="server" />
                                 </td>
                                 <td><font color="red">*แนบเอกสาร 1-4 เพื่อดำเนินขั้นตอนต่อไป</font></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100744_2" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100744_3" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100744_4" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100744_5" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                           
                         </table>
                     </asp:Panel>
                      <!-- สมพ -->
                                                                                  <asp:Panel ID="Panel100751" runat="server" style="display:none;">
                         <table>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100751_1" runat="server" />
                                 </td>
                                 <td><font color="red">*แนบเอกสาร 1-4 เพื่อดำเนินขั้นตอนต่อไป</font></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100751_2" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100751_3" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100751_4" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100751_5" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                           
                         </table>
                     </asp:Panel>
                 <!-- ขจ3 -->
                                                                                                       <asp:Panel ID="Panel100745" runat="server" style="display:none;">
                         <table>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100745_1" runat="server" />
                                 </td>
                                 <td><font color="red">*แนบเอกสาร 1-4 เพื่อดำเนินขั้นตอนต่อไป</font></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100745_2" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100745_3" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100745_4" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100745_5" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                           
                         </table>
                     </asp:Panel>

                 <!-- นจ3 -->
                                                                                                                            <asp:Panel ID="Panel100746" runat="server" style="display:none;">
                         <table>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100746_1" runat="server" />
                                 </td>
                                 <td><font color="red">*แนบเอกสาร 1-4 เพื่อดำเนินขั้นตอนต่อไป</font></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100746_2" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100746_3" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100746_4" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100746_5" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                           
                         </table>
                     </asp:Panel>

                 <!-- ผจ3 -->
   <asp:Panel ID="Panel100747" runat="server" style="display:none;">
                         <table>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100747_1" runat="server" />
                                 </td>
                                 <td><font color="red">*แนบเอกสาร 1-4 เพื่อดำเนินขั้นตอนต่อไป</font></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100747_2" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100747_3" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100747_4" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100747_5" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                           
                         </table>
                     </asp:Panel>

                 <!-- สจ4 -->
                        <asp:Panel ID="Panel100748" runat="server" style="display:none;">
                         <table>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100748_1" runat="server" />
                                 </td>
                                 <td><font color="red">*แนบเอกสาร 1-4 เพื่อดำเนินขั้นตอนต่อไป</font></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100748_2" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100748_3" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100748_4" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100748_5" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                           
                         </table>
                            </asp:Panel>

                 <!-- ยส19 -->
                                           <asp:Panel ID="Panel100749" runat="server" style="display:none;">
                         <table>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100749_1" runat="server" />
                                 </td>
                                 <td><font color="red">*แนบเอกสาร 1-4 เพื่อดำเนินขั้นตอนต่อไป</font></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100749_2" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100749_3" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100749_4" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100749_5" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                           
                         </table>
                            </asp:Panel>

                                      <!-- ขนจ1 -->
                                                                <asp:Panel ID="Panel100750" runat="server" style="display:none;">
                         <table>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100750_1" runat="server" />
                                 </td>
                                 <td><font color="red">*แนบเอกสาร 1-4 เพื่อดำเนินขั้นตอนต่อไป</font></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100750_2" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100750_3" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100750_4" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                             <tr>
                                 <td>
                                     <uc1:UC_ATTACH_DRUG ID="uc100750_5" runat="server" />
                                 </td>
                                 <td></td>
                             </tr>
                           
                         </table>
                            </asp:Panel>                
                 </td>
             <tr><td colspan="2" class="auto-style4">1.1&nbsp; ชื่อแพท์ผู้รับรอง :
                 <asp:TextBox ID="Medic_4bsnname" runat="server"></asp:TextBox>
                 นามสุล :
                 <asp:TextBox ID="Medic_4bsnlastname" runat="server"></asp:TextBox>
                 เลขที่ใบประกอบวิชาชีพ(เลข ว.) :
                 <asp:TextBox ID="Medic_4bsnnumber" runat="server"></asp:TextBox>
                 <br />
                 2.1&nbsp; ชื่อแพท์ผู้รับรอง :
                 <asp:TextBox ID="Medic_4exname" runat="server"></asp:TextBox>
                 นามสุล :
                 <asp:TextBox ID="Medic_4exlastname" runat="server"></asp:TextBox>
                 เลขที่ใบประกอบวิชาชีพ(เลข ว.) :
                 <asp:TextBox ID="Medic_4exnumber" runat="server"></asp:TextBox>
                 <br />
                 พิกัดร้านในแผนที่ พิกัด x :
                 <asp:TextBox ID="map_x" runat="server" Width="45px"></asp:TextBox>
&nbsp;พิกัด y :
                 <asp:TextBox ID="map_y" runat="server" Width="45px"></asp:TextBox>
                 </td></tr>
             <tr><td colspan="2"> <asp:Button ID="btn_Upload" runat="server" Text="อัพโหลด"   CssClass=" btn-lg" />
                 &nbsp;
                 <asp:Button ID="Button1" runat="server" Text="ปิด"  CssClass=" btn-lg" Width="150px"  />
                 </td></tr>
             <tr><td colspan="2">หมายเหตุ1 : กรุณาจดเลขที่ได้หลังจากทำการอัพโหลดเรียบร้อยแล้ว
                 <br />
                 มายเหตุ 2 : กรณีผู้มีหน้าที่ปฏิบัติการมากกว่า 1 ให้รวมเอกสารเป็น pdf1 ไฟล์ </td></tr>
         </table>
       
    </div>
</asp:Content>
