<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_SUB_DRUG_ANIMAL.aspx.vb" Inherits="FDA_DRUG.FRM_SUB_DRUG_ANIMAL" %>
<%@ Register src="UC/UC_SUB_DRUG_ANIMAL.ascx" tagname="UC_SUB_DRUG_ANIMAL" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        ส่วนบริโภค
    </h2>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <uc1:UC_SUB_DRUG_ANIMAL ID="UC_SUB_DRUG_ANIMAL1" runat="server" />

</asp:Content>
