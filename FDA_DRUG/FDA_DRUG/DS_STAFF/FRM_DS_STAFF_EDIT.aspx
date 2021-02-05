<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_DS_STAFF_EDIT.aspx.vb" Inherits="FDA_DRUG.FRM_DS_STAFF_EDIT" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            font-size: 12px;
            line-height: 1.5;
            border-radius: 3px;
            padding: 5px 10px;
        }
        .auto-style2 {
            width: 520px;
        }
        .auto-style3 {
            width: 160px;
        }
    </style>
 <script type="text/javascript" >



     $(document).ready(function () {


         function CloseSpin() {
             $('#spinner').toggle('slow');
         }


         function Popups(url) { // สำหรับทำ Div Popup

             $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
             var i = $('#f1'); // ID ของ iframe   
             i.attr("src", url); //  url ของ form ที่จะเปิด
         }


         $('#ContentPlaceHolder1_btn_download_2').click(function () {
             $('#spinner').fadeIn('slow');

         });

         $('#ContentPlaceHolder1_btn_download').click(function () {
             $('#spinner').fadeIn('slow');

         });

     });
     function close_modal() { // คำสั่งสั่งปิด PopUp
         $('#myModal').modal('hide');
         $('#ContentPlaceHolder1_btn_reset').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
     }

     function Popups2(url) { // สำหรับทำ Div Popup

         $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
         var i = $('#f1'); // ID ของ iframe   
         i.attr("src", url); //  url ของ form ที่จะเปิด
     }


     function closespinner() {
         alert('Download เสร็จสิ้น');
         $('#spinner').fadeOut('slow');
         $('#ContentPlaceHolder1_Button1').click();
     }
        </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <center><h1>หมายเหตุการแก้ไข</h1></center>
            </div>
            <div class="panel-body">

            </div>
        
                <table class="table">
                    <tr >
                        <td align="right" class="auto-style3"><h4>หมายเหตุ :</h4></td>
                        <td class="auto-style2"><asp:TextBox ID="Txt_EDIT" TextMode="MultiLine" runat="server" CssClass="auto-style1" Width="454px" Height="245px"></asp:TextBox></td>
                        <td><h4>ไฟล์แนบ(รายละเอียดเพิ่มเติม)</h4>
                            <asp:FileUpload ID="FileUpload1" runat="server" CssClass="btn-default" /><br />
                            <asp:FileUpload ID="FileUpload2" runat="server" CssClass="btn-default" />
                            <br />
                            <h5>กำหนดส่งเอกสาร</h5>
                            <telerik:RadDatePicker ID="rdp_cncdate" Runat="server"></telerik:RadDatePicker>
                            <br />
                            <br />
                            <asp:Button ID="btn_Upload" runat="server" Text="อัพโหลด"   CssClass=" btn-lg" />
                        </td>
                    </tr>
                </table>
        
        </div>
        <div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" OnClientClick="return confirm('คุณต้องการบันทึกข้อมูลหรือไม่')"/>
                  
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>

