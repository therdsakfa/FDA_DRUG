<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_RQT_EDIT_V2.aspx.vb" Inherits="FDA_DRUG.FRM_RQT_EDIT_V2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/ui.datepicker-th.js"></script>

    <script type="text/javascript" >
        function showdate(targetobject) {
            $(targetobject).datepicker({
                showOn: "button",
                buttonImage: "../jsdate/calendar.gif",
                buttonImageOnly: true

            });

        }

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
            showdate($("#ContentPlaceHolder1_txt_appdate"));

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            //$('#ContentPlaceHolder1_btn_upload_t').click(function () {

            //    //  $('#spinner').toggle('slow');
            //    Popups('../DR/POPUP_DR_UPLOAD.aspx');
            //    return false;
            //});

            $('#ContentPlaceHolder1_btn_download_t').click(function () {
                $('#spinner').fadeIn('slow');

            });

            //$('#ContentPlaceHolder1_btn_upload_ex').click(function () {

            //    //  $('#spinner').toggle('slow');
            //    Popups('../DS/POPUP_DS_UPLOAD.aspx');
            //    return false;
            //});

            $('#ContentPlaceHolder1_btn_download_ex').click(function () {
                $('#spinner').fadeIn('slow');

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
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
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
            $('#ContentPlaceHolder1_Button1').click();

        }
        </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table">
    
       <tr>
        <td colspan="2" >
            <h2>ข้อมูลทั่วไปผลิตภัณฑ์ยา<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </h2>
        </td>
    </tr>


       <tr>
        <td width="40%">เลขทะเบียนตำรับยา</td>
        <td><asp:Label ID="lbl_rgtno" runat="server" ></asp:Label></td>
    </tr>
        
    <tr>
        <td >ชื่อการค้า (ภาษาไทย):</td>
        <td >
            <asp:Label ID="lbl_thadrgnm" runat="server" ></asp:Label></td>
    </tr>



    <tr>
        <td >ชื่อการค้า (ภาษาอังกฤษ):</td>
        <td >
            <asp:Label ID="lbl_engdrgnm" runat="server" ></asp:Label>
        </td>
    </tr>



    <tr>
        <td>ชื่อผู้รับอนุญาต : </td>
        <td >
            <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
        </td>
    </tr>



    <tr>
        <td>ชื่อสถานที่ :</td>
        <td >
            <asp:Label ID="lbl_thanameplace" runat="server" Text="-"></asp:Label>
        </td>
    </tr>



    <tr>
        <td>ที่ตั้ง :</td>
        <td >
            <asp:Label ID="lbl_addr" runat="server" Text="-"></asp:Label>
        </td>
    </tr>



    <tr>
        <td>ประเภทใบอนุญาต :</td>
        <td >
            <asp:Label ID="lbl_lcntpcd" runat="server" Text="-"></asp:Label>
        </td>
    </tr>



    <tr>
        <td>เลขที่ใบอนุญาต :</td>
        <td >
            <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
        </td>
    </tr>



<%--    <tr>
        <td>วันที่อนุญาตทะเบียน :</td>
        <td >
            <asp:Label ID="lbl_appdate" runat="server" Text="-"></asp:Label>
        </td>
    </tr>



    <tr>
        <td>สถานะทะเบียน :</td>
        <td >
            <asp:Label ID="lbl_rgt_stat" runat="server" Text="-"></asp:Label>
        </td>
    </tr>--%>
    </table>

    <br />
    <br />
    <table class="table">
        <tr>
            <td width="150px">
                หัวข้อการแก้ไข
            </td>
            <td>
                <asp:TextBox ID="txt_edit_description" runat="server" Width="100%" Height="300px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="150px">
                รายละเอียดการแก้ไข จาก</td>
            <td>
                <asp:TextBox ID="txt_old" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td width="150px">
                เป็น</td>
            <td>
                <asp:TextBox ID="txt_new" runat="server" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_save_edit_des" runat="server" Text="บันทึกหัวข้อการแก้ไข" />
                <asp:Button ID="btn_send_edit" runat="server" Text="ระบบปรับปรุงข้อมูลทะเบียน" style="display:none;" />
            </td>
        </tr>
    </table>
    <hr />
    <br /><br />

    <br /><br />

    <table style="display:none;">
        <tr>
            <td>
                วันที่อนุญาตทะเบียน :
            </td>
            <td>
                <asp:TextBox ID="txt_appdate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                เลขทะเบียน :
            </td>
            <td>
                <asp:Label ID="lbl_tabean_type" runat="server"></asp:Label>
                <asp:TextBox ID="txt_tabean_no" runat="server"></asp:TextBox>
                <asp:Label ID="lbl_tabean_other_type" runat="server"></asp:Label> <br /> (กรอกแต่เลขทะเบียน เช่น 1/61)

            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btn_save_app" runat="server" Text="บันทึกเลขทะเบียนและวันที่อนุญาต" CssClass="input-lg" />
                <asp:Button ID="btn_preview" runat="server" Text="พิมพ์ย.2" CssClass="input-lg" />


                <asp:Button ID="btn_pay" runat="server" Text="ออกใบสั่งชำระ" CssClass="input-lg"/>


            </td>
        </tr>
    </table>


    
    <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>
                       <asp:Label ID="lbl_titlename" runat="server" Text=""></asp:Label></h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
    <asp:Button ID="btn_preview2" runat="server" Text="พิมพ์ย.2 แบบ Word" CssClass="input-lg" style="display:none;" />
    </asp:Content>

