<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LABEL_DETAIL.ascx.vb" Inherits="FDA_DRUG.UC_LABEL_DETAIL" %>
<table width="800px">
    <tr>
        <td>ฉลาก</td>
        <td width="75%">
            <asp:TextBox ID="txt_label_detail" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td width="75%">
            <asp:Button ID="btn_insert" runat="server" Text="บันทึกข้อมูล" CssClass="input-lg"/>
        </td>
    </tr>
</table>