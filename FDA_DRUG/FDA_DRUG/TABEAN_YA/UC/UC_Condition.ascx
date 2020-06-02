<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Condition.ascx.vb" Inherits="FDA_DRUG.UC_Condition" %>
<table width="800px">
    <tr>
        <td>เงื่อนไขทั่วไป</td>
        <td width="75%">
            <asp:TextBox ID="txt_con1" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td>เงื่อนไขสำหรับพนักงานเจ้าหน้าที่ </td>
        <td width="75%">
            <asp:TextBox ID="txt_con2" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td width="75%">
            <asp:Button ID="btn_insert" runat="server" Text="บันทึกข้อมูล" CssClass="input-lg" Height="26px"/>
        </td>
    </tr>
</table>