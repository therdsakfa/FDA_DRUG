<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_BSN_NAME.ascx.vb" Inherits="FDA_DRUG.UC_BSN_NAME" %>

<asp:Panel ID="Panel1" runat="server" GroupingText="ข้อมูลผู้ดำเนินกิจการ">
<table>
    <tr>
        <td align="right">เลขบัตรประชาชน/เลขPassport/เลขต่างด้าว</td>
        <td>จาก &nbsp;<asp:Label ID="lb_BSN_IDENTIFY" runat="server"></asp:Label> &nbsp; เป็น &nbsp;
            &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_IDENTIFY" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
        <td style="padding-left:1%;">
            <asp:Button ID="Button1" runat="server" Text="ดึงข้อมูล" />
        </td>
    </tr>
    <tr>
        <td align="right">คำนำหน้าชื่อ (ภาษาไทย)</td>
        <td>จาก &nbsp;<asp:Label ID="lb_prefix" runat="server"></asp:Label>
            &nbsp; เป็น</td>
        <td style="padding-left:1%;">
           <asp:DropDownList ID="ddl_prefix" runat="server" AutoPostBack="True" DataTextField ="thanm" DataValueField="prefixcd"></asp:DropDownList></td>
        <td style="padding-left:1%;">&nbsp;</td>
    </tr>
    <tr>
        <td align="right">คำนำหน้าชื่อ (ภาษาอังกฤษ)</td>
        <td >จาก &nbsp;<asp:Label ID="lb_engprefixnm" runat="server"></asp:Label>
            &nbsp; เป็น</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_engprefixnm" runat="server" Text="-"></asp:Label>
        </td>
        <td style="padding-left:1%;">&nbsp;</td>
    </tr>
    <tr>
        <td align="right">ชื่อผู้ดำเนินกิจการ (ภาษาไทย)</td>
        <td>จาก &nbsp;<asp:Label ID="lb_BSN_THAINAME" runat="server"></asp:Label>
            &nbsp; เป็น</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_THAINAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
        <td style="padding-left:1%;">&nbsp;</td>
    </tr>
    <tr>
        <td align="right">นามสกุลผู้ดำเนินกิจการ (ภาษาไทย)</td>
        <td>จาก &nbsp;<asp:Label ID="lb_BSN_THAILASTNAME" runat="server"></asp:Label>
            &nbsp; เป็น</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_THAILASTNAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
        <td style="padding-left:1%;">&nbsp;</td>
    </tr>
    <tr>
        <td align="right">ชื่อผู้ดำเนินกิจการ (ภาษาอังกฤษ)</td>
        <td>จาก &nbsp;<asp:Label ID="lb_BSN_ENGNAME" runat="server"></asp:Label>
            &nbsp; เป็น</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ENGNAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
        <td style="padding-left:1%;">&nbsp;</td>
    </tr>
    <tr>
        <td align="right">นามสกุลผู้ดำเนินกิจการ (ภาษาอังกฤษ)</td>
        <td>จาก &nbsp;<asp:Label ID="lb_BSN_ENGLASTNAME" runat="server"></asp:Label>
            &nbsp; เป็น</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ENGLASTNAME" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
        <td style="padding-left:1%;">&nbsp;</td>
    </tr>
   
</table>
</asp:Panel>
