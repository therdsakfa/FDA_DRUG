<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_REGISTRATION_INSERT.aspx.vb" Inherits="FDA_DRUG.POPUP_REGISTRATION_INSERT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td align="center">
                <h2>
                    สร้างตำรับ<br />
                    <%--(Drug Registration Listing)--%>
                </h2>
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr>
            <td>
                1.1 ชื่อการค้า (ภาษาไทย)
            </td>
            <td>
                <asp:TextBox ID="txt_DRUG_NAME_THAI" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                ชื่อการค้า (ภาษาอังกฤษ)</td>
            <td>
                <asp:TextBox ID="txt_DRUG_NAME_OTHER" runat="server" Width="300px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                2. คำบรรยายลักษณะของยา</td>
            <td>
                <asp:TextBox ID="txt_DRUG_COLOR" runat="server" TextMode="MultiLine" Width="400px" Height="100px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" />
                <asp:Button ID="btn_back" runat="server" Text="ปิดหน้าต่าง" />
            </td>
        </tr>
    </table>
</asp:Content>
