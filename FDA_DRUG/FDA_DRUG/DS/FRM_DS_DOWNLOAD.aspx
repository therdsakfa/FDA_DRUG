<%@ Page Title="" Language="vb" AutoEventWireup="false"  CodeBehind="FRM_DS_DOWNLOAD.aspx.vb" Inherits="FDA_DRUG.WebForm29" %>

<%@ Register Src="~/DS/UC/UC_DS_DOWNLOAD_PDF.ascx" TagPrefix="uc1" TagName="UC_DS_DOWNLOAD_PDF" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UC_DS_DOWNLOAD_PDF runat="server" ID="UC_DS_DOWNLOAD_PDF" />
</asp:Content>
