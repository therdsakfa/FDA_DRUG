<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_PRODUCTION_DRUG_GROUP_HEAD.aspx.vb" Inherits="FDA_DRUG.POPUP_LCN_PRODUCTION_DRUG_GROUP_HEAD" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        สำหรับผลิตยาแผนปัจจุบันในหมวดยาต่อไปนี้
    </div>
    <table style="width:100%;" class="table">
        <tr>
            <td>
                <strong>หมวดยา</strong>  
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                ยาปราศจากเชื้อ</td>
            <td>
                <asp:RadioButtonList ID="rdl_type1" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">ผลิต</asp:ListItem>
                    <asp:ListItem Value="2">บรรจุ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                ยาที่ไม่ใช่ยาปราศจากเชื้อ</td>
            <td>
                <asp:RadioButtonList ID="rdl_type2" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">ผลิต</asp:ListItem>
                    <asp:ListItem Value="2">บรรจุ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                ยาชีววัตถุ</td>
            <td>
                <asp:RadioButtonList ID="rdl_type3" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">ผลิต</asp:ListItem>
                    <asp:ListItem Value="2">บรรจุ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                เภสัชเคมีภัณฑ์</td>
            <td>
                <asp:RadioButtonList ID="rdl_type4" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">ผลิต</asp:ListItem>
                    <asp:ListItem Value="2">บรรจุ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                เภสัชชีววัตถุ</td>
            <td>
                <asp:RadioButtonList ID="rdl_type5" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">ผลิต</asp:ListItem>
                    <asp:ListItem Value="2">บรรจุ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                เภสัชภัณฑ์รังสี</td>
            <td>
                <asp:RadioButtonList ID="rdl_type6" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">ผลิต</asp:ListItem>
                    <asp:ListItem Value="2">บรรจุ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                ยาเตรียมแอโรโซลสำหรับสูดดมแบบกำหนดขนาดใช้</td>
            <td>
                <asp:RadioButtonList ID="rdl_type7" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">ผลิต</asp:ListItem>
                    <asp:ListItem Value="2">บรรจุ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                ผลิตภัณฑ์ยาสัตว์ที่ไม่ใช่ยากระตุ้นภูมิคุ้มกัน</td>
            <td>
                <asp:RadioButtonList ID="rdl_type8" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">ผลิต</asp:ListItem>
                    <asp:ListItem Value="2">บรรจุ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                ยาสกัด</td>
            <td>
                <asp:RadioButtonList ID="rdl_type9" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">ผลิต</asp:ListItem>
                    <asp:ListItem Value="2">บรรจุ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td>
                ยาอื่นๆ</td>
            <td>
                <asp:RadioButtonList ID="rdl_type10" runat="server" RepeatDirection="Horizontal">
                    <asp:ListItem Value="1">ผลิต</asp:ListItem>
                    <asp:ListItem Value="2">บรรจุ</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" />
                <asp:Button ID="btn_next" runat="server" Text="หน้าถัดไป" CssClass="btn-lg" />
            </td>
        </tr>
    </table>
</asp:Content>
