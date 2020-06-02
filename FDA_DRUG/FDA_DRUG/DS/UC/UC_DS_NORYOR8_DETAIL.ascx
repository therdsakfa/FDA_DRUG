<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DS_NORYOR8_DETAIL.ascx.vb" Inherits="FDA_DRUG.UC_DS_NORYOR8_DETAIL" %>

<table class="table" style="width:100%;">
    <tr>
        <td align="right">
            เขียนที่
        </td>
        <td>
            <asp:TextBox ID="txt_WRITE_AT" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            วันที่</td>
        <td>
            <asp:TextBox ID="txt_WRITE_DATE" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            ข้าพเจ้า (ชื่อผู้ขออนุญาต)</td>
        <td>
            <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            ผู้ดำเนินกิจการชื่อ</td>
        <td>
            <asp:Label ID="lbl_bsn_name" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right">
            ได้รับอนุญาตนำหรือสั่งเลขที่</td>
        <td>
            <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td align="right" >
            ทะเบียนตำรับชื่อ (ภาษาไทย)</td>
        <td>
            <asp:TextBox ID="txt_thadrgnm" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            (ภาษาอังกฤษ)</td>
        <td>
            <asp:TextBox ID="txt_engdrgnm" runat="server" Width="250px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td align="right">
            จำนวน</td>
        <td>
            <table>
                <tr>
                    <td>
<asp:TextBox ID="txt_QUANTITY" runat="server"></asp:TextBox>
                    </td>
                    <td>

                        <asp:DropDownList ID="ddl_QUANTITY_unit" runat="server">
                        </asp:DropDownList>

                    </td>
                </tr>
            </table>
            
        </td>
    </tr>
    <tr>
        <td align="right">
            หน่วยนับตามรูปแบบยา</td>
        <td>
            <asp:DropDownList ID="ddl_unit" runat="server">
            </asp:DropDownList>
            
        </td>
    </tr>
    <tr>
        <td colspan="2">
            แนบเอกสารเพิ่มเติม</td>
    </tr>
    <tr>
        <td>
            (1) ฉลากทุกขนาดบรรจุ</td>
        <td>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:HyperLink ID="hp_file_name1" runat="server" style="display:none;" Target="_blank"></asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td >
            (2) กล่องบรรจุทุกขนาดบรรจุ</td>
        <td>
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <asp:HyperLink ID="hp_file_name2" runat="server" style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
    </tr>
    <tr>
        <td>
            (3) เอกสารกำกับยา</td>
        <td>
            <asp:FileUpload ID="FileUpload3" runat="server" />
            <asp:HyperLink ID="hp_file_name3" runat="server" style="display:none;" Target="_blank"></asp:HyperLink>
        </td>
    </tr>
</table>