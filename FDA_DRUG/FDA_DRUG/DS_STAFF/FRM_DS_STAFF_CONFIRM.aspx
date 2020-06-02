<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_DS_STAFF_CONFIRM.aspx.vb" Inherits="FDA_DRUG.FRM_DS_STAFF_CONFIRM" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
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
           function Popups2(url) { // สำหรับทำ Div Popup
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
         <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="HiddenField3" runat="server" />
    </div>
    <table style="width:100%;height:500px;">
        <tr>
            <td rowspan="2" style="width:70%;">

                <%--<uc1:uc_confirm ID="UC_CONFIRM1" runat="server" />--%>
                <div >
                     <asp:Literal ID="lr_preview" runat="server" ></asp:Literal>
    </div>
            </td>
             <td style="padding-left:10%;height:50%;">

                 <table class="table" style="width:90%">
                     <%--<tr>
                         <td>&nbsp;

                             สถานะ :
                             <asp:Label ID="lbl_Status" runat="server" Text="-"></asp:Label>

                         </td>
                     </tr> 
                     <tr>
                         <td>&nbsp;

                             ชื่อผู้ลงนาม :
                             <asp:Label ID="lbl_staff_consider" runat="server" Text="-"></asp:Label>

                         </td>
                     </tr>
                     <tr>
                         <td>&nbsp;

                         วันที่เสนอลงนาม :
                             <asp:Label ID="lbl_consider_date" runat="server" Text="-"></asp:Label>

                         </td>
                     </tr>
                     <tr>
                         <td>&nbsp;

                         วันที่คาดว่าจะอนุมัติ :
                             <asp:Label ID="lbl_app_date" runat="server" Text="-"></asp:Label>

                         </td>--%>
                     </tr>
                    <%-- <tr>
                         <td>
                             <asp:DropDownList ID="ddl_template" runat="server" Width="80%" style="display:none;">
                                 <asp:ListItem Value="1">แบบปกติ</asp:ListItem>
                                 <asp:ListItem Value="2">แบบที่ 1</asp:ListItem>
                             </asp:DropDownList>

                         </td>
                     </tr>--%>
                     <tr><td>
                         <asp:DropDownList ID="ddl_cnsdcd" runat="server" AutoPostBack="True" Width="80%" DataTextField="STATUS_NAME" DataValueField="STATUS_ID">
                         </asp:DropDownList>
                         </td></tr>
                 <%--     <tr>
                         <td>
                             
                             วันที่ : &nbsp;
                             <asp:TextBox ID="txt_app_date" runat="server"></asp:TextBox>
                         </td>
                     </tr>--%>
                        <tr id="remark_box" runat="server" style="display:none;"><td> 
                         <asp:CheckBox ID="CheckBox1" runat="server" Text="เงื่อนไข/หมายเหตุ" AutoPostBack="True" />

                         <br />
                         <asp:TextBox ID="txt_REMARK" runat="server" CssClass="auto-style1" Height="100px" TextMode="MultiLine" Width="270px" Visible="False"></asp:TextBox>

                         </td></tr>
                     <tr><td><asp:Button ID="btn_confirm" runat="server" Text="ยืนยัน" CssClass="btn-lg"   Width="80%" OnClientClick="return confirm('คุณต้องการบันทึกข้อมูลหรือไม่');" /></td></tr>
                     <tr><td> <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg"   Width="80%"/></td></tr>
                     <tr><td>  <asp:Button ID="btn_load" runat="server" Text="Download PDF" CssClass="btn-lg"   Width="80%" /></td></tr>
                     <tr style="display:none;"><td>  <asp:Button ID="btn_preview" runat="server" Text="Preview ใบอนุญาต" CssClass="btn-lg"   Width="80%" /></td></tr>
                     <tr><td>  <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg"   Width="80%" /></td></tr>

                     <tr><td>  <asp:Button ID="btn_drug_group" runat="server" Text="หมวดยา" CssClass="btn-lg" style="display:none;"   Width="80%" /></td></tr>

                 </table>
                 


             </td>
        </tr>
        <tr>
             <td style="width:30%;height:50%;padding-left:10%">

                 <uc1:UC_GRID_ATTACH runat="server" ID="UC_GRID_ATTACH" />
           
                 <br />
                 <%--<uc2:UC_GRID_PHARMACIST ID="UC_GRID_PHARMACIST" runat="server" />--%>
           
             </td>
        </tr>
      
    <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
