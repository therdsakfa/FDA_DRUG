<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_officer_refer.ascx.vb" Inherits="FDA_SEARCH_DRUG.UC_officer_refer" %>
<style type="text/css">
    .z {
         border : 1px solid;
    }
    .auto-style3 {
        height: 29px;
    }
</style>
<%--<style type="text/css">
    .auto-style1 {
        width: 281px;
    }
    .auto-style2 {
        width: 281px;
        height: 23px;
    }
    .auto-style3 {
        height: 23px;
    }

</style>--%>
<table style="background-color: White ; width: 1130px; height: 388px;" border="1">



   <tr>
        <td  bgcolor="Lavender" >ประเภททะเบียน : </td>
        <td >
            <asp:Label ID="lb_regis_type" runat="server"></asp:Label></td>
    </tr>
   
   <tr>
        <td  bgcolor="Lavender" class="auto-style3" >ขอที่ : </td>
        <td class="auto-style3" >
            <asp:Label ID="lb_askwhere" runat="server"></asp:Label></td>
    </tr>



   <tr>
        <td  bgcolor="Lavender" >เลขทะเบียน : </td>
        <td >
            <asp:Label ID="lb_regis" runat="server"></asp:Label></td>
    </tr>



    <tr>
        <td  bgcolor="Lavender" >ชื่อการค้าไทย : </td>
        <td >
            <asp:Label ID="lb_thadrgnm" runat="server"></asp:Label></td>
    </tr>




   <tr>
        <td  bgcolor="Lavender" bgcolor="Wheat" >ชื่อการค้าอังกฤษ</td>
        <td >
            <asp:Label ID="lb_engdrgnm" runat="server"></asp:Label></td>
    </tr>

</table>
