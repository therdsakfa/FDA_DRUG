<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_OPENTIME.ascx.vb" Inherits="FDA_DRUG.UC_LCN_OPENTIME" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="เวลาทำการ">
<table width="75%">
    <tr>
        <td align="right">เวลาทำการรวม จาก</td>
        <td align="right">&nbsp;<asp:Label ID="lb_OPEN_TIME" runat="server"></asp:Label>&nbsp; เป็น &nbsp;

        </td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_OPEN_TIME" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
        </td>
    </tr>
   
</table>
</asp:Panel>