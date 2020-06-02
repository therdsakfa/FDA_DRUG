<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_REPORT_BEHIND.aspx.vb" Inherits="FDA_DRUG.FRM_REPORT_BEHIND" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Button ID="Button1" runat="server" Text="Export to Word" />
   <table>
        <tr>
            <td>รายการแก้ไขเปลี่ยนแปลงใบอนุญาต</td>
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
