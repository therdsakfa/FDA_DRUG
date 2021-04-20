<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_ASSIGN_STAFF.aspx.vb" Inherits="FDA_DRUG.POPUP_ASSIGN_STAFF" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>เพิ่มเจ้าหน้าที่ผู้รับผิดชอบคำขอ<asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        </h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    
                    <tr ><td>ค้นหาชื่อเจ้าหน้าที่</td><td>
                        <asp:TextBox ID="txt_consider_iden" runat="server"  Width="270px"></asp:TextBox>
                  <asp:Button ID="btn_search" runat="server" Text="ค้นหา" CssClass="btn-lg" />
                        </td></tr>

                    <tr ><td>เลือกชื่อเจ้าหน้าที่</td><td>
          
                        <telerik:RadComboBox ID="rcb_name" Runat="server" DataValueField="identify" DataTextField="thanm">
                        </telerik:RadComboBox>
                        </td></tr>
                      
                </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ปิดหน้าต่าง"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>
