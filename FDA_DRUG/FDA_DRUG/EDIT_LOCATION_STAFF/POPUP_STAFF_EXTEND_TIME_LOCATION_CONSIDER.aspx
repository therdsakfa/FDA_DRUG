<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_STAFF_EXTEND_TIME_LOCATION_CONSIDER.aspx.vb" Inherits="FDA_DRUG.POPUP_STAFF_EXTEND_TIME_LOCATION_CONSIDER" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>เสนอลงนาม</h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>หมายเหตุ</td><td>
                        <asp:TextBox ID="Txt_Remark" runat="server" CssClass="input-lg"></asp:TextBox>
                        </td></tr>

                    <tr ><td>วันที่เสนอลงนาม</td><td>
                        <asp:TextBox ID="TextBox1" runat="server" class="input-lg"></asp:TextBox></td></tr>

                    <tr ><td>วันที่คาดว่าจะอนุมัติ</td><td>
                        <asp:TextBox ID="txt_app_date" runat="server" class="input-lg"></asp:TextBox></td></tr>

                </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  </div>
        </div>
</asp:Content>