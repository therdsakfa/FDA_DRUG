<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_LCN_DRUG_CHOOSE_TYPE.aspx.vb" Inherits="FDA_DRUG.FRM_LCN_DRUG_CHOOSE_TYPE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                เลือกหน่วยงาน
            </td>
            <td>
                <asp:RadioButtonList ID="rdl_org" runat="server"></asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_download" runat="server" Text="ดาวน์โหลด" />
            </td>
        </tr>
    </table>

</asp:Content>
