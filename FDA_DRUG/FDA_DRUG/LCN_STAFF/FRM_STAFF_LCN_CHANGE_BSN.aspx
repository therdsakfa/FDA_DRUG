<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_CHANGE_BSN.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_LCN_CHANGE_BSN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%" class="table">
       
    
    <tr>
        <td align="right" width="30%">
            ชื่อผู้ดำเนินกิจการเดิม :
        </td>
        <td>
            <asp:Label ID="lbl_old_bsn" runat="server" Text="-"></asp:Label>
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
            <%--หากยังไม่ได้เพิ่มผู้ดำเนินรายใหม่กรุณา
            <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/EDIT_LOCATION_STAFF/FRM_ADD_NEW_BSN.aspx" Target="_blank">คลิกที่นี่</asp:HyperLink>--%>
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
        <tr>
            <td align="center" colspan="2">
                <asp:Button ID="btn_c_bsn" runat="server" CssClass="btn-lg" Text="เปลี่ยนชื่อผู้ดำเนิน" OnClientClick="return confirm('คุณต้องการเปลี่ยนผู้ดำเนินหรือไม่');" />
            </td>
        </tr>
</table>
</asp:Content>
