<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_BIO_CHEM.ascx.vb" Inherits="FDA_DRUG.UC_BIO_CHEM" %>
<table width="100%">
    <tr>
        <td style="width:40%;">
            1)
            ประเภทชีววัตถุ 
        </td>
        <td>
            <asp:Label ID="lbl_bio_type1" runat="server" Text="-"></asp:Label>
            <%--<asp:RadioButtonList ID="rdl_bio_type" runat="server"></asp:RadioButtonList>--%>
        </td>
        </tr>
    <tr>
        <td>
            2) การดัดแปลงพันธุกรรม</td>
        <td>
            <asp:RadioButtonList ID="rdl_GENE_MOD" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:RadioButtonList>
        </td>
        </tr>
    <tr>
        <td>
            3) การสกัด</td>
        <td>
            <table>
                <tr>
                    <td>
<asp:RadioButtonList ID="rdl_EXTRACT_TYPE" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                <asp:ListItem Value="1">Yes</asp:ListItem>
                <asp:ListItem Value="2">No</asp:ListItem>
            </asp:RadioButtonList>
                    </td>
                    <td>
<asp:TextBox ID="txt_EXTRACT_OTHER" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            
            
        </td>
        </tr>
    <tr>
        <td>
            4) ชื่อ</td>
        <td>
            <asp:TextBox ID="txt_iowanm" runat="server" Width="80%"></asp:TextBox>
            
            
        </td>
        </tr>
    <tr>
        <td>
            <span style="margin-left:10%;"></span> Genus</td>
        <td>
            <asp:TextBox ID="txt_genus" runat="server" Width="80%"></asp:TextBox>
            
            
        </td>
        </tr>
    <tr>
        <td>
            <span style="margin-left:10%;"></span>Species</td>
        <td>
            <asp:TextBox ID="txt_Species" runat="server" Width="80%"></asp:TextBox>
            
            
        </td>
        </tr>
    <tr>
        <td>
            <span style="margin-left:10%;"></span>Strain</td>
        <td>
            <asp:TextBox ID="txt_Strain" runat="server" Width="80%"></asp:TextBox>
            
            
        </td>
        </tr>
    <tr>
        <td>
            5) ชื่อการค้า (ถ้ามี)</td>
        <td>
            <asp:TextBox ID="txt_BRAND_LABEL" runat="server" Width="80%"></asp:TextBox>
            
            
        </td>
        </tr>
    <tr>
        <td>
            กรณีเป็นสารสกัดหรือสารสกัดบริสุทธิจากสิ่งมีชีวิต</td>
        <td>
            &nbsp;</td>
        </tr>
    <tr>
        <td>
            6) โปรดระบุ</td>
        <td>
            <asp:TextBox ID="txt_EXTRACT_OTHER2" runat="server" Width="80%"></asp:TextBox>
            
            
        </td>
        </tr>
</table>
<br />
<table width="100%">
    <tr>
                            <td style="width:40%;">Email สำหรับติดต่อ</td>
                            <td>
                                <asp:TextBox ID="txt_EMAIL" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
                    <tr>
                            <td>เบอร์โทรศัพท์ติดต่อ</td>
                            <td>
                                <asp:TextBox ID="txt_TEL" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                            </td>
                        </tr>
</table>