<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_PRODUCTION_DRUG_GROUP3.aspx.vb" Inherits="FDA_DRUG.POPUP_LCN_PRODUCTION_DRUG_GROUP3" %>

<%@ Register Src="~/EDIT_LOCATION_STAFF/UC/UC_TABLE_DRUG_GROUP_CHANGE_V2.ascx" TagPrefix="uc1" TagName="UC_TABLE_DRUG_GROUP_CHANGE_V2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="ss2s" runat="server">
            <asp:Panel ID="pnlPerson" runat="server">
                <div style="width: 900px" id="main">
                    <h3>รายการหมวดยาแผนปัจจุบันที่ขออนุญาตผลิต
                    </h3>
                    <table class="table" style="width: 100%;">
                         <tr>
            <td align="center">
                <b>
                รายการหมวดยาแผนปัจจุบันที่ขออนุญาตผลิต</b>
            </td>
        </tr>
        <tr>
            <td>
                ประเภทของยาแผนปัจจุบัน
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:RadioButtonList ID="rdl_drug_type" runat="server" RepeatColumns="2" style="display:none;">
                    <asp:ListItem Value="1">ยาแผนปัจจุบันสำหรับมนุษย์</asp:ListItem>
                    <asp:ListItem Value="3">ยาแผนปัจจุบันสำหรับทำการวิจัยทางคลินิกในมนุษย์ ระยะที่ ๑,๒,๓</asp:ListItem>
                    <asp:ListItem Value="2">ยาแผนปัจจุบันสำหรับสัตว์</asp:ListItem>
                </asp:RadioButtonList>
                <asp:CheckBox ID="cb_drug_type1" runat="server" Text="ยาแผนปัจจุบันสำหรับมนุษย์" /> &nbsp
                <asp:CheckBox ID="cb_drug_type2" runat="server" Text="ยาแผนปัจจุบันสำหรับสัตว์" />&nbsp
                <asp:CheckBox ID="cb_drug_type3" runat="server" Text="ยาแผนปัจจุบันสำหรับทำการวิจัยทางคลินิกในมนุษย์ ระยะที่ ๑,๒,๓" />
            </td>
        </tr>
                        <tr>
                            <td>
                                <uc1:UC_TABLE_DRUG_GROUP_CHANGE_V2 runat="server" id="UC_TABLE_DRUG_GROUP_CHANGE_V2" />

                            </td>
                        </tr>
                    </table>
                </div>
            </asp:Panel>
        </div>
    <div class="panel-footer">
        <center>
            <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" CssClass="btn-lg"/>
          <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg"/>
            <asp:Button ID="btn_goto" runat="server" Text="หน้าสำหรับพิมพ์" CssClass="btn-lg"/>
            <asp:Button ID="btn_Export" runat="server" Text="Export" CssClass="btn-lg"/>
        </center>
        
    </div>
</asp:Content>
