<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_CER_EXP_INSERT_AND_UPDATE.aspx.vb" Inherits="FDA_DRUG.FRM_CER_EXP_INSERT_AND_UPDATE" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel" style="width:100%">
         <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
          <div class="panel-heading panel-title">
                <h1>คำขอต่ออายุ Cer<asp:Panel ID="Panel1" runat="server" GroupingText="เลือก Cert ที่จะต่ออายุ (กรุณาตรวจสอบความถูกต้องด้วย)">
             <table width="80%">
                 <tr>
                     <td>
                           <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false">
                               <MasterTableView>
                                   <Columns>
                                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                           SortExpression="IDA" UniqueName="IDA" Display="false">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="CER_NUMBER" FilterControlAltText="Filter CER_NUMBER column"
                                           HeaderText="เลขในระบบ" SortExpression="CER_NUMBER" UniqueName="CER_NUMBER">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="CERTIFICATION_NUMBER_ALL" FilterControlAltText="Filter CERTIFICATION_NUMBER_ALL column"
                                           HeaderText="เลขที่ใบรับรอง" SortExpression="CERTIFICATION_NUMBER_ALL" UniqueName="CERTIFICATION_NUMBER_ALL">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="EXP_DATE_EXTEND" FilterControlAltText="Filter EXP_DATE_EXTEND column"
                                           HeaderText="ใช้ได้ถึง" SortExpression="EXP_DATE_EXTEND" UniqueName="EXP_DATE_EXTEND" DataFormatString="{0:dd/MM/yyyy}">
                                       </telerik:GridBoundColumn>
                                   </Columns>
                               </MasterTableView>
                              <ClientSettings EnableRowHoverStyle="true">
                           <Selecting AllowRowSelect="true" />
                       </ClientSettings>
                         </telerik:RadGrid>
                     </td>
                     <td align="center">
                         <asp:Button ID="btn_right" runat="server" Text=">>" />
                     </td>
                     <td>

                         <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="false">
                             <MasterTableView>
                                   <Columns>
                                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                           SortExpression="IDA" UniqueName="IDA" Display="false">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="CER_NUMBER" FilterControlAltText="Filter CER_NUMBER column"
                                           HeaderText="เลขในระบบ" SortExpression="CER_NUMBER" UniqueName="CER_NUMBER">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="CERTIFICATION_NUMBER_ALL" FilterControlAltText="Filter CERTIFICATION_NUMBER_ALL column"
                                           HeaderText="เลขที่ใบรับรอง" SortExpression="CERTIFICATION_NUMBER_ALL" UniqueName="CERTIFICATION_NUMBER_ALL">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="EXP_DATE_EXTEND" FilterControlAltText="Filter EXP_DATE_EXTEND column"
                                           HeaderText="ใช้ได้ถึง" SortExpression="EXP_DATE_EXTEND" UniqueName="EXP_DATE_EXTEND" DataFormatString="{0:dd/MM/yyyy}">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridButtonColumn ButtonType="LinkButton" Text="ลบ" ConfirmText="คุณต้องการลบข้อมูล?" UniqueName="btn_del" CommandName="del">
                                       </telerik:GridButtonColumn>
                                   </Columns>
                               </MasterTableView>
                         </telerik:RadGrid>

                     </td>
                 </tr>
             </table>
         </asp:Panel>

                </h1>
            </div>
         <h2>
             เลือกสาร
         </h2>
         <asp:Panel ID="Panel2" runat="server">
             <telerik:RadGrid ID="RadGrid3" runat="server" AutoGenerateColumns="false">
                             <MasterTableView>
                                   <Columns>
                                      <telerik:GridCheckBoxColumn UniqueName="chk">

                                </telerik:GridCheckBoxColumn>
                                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                           SortExpression="IDA" UniqueName="IDA" Display="false">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="IS_USE" DataType="System.Int32" FilterControlAltText="Filter IS_USE column" HeaderText="IS_USE"
                                           SortExpression="IS_USE" UniqueName="IS_USE" Display="false">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="CER_NUMBER" FilterControlAltText="Filter CER_NUMBER column"
                                           HeaderText="เลขในระบบ" SortExpression="CER_NUMBER" UniqueName="CER_NUMBER">
                                       </telerik:GridBoundColumn>
                                       <telerik:GridBoundColumn DataField="CAS_NAME" FilterControlAltText="Filter CAS_NAME column"
                                           HeaderText="ชื่อสาร" SortExpression="CAS_NAME" UniqueName="CAS_NAME">
                                       </telerik:GridBoundColumn>
                                      <%-- <telerik:GridBoundColumn DataField="EXP_DATE_EXTEND" FilterControlAltText="Filter EXP_DATE_EXTEND column"
                                           HeaderText="ใช้ได้ถึง" SortExpression="EXP_DATE_EXTEND" UniqueName="EXP_DATE_EXTEND" DataFormatString="{0:dd/MM/yyyy}">
                                       </telerik:GridBoundColumn>--%>
                                       <%--<telerik:GridButtonColumn ButtonType="LinkButton" Text="ลบ" ConfirmText="คุณต้องการลบข้อมูล?" UniqueName="btn_del" CommandName="del">
                                       </telerik:GridButtonColumn>--%>
                                   </Columns>
                               </MasterTableView>
                  <ClientSettings EnableRowHoverStyle="true">
                    <Selecting AllowRowSelect="true" />
                </ClientSettings>
                         </telerik:RadGrid>

             
             <asp:Button ID="btn_save_case" runat="server" Text="บันทึกสารที่เลือก" CssClass="btn-lg" />
         </asp:Panel>
    <table class="table" width="100%">
        <tr>
            <td align="right">
                เลขที่ใบรับรอง (Certificate Number) :</td>
            <td>
               <asp:TextBox ID="txt_Cernumber" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                วันที่ cer :</td>
            <td>
               <asp:TextBox ID="txt_cer_DATE" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                วันที่หมดอายุ :</td>
            <td>
               <asp:TextBox ID="txt_cer_exp_date" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="right">
                ปีที่ต่ออายุ :&nbsp;</td>
            <td>
               <asp:TextBox ID="txt_Year_extend" runat="server" CssClass="input-sm" Width="200px" Enabled="false"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="right">
                แนบไฟล์ Cert</td>
            <td>
               <table style="width:100%;">
                                    <tr>
                                        <td colspan="2"><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                                       
                                    </tr>
                                    <tr>
                                        <td>
                                            <%--<asp:LinkButton ID="hp_file_name" runat="server" style="display:none;" />--%>
                                            <asp:HyperLink ID="hp_file_name" runat="server" style="display:none;" Target="_blank"></asp:HyperLink>
                                        </td>
                                      
                                        <td><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/file_delete.png" Width="28px" Height="28px"
                                                 ToolTip="ลบข้อมูล" style="display:none;" OnClientClick="return confirm('ต้องการลบหรือไม่');" />
                                        </td>
                                      
                                    </tr>
                                </table>
            </td>
        </tr>

        <tr>
            <td colspan="2">
              <div style="text-align: center;">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" /></td>
                                        <td>
                                            <asp:Button ID="btn_edit" runat="server" Text="แก้ไข" CssClass="btn-lg" /></td>
                                        <td>
                                            <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" /></td>
                                    </tr>
                                </table>
                            </div>
            </td>
        </tr>
 
        </table>

         
   <%-- <div class="panel-footer " style="text-align:center;">
        <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" />
        </div>

       </div>  --%>
</asp:Content>