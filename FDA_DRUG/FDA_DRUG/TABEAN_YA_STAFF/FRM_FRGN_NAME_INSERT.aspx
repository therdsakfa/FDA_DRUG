<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_FRGN_NAME_INSERT.aspx.vb" Inherits="FDA_DRUG.FRM_FRGN_NAME_INSERT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:Label ID="lbl_head" runat="server" Text="เพิ่มชื่อผู้ผลิตต่างประเทศ"></asp:Label>
    </h1>
    <table class="table">
        <tr>
            <td>
                ชื่อผู้ผลิตต่างประเทศ (ภาษาอังกฤษ)</td>
            <td>
                <asp:TextBox ID="txt_engfrgnnm" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                ชื่อผู้ผลิตต่างประเทศ (ภาษาไทย)</td>
            <td>
                <asp:TextBox ID="txt_thafrgnnm" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" />
            </td>
        </tr>
    </table>
</asp:Content>
