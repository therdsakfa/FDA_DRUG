<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_SELL_TYPE.aspx.vb" Inherits="FDA_DRUG.POPUP_LCN_SELL_TYPE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table >
        <tr>
            <td align="right">
                ประเภทขายส่ง :
            </td>
            <td>
                <asp:CheckBoxList ID="cb_sell" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="13">ขายส่งยาสำเร็จรูป</asp:ListItem>
                    <asp:ListItem Value="12">ขายส่งเภสัชเคมีภัณฑ์</asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg"/>
            </td>
        </tr>
    </table>
</asp:Content>
