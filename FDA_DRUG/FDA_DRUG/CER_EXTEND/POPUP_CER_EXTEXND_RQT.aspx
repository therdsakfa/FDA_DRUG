<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_CER_EXTEXND_RQT.aspx.vb" Inherits="FDA_DRUG.POPUP_CER_EXTEXND_RQT" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        เลือก Cert ที่จะต่ออายุ
    </h2>
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
</asp:Content>
