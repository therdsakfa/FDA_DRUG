<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_DS_EDIT_REQUEST.aspx.vb" Inherits="FDA_DRUG.FRM_DS_EDIT_REQUEST" %>

<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 552px;
            height: 264px;
        }
        .auto-style3 {
            width: 201px;
            height: 264px;
        }
        .auto-style4 {
            width: 30%;
            height: 264px;
        }
        .auto-style5 {
            width: 209px;
        }
        .auto-style6 {
            width: 120px;
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
                <td class="auto-style2"><h4><asp:Label ID="lbl_EDIT" runat="server"></asp:Label></h4></td>
                <td style="padding-left:10%" class="auto-style4">
                    <uc1:UC_GRID_ATTACH runat="server" id="UC_GRID_ATTACH" />

                </td>
                
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
    <br />
    <div>
        <center><asp:Button ID="Button_DL" runat="server" Text="แก้ไขข้อมูลส่วนที่ 2"  CssClass="btn-lg" Height="45px"/></center>
    </div>

    </asp:Content>