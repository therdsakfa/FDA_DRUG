<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_PD_REPORT.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_PD_REPORT" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>รายงานโครงการวิจัย</h1>
            </div>
            <div class="panel-body">
                
                รายละเอียด/หมายเหตุ.
                <asp:TextBox ID="TextBox1" runat="server" Width="100%" TextMode="MultiLine" Height="100px"></asp:TextBox>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <center>
                    <asp:Button ID="Button3" runat="server" Text="อัพโหลดรายงาน" CssClass="btn-lg" />
                </center>
            </div>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
              <%--<div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก"  CssClass="btn-lg"/>
              </div>--%>
        </div>
</asp:Content>
