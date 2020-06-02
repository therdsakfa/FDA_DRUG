<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_EQTO.aspx.vb" Inherits="FDA_DRUG.FRM_EQTO" %>

<%@ Register Src="~/TABEAN_YA/UC/UC_EQTO.ascx" TagPrefix="uc1" TagName="UC_EQTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <uc1:UC_EQTO runat="server" ID="UC_EQTO" />
</asp:Content>
