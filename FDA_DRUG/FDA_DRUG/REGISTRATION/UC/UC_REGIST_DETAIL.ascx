<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_REGIST_DETAIL.ascx.vb" Inherits="FDA_DRUG.UC_REGIST_DETAIL" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<table>
    <tr>
        <td>
            หมวดยา
        </td>
        <td style="padding:0px 0px 0px 50px;" >
            <asp:Label ID="lbl_dactg" runat="server" Text=""></asp:Label>
        </td>
        <td style="padding:0px 0px 0px 50px;" >
            แก้ไขเป็น</td>
        <td style="padding:0px 0px 0px 50px;" >
            <%--<asp:DropDownList ID="ddl_dactg" runat="server">
            </asp:DropDownList>--%>
            <telerik:RadComboBox ID="rcb_dactg" runat="server" filter="Contains"></telerik:RadComboBox>
        </td>
    </tr>
    <tr>
        <td>
            ประเภทของยา</td>
        <td style="padding:0px 0px 0px 50px;" >
            <asp:Label ID="lbl_drclass" runat="server" Text=""></asp:Label>

        </td>
        <td style="padding:0px 0px 0px 50px;" >
            แก้ไขเป็น</td>
        <td style="padding:0px 0px 0px 50px;" >
            <telerik:RadComboBox ID="rcb_drclass" runat="server" filter="Contains"></telerik:RadComboBox>
            <%--<asp:DropDownList ID="ddl_drclass" runat="server">
            </asp:DropDownList>--%>

        </td>
    </tr>
    <tr>
        <td>
            รูปแบบของยา</td>
        <td style="padding:0px 0px 0px 50px;">
            <asp:Label ID="lbl_drdosage" runat="server" Text=""></asp:Label>

        </td>
        <td style="padding:0px 0px 0px 50px;">
            แก้ไขเป็น</td>
        <td style="padding:0px 0px 0px 50px;">
            <telerik:RadComboBox ID="rcb_drdosage" runat="server" filter="Contains"></telerik:RadComboBox>
            <%--<asp:DropDownList ID="ddl_drdosage" runat="server">
            </asp:DropDownList>--%>

        </td>
    </tr>
    <tr>
        <td>
            หน่วยนับตามรูปของแบบยา</td>
        <td style="padding:0px 0px 0px 50px;">
            <asp:Label ID="lbl_small_unit" runat="server" Text=""></asp:Label>

        </td>
        <td style="padding:0px 0px 0px 50px;">
            แก้ไขเป็น</td>
        <td style="padding:0px 0px 0px 50px;">
            <telerik:RadComboBox ID="rcb_small_unit" runat="server" filter="Contains"></telerik:RadComboBox>

            <%--<asp:DropDownList ID="ddl_small_unit" runat="server">
            </asp:DropDownList>--%>

        </td>
    </tr>
    <tr>
        <td>
            หน่วยนับทางชีวภาพ</td>
        <td style="padding:0px 0px 0px 50px;">
            <asp:Label ID="lbl_bio_pack" runat="server" Text=""></asp:Label>

        </td>
        <td style="padding:0px 0px 0px 50px;">
            แก้ไขเป็น</td>
        <td style="padding:0px 0px 0px 50px;">
            <telerik:RadComboBox ID="rcb_bio_pack" runat="server" filter="Contains"></telerik:RadComboBox>
            <%--<asp:DropDownList ID="ddl_bio_pack" runat="server">
                            </asp:DropDownList>--%>

        </td>
    </tr>
    <tr>
        <td>
            หน่วยนับตามบรรจุภัณฑ์</td>
        <td style="padding:0px 0px 0px 50px;">
            <asp:Label ID="lbl_packaging" runat="server" Text=""></asp:Label>


        </td>
        <td style="padding:0px 0px 0px 50px;">
            แก้ไขเป็น</td>
        <td style="padding:0px 0px 0px 50px;">
            <telerik:RadComboBox ID="rcb_packaging" runat="server" filter="Contains"></telerik:RadComboBox>
            <%--<asp:DropDownList ID="ddl_packaging" runat="server">
            </asp:DropDownList>--%>


        </td>
    </tr>
    <tr>
        <td>
            รูปทรง</td>
        <td style="padding:0px 0px 0px 50px;">
            <asp:Label ID="lbl_shape" runat="server" Text=""></asp:Label>

        </td>
        <td style="padding:0px 0px 0px 50px;">
            แก้ไขเป็น</td>
        <td style="padding:0px 0px 0px 50px;">
            <telerik:RadComboBox ID="rcb_shape" runat="server" filter="Contains"></telerik:RadComboBox>
            <%--<asp:DropDownList ID="ddl_shape" runat="server">
            </asp:DropDownList>--%>

        </td>
    </tr>
    <tr>
        <td>
            ชนิดของยาตามกฎหมาย</td>
        <td style="padding:0px 0px 0px 50px;">
            <asp:Label ID="lbl_drug_type" runat="server" Text=""></asp:Label>

        </td>
        <td style="padding:0px 0px 0px 50px;">
            แก้ไขเป็น</td>
        <td style="padding:0px 0px 0px 50px;">
            <telerik:RadComboBox ID="rcb_drug_type" Runat="server" filter="Contains">
            </telerik:RadComboBox>

        </td>
    </tr>
    <tr>
        <td>
            ความแรง</td>
        <td style="padding:0px 0px 0px 50px;">
            &nbsp;</td>
        <td style="padding:0px 0px 0px 50px;">
            &nbsp;</td>
        <td style="padding:0px 0px 0px 50px;">
            <asp:TextBox ID="txt_drug_str" runat="server"></asp:TextBox>

        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td style="padding:0px 0px 0px 50px;">

            &nbsp;</td>
        <td style="padding:0px 0px 0px 50px;">

            &nbsp;</td>
        <td style="padding:0px 0px 0px 50px;">

            <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" CssClass="input-lg" />

        </td>
    </tr>
</table>