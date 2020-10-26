<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_OFFER_INSERT_AND_UPDATE.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_OFFER_INSERT_AND_UPDATE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>เสนอลงนาม
                </h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>ชื่อ - นามสกุล</td><td>
                        <asp:TextBox ID="Txt_Name" runat="server" CssClass="input-lg" Width="300px"></asp:TextBox>
                        </td></tr>

                    <tr ><td>ตำแหน่ง</td><td>
                        <asp:TextBox ID="Txt_POSITION" runat="server" CssClass="input-lg" Width="300px"></asp:TextBox>
                        </td></tr>

                    </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" style="display:none;" />
                  &nbsp;&nbsp;
                  <asp:Button ID="btn_edit" runat="server" Text="แก้ไข"  CssClass="btn-lg" style="display:none;"/>
              </div>
        </div>
</asp:Content>
