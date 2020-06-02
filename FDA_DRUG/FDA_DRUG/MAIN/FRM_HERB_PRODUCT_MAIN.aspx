<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_HERB_PRODUCT_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_HERB_PRODUCT_MAIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css" >
        /*.button {
  background-color: #4CAF50;
  border: none;
  color: white;
  padding: 20px;
  text-align: center;
  text-decoration: none;
  display: inline-block;
  font-size: 16px;
  margin: 4px 2px;
}*/

.btn_food {border-radius: 12px;}
.btn_drug {border-radius: 12px;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table width="100%">
    <tr>
        <td align="center">
            <asp:Button ID="btn_food" runat="server" Text="ผลิตภัณฑ์สมุนไพรเพื่อสุขภาพ" class="btn btn-green" style="color:DarkBlue;width:350px;height:210px;border-radius: 12px; border:solid; border-width:thin; border-color:lightgreen;" />
        </td>
        
    </tr>
        <tr>
<td align="center">
            <asp:Button ID="btn_drug" runat="server" Text="ผลิตภัณฑ์ยาจากสมุนไพร" class="btn btn-green" style="color:DarkBlue;width:350px;height:210px;border-radius: 12px; border:solid; border-width:thin; border-color:lightgreen;" />
        </td>
        </tr>
</table>

</asp:Content>
