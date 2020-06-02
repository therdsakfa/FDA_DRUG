<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF_MAIN.Master" CodeBehind="FRM_REPLACEMENT_BOOKING.aspx.vb" Inherits="FDA_DRUG.FRM_REPLACEMENT_BOOKING" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/UC/UC_DRUG_SEARCH.ascx" TagPrefix="uc1" TagName="UC_DRUG_SEARCH" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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


         function closespinner() {
             alert('Download เสร็จสิ้น');
             $('#spinner').fadeOut('slow');
             $('#ContentPlaceHolder1_btn_down').click();
         }
        </script> 

      <div class="panel panel-default">
       <div class="panel-heading" style="background-color:gold;color:black;width:100%"> ทะเบียนนัดหมาย</div>
       
        </div>
       <div class="panel  panel-info" style="width:100%">
           <uc1:UC_DRUG_SEARCH runat="server" ID="UC_DRUG_SEARCH" />
         <div style="text-align:center;padding-top:10px;padding-bottom:20px;">

                      <asp:Button ID="Btn_OK" runat="server" CssClass="btn-group-xs" Text="ค้นหา" Width="20%" />
            &nbsp;&nbsp;
            <asp:Button ID="Btn_save" runat="server" CssClass="btn-group-xs" Text="ลงทะเบียนนัดหมาย" Width="20%" />
               <asp:Button ID="btn_reload" runat="server" CssClass="btn-primary btn-lg" Text="btn_reload" Width="20%" Style="display:none"  />
    </div>
        <div >
            <telerik:RadGrid ID="rg_MAIN" runat="server" CellSpacing="0" GridLines="None"  AutoGenerateColumns="False" Skin="MetroTouch" AllowPaging="True" PageSize="20">
       <MasterTableView>
           <Columns>
              <telerik:GridBoundColumn FilterControlAltText="Filter SCHEDULE_ID column" UniqueName="SCHEDULE_ID"  DataField="SCHEDULE_ID" 
                 SortExpression="SCHEDULE_ID" HeaderText="IDA"  ReadOnly="True"   Display="false" ItemStyle-Font-Size="Small" >
               </telerik:GridBoundColumn>

                   <telerik:GridBoundColumn FilterControlAltText="Filter SCHEDULE_DATE column" UniqueName="SCHEDULE_DATE" DataField="SCHEDULE_DATE" DataFormatString="{0:d}"
                 SortExpression="SCHEDULE_DATE" HeaderText="วันที่"  ReadOnly="True" ItemStyle-Width="5%"  ItemStyle-Font-Size="Small" >
               </telerik:GridBoundColumn>

               <telerik:GridBoundColumn FilterControlAltText="Filter CONSIDER_DATE column" UniqueName="CONSIDER_DATE"  DataField="CONSIDER_DATE" 
                 SortExpression="CONSIDER_DATE"  HeaderText="วันที่ส่งเอกสาร" ReadOnly="True" DataFormatString="{0:d}" ItemStyle-Font-Size="Small" >
               </telerik:GridBoundColumn>

                 <telerik:GridBoundColumn FilterControlAltText="Filter ALLOW_DATE column" UniqueName="ALLOW_DATE"  DataField="ALLOW_DATE" 
                 SortExpression="ALLOW_DATE"  HeaderText="วันที่ฟังผลการตรวจรับ" ReadOnly="True" DataFormatString="{0:d}" ItemStyle-Font-Size="Small" > 
               </telerik:GridBoundColumn>

                 <telerik:GridBoundColumn FilterControlAltText="Filter BOOKING_SUBSTITUTE_NAME column" UniqueName="BOOKING_SUBSTITUTE_NAME"  DataField="BOOKING_SUBSTITUTE_NAME" 
                 SortExpression="BOOKING_SUBSTITUTE_NAME"  HeaderText="ผู้รับอนุญาต" ReadOnly="True" ItemStyle-Font-Size="Small" >
               </telerik:GridBoundColumn>

                 <telerik:GridBoundColumn FilterControlAltText="Filter THAINAMEPLACE column" UniqueName="THAINAMEPLACE"  DataField="THAINAMEPLACE" 
                 SortExpression="THAINAMEPLACE"  HeaderText="ชื่อสถานที่" ReadOnly="True" ItemStyle-Font-Size="Small" >
               </telerik:GridBoundColumn>

                <telerik:GridBoundColumn FilterControlAltText="Filter PROCESS_NAME column" UniqueName="PROCESS_NAME"  DataField="PROCESS_NAME" 
                 SortExpression="PROCESS_NAME"  HeaderText="กระบวนการ" ReadOnly="True" ItemStyle-Font-Size="Small" >
               </telerik:GridBoundColumn>

                 <telerik:GridBoundColumn FilterControlAltText="Filter WORK_GROUP_NAME column" UniqueName="WORK_GROUP_NAME"  DataField="WORK_GROUP_NAME" 
                 SortExpression="WORK_GROUP_NAME"  HeaderText="ฝ่าย" ReadOnly="True" ItemStyle-Font-Size="Small" >
               </telerik:GridBoundColumn>

             <telerik:GridBoundColumn FilterControlAltText="Filter STATUS_NAME1 column" UniqueName="STATUS_NAME1"  DataField="STATUS_NAME1" 
                 SortExpression="STATUS_NAME1"  HeaderText="สถานะ" ReadOnly="True" ItemStyle-Font-Size="Small" >
               </telerik:GridBoundColumn>

                 <telerik:GridBoundColumn FilterControlAltText="Filter REF_C_NUMBER_1 column" UniqueName="REF_C_NUMBER_1"  DataField="REF_C_NUMBER_1" 
                 SortExpression="REF_C_NUMBER_1"  HeaderText="เลขอ้างอิง C" ReadOnly="True" ItemStyle-Font-Size="Small" >
               </telerik:GridBoundColumn>

                    <telerik:GridBoundColumn FilterControlAltText="Filter REF_R_NUMBER_1 column" UniqueName="REF_R_NUMBER_1"  DataField="REF_R_NUMBER_1" 
                 SortExpression="REF_R_NUMBER_1"  HeaderText="เลขอ้างอิง R" ReadOnly="True" ItemStyle-Font-Size="Small" >
               </telerik:GridBoundColumn>

          
               <%--  <telerik:GridBoundColumn FilterControlAltText="Filter STATUS_NAME column" UniqueName="STATUS_NAME"  DataField="STATUS_NAME" 
                 SortExpression="STATUS_NAME"  HeaderText="จำนวนเงิน" ReadOnly="True" >
               </telerik:GridBoundColumn>--%>

                  <telerik:GridTemplateColumn  >
            <ItemTemplate>

                
                        <asp:Button ID="lbn_status" Width="100%" runat="server" CssClass="btn-info btn-sm" BackColor="Goldenrod" Text="ปรับสถานะ" CommandName="status" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' /> 
                <asp:Button ID="lbn_doc" runat="server" CssClass="btn-success btn-sm" Text="ใบนัดส่งเอกสาร" CommandName="doc" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' /> &nbsp;
                 <asp:Button ID="lbn_doc2" runat="server" CssClass="btn-success btn-sm" Text="ใบนัดฟังผลการตรวจรับ" CommandName="doc2" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' /> &nbsp;
                
            </ItemTemplate>
                
                
        </telerik:GridTemplateColumn>
           </Columns>
       </MasterTableView>
                 </telerik:RadGrid>
        <%--    <telerik:RadGrid ID="rg_MAIN" runat="server" CellSpacing="0" GridLines="None"  AutoGenerateColumns="False" Skin="MetroTouch">
       <MasterTableView>
           <Columns>
              <telerik:GridBoundColumn FilterControlAltText="Filter SCHEDULE_ID column" UniqueName="SCHEDULE_ID"  DataField="SCHEDULE_ID" 
                 SortExpression="SCHEDULE_ID" HeaderText="SCHEDULE_ID"  ReadOnly="True"   Display="false" >
               </telerik:GridBoundColumn>

               <telerik:GridBoundColumn FilterControlAltText="Filter SCHEDULE_DATE column" UniqueName="SCHEDULE_DATE"  DataField="SCHEDULE_DATE" 
                 SortExpression="SCHEDULE_DATE"  HeaderText="วันที่" ReadOnly="True">
               </telerik:GridBoundColumn>

                <telerik:GridBoundColumn FilterControlAltText="Filter SCHEDULE_TIME_START column" UniqueName="SCHEDULE_TIME_START"  DataField="SCHEDULE_TIME_START" 
                 SortExpression="SCHEDULE_TIME_START"  HeaderText="เวลาเริ่มต้น" ReadOnly="True" >
               </telerik:GridBoundColumn>

                <telerik:GridBoundColumn FilterControlAltText="Filter SCHEDULE_TIME_END column" UniqueName="SCHEDULE_TIME_END"  DataField="SCHEDULE_TIME_END" 
                 SortExpression="SCHEDULE_TIME_END"  HeaderText="เวลาสิ้นสุด" ReadOnly="True" >
               </telerik:GridBoundColumn>

                <telerik:GridBoundColumn FilterControlAltText="Filter SCHEDULE_DESCRIPTION column" UniqueName="SCHEDULE_DESCRIPTION"  DataField="SCHEDULE_DESCRIPTION" 
                 SortExpression="SCHEDULE_DESCRIPTION"  HeaderText="รายละเอียด" ReadOnly="True" >
               </telerik:GridBoundColumn>

              <telerik:GridBoundColumn FilterControlAltText="Filter DEPARTMENT_TYPE_NAME column" UniqueName="DEPARTMENT_TYPE_NAME"  DataField="DEPARTMENT_TYPE_NAME" 
                 SortExpression="DEPARTMENT_TYPE_NAME"  HeaderText="แผนก" ReadOnly="True" >
               </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlAltText="Filter DOCUMENT_TYPE_NAME column" UniqueName="DOCUMENT_TYPE_NAME"  DataField="DOCUMENT_TYPE_NAME" 
                 SortExpression="DOCUMENT_TYPE_NAME"  HeaderText="กระบวนการ" ReadOnly="True" >
               </telerik:GridBoundColumn>
                <telerik:GridBoundColumn FilterControlAltText="Filter CHANNEL_NAME column" UniqueName="CHANNEL_NAME"  DataField="CHANNEL_NAME" 
                 SortExpression="CHANNEL_NAME"  HeaderText="ชื่อ Service" ReadOnly="True" >
               </telerik:GridBoundColumn>


               <telerik:GridTemplateColumn>
            <ItemTemplate>
                <asp:Button ID="lbn_status" runat="server" Text="เลือกข้อมูล" CommandName="status"  />
            </ItemTemplate>
        </telerik:GridTemplateColumn>


                <telerik:GridTemplateColumn>
            <ItemTemplate>
                <asp:Button ID="lbnDel" runat="server" Text="เลือกข้อมูล" CommandName="sel" OnClientClick=" return confirm('คุณยืนยันที่จะลบข้อมูลหรือไม่');" />
            </ItemTemplate>
        </telerik:GridTemplateColumn>

           </Columns>
       </MasterTableView>
                 </telerik:RadGrid>--%>


        <%--<asp:GridView ID="Gv_booking" runat="server" DataKeyNames="SCHEDULE_ID" Width="100%" AutoGenerateColumns="False" CellPadding="4" 
              ForeColor="#333333" GridLines="Vertical" BorderColor="White" BorderStyle="Solid" BorderWidth="1px" HeaderStyle-HorizontalAlign="Center"
            >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                    <asp:BoundField HeaderText="SCHEDULE_ID" DataField="SCHEDULE_ID" Visible="false" ItemStyle-Width="0%" />
                 <asp:BoundField HeaderText="STATUS_ID" DataField="STATUS_ID" Visible="false" ItemStyle-Width="0%" />

               <asp:BoundField HeaderText="วันที่" DataField="SCHEDULE_DATE" DataFormatString="{0:d}" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center"  />
                <asp:BoundField HeaderText="ชื่อผู้รับอนุญาต" DataField="BOOKING_SUBSTITUTE_NAME"  ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="ชื่อสถานที่" DataField="THAINAMEPLACE"  ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="ประเภทคำขอ" DataField="PROCESS_NAME" ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="ฝ่าย" DataField="WORK_GROUP_NAME" ItemStyle-Width="5%" HeaderStyle-HorizontalAlign="Center" />
                 <asp:BoundField HeaderText="วันที่ฟังผล" DataField="CONSIDER_DATE_DISPLAY"  ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="วันที่รับใบ" DataField="ALLOW_DATE_DISPLAY"  ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"  />
                <asp:BoundField HeaderText="สถานะ" DataField="STATUS_NAME1" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" />
                 <asp:BoundField HeaderText="เลขอ้างอิง C" DataField="REF_C_NUMBER_1"  ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" />
                <asp:BoundField HeaderText="เลขอ้างอิง R" DataField="REF_R_NUMBER_1"  ItemStyle-Width="10%" HeaderStyle-HorizontalAlign="Center" />
                  <asp:TemplateField>
                    <ItemTemplate>
                         <asp:Button ID="lbn_status" Width="100%" runat="server" CssClass="btn-info" BackColor="Goldenrod" Text="ปรับสถานะ" CommandName="status" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' /> 
                <asp:Button ID="lbn_doc" runat="server" CssClass="btn-success" Text="ใบนัดส่งเอกสาร" CommandName="doc" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' /> &nbsp;
                 <asp:Button ID="lbn_doc2" runat="server" CssClass="btn-success" Text="ใบนัดฟังผลการตรวจรับ" CommandName="doc2" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' /> &nbsp;
                    </ItemTemplate>

                </asp:TemplateField>
            </Columns>
            
           <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" HorizontalAlign="Center"  CssClass="text-center" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" BorderColor ="White" BorderWidth="1px" BorderStyle="Solid" />
            <RowStyle BackColor="#EFF3FB" BorderColor ="White" BorderWidth="1px" BorderStyle="Solid" Font-Size="Small"  />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>--%>
    </div>
    </div>

       <div class="modal  " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                   <asp:Label ID="lbl_modal" runat="server" Text=""></asp:Label>  
            
                    <button type="button" class="btn btn-default pull-right" style="background-color:gold;color:black;" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
