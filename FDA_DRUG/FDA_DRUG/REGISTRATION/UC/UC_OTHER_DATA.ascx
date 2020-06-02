<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_OTHER_DATA.ascx.vb" Inherits="FDA_DRUG.UC_OTHER_DATA" %>
<table width="800px">
    <tr>
        <td>สภาวะการเก็บรักษา</td>
        <td width="75%">
            <asp:TextBox ID="txt_keep" runat="server" Height="200px" TextMode="MultiLine" Width="100%"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <table>
                <tr>
                    <td>อายุการใช้งาน :</td>
                    <td width="25%">
                        <asp:TextBox ID="txt_AGE_MONTH" runat="server"></asp:TextBox>
                        เดือน</td>
                    <td class="auto-style1">&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txt_AGE_DAY" runat="server"></asp:TextBox>
                        วัน</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:TextBox ID="txt_AGE_HOUR" runat="server"></asp:TextBox>ชั่วโมง
                    </td>
                    <td>&nbsp;</td>

                </tr>
                <tr>
                    <td>ช่วงอุณหภูมิการเก็บรักษา ระหว่าง</td>
                    <td>
                        <asp:TextBox ID="txt_TEMPERATE1" runat="server"></asp:TextBox>
                        &nbsp;องศาเซลเซียส</td>
                    <td class="auto-style1">ถึง</td>
                    <td>
                        <asp:TextBox ID="txt_TEMPERATE2" runat="server"></asp:TextBox>&nbsp;องศาเซลเซียส
                    </td>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td width="75%">
            <asp:Button ID="btn_insert" runat="server" Text="บันทึกข้อมูล" CssClass="input-lg"/>
        </td>
    </tr>
</table>