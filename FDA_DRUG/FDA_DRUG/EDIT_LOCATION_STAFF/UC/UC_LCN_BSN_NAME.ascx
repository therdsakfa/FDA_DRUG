<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_BSN_NAME.ascx.vb" Inherits="FDA_DRUG.UC_LCN_BSN_NAME" %>
<asp:Panel ID="Panel1" runat="server" GroupingText="ข้อมูลผู้ดำเนินกิจการ">
<table>
    <tr>
        <td align="right">เลขบัตรประชาชน/เลขPassport/เลขต่างด้าว</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_IDENTIFY" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">คำนำหน้าชื่อ (ภาษาไทย)</td>
        <td style="padding-left:1%;">
           <asp:DropDownList ID="ddl_prefix" runat="server" AutoPostBack="True" DataTextField ="thanm" DataValueField="prefixcd"></asp:DropDownList></td>
    </tr>
    <tr>
        <td align="right">คำนำหน้าชื่อ (ภาษาอังกฤษ)</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_engprefixnm" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อผู้ดำเนินกิจการ (ภาษาไทย)</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_THAINAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">นามสกุลผู้ดำเนินกิจการ (ภาษาไทย)</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_THAILASTNAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อผู้ดำเนินกิจการ (ภาษาอังกฤษ)</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ENGNAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">นามสกุลผู้ดำเนินกิจการ (ภาษาอังกฤษ)</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ENGLASTNAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
   
</table>
</asp:Panel>
