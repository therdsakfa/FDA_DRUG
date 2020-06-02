<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_PHARMACIST_CITIZEN_ID.aspx.vb" Inherits="FDA_DRUG.WebForm4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table  style="width:100%;">
        <tr>
             <td style="width:25%;"></td>
             <td style="width:25%;"></td>
             <td style="width:25%;"></td>
            <td style="width:25%;"></td>
        </tr>
        <tr>
             <td></td>
             <td>เลขบัตรประชาชน : </td>
             <td>
                 <asp:TextBox ID="txt_CITIZEN_ID" runat="server"></asp:TextBox>
             </td>
            <td></td>
        </tr>
        <tr>
             <td></td>
             <td colspan="2" style="text-align:center;"> <asp:Button ID="btn_ok" runat="server" Text="ยืนยัน" /></td>
            <td></td>
        </tr>
    </table>
</asp:Content>
