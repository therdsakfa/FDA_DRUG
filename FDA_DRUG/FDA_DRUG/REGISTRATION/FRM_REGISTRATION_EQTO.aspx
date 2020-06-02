<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_REGISTRATION_EQTO.aspx.vb" Inherits="FDA_DRUG.FRM_REGISTRATION_EQTO" %>

<%@ Register Src="~/REGISTRATION/UC/UC_CHEM_EQTO.ascx" TagPrefix="uc1" TagName="UC_CHEM_EQTO" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <uc1:UC_CHEM_EQTO runat="server" id="UC_CHEM_EQTO" />

</asp:Content>
