<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_STAFF_LCN_LOCATION_INSERT_AND_UPDATE.aspx.vb" Inherits="FDA_DRUG.FRM_STAFF_LCN_LOCATION_INSERT_AND_UPDATE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <style> 

        input[type=text] {
    padding: 5px 10px;
    margin: 10px 0 2px 5px;
    box-sizing: border-box;
}



        </style> 
    <asp:panel ID="Panel1" runat="server">

             <div style="width:100%">
                <table style="width:100%">

                    <tr>
                        <td style="width:30%  ; padding-left:15%; text-align:left">
                            
                    <h2><asp:Label ID="Label1" runat="server" Text="ประเภทสถานที่"></asp:Label></h2>
                        </td>
                        <td  style="width:70%" valign="center">
                           <h2>
                                <asp:Label ID="lbl_place_type" runat="server" Text="-"></asp:Label>
                           </h2> 
                             <%--<asp:RadioButtonList ID="rdl_place_type" runat="server" RepeatColumns="2" RepeatDirection="Horizontal">
                                 <asp:ListItem Value="1" Selected="True">ที่ตั้ง</asp:ListItem>
                                 <asp:ListItem Value="2">สถานที่เก็บ</asp:ListItem>
                             </asp:RadioButtonList>--%>

                        </td>
                    </tr>
                </table>

            </div>
     
    <div style="width:100%">
        <table style="width: 100%">
            <tr>
                <td style="width: 30%; padding-left: 15%; text-align: left" colspan="2">

                    <h2>
                        <asp:Label ID="Label21" runat="server" Text="ชื่อสถานที่"></asp:Label></h2>

                </td>
                <td style="width: 70%; text-align: right" colspan="2"></td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_thanameplace_lo" runat="server" Text="ชื่อสถานที่ (ภาษาไทย)"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_thanameplace_lo" runat="server" Width="70%"> </asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_engnameplace_lo" runat="server" Text="ชื่อสถานที่ (ภาษาอังกฤษ)"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_engnameplace_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; padding-left: 15%; text-align: left" colspan="2">

                    <h2>
                        <asp:Label ID="Label24" runat="server" Text="ที่ตั้งสถานที่"></asp:Label></h2>

                </td>
                <td style="width: 70%; text-align: right" colspan="2"></td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_thacode_id_lo" runat="server" Text="รหัสประจำบ้าน"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_thacode_id_lo" runat="server" Width="70%"></asp:TextBox>

                    <asp:Button ID="btn_hno" runat="server" Text="ดึงข้อมูล" />
                    (หมายเหตุ สามารถดึงได้ทีละเลข)

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_thaaddr_lo" runat="server" Text="เลขที่"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_thaaddr_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_thabuilding_lo" runat="server" Text="อาคาร/ตึก"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_thabuilding_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_thafloor_lo" runat="server" Text="ชั้น"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_thafloor_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_tharoom_lo" runat="server" Text="ห้อง"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_tharoom_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_thamu_lo" runat="server" Text="หมู่"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_thamu_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_thasoi_lo" runat="server" Text="ซอย"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_thasoi_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_tharoad_lo" runat="server" Text="ถนน"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_tharoad_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_thachngwtnm_lo" runat="server" Text="จังหวัด"></asp:Label>


                </td>
                <td style="width: 70%; text-align: left" colspan="2">


                    <asp:DropDownList CssClass="dropdown" ID="ddl_chngwt" Width="70%" runat="server" AutoPostBack="True">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_thaamphrnm_lo" runat="server" Text="เขต/อำเภอ"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:DropDownList CssClass="dropdown" ID="ddl_amphr" Width="70%" runat="server" AutoPostBack="True">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">
                    <asp:Label ID="Lb_thathmblnm_lo" runat="server" Text="แขวง/ตำบล"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:DropDownList CssClass="dropdown" ID="ddl_thumbol" Width="70%" runat="server" AutoPostBack="True">
                    </asp:DropDownList>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_zipcode_lo" runat="server" Text="รหัสไปรษณีย์"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_zipcode_lo" runat="server" Width="70%" MaxLength="5"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_tel_lo" runat="server" Text="โทรศัพท์"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_tel_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>

            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_mobile_lo" runat="server" Text="โทรศัพท์มือถือ"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_mobile_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>

            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_fax_lo" runat="server" Text="โทรสาร"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_fax_lo" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>

            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_latitude" runat="server" Text="latitude(ถ้าไม่มีใส่ 0)"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_latitude" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width: 30%; text-align: right" colspan="2">

                    <asp:Label ID="Lb_longitude" runat="server" Text="longitude(ถ้าไม่มีใส่ 0)"></asp:Label>

                </td>
                <td style="width: 70%; text-align: left" colspan="2">

                    <asp:TextBox ID="txt_longitude" runat="server" Width="70%"></asp:TextBox>

                </td>
            </tr>

        </table>
    </div>
            </asp:panel>




    <br />
    <br />

    <div style="width:100%;text-align:center">
        <%--<asp:Button  CssClass ="btn-primary" ID="btn_back" runat="server" Text="ย้อนกลับ" style="height: 29px"  />--%>
        &nbsp;&nbsp;
        <asp:Button  CssClass="btn btn-primary" Height="34px" ID="bnt_submit" runat="server" Text="บันทึกข้อมูล" />
    </div>
    <br />
</asp:Content>