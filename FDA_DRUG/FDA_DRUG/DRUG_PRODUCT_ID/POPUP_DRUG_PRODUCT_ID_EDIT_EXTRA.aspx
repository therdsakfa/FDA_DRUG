<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DRUG_PRODUCT_ID_EDIT_EXTRA.aspx.vb" Inherits="FDA_DRUG.POPUP_DRUG_PRODUCT_ID_EDIT_EXTRA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table" style="width: 100%">
                    
                    <tr>
                        <td>ชื่อการค้า</td>
                        <td>
                            <asp:Label ID="lbl_TRADE_NAME" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>ชื่อการค้าภาษาอังกฤษ</td>
                        <td>
                            <asp:Label ID="lbl_TRADE_NAME_ENG" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>เลข Product ID</td>
                        <td>
                            <asp:Label ID="lbl_Product_ID" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>ลักษณะและสีของยา</td>
                        <td>
                            <asp:TextBox ID="Txt_Drug_Nature" runat="server" CssClass="input-sm" Width="400px" TextMode="MultiLine" Height="150px"></asp:TextBox>
                        </td>
                    </tr>
    </table>

    <asp:Panel ID="Panel3" runat="server">
            <div class="panel-footer " style="text-align: center;">
                <asp:Button ID="btn_save" runat="server" CssClass="btn-lg" Text="บันทึก" />
            </div>
        </asp:Panel>
</asp:Content>
