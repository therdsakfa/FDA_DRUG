<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm27.aspx.vb" Inherits="FDA_DRUG.WebForm271" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/DS/UC/UC_DS_YORBOR8.ascx" TagPrefix="uc1" TagName="UC_DS_YORBOR8" %>
<%@ Register Src="~/DS/UC/UC_DS_YORBOR5.ascx" TagPrefix="uc1" TagName="UC_DS_YORBOR5" %>
<%@ Register Src="~/DS/UC/UC_DS_NORYOR8.ascx" TagPrefix="uc1" TagName="UC_DS_NORYOR8" %>
<%@ Register Src="~/DS/UC/UC_DS_PORYOR8.ascx" TagPrefix="uc1" TagName="UC_DS_PORYOR8" %>




<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
            </telerik:RadScriptManager>
            <%--<uc1:UC_DS_YORBOR8 runat="server" ID="UC_DS_YORBOR8" />--%>
         <%--   <uc1:UC_DS_YORBOR5 runat="server" id="UC_DS_YORBOR5" />--%>
            <%--<uc1:UC_DS_NORYOR8 runat="server" ID="UC_DS_NORYOR8" />--%>
            <uc1:UC_DS_PORYOR8 runat="server" ID="UC_DS_PORYOR8" />
        </div>
    </form>
</body>
</html>
