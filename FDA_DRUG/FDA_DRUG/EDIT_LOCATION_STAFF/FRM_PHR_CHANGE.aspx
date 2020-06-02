<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_PHR_CHANGE.aspx.vb" Inherits="FDA_DRUG.FRM_PHR_CHANGE" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="UC/UC_PHR_ADD.ascx" tagname="UC_PHR_ADD" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">

        <div class="panel-heading panel-title">
                <h1>เปลี่ยนผู้ปฏิบัติงาน</h1>
            </div>
    <table style="width:100%;" class="table">
        <tr>
            <td align="center">
                เปลี่ยนผู้ปฏิบัติงานจาก &nbsp; <asp:Label ID="lb_old_phr" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>

            <td align="center">
                ผู้ปฏิบัติงานคนใหม่
                <uc1:UC_PHR_ADD ID="UC_PHR_ADD1" runat="server" />
                
            </td>
           
        </tr>
        </table>

        <div class="panel-footer " style="text-align:center;">
       <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" Width="120px" />
                <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" Width="120px"/>
        </div>
        </div>
</asp:Content>
