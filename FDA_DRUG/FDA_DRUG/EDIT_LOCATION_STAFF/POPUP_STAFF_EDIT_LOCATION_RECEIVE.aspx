<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_STAFF_EDIT_LOCATION_RECEIVE.aspx.vb" Inherits="FDA_DRUG.POPUP_STAFF_EDIT_LOCATION_RECEIVE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>รับคำขอแก้ไข</h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>เลขรับ</td><td>
                        <asp:TextBox ID="Txt_RCVNO" runat="server" CssClass="input-sm" Width="400px"></asp:TextBox>
                        </td></tr>

                    <tr ><td>เลขรับชั่วคราว</td><td>
                        <asp:TextBox ID="Txt_RCV_MEETING" runat="server" CssClass="input-sm" Width="400px"></asp:TextBox>
                        </td></tr>

                    <tr ><td>วันที่</td><td>
                        <asp:TextBox ID="txt_rcvdate" runat="server" class="input-sm" Width="120px"></asp:TextBox></td></tr>

                </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  </div>
        </div>
</asp:Content>