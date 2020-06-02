<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Packing_Size.ascx.vb" Inherits="FDA_DRUG.UC_Packing_Size" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<table>
    <tr>
        <td>
            ขนาดบรรจุ
        </td>
        <td>
            <asp:TextBox ID="txt_SMALL_AMOUNT" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:DropDownList ID="ddl_small_unit" runat="server"></asp:DropDownList>/
        </td>
        <td>
            <asp:DropDownList ID="ddl_medium_unit" runat="server"></asp:DropDownList>
        </td>
        <td>
            Barcode
        </td>
        <td>
            <asp:TextBox ID="txt_BARCODE" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btn_add" runat="server" Text="เพิ่มขนาดบรรจุ" />
        </td>
    </tr>
    <tr>
        <td colspan="7">
           <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="false">
                        <MasterTableView>
                            <Columns>

                                <telerik:GridBoundColumn UniqueName="IDA" HeaderText="IDA" DataField="IDA" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="order_id" HeaderText="ลำดับ" DataField="order_id">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="SMALL_AMOUNT" HeaderText="จำนวน" DataField="SMALL_AMOUNT">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="unit_name" HeaderText="หน่วย" DataField="unit_name">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="x" HeaderText="ต่อ" DataField="x">
                                </telerik:GridBoundColumn>
                                <%--<telerik:GridBoundColumn UniqueName="MEDIUM_AMOUNT" HeaderText="จำนวน" DataField="MEDIUM_AMOUNT">
                                </telerik:GridBoundColumn>--%>
                                <telerik:GridBoundColumn UniqueName="sunitengnm" HeaderText="หน่วย" DataField="sunitengnm">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="BARCODE" HeaderText="หมายเลขบาร์โค้ด" DataField="BARCODE">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>

        </td>
    </tr>
</table>