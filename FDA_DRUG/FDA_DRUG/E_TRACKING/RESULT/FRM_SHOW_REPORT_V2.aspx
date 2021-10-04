<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_SHOW_REPORT_V2.aspx.vb" Inherits="FDA_DRUG.FRM_SHOW_REPORT_V2" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/css_radgrid.css" rel="stylesheet" />

    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/bootstrap-theme.min.css" rel="stylesheet" /> 
   
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />

    <script src="../../js/jquery-1.8.3.js"></script>
     <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
     <script type="text/javascript" >

         $(document).ready(function () {

             $("#ContentPlaceHolder1_ddl_WORK_GROUP").searchable();
             $("#ContentPlaceHolder1_ddl_category_requests").searchable();

             //$('#ContentPlaceHolder1_btn_add').click(function () {
             //    Popups('../DRUG_REQUEST_CENTER/DRUG_REQUEST_CENTER_INSERT.aspx');  //Main_E_Tracking
             //    return false;
             //});
             //$('#ContentPlaceHolder1_btn_add2').click(function () {
             //    Popups('../DRUG_REQUEST_CENTER/DRUG_REQUEST_CENTER_C_INSERT.aspx');
             //    return false;
             //});
             function CloseSpin() {
                 $('#spinner').toggle('slow');
             }



             function Popups(url) { // สำหรับทำ Div Popup

                 $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                 var i = $('#f1'); // ID ของ iframe   
                 i.attr("src", url); //  url ของ form ที่จะเปิด
             }




             $('#ContentPlaceHolder1_btn_download').click(function () {
                 $('#spinner').fadeIn('slow');

             });

         });
         function close_modal() { // คำสั่งสั่งปิด PopUp
             $('#myModal').modal('hide');
             $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
         }

         function Popups2(url) { // สำหรับทำ Div Popup

             $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
             var i = $('#f1'); // ID ของ iframe   
             i.attr("src", url); //  url ของ form ที่จะเปิด
         }
         function Popups3(url) { // สำหรับทำ Div Popup

             $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
             var i = $('#f2'); // ID ของ iframe   
             i.attr("src", url); //  url ของ form ที่จะเปิด
         }
         function Popups4(url) { // สำหรับทำ Div Popup

             $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
             var i = $('#f3'); // ID ของ iframe   
             i.attr("src", url); //  url ของ form ที่จะเปิด
         }
         function spin_space() { // คำสั่งสั่งปิด PopUp
             //    alert('123456');
             $('#spinner').toggle('slow');
             //$('#myModal').modal('hide');
             //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

         }
         function closespinner() {
             alert('Download เสร็จสิ้น');
             $('#spinner').fadeOut('slow');
             $('#ContentPlaceHolder1_Button1').click();
         }

         function insert() {
             alert('บันทึกข้อมูลเรียบร้อยแล้ว');
             $('#spinner').fadeOut('slow');
             $('#ContentPlaceHolder1_Button1').click();
         }

        </script> 
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h2>ค้นหาการติดตามคำขอด้านยา (งานค้าง)</h2>

        </div>

    </div>
    
   <hr />
   <div>
       <table width="100%">
           <tr>
               <td align="center">
                    <table style="width: 100%;" class=" table">
            <%--<tr>
                <td>กลุ่มงาน</td>
                <td Width="70%">
                                <asp:DropDownList ID="ddl_WORK_GROUP" runat="server" AutoPostBack="True" CssClass="input-lg" Width="70%">
                                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>ประเภทคำขอ</td>
                <td Width="70%">
                                <asp:DropDownList ID="ddl_category_requests" runat="server" CssClass="input-lg" Width="70%">
                                   
                                </asp:DropDownList>
                </td>
            </tr>--%>
            <tr>
                <td>เลขกระบวนงาน</td>
                <td Width="70%">
                                <asp:TextBox ID="txt_type_request" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>เลขรับประเมินคำขอ</td>
                <td Width="70%">
                                <asp:TextBox ID="txt_r_no" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td Width="70%">
                               <asp:Button ID="btn_search" runat="server" Text="ค้นหาข้อมูล" CssClass="btn-lg"/>
                </td>
            </tr>
        </table>


               </td>
           </tr>
           <tr>
               <td>

                   &nbsp;</td>
           </tr>
           <br />
           
           <tr>
               <td align="right">
                   <asp:Button ID="btn_export" runat="server" Text="Export to Excel" CssClass="btn-lg" />
               </td>
           </tr>
           <tr>
               <td>

                   *หมายเหตุ (1) วันที่ใช้ไปหมายถึง วันที่รับคำขอจนถึงวันที่คำนวณปัจจุบัน (คำนวณทุกวันศุกร์), (2) วันหยุดเวลาหมายถึง วันที่อยู่ในระหว่างการผ่อนผันของผู้ประกอบการ (3) วันที่แสดงเป็นวันทำการ</td>
           </tr>
           </table>
       <table width="100%">
           <tr>
               <td>
                   <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0" GridLines="None" PageSize="15">
                       <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">

                           <Columns>

                               <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                                   HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                               </telerik:GridBoundColumn>

                               <telerik:GridBoundColumn DataField="TYPE_REQUEST_NAME" FilterControlAltText="Filter TYPE_REQUEST_NAME column"
                                   HeaderText="ประเภทคำขอ" SortExpression="TYPE_REQUEST_NAME" UniqueName="TYPE_REQUEST_NAME">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="RCVNO_DISPLAY" FilterControlAltText="Filter RCVNO_DISPLAY column"
                                   HeaderText="เลขคำร้อง" SortExpression="RCVNO_DISPLAY" UniqueName="RCVNO_DISPLAY">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter REQUEST_DATE column" DataType="System.DateTime"
                                   HeaderText="วันที่รับเรื่อง" SortExpression="REQUEST_DATE" UniqueName="REQUEST_DATE" DataFormatString="{0:dd/MM/yyyy}">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="TRADENAME" FilterControlAltText="Filter TRADENAME column"
                                   HeaderText="ชื่อยา" SortExpression="TRADENAME" UniqueName="TRADENAME">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="TRADENAME_ENG" FilterControlAltText="Filter TRADENAME_ENG column"
                                   HeaderText="ชื่อยาภาษาอังกฤษ" SortExpression="TRADENAME_ENG" UniqueName="TRADENAME_ENG">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="ALLOW_NAME" FilterControlAltText="Filter ALLOW_NAME column"
                                   HeaderText="ชื่อผู้รับอนุญาต" SortExpression="ALLOW_NAME" UniqueName="ALLOW_NAME">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="R_DAY_WORK" FilterControlAltText="Filter R_DAY_WORK column"
                                   HeaderText="จำนวนวันที่ใช้ไป" SortExpression="R_DAY_WORK" UniqueName="R_DAY_WORK">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="STOP_DAY" FilterControlAltText="Filter STOP_DAY column"
                                   HeaderText="วันหยุดเวลา" SortExpression="STOP_DAY" UniqueName="STOP_DAY">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="DAY_WORK" FilterControlAltText="Filter DAY_WORK column"
                                   HeaderText="ระยะเวลาประกาศ" SortExpression="DAY_WORK" UniqueName="DAY_WORK">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="days_result" FilterControlAltText="Filter days_result column"
                                   HeaderText="days_result" SortExpression="days_result" UniqueName="days_result" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="CONREQ_LAST_UPDATE_DATE" FilterControlAltText="Filter CONREQ_LAST_UPDATE_DATE column" DataType="System.DateTime"
                                   HeaderText="วันที่กำหนดต้องเสร็จสิ้น" SortExpression="CONREQ_LAST_UPDATE_DATE" UniqueName="CONREQ_LAST_UPDATE_DATE" DataFormatString="{0:dd/MM/yyyy}">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                                   HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="CREATE_DATE" FilterControlAltText="Filter CREATE_DATE column"
                                   HeaderText="วันที่ของสถานะล่าสุด" SortExpression="CREATE_DATE" UniqueName="CREATE_DATE" DataType="System.DateTime" DataFormatString="{0:dd/MM/yyyy}">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="staff_name" FilterControlAltText="Filter staff_name column"
                                   HeaderText="จนท.ผู้รับผิดชอบ" SortExpression="staff_name" UniqueName="staff_name">
                               </telerik:GridBoundColumn>
                                
                               <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="report" Text="เพิ่มการหยุดและขยายเวลา" UniqueName="report">
                               </telerik:GridButtonColumn>
                               <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="stat" Text="ปรับสถานะ" UniqueName="stat">
                               </telerik:GridButtonColumn>
                               <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="staff" Text="เพิ่มจนท.ผู้รับผิดชอบ" UniqueName="staff">
                               </telerik:GridButtonColumn>
                           </Columns>
                       </MasterTableView>

                   </telerik:RadGrid>
               </td>
           </tr>

       </table>
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>เพิ่มการหยุดและขยายเวลา </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
    <div class=" modal fade" id="myModal2">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>ปรับสถานะ </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f2"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
    <div class=" modal fade" id="myModal3">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>เพิ่มเจ้าหน้าที่ </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f3"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
