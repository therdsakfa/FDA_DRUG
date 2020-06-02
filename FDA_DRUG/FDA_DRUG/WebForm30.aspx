<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm30.aspx.vb" Inherits="FDA_DRUG.WebForm30" %>

<%@ Register src="DS/UC/UC_DS_DOWNLOAD_PDF.ascx" tagname="UC_DS_DOWNLOAD_PDF" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <uc1:UC_DS_DOWNLOAD_PDF ID="UC_DS_DOWNLOAD_PDF1" runat="server" />
    </form>
</body>
</html>
