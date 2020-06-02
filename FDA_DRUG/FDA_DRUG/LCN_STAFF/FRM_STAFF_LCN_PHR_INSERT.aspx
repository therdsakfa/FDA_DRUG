<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_PHR_INSERT.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_LCN_PHR_INSERT" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register src="../EDIT_LOCATION_STAFF/UC/UC_PHR_ADD.ascx" tagname="UC_PHR_ADD" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">

        <div class="panel-heading panel-title">
                <h1>ข้อมูลผู้ปฏิบัติงาน</h1>
            </div>
    <table style="width:100%;" class="table">
        <tr>

            <td align="center">
                
         
                <uc1:UC_PHR_ADD ID="UC_PHR_ADD1" runat="server" />
                
         
            </td>
           
        </tr>
        </table>

        <div class="panel-footer " style="text-align:center;">
       <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" Width="120px" OnClientClick="confirm('คุณต้องการบันทึกข้อมูลหรือไม่');" />
                <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" Width="120px"/>
        </div>
        </div>
</asp:Content>
