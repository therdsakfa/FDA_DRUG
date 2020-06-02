<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_E_Tracking.Master" CodeBehind="FRM_CUSTOMER_REPORT.aspx.vb" Inherits="FDA_DRUG.FRM_CUSTOMER_REPORT" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../../js/jquery-1.8.3.js"></script>
    <link href="../../assets/prettify/prettify.css" rel="stylesheet" />
    <script src="../../Charts/FusionCharts.js"></script>
    <script src="../../assets/prettify/prettify.js"></script>
    <script src="../../assets/ui/js/json2.js"></script>
    <script src="../../assets/ui/js/lib.js"></script>

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

             $('#ContentPlaceHolder1_btn_add').click(function () {

                 //  $('#spinner').toggle('slow');
                 Popups('FRM_E_TRACKING_STAFF_ASIGN_INSERT.aspx');
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
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h2> รายงานติดตามคำขอ</h2>

        </div>
    </div>
    <table width="100%">
           <tr>
               <td align="center">
                    <table style="width: 100%;" class=" table">
            <tr>
                <td>เลือกคำขอ</td>
                <td>
                    <asp:RadioButtonList ID="rdl_small_type" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
                        <asp:ListItem Value="1" Selected="True">คำขอใหม่</asp:ListItem>
                        <asp:ListItem Value="2">คำขอแก้ไข</asp:ListItem>
                        <asp:ListItem Value="3">คำขอต่ออายุ</asp:ListItem>
                        <asp:ListItem Value="4">คำขอใบแทน</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:TextBox ID="txt_citizen" runat="server" Text="0105536030123" style="display:none;"></asp:TextBox>
                </td>
        </table>
   <hr />
   <div>
       <table width="100%">
           <tr>
               <td align="right">
                   <asp:Button ID="btn_export0" runat="server" Text="Export to Excel" CssClass="btn-lg" style="display:none;" />
                   
               </td>
           </tr>
           <tr>
               <td align="right">
                   *หมายเหตุ (1) วันที่ใช้ไปหมายถึง วันที่รับคำขอจนถึงวันที่คำนวณปัจจุบัน (คำนวณทุกวันศุกร์) , (2) วันหยุดเวลาหมายถึง วันที่อยู่ในระหว่างการผ่อนผันของผู้ประกอบการ (3) วันที่แสดงเป็นวันทำการ
                   <asp:Button ID="btn_export" runat="server" Text="EXPORT TO EXCEL" style="display:none;" />
                   
               </td>
           </tr>
           <tr>
               <td>
              <telerik:RadGrid ID="RadGrid1" runat="server" Width="100%" AutoGenerateColumns="false" AllowPaging="true" PageSize="15">
                  <MasterTableView>
                      <Columns>
                          <telerik:GridBoundColumn DataField="rcvno" FilterControlAltText="Filter rcvno column"
                           HeaderText="rcvno" SortExpression="rcvno" UniqueName="rcvno" Display="false">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="lcnsid" FilterControlAltText="Filter lcnsid column"
                           HeaderText="lcnsid" SortExpression="lcnsid" UniqueName="lcnsid" Display="false">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="ctzid" FilterControlAltText="Filter ctzid column"
                           HeaderText="ctzid" SortExpression="ctzid" UniqueName="ctzid" Display="false">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="rgttpcd" FilterControlAltText="Filter rgttpcd column"
                           HeaderText="rgttpcd" SortExpression="rgttpcd" UniqueName="rgttpcd" Display="false">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="drgtpcd" FilterControlAltText="Filter drgtpcd column"
                           HeaderText="drgtpcd" SortExpression="drgtpcd" UniqueName="drgtpcd" Display="false">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="rcvno_display" FilterControlAltText="Filter rcvno_display column"
                           HeaderText="เลขที่รับ" SortExpression="rcvno_display" UniqueName="rcvno_display" >
                              <ItemStyle Width="10%" />
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="rcvdate" FilterControlAltText="Filter rcvdate column"
                           HeaderText="วันที่รับคำขอ" SortExpression="rcvdate" UniqueName="rcvdate" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="appdate" FilterControlAltText="Filter appdate column"
                           HeaderText="วันที่อนุญาต" SortExpression="appdate" UniqueName="appdate" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}" Display="false">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column"
                           HeaderText="ชื่อยา" SortExpression="thadrgnm" UniqueName="thadrgnm">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column"
                           HeaderText="ชื่อยาภาษาอังกฤษ" SortExpression="engdrgnm" UniqueName="engdrgnm">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="all_days" FilterControlAltText="Filter all_days column"
                           HeaderText="จำนวนวันที่ใช้ไป" SortExpression="all_days" UniqueName="all_days">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="stop_days" FilterControlAltText="Filter stop_days column"
                           HeaderText="วันหยุดเวลา" SortExpression="stop_days" UniqueName="stop_days">
                       </telerik:GridBoundColumn>
                          
                          <telerik:GridBoundColumn DataField="stdno" FilterControlAltText="Filter stdno column"
                           HeaderText="ระยะเวลาประกาศ" SortExpression="stdno" UniqueName="stdno">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="rcvdate" FilterControlAltText="Filter rcvdate column"
                           HeaderText="วันที่ของสถานะล่าสุด" SortExpression="rcvdate" UniqueName="rcvdate" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}">
                       </telerik:GridBoundColumn>
                        <%--  <telerik:GridBoundColumn DataField="extend_days" FilterControlAltText="Filter extend_days column"
                           HeaderText="ระยะเวลาขยาย" SortExpression="extend_days" UniqueName="extend_days">
                       </telerik:GridBoundColumn>--%>
                          <%--<telerik:GridBoundColumn DataField="days_result" FilterControlAltText="Filter days_result column"
                           HeaderText="ระยะเวลาที่เหลือ" SortExpression="days_result" UniqueName="days_result">
                       </telerik:GridBoundColumn>--%>
                          
                          <telerik:GridBoundColumn DataField="stat" FilterControlAltText="Filter stat column"
                           HeaderText="สถานะ" SortExpression="stat" UniqueName="stat">
                       </telerik:GridBoundColumn>
                         <%-- <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="report" Text="เพิ่มการหยุดและขยายเวลา" UniqueName="report">

                          </telerik:GridButtonColumn>
                          <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="stat" Text="ปรับสถานะ" UniqueName="stat">

                          </telerik:GridButtonColumn>--%>
                      </Columns>
                  </MasterTableView>
              </telerik:RadGrid>
               </td>
           </tr>
           <tr>
               <%--<td align="right">
                   *หมายเหตุ ข้อมูล ณ วันที่ &nbsp; <asp:Label ID="lb_update_date" runat="server" Text="-"></asp:Label>
               </td>--%>
           </tr>
       </table>
        </div>
   <div class=" modal" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>เพิ่มเจ้าหน้าที่ </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>