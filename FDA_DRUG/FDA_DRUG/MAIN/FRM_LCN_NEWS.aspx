<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Auto_Menu.Master" CodeBehind="FRM_LCN_NEWS.aspx.vb" Inherits="FDA_DRUG.WebForm19" %>

<%@ Register Src="~/UC/UC_NEWS.ascx" TagPrefix="uc1" TagName="UC_NEWS" %>

<%@ Register src="../UC/UC_Information.ascx" tagname="UC_Information" tagprefix="uc3" %>

<%@ Register src="../UC/UC_INFMT.ascx" tagname="UC_INFMT" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <uc4:UC_INFMT ID="UC_INFMT1" runat="server" />

       <uc1:UC_NEWS runat="server" id="UC_NEWS" />
</asp:Content>
