<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_general_head.ascx.vb" Inherits="FDA_SEARCH_DRUG.UC_general_head" %>
<style type="text/css">
    .auto-style1 {
        height: 35px;

    }
</style>
<table bgcolor="whitesmoke" border="0"; width: 1130px; height: 388px;>
    
       <tr>
        <td colspan="2" >
            <h2>ข้อมูลทั่วไปผลิตภัณฑ์ยา</h2>
        </td>
    </tr>


       <tr>
        <td  bgcolor="whitesmoke" width="210px" height="28px">เลขทะเบียนตำรับยา</td>
        <td width="530px" height="24px"><asp:Label ID="Lb_cou" runat="server" ></asp:Label></td>
    </tr>

    <tr>
        <td  bgcolor="whitesmoke">ชื่อการค้า:</td>
        <td >
            <asp:Label ID="lb_appdate" runat="server"></asp:Label></td>
    </tr>



    <tr>
        <td  bgcolor="whitesmoke">ชื่อผู้รับอนุญาต : </td>
        <td >
            <asp:Label ID="lb_kind_pop" runat="server"></asp:Label></td>
    </tr>
    </table>