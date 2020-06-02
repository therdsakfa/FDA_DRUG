<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DS_PACKAGE.ascx.vb" Inherits="FDA_DRUG.UC_DS_PACKAGE" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<table width="100%">
    <tr>
        <td align="right" valign="top">
            บรรจุ
        </td>
        <td valign="top">
                        <asp:DropDownList ID="ddl_contain_unit" runat="server" Width="200px" CssClass="input-sm">
                        </asp:DropDownList>
        </td>

    </tr>
    <tr>
        <td align="right">
            <asp:Label ID="lbl_" runat="server" Text="-"></asp:Label>
        </td>
        <td>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="Txt_DOSAGE" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbl_md_unit" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
            </table>


        </td>

    </tr>
    <tr>
        <td align="right">บรรจุใน</td>
        <td>
            <asp:DropDownList ID="ddl_contain_unit2" runat="server" DataTextField="iowanm" DataValueField="IDA" Width="200px" CssClass="input-sm">
            </asp:DropDownList>


        &nbsp;ละ</td>

    </tr>
    <tr>
        <td align="right">&nbsp;</td>
        <td>
            <table>
                <tr>
                    <td>
                        <asp:TextBox ID="Txt_DOSAGE2" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="lbl_md_unit2" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
            </table>
        </td>

    </tr>
</table>
<table width="100%">
                                    <tr>
                                        <td align="right">
                                            <asp:Button ID="btn_add" runat="server" CssClass="btn-lg" Text="เพิ่มขนาดบรรจุ" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" Width="100%" AutoGenerateColumns="false">
                                                <MasterTableView>
                                                    <Columns>

                                                        <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="IDA" HeaderText="IDA" DataField="IDA" Display="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="FK_IDA" HeaderText="FK_IDA" DataField="FK_IDA" Display="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="iowanm" HeaderText="ตัวยาสำคัญ" DataField="iowanm">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="DOSAGE" HeaderText="ปริมาณ" DataField="DOSAGE">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="sunitengnm" HeaderText="หน่วย" DataField="sunitengnm">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del">
                                                        </telerik:GridButtonColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>

                                        </td>
                                    </tr>
                                    </table>