<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_SUB_DRUG_ANIMAL.ascx.vb" Inherits="FDA_DRUG.UC_SUB_DRUG_ANIMAL" %>
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
            <asp:Label ID="lbl_sunit_ida" runat="server" AutoPostBack="True" DataTextField="lbl_sunit_ida" DataValueField="lbl_sunit_ida" Visible="False"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td colspan="4">
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" />
            <asp:Button ID="btn_edit" runat="server" Text="แก้ไข" />
            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิกแก้ไข" />
        </td>
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
                        <telerik:GridButtonColumn UniqueName="edt" ButtonType="LinkButton" Text="แก้ไขข้อมูล" CommandName="edt">
                            </telerik:GridButtonColumn>
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