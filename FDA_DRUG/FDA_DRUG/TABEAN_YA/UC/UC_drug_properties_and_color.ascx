<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_drug_properties_and_color.ascx.vb" Inherits="FDA_DRUG.UC_drug_properties_and_color" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<table>
    <tr>
        <td>
           ลักษณะและสีของยา : <asp:TextBox ID="txt_detail" runat="server" CssClass="input-lg" Width="300px"></asp:TextBox> <asp:Button ID="btn_add" runat="server" Text="บันทึกข้อมูล" CssClass="input-lg" />
        </td>
    </tr>
    <tr>
        <%--<td  bgcolor="Lavender" width="197px" height="28px">สารสำคัญ : </td>--%>
        <td>
            <telerik:RadGrid ID="rg_color" runat="server" Width="100%">
                <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                            SortExpression="IDA" UniqueName="IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="FK_IDA" DataType="System.Int32" FilterControlAltText="Filter FK_IDA column" HeaderText="FK_IDA"
                            SortExpression="FK_IDA" UniqueName="FK_IDA" Display="false">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="ROWS" FilterControlAltText="Filter ROWS column" HeaderText="ลำดับ"
                            SortExpression="ROWS" UniqueName="ROWS">
                        </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="DRUG_PROPERTIES_AND_DETAIL" FilterControlAltText="Filter DRUG_PROPERTIES_AND_DETAIL column"
                            HeaderText="ลักษณะและสีของยา" SortExpression="DRUG_PROPERTIES_AND_DETAIL" UniqueName="DRUG_PROPERTIES_AND_DETAIL">
                        </telerik:GridBoundColumn>
                        <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="edt" HeaderText="" Display="false"
                            CommandName="edt" Text="แก้ไข">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>--%>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_del" HeaderText="" CommandName="_del" Text="ลบข้อมูล" ConfirmText="คุณต้องการลบหรือไม่">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td>
    </tr>

    <%-- <tr>
        <td bgcolor="Lavender" width="197px" height="28px">สารย่อย : </td>
        <td  ><asp:Label ID="lb_NoReport_pop" runat="server"  Width="438px" Height="30px"></asp:Label></td>
    </tr>--%>
</table>