<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_TABLE_DRUG_GROUP_CHANGE.ascx.vb" Inherits="FDA_DRUG.UC_TABLE_DRUG_GROUP_CHANGE" %>

<asp:Panel ID="Panel1" runat="server">
<table class="table" style="width:100%;">
        <tr>
            <td align="center">
                <b>
                รายการหมวดยาแผนปัจจุบันที่ขออนุญาตผลิต</b>
            </td>
        </tr>
        <tr>
            <td>
                ประเภทของยาแผนปัจจุบัน
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:RadioButtonList ID="rdl_drug_type" runat="server" RepeatColumns="2" style="display:none;">
                    <asp:ListItem Value="1">ยาแผนปัจจุบันสำหรับมนุษย์</asp:ListItem>
                    <asp:ListItem Value="3">ยาแผนปัจจุบันสำหรับทำการวิจัยทางคลินิกในมนุษย์ ระยะที่ ๑,๒,๓</asp:ListItem>
                    <asp:ListItem Value="2">ยาแผนปัจจุบันสำหรับสัตว์</asp:ListItem>
                </asp:RadioButtonList>
                <asp:CheckBox ID="cb_drug_type1" runat="server" Text="ยาแผนปัจจุบันสำหรับมนุษย์" /> &nbsp
                <asp:CheckBox ID="cb_drug_type2" runat="server" Text="ยาแผนปัจจุบันสำหรับทำการวิจัยทางคลินิกในมนุษย์ ระยะที่ ๑,๒,๓" />&nbsp
                <asp:CheckBox ID="cb_drug_type3" runat="server" Text="ยาแผนปัจจุบันสำหรับสัตว์" />
            </td>
        </tr>
        <tr>
            <td align="center">
                <b>รายการหมวดยาที่ผลิต (แบ่งประเภทตามกระบวนการผลิต) : ให้ใส่เครื่องหมาย ในช่องที่เกี่ยวข้อง</b>
            </td>
        </tr>
    </table>

<asp:Table ID="Table1" runat="server" Width="100%" CssClass="table" CellSpacing="0" ></asp:Table>
</asp:Panel>