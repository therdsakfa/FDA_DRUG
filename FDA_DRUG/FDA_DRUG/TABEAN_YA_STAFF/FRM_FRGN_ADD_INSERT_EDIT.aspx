<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_FRGN_ADD_INSERT_EDIT.aspx.vb" Inherits="FDA_DRUG.FRM_FRGN_ADD_INSERT_EDIT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <h1>
        <asp:Label ID="lbl_head" runat="server" Text=""></asp:Label>
    </h1>
    <table class="table">
        <tr>
            <td>
                ชื่อผู้ผลิตต่างประเทศ</td>
            <td>
                <asp:Label ID="lbl_frgn_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                Address
            </td>
            <td>
                <asp:TextBox ID="txt_addr" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                soi</td>
            <td>
                <asp:TextBox ID="txt_soi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                road</td>
            <td>
                <asp:TextBox ID="txt_road" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                mu</td>
            <td>
                <asp:TextBox ID="txt_mu" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                District</td>
            <td>
                <asp:TextBox ID="txt_district" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                SUBDIVISION OF A PROVINCE</td>
            <td>
                <asp:TextBox ID="txt_subdiv" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Province</td>
            <td>
                <asp:TextBox ID="txt_Province" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Postal Code</td>
            <td>
                <asp:TextBox ID="txt_zipcode" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Telephone</td>
            <td>
                <asp:TextBox ID="txt_tel" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Faxno</td>
            <td>
                <asp:TextBox ID="txt_fax" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Country</td>
            <td>
            
                <telerik:RadComboBox ID="rcb_national" Runat="server" Filter="Contains">
                </telerik:RadComboBox> 
            
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" />
            </td>
        </tr>
    </table>
</asp:Content>
