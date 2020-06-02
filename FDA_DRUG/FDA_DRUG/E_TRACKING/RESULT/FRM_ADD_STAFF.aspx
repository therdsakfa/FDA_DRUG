<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_ADD_STAFF.aspx.vb" Inherits="FDA_DRUG.FRM_ADD_STAFF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td width="30%">เลขบัตรปชช. เจ้าหน้าที่ผู้รับผิดชอบคำขอ</td>
            <td>
                <asp:TextBox ID="txt_staff_iden" runat="server" CssClass="input-sm" Width="50%"></asp:TextBox>
                <br />
                <asp:Button ID="btn_staff" runat="server" CssClass="btn-lg" Text="ตรวจสอบเจ้าหน้าที่" Width="30%" />
            </td>
        </tr>
        <tr>
            <td>ชื่อเจ้าหน้าที่ผู้รับผิดชอบคำขอ</td>
            <td>
                <asp:Label ID="lbl_staff" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btn_save" runat="server" CssClass="btn-lg" Text="บันทึก" Width="30%" />
            </td>
        </tr>
    </table>
</asp:Content>
