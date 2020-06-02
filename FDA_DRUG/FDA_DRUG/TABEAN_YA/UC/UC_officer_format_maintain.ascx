<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_officer_format_maintain.ascx.vb" Inherits="FDA_SEARCH_DRUG.UC_officer_format_maintain" %>
 <style type="text/css">
     .auto-style4 {
         width: 98px;
     }
 </style>


<table style="background-color:  white; width: 1130px; height: 40px;" border="1">

    <tr>
        <td  bgcolor="Lavender" width="197px" height="28px">อายุการใช้งาน:</td>
        <td height="24px" class="auto-style4"><asp:Label ID="lb_Lifetime" runat="server"></asp:Label></td>
     <td bgcolor="Lavender"width="50px" height="24px">เดือน</td>
    </tr>



    <tr>
        <td  bgcolor="Lavender" width="197px" height="28px">เดือน : </td>
        <td height="24px" class="auto-style4"><asp:Label ID="lb_Month" runat="server"></asp:Label></td>
        <td bgcolor="Lavender"width="50px" height="24px">วัน</td>
        <td width="530px" height="24px"> <asp:Label ID="lb_day" runat="server"></asp:Label></td></td>
    </tr>

<tr>
        <td  bgcolor="Lavender" width="197px" height="28px">สภาวะการเก็บรักษา:</td>
        <td colspan ="3" width="530px" height="24px"><asp:Label ID="lb_Storage_conditions" runat="server"></asp:Label></td>

  </tr>



    <tr>
        <td  bgcolor="Lavender" width="197px" height="28px">ลักษณะยา : </td>
        <td colspan ="3" width="530px" height="24px"><asp:Label ID="lb_nature_medicine" runat="server"></asp:Label></td>
    </tr>


    </tr>
</table>
