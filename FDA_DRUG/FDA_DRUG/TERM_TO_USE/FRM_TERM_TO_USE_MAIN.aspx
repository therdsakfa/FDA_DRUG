<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_TERM_TO_USE_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_TERM_TO_USE_MAIN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">

        <div class="panel-heading panel-title">
                <h1>ข้อบ่งใช้</h1>
            </div>
    <table style="width:100%;" class="table">
        <tr>
            <td align="right">
                เลขทะบียน : 
            </td>
            <td>
                <asp:TextBox ID="txt_rgtno" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
            <td align="right">
                : 
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td align="right">
                ข้อบ่งใช้ :</td>
            <td colspan="3">
                <asp:TextBox ID="txt_term" runat="server" CssClass="input-sm" Width="100%" TextMode="MultiLine" Height="400px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" colspan="4">
                <asp:Button ID="btn_add" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-lg" Width="120px" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">

  <telerik:RadGrid ID="RadGrid1" runat="server" style="margin-left: 0px" AllowPaging="true" PageSize="10">

<MasterTableView autogeneratecolumns="False" datakeynames="IDA">
<CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

<RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
<HeaderStyle Width="20px"></HeaderStyle>
</RowIndicatorColumn>

<ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
<HeaderStyle Width="20px"></HeaderStyle>
</ExpandCollapseColumn>

    <Columns>
          <telerik:GridBoundColumn DataField="RGTNO" FilterControlAltText="Filter RGTNO column"
                      HeaderText="เลขทะเบียน" SortExpression="RGTNO" UniqueName="RGTNO">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TERM_TO_USE" FilterControlAltText="Filter TERM_TO_USE column"
                      HeaderText="ข้อบ่งใช้" SortExpression="TERM_TO_USE" UniqueName="TERM_TO_USE">
        </telerik:GridBoundColumn>
        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="del"
                        CommandName="del" Text="ลบข้อมูล" >
                        
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
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">

                

            </td>
        </tr>
    </table>

        </div>
</asp:Content>