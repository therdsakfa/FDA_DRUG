<%@ Page Language="vb" AutoEventWireup="false"MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_REPORT_PROCESS.aspx.vb" Inherits="FDA_DRUG.FRM_REPORT_PROCESS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div >
         <div class="panel-heading panel-title" style="padding-left:5%;">
            <h2>รายงาน</h2>
        <h4> <asp:Label ID="lbl_systemID" runat="server" Text=""></asp:Label></h4>
    </div> 
        <div style="text-align:center;">

            <%--<asp:Label ID="Label1" runat="server" CssClass="badge" Text="" vi Font-Size="XX-Large"></asp:Label>--%>
        </div>
        <div  style="text-align:center;">
        <asp:Button ID="btn_2" runat="server" Width="30%" Text="ใบอนุญาตสถานที่" CssClass="btn-lg"   BorderStyle="None"  />
           
            <hr />
             </div>
    </div>
    
</asp:Content>
