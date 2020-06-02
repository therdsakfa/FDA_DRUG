<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_BSN_EDIT_ADDR.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_LCN_BSN_EDIT_ADDR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        แก้ไขชื่อ-ที่อยู่ผู้ดำเนินกิจการ
    </h2>
    <table class="table">
    <tr>
        <td align="right">เลขบัตรประชาชน</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_bsn_citizen" runat="server" CssClass="input-sm" Width="60%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">คำนำหน้าชื่อ</td>
        <td style="padding-left:1%;">
           <asp:DropDownList ID="ddl_prefix" runat="server" AutoPostBack="True" DataTextField ="thanm" DataValueField="prefixcd"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">ชื่อ</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_bsn_name" runat="server" CssClass="input-sm" Width="60%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">นามสกุล</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_bsn_lastname" runat="server" CssClass="input-sm" Width="60%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">รหัสประจำบ้าน</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_HOUSENO" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เลขที่</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ENGADDR" runat="server" CssClass="input-sm" Width="40%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">หมู่</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_MOO" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ซอย</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_SOI" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ถนน</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ROAD" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">จังหวัด</td>
        <td style="padding-left:1%;">
            <asp:DropDownList ID="ddl_Province" runat="server" AutoPostBack="True" DataTextField="thachngwtnm" DataValueField="chngwtcd"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">เขต/อำเภอ</td>
        <td style="padding-left:1%;">
            <asp:DropDownList ID="ddl_amphor" runat="server" AutoPostBack="True" DataTextField="thaamphrnm" DataValueField="amphrcd">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">แขวง/ตำบล</td>
        <td style="padding-left:1%;">
            <asp:DropDownList ID="ddl_tambol" runat="server" AutoPostBack="True" DataTextField="thathmblnm" DataValueField="thmblcd">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">รหัสไปรษณีย์</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ZIPCODE" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">โทรศัพท์</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_TELEPHONE" runat="server"  CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">โทรสาร</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_FAX" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เบอร์มือถือ</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_MOBILE" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2">
            <asp:Button ID="btn_edit" runat="server" Text="แก้ไข" CssClass="input-lg" />
        </td>
    </tr>
</table>
</asp:Content>
