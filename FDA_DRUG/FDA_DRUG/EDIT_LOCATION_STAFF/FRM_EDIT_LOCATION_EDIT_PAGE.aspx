<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_EDIT.Master" CodeBehind="FRM_EDIT_LOCATION_EDIT_PAGE.aspx.vb" Inherits="FDA_DRUG.FRM_EDIT_LOCATION_EDIT_PAGE" %>
<%@ Register src="UC/UC_NAME_LOCATION.ascx" tagname="UC_NAME_LOCATION" tagprefix="uc1" %>
<%@ Register src="UC/UC_LOCATION_ADDRESS_DETAIL.ascx" tagname="UC_LOCATION_ADDRESS_DETAIL" tagprefix="uc2" %>
<%@ Register src="UC/UC_BSN_NAME.ascx" tagname="UC_BSN_NAME" tagprefix="uc3" %>
<%@ Register src="UC/UC_BSN_ADDRESS.ascx" tagname="UC_BSN_ADDRESS" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" style="display:none;">
                    <uc1:UC_NAME_LOCATION ID="UC_NAME_LOCATION1" runat="server" />
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" style="display:none;">
                    <uc2:UC_LOCATION_ADDRESS_DETAIL ID="UC_LOCATION_ADDRESS_DETAIL1" runat="server" />
                </asp:Panel>
                <asp:Panel ID="Panel3" runat="server" style="display:none;">
                    <uc3:UC_BSN_NAME ID="UC_BSN_NAME1" runat="server" />
                </asp:Panel>
                <asp:Panel ID="Panel4" runat="server" style="display:none;">
                    <uc4:UC_BSN_ADDRESS ID="UC_BSN_ADDRESS1" runat="server" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td align="center">
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" />
            </td>
        </tr>

    </table>
    

</asp:Content>
