<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_ADD_NEW_BSN.aspx.vb" Inherits="FDA_DRUG.FRM_ADD_NEW_BSN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<%@ Register src="UC/UC_BSN_ADD_NEW.ascx" tagname="UC_BSN_ADD_NEW" tagprefix="uc1" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">

        <div class="panel-heading panel-title">
                <h1>เพิ่มผู้ดำเนินกิจการ</h1>
            </div>
    <table style="width:100%;" class="table">
        <tr>

            <td align="center">
                
                
                <uc1:UC_BSN_ADD_NEW ID="UC_BSN_ADD_NEW1" runat="server" />
            </td>
           
        </tr>
        </table>

        <div class="panel-footer " style="text-align:center;">
       <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" Width="120px" OnClientClick="confirm('คุณต้องการบันทึกข้อมูลหรือไม่');" />
                <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" Width="120px"/>
        </div>
        </div>
</asp:Content>