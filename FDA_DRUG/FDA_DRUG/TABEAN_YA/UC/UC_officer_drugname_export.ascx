<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_officer_drugname_export.ascx.vb" Inherits="FDA_SEARCH_DRUG.officer_export" %>
  <style type="text/css">
      .auto-style1 {
          width: 126px;
      }
  </style>
 <table style="background-color: white; width: 1130px; height: 40px;">
   <tr>
        <td  bgcolor="Lavender" width="197px" height="28px">ชื่อยาส่งออก:</td>
        <td >
            <asp:Label ID="lb_drgexp" runat="server"></asp:Label></td>
    </tr>



    <tr>
        <td  bgcolor="Lavender" width="197px" height="28px">ประเทศยาส่งออก : </td>
        <td >
            <asp:Label ID="lb_drgexp_cntcd" runat="server"></asp:Label></td>
    </tr>
   
</table>