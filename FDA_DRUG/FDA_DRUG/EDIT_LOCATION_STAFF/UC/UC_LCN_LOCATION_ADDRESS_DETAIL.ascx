<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LCN_LOCATION_ADDRESS_DETAIL.ascx.vb" Inherits="FDA_DRUG.UC_LCN_LOCATION_ADDRESS_DETAIL" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Panel ID="Panel1" runat="server" GroupingText="ที่ตั้งของสถานที่ที่ขออนุญาต (ภาษาไทย)">
    <table width="75%">
    <tr>
        <td align="right">รหัสประจำบ้าน จาก</td>
        <td align="right">
            <asp:Label ID="lb_HOUSENO" runat="server"></asp:Label> &nbsp; เป็น &nbsp;
        </td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_HOUSENO" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เลขที่ จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_thaaddr" runat="server"></asp:Label> &nbsp; เป็น &nbsp;

        </td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_thaaddr" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">หมู่ จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_thamu" runat="server"></asp:Label> &nbsp; เป็น &nbsp;

        </td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_thamu" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ซอย จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_thasoi" runat="server"></asp:Label> &nbsp; เป็น &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_thasoi" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ถนน จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_tharoad" runat="server"></asp:Label> &nbsp; เป็น &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_tharoad" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">จังหวัด จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_Province" runat="server"></asp:Label> &nbsp; เป็น &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:DropDownList ID="ddl_Province" runat="server" AutoPostBack="True" DataTextField="thachngwtnm" DataValueField="chngwtcd">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">เขต/อำเภอ จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_amphor" runat="server"></asp:Label> &nbsp; เป็น &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:DropDownList ID="ddl_amphor" runat="server" AutoPostBack="True" DataTextField="thaamphrnm" DataValueField="amphrcd">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">แขวง/ตำบล จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_tambol" runat="server"></asp:Label> &nbsp; เป็น &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:DropDownList ID="ddl_tambol" runat="server" AutoPostBack="True" DataTextField="thathmblnm" DataValueField="thmblcd">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">รหัสไปรษณีย์ จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_zipcode" runat="server"></asp:Label> &nbsp; เป็น &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_zipcode" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">โทรสาร จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_fax" runat="server"></asp:Label> &nbsp; เป็น &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_fax" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
</table>
</asp:Panel>
<br />

<asp:Panel ID="Panel2" runat="server" GroupingText="ที่ตั้งของสถานที่ที่ขออนุญาต (ภาษาอังกฤษ)">
    <table width="75%">
    
    <tr>
        <td align="right">Address No. :</td>
        <td align="right">
            &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_thaaddr" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Mu :</td>
        <td align="right">
            &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_thamu" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Soi จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_engsoi" runat="server"></asp:Label> &nbsp; เป็น &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_engsoi" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">Road จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_engroad" runat="server"></asp:Label> &nbsp; เป็น &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_engroad" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">Province :</td>
        <td align="right">
            &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_engchngwtnm" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Subdivision of a Province :</td>
        <td align="right">
            &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_engamphrnm" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">District :</td>
        <td align="right">
            &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_engthmblnm" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Postal Code :</td>
        <td align="right">
            &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_zipcode" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Fax No :</td>
        <td align="right">
            &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_fax" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
</table>
</asp:Panel>