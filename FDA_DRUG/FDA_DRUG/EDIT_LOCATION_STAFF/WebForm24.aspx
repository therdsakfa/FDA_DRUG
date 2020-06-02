<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm24.aspx.vb" Inherits="FDA_DRUG.WebForm24" %>

<%@ Register Src="~/EDIT_LOCATION_STAFF/UC/UC_TABLE_DRUG_GROUP_CHANGE.ascx" TagPrefix="uc1" TagName="UC_TABLE_DRUG_GROUP_CHANGE" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <uc1:UC_TABLE_DRUG_GROUP_CHANGE runat="server" ID="UC_TABLE_DRUG_GROUP_CHANGE" />
        <asp:Button ID="Button1" runat="server" Text="Button" />
    </div>
    </form>
</body>
</html>
