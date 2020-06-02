<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_CONSIDER_UPDATE.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_LCN_CONSIDER_UPDATE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>เสนอลงนาม</h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr>
                        <td>หมายเหตุ</td>
                        <td>
                            <asp:TextBox ID="Txt_Remark" runat="server" CssClass="input-lg"></asp:TextBox>
                        </td>
                    </tr>

                    <tr>
                        <td>ชื่อผู้ลงนาม </td>
                        <td>
                            <asp:DropDownList ID="ddl_staff_offer" runat="server" DataTextField="STAFF_OFFER_NAME" DataValueField="IDA" CssClass="input-lg" Width="200px">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr>
                        <td>วันที่เสนอลงนาม</td>
                        <td>

                            <asp:TextBox ID="TextBox1" runat="server" CssClass="input-lg"></asp:TextBox>


                        </td>
                    </tr>

                    <tr>
                        <td>วันที่คาดว่าจะอนุมัติ</td>
                        <td>
                            <asp:TextBox ID="txt_app_date" runat="server" CssClass="input-lg"></asp:TextBox></td>
                    </tr>

                </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
              </div>
        </div>
</asp:Content>

