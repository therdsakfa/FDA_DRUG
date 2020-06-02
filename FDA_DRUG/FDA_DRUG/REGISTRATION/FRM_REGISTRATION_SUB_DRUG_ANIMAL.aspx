<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_REGISTRATION_SUB_DRUG_ANIMAL.aspx.vb" Inherits="FDA_DRUG.FRM_REGISTRATION_SUB_DRUG_ANIMAL" %>

<%@ Register src="UC/UC_ANIMAL_SUB.ascx" tagname="UC_ANIMAL_SUB" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        ส่วนบริโภค
    </h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>


    <uc1:UC_ANIMAL_SUB ID="UC_ANIMAL_SUB1" runat="server" />


</asp:Content>