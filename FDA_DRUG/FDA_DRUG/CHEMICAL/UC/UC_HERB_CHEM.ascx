<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_HERB_CHEM.ascx.vb" Inherits="FDA_DRUG.UC_HERB_CHEM" %>
<style type="text/css">
    .auto-style1 {
        height: 25px;
    }
</style>
<table width="100%">
    <tr>
        <td style="width:30%;">
            1) ประเภทสมุนไพร
        </td>
        <td>
            <%--<asp:RadioButtonList ID="rdl_herb_type" runat="server"  RepeatColumns="2" RepeatDirection="Horizontal" AutoPostBack="True"></asp:RadioButtonList>--%>
            <asp:Label ID="lb_herb_type" runat="server" Text="-"></asp:Label>
        </td>
    </tr>
    <tr>
        <td style="width:30%;">
            <span style="margin-left:10%;"></span>ประเภทวัตถุ</td>
        <td>
            <asp:RadioButtonList ID="rdl_herb_sub_type" runat="server" AutoPostBack="true" RepeatDirection="Horizontal">
                <asp:ListItem Value="1" Selected="True">พืชวัตถุ</asp:ListItem>
                <asp:ListItem Value="2">สัตว์วัตถุ</asp:ListItem>
            </asp:RadioButtonList>
        </td>
    </tr>
    <tr>
        <td>
            2) ชื่อสมุนไพร</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
        <span style="margin-left:10%;"></span>  ชื่อไทย</td>
        <td>
            <asp:TextBox ID="txt_iowanm" runat="server" Width="80%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
          <span style="margin-left:10%;"></span>  ชื่ออังกฤษ</td>
        <td>
            <asp:TextBox ID="txt_iowanm_eng" runat="server" Width="80%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="auto-style1">
          <span style="margin-left:10%;"></span>  ชื่อวิทยาศาสตร์</td>
        <td class="auto-style1">
            <asp:TextBox ID="txt_SCIENTIFIC_NAME" runat="server" Width="80%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            3) ส่วนที่ใช้</td>
        <td>
            <table>
                <tr>
                    <td>
                        <asp:CheckBoxList ID="cbl_herb_or_animal" runat="server" RepeatColumns="3" RepeatDirection="Horizontal">
                        </asp:CheckBoxList>
                    </td>
                    <td>
                        <asp:TextBox ID="txt_herb_or_animal_other" runat="server"></asp:TextBox>
                    </td>
                </tr>
            </table>
            

        </td>
    </tr>
    <tr>
        <td>
            4) ประเทศแหล่งกำเนิดสมุนไพร</td>
        <td>
            <asp:DropDownList ID="ddl_national" runat="server" Width="50%">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            5) ผ่านกรรมวิธีหรือไม่</td>
        <td>
            <table>
                <tr>
                    <td>
                        <asp:RadioButtonList ID="rdl_processing" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Selected="True" Value="1">ไม่ผ่าน</asp:ListItem>
                <asp:ListItem Value="2">ผ่านกรรมวิธี ระบุ</asp:ListItem>
            </asp:RadioButtonList>
                    </td>
                    <td>
<asp:TextBox ID="txt_PROCESSING_DES" runat="server" ></asp:TextBox>
                    </td>
                </tr>
            </table>
            
            
        </td>
    </tr>
    <tr>
        <td>
            6) สารประกอบด้วย พืชวัตถุ หรือสัตว์วัตถุ โปรดระบุ</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
           <span style="margin-left:30%;"> 6.1) Genus</td>
        <td>
            <asp:TextBox ID="txt_genus" runat="server" Width="80%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            <span style="margin-left:30%;"> 6.2) Species</td>
        <td>
            <asp:TextBox ID="txt_Species" runat="server" Width="80%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            7) ซึ่งที่แสดงในฉลาก</td>
        <td>
            <asp:TextBox ID="txt_BRAND_LABEL" runat="server" Width="80%"></asp:TextBox>
        </td>
    </tr>
</table>

<br />
<table width="100%">
    <tr>
                            <td style="width:30%;">Email สำหรับติดต่อ</td>
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