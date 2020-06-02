<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_EDIT_PRODUCTION_INSERT_AND_UPDATE.aspx.vb" Inherits="FDA_DRUG.FRM_EDIT_PRODUCTION_INSERT_AND_UPDATE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel" style="width:100%">
          <div class="panel-heading panel-title">
                <h1>คำขอแก้ไข</h1>
            </div>

    <table class="table" width="100%">
        <tr>
            <td align="right">
                เขียนที่ :</td>
            <td>
               <asp:TextBox ID="txt_WRITE_AT" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                วันที่ :</td>
            <td>
               <asp:TextBox ID="txt_WRITE_DATE" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                เลขที่ใบอนุญาต :</td>
            <td>
                <asp:DropDownList ID="ddl_lcnno" runat="server" CssClass="input-sm" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>

        <tr>
            <td align="right">
                ขอเปลี่ยนแปลงรายการในใบอนุญาต ดังต่อไปนี้</td>
            <td>
               <asp:TextBox ID="txt_REMARK" runat="server" CssClass="input-sm" Width="400px" Height="100px" TextMode="MultiLine"></asp:TextBox>
            </td>
        </tr>

    </table>

    <div class="panel-footer " style="text-align:center;">
        <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" />
        </div>

       </div>  
</asp:Content>