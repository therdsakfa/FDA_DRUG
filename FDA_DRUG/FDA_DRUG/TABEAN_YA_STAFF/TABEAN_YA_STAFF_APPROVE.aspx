<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="TABEAN_YA_STAFF_APPROVE.aspx.vb" Inherits="FDA_DRUG.TABEAN_YA_STAFF_APPROVE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery.blockUI.js"></script>
 <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript" >

        $(function () {
            $('#<%= btn_save.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
            });
        });

        </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>อนุมัติคำขอ</h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    
                    <tr ><td>เลขทะเบียน</td><td>
                        <asp:Label ID="lbl_rgtno" runat="server" Text="-"></asp:Label>
                        </td></tr>

                    <%--<tr ><td>ประเภททะเบียน</td><td>
                        <asp:DropDownList ID="ddl_rgttpcd" runat="server">
                        </asp:DropDownList>
                        </td></tr>

                    <tr ><td>วงเล็บ(ถ้ามี)</td><td>
                        <asp:DropDownList ID="ddl_tabean_group" runat="server">
                        </asp:DropDownList>
                        </td></tr>--%>

                    <%--<tr ><td>เลขทะเบียน</td><td>
                        <asp:TextBox ID="Txt_rcvno_no" runat="server" CssClass="input-lg"></asp:TextBox>
                        (เช่น 1/62)</td></tr>--%>
                        <tr ><td>ชื่อผู้ลงนาม </td><td>
                            <asp:TextBox ID="txt_iden_staff" runat="server" CssClass="input-lg"></asp:TextBox>
                            <asp:Button ID="btn_search" runat="server" CssClass="btn-lg" Text="ค้นหาจนท." />
                            <br />
                            <asp:Label ID="lbl_staff_name" runat="server" Text="-"></asp:Label>
                        </td></tr>
                   <tr ><td>วันที่ขึ้นทะเบียน</td><td>
                        <asp:TextBox ID="txt_rcvdate" runat="server" CssClass="input-lg"></asp:TextBox>
                        </td></tr>

                 <%--  <tr ><td>ผู้รับคำขอ</td><td>
                        <asp:DropDownList ID="ddl_receiver" runat="server"  Width="70%">
                        </asp:DropDownList>
                        </td>

                   </tr>--%>

                   <%--<tr ><td>ชื่อจนท.</td><td>
                        <asp:Label ID="lbl_name_staff" runat="server" Text="-"></asp:Label>
                        </td></tr>--%>

                   <tr ><td><asp:Label ID="Label1" runat="server" Text="รูปแบบเอกสาร" style="display:none;"></asp:Label>
                       </td><td>
                        <asp:DropDownList ID="ddl_template" runat="server" Width="80%" style="display:none;">
                            <asp:ListItem Value="1">แบบปกติ</asp:ListItem>
                            <asp:ListItem Value="2">แบบที่ 1</asp:ListItem>
                        </asp:DropDownList>
                        </td></tr>
                </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" OnClientClick="return confirm('ต้องการรับคำขอหรือไม่?');" />
                  &nbsp;&nbsp;
                  <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>
