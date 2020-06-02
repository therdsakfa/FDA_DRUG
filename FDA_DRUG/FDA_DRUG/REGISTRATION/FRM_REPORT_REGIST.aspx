<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_REPORT_REGIST.aspx.vb" Inherits="FDA_DRUG.FRM_REPORT_REGIST" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <table width="100%">
        <tr>
            <td>

                &nbsp;</td>
        </tr>
    </table>
    <table style="width: 100%; height: 500px;">
        <tr>
            <td rowspan="2" style="width: 60%;" valign="top">

                <%--<uc1:UC_CONFIRM ID="UC_CONFIRM1" runat="server" />--%>
                <div style="width:60%">

                <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server">
                </rsweb:ReportViewer>--%>
                    
                </div>
                <asp:Literal ID="lr_preview" runat="server" ></asp:Literal>
            </td>
            <td style="padding-left: 10%; height: 50%;">

                <table class="table" style="width: 90%">

                    <tr>
                        <td>
                            <asp:Button ID="btn_confirm" runat="server" Text="ยื่นคำขอ" CssClass="btn-lg" Width="80%" OnClientClick="return confirm('ต้องการส่งข้อมูลหรือไม่');" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg" Width="80%" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg" Width="80%" /></td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                    </tr>

                </table>



            </td>
        </tr>
        <tr>
            <td style="width: 30%; height: 50%; padding-left: 10%">

                &nbsp;</td>
        </tr>
    </table>


</asp:Content>
