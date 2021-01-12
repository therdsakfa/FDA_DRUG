<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_SEARCH.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_LCN_SEARCH" %>
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
             //    Popups('../DRUG_REQUEST_CENTER/DRUG_REQUEST_CENTER_INSERT.aspx');
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
            <h2>ค้นหาใบอนุญาตสถานที่ด้านยา</h2>

        </div>

    </div>
    
   <hr />
   <div>
       <table width="100%">
           <tr>
               <td>
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
                <td>สถานะใบอนุญาต</td>
                <td Width="70%">
                                <asp:RadioButtonList ID="rdl_stat" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CssClass="input-lg" CellSpacing="10">
                                    <asp:ListItem Value="0" Selected="True">ทั้งหมด &nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem Value="1">คงอยู่ &nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem Value="2">ยกเลิก &nbsp;&nbsp;</asp:ListItem>
                                </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>เลขนิติบุคคล/เลขบัตรประชาชน</td>
                <td Width="70%">
                                <asp:TextBox ID="txt_CITIZEN_AUTHORIZE" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>เลขที่ใบอนุญาตสถานที่</td>
                <td Width="70%">
                                <asp:TextBox ID="txt_lcnno_no" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                &nbsp;(ตัวอย่าง นย1 กท 1/2555)</td>
            </tr>
            <%--<tr>
                <td>เลขสถานที่</td>
                <td Width="70%">
                                <asp:TextBox ID="txt_lcnsid" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                </td>
            </tr>--%>
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
                   <asp:Button ID="btn_template" runat="server" Text="Template เพื่อส่งนำเข้าข้อมูล" CssClass="btn-lg" />
                   <asp:Button ID="btn_export_phr" runat="server" Text="Export ผู้มีหน้าที่ปฏิบัติงาน" CssClass="btn-lg" />
                   <asp:Button ID="btn_export" runat="server" Text="Export ใบอนุญาตทั้งหมด" CssClass="btn-lg" />
               </td>
           </tr>
           <tr>
               <td>

                   <%--*หมายเหตุ (1) วันที่ใช้ไปหมายถึง วันที่รับคำขอจนถึงวันที่คำนวณปัจจุบัน (คำนวณทุกวันศุกร์), (2) วันหยุดเวลาหมายถึง วันที่อยู่ในระหว่างการผ่อนผันของผู้ประกอบการ (3) วันที่แสดงเป็นวันทำการ</td>--%>
           </tr>
           </table>
       <table width="100%">
           <tr>
               <td>
                   <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
                   <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0" GridLines="None" PageSize="15">
    <MasterTableView autogeneratecolumns="False" datakeynames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">

    <Columns>
       
        <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
             HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="lcnno"  FilterControlAltText="Filter lcnno column"
             HeaderText="lcnno" ReadOnly="True" SortExpression="lcnno" UniqueName="lcnno" Display="false">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CITIZEN_ID_AUTHORIZE"  FilterControlAltText="Filter CITIZEN_ID_AUTHORIZE column"
             HeaderText="CITIZEN_ID_AUTHORIZE" ReadOnly="True" SortExpression="CITIZEN_ID_AUTHORIZE" UniqueName="CITIZEN_ID_AUTHORIZE" Display="false">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="lcntpcd" FilterControlAltText="Filter lcntpcd column" 
            HeaderText="ประเภทคำขอ" SortExpression="lcntpcd" UniqueName="lcntpcd" >
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="lcnno_no" FilterControlAltText="Filter lcnno_no column" 
            HeaderText="เลขที่ใบอนุญาต" SortExpression="lcnno_no" UniqueName="lcnno_no" >
        </telerik:GridBoundColumn>
       <telerik:GridBoundColumn DataField="thanm" FilterControlAltText="Filter thanm column" 
            HeaderText="ชื่อสถานที่" SortExpression="thanm" UniqueName="thanm" >
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="thanm_addr" FilterControlAltText="Filter thanm_addr column" 
            HeaderText="ที่อยู่" SortExpression="thanm_addr" UniqueName="thanm_addr" ItemStyle-Width="30%">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="grannm_lo" FilterControlAltText="Filter grannm_lo column" 
            HeaderText="ชื่อผู้ดำเนินกิจการ" SortExpression="grannm_lo" UniqueName="grannm_lo" >
        </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="thachngwtnm" FilterControlAltText="Filter thachngwtnm column" 
            HeaderText="จังหวัด" SortExpression="thachngwtnm" UniqueName="thachngwtnm" >
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column" 
            HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID" >
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="STAT_DA" FilterControlAltText="Filter STAT_DA column" 
            HeaderText="สถานะใบอนุญาต" SortExpression="STAT_DA" UniqueName="STAT_DA" >
        </telerik:GridBoundColumn>
        
            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                       CommandName="sel" Text="เลือกข้อมูล">
                       <HeaderStyle Width="70px" />
                   </telerik:GridButtonColumn>
        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_drug_group"
                       CommandName="drug_group" Text="หมวดยา">
                       <HeaderStyle Width="70px" />
                   </telerik:GridButtonColumn>
        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_trid"
                       CommandName="_trid" Text="ขอเลขดำเนินการ" ConfirmText="คุณต้องการทำต่อหรือไม่?">
                       <HeaderStyle Width="70px" />
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
                   <div class="panel-heading  text-center"><h1>ใบอนุญาตต่ออายุสถานที่ด้านยา </h1></div>
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
</asp:Content>
