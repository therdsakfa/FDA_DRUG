<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_PHR_HISTORY.aspx.vb" Inherits="FDA_DRUG.POPUP_PHR_HISTORY" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h2> ประวัติการทำงานของเภสัชกร<telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                </telerik:RadScriptManager>
            </h2>

        </div>
    <table width="100%">
           <tr>
               <td align="right">&nbsp;</td>
           </tr>
           <tr>
               <td>
                   <telerik:RadGrid ID="RadGrid2" runat="server">
                       <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                           <Columns>
                               <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                   HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="FK_PHR_IDA" FilterControlAltText="Filter FK_PHR_IDA column"
                                   HeaderText="FK_PHR_IDA" SortExpression="FK_PHR_IDA" UniqueName="FK_PHR_IDA" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="OLD_PHR_NAME" FilterControlAltText="Filter OLD_PHR_NAME column"
                                   HeaderText="ชื่อเภสัชกร" SortExpression="OLD_PHR_NAME" UniqueName="OLD_PHR_NAME">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="stat" FilterControlAltText="Filter stat column"
                                   HeaderText="สถานะ" SortExpression="stat" UniqueName="stat">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="ACTIVE_DATE" FilterControlAltText="Filter ACTIVE_DATE column"
                                   HeaderText="วันที่" SortExpression="ACTIVE_DATE" UniqueName="ACTIVE_DATE" DataFormatString="{0:dd/MM/yyyy}">
                               </telerik:GridBoundColumn>

                           </Columns>
                       </MasterTableView>
                   </telerik:RadGrid>
              
               </td>
           </tr>
       </table>
</asp:Content>
