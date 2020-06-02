<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DRUG_PRODUCT_ID_LINK_SELECT.aspx.vb" Inherits="FDA_DRUG.POPUP_DRUG_PRODUCT_ID_LINK_SELECT" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
<%--    <script src="../js/jquery-1.8.3.js"></script>
    <script src="../js/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {  
             $("#ContentPlaceHolder1_ddl_gr_group").searchable();
             $("#ContentPlaceHolder1_ddl_chemecal").searchable();
             $("#ContentPlaceHolder1_ddl_atc").searchable();
             $("#ContentPlaceHolder1_ddl_small_unit").searchable();
             $("#ContentPlaceHolder1_ddl_first_unit").searchable();
         });

         </script>--%>
    <style type="text/css">
       /*.RadComboBox .rcbInner { 
            height: 22px; 
        }*/
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <div class="panel-heading panel-title">
                <h1>ผลิตภัณฑ์</h1>
            </div>
            <div class="panel-body" style="width:100%">
                <asp:Panel ID="Panel4" runat="server">
                <table class="table" style="width: 100%">
                 <tr>
                        <td>
                            <span id="ContentPlaceHolder1_lbl_PRODUCT_NAME">ชื่อผลิตภัณฑ์</span> ที่ต้องการเชื่อมโยง</td>
                        <td>
                            <asp:DropDownList ID="ddl_product" runat="server" CssClass="input-sm" Width="200px" AutoPostBack="True">
                            </asp:DropDownList>
&nbsp;</td>
                    </tr>
                    <tr>
                        <td>กรุณาเลือกประเภทการเชื่อมโยง</td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                                <asp:ListItem Value="1">เปลี่ยนชื่อการค้า</asp:ListItem>
                                <asp:ListItem Value="2">ระบุความแรง สัดส่วนตัวคูณของสูตร</asp:ListItem>
                                <asp:ListItem Value="3">แก้ทั้งชื่อการค้าและระบุความแรง สัดส่วนตัวคูณของสูตร</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_linktype" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_center_link" runat="server" Width="400px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lbl_linktype2" runat="server" Text=""></asp:Label>
                        </td>
                        <td>
                            <telerik:RadNumericTextBox ID="RadNumericTextBox1" Runat="server" Width="400px">
                            </telerik:RadNumericTextBox>
                        </td>
                    </tr>
                    </table>
                </asp:Panel>
            </div>
        <asp:Panel ID="Panel3" runat="server">
            <div class="panel-footer " style="text-align: center;">
                <asp:Button ID="btn_next" runat="server" CssClass="btn-lg" Text="เชื่อมโยงข้อมูล" />
            </div>
        </asp:Panel>
              
        </div>

</asp:Content>
