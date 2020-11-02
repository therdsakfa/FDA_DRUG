<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_RGT_EDIT_CONFIRM_STAFF.aspx.vb" Inherits="FDA_DRUG.FRM_RGT_EDIT_CONFIRM_STAFF" %>
<%@ Register Src="~/UC/UC_GRID_ATTACH.ascx" TagPrefix="uc1" TagName="UC_GRID_ATTACH" %>

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

         <asp:HyperLink ID="hl_reader" runat="server" Target="_blank" CssClass="btn-control" >
                 <input type="button" value="เปิดจาก acrobat reader"   class="btn-lg"   style="  Width:70%;" />
                       </asp:HyperLink>
         <asp:HiddenField ID="HiddenField1" runat="server" />
    </div>
    <table style="width:100%;height:500px;">
        <tr>
            <td rowspan="2" style="width:70%;">

                <%--<uc1:UC_CONFIRM ID="UC_CONFIRM1" runat="server" />--%>
                <div >
                     <asp:Literal ID="lr_preview" runat="server" ></asp:Literal>
    </div>
            </td>
             <td style="padding-left:10%;height:50%;">

                 <table class="table" style="width:90%"> 
                      <tr><td>
                                                  วันที่ออกเลขรับคำขอ : &nbsp; <asp:Label ID="lbl_rcvdate" runat="server" Text="-"></asp:Label>
                         
                         </td></tr>
                     <tr><td>
                                                  วันที่อนุมัติ : &nbsp;<asp:Label ID="lbl_appdate" runat="server" Text="-"></asp:Label>
                         
                         </td></tr>
                     <tr><td>
                                                  วิธียื่นเอกสารประกอบคำขอ :
                                                  <asp:Label ID="lbl_rqt_type" runat="server" Text="-"></asp:Label>
                         
                         </td></tr>
                     <tr><td>
                                                  เลข identifier :<asp:Label ID="lbl_rqt_identify" runat="server" Text="-"></asp:Label>
                         
                         </td></tr>
                     <tr><td>
                                                  สถานะปัจจุบัน : <asp:Label ID="lbl_current_stat" runat="server" Text="-"></asp:Label>
                         
                         </td></tr>
                     <tr><td>
                         โปรดเลือกสถานะถัดไป
                                                  <asp:DropDownList ID="ddl_status" runat="server" Width="80%" >
                         </asp:DropDownList>
                         
                         </td></tr>
                     <tr><td>
                        วันที่มีผลอนุมัติ
                                                  <%--(กรอกตอนสถานะเสนอลงนาม)--%>
                                                  <asp:TextBox ID="txt_appdate" runat="server" Width="80%"></asp:TextBox><br />
                         (ตัวอย่าง 10/12/2563)
                         
                         </td></tr>
                     <tr><td><asp:Button ID="btn_confirm" runat="server" Text="ยืนยัน" CssClass="btn-lg" OnClientClick="return confirm('คุณต้องการยืนยันข้อมูลหรือไม่?');"   Width="80%" /></td></tr>
                     <tr><td>
                         <asp:Button ID="btn_send_edit" runat="server" CssClass="btn-lg"  Text="ระบบปรับปรุงข้อมูลทะเบียน" Width="80%" />
                         </td></tr>
                     <tr><td> <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg"   Width="80%"/></td></tr>
                     <tr><td>  <asp:Button ID="btn_load" runat="server" Text="Download PDF" CssClass="btn-lg"   Width="80%" /></td></tr>
                     <tr><td>  <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg"   Width="80%" Height="53px" /></td></tr>

                 </table>
                 


             </td>
        </tr>
        <tr>
             <td style="width:30%;height:50%;padding-left:10%">
                
                 <uc1:UC_GRID_ATTACH runat="server" id="UC_GRID_ATTACH" />
           
             </td>
        </tr>
        </table>

</asp:Content>