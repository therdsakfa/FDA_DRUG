<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Auto_Menu.Master" CodeBehind="FRM_CHANGE_NAME_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_CHANGE_NAME_MAIN" %>
<%@ Register Src="~/UC/UC_Information.ascx" TagPrefix="uc1" TagName="UC_Information" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
    
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
               var lct_ida = getQuerystring("lct_ida");
               var lcn_ida = getQuerystring("lcn_ida");
               var process = getQuerystring("process");
               //  $('#spinner').toggle('slow');
               Popups('POPUP_DI_UPLOAD.aspx?lct_ida=' + lct_ida + '&lcn_ida=' + lcn_ida + '&process=' + process);
               return false;
           });

           $('#ContentPlaceHolder1_btn_download').click(function () {
               $('#spinner').fadeIn('slow');

           });

           function Popups(url) { // สำหรับทำ Div Popup
               $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
               var i = $('#f1'); // ID ของ iframe   
               i.attr("src", url); //  url ของ form ที่จะเปิด
           }


       });
       function getQuerystring(key, default_) {
           if (default_ == null) default_ = "";
           key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
           var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
           var qs = regex.exec(window.location.href);
           if (qs == null)
               return default_;
           else
               return qs[1];
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
       function spin_space() { // คำสั่งสั่งปิด PopUp
           //    alert('123456');
           $('#spinner').toggle('slow');
           //$('#myModal').modal('hide');
           //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
       }
       
       function getQuerystring(key, default_) {
           if (default_ == null) default_ = "";
           key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
           var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
           var qs = regex.exec(window.location.href);
           if (qs == null)
               return default_;
           else
               return qs[1];
       }
        </script> 
     <script type="text/javascript" >
         function closespinner() {
             $('#spinner').fadeOut('slow');
             alert('Download Success');
             $('#ContentPlaceHolder1_Button1').click();

         }
         </script>
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h2> ระบบเปลี่ยนแปลงชื่อผู้รับอนุญาตตามกรมการปกครอง/กรมพัฒนาธุรกิจ</h2>

 <table>
       </table>

            <br />
        </div>


    </div>
    
    <div class="panel-info" style="text-align: right; width: 100%">
        <div style="text-align: right; padding-left: 5%; height: 60px;">
            &nbsp;&nbsp;
            <asp:Button ID="btn_add" runat="server" Text="เพิ่มคำขอ" Width="170px" CssClass="btn-lg " />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
            <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
        </div>
    </div>
  
   <hr />
   <div>
       <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15">
           <MasterTableView AutoGenerateColumns="False">
               <Columns>
                   <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                       SortExpression="IDA" UniqueName="IDA" Display="false">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter REQUEST_DATE column"
                       HeaderText="วันที่ยื่นคำขอ" SortExpression="REQUEST_DATE" UniqueName="REQUEST_DATE" DataFormatString="{0:dd/MM/yyyy}">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="COUNT_ALL_ITEM" FilterControlAltText="Filter COUNT_ALL_ITEM column"
                       HeaderText="จำนวนผลิตภัณฑ์" SortExpression="COUNT_ALL_ITEM" UniqueName="COUNT_ALL_ITEM">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                       HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                       HeaderText="รหัสการดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID">
                   </telerik:GridBoundColumn>
                   <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_cancel" ConfirmText="ต้องการยกเลิกคำขอหรือไม่"
                       CommandName="cancel" Text="ยกเลิกคำขอ">
                       <HeaderStyle Width="70px" />
                   </telerik:GridButtonColumn>
               </Columns>
           </MasterTableView>
       </telerik:RadGrid>
       <br />
       <table width="100%">
           <tr>
               <td align="right">
<asp:HyperLink ID="hl_pay" runat="server"  target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
               </td>
           </tr>
       </table>






              <br />

              <div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  /> 
              </div>  
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>รายละเอียดxt-center"><h1>รายละเอียด</div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
