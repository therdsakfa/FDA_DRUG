<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_EDIT.Master" CodeBehind="FRM_CHANGE_DRUG_GROUP.aspx.vb" Inherits="FDA_DRUG.FRM_CHANGE_DRUG_GROUP" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="~/EDIT_LOCATION_STAFF/UC/UC_TABLE_DRUG_GROUP_CHANGE.ascx" TagPrefix="uc1" TagName="UC_TABLE_DRUG_GROUP_CHANGE" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:UC_TABLE_DRUG_GROUP_CHANGE runat="server" id="UC_TABLE_DRUG_GROUP_CHANGE" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            
        </ContentTemplate>

        <Triggers>
           <%-- <asp:PostBackTrigger ControlID="btn_SAVE" />--%>
           <%-- <asp:AsyncPostBackTrigger ControlID ="btn_SAVE" />--%>
        </Triggers>
        </asp:UpdatePanel>
      
      <br />
    <asp:Button ID="btn_save" runat="server" Text="บันทึก" />
</asp:Content>
