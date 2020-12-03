<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_PRODUCT_ID.Master" CodeBehind="TABEAN_YA_MAIN.aspx.vb" Inherits="FDA_DRUG.TABEAN_YA_MAIN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/DS/UC/UC_DS_MAIN.ascx" TagPrefix="uc1" TagName="UC_DS_MAIN" %>

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
           function Popups3(url) { // สำหรับทำ Div Popup
               $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
               var i = $('#f12'); // ID ของ iframe   
               i.attr("src", url); //  url ของ form ที่จะเปิด
           }
           function close_modal() { // คำสั่งสั่งปิด PopUp
               debugger;
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
         <%--   <h2> บัญชีรายการขอขึ้นทะเบียนยา</h2>

            License number : 
            --%>
        </div>


        
    </div>
    <br />
    <asp:Panel ID="Panel3" runat="server" GroupingText="ข้อมูล">
        <table class="table" style="width: 100%;">
            <tr>
                <td style="font-size:larger;">
                    ชื่อบริษัท</td>
                <td>
                    <asp:Label ID="lbl_lcn_name" runat="server"></asp:Label>
                </td>
                <td style="font-size:larger">
                    เลขที่ใบอนุญาต
                </td>
                <td>
                <asp:Label ID="lbl_lcnno" runat="server" Text=""></asp:Label>
                </td>
            </tr>
             <tr>
                 <td style="font-size:larger">ชื่อยา(ไทย) </td>
                 <td>
                 <asp:Label ID="lb_drug_name" runat="server" Text=""></asp:Label>
                 </td>
                 <td style="font-size:larger">ชื่อยา(ภาษาอังกฤษ) </td>
                 <td>
                <asp:Label ID="lb_drug_name_other" runat="server" Text=""></asp:Label>                     
                 </td>
            </tr>
             <tr>
                <td style="font-size:larger">
                   หมวดยา
                </td>
                <td>
                    <asp:Label ID="lb_drug_group" runat="server" Text=""></asp:Label>
                </td>
                <td style="font-size:larger">
                    ชนิดของยา
                </td>
                 <td>
                      <asp:Label ID="lb_drug_type" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="font-size:larger">เลขที่ตำรับ</td>
                <td>
                    <asp:Label ID="lbl_dl" runat="server" Text="-"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>   

    <br />
    <hr />
<%--    <div class="panel-info" style="text-align: right; width: 100%">
        
    </div>--%>
  
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" SelectedIndex="0" MultiPageID="RadMultiPage1" Width="100%">
        <Tabs>
            <telerik:RadTab runat="server" Text="ยาตัวอย่าง" Value="1" Selected="True">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="ย.1" Value="2"  >
            </telerik:RadTab>
        </Tabs>
    </telerik:RadTabStrip>

    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" CssClass="fa left" Width="100%">
        <telerik:RadPageView ID="RadPageView1" runat="server" TabIndex="1">
            <fieldset>
           <legend style="color: red;">ยาตัวอย่าง</legend>
           <div style="text-align: right;">
               <asp:Button ID="btn_download_ex" runat="server" Text="ดาวน์โหลดคำขอ" Width="170px" CssClass="btn-lg " Style="display: none;" />
               &nbsp;&nbsp;
       <asp:Button ID="btn_upload_ex" runat="server" Text="อัพโหลดคำขอ" Width="170px" CssClass="btn-lg " Style="display: none;" />
               <%-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
               <asp:Button ID="Button4" runat="server" Text="reload" Style="display: none" />
               <asp:Button ID="Button5" runat="server" Text="Button" Style="display: none" />
           </div>
           <table class="table" style="width: 100%;">
               <tr>
                   <td>
                       <uc1:UC_DS_MAIN runat="server" ID="UC_DS_MAIN" />
                       <asp:GridView ID="GV_Drug_EX" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
                           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt" Style="display: none;">
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
                               <asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_status" runat="server"></asp:Label>
                                   </ItemTemplate>

                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:TemplateField>
                               <asp:TemplateField ItemStyle-Width="10%" HeaderText="รหัสการดำเนินการ">
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_transession" runat="server"></asp:Label>
                                   </ItemTemplate>

                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:TemplateField>
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
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server" TabIndex="2" >
            <fieldset>
           <legend style="color: red;"> <asp:Label ID="lbl_tabean" runat="server" Text="คำขอขึ้นทะเบียนยา"></asp:Label></legend>
           <table style="width: 100%;">
               <tr>
                   <td style="width: 55%;">
                       <table style="width: 100%;">
                           <tr>
                               <td><b>ชื่อภาษาไทย :</b></td>
                               <td>
                                   <asp:Label ID="lb_th_name" runat="server"></asp:Label>
                               </td>
                               <td><b>ชื่อภาษาอังกฤษ :</b></td>
                               <td>
                                   <asp:Label ID="lb_eng_name" runat="server"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td><b>สถานะ :</b></td>
                               <td colspan="4">
                                   <asp:Label ID="lb_stat" runat="server"></asp:Label>
                               </td>
                           </tr>
                       </table>



                   </td>
                   <td valign="center">
                       <div style="text-align: right; padding-left: 0%; height: 60px;">
                           <asp:Button ID="btn_download_t" runat="server" Text="สร้างคำขอ ย.1"  CssClass="btn-sm " />
                           &nbsp;&nbsp;
                           <asp:Button ID="btn_download_t2" runat="server" Text="คำขอ Transfer/Referred/Copy" CssClass="btn-sm " />
                           &nbsp;&nbsp;
       <asp:Button ID="btn_upload_t" runat="server" Text="อัพโหลดคำขอ" CssClass="btn-sm " />
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
                           <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
                       </div>
                   </td>
               </tr>
           </table>
           <br />
           <table class="table" style="width: 100%;">
               <tr>
                   <td>
                       <h2>คำขอขึ้นทะเบียน</h2>


                       <telerik:radgrid ID="rg_tabean1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column" HeaderText="STATUS_ID"
                           SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column" HeaderText="TR_ID"
                           SortExpression="TR_ID" UniqueName="TR_ID" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                           HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
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
                       <%--<telerik:GridBoundColumn DataField="REMARK" FilterControlAltText="Filter REMARK column"
                           HeaderText="เหตุผลการคืนคำขอ" SortExpression="REMARK" UniqueName="REMARK">
                       </telerik:GridBoundColumn>--%>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                           CommandName="sel" Text="ยื่นคำขอ ย.1/ดูข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_report2"
                           CommandName="report2" Text="แบบฟอร์มทะเบียน">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_add"
                           CommandName="_add" Text="เพิ่มข้อมูลส่วนที่ 2">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_report" Display="false"
                           CommandName="_report" Text="ใบนัด">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                   </Columns>
               </MasterTableView>
           </telerik:radgrid>


                       <asp:GridView ID="GV_Tabean" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
                           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" Font-Size="10pt" style="display:none;">
                           <AlternatingRowStyle BackColor="White" />
                           <Columns>
                               <asp:BoundField DataField="IDA" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
                                   <ItemStyle Width="0%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="TR_ID" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
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
                               <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <%--<asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_status" runat="server"></asp:Label>
                                   </ItemTemplate>

                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:TemplateField>--%>
                               <asp:BoundField DataField="trans_code" HeaderText="รหัสการดำเนินการ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:TemplateField ItemStyle-Width="20%">
                                   <ItemTemplate>

                                       <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                       <asp:Button ID="btn_Preview" runat="server" Text="ดูข้อมูล" CommandName="preview" Width="0%" CssClass="btn-link" Visible="false" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                       <asp:Button ID="btn_add" runat="server" Text="เพิ่มข้อมูลส่วนที่ 2" CommandName="_add" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                        <%--<asp:Button ID="btn_iden" runat="server" Text="เพิ่มเลข Identify" CommandName="_add_iden" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />--%>
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
                       <table width="100%">
                           <tr>
                               <td align="right">
<asp:HyperLink ID="hl_pay" runat="server"  target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
                               </td>
                           </tr>
                       </table>
                       
                       <br /><br />
                       <h2>ทะเบียนตำรับ</h2>
                       <telerik:radgrid ID="rg_tabean2" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column" HeaderText="STATUS_ID"
                           SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column" HeaderText="TR_ID"
                           SortExpression="TR_ID" UniqueName="TR_ID" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                           HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
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
                       <%--<telerik:GridBoundColumn DataField="REMARK" FilterControlAltText="Filter REMARK column"
                           HeaderText="เหตุผลการคืนคำขอ" SortExpression="REMARK" UniqueName="REMARK">
                       </telerik:GridBoundColumn>--%>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                           CommandName="sel" Text="ดูข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_add"
                           CommandName="_add" Text="เพิ่มข้อมูลส่วนที่ 2">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_edit"
                           CommandName="_edit" Text="แก้ไขการเสนอลงนาม">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>--%>
                   </Columns>
               </MasterTableView>
           </telerik:radgrid>






                       <asp:GridView ID="GV_Tabean2" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
                           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" Font-Size="10pt" style="display:none;">
                           <AlternatingRowStyle BackColor="White" />
                           <Columns>
                               <asp:BoundField DataField="IDA" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
                                   <ItemStyle Width="0%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="TR_ID" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
                                   <ItemStyle Width="0%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="STATUS_ID" HeaderText="STATUS_ID" ItemStyle-Width="0%" Visible="false">
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
                               <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <%--<asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_status" runat="server"></asp:Label>
                                   </ItemTemplate>

                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:TemplateField>--%>
                               <asp:BoundField DataField="trans_code" HeaderText="รหัสการดำเนินการ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:TemplateField ItemStyle-Width="20%">
                                   <ItemTemplate>

                                       <asp:Button ID="btn_Select0" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                       <asp:Button ID="btn_Preview0" runat="server" Text="ดูข้อมูล" CommandName="preview" Width="0%" CssClass="btn-link" Visible="false" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                       <asp:Button ID="btn_add0" runat="server" Text="เพิ่มข้อมูลส่วนที่ 2" CommandName="_add" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                        <%--<asp:Button ID="btn_iden0" runat="server" Text="เพิ่มเลข Identify" CommandName="_add_iden" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />--%>
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
        </telerik:RadPageView>
        
    </telerik:RadMultiPage>

   <div>
       

       <hr />
    <br />

       
 <br />
    

       <br />
              <div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  /> 
              </div>  
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>รายละเอียด</h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="close_modal()">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
    <div class=" modal fade" id="myModal2">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>รายละเอียด</h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="close_modal()">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f2"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
