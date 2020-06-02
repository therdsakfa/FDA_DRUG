<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DETAIL_USE.ascx.vb" Inherits="FDA_DRUG.UC_DETAIL_USE" %>
<table width="800px">
    <tr>
        <td>ข้อบ่งใช้</td>
        <td width="75%">
            <asp:TextBox ID="txt_dtl" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td width="75%">
            <asp:Button ID="btn_insert" runat="server" Text="บันทึกข้อมูล" CssClass="input-lg"/>
        </td>
    </tr>
</table>