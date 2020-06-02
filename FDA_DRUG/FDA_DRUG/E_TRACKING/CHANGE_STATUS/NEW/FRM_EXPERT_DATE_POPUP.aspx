<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_EXPERT_DATE_POPUP.aspx.vb" Inherits="FDA_DRUG.FRM_EXPERT_DATE_POPUP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../../Scripts/jquery-1.8.2.js"></script>
    <script src="../../../Jsdate/ui.datepicker.js"></script>
    <script src="../../../Jsdate/ui.datepicker-th.js"></script>
    <script type="text/javascript">
        function showdate(targetobject) {
            $(targetobject).datepicker({
                showOn: "button",
                buttonImage: "../../../jsdate/calendar.gif",
                buttonImageOnly: true
            });

        }
        $(document).ready(function () {
            showdate($("#ContentPlaceHolder1_txt_start_date"));
            showdate($("#ContentPlaceHolder1_txt_end_date"));
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel-info" style="width: 100%">
        <div style="height: 60px;">
            <table style="width:100%;">
                <tr>
                    <td>ชื่อผู้ประเมิน</td>
                    <td>
                        <asp:Label ID="lbl_head_status" runat="server" Text="-"></asp:Label>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>วันที่เริ่มส่งประเมิน</td>
                    <td align="left">
                        <asp:TextBox ID="txt_start_date" runat="server" Enabled="false"></asp:TextBox>
                    </td>
                    <td>
                        วันที่สิ้นสุดการประเมิน</td>
                    <td align="left">
                        <asp:TextBox ID="txt_end_date" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" CssClass="btn-lg "/>
<asp:Button ID="btn_add" runat="server" Text="บันทึก" CssClass="btn-lg "/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>