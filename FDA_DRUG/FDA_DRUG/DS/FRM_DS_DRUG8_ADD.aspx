<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FRM_DS_DRUG8_ADD.aspx.vb" Inherits="FDA_DRUG.FRM_DS_DRUG8_ADD" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/DS/UC/UC_DS_DRUG8_ADD.ascx" TagPrefix="uc1" TagName="UC_DS_DRUG8_ADD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<body>
    <form id="form1" runat="server">
        <div>

            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <uc1:UC_DS_DRUG8_ADD runat="server" id="UC_DS_DRUG8_ADD" />
        </div>
    </form>
</body>
</html>
  <%--  </asp:Content>--%>