<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_DR_DTL_TEXT_MAIN_INSERT_AND_UPDATE_V2.aspx.vb" Inherits="FDA_DRUG.FRM_DR_DTL_TEXT_MAIN_INSERT_AND_UPDATE_V2" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
        <div class="panel-heading panel-title">
                <h1>แก้ไขผลิตภัณฑ์</h1>
            </div>
        <table class="table" style="width:100%;">
            <tr>
            <td>
              <table width="100%">
                  <tr>
                      <td align="right">
                          ชื่อผลิตภัณฑ์ :
                      </td>
                      <td>
                          <asp:Label ID="lbl_product_name" runat="server" Text="-"></asp:Label>
                      </td>
                      <td align="right">
                          เลขทะเบียน :
                      </td>
                      <td>
                          <asp:Label ID="lbl_lcnno_display" runat="server" Text="-"></asp:Label>
                      </td>

                      <td align="right">
                          rgttpcd :
                      </td>
                      <td>
                          <asp:Label ID="lbl_rgttpcd" runat="server" Text="-"></asp:Label>
                      </td>
                       <td align="right">
                          วงเล็บ :
                      </td>
                      <td>
                          <asp:Label ID="lbl_engdrgtpnm" runat="server" Text="-"></asp:Label>
                      </td>
                  </tr>
              </table>

                </td>
            </tr>
            <tr>
                <td>
                   <table width="100%">
                       <tr>
                           <td>
                               1.ข้อบ่งใช้</td>
                           <td width="75%">
                               <asp:TextBox ID="txt_dtl" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

                           </td>
                       </tr>
                       <tr>
                           <td>
                               2.ขนาดบรรจุ
                           </td>
                           <td width="75%">
                               <asp:TextBox ID="txt_pcksize" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

                           </td>
                       </tr>
                       <%--<tr>
                           <td>
                               3.รูปแบบการเก็บรักษา</td>
                           <td width="75%">
                               &nbsp;</td>
                       </tr>
                       <tr>
                           <td>
                               3.1 อายุการใช้งาน</td>
                           <td width="75%">
                               <asp:TextBox ID="txt_useage" runat="server"></asp:TextBox>
&nbsp;เดือน</td>
                       </tr>
                       <tr>
                           <td>
                               3.2 ช่วงอุณหภูมิ</td>
                           <td width="75%">
                               <asp:TextBox ID="txt_tplow" runat="server"></asp:TextBox>
&nbsp;ถึง
                               <asp:TextBox ID="txt_tphigh" runat="server"></asp:TextBox>

                           </td>
                       </tr>
                       <tr>
                           <td>
                               3.3 สภาวะการเก็บรักษา</td>
                           <td width="75%">
                               <asp:TextBox ID="txt_keepdesc" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

                           </td>
                       </tr>
                       <tr>
                           <td>
                               &nbsp;</td>
                           <td width="75%">
                               &nbsp;</td>
                       </tr>--%>
                       <tr>
                           <td colspan="2" align="center">
                               <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" />

                           </td>
                       </tr>
                   </table>
                </td>
            </tr>
        </table>
        </div>
</asp:Content>
