<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_HERB_INSERT_AND_UPDATE.aspx.vb" Inherits="FDA_DRUG.POPUP_HERB_INSERT_AND_UPDATE" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="UC/UC_HERB_CHEM.ascx" tagname="UC_HERB_CHEM" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <div class="panel-heading panel-title">
                <h1>เพิ่มสารสมุนไพร
                </h1>
            </div>
            <div class="panel-body" width="100%">

                <table class="table" width="100%">
                    <tr ><td>
                        <uc1:UC_HERB_CHEM ID="UC_HERB_CHEM1" runat="server" />
                        </td></tr>
                    <tr>
                        <td">
                            &nbsp;</td>
                    </tr>
                    
                    </table>
            </div>
              
        </div>
 <div class="panel-footer">
        <center>
                   <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg"/>
        </center>
        
    </div>
</asp:Content>
