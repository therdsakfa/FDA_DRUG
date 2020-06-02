<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Product.Master" CodeBehind="FRM_LCN_LCT.aspx.vb" Inherits="FDA_DRUG.RM_LCN_LCT" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
    <style type="text/css">
 .hiddencol
  {
    display: none;
  }
    </style>
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

                 $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                 var i = $('#f1'); // ID ของ iframe   
                 i.attr("src", url); //  url ของ form ที่จะเปิด
             }


             function closespinner() {
                 alert('Download เสร็จสิ้น');
                 $('#spinner').fadeOut('slow');
                 $('#ContentPlaceHolder1_Button1').click();
             }
        </script> 
    

        <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../DESIGN/imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>

    
    
     <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4> สถานที่ขาย สถานที่นำหรือสั่งฯ/สถานที่ผลิต&nbsp;</h4> </div>
                          <div  class="col-lg-8 col-md-8">
                               <p style="text-align:right;padding-right:5%;">

            <asp:Button ID="btn_download" runat="server" Text="ลงทะเบียนสถานที่ตั้ง/สถานที่เก็บใหม่" CssClass="btn-lg"   />
        &nbsp;&nbsp;
            <asp:Button ID="btn_upload" runat="server" Text="อัพโหลด" CssClass="btn-lg" style="display:none;"   />
        </p>
                          </div>

         </div>
    
    </div>
    
       <div class="panel panel-body"  style="width:100%;padding-left:5%;">
           <asp:Button ID="Button1" runat="server" Text="Button"  style="display:none" />
           
           <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="10">
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
                       <telerik:GridBoundColumn DataField="rcvno" DataType="System.Int32" FilterControlAltText="Filter rcvno column"
                           HeaderText="เลขรับ" SortExpression="rcvno" UniqueName="rcvno">
                           <ColumnValidationSettings>
                               <%--<ModelErrorMessage Text="" />--%>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="rcvdate" DataFormatString="{0:d}" DataType="System.DateTime" FilterControlAltText="Filter rcvdate column" HeaderText="วันที่ส่งเรื่อง" SortExpression="rcvdate" UniqueName="rcvdate">
                           <ColumnValidationSettings>
                               <%--<ModelErrorMessage Text="" />--%>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>

                       <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                           HeaderText="ชื่อสถานที่" SortExpression="thanameplace" UniqueName="thanameplace">
                           <ColumnValidationSettings>
                               <%--<ModelErrorMessage Text="" />--%>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
                           <ColumnValidationSettings>
                               <%--<ModelErrorMessage Text="" />--%>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="XMLNAME" FilterControlAltText="Filter XMLNAME column" HeaderText="รหัสดำเนินการ" SortExpression="XMLNAME" UniqueName="XMLNAME">
                           <ColumnValidationSettings>
                               <%--<ModelErrorMessage Text="" />--%>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>


                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                           HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                           <ColumnValidationSettings>
                               <%--<ModelErrorMessage Text="" />--%>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
                           HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                           <ColumnValidationSettings>
                               <%--<ModelErrorMessage Text="" />--%>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
                           HeaderText="TR_ID" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
                           <ColumnValidationSettings>
                               <%--<ModelErrorMessage Text="" />--%>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="DOWN_ID" DataType="System.Int32" FilterControlAltText="Filter DOWN_ID column"
                           HeaderText="DOWN_ID" SortExpression="DOWN_ID" UniqueName="DOWN_ID" Display="false">
                           <ColumnValidationSettings>
                               <%--<ModelErrorMessage Text="" />--%>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="CITIZEN_ID" FilterControlAltText="Filter CITIZEN_ID column" HeaderText="CITIZEN_ID"
                           SortExpression="CITIZEN_ID" UniqueName="CITIZEN_ID" Display="false">
                           <ColumnValidationSettings>
                               <%--<ModelErrorMessage Text="" />--%>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="CITIZEN_ID_UPLOAD" FilterControlAltText="Filter CITIZEN_ID_UPLOAD column"
                           HeaderText="CITIZEN_ID_UPLOAD" SortExpression="CITIZEN_ID_UPLOAD" UniqueName="CITIZEN_ID_UPLOAD" Display="false">
                           <ColumnValidationSettings>
                               <%--<ModelErrorMessage Text="" />--%>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>


                       <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                           HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">


                           <ColumnValidationSettings>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>

                       <telerik:GridBoundColumn DataField="REMARK" FilterControlAltText="Filter REMARK column"
                           HeaderText="เหตุผลการคืนคำขอ" SortExpression="REMARK" UniqueName="REMARK">


                           <ColumnValidationSettings>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>

                       <telerik:GridBoundColumn DataField="lctcd" DataType="System.Int32" FilterControlAltText="Filter lctcd column" HeaderText="lctcd"
                           SortExpression="lctcd" UniqueName="lctcd" Display="false">
                           <ColumnValidationSettings>
                               <%--<ModelErrorMessage Text="" />--%>
                           </ColumnValidationSettings>
                       </telerik:GridBoundColumn>
                       <%-- <telerik:GridTemplateColumn>
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink1"  runat="server">ดูข้อมูล</asp:HyperLink>
            </ItemTemplate>
        </telerik:GridTemplateColumn>--%>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="view"
                           CommandName="view" Text="ดูข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="sel" HeaderText="การขอใบอนุญาต"
                           CommandName="sel" Text="กดเพื่อยื่นขออนุญาต">
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
           <br />
               <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4> สถานที่เก็บยาสำหรับใช้ประกอบสถานที่ขาย สถานที่นำหรือสั่งฯ/สถานที่ผลิต</h4> </div>
                          <div  class="col-lg-8 col-md-8">
                               <p style="text-align:right;padding-right:5%;">

            <asp:Button ID="btn_download_2" runat="server" Text="ดาวน์โหลด" CssClass="btn-lg"  style="display:none;" />
        &nbsp;&nbsp;
            <asp:Button ID="btn_upload_2" runat="server" Text="อัพโหลด" CssClass="btn-lg" style="display:none;"  />
        </p>
                          </div>

         </div>
    
    </div>
           <telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="true" PageSize="10">
