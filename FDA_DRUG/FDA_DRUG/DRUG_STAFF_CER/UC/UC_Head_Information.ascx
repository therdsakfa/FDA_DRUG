<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_Head_Information.ascx.vb" Inherits="FDA_DRUG.UC_Head_Information" %>
<table width="100%" style="font-family:'TH SarabunPSK';font-size:20px;">
    <tr>
        <td width="20%" style="height:25px">
            เลขที่ใบอนุญาต :
        </td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_lcnno_format" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            ประเภท :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_lcntpnm" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            ชื่อผู้รับอนุญาต :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_licen_name" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            สถานที่ ชื่อ :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_thanameplace" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            อยู่เลขที่ :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_addr" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            โทรศัพท์ :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_tel" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="height:25px">
            โทรสาร :</td>
        <td style="border-bottom:dotted;border-bottom-width:thin;">
            <asp:Label ID="lbl_fax" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
</table>