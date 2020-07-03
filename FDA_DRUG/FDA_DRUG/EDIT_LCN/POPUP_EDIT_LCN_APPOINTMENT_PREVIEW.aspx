<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_EDIT_LCN_APPOINTMENT_PREVIEW.aspx.vb" Inherits="FDA_DRUG.POPUP_EDIT_LCN_APPOINTMENT_PREVIEW" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td width="20%">
                เลขใบอนุญาต 
            </td>
            <td>
                <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                ชื่อสถานที่ตั้ง</td>
            <td>
                <asp:Label ID="lbl_nameplace" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                ชื่อเภสัช</td>
            <td>
                <asp:Label ID="lbl_phesajname" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                ใบเสร็จ</td>
            <td>
                <asp:Label ID="lbl_receipt" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                ใบสั่ง</td>
            <td>
                <asp:Label ID="lbl_bill" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                เลขนิติบริษัท</td>
            <td>
                <asp:Label ID="lbl_identify" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                เลขนิติผู้รับอนุญาต</td>
            <td>
                <asp:Label ID="lbl_bsn" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                วันที่มายื่น</td>
            <td>
                <asp:Label ID="lbl_request_date" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
