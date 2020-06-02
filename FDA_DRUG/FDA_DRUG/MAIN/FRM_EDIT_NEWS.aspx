<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_NODE_EDIT.Master" CodeBehind="FRM_EDIT_NEWS.aspx.vb" Inherits="FDA_DRUG.WebForm18" %>

<%@ Register Src="~/UC/UC_NEWS.ascx" TagPrefix="uc1" TagName="UC_NEWS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UC_NEWS runat="server" id="UC_NEWS" />
</asp:Content>
