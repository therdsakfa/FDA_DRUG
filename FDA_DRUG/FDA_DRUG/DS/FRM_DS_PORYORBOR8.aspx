<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_DS_PORYORBOR8.aspx.vb" Inherits="FDA_DRUG.FRM_DS_PORYORBOR8_" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/DS/UC/UC_DS_PORYORBOR8.ascx" TagPrefix="uc1" TagName="UC_DS_PORYORBOR8" %>






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
            <uc1:UC_DS_PORYORBOR8 runat="server" id="UC_DS_PORYORBOR8" />
        </div>
    </form>
</body>
</html>
