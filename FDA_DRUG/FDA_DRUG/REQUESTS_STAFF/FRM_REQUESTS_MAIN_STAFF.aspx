<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_REQUESTS_MAIN_STAFF.aspx.vb" Inherits="FDA_DRUG.FRM_REQUESTS_MAIN_STAFF" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script type="text/javascript" >
         $(document).ready(function () {
             $('#ContentPlaceHolder1_btn_add').click(function () {
                 Popups('../REQUESTS_STAFF/FRM_REQUESTS_ADD_STAFF2.aspx');
                 return false;
             });

             function CloseSpin() {
                 $('#spinner').toggle('slow');
             }
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
         function close_modal() { // คำสั่งสั่งปิด PopUp
             $('#myModal').modal('hide');
             $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
         }

         function close_modal2() { // คำสั่งสั่งปิด PopUp
             $('#myModal2').modal('hide');
             $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
         }
        </script> 

       <div >
      
           <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4> ใบนัดรับผลพิจารณาคำขอ</h4> </div>

         </div>
           <div class="panel panel-body"  style="width:100%;padding-left:5%;">
        <table width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btn_report" runat="server" Text="รายงานประจำวัน" CssClass="btn-lg" />
                    <asp:Button ID="btn_add" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-lg" />
                </td>
            </tr>
        </table>
        </div>
           
        <div style="text-align:center;">

            <%--<asp:Label ID="Label1" runat="server" CssClass="badge" Text="" vi Font-Size="XX-Large"></asp:Label>--%>
           
              <div class="panel panel-body"  style="width:100%;padding-left:5%;">

                  <table style="width:100%;" >
                      <tr>
                            <td style="width:10%;">กลุ่มงาน </td>
                            <td style="width:25%;">
                                <asp:DropDownList ID="ddl_WORK_GROUP" runat="server" Width="80%">
                                    <asp:ListItem></asp:ListItem>
                                </asp:DropDownList></td>
                            <td style="width:25%;">
                                <asp:Button ID="btn_filter" runat="server" Text="ค้นหา" /></td>
                            <td style="width:40%;"></td>
                      </tr>
                  </table>
                  <br />
           <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0" GridLines="None" PageSize="20">
<MasterTableView autogeneratecolumns="False" datakeynames="IDA">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
       
        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
             HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                            <ColumnValidationSettings>
                            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
 <telerik:GridBoundColumn DataField="RCVNO_DISPLAY" FilterControlAltText="Filter RCVNO_DISPLAY column" 
            HeaderText="เลขประเมินคำขอ" SortExpression="RCVNO_DISPLAY" UniqueName="RCVNO_DISPLAY" >
                            <ColumnValidationSettings>
                            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        
        <telerik:GridBoundColumn DataField="TYPE_REQUESTS_NAME" FilterControlAltText="Filter TYPE_REQUESTS_NAME column" 
            HeaderText="ประเภทคำขอ" SortExpression="TYPE_REQUESTS_NAME" UniqueName="TYPE_REQUESTS_NAME" >
                            <ColumnValidationSettings>
                            </ColumnValidationSettings>
        </telerik:GridBoundColumn>

        <telerik:GridBoundColumn DataField="REQUESTS_DATE" FilterControlAltText="Filter REQUESTS_DATE column" DataType="System.DateTime" 
            HeaderText="วันที่รับเรื่อง"  SortExpression="REQUESTS_DATE" UniqueName="REQUESTS_DATE"  DataFormatString="{0:d/M/yyyy}"> 
                            <ColumnValidationSettings>
                            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
       

        <telerik:GridBoundColumn DataField="ALLOW_NAME" FilterControlAltText="Filter ALLOW_NAME column" 
            HeaderText="ชื่อผู้รับอนุญาต" SortExpression="ALLOW_NAME" UniqueName="ALLOW_NAME" >
                            <ColumnValidationSettings>
                            </ColumnValidationSettings>
        </telerik:GridBoundColumn>

        <telerik:GridBoundColumn DataField="REQUESTS_AUTHORITIES" FilterControlAltText="Filter REQUESTS_AUTHORITIES column" 
            HeaderText="เจ้าหน้าที่ผู้รับคำขอ" SortExpression="REQUESTS_AUTHORITIES" UniqueName="REQUESTS_AUTHORITIES" >
                            <ColumnValidationSettings>
                            </ColumnValidationSettings>
        </telerik:GridBoundColumn>

        <telerik:GridBoundColumn DataField="WORK_GROUP_NAME" FilterControlAltText="Filter WORK_GROUP_NAME column" 
            HeaderText="เจ้าหน้าที่ผู้รับผิดชอบ" SortExpression="WORK_GROUP_NAME" UniqueName="WORK_GROUP_NAME" >
                            <ColumnValidationSettings>
                            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
          <telerik:GridBoundColumn DataField="WORK_GROUP_ID" FilterControlAltText="Filter WORK_GROUP_ID column" 
            HeaderText="WORK_GROUP_ID" SortExpression="WORK_GROUP_ID" UniqueName="WORK_GROUP_ID" Display="false" >
                            <ColumnValidationSettings>
                            </ColumnValidationSettings>
        </telerik:GridBoundColumn>

       
              <telerik:GridButtonColumn  ButtonType="LinkButton" UniqueName="select"
                        CommandName="sel" Text="ดูข้อมูล" >
                        <HeaderStyle Width="70px" />
   </telerik:GridButtonColumn>

              <telerik:GridButtonColumn  ButtonType="LinkButton" UniqueName="_del" ConfirmText="คุณต้องการที่จะลบข้อมูลนี้?" Display="false"
                        CommandName="_del" Text="ลบข้อมูล" >
                        <HeaderStyle Width="70px" />
              </telerik:GridButtonColumn>
    </Columns>

<EditFormSettings>
<EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
</EditFormSettings>

<PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
</MasterTableView>

<PagerStyle PageSizeControlType="RadComboBox" PageSizes="20;50;100"></PagerStyle>

<FilterMenu EnableImageSprites="False"></FilterMenu>
           </telerik:RadGrid>
           


        </div>

     
    </div>
    
     <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียด ใบนัดรับพิจารณา<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
             <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"  />

</asp:Content>
