<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_ANIMAL_SUB.ascx.vb" Inherits="FDA_DRUG.UC_ANIMAL_SUB" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<table>
    <tr>
        <td>ส่วนบริโภค :&nbsp;</td>
        <td colspan="4">
            <asp:DropDownList ID="ddl_dramlpart" runat="server"></asp:DropDownList>
        </td>
 
    </tr>
    <tr>
        <td>ระยะหยุดยา :</td>
        <td>
            <asp:TextBox ID="txt_STOP_VALUE1" runat="server"></asp:TextBox>
        </td>
 
        <td>
            <asp:DropDownList ID="ddl_STOP_UNIT1" runat="server">
                <asp:ListItem Value="1">ชั่วโมง</asp:ListItem>
                <asp:ListItem Value="2">วัน</asp:ListItem>
            </asp:DropDownList> <%--&nbsp; ถึง --%>

        </td>
 
        <td>
           <%-- <asp:TextBox ID="txt_STOP_VALUE2" runat="server"></asp:TextBox>--%>
        </td>
 
        <td>
           <%-- <asp:DropDownList ID="ddl_STOP_UNIT2" runat="server">
                <asp:ListItem Value="1">ชั่วโมง</asp:ListItem>
                <asp:ListItem Value="2">วัน</asp:ListItem>
            </asp:DropDownList>--%>
        </td>
 
    </tr>
    <%--<tr>
        <td>
            ข้อห้ามใช้ :
        </td>
        <td colspan="4">
            <asp:TextBox ID="txt_nouse" runat="server"></asp:TextBox>
        </td>
    </tr>--%>
    <tr>
        <td>ขนาดและวิธีการใช้ :</td>
        <td colspan="4">
            <asp:TextBox ID="txt_packuse" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td>
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" />
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
<br />
<table width="100%">
    <tr>
        <td>
<telerik:RadGrid ID="rgAnimals" runat="server" Width="100%">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ampartnm" FilterControlAltText="Filter ampartnm column" HeaderText="ส่วนบริโภค"
                            SortExpression="ampartnm" UniqueName="ampartnm">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="stpdrg" FilterControlAltText="Filter stpdrg column"
                            HeaderText="ระยะหยุดยา" SortExpression="stpdrg" UniqueName="stpdrg">
                        </telerik:GridBoundColumn>
                        <%--<telerik:GridBoundColumn DataField="nouse" FilterControlAltText="Filter nouse column" HeaderText="ข้อห้ามใช้" SortExpression="nouse" UniqueName="nouse">
                        </telerik:GridBoundColumn>--%>
                        <telerik:GridBoundColumn DataField="packuse" FilterControlAltText="Filter packuse column" HeaderText="ขนาดและวิธีการใช้" SortExpression="packuse" UniqueName="packuse">
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
    <tr>
        <td align="center">
            <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" />
        </td>
    </tr>
</table>