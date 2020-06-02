<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_REGIST_DETAIL_V2.ascx.vb" Inherits="FDA_DRUG.UC_REGIST_DETAIL_V2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>
    <tr>
        <td>
            หมวดยา
        </td>
        <td style="padding:0px 0px 0px 50px;" >
            <table>
                <tr>
                    <td>
                        <telerik:RadComboBox ID="rcb_dactg" runat="server" filter="Contains" style="display:none;"></telerik:RadComboBox>
                        <asp:Label ID="lbl_dactg" runat="server" Text="-"></asp:Label>
                    </td>
                    <td>
                        <asp:Button ID="btn_chg_dactg" runat="server" Text="เปลี่ยน" />
                        <asp:Button ID="btn_cls_dactg" runat="server" Text="ปิด" style="display:none;"/>
                        <asp:Button ID="btn_sv_dactg" runat="server" Text="บันทึก" style="display:none;"/>
                    </td>
                    
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            ประเภทของยา</td>
        <td style="padding:0px 0px 0px 50px;" >
            <telerik:RadComboBox ID="rcb_drclass" runat="server" filter="Contains"></telerik:RadComboBox>
            <asp:Label ID="lbl_drclass" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            รูปแบบของแบบยา</td>
        <td style="padding:0px 0px 0px 50px;">
            <telerik:RadComboBox ID="rcb_drdosage" runat="server" filter="Contains"></telerik:RadComboBox>
            <asp:Label ID="lbl_drdosage" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            หน่วยนับตามรูปของแบบยา</td>
        <td style="padding:0px 0px 0px 50px;">
            <telerik:RadComboBox ID="rcb_small_unit" runat="server" filter="Contains"></telerik:RadComboBox>
            <asp:Label ID="lbl_small_unit" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            หน่วยนับทางชีวภาพ</td>
        <td style="padding:0px 0px 0px 50px;">
            <telerik:RadComboBox ID="rcb_bio_pack" runat="server" filter="Contains"></telerik:RadComboBox>
            <asp:Label ID="lbl_bio_pack" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            หน่วยนับตามบรรจุภัณฑ์</td>
        <td style="padding:0px 0px 0px 50px;">
            <telerik:RadComboBox ID="rcb_packaging" runat="server" filter="Contains"></telerik:RadComboBox>
            <asp:Label ID="lbl_packaging" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            รูปทรง</td>
        <td style="padding:0px 0px 0px 50px;">
            <telerik:RadComboBox ID="rcb_shape" runat="server" filter="Contains"></telerik:RadComboBox>
            <asp:Label ID="lbl_shape" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            ชนิดของยาตามกฎหมาย</td>
        <td style="padding:0px 0px 0px 50px;">
            <telerik:RadComboBox ID="rcb_drug_type" Runat="server" filter="Contains">
            </telerik:RadComboBox>
            <asp:Label ID="lbl_drug_type" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            ความแรง</td>
        <td style="padding:0px 0px 0px 50px;">
            <asp:TextBox ID="txt_drug_str" runat="server"></asp:TextBox>
            <asp:Label ID="lbl_drug_str" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="padding:0px 0px 0px 50px;">

            <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" CssClass="input-lg" />

        </td>
    </tr>
</table>