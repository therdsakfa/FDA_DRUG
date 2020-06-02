<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LOCATION_ADDRESS_TEL.ascx.vb" Inherits="FDA_DRUG.UC_LOCATION_ADDRESS_TEL" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="เบอร์โทรศัพท์ของที่ตั้ง">
    <table width="75%">
    <tr>
        <td align="right">เบอร์โทรศัพท์ จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_tel" runat="server"></asp:Label> &nbsp; เป็น &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_tel" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
</table>
</asp:Panel>