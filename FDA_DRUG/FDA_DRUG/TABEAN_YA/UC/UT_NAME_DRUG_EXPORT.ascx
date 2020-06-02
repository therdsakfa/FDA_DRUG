<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UT_NAME_DRUG_EXPORT.ascx.vb" Inherits="FDA_DRUG.UT_NAME_DRUG_EXPORT" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
    

    <table class="table" style="width:100%;">
          <tr>
            <td>
                

<table style="width:100%;" class="table">
    <tr>
        <td align="right" Width="20%">
            ชื่อยาเพื่อการส่งออก&nbsp;
        </td>
        <td Width="20%">
            <asp:TextBox ID="TextBox1" runat="server" Width="100%"></asp:TextBox>
        </td>
        <td align="right" Width="20%">
            ประเทศ</td>
        <td Width="20%">
            <asp:DropDownList ID="DropDownList1" runat="server">
            </asp:DropDownList>
        </td>
        <td Width="20%">
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="input-lg" />
        </td>
    </tr>
    <tr>
        <td colspan="5">
            รายการผู้ผลิตที่เลือก</td>
    </tr>
    <tr>
        <td align="center" colspan="5">
                <telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="DRUG_NAME" FilterControlAltText="Filter DRUG_NAME column"
                           HeaderText="ชื่อยาเพื่อการส่งออก" SortExpression="DRUG_NAME" UniqueName="DRUG_NAME">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="engcntnm" FilterControlAltText="Filter engcntnm column"
                           HeaderText="ประเทศ" SortExpression="engcntnm" UniqueName="engcntnm">
                       </telerik:GridBoundColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_del" HeaderText="ลบรายการ"  ConfirmText="ต้องการลบหรือไม่?"
                            CommandName="_del" Text="ลบ">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                   </Columns>
               </MasterTableView>
           </telerik:RadGrid>
        </td>
    </tr>
</table>
    </table>