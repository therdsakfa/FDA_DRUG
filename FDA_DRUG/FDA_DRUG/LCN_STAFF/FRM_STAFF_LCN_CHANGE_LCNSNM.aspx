<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_CHANGE_LCNSNM.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_LCN_CHANGE_LCNSNM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" class="table">
        <tr>
            <td width="30%">ชื่อผู้รับอนุญาต (เดิม)</td>
            <td>
                <asp:Label ID="lbl_lcnsnm_old" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>เลขนิติฯ/เลขประจำตัวประชาชน (ใหม่)</td>
            <td>
                <asp:TextBox ID="txt_ctzid_lcn" runat="server"></asp:TextBox>
                <asp:Button ID="btn_search_lcn" runat="server" Text="ค้นหา" />
                <asp:HiddenField ID="hf_lcn" runat="server" /><br />
                <asp:Label ID="lbl_lcnname_new" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btn_lcn" runat="server" Text="เปลี่ยนผู้รับอนุญาต" CssClass="btn-lg" OnClientClick="return confirm('คุณต้องการเปลี่ยนผู้รับอนุญาตหรือไม่');"  />
            </td>
        </tr>
    </table>
</asp:Content>
