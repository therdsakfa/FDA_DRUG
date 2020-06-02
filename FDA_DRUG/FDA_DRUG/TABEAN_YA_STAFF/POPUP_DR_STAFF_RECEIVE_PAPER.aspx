<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DR_STAFF_RECEIVE_PAPER.aspx.vb" Inherits="FDA_DRUG.POPUP_DR_STAFF_RECEIVE_PAPER" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>ระบุเลขรับ C,A และประเภททะเบียน</h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    
                    <tr ><td>เลข C,A (อย่างใดอย่างหนึ่ง)</td><td>
                        <asp:TextBox ID="Txt_rcvno_temp" runat="server" CssClass="input-lg"></asp:TextBox>
                        </td></tr>

                    <tr ><td>ประเภทการขึ้นทะเบียน</td><td>
                        <asp:DropDownList ID="ddl_tabean_group" runat="server">
                        </asp:DropDownList>
                        </td></tr>

                    <tr ><td>ประเภทคำขอขึ้นทะเบียน</td><td>
                        <asp:DropDownList ID="ddl_rgttpcd" runat="server">
                        </asp:DropDownList>
                        </td></tr>

                   <tr ><td>วันที่รับ</td><td>
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
                            <asp:ListItem Value="2">แบบที่ 1</asp:ListItem>
                        </asp:DropDownList>
                        </td></tr>
                </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" OnClientClick="return confirm('ต้องการรับคำขอหรือไม่?');" />
                  &nbsp;&nbsp;
                  <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>
