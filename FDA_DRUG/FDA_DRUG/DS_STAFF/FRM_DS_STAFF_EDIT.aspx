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
        .auto-style5 {
            width: 262px;
            height: 48px;
        }
        .auto-style11 {
            width: 425px;
            height: 28px;
        }
        .auto-style12 {
            width: 196px;
            height: 44px;
        }
        .auto-style13 {
            height: 44px;
        }
        .auto-style17 {
            width: 196px;
            height: 29px;
        }
        .auto-style18 {
            height: 29px;
        }
        .auto-style20 {
            width: 196px;
            height: 48px;
        }
        .auto-style22 {
            height: 51px;
        }
        .auto-style23 {
            width: 196px;
            height: 51px;
        }
        .auto-style24 {
            width: 196px;
            height: 32px;
        }
        .auto-style25 {
            height: 32px;
        }
        .auto-style26 {
            margin-left: 14px;
        }
        .auto-style27 {
            height: 58px;
        }
        .auto-style28 {
            height: 58px;
            width: 196px;
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
                    </tr>
                </table>        
        </div>
    <div>
        <h4>ไฟล์แนบ (รายละเอียดเพิ่มเติม)</h4>
    </div>
    <div>
        <table>
            
            <tr>
                <td class="auto-style17" align="right">รายละเอียดไฟล์แนบ 1 :</td>
                <td class="auto-style18"><asp:TextBox ID="TXT_DESCIPTION1" runat="server" Width="388px"></asp:TextBox></td>
            </tr>
            <tr>           
                <td class="auto-style20"></td>
                <td class="auto-style5"><asp:FileUpload ID="FileUpload1" runat="server" Width="243px" /><asp:Label ID="lbl_attach1" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style24" align="right">รายละเอียดไฟล์แนบ 2 :</td>
                <td class="auto-style25"><asp:TextBox ID="TXT_DESCIPTION2" runat="server" Width="388px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style23"></td>
                <td class="auto-style22"><asp:FileUpload ID="FileUpload2" runat="server" CssClass="auto-style11" Width="243px"  /><asp:Label ID="lbl_attach2" runat="server" Text=""></asp:Label></td>                
            </tr>
            <tr>
                <td class="auto-style12"></td>
                <td class="auto-style13"><asp:Button ID="btn_Upload" runat="server" Text="Upload File" /></td>
            </tr>
            <tr>
                <td align="right" class="auto-style28">กำหนดส่งเอกสาร :</td>
                <td class="auto-style27"><telerik:RadDatePicker ID="rdp_cncdate" Runat="server" CssClass="auto-style26"></telerik:RadDatePicker></td>
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

