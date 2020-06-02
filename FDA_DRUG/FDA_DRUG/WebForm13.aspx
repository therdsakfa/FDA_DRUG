<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_PPK.Master" CodeBehind="WebForm13.aspx.vb" Inherits="FDA_DRUG.WebForm13" %>

<%@ Register src="UC/UC_INFMT.ascx" tagname="UC_INFMT" tagprefix="uc1" %>

<%@ Register src="EDIT_LOCATION_STAFF/UC/UC_TABLE_DRUG_GROUP_CHANGE.ascx" tagname="UC_TABLE_DRUG_GROUP_CHANGE" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
   
    <uc1:UC_INFMT ID="UC_INFMT1" runat="server" />
    <uc2:UC_TABLE_DRUG_GROUP_CHANGE ID="UC_TABLE_DRUG_GROUP_CHANGE1" runat="server" />
    <asp:Button ID="Button1" runat="server" Text="Button" />
    <br />
    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width ="100%" Height="150px"></asp:TextBox>
</asp:Content>