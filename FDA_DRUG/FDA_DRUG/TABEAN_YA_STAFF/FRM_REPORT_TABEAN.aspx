<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_REPORT_TABEAN.aspx.vb" Inherits="FDA_DRUG.FRM_REPORT_TABEAN" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table width="100%">
        <tr>
            <td>

               <%-- <rsweb:ReportViewer ID="ReportViewer1" runat="server">
                </rsweb:ReportViewer>--%>
                <asp:Literal ID="lr_preview" runat="server" ></asp:Literal>
            </td>
        </tr>
    </table>
</asp:Content>
