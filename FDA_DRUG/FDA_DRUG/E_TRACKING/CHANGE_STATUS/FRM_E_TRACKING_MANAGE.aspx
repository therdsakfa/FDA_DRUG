<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_E_Tracking.Master" CodeBehind="FRM_E_TRACKING_MANAGE.aspx.vb" Inherits="FDA_DRUG.FRM_E_TRACKING_MANAGE" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/css_radgrid.css" rel="stylesheet" />
    <link href="../../css/css_radgrid.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
             $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
         }

         function Popups2(url) { // สำหรับทำ Div Popup
             //alert(url);
             $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
             var i = $('#f1'); // ID ของ iframe   
             i.attr("src", url); //  url ของ form ที่จะเปิด
         }
         function Popups3(url) { // สำหรับทำ Div Popup
             //alert(url);
             $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
             var i = $('#f3'); // ID ของ iframe   
             i.attr("src", url); //  url ของ form ที่จะเปิด
         }

         function closespinner() {
             alert('Download เสร็จสิ้น');
             $('#spinner').fadeOut('slow');
             $('#ContentPlaceHolder1_Button1').click();
         }
        </script>
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h2> คำขอด้านยาที่เป็นงานค้าง</h2>

   <hr />

        </div>

    </div>
    
   <div>
       <table width="100%">
           <tr>
               <td align="right">
                   &nbsp;</td>
           </tr>
           <tr>
               <td>
              <telerik:RadGrid ID="RadGrid1" runat="server" Width="100%" AutoGenerateColumns="false" AllowPaging="true" PageSize="15">
                  <MasterTableView>
                      <Columns>
                          <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                           HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="rcvno" FilterControlAltText="Filter rcvno column"
                           HeaderText="rcvno" ReadOnly="True" SortExpression="rcvno" UniqueName="rcvno" Display="false">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="ctzid"  FilterControlAltText="Filter ctzid column"
                           HeaderText="ctzid" ReadOnly="True" SortExpression="ctzid" UniqueName="ctzid" Display="false">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="rgttpcd"  FilterControlAltText="Filter rgttpcd column"
                           HeaderText="rgttpcd" ReadOnly="True" SortExpression="rgttpcd" UniqueName="rgttpcd" Display="false">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="rcvno_display" FilterControlAltText="Filter rcvno_display column"
                           HeaderText="เลขที่รับ" SortExpression="rcvno_display" UniqueName="rcvno_display">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="rcvdate" FilterControlAltText="Filter rcvdate column"
                           HeaderText="วันที่รับคำขอ" SortExpression="rcvdate" UniqueName="rcvdate" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="wrkuntnm" FilterControlAltText="Filter wrkuntnm column"
                           HeaderText="กลุ่มงาน" SortExpression="wrkuntnm" UniqueName="wrkuntnm">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="stfthanm" FilterControlAltText="Filter stfthanm column"
                           HeaderText="ชื่อ-นามสกุลเจ้าหน้าที" SortExpression="stfthanm" UniqueName="stfthanm">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="WORK_NAME2" FilterControlAltText="Filter WORK_NAME2 column"
                           HeaderText="ประเภท" SortExpression="WORK_NAME2" UniqueName="WORK_NAME2">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="drgnm" FilterControlAltText="Filter drgnm column"
                           HeaderText="ชื่อยา" SortExpression="drgnm" UniqueName="drgnm">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="thanm" FilterControlAltText="Filter thanm column"
                           HeaderText="ผู้รับอนุญาต" SortExpression="thanm" UniqueName="thanm">
                       </telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="stat" Text="ปรับสถานะ" UniqueName="stat">

                        </telerik:GridButtonColumn>
                          <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="report" Text="เพิ่มการหยุดเวลา" UniqueName="report">

                          </telerik:GridButtonColumn>
                      </Columns>
                  </MasterTableView>
              </telerik:RadGrid>
               </td>
           </tr>
           
       </table>
        </div>
   <div class=" modal" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>ปรับสถานะ </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
    <div class=" modal" id="myModal3">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>เพิ่มการหยุดเวลา </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f3"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>