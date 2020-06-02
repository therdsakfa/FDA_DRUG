<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_PROFESSIONAL_INSERT_AND_UPDATE.aspx.vb" Inherits="FDA_DRUG.FRM_PROFESSIONAL_INSERT_AND_UPDATE" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">

        <div class="panel-heading panel-title">
                <h1>ผู้เชี่ยวชาญ</h1>
            </div>
    <table style="width:100%;" class="table">
        <tr>

            <td align="right">
                คำนำหน้าชื่อ :
            </td>
           <td>
               <asp:DropDownList ID="ddl_prefix" runat="server" DataTextField ="thanm" DataValueField="prefixcd"></asp:DropDownList>
           </td>
        </tr>
        <tr>

            <td align="right">
                ชื่อ-นามสกุล :</td>
           <td>
               <asp:TextBox ID="txt_name" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
           </td>
        </tr>
        <%--<tr>

            <td align="right">
                นามสกุล :</td>
           <td>
               <asp:TextBox ID="txt_SURNAME" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>

            <td align="right">
                เลขบัตรประชาชน</td>
           <td>
               <asp:TextBox ID="txt_CITIZEN_ID" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
            </td>
        </tr>
        </table>

        <div class="panel-footer " style="text-align:center;">
       <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" Width="120px" />
                <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" Width="120px"/>
        </div>
        </div>
</asp:Content>