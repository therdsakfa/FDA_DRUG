<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_E_TRACKING_STAFF_ASIGN_INSERT.aspx.vb" Inherits="FDA_DRUG.FRM_E_TRACKING_STAFF_ASIGN_INSERT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>เพิ่มเจ้าหน้าที่
                </h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>หมายเลขบัตรประชาชน</td><td>
                        <asp:TextBox ID="Txt_CITIZENID" runat="server" CssClass="input-lg" Width="300px"></asp:TextBox>
                        </td></tr>
                    <tr>
                        <td>หน้าที่รับผิดชอบ</td>
                        <td>
                            <asp:DropDownList ID="ddl_process" runat="server" CssClass="input-sm" Width="300px">
                                <asp:ListItem Value="11">ทะเบียนตำรับยา</asp:ListItem>
                              <%--  <asp:ListItem Value="7">ยาตัวอย่าง</asp:ListItem>--%>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  <asp:Button ID="btn_edit" runat="server" Text="แก้ไข"  CssClass="btn-lg" style="display:none;"/>
              </div>
        </div>
</asp:Content>
