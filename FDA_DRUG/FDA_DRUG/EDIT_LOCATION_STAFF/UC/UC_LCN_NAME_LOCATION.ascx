<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_NAME_LOCATION.ascx.vb" Inherits="FDA_DRUG.UC_LCN_NAME_LOCATION" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="ชื่อสถานที่">
<table width="75%">
    <tr>
        <td align="right">ชื่อสถานที่ (ภาษาไทย) จาก</td>
        <td align="right">&nbsp;<asp:Label ID="lb_tha_nameplace" runat="server"></asp:Label>&nbsp; เป็น &nbsp;

        </td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_tha_nameplace" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อสถานที่ (ภาษาอังกฤษ) จาก</td>
        <td align="right">&nbsp;<asp:Label ID="lb_eng_nameplace" runat="server"></asp:Label>&nbsp; เป็น &nbsp;

        </td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_eng_nameplace" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
        </td>
    </tr>
</table>
</asp:Panel>
