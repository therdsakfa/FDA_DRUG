<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_BSN_SUSTAIN.ascx.vb" Inherits="FDA_DRUG.UC_BSN_SUSTAIN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Panel ID="Panel4" runat="server">
    <asp:RadioButtonList ID="rdl_type" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
        <asp:ListItem Value="1" Selected="True">สืบสิทธิ์</asp:ListItem>
        <asp:ListItem Value="2">โอนกิจการ</asp:ListItem>
    </asp:RadioButtonList>
<%--    <asp:CheckBoxList ID="cbl_change" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
        <asp:ListItem Value="1">เปลี่ยนผู้รับอนุญาต</asp:ListItem>
        <asp:ListItem Value="2">เปลี่ยนสถานที่ตั้ง</asp:ListItem>
        <asp:ListItem Value="3">เปลี่ยนผู้ดำเนินกิจการ</asp:ListItem>
    </asp:CheckBoxList>--%>
    <asp:RadioButtonList ID="rdl_change" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
        <asp:ListItem Value="1">เปลี่ยนผู้รับอนุญาต</asp:ListItem>
        <asp:ListItem Value="2">เปลี่ยนสถานที่ตั้ง</asp:ListItem>
        <asp:ListItem Value="3">เปลี่ยนผู้ดำเนินกิจการ</asp:ListItem>
    </asp:RadioButtonList>
</asp:Panel>
<asp:Panel ID="Panel1" runat="server" GroupingText="เปลี่ยนผู้รับอนุญาต" style="display:none;">
    <table width="100%">
        <tr>
            <td width="30%">ชื่อผู้รับอนุญาต (เดิม)</td>
            <td>
                <asp:Label ID="lbl_lcnsnm_old" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>ชื่อผู้รับอนุญาต (ใหม่)</td>
            <td>
                <asp:TextBox ID="txt_ctzid_lcn" runat="server"></asp:TextBox>
                <asp:Button ID="btn_search_lcn" runat="server" Text="ค้นหา" />
                <asp:HiddenField ID="hf_lcn" runat="server" /><br />
                <asp:Label ID="lbl_lcnname_new" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:Panel ID="Panel2" runat="server" GroupingText="เปลี่ยนสถานที่" style="display:none;">
    <table width="100%">
        
        <tr>
            <td width="30%">ชื่อสถานที่ (เดิม)</td>
            <td>
                <asp:Label ID="lbl_thanameplace_old" runat="server" Text="-"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>ชื่อสถานที่ (ใหม่)</td>
            <td>
                <asp:DropDownList ID="ddl_placename" runat="server" Width="300px" AutoPostBack="True">
                </asp:DropDownList>
                <asp:HiddenField ID="hf_place" runat="server" />
            </td>
        </tr>

        <tr>
            <td>ที่ตั้ง (เดิม)</td>
            <td>
                <asp:Label ID="lbl_location_old" runat="server" Text="-"></asp:Label>
            </td>
        </tr>

        <tr>
            <td>ที่ตั้ง (ใหม่)</td>
            <td>
                <asp:Label ID="lbl_location_new" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Panel>
<br />
<asp:Panel ID="Panel3" runat="server" GroupingText="ผู้ดำเนินกิจการ" style="display:none;">
    <table width="100%">
       
    
    <tr>
        <td align="right" width="30%">
            ชื่อผู้ดำเนินกิจการเดิม :
        </td>
        <td>
            <asp:Label ID="lbl_old_bsn" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
        <tr>
            <td align="right" width="30%">
                <asp:Label ID="lbl_pass_away" runat="server" Text="เสียชีวิตตั้งแต่วันที่ :"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txt_PASS_AWAY_DATE" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right" width="30%">ที่อยู่เดิม : </td>
            <td>
                <asp:Label ID="lbl_old_addr" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
        <td  colspan="2">
            หากยังไม่ได้เพิ่มผู้ดำเนินรายใหม่กรุณา
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/EDIT_LOCATION_STAFF/FRM_ADD_NEW_BSN.aspx" Target="_blank">คลิกที่นี่</asp:HyperLink>
        </td>
    </tr>
    <tr>
        <td align="right">
            กรอกเลข 13 หลัก เพื่อดึงข้อมูลผู้ดำเนิน :</td>
        <td>
            <asp:TextBox ID="txt_ctzid" runat="server"></asp:TextBox>
            <asp:Button ID="btn_search" runat="server" Text="ค้นหา" />
            <asp:HiddenField ID="hf_bsn" runat="server" />
        </td>
    </tr>
    <tr>
        <td align="right">
            ชื่อผู้ดำเนินใหม่ :</td>
        <td>
            <asp:Label ID="lbl_new_bsn" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
        <tr>
            <td align="right">ที่อยู่ใหม่ :</td>
            <td>
                <asp:Label ID="lbl_new_addr" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
</table>
</asp:Panel>
