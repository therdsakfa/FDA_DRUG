<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_REMARK_ATTACH.ascx.vb" Inherits="FDA_DRUG.UC_REMARK_ATTACH" %>
    <script type="text/javascript" >



        $(document).ready(function () {

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            //$('#ContentPlaceHolder1_btn_upload').click(function () {
            //    Popups('POPUP_LCN_TYPE_UPLOAD.aspx');
            //    return false;
            //});

            $('#ContentPlaceHolder1_btn_download').click(function () {
                Popups('POPUP_LCN_DOWNLOAD.aspx');
                return false;
            });

            function Popups(url) { // สำหรับทำ Div Popup

                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
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
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        </script> 

<table class="table" style="width:100%;">
        <tr class="row" style="background-color:#8CB340">
            <td style="width:20%; right: 1037px; color:white;" class="text-info" >

                ลำดับที่ :
                <asp:Label ID="lbl_ID" runat="server" Text=""></asp:Label>

            </td>
            <td style="width:20%">

                &nbsp;</td>
            <td style="width:20%">

            </td>
            <td style="width:20%">

            </td>
            <td style="width:20%">

            </td>
        </tr>
         <tr class="row">
            <td colspan ="5">

                รายละเอียด/หมายเหตุ :
                <asp:Label ID="lbl_descript" runat="server"></asp:Label>

            </td>
            
        </tr>
         <tr class="row">
            <td>

                 &nbsp;</td>
            <td>

                 &nbsp;</td>
            <td>
                <br />
&nbsp;</td>
            <td>

                 &nbsp;</td>
            <td>

                 <asp:HyperLink ID="hl_pdf" runat="server" Target="_blank" CssClass="btn-control" >ดูข้อมูล</asp:HyperLink>

            </td>
        </tr>
    </table>