<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCNS_NAME.ascx.vb" Inherits="FDA_DRUG.UC_LCNS_NAME" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="ข้อมูลผู้รับอนุญาต">
<table>
    <tr>
        <td align="right">คำนำหน้าชื่อ</td>
        <td>จาก &nbsp;<asp:Label ID="lb_prefix" runat="server"></asp:Label>
            &nbsp; เป็น</td>
        <td style="padding-left:1%;">
           <asp:DropDownList ID="ddl_prefix" runat="server" AutoPostBack="True" DataTextField ="thanm" DataValueField="prefixcd"></asp:DropDownList></td>
    </tr>
    <tr>
        <td align="right">ชื่อผู้รับอนุญาต</td>
        <td>จาก &nbsp;<asp:Label ID="lb_BSN_THAINAME" runat="server"></asp:Label>
            &nbsp; เป็น</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_THAINAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">นามสกุลผู้รับอนุญาต</td>
        <td>จาก &nbsp;<asp:Label ID="lb_BSN_THAILASTNAME" runat="server"></asp:Label>
            &nbsp; เป็น</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_THAILASTNAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
   
</table>
</asp:Panel>