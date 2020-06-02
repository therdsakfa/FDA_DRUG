<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_RCV_MANUAL.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_LCN_RCV_MANUAL" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>ระบุเลขรับ</h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>เลขรับคำขอ/เลขตรวจคำขอ</td><td>
                        <asp:TextBox ID="Txt_rcvno_temp" runat="server" CssClass="input-lg"></asp:TextBox>
                        </td></tr>

                    <tr ><td>เลขรับ</td><td>
                        <asp:TextBox ID="Txt_rcvno" runat="server" CssClass="input-lg"></asp:TextBox>
                        </td></tr>

                   <tr ><td>วันที่</td><td>
                        <asp:TextBox ID="txt_rcvdate" runat="server" CssClass="input-lg"></asp:TextBox>
                        </td></tr>

                 <%--  <tr ><td>ผู้รับคำขอ</td><td>
                        <asp:DropDownList ID="ddl_receiver" runat="server"  Width="70%">
                        </asp:DropDownList>
                        </td>

                   </tr>--%>

                   <tr ><td>จนท.ผู้รับคำขอ</td><td>
                        <asp:Label ID="lbl_name_staff" runat="server" Text="-"></asp:Label>
                        </td></tr>

                   <tr ><td><asp:Label ID="Label1" runat="server" Text="รูปแบบเอกสาร" style="display:none;"></asp:Label>
                       </td><td>
                        <asp:DropDownList ID="ddl_template" runat="server" Width="80%" style="display:none;">
                            <asp:ListItem Value="1">แบบปกติ</asp:ListItem>
                            <asp:ListItem Value="2">แบบยาว</asp:ListItem>
                        </asp:DropDownList>
                        </td></tr>
                </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>
