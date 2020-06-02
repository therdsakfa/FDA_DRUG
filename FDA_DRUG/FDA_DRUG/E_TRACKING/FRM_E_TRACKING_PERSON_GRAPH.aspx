<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_E_Tracking.Master" CodeBehind="FRM_E_TRACKING_PERSON_GRAPH.aspx.vb" Inherits="FDA_DRUG.FRM_E_TRACKING_PERSON_GRAPH" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../js/jquery-1.8.3.js"></script>
    <link href="../assets/prettify/prettify.css" rel="stylesheet" />
    <script src="../Charts/FusionCharts.js"></script>
    <script src="../assets/prettify/prettify.js"></script>
    <script src="../assets/ui/js/json2.js"></script>
    <script src="../assets/ui/js/lib.js"></script>

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
              <telerik:RadGrid ID="RadGrid1" runat="server" Width="100%" AutoGenerateColumns="false">
                  <MasterTableView>
                      <Columns>
                          <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                           HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="CITIZEN_ID" FilterControlAltText="Filter CITIZEN_ID column"
                           HeaderText="บัตรประจำตัวประชาชน" SortExpression="CITIZEN_ID" UniqueName="CITIZEN_ID">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="fullname" FilterControlAltText="Filter fullname column"
                           HeaderText="ชื่อ-นามสกุลเจ้าหน้าที่" SortExpression="fullname" UniqueName="fullname">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="PROCESS_NAME" FilterControlAltText="Filter PROCESS_NAME column"
                           HeaderText="หน้าที่รับผิดชอบ" SortExpression="PROCESS_NAME" UniqueName="PROCESS_NAME">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="all_work" FilterControlAltText="Filter all_work column"
                           HeaderText="จำนวนคำขอทั้งหมด" SortExpression="all_work" UniqueName="all_work">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="zero_work" FilterControlAltText="Filter zero_work column"
                           HeaderText="คำขอใหม่" SortExpression="zero_work" UniqueName="zero_work">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="one_to_sixty_work" FilterControlAltText="Filter one_to_sixty_work column"
                           HeaderText="คำขอรออนุมัติ 1-60 วัน" SortExpression="one_to_sixty_work" UniqueName="one_to_sixty_work">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="sixty_to_120_work" FilterControlAltText="Filter sixty_to_120_work column"
                           HeaderText="คำขอรออนุมัติ 61-120 วัน" SortExpression="sixty_to_120_work" UniqueName="sixty_to_120_work">
                       </telerik:GridBoundColumn>
                          <telerik:GridBoundColumn DataField="over_120_work" FilterControlAltText="Filter over_120_work column"
                           HeaderText="คำขอมากกว่า 120 วัน" SortExpression="over_120_work" UniqueName="over_120_work">
                       </telerik:GridBoundColumn>
                      </Columns>
                  </MasterTableView>
              </telerik:RadGrid>
               </td>
           </tr>
       </table>
        </div>
   <div class=" modal fade" id="myModal">              
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