<MasterTableView autogeneratecolumns="False" datakeynames="IDA">
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
                      <telerik:GridBoundColumn DataField="rcvno" DataType="System.Int32" FilterControlAltText="Filter rcvno column" 
                          HeaderText="เลขรับ" SortExpression="rcvno" UniqueName="rcvno">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="rcvdate"  DataFormatString="{0:d}" DataType="System.DateTime" FilterControlAltText="Filter rcvdate column" HeaderText="วันที่ส่งเรื่อง" SortExpression="rcvdate" UniqueName="rcvdate">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        
                 <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                      HeaderText="ชื่อสถานที่" SortExpression="thanameplace" UniqueName="thanameplace">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
                <telerik:GridBoundColumn DataField="XMLNAME" FilterControlAltText="Filter XMLNAME column" HeaderText="รหัสดำเนินการ" SortExpression="XMLNAME" UniqueName="XMLNAME">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>


        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
             HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
             HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
             HeaderText="TR_ID" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="DOWN_ID" DataType="System.Int32" FilterControlAltText="Filter DOWN_ID column" 
            HeaderText="DOWN_ID" SortExpression="DOWN_ID" UniqueName="DOWN_ID" Display="false">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CITIZEN_ID" FilterControlAltText="Filter CITIZEN_ID column" HeaderText="CITIZEN_ID"
             SortExpression="CITIZEN_ID" UniqueName="CITIZEN_ID" Display="false">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="CITIZEN_ID_UPLOAD" FilterControlAltText="Filter CITIZEN_ID_UPLOAD column" 
            HeaderText="CITIZEN_ID_UPLOAD" SortExpression="CITIZEN_ID_UPLOAD" UniqueName="CITIZEN_ID_UPLOAD" Display="false">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>

 
                <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column" 
            HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME" >
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>

        <telerik:GridBoundColumn DataField="lctcd" DataType="System.Int32" FilterControlAltText="Filter lctcd column" HeaderText="lctcd" 
            SortExpression="lctcd" UniqueName="lctcd" Display="false">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridTemplateColumn>

           <%-- <ItemTemplate>
                <asp:HyperLink ID="HyperLink2"  runat="server">ดูข้อมูล</asp:HyperLink>
            </ItemTemplate>--%>
        </telerik:GridTemplateColumn>

                      <telerik:GridButtonColumn  ButtonType="LinkButton" UniqueName="view1"
                        CommandName="view1" Text="ดูข้อมูล" >
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
    </div>
 
   <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
         
    <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียด ทะเบียนสถานที่<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>

</asp:Content>