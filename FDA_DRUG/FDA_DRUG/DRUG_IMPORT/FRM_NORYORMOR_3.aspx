<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_NORYORMOR_3.aspx.vb" Inherits="FDA_DRUG.FRM_NORYORMOR_3" %>

<%@ Register Src="~/DS/UC/UC_DS_NORYORMOR2.ascx" TagPrefix="uc1" TagName="UC_DS_PORYOR8" %>
<%@ Register Src="~/DS/UC/UC_DS_CHECAL_DETAIL.ascx" TagPrefix="uc1" TagName="UC_DS_CHECAL_DETAIL" %>



<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>



<%@ Register src="~/DS/UC/UC_DS_NORYORMOR3.ascx" tagname="UC_DS_NORYORMOR3" tagprefix="uc2" %>



<%@ Register src="~/DS/UC/UC_DS_NORYORMOR4.ascx" tagname="UC_DS_NORYORMOR4" tagprefix="uc3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <%--นยม3--%>
        <uc2:UC_DS_NORYORMOR3 ID="UC_DS_NORYORMOR31" runat="server" />
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
</asp:Content>


<%--<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>--%>
        

        <%--นยม1--%>
        <%--<uc4:UC_DS_NORYORMOR1 ID="UC_DS_NORYORMOR11" runat="server" />--%>

        <%--นยม2--%>
        <%--<uc1:UC_DS_PORYOR8 ID="UC_DS_PORYOR81" runat="server" />--%>

        

        <%--นยม4--%>
        <%--<uc3:UC_DS_NORYORMOR4 ID="UC_DS_NORYORMOR41" runat="server" />--%>

        <%--นยม5--%>
        <%--<uc5:UC_DS_NORYORMOR5 ID="UC_DS_NORYORMOR51" runat="server" />--%>


<%--    </div>
        
    </form>
</body>
</html>--%>
