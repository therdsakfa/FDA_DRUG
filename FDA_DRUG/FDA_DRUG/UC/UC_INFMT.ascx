<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_INFMT.ascx.vb" Inherits="FDA_DRUG.UC_INFMT" %>

  <table style="width:100%;">
        <tr>
            <td style="width:20%;">

                <asp:Label ID="Label1" runat="server" Text="Label">วันที่รับ </asp:Label>
               

                :</td>
 <td >

                    <asp:Label ID="txt_date" runat="server" ></asp:Label>

                </td>
            <td style="width:20%;" >

                <asp:Label ID="Label2" runat="server" >ชื่อสถานที่ </asp:Label>
                :</td>
            <td >
                    <asp:Label ID="txt_addrnm" runat="server" ></asp:Label>
                </td>
          
               
        </tr>
        <tr  >
  <td >
                
                <asp:Label ID="Label3" runat="server" Text="Label">ที่อยู่ </asp:Label>
               

                :</td>
             <td  colspan="3">
                    <asp:Label ID="txt_addr" runat="server" ></asp:Label>

                </td>
                </tr>
        </table>
