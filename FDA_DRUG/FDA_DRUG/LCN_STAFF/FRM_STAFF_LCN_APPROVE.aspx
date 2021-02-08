<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_APPROVE.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_LCN_APPROVE" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery.blockUI.js"></script>
 <link href="../css/css_main.css" rel="stylesheet" />
    <script type="text/javascript" >
 
        $(function () {
            $('#<%= Button1.ClientID%>').click(function () {
                $.blockUI({ message: 'กำลังบันทึกกรุณารอสักครู่....' });
            });
        });

        </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>อนุญาตคำขอ</h1>
            </div>
            <div class="panel-body">
                <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                <table class="table">
                    
                    <tr ><td width="30%">ชื่อผู้ลงนาม <font color="red">*</font></td><td>
                        <%--<asp:DropDownList ID="ddl_staff_offer" runat="server" DataTextField="STAFF_OFFER_NAME" DataValueField="IDA" CssClass="input-lg" Width="200px">
                        </asp:DropDownList>--%>
                        <asp:TextBox ID="txt_name" runat="server" class="input-lg" Width="100%"></asp:TextBox>
                        </td></tr>

                    <tr ><td>ตำแหน่ง <font color="red">*</font></td><td>
                        <asp:TextBox ID="txt_position" runat="server" class="input-lg" Width="100%"></asp:TextBox>
                        </td></tr>

                    <tr ><td>วันที่อนุมัติ</td><td>
                        <asp:Label ID="lbl_app_date" runat="server" Text="-"></asp:Label>
                        </td></tr>

                </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ยกเลิก"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>
