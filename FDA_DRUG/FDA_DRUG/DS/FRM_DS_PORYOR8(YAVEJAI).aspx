<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_DS_PORYOR8(YAVEJAI).aspx.vb" Inherits="FDA_DRUG.FRM_DS_PORYOR8_YAVEJAI_" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/DS/UC/US_DS_PORYOR8(YAVEJAI).ascx" TagPrefix="uc1" TagName="US_DS_PORYOR8YAVEJAI" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <uc1:US_DS_PORYOR8YAVEJAI runat="server" ID="US_DS_PORYOR8YAVEJAI" />
        </div>
    </form>
</body>
</html>
