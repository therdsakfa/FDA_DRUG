<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_LCN_NCT_TEMP_INSERT.aspx.vb" Inherits="FDA_DRUG.POPUP_LCN_NCT_TEMP_INSERT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        ข้อมูลใบอนุญาต
    </h2>
    <table width="100%" style="padding-left:60px">
        <tr>
            <td>
                ตั้งอยู่ ณ ใบอนุญาตเลขที่</td>
            <td>

                <asp:Label ID="lbl_main_lcnno" runat="server" Text="-"></asp:Label>

            </td>
        </tr>
        <tr>
            <td>
                ประเภทใบอนุญาต
            </td>
            <td>

                <asp:DropDownList ID="ddl_lcntpcd" runat="server">
                </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td>
                ใบอนุญาตเลขที่
            </td>
            <td>
                <asp:TextBox ID="txt_LCNNO_FORMAT" runat="server"></asp:TextBox>
            &nbsp;(ตัวอย่าง กท 10/2562)</td>
        </tr>
        <tr>
            <td>
                เลขผู้รับอนุญาต</td>
            <td>
                <asp:TextBox ID="txt_IDENTIFY" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                ชื่อผู้รับอนุญาต</td>
            <td>
                <asp:TextBox ID="txt_LICEN_NAME" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                เลขบัตรผู้ดำเนินกิจการ</td>
            <td>
                <asp:TextBox ID="txt_BSN_IDENTIFY" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                ชื่อผู้ดำเนินกิจการ</td>
            <td>
                <asp:TextBox ID="txt_BSN_NAME" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                หมวดยา</td>
            <td>
                <asp:TextBox ID="txt_DRUG_GROUP" runat="server" TextMode="MultiLine" Width="500px" Height="70px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                ชื่อสถานที่ </td>
            <td>
                <asp:TextBox ID="txt_LOCATION_NAME" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                ที่อยู่</td>
            <td>
                <asp:TextBox ID="txt_LOCATION_ADDR" runat="server" TextMode="MultiLine" Width="500px" Height="70px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                โทรศัพท์/มือถือ</td>
            <td>
                <asp:TextBox ID="txt_TEL" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                ชื่อสถานที่เก็บ</td>
            <td>
                <asp:TextBox ID="txt_LOCATION_KEEP_NAME" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                ที่อยู่สถานที่เก็บ</td>
            <td>
                <asp:TextBox ID="txt_LOCATION_KRRP_ADDR" runat="server" TextMode="MultiLine" Width="500px" Height="70px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                โทรศัพท์/มือถือ ของสถานที่เก็บ</td>
            <td>
                <asp:TextBox ID="txt_KEEP_TEL" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td class="auto-style1">
                ตั้งแต่วันที่</td>
            <td class="auto-style1">
                <asp:TextBox ID="txt_DATE_START" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                ถึงวันที่</td>
            <td>
                <asp:TextBox ID="txt_DATE_END" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                .ให้ไว้ ณ วันที่</td>
            <td>
                <asp:TextBox ID="txt_DATE_DAY" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                เดือน</td>
            <td>
                <asp:TextBox ID="txt_DATE_MONTH" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                พ.ศ.</td>
            <td>
                <asp:TextBox ID="txt_DATE_YEAR" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                ชื่อผู้อนุญาต</td>
            <td>
                <asp:TextBox ID="txt_APPROVE_NAME" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                ตำแหน่ง</td>
            <td>
                <asp:TextBox ID="txt_APPROVE_POSITION" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                เงื่อนไข</td>
            <td>
                <asp:TextBox ID="txt_CONDITION" runat="server" TextMode="MultiLine" Width="500px" Height="70px"></asp:TextBox>
            </td>
        </tr>

    </table>
    <br />
    <br />

    <h2>
        เภสัชกร</h2>
    <table>
        <tr>
            <td>
                ชื่อเภสัชกร ลำดับที่ 1
            </td>
            <td>
                <asp:TextBox ID="txt_PHR_NAME1" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                ใบอนุญาตประกอบวิชาชีพเภสัชกรรมเลขที่
            </td>
            <td>
                <asp:TextBox ID="txt_PHR_NUMBER1" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>ชื่อเภสัชกร ลำดับที่ 2</td>
            <td>
                <asp:TextBox ID="txt_PHR_NAME2" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                ใบอนุญาตประกอบวิชาชีพเภสัชกรรมเลขที่
            </td>
            <td>
                 <asp:TextBox ID="txt_PHR_NUMBER2" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>ชื่อเภสัชกร ลำดับที่ 3</td>
            <td>
                <asp:TextBox ID="txt_PHR_NAME3" runat="server" Width="200px"></asp:TextBox>
            </td>
            <td>
                ใบอนุญาตประกอบวิชาชีพเภสัชกรรมเลขที่
            </td>
            <td>
                 <asp:TextBox ID="txt_PHR_NUMBER3" runat="server"></asp:TextBox></td>
        </tr>
    </table>
    <br />

    <table width="100%" >
        <tr>
            <td align="center">
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" />
            </td>
        </tr>
    </table>
</asp:Content>
