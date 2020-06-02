<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DRUG_COLOR.ascx.vb" Inherits="FDA_DRUG.UC_DRUG_COLOR" %>


<style type="text/css">
    .auto-style1 {
        text-align: center;
    }
</style>
<table width="100%">
    <tr>
        <td width="20%">
            คำบรรยายลักษณะของยา 
        </td>
        <td>
            <asp:TextBox ID="txt_DRUG_COLOR" runat="server" Width="100%"></asp:TextBox>
        </td>
    </tr>
</table> <br />
สีของยา
<table width="100%">
    <tr>
        <td style="text-align: center" width="10%">
            ลักษณะสี</td>
        <td width="50px" style="background-color:white;">
        </td>
        <td width="50px" style="background-color:red;">
        </td>
        <td width="50px" style="background-color:orange;">
        </td>
        <td width="50px" style="background-color:yellow;">
        </td>
        <td width="50px" style="background-color:lightgreen;">
        </td>
        <td width="50px" style="background-color:lightblue;">
        </td>
        <td width="50px" style="background-color:blue;">
        </td>
        <td width="50px" style="background-color:pink;">
        </td>
        <td width="50px" style="background-color:purple;">
        </td>
        <td width="50px" style="background-color:brown;">
        </td>
        <td width="50px" style="background-color:gray;">
        </td>
        <td width="50px" style="background-color:black;">
        </td>
        
        <td style="text-align: center" width="10%">
            ไม่ระบุ</td>
    </tr>
    <tr>
        <td class="auto-style1">
            1</td>
        <td colspan="14" rowspan="4" align="left" style="padding-right:10px;padding-left:30px;">
            <asp:RadioButtonList ID="rdl_color_row1" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" style="color:white;" Width="100%">
                <asp:ListItem Value="01"></asp:ListItem>
                <asp:ListItem Value="02"></asp:ListItem>
                <asp:ListItem Value="03"></asp:ListItem>
                <asp:ListItem Value="04"></asp:ListItem>
                <asp:ListItem Value="05"></asp:ListItem>
                <asp:ListItem Value="06"></asp:ListItem>
                <asp:ListItem Value="07"></asp:ListItem>
                <asp:ListItem Value="08"></asp:ListItem>
                <asp:ListItem Value="09"></asp:ListItem>
                <asp:ListItem Value="10"></asp:ListItem>
                <asp:ListItem Value="11"></asp:ListItem>
                <asp:ListItem Value="12"></asp:ListItem>
                <asp:ListItem Selected="True" Value="13"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:RadioButtonList ID="rdl_color_row2" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" Width="100%" style="color:white;">
                 <asp:ListItem Value="01"></asp:ListItem>
                <asp:ListItem Value="02"></asp:ListItem>
                <asp:ListItem Value="03"></asp:ListItem>
                <asp:ListItem Value="04"></asp:ListItem>
                <asp:ListItem Value="05"></asp:ListItem>
                <asp:ListItem Value="06"></asp:ListItem>
                <asp:ListItem Value="07"></asp:ListItem>
                <asp:ListItem Value="08"></asp:ListItem>
                <asp:ListItem Value="09"></asp:ListItem>
                <asp:ListItem Value="10"></asp:ListItem>
                <asp:ListItem Value="11"></asp:ListItem>
                <asp:ListItem Value="12"></asp:ListItem>
                <asp:ListItem Selected="True" Value="13"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:RadioButtonList ID="rdl_color_row3" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" Width="100%" style="color:white;">
                 <asp:ListItem Value="01"></asp:ListItem>
                <asp:ListItem Value="02"></asp:ListItem>
                <asp:ListItem Value="03"></asp:ListItem>
                <asp:ListItem Value="04"></asp:ListItem>
                <asp:ListItem Value="05"></asp:ListItem>
                <asp:ListItem Value="06"></asp:ListItem>
                <asp:ListItem Value="07"></asp:ListItem>
                <asp:ListItem Value="08"></asp:ListItem>
                <asp:ListItem Value="09"></asp:ListItem>
                <asp:ListItem Value="10"></asp:ListItem>
                <asp:ListItem Value="11"></asp:ListItem>
                <asp:ListItem Value="12"></asp:ListItem>
                <asp:ListItem Selected="True" Value="13"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:RadioButtonList ID="rdl_color_row4" runat="server" RepeatDirection="Horizontal" AutoPostBack="true" Width="100%" style="color:white;">
                 <asp:ListItem Value="01"></asp:ListItem>
                <asp:ListItem Value="02"></asp:ListItem>
                <asp:ListItem Value="03"></asp:ListItem>
                <asp:ListItem Value="04"></asp:ListItem>
                <asp:ListItem Value="05"></asp:ListItem>
                <asp:ListItem Value="06"></asp:ListItem>
                <asp:ListItem Value="07"></asp:ListItem>
                <asp:ListItem Value="08"></asp:ListItem>
                <asp:ListItem Value="09"></asp:ListItem>
                <asp:ListItem Value="10"></asp:ListItem>
                <asp:ListItem Value="11"></asp:ListItem>
                <asp:ListItem Value="12"></asp:ListItem>
                <asp:ListItem Selected="True" Value="13"></asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
            2</td>
    </tr>
    <tr>
        <td class="auto-style1">
            3</td>
    </tr>
    <tr>
        <td class="auto-style1">
            4</td>
    </tr>
</table>
<table width="100%">
    <tr>
        <td width="10%">สีที่ 1 :</td>
        <td>
            <asp:Label ID="lbl_color1" runat="server" Text="-"></asp:Label></td>
        <td width="10%">สีที่ 2 :</td>
        <td>
            <asp:Label ID="lbl_color2" runat="server" Text="-"></asp:Label></td>
    </tr>
    <tr>
        <td>สีที่ 3 :</td>
        <td>
            <asp:Label ID="lbl_color3" runat="server" Text="-"></asp:Label></td>
        <td>สีที่ 4 :</td>
        <td>
            <asp:Label ID="lbl_color4" runat="server" Text="-"></asp:Label></td>
    </tr>
    <tr>
        <td colspan="4" style="text-align: center">
            <asp:Button ID="btn_save" runat="server" Text="บันทึก" />
        </td>
    </tr>
</table>