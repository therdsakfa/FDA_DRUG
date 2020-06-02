<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_ADD_LOCATION.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_LCN_ADD_LOCATION" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        <asp:Label ID="lbl_head" runat="server" Text="-"></asp:Label>    
    </h2>
    <table width="100%" class="table">
        <tr>
            <td>&nbsp;</td>
            <td>
                <asp:RadioButtonList ID="rdl_choose" runat="server" RepeatColumns="2" RepeatDirection="Horizontal" AutoPostBack="true">
                    <asp:ListItem Selected="True" Value="1">เลือกสถานที่</asp:ListItem>
                    <asp:ListItem Value="2">อ้างอิงสถานที่</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        
    </table>
    <asp:Panel ID="Panel1" runat="server">
        <table width="100%" class="table">
            <tr>
                <td>
                    <asp:Label ID="lbl_name" runat="server" Text="-"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="ddl_placename" runat="server" Width="300px" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:HiddenField ID="hf_place" runat="server" />
                </td>
            </tr>
            <tr>
                <td>ที่ตั้ง (ใหม่)</td>
                <td>
                    <asp:Label ID="lbl_location_new" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <asp:Button ID="btn_save" runat="server" Text="เลือกข้อมูล" CssClass="btn-lg" OnClientClick="return confirm('คุณต้องการเลือกสถานที่เก็บนี้หรือไม่');" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server">
        <table width="100%" class="table">
            <tr>
                <td>
                    เลือกสถานที่
                </td>
                <td>
                    <asp:DropDownList ID="ddl_placename_sel" runat="server" Width="300px" AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </td>
            </tr>
        </table>

    <table style="width: 100%">
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_thanameplace_lo" runat="server" Text="ชื่อสถานที่ (ภาษาไทย)"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">
                    <asp:TextBox ID="txt_thanameplace_lo" runat="server" Width="70%"> </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_engnameplace_lo" runat="server" Text="ชื่อสถานที่ (ภาษาอังกฤษ)"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_engnameplace_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: left; padding-left: 15%;">

                    <h2>
                        <asp:Label ID="Label24" runat="server" Text="ที่ตั้งสถานที่"></asp:Label>
                    </h2>

                </td>
                <td style="width: 70%; text-align: right">

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_thacode_id_lo" runat="server" Text="รหัสประจำบ้าน"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">
                    <asp:TextBox ID="txt_thacode_id_lo" runat="server" Width="70%"></asp:TextBox>
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_thaaddr_lo" runat="server" Text="เลขที่"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_thaaddr_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_thabuilding_lo" runat="server" Text="อาคาร/ตึก"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_thabuilding_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_thafloor_lo" runat="server" Text="ชั้น"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_thafloor_lo" runat="server" Width="70%"></asp:TextBox>

                    *กรุณากรอกคำว่า &quot;ชั้น&quot; เช่น ชั้น 3</td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_tharoom_lo" runat="server" Text="ห้อง"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_tharoom_lo" runat="server" Width="70%"></asp:TextBox>

                    *กรุณากรอกคำว่า &quot;ห้อง&quot; เช่น ห้อง 241</td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_thamu_lo" runat="server" Text="หมู่"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_thamu_lo" runat="server" Width="70%"></asp:TextBox>

                    *กรุณากรอกคำว่า &quot;อาคาร&quot; เช่น อาคาร 1</td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_thasoi_lo" runat="server" Text="ซอย"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_thasoi_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_tharoad_lo" runat="server" Text="ถนน"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_tharoad_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_thachngwtnm_lo" runat="server" Text="จังหวัด"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:DropDownList ID="ddl_chngwt" runat="server" AutoPostBack="True" CssClass="dropdown" Width="70%">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_thaamphrnm_lo" runat="server" Text="เขต/อำเภอ"></asp:Label>


                </td>
                <td style="width: 70%; text-align: left">


                    <asp:DropDownList CssClass="dropdown" ID="ddl_amphr" Width="70%" runat="server" AutoPostBack="True">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_thathmblnm_lo" runat="server" Text="แขวง/ตำบล"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:DropDownList CssClass="dropdown" ID="ddl_thumbol" Width="70%" runat="server" AutoPostBack="True">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">
                    <asp:Label ID="Lb_zipcode_lo" runat="server" Text="รหัสไปรษณีย์"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_zipcode_lo" runat="server" MaxLength="5" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_tel_lo" runat="server" Text="โทรศัพท์"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_tel_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_mobile_lo" runat="server" Text="โทรศัพท์มือถือ"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_mobile_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>

            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_fax_lo" runat="server" Text="โทรสาร"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_fax_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>

            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_latitude" runat="server" Text="latitude(ถ้าไม่มีใส่ 0)"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_latitude" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>

            <tr>
                <td style="width: 30%; text-align: right">

                    <asp:Label ID="Lb_longitude" runat="server" Text="longitude(ถ้าไม่มีใส่ 0)"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left">

                    <asp:TextBox ID="txt_longitude" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right">&nbsp;</td>
                <td style="width: 70%; text-align: left">
                    <asp:Button ID="btn_save_sel" runat="server" CssClass="btn-lg" OnClientClick="return confirm('คุณต้องการบันทึกหรือไม่');" Text="บันทึกและใช้สถานที่" />
                </td>
            </tr>

        </table>
    </asp:Panel>
</asp:Content>
