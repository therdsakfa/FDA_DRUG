<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_SELECT_LOCATION_KEEP.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_LCN_SELECT_LOCATION_KEEP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <asp:Label ID="lbl_head" runat="server" Text="เลือกสถานที่เก็บ"></asp:Label>    
    </h2>
    <table width="100%" class="table">
        <tr>
            <td>ชื่อสถานที่เก็บ
                <asp:Label ID="lbl_name" runat="server" Text="-"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_placename" runat="server" Width="300px" AutoPostBack="True">
                </asp:DropDownList>
                <asp:HiddenField ID="hf_place" runat="server" />
            </td>
        </tr>
        <tr>
            <td>ที่ตั้ง (ใหม่)</td>
            <td>
                <asp:Label ID="lbl_location_new" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:Button ID="btn_save" runat="server" Text="เลือกข้อมูล" CssClass="btn-lg" OnClientClick="return confirm('คุณต้องการเลือกสถานที่เก็บนี้หรือไม่');" />
            </td>
        </tr>
    </table>
</asp:Content>
