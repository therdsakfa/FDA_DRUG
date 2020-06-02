<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_CER_CONFIRM2.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_CER_CONFIRM2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="../UC/UC_GRID_ATTACH.ascx" tagname="UC_GRID_ATTACH" tagprefix="uc1" %>
<%@ Register src="UC/UC_Head_Information.ascx" tagname="UC_Head_Information" tagprefix="uc2" %>
<%@ Register src="UC/UC_GMP.ascx" tagname="UC_GMP" tagprefix="uc3" %>
<%@ Register src="UC/UC_ISO.ascx" tagname="UC_ISO" tagprefix="uc4" %>
<%@ Register src="UC/UC_HACCP.ascx" tagname="UC_HACCP" tagprefix="uc5" %>
<%@ Register src="UC/UC_PIC.ascx" tagname="UC_PIC" tagprefix="uc6" %>
<%@ Register src="UC/UC_Other.ascx" tagname="UC_Other" tagprefix="uc7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      
       <script type="text/javascript" >
           $(document).ready(function () {
               $(window).load(function () {
                   $.ajax({
                       type: 'POST',
                       data: { submit: true },
                       success: function (result) {
                           //     $('#spinner').fadeOut('slow');
                       }
                   });
               });

               function CloseSpin() {
                   $('#spinner').toggle('slow');
               }

               $('#ContentPlaceHolder1_btn_upload').click(function () {

                   $('#spinner').toggle('slow');
                   Popups('POPUP_LCN_UPLOAD.aspx');
                   return false;
               });


               $('#ContentPlaceHolder1_btn_load0').click(function () {
                   parent.close_modal();

                   return false;
               });
               $('#ContentPlaceHolder1_btn_download').click(function () {
                   $('#spinner').fadeIn('slow');
                   Popups('POPUP_LCN_DOWNLOAD.aspx');
                   return false;
               });
               $('#ContentPlaceHolder1_btn_confirm').click(function () {
                   $('#spinner').fadeIn('slow');

               });
               function Popups(url) { // สำหรับทำ Div Popup
                   $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                   var i = $('#f1'); // ID ของ iframe   
                   i.attr("src", url); //  url ของ form ที่จะเปิด
               }


           });
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
  <div id="spinner" style=" background-color:transparent; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;display:none" />
                 <%--<asp:HyperLink ID="hl_reader" runat="server" Target="_blank" CssClass="btn-control" >
                 <input type="button" value="เปิดจาก acrobat reader"   class="btn-lg"   style="  Width:70%;" />
                       </asp:HyperLink>--%>
</div>
    <table style="width:100%;height:500px;">
        <tr>
            <td rowspan="2" style="width:70%; vertical-align:top;">

                <%--<uc1:UC_CONFIRM ID="UC_CONFIRM1" runat="server" />--%>
                <div style="vertical-align: top;">
                    <h2>
                        <asp:Label ID="lbl_head_type" runat="server" Text="-" style="font-family:'TH SarabunPSK';"></asp:Label>
                    </h2>
                    <br />
                    <uc2:UC_Head_Information ID="UC_Head_Information1" runat="server" />
                    <asp:Panel ID="Panel1" runat="server" style="display:none;">
                        <uc3:UC_GMP ID="UC_GMP1" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server" style="display:none;">
                        <uc4:UC_ISO ID="UC_ISO1" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="Panel3" runat="server" style="display:none;">
                        <uc5:UC_HACCP ID="UC_HACCP1" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="Panel4" runat="server" style="display:none;">
                        <uc6:UC_PIC ID="UC_PIC1" runat="server" />
                    </asp:Panel>
                    <asp:Panel ID="Panel5" runat="server" style="display:none;">
                        <uc7:UC_Other ID="UC_Other1" runat="server" />
                    </asp:Panel>
                </div>
            </td>
             <td style="padding-left:10%;height:50%;" class="auto-style1">

                 <table class="table" style="width:90%"> 
                     
                     <tr><td>สถานะ</td></tr>
                     
                     <tr><td>
                         <asp:DropDownList ID="ddl_status" runat="server" CssClass="input-sm" Width="80%">
                         </asp:DropDownList>
                         </td></tr>
                     <tr><td> <asp:Button ID="btn_confirm" runat="server" Text="บันทึก" CssClass="btn-lg"   Width="80%" OnClientClick="return confirm('คุณต้องการบันทึกข้อมูลหรือไม่');" /></td></tr>
                     <tr><td>  <asp:Button ID="btn_load" runat="server" Text="Download PDF" CssClass="btn-lg"   Width="80%" /></td></tr>
                     <tr><td>  <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg"   Width="80%" /></td></tr>

                 </table>
                 
             </td>
        </tr>
        <tr>
             <td style="padding-left:5px; vertical-align:top;">
                
                  
           
                 <uc1:UC_GRID_ATTACH ID="UC_GRID_ATTACH1" runat="server" />
                
                 <hr />

                   <asp:ScriptManager ID="ScriptManager1" runat="server">
                 </asp:ScriptManager>

                   <telerik:RadGrid ID="rg_company" runat="server" CellSpacing="0" GridLines="None" style="display:none;">

                       <MasterTableView autogeneratecolumns="False" datakeynames="IDA">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
      
                      <telerik:GridBoundColumn DataField="engfrgnnm"  FilterControlAltText="Filter engfrgnnm column" 
                          HeaderText="ชื่อบริษัท" SortExpression="engfrgnnm" UniqueName="engfrgnnm">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>

        <telerik:GridBoundColumn DataField="addr"  FilterControlAltText="Filter addr column" HeaderText="ที่อยู่" SortExpression="addr" UniqueName="addr">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        
                 <telerik:GridBoundColumn DataField="cntcd" FilterControlAltText="Filter cntcd column"
                      HeaderText="ประเทศ" SortExpression="cntcd" UniqueName="cntcd">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
      
        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
             HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column"
             HeaderText="FK_IDA" SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
            <ColumnValidationSettings>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
             HeaderText="TR_ID" SortExpression="TR_ID" UniqueName="TR_ID" Display="false">
            <ColumnValidationSettings>
              
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
     
    
      
            
                 <telerik:GridButtonColumn ButtonType="LinkButton"
                        CommandName="sel" Text="เลือกข้อมูล" Visible="false" UniqueName="DeleteColumn"> 
                        <HeaderStyle Width="100px" />
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
                 <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
           


                 <table class="table" style="width:100%;">
                    <tr>
                        <td style="width:40%;">
                            ชื่อบริษัท
                        </td>
                        <td>

                            <asp:Label ID="lbl_office" runat="server" Text="-"></asp:Label>

                        </td>
                    </tr>
                    <tr>
                        <td style="width:40%;">
                            ชื่อผู้ยื่น</td>
                        <td>

                            <asp:Label ID="lbl_person" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:40%;">
                            เบอร์โทรศัพท์</td>
                        <td>

                            <asp:Label ID="lbl_mobile" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:40%;">
                            เลขดำเนินการเก่า</td>
                        <td>

                            <asp:Label ID="lbl_old_tr_id" runat="server" Text="Label"></asp:Label>
                        </td>
                    </tr>
                </table>



             </td>
        </tr>
       
        </table>
</asp:Content>