<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_REPORT_PRE4.aspx.vb" Inherits="FDA_DRUG.FRM_REPORT_PRE4" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
   <table>
        <tr>
            <td>
                <asp:TextBox ID="txt_startdate" runat="server"></asp:TextBox>
                <asp:TextBox ID="txt_enddate" runat="server"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="Button" />
            </td>
        </tr>
        <tr>
            <td>
                <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
