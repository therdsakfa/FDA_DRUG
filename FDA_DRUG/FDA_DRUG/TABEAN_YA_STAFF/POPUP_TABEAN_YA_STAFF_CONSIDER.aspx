<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_TABEAN_YA_STAFF_CONSIDER.aspx.vb" Inherits="FDA_DRUG.POPUP_TABEAN_YA_STAFF_CONSIDER" %>
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

                 <%--   <tr ><td>ชื่อผู้ลงนาม </td><td>
                        <asp:DropDownList ID="ddl_staff_offer" runat="server" DataTextField="STAFF_OFFER_NAME" DataValueField="IDA" CssClass="input-lg" Width="200px">
                        </asp:DropDownList>
                        </td></tr>--%>
                    <tr ><td>ประเภททะเบียน</td><td>
                        <asp:DropDownList ID="ddl_rgttpcd" runat="server">
                        </asp:DropDownList>
                        </td></tr>

                    <tr ><td>วงเล็บ(ถ้ามี)</td><td>
                        <asp:DropDownList ID="ddl_tabean_group" runat="server">
                        </asp:DropDownList>
                        </td></tr>
                    <tr ><td>เลขทะเบียน</td><td>
                        <asp:TextBox ID="Txt_rcvno_no" runat="server" class="input-lg"></asp:TextBox>
                        ( ตัวอย่าง 1/62)</td></tr>

                    <tr ><td>วันที่เสนอลงนาม</td><td>
                        <asp:TextBox ID="TextBox1" runat="server" class="input-lg"></asp:TextBox></td></tr>

                    </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>
