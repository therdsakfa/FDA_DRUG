<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_DS_STAFF_REMARK2.aspx.vb" Inherits="FDA_DRUG.FRM_DS_STAFF_REMARK2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>เงื่อนไขการอนุญาต </h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>เงื่อนไขการอนุญาต&nbsp;</td><td>
                        <asp:TextBox ID="Txt_Remark" runat="server" CssClass="input-sm" Width="400px"></asp:TextBox>
                        </td></tr>

                    <tr ><td>วันที่</td><td>
                        <asp:TextBox ID="txt_app_date" runat="server" class="input-sm" Width="120px"></asp:TextBox></td></tr>

                </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>
