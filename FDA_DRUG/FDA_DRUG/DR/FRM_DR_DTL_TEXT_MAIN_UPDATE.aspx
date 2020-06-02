<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_DR_DTL_TEXT_MAIN_UPDATE.aspx.vb" Inherits="FDA_DRUG.FRM_DR_DTL_TEXT_MAIN_UPDATE" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
        <div class="panel-heading panel-title">
                <h1>ผลิตภัณฑ์</h1>
            </div>
        <table class="table" style="width:100%;">

            <tr>
                <td align="right" colspan="4">
                    &nbsp;</td>
            </tr>
            <tr>
                <td colspan="4">
                   <table width="100%">
                       <tr>
                           <td>
                               1.ขนาดบรรจุ
                           </td>
                           <td width="75%">
                               <asp:TextBox ID="txt_pcksize" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

                           </td>
                       </tr>
                       <tr>
                           <td>
                               2.รูปแบบการเก็บรักษา</td>
                           <td width="75%">
                               &nbsp;</td>
                       </tr>
                       <tr>
                           <td>
                               2.1 อายุการใช้งาน</td>
                           <td width="75%">
                               <asp:TextBox ID="txt_useage" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

                           </td>
                       </tr>
                       <tr>
                           <td>
                               2.2 ช่วงอุณหภูมิ</td>
                           <td width="75%">
                               <asp:TextBox ID="txt_tphigh" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

                           </td>
                       </tr>
                       <tr>
                           <td>
                               2.3 สภาวะการเก็บรักษา</td>
                           <td width="75%">
                               <asp:TextBox ID="txt_keepdesc" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

                           </td>
                       </tr>
                       <tr>
                           <td>
                               3.ข้อบ่งใช้</td>
                           <td width="75%">
                               <asp:TextBox ID="txt_dtl" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

                           </td>
                       </tr>
                       <tr>
                           <td colspan="2" align="center">
                               <asp:Button ID="btn_save" runat="server" Text="แก้ไข" CssClass="btn-lg" />

                           </td>
                       </tr>
                   </table>
                </td>
            </tr>
        </table>
        </div>
</asp:Content>