<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_PHR_CENCAL_SELF.ascx.vb" Inherits="FDA_DRUG.UC_PHR_CENCAL_SELF" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table class="table">
    <tr>
        <td align="right">เจ้าหน้าที่ :</td>
        <td>
            <asp:Label ID="lbl_staff_name" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">เลขใบประกอบโรคศิลป์:</td>
        <td>
            <asp:TextBox ID="txt_PHR_TXT_NUM" runat="server" Width="200px" CssClass="input-sm"></asp:TextBox>
            <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
        </td>
    </tr>
    <tr>
        <td align="right">เลขที่บัตรประชาชน :</td>
        <td>
            <asp:TextBox ID="txt_PHR_CTZNO" runat="server" Width="200px" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อผู้มีหน้าที่ปฏิบัติการ :</td>
        <td>
            <asp:TextBox ID="txt_PHR_NAME" runat="server" Width="200px" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td align="right">เลขที่รับ :</td>
        <td>
            <asp:Label ID="lbl_rcvno" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">วันที่รับ :</td>
        <td>
            <asp:TextBox ID="txt_rcvdate" runat="server" Width="200px" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ผลพิจารณา :</td>
        <td>
            <asp:DropDownList ID="ddl_result" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">สาเหตุ :</td>
        <td>
            <asp:DropDownList ID="ddl_purpose" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">วันที่พิจารณา :</td>
        <td>
            <asp:TextBox ID="txt_appdate" runat="server" Width="200px" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    </table>
<br />

<table class="table" width="100%">
    <tr>
        <td>
            <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" AllowMultiRowSelection="true">
                <MasterTableView>
                    <Columns>
                        <telerik:GridTemplateColumn DataField="chk" UniqueName="chk" HeaderText="เลือก">
                            <ItemTemplate>
                                <asp:CheckBox ID="cb_chk" runat="server" />
                            </ItemTemplate>
                        </telerik:GridTemplateColumn>
                        <telerik:GridBoundColumn DataField="IDA" UniqueName="IDA"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="LCNNO_MANUAL" HeaderText="เลขอนุญาต" DataField="LCNNO_MANUAL"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="thanameplace" HeaderText="ชื่อสถานที่" DataField="thanameplace"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="fulladdr" HeaderText="ที่อยู่" DataField="fulladdr"></telerik:GridBoundColumn>
                    </Columns>
                </MasterTableView>
                <ClientSettings EnableRowHoverStyle="true">
                    <Selecting AllowRowSelect="true" />
                </ClientSettings>
            </telerik:RadGrid>
        </td>
    </tr>
</table>
<p>
            <asp:Button ID="btn_save" runat="server" Text="บันทึกรายการที่เลือก" />
            </p>
<br />

รายการเลขรับที่ยกเลิก
<table class="table" width="100%">
    <tr>
        <td>
            <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="false" AllowMultiRowSelection="true">
                <MasterTableView>
                    <Columns>
                        <telerik:GridBoundColumn DataField="IDA" UniqueName="IDA"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="RCVNO_MANUAL" HeaderText="เลขรับ" DataField="RCVNO_MANUAL"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="rcvdate" HeaderText="วันที่รับ" DataField="rcvdate"></telerik:GridBoundColumn>
                        <telerik:GridBoundColumn UniqueName="PHR_FULL_NAME" HeaderText="ชื่อ" DataField="PHR_FULL_NAME"></telerik:GridBoundColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_edit" HeaderText="" ItemStyle-Width="15%"
                            CommandName="_list" Text="รายการใบอนุญาตที่ถูกยกเลิก">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                    </Columns>
                </MasterTableView>
            </telerik:RadGrid>
        </td>
    </tr>
</table>