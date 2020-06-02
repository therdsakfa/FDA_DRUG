<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_E_Tracking.Master" CodeBehind="FRM_E_TRACKING_PERSON_GRAPH_NEW.aspx.vb" Inherits="FDA_DRUG.FRM_E_TRACKING_PERSON_GRAPH_NEW" %>
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
            <h2> รายงานคำขอ ตามเจ้าหน้าที่</h2>

        </div>

    </div>
    
   <hr />
   <div>
       <table width="100%">
           <tr>
               <td align="center">
                   <table>
                       <tr>
                           <td>
                               &nbsp;</td>
                       </tr>
                   </table>
                   
               </td>
           </tr>
           <tr>
               <td>
                   <div id="chartdiv" align="center">Chart will load here</div>
           <asp:HiddenField ID="HiddenField1" runat="server" Value="1234" />
                    <script type="text/javascript">
                        var targetobject = $("#<%=HiddenField1.ClientID%>").val();
                        var myChart = new FusionCharts({
                            type: 'MSColumn3D',
                            renderAt: 'chart-container',
                            dataFormat: 'json',
                            dataSource: targetobject,
                            width: '100%',
                            height: '100%',
                        });

                        myChart.render("chartdiv");
		</script>
               </td>
           </tr>
           <tr>
               <td>
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
                          <telerik:GridBoundColumn DataField="rqt_type" FilterControlAltText="Filter rqt_type column"
                           HeaderText="การรับคำขอ" SortExpression="rqt_type" UniqueName="rqt_type">
                       </telerik:GridBoundColumn>
                      </Columns>
                  </MasterTableView>
              </telerik:RadGrid>
               </td>
           </tr>
           <tr>
               <td align="right">
                   *หมายเหตุ ข้อมูล ณ วันที่ &nbsp; <asp:Label ID="lb_update_date" runat="server" Text="-"></asp:Label>
               </td>
           </tr>
       </table>
        </div>
    <div class="panel-footer">
        <center>
                   <asp:Button ID="btn_export" runat="server" Text="EXPORT" CssClass="btn-lg"/>
<asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" CssClass="btn-lg"/>
        </center>
        
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
