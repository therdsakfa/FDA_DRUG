<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_ETRACKING_STATUS_POPUP.aspx.vb" Inherits="FDA_DRUG.FRM_ETRACKING_STATUS_POPUP" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table class="table">
        <tr>
            <td align="right" style="width:10%;">ชื่อผลิตภัณฑ์ :
            </td>
            <td style="width:20%;">
                <asp:Label ID="lbl_product_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
             <td align="right" style="width:10%;">เลขทะเบียน/เลขใบอนุญาต :
            </td>
            <td style="width:20%;">
                <asp:Label ID="lbl_lcnno_display" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:10%;">ชื่อผู้อนุญาต :
            </td>
            <td style="width:10%;">
                <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:10%;">สถานะปัจจุบัน :
            </td>
            <td style="width:20%;">
                <asp:Label ID="lbl_stat" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
    </table>


    <table width="100%" class="table">
        <tr>
            <td align="right" style="width:20%;">สถานะถัดไป :</td>
            <td >
                <asp:DropDownList ID="ddl_cnsdcd" runat="server" DataTextField="STAFF_STATUS" DataValueField="STATUS_ID" CssClass="btn-sm" Width="200px">
                         </asp:DropDownList>
            </td>
 
        </tr>
        <tr>
            <td align="right" style="width:20%;">วันที่บันทึกสถานะ :</td>
            <td >
                <asp:TextBox ID="txt_stat_date" runat="server"></asp:TextBox>
            </td>
 
        </tr>
        <tr>
            <td align="right" style="width:20%;">ส่ง email :</td>
            <td>
                <asp:TextBox ID="txt_email" runat="server" TextMode="MultiLine" Width="500px" Height="90px"></asp:TextBox>
            </td>

        </tr>
        <tr>
            <td colspan="2" align="center">
                <table>
                    <tr>
                        <td>
                            <asp:Button ID="btn_add_expert" runat="server" Text="เพิ่มผู้เชี่ยมชาญ" CssClass="btn-lg" Width="150px" Style="display: none;" />
                        </td>
                        <td>
                            <asp:Button ID="btn_confirm" runat="server" Text="ยืนยัน" CssClass="btn-lg" Width="150px" />
                        </td>
                    </tr>
                </table>
                

                

            </td>
        </tr>
    </table>
</asp:Content>