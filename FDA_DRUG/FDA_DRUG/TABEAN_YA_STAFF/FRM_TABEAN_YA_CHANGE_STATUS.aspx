<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_TABEAN_YA_CHANGE_STATUS.aspx.vb" Inherits="FDA_DRUG.FRM_TABEAN_YA_CHANGE_STATUS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
         
        <table>
        <tr>
            <td>
                ข้ามสถานะชำระเงิน
            </td>
            <td>
                <asp:RadioButtonList ID="rdl_type" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1" Selected="True">ทะเบียน</asp:ListItem>
                    <asp:ListItem Value="2">แก้ไขเปลี่ยนแปลงทะเบียน</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
    </table>
    </p>
    <table>
        <tr>
            <td>
                เลขดำเนินการที่ 1
            </td>
            <td>
                <asp:TextBox ID="txt_no_1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                เลขดำเนินการที่ 2
            </td>
            <td>
                <asp:TextBox ID="txt_no_2" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                เลขดำเนินการที่ 3
            </td>
            <td>
                <asp:TextBox ID="txt_no_3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                เลขดำเนินการที่ 4
            </td>
            <td>
                <asp:TextBox ID="txt_no_4" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                เลขดำเนินการที่ 5
            </td>
            <td>
                <asp:TextBox ID="txt_no_5" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btn_sent" runat="server" Text="ข้ามสถานะ" />
            </td>
        </tr>
    </table>
</asp:Content>
