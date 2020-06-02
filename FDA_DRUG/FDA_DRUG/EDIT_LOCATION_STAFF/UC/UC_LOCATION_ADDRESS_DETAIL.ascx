<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_LOCATION_ADDRESS_DETAIL.ascx.vb" Inherits="FDA_DRUG.UC_LOCATION_ADDRESS_DETAIL" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Panel ID="Panel1" runat="server" GroupingText="ที่ตั้งของสถานที่ที่ขออนุญาต (ภาษาไทย)">
    <table width="75%">
    <tr>
        <td align="right">รหัสประจำบ้าน</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_HOUSENO" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เลขที่</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_thaaddr" runat="server" CssClass="input-sm" AutoPostBack="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">หมู่</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_thamu" runat="server" CssClass="input-sm" AutoPostBack="True"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ซอย</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_thasoi" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ถนน</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_tharoad" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">จังหวัด</td>
        <td style="padding-left:1%;">
            <asp:DropDownList ID="ddl_Province" runat="server" AutoPostBack="True" DataTextField="thachngwtnm" DataValueField="chngwtcd"></asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">เขต/อำเภอ</td>
        <td style="padding-left:1%;">
            <asp:DropDownList ID="ddl_amphor" runat="server" AutoPostBack="True" DataTextField="thaamphrnm" DataValueField="amphrcd">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">แขวง/ตำบล</td>
        <td style="padding-left:1%;">
            <asp:DropDownList ID="ddl_tambol" runat="server" AutoPostBack="True" DataTextField="thathmblnm" DataValueField="thmblcd">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">รหัสไปรษณีย์</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_zipcode" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">โทรศัพท์</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_tel" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">โทรสาร</td>
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
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_thaaddr" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Mu :</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_thamu" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Soi :</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_engsoi" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">Road :</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_engroad" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">Province :</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_engchngwtnm" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Subdivision of a Province :</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_engamphrnm" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">District :</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_engthmblnm" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Postal Code :</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_zipcode" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Telephone :</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_tel" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Fax No :</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_fax" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
</table>
</asp:Panel>

