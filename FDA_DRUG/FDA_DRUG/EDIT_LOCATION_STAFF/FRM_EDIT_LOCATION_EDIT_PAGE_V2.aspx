<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_EDIT.Master" CodeBehind="FRM_EDIT_LOCATION_EDIT_PAGE_V2.aspx.vb" Inherits="FDA_DRUG.FRM_EDIT_LOCATION_EDIT_PAGE_V2" %>
<%@ Register src="UC/UC_BSN_NAME.ascx" tagname="UC_BSN_NAME" tagprefix="uc1" %>
<%@ Register Src="~/EDIT_LOCATION_STAFF/UC/UC_BSN_ADDRESS.ascx" TagPrefix="uc1" TagName="UC_BSN_ADDRESS" %>


<%@ Register Src="~/EDIT_LOCATION_STAFF/UC/UC_LCN_LOCATION_ADDRESS_DETAIL.ascx" TagPrefix="uc1" TagName="UC_LCN_LOCATION_ADDRESS_DETAIL" %>


<%@ Register src="UC/UC_LCN_NAME_LOCATION.ascx" tagname="UC_LCN_NAME_LOCATION" tagprefix="uc3" %>
<%@ Register Src="~/EDIT_LOCATION_STAFF/UC/UC_LCNS_NAME.ascx" TagPrefix="uc1" TagName="UC_LCNS_NAME" %>
<%@ Register Src="~/EDIT_LOCATION_STAFF/UC/UC_LOCATION_ADDRESS_TEL.ascx" TagPrefix="uc1" TagName="UC_LOCATION_ADDRESS_TEL" %>
<%@ Register Src="~/EDIT_LOCATION_STAFF/UC/UC_LCN_OPENTIME.ascx" TagPrefix="uc1" TagName="UC_LCN_OPENTIME" %>




<%@ Register src="../UC/UC_Information_edit.ascx" tagname="UC_Information_edit" tagprefix="uc2" %>




<%@ Register src="UC/UC_BSN_SUSTAIN.ascx" tagname="UC_BSN_SUSTAIN" tagprefix="uc4" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
        <tr>
            <td>

                <uc2:uc_information_edit ID="UC_Information_edit1" runat="server" />

            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="Panel1" runat="server" style="display:none;">
                    <uc1:UC_BSN_NAME ID="UC_BSN_NAME2" runat="server" />
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" style="display:none;">
                    <uc1:UC_BSN_ADDRESS runat="server" ID="UC_BSN_ADDRESS" />
                </asp:Panel>
                <asp:Panel ID="Panel3" runat="server" style="display:none;">
                    <uc3:UC_LCN_NAME_LOCATION ID="UC_LCN_NAME_LOCATION1" runat="server" />
                </asp:Panel>
                <asp:Panel ID="Panel4" runat="server" Style="display: none;">
                    <uc1:UC_LCN_LOCATION_ADDRESS_DETAIL runat="server" ID="UC_LCN_LOCATION_ADDRESS_DETAIL" />
                </asp:Panel>
                <asp:Panel ID="Panel5" runat="server" Style="display: none;">
                    <uc1:UC_LCNS_NAME runat="server" ID="UC_LCNS_NAME" />
                </asp:Panel>
                <asp:Panel ID="Panel6" runat="server" Style="display: none;">
                    <uc1:UC_LOCATION_ADDRESS_TEL runat="server" ID="UC_LOCATION_ADDRESS_TEL" />
                </asp:Panel>
                <asp:Panel ID="Panel7" runat="server" Style="display: none;">
                    <uc1:UC_LCN_OPENTIME runat="server" ID="UC_LCN_OPENTIME" />
                </asp:Panel>
                <asp:Panel ID="Panel8" runat="server" Style="display: none;">
                    <uc4:UC_BSN_SUSTAIN ID="UC_BSN_SUSTAIN1" runat="server" />
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%">
                    <tr>
                        <td align="right">วันที่บันทึก</td>
                        <td>
                            <asp:TextBox ID="txt_select_date_edit" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                
            </td>
        </tr>
    </table>

    <div class="panel-footer">
        <center>
            <asp:Button ID="btn_save" runat="server" CssClass="btn-lg" Text="บันทึก" />
<asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" CssClass="btn-lg"></asp:Button>
        </center>
    </div>
</asp:Content>
