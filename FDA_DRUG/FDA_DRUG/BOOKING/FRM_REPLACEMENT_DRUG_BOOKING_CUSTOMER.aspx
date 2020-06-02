<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF_DRUG_POPUP.Master" CodeBehind="FRM_REPLACEMENT_DRUG_BOOKING_CUSTOMER.aspx.vb" Inherits="FDA_DRUG.FRM_REPLACEMENT_DRUG_BOOKING_CUSTOMER" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table" style="width:100%;">
        <tr>
            <td style="width:25%;"></td>
            <td style="width:25%;">ชื่อผู้ประกอบการ</td>
            <td style="width:25%;">
                <asp:TextBox ID="txt_SEARCH" runat="server" CssClass="input-lg"></asp:TextBox>
            </td>
            <td style="width:25%;"></td>
        </tr>
        <tr>
            <td style="width:25%;"></td>
            <td style="width:25%;">เลขนิติบุคคล/เลขบัตรประชาชน</td>
            <td style="width:25%;">
                <asp:TextBox ID="txt_NUM" runat="server" CssClass="input-lg"></asp:TextBox>
            </td>
            <td style="width:25%;"></td>
        </tr>
      
        <tr>
            <td colspan="4" style="text-align:center;">
                <asp:Button ID="btn_SEARCH" runat="server" CssClass="input-lg" Text="ค้นหา" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <p class="h3">
                    ชื่อผู้ประกอบการ</p>
                <hr />
               
              <telerik:RadGrid ID="rg_name" runat="server">
<MasterTableView autogeneratecolumns="False" datakeynames="ID">
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
                  
         <telerik:GridBoundColumn DataField="fullname2" FilterControlAltText="Filter fullname2 column" HeaderText="ชื่อผู้ประกอบการ" ReadOnly="True" SortExpression="fullname2" UniqueName="fullname2">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
               


        <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" FilterControlAltText="Filter ID column"
             HeaderText="ID" ReadOnly="True" SortExpression="ID" UniqueName="ID" Display="false">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>
     
        <telerik:GridBoundColumn DataField="IDENTIFY" FilterControlAltText="Filter IDENTIFY column" 
            HeaderText="IDENTIFY" SortExpression="IDENTIFY" UniqueName="IDENTIFY" Display="true">
            <ColumnValidationSettings>
                <%--<ModelErrorMessage Text="" />--%>
            </ColumnValidationSettings>
        </telerik:GridBoundColumn>

 
              
        <telerik:GridTemplateColumn>
            <ItemTemplate>
                <asp:Button ID="btn_SELECT" runat="server" Text="เลือกข้อมูล" CommandName="sel" />
                <%--<asp:HyperLink ID="HL_SELECT"  runat="server">เลือกข้อมูล</asp:HyperLink>--%>
            </ItemTemplate>
        </telerik:GridTemplateColumn>
            
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

           
    </table>
</asp:Content>
