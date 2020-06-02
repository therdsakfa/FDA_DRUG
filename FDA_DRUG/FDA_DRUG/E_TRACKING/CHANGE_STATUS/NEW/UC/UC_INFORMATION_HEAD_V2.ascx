<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_INFORMATION_HEAD_V2.ascx.vb" Inherits="FDA_DRUG.UC_INFORMATION_HEAD_V2" %>
<table class="table">
        <tr>
            <td align="right" style="width:10%;">ชื่อผลิตภัณฑ์ :
            </td>
            <td style="width:20%;">
                <asp:Label ID="lbl_product_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
             <td align="right" style="width:10%;">เลขทะเบียน/เลขใบอนุญาต :
            </td>
            <td style="width:20%;">
                <asp:Label ID="lbl_lcnno_display" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:10%;">ชื่อผู้อนุญาต :
            </td>
            <td style="width:10%;">
                <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:10%;">สถานะปัจจุบัน :
            </td>
            <td style="width:20%;">
                <asp:Label ID="lbl_stat" runat="server" Text="-"></asp:Label> &nbsp; <asp:Label ID="Label1" runat="server" Text="/"></asp:Label> <asp:HyperLink ID="HyperLink1" runat="server" Target="_self">เพิ่มสถานะย่อย (ถ้ามี)</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:10%;">วันที่ของสถานะ :</td>
            <td style="width:20%;">
                <asp:Label ID="lbl_date" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        </table>