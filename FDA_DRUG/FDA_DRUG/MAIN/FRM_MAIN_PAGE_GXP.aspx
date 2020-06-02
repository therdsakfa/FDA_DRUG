<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_GXP.Master" CodeBehind="FRM_MAIN_PAGE_GXP.aspx.vb" Inherits="FDA_DRUG.FRM_MAIN_PAGE_GXP" %>

<%@ Register src="../UC/UC_NEWS.ascx" tagname="UC_NEWS" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <uc1:UC_NEWS ID="UC_NEWS1" runat="server" />

        </asp:Content>