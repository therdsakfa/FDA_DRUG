<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_HEAD_ETRACKING_DATE_POPUP.aspx.vb" Inherits="FDA_DRUG.FRM_HEAD_ETRACKING_DATE_POPUP" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--    <script src="../../../Scripts/jquery-1.7.2.js"></script>
    <link href="../../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    
    <script src="../../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../../Jsdate/ui.datepicker.js"></script>
    <script src="../../../Jsdate/Jsdatemain.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            showdate2($("#ContentPlaceHolder1_txt_start_date"));
            showdate2($("#ContentPlaceHolder1_txt_end_date"));
        });
    </script>--%>
    <style type="text/css">
        .auto-style1 {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
    </telerik:RadScriptManager>
    <br />
    <div class="panel-info" style="width: 100%">
        <div style="height: 60px;">
            <table style="width:100%;">
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="5">
                        <asp:Label ID="lbl_a_no" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">ช่วงสถานะ</td>
                    <td class="auto-style1">
                        <asp:Label ID="lbl_head_status" runat="server" Text="-"></asp:Label>
                    </td>
                    <td class="auto-style1">
                        </td>
                    <td class="auto-style1">
                        </td>
                    <td class="auto-style1">
                        </td>
                    <td class="auto-style1">
                        </td>
                </tr>
                <tr>
                    
                    <td><asp:Label ID="lbl_start_date" runat="server" Text="วันที่เริ่มกระบวนการ"></asp:Label>
                    </td>
                    <td align="left">
                        <telerik:RadDatePicker ID="rd_start_date" runat="server"></telerik:RadDatePicker>
                        <%--<asp:TextBox ID="txt_start_date" runat="server"></asp:TextBox>--%>
                    </td>
                    <td>
                        <asp:Label ID="lbl_end_date" runat="server" Text="วันสิ้นสุด"></asp:Label>
                    </td>
                    <td align="left">
                        <telerik:RadDatePicker ID="rd_end_date" runat="server"></telerik:RadDatePicker>
                        <%--<asp:TextBox ID="txt_end_date" runat="server"></asp:TextBox>--%>

                    </td>
                    <td align="left">
                        <asp:Label ID="lbl_app" runat="server" Text="การอนุมัติ"></asp:Label>

                    </td>
                    <td align="left">
                        <asp:DropDownList ID="ddl_app" runat="server">
                            <asp:ListItem Value="0">กรุณาเลือก</asp:ListItem>
                            <asp:ListItem Value="1">อนุญาต</asp:ListItem>
                            <asp:ListItem Value="2">คืนคำขอ</asp:ListItem>
                            <asp:ListItem Value="3">ยกเลิกคำขอ</asp:ListItem>
                            <asp:ListItem Value="4">จำหน่ายคำขอ (บันทึกข้อมูลผิดพลาด)</asp:ListItem>
                            <asp:ListItem Value="5">ไม่อนุญาต</asp:ListItem>
                        </asp:DropDownList>
                        


                    </td>
                </tr>
                <tr>
                    
                    <td>&nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
                        <asp:Label ID="lbl_ref_no" runat="server" Text="เลขอ้างอิงโฆษณา"></asp:Label>
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txt_ref_no" runat="server"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    
                    <td>&nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td align="left">
                        &nbsp;</td>
                    <td align="left">
                        หมายเหตุประกอบผลพิจารณา</td>
                    <td align="left">
                        <asp:TextBox ID="txt_remark" runat="server" TextMode="MultiLine" Width="90%" Height="70px"></asp:TextBox>

                    </td>
                </tr>
                <tr>
                    <td colspan="6" align="center">
                        <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" CssClass="btn-lg "/>
<asp:Button ID="btn_add" runat="server" Text="บันทึก" CssClass="btn-lg "/>
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
