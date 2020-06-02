<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="TABEAN_YA_MAIN_STAFF.aspx.vb" Inherits="FDA_DRUG.TABEAN_YA_MAIN_STAFF" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

               //$('#ContentPlaceHolder1_btn_upload_t').click(function () {

               //    //  $('#spinner').toggle('slow');
               //    Popups('../DR/POPUP_DR_UPLOAD.aspx');
               //    return false;
               //});

               $('#ContentPlaceHolder1_btn_download_t').click(function () {
                   $('#spinner').fadeIn('slow');

               });

               //$('#ContentPlaceHolder1_btn_upload_ex').click(function () {

               //    //  $('#spinner').toggle('slow');
               //    Popups('../DS/POPUP_DS_UPLOAD.aspx');
               //    return false;
               //});

               $('#ContentPlaceHolder1_btn_download_ex').click(function () {
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
        <div >
            <h2> บัญชีรายการขอขึ้นทะเบียนยา</h2>
            <asp:Button ID="btn_reload" runat="server" Text="Button" style="display:none;" />
          <%--  License number : 
            <asp:Label ID="lbl_lcnno" runat="server" Text=""></asp:Label>--%>
        </div>


        
    </div>
    <br />

    <br />
<%--    <div class="panel-info" style="text-align: right; width: 100%">
        
    </div>--%>
  
   <div>

       <fieldset>
           <table class="table" style="width: 100%;">
               <tr>
                   <td>
                       <telerik:radgrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column" HeaderText="STATUS_ID"
                           SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column" HeaderText="เลขดำเนินการ"
                           SortExpression="TR_ID" UniqueName="TR_ID" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="RCVNO_MANUAL" FilterControlAltText="Filter RCVNO_MANUAL column"
                           HeaderText="เลขรับ" SortExpression="RCVNO_MANUAL" UniqueName="RCVNO_MANUAL">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="STATUS_NAME_STAFF" FilterControlAltText="Filter STATUS_NAME_STAFF column"
                           HeaderText="สถานะ" SortExpression="STATUS_NAME_STAFF" UniqueName="STATUS_NAME_STAFF">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column"
                           HeaderText="ชื่อภาษาไทย" SortExpression="thadrgnm" UniqueName="thadrgnm">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column"
                           HeaderText="ชื่อภาษาอังกฤษ" SortExpression="engdrgnm" UniqueName="engdrgnm">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="trans_code" FilterControlAltText="Filter trans_code column"
                           HeaderText="รหัสการดำเนินการ" SortExpression="trans_code" UniqueName="trans_code">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="REMARK" FilterControlAltText="Filter REMARK column"
                           HeaderText="เหตุผลการคืนคำขอ" SortExpression="REMARK" UniqueName="REMARK">
                       </telerik:GridBoundColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                           CommandName="sel" Text="ดูข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_add"
                           CommandName="add" Text="เพิ่มข้อมูลส่วนที่ 2">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_report"
                           CommandName="report" Text="แบบฟอร์มทะเบียน">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_report2"
                           CommandName="_report" Text="ใบนัด">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="report2" Text="เพิ่มการหยุดและขยายเวลา" UniqueName="report2">
                               </telerik:GridButtonColumn>
                       <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_edit"
                           CommandName="_edit" Text="แก้ไขการเสนอลงนาม">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>--%>
                   </Columns>
               </MasterTableView>
           </telerik:radgrid>
                       <%--<asp:GridView ID="GV_Tabean" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
                           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" Font-Size="10pt">
                           <AlternatingRowStyle BackColor="White" />
                           <Columns>
                               <asp:BoundField DataField="IDA" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
                                   <ItemStyle Width="0%"></ItemStyle>
                               </asp:BoundField>

                               <asp:BoundField DataField="thadrgnm" HeaderText="ชื่อภาษาไทย" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="engdrgnm" HeaderText="ชื่อภาษาอังกฤษ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="trans_code" HeaderText="รหัสการดำเนินการ" ItemStyle-Width="10%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="REMARK" HeaderText="เหตุผลการคืนคำขอ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:TemplateField ItemStyle-Width="20%">
                                   <ItemTemplate>

                                       <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                       <asp:Button ID="btn_Preview" runat="server" Text="ดูข้อมูล" CommandName="preview" Width="0%" CssClass="btn-link" Visible="false" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                   </ItemTemplate>

                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:TemplateField>
                               <asp:TemplateField ItemStyle-Width="20%">
                                   <ItemTemplate>
                                       <asp:Button ID="btn_edit" runat="server" Text="แก้ไขการเสนอลงนาม" CommandName="_edit" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                   </ItemTemplate>

                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:TemplateField>
                           </Columns>
                           <EditRowStyle BackColor="#2461BF" />
                           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                           <HeaderStyle BackColor="#8CB343" Font-Bold="True" ForeColor="White" />
                           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                           <RowStyle BackColor="#EFF3FB" />
                           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                           <SortedAscendingCellStyle BackColor="#F5F7FB" />
                           <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                           <SortedDescendingCellStyle BackColor="#E9EBEF" />
                           <SortedDescendingHeaderStyle BackColor="#4870BE" />
                       </asp:GridView>--%>
                   </td>
               </tr>


           </table>
       </fieldset>
<br />


       <fieldset style="display:none;">
           <legend style="color: red;">ยาตัวอย่าง</legend>
           <table class="table" style="width:100%;">
   <tr>
        <td>
            <asp:GridView ID="GV_Drug_EX" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" Font-Size="10pt">
           <AlternatingRowStyle BackColor="White" />
           <Columns>
               <asp:BoundField DataField="IDA" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
                   <ItemStyle Width="0%"></ItemStyle>
               </asp:BoundField>
       
               <asp:BoundField DataField="rcvno" HeaderText="เลขที่คำขอ" ItemStyle-Width="10%">
                   <ItemStyle Width="10%"></ItemStyle>
               </asp:BoundField>
                  
               <asp:BoundField DataField="rcvdate" DataFormatString="{0:d}" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
        <asp:BoundField DataField="thadrgnm" HeaderText="ชื่อภาษาไทย" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
               <asp:BoundField DataField="engdrgnm" HeaderText="ชื่อภาษาอังกฤษ" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
                <asp:BoundField DataField="trans_code" HeaderText="รหัสการดำเนินการ" ItemStyle-Width="10%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
               <%--<asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                   <ItemTemplate>
                       <asp:Label ID="lbl_status" runat="server"></asp:Label>
                   </ItemTemplate>

                   <ItemStyle Width="10%"></ItemStyle>
               </asp:TemplateField>--%>
               
                <asp:BoundField DataField="REMARK" HeaderText="เหตุผลการคืนคำขอ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
               <asp:TemplateField ItemStyle-Width="20%">
                   <ItemTemplate>

                       <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                       <asp:Button ID="btn_Preview" runat="server" Text="ดูข้อมูล" CommandName="preview" Width="0%" CssClass="btn-link" Visible="false" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                   </ItemTemplate>

                   <ItemStyle Width="20%"></ItemStyle>
               </asp:TemplateField>
           </Columns>
           <EditRowStyle BackColor="#2461BF" />
           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
           <HeaderStyle BackColor="#8CB343" Font-Bold="True" ForeColor="White" />
           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
           <RowStyle BackColor="#EFF3FB" />
           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
           <SortedAscendingCellStyle BackColor="#F5F7FB" />
           <SortedAscendingHeaderStyle BackColor="#6D95E1" />
           <SortedDescendingCellStyle BackColor="#E9EBEF" />
           <SortedDescendingHeaderStyle BackColor="#4870BE" />
       </asp:GridView>
        </td>
    </tr>
</table>
     </fieldset>

       

       <br />
              <div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  style="display:none;" /> 
              </div>  
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>
                       <asp:Label ID="lbl_titlename" runat="server" Text=""></asp:Label></h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="close_modal();">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
