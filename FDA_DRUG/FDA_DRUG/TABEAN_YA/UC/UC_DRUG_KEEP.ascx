<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DRUG_KEEP.ascx.vb" Inherits="FDA_DRUG.UC_DRUG_KEEP" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">
    .auto-style1 {
        width: 33px;
    }
</style>
<table class="table">
    <tr>
        <td>
            อายุการใช้งาน :</td>
        <td width="25%">
            <asp:TextBox ID="txt_AGE_MONTH" runat="server"></asp:TextBox>
            เดือน</td>
        <td class="auto-style1">
            &nbsp;</td>
        <td>
            <asp:TextBox ID="txt_AGE_DAY" runat="server"></asp:TextBox>
            วัน</td>
        <td>
            &nbsp;</td>
        <td>
            <asp:TextBox ID="txt_AGE_HOUR" runat="server"> </asp:TextBox>ชั่วโมง
        </td>
        <td>
            &nbsp;</td>
        
    </tr>
    <tr>
        <td>
            ช่วงอุณหภูมิการเก็บรักษา ระหว่าง</td>
        <td>
            <asp:TextBox ID="txt_TEMPERATE1" runat="server"></asp:TextBox>
        &nbsp;องศาเซลเซียส</td>
        <td class="auto-style1">
            ถึง</td>
        <td>
            <asp:TextBox ID="txt_TEMPERATE2" runat="server"></asp:TextBox>&nbsp;องศาเซลเซียส
        </td>
        <td></td> <td></td><td></td>
    </tr>
    <tr>
        <td>
            สภาวะการเก็บรักษา :</td>
        <td colspan="6">
            <asp:TextBox ID="txt_KEEP_DESCRIPTION" runat="server" TextMode="MultiLine" Width="70%" Height="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            ลักษณะยา :</td>
        <td colspan="6">
            <asp:TextBox ID="txt_DRUG_DETAIL" runat="server" TextMode="MultiLine" Width="70%" Height="100px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="7" align="center">
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" />
        </td>
    </tr>
    <tr>
        <td colspan="7">
           <telerik:RadGrid ID="rg_keep" runat="server" Width="80%">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="age_detail" FilterControlAltText="Filter age_detail column"
                            HeaderText="อายุการใช้งาน" SortExpression="age_detail" UniqueName="age_detail">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="KEEP_DESCRIPTION" FilterControlAltText="Filter KEEP_DESCRIPTION column"
                            HeaderText="สภาวะเก็บรักษา" SortExpression="KEEP_DESCRIPTION" UniqueName="KEEP_DESCRIPTION">
                        </telerik:GridBoundColumn>
                        <%--<telerik:GridBoundColumn DataField="DRUG_DETAIL" FilterControlAltText="Filter DRUG_DETAIL column" HeaderText="ลักษณะยา" SortExpression="DRUG_DETAIL" UniqueName="DRUG_DETAIL">
                        </telerik:GridBoundColumn>--%>
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