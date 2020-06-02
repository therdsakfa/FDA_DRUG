<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm34.aspx.vb" Inherits="FDA_DRUG.WebForm34" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<%--    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../assets/css/style.css" rel="stylesheet" />
    <script src="../Scripts/jquery-1.9.1.min.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>--%>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="Button1" runat="server" Text="Button" />
        <p>
            <asp:TextBox ID="txt_chk" runat="server"></asp:TextBox>
            <asp:Button ID="btn_chk_int" runat="server" Text="เช็คค่าว่าแปลงได้มั้ย" />
            <table>
                <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_thacode_id_lo" runat="server" Text="รหัสประจำบ้าน"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

                <asp:TextBox ID="txt_thacode_id_lo"  runat="server" Width="70%" ></asp:TextBox>

                    <asp:Button ID="btn_hno" runat="server" Text="ดึงข้อมูล" /> (หมายเหตุ สามารถดึงได้ทีละเลข)

                </td>
            </tr>
              <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_thaaddr_lo" runat="server" Text="เลขที่"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

                <asp:TextBox ID="txt_thaaddr_lo" runat="server"  Width="70%" ></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_thabuilding_lo" runat="server" Text="อาคาร/ตึก"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

               <asp:TextBox ID="txt_thabuilding_lo" runat="server"   Width="70%" ></asp:TextBox>

                </td>
            </tr>
                        <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_thafloor_lo" runat="server" Text="ชั้น"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

               <asp:TextBox ID="txt_thafloor_lo" runat="server"   Width="70%" ></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_tharoom_lo" runat="server" Text="ห้อง"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

               <asp:TextBox ID="txt_tharoom_lo" runat="server"   Width="70%" ></asp:TextBox>

                </td>
            </tr>
              <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_thamu_lo" runat="server" Text="หมู่"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

               <asp:TextBox ID="txt_thamu_lo" runat="server"   Width="70%" ></asp:TextBox>

                </td>
            </tr>
              <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_thasoi_lo" runat="server" Text="ซอย"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

                <asp:TextBox ID="txt_thasoi_lo" runat="server"   Width="70%" ></asp:TextBox>

                </td>
            </tr>
              <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_tharoad_lo" runat="server" Text="ถนน"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

                 <asp:TextBox ID="txt_tharoad_lo" runat="server"   Width="70%" ></asp:TextBox>

                </td>
            </tr>
              <tr>
                <td style="width:30%  ; text-align:right" colspan="2">
             
                       <asp:Label ID="Lb_thachngwtnm_lo" runat="server" Text="จังหวัด"></asp:Label>


                </td>
                <td style="width:70%  ; text-align:left " colspan="2">

                 
                      <asp:DropDownList CssClass="dropdown" ID="ddl_chngwt"  Width="70%" runat="server" AutoPostBack="True">
                    </asp:DropDownList>

                </td>
            </tr>
              <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_thaamphrnm_lo" runat="server" Text="เขต/อำเภอ"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

                    <asp:DropDownList CssClass="dropdown" ID="ddl_amphr"  Width="70%" runat="server" AutoPostBack="True">
                    </asp:DropDownList>

                </td>
            </tr>
              <tr>
                <td style="width:30%  ; text-align:right" colspan="2">
                              <asp:Label ID="Lb_thathmblnm_lo" runat="server" Text="แขวง/ตำบล"></asp:Label>
              
                </td>
                <td style="width:70% ;  text-align:left" colspan="2">

                     <asp:DropDownList CssClass="dropdown" ID="ddl_thumbol"  Width="70%"  runat="server" AutoPostBack="True">
                    </asp:DropDownList>

                </td>
            </tr>
              <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_zipcode_lo" runat="server" Text="รหัสไปรษณีย์"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

                 <asp:TextBox ID="txt_zipcode_lo" runat="server"  Width="70%" MaxLength="5" ></asp:TextBox>

                </td>
            </tr>
              <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_tel_lo" runat="server" Text="โทรศัพท์"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

                <asp:TextBox ID="txt_tel_lo" runat="server"   Width="70%" ></asp:TextBox>

                </td>
            </tr>

                <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_mobile_lo" runat="server" Text="โทรศัพท์มือถือ"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

                <asp:TextBox ID="txt_mobile_lo" runat="server"   Width="70%" ></asp:TextBox>

                </td>
            </tr>

               <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_fax_lo" runat="server" Text="โทรสาร"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

                <asp:TextBox ID="txt_fax_lo" runat="server"  Width="70%" ></asp:TextBox>

                </td>
            </tr>

                  <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_latitude" runat="server" Text="latitude(ถ้าไม่มีใส่ 0)"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

                <asp:TextBox ID="txt_latitude" runat="server"  Width="70%" ></asp:TextBox>

                </td>
            </tr>
               <tr>
                <td style="width:30%  ; text-align:right" colspan="2">

                    <asp:Label ID="Lb_longitude" runat="server" Text="longitude(ถ้าไม่มีใส่ 0)"></asp:Label>

                </td>
                <td style="width:70%  ; text-align:left" colspan="2">

                <asp:TextBox ID="txt_longitude" runat="server"  Width="70%" ></asp:TextBox>

                    <telerik:RadScheduler ID="RadScheduler1" runat="server">
                    </telerik:RadScheduler>

                </td>
            </tr>

        </table>
            </table>
        </p>
    </form>
</body>
</html>
