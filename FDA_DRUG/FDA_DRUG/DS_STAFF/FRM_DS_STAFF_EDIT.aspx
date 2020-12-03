<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_DS_STAFF_EDIT.aspx.vb" Inherits="FDA_DRUG.FRM_DS_STAFF_EDIT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
    <style type="text/css">
        .auto-style1 {
            font-size: 12px;
            line-height: 1.5;
            border-radius: 3px;
            padding: 5px 10px;
        }
    </style>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>หมายเหตุการแก้ไข</h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>หมายเหตุ</td><td>
                        <asp:TextBox ID="Txt_EDIT" runat="server" CssClass="auto-style1" Width="400px" Height="211px"></asp:TextBox>
                        </td></tr>

                    <tr ><td>วันที่</td><td>
                        <asp:TextBox ID="txt_lmdfdate" runat="server" class="input-sm" Width="120px"></asp:TextBox></td></tr>

                </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>

