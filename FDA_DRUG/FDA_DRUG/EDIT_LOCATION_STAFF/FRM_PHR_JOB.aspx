<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_PHR_JOB.aspx.vb" Inherits="FDA_DRUG.FRM_PHR_JOB" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">

        <div class="panel-heading panel-title">
                <h1>หน้าที่ผู้ปฏิบัติงาน</h1>
            </div>
    <table style="width:100%;" class="table">
        <tr>
<td>
    หน้าที่เดิม</td>     
         <td>
             <asp:Label ID="lbl_old_job" runat="server" Text="-"></asp:Label>
         </td>     
        </tr>
        <tr>
<td>
    หน้าที่
</td>     
         <td>
             <asp:DropDownList ID="ddl_job" runat="server"></asp:DropDownList>
         </td>     
        </tr>
        </table>

        <div class="panel-footer " style="text-align:center;">
       <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" Width="120px" />
                <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" Width="120px"/>
        </div>
        </div>
</asp:Content>