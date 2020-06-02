<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_EDIT_LOCATION_SEARCH.aspx.vb" Inherits="FDA_DRUG.FRM_EDIT_LOCATION_SEARCH" %>
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
            <h2> ค้นหา</h2>

        </div>

    </div>
    
   <hr />
   <div>
       <table width="100%">
           <tr>
               <td align="center">
                   <table>
                       <tr>
<%--                           <td>
                               ประเภทการค้นหา</td>
                           <td>
                               <asp:DropDownList ID="ddl_type" runat="server">
                                   <asp:ListItem Value="1">สถานที่จำลอง</asp:ListItem>
                                   <asp:ListItem Value="2">สถานที่เก็บ</asp:ListItem>
                               </asp:DropDownList>
                           </td>--%>
                           <td>
                               เลขนิติบุคคล</td>
                           <td>
                               <asp:TextBox ID="txt_citizen" runat="server" CssClass="btn-lg" Width="200px"></asp:TextBox>
                               <asp:Button ID="btn_search" runat="server" Text="ค้นหาข้อมูล" CssClass="btn-lg"/></td>
                       </tr>
                   </table>
                   
               </td>
           </tr>
           <tr>
               <td>

               </td>
           </tr>
           <br />
       </table>
       <table width="100%">
           <tr>
               <td>
                   <telerik:RadGrid ID="RadGrid2" runat="server" AllowFilteringByColumn="True" CellSpacing="0" GridLines="None" AllowPaging="true" PageSize="15">
                       <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                           <Columns>
                               <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                   HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="LCNNO_DISPLAY" FilterControlAltText="Filter LCNNO_DISPLAY column"
                                   HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO_DISPLAY" UniqueName="LCNNO_DISPLAY">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                                   HeaderText="ชื่อสถานที่" SortExpression="thanameplace" UniqueName="thanameplace">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="PROCESS_NAME" FilterControlAltText="Filter PROCESS_NAME column"
                                   HeaderText="ประเภท" SortExpression="PROCESS_NAME" UniqueName="PROCESS_NAME">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="PROCESS_ID" FilterControlAltText="Filter PROCESS_ID column"
                                   HeaderText="PROCESS_ID" SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                               </telerik:GridBoundColumn>
                               
                               <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="sel"
                           CommandName="sel" Text="เลือกข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                           </Columns>
                       </MasterTableView>
                   </telerik:RadGrid>
              
                   <telerik:RadGrid ID="RadGrid1" runat="server" style="display:none;">
               <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                   <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                   <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                       <HeaderStyle Width="20px"></HeaderStyle>
                   </RowIndicatorColumn>

                   <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                       <HeaderStyle Width="20px"></HeaderStyle>
                   </ExpandCollapseColumn>

                   <Columns>
                       <telerik:GridBoundColumn DataField="lcnsid" DataType="System.Int32" FilterControlAltText="Filter lcnsid column" HeaderText="lcnsid"
                           SortExpression="lcnsid" UniqueName="lcnsid" Display="false">
                           <ColumnValidationSettings>
                               <%--<ModelErrorMessage Text="" />--%>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>

                       <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                           HeaderText="ชื่อสถานที่" SortExpression="thanameplace" UniqueName="thanameplace">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                           HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="IDENTIFY" DataType="System.Int32" FilterControlAltText="Filter IDENTIFY column"
                           HeaderText="IDENTIFY" ReadOnly="True" SortExpression="IDENTIFY" UniqueName="IDENTIFY" Display="false">
                       </telerik:GridBoundColumn>
                       
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="sel"
                           CommandName="sel" Text="เลือกข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                   </Columns>

                   <EditFormSettings>
                       <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                   </EditFormSettings>

                   <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
               </MasterTableView>

               <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

               <FilterMenu EnableImageSprites="False"></FilterMenu>
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