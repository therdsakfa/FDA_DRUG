<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_BSN_ADDRESS.ascx.vb" Inherits="FDA_DRUG.UC_BSN_ADDRESS" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Panel ID="Panel1" runat="server" GroupingText="ที่อยู่ตามทะเบียนบ้านของผู้ดำเนินกิจการ (ภาษาไทย)">
    <table>
    <tr>
        <td align="right">รหัสประจำบ้าน จาก </td>
        
        <td align="right">
            <asp:Label ID="lb_BSN_HOUSENO" runat="server"></asp:Label> &nbsp; เป็น &nbsp;
        </td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_HOUSENO" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">เลขที่ จาก </td>
        <td align="right">
            &nbsp; <asp:Label ID="lb_BSN_ENGADDR" runat="server"></asp:Label> &nbsp; เป็น &nbsp;</td> 
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ENGADDR" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">หมู่ จาก </td>
        <td align="right">
            &nbsp; <asp:Label ID="lb_BSN_MOO" runat="server"></asp:Label>&nbsp; เป็น &nbsp;</td> 
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_MOO" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ซอย จาก </td>
        <td align="right">
            &nbsp; <asp:Label ID="lb_BSN_SOI" runat="server"></asp:Label> &nbsp; เป็น &nbsp;</td> 
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_SOI" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">ถนน จาก </td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_BSN_ROAD" runat="server"></asp:Label>&nbsp; เป็น &nbsp;</td> 
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ROAD" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">จังหวัด จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_Province" runat="server"></asp:Label>&nbsp; เป็น &nbsp;</td> 
        <td style="padding-left:1%;">
            <asp:DropDownList ID="ddl_bsn_Province" runat="server" AutoPostBack="True" DataTextField="thachngwtnm" DataValueField="chngwtcd">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">เขต/อำเภอ จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_amphor" runat="server"></asp:Label>&nbsp; เป็น &nbsp;</td> 
        <td style="padding-left:1%;">
            <asp:DropDownList ID="ddl_bsn_amphor" runat="server" AutoPostBack="True" DataTextField="thaamphrnm" DataValueField="amphrcd">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">แขวง/ตำบล จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_bsn_tambol" runat="server"></asp:Label>&nbsp; เป็น &nbsp;</td> 
        <td style="padding-left:1%;">
            <asp:DropDownList ID="ddl_tambol" runat="server" AutoPostBack="True" DataTextField="thathmblnm" DataValueField="thmblcd">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td align="right">รหัสไปรษณีย์ จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_BSN_ZIPCODE" runat="server"></asp:Label>&nbsp; เป็น &nbsp;</td> 
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ZIPCODE" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">โทรศัพท์ จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_BSN_TELEPHONE" runat="server"></asp:Label>&nbsp; เป็น &nbsp;</td> 
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_TELEPHONE" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">โทรสาร จาก</td>
        <td align="right">
            &nbsp;<asp:Label ID="lb_BSN_FAX" runat="server"></asp:Label>&nbsp; เป็น &nbsp;</td> 
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_FAX" runat="server" AutoPostBack="True" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
</table>
</asp:Panel>
<br />

<asp:Panel ID="Panel2" runat="server" GroupingText="ที่อยู่ตามทะเบียนบ้านของผู้ดำเนินกิจการ (ภาษาอังกฤษ)">
    <table>
    
    <tr>
        <td align="right">Address No.</td>
        <td align="right">&nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_BSN_ENGADDR" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Mu</td>
        <td align="right">&nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_BSN_ENGMU" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Soi จาก</td>
        <td align="right">
            <asp:Label ID="lb_BSN_ENGSOI" runat="server"></asp:Label>&nbsp; เป็น &nbsp;
        </td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ENGSOI" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">Road จาก</td>
        <td align="right"><asp:Label ID="lb_BSN_ENGROAD" runat="server"></asp:Label>&nbsp; เป็น &nbsp;</td>
        <td style="padding-left:1%;">
            <asp:TextBox ID="txt_BSN_ENGROAD" runat="server" CssClass="input-sm"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">Province</td>
        <td align="right">&nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_BSN_CHWNG_ENGNAME" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Subdivision of a Province </td>
        <td align="right">&nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_BSN_AMPHR_ENGNAME" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">District </td>
        <td align="right">&nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_BSN_THMBL_ENGNAME" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Postal Code </td>
        <td align="right">&nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_BSN_ZIPCODE" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Telephone </td>
        <td align="right">&nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_BSN_TELEPHONE" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">Fax No </td>
        <td align="right">&nbsp;</td>
        <td style="padding-left:1%;">
            <asp:Label ID="lbl_BSN_FAX" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
</table>
</asp:Panel>
