<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_NYM_CONSIDER_NEW.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_NYM_CONSIDER_NEW" %>

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

                    <tr ><td>ชื่อผู้ลงนาม </td><td>
                        <asp:DropDownList ID="ddl_staff_offer" runat="server" DataTextField="STAFF_OFFER_NAME" DataValueField="IDA" CssClass="input-lg" Width="200px">
                        </asp:DropDownList>
                        </td></tr>
                      <tr ><td>ตำแหน่งแถวที่ 1</td><td>
                        <asp:TextBox ID="TextBox6" runat="server" CssClass="input-lg" Width="397px"></asp:TextBox>
                        </td></tr>
                    <tr ><td>ตำแหน่งแถวที่ 2</td><td>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="input-lg" Width="398px"></asp:TextBox>
                        </td></tr>
                    <tr ><td>ตำแหน่งแถวที่ 3</td><td>
                        <asp:TextBox ID="TextBox3" runat="server" CssClass="input-lg" Width="395px"></asp:TextBox>
                        </td></tr>
                    <tr ><td>ตำแหน่งแถวที่ 4</td><td>
                        <asp:TextBox ID="TextBox4" runat="server" CssClass="input-lg" Width="392px"></asp:TextBox>
                        </td></tr>
                    <tr ><td>ตำแหน่งแถวที่ 5</td><td>
                        <asp:TextBox ID="TextBox5" runat="server" CssClass="input-lg" Width="389px"></asp:TextBox>
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
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>
