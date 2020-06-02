<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_No_Use.ascx.vb" Inherits="FDA_DRUG.UC_No_Use" %>
<table width="100%">
    <tr>
        <td width="20%">
            ข้อห้ามใช้
        </td>
        <td>
            <asp:TextBox ID="txt_no_use" runat="server" TextMode="MultiLine" Width="80%" Height="200px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td width="20%">
            &nbsp;</td>
        <td>
            <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อห้ามใช้" />
        </td>
    </tr>
</table>