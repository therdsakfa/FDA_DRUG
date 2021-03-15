<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_DS_EDIT_REQUEST.aspx.vb" Inherits="FDA_DRUG.FRM_DS_EDIT_REQUEST" %>

<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 485px;
            height: 264px;
        }
        .auto-style3 {
            width: 233px;
            height: 264px;
        }
        .auto-style5 {
            width: 209px;
        }
        .auto-style6 {
            width: 120px;
        }
        .auto-style7 {
            width: 367px;
        }
        .auto-style9 {
            text-shadow: 0 1px 0 #fff;
            -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, .15), 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: inset 0 1px 0 rgba(255, 255, 255, .15), 0 1px 1px rgba(0, 0, 0, .075);
            filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
            color: #fff;
            border: 2px solid #111;
            background: #111;
            margin-left: 121;
        }
        .auto-style10 {
            width: 432px;
        }
        .auto-style11 {
            text-shadow: 0 1px 0 #fff;
            -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, .15), 0 1px 1px rgba(0, 0, 0, .075);
            box-shadow: inset 0 1px 0 rgba(255, 255, 255, .15), 0 1px 1px rgba(0, 0, 0, .075);
            filter: progid:DXImageTransform.Microsoft.gradient(enabled=false);
            color: #fff;
            border: 2px solid #111;
            background: #111;
        }
        .auto-style12 {
            width: 432px;
            height: 35px;
        }
        .auto-style13 {
            height: 35px;
            width: 288px;
        }
        .auto-style14 {
            height: 32px;
            width: 288px;
        }
        .auto-style15 {
            height: 32px;
            width: 432px;
        }
        .auto-style16 {
            width: 115px;
            height: 35px;
        }
        .auto-style17 {
            height: 45px;
        }
        .auto-style18 {
            width: 839px;
        }
        .auto-style19 {
            width: 115px;
            height: 32px;
        }
        .auto-style20 {
            height: 45px;
            width: 288px;
        }
        .auto-style22 {
            width: 526px;
            height: 52px;
        }
        .auto-style23 {
            height: 52px;
        }
        .auto-style24 {
            margin-left: 16px;
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
        function Popups2(url) { // สำหรับทำ Div Popup

            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
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
            <center><h1>รายละเอียดการแก้ไข</h1></center>
        </div>
    
    <div>
        <table class="table">
            <tr>
                <td align="right" class="auto-style3"><h4>รายละเอียดการแก้ไข : </h4></td>
                <td class="auto-style2"><h4><asp:Label ID="lbl_EDIT"  runat="server" CssClass="auto-style1" Width="530px" Height="245px">-</asp:Label></h4></td>
                <td class="auto-style7" ><uc1:UC_GRID_ATTACH runat="server" id="UC_GRID_ATTACH" /></td>
                <td></td>               
            </tr>
        </table>
    </div>
    <div>
        <table class="auto-style18">
            <tr>
                <td class="auto-style10" ><h4>แนบเอกสารเพิ่มเติม</h4></td>
            </tr>
            <tr>
                <td class="auto-style12">ฉลากและเอกสารกำกับผลิตภัณฑ์ ทุกภาชนะบรรจุ ( ไฟล์ PDF เท่านั้น )</td>
                <td class="auto-style13"><asp:FileUpload ID="FileUpload1" runat="server" CssClass="auto-style9" Width="243px" /></td>
                <td class="auto-style16" style="color:red"><asp:Label ID="lbl_attach1" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style15">อื่นๆ</td>
                <td class="auto-style14"><asp:FileUpload ID="FileUpload2" runat="server" CssClass="auto-style11" Width="243px"  /></td>                
                <td class="auto-style19" style="color:red"><asp:Label ID="lbl_attach2" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td class="auto-style17"></td>
                <td class="auto-style20"><asp:Button ID="btn_Upload" runat="server" Text="Upload File" /></td>
            </tr>
        </table>
    </div>
    <br />
    <div>
        <table>
            <tr>
                <td class="auto-style5" align="right">* กำหนดส่งเอกสารในะบบวันที่</td>
                <td class="auto-style6"><center><asp:Label ID="lbl_DATE" runat="server"></asp:Label></center></td>
                <td>ก่อนเวลา 23.59 น. ของวันที่ระบุข้างต้น</td>
            </tr>
        </table>
    </div>
         
    
    <br />
    <div>
        <table style="width:100%">
            <tr>
                <td align="right" class="auto-style22" ><asp:Button ID="Button_DL" runat="server" Text="แก้ไขข้อมูลส่วนที่ 2" Height="35px" /></td>
                <td class="auto-style23"><asp:Button ID="Button_confirm" runat="server" Text="แก้ไขเสร็จแล้ว ส่งเรื่องคืนเจ้าหน้าที่" Height="35px" CssClass="auto-style24" OnClientClick="กรุณาตรวจสอบข้อมูลให้ถูกต้องก่อนส่งเรื่องให้เจ้าหน้าที่"/></td>
            </tr>
        </table>
        
    </div>

    </asp:Content>