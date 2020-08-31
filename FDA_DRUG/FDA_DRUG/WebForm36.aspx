<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm36.aspx.vb" Inherits="FDA_DRUG.WebForm36" %>

<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<%@ Register src="TABEAN_YA/UC_BC/UC_general_BC.ascx" tagname="UC_general_BC" tagprefix="uc1" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:DropDownList ID="ddl_remark1" runat="server">
                            <asp:ListItem Value="0">กรุณาเลือก</asp:ListItem>
                            <asp:ListItem Value="1">&lt;=</asp:ListItem>
                            <asp:ListItem Value="2">&lt;</asp:ListItem>
                            <asp:ListItem Value="3">=</asp:ListItem>
                            <asp:ListItem Value="4">&gt;=</asp:ListItem>
                            <asp:ListItem Value="5">&gt;</asp:ListItem>
                        </asp:DropDownList>
        <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
        <asp:Button ID="Button23" runat="server" Text="อัพเดทใบอนุญาตไปทราย" />
        <asp:Button ID="Button24" runat="server" Text="ดึงใบอนุญาตไประบบทราย" />
        <asp:Button ID="Button25" runat="server" Text="ดึง DRM ไปทราย" />
        <asp:Button ID="Button27" runat="server" Text="test สารจากระบบทราย" />
        <asp:Button ID="btn_t_auto" runat="server" Text="ทะเบียนยาออโต้" />
        <asp:DropDownList ID="ddl_status" runat="server" Height="16px" Width="80%">
        </asp:DropDownList>
        <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
        <asp:Button ID="btn_gen_dh" runat="server" Text="GEN_DH" style="height: 26px" />
    <h2>
        บันทึกข้อมูลวันที่ขอตรวจ
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
    </h2>
        <table>
            <tr>
                <td>
                    ชื่อผู้รับอนุญาต :
                </td>
                <td>
                    บริษัท เภสัชกรรมศรีประสิทธิ์ จำกัด 
                </td>
            </tr>
            <tr>
                <td>
                    ชื่อสถานที่ :
                </td>
                <td>บริษัท เภสัชกรรมศรีประสิทธิ์ จำกัด</td>
            </tr>
            <tr>
                <td>
                    ที่ตั้ง :</td>
                <td><span id="ContentPlaceHolder1_lbl_addr">บ้านเลขที่216 หมู่6 ตำบลสวนหลวง อำเภอกระทุ่มแบน จังหวัดสมุทรสาคร 74110</span></td>
            </tr>
            <tr>
                <td>
                    เลขรับคำขอ :</td>
                <td>1/61</td>
            </tr>
            <tr>
                <td>
                    ประเภทใบอนุญาต :</td>
                <td>ขย1</td>
            </tr>
            <tr>
                <td>
                    วันที่ขอตรวจ :</td>
                <td>
                    <telerik:RadDatePicker ID="RadDatePicker1" Runat="server">
                    </telerik:RadDatePicker>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="btn_save" runat="server" Text="บันทึกวันที่ขอตรวจ" />
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                    <asp:Button ID="Button21" runat="server" Text="DEL A" />
                </td>
            </tr>
        </table>
        <p>
            <asp:FileUpload ID="FileUpload2" runat="server" />
            <asp:Button ID="Button26" runat="server" Text="Button" />
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Button" />
            <asp:Button ID="btn_run_atc" runat="server" Text="Run_ATC" />
            <asp:Button ID="btn_a" runat="server" Text="run_เลขA" />
            <asp:Button ID="btn_run_xml" runat="server" Text="Run XML" />
            <asp:Button ID="btn_run_cert_finist_date" runat="server" Text="run_cert_finist_date" />
            <asp:Button ID="Button14" runat="server" Text="test_date" />
        </p>
        <p>
            <table class="table">
                <tr>
                    <td colspan="2">
                        <h2>ข้อมูลทั่วไปผลิตภัณฑ์ยา</h2>
                    </td>
                </tr>
                <tr>
                    <td width="40%">เลขทะเบียนตำรับยา</td>
                    <td>
                        <asp:Label ID="lbl_rgtno" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>ชื่อการค้า (ภาษาไทย):</td>
                    <td>
                        <asp:Label ID="lbl_thadrgnm" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>ชื่อการค้า (ภาษาอังกฤษ):</td>
                    <td>
                        <asp:Label ID="lbl_engdrgnm" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>ชื่อผู้รับอนุญาต : </td>
                    <td>
                        <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>ชื่อสถานที่ :</td>
                    <td>
                        <asp:Label ID="lbl_thanameplace" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>ที่ตั้ง :</td>
                    <td>
                        <asp:Label ID="lbl_addr" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>ประเภทใบอนุญาต :</td>
                    <td>
                        <asp:Label ID="lbl_lcntpcd" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>เลขที่ใบอนุญาต :</td>
                    <td>
                        <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>



<%--    <tr>
        <td>วันที่อนุญาตทะเบียน :</td>
        <td >
            <asp:Label ID="lbl_appdate" runat="server" Text="-"></asp:Label>
        </td>
    </tr>



    <tr>
        <td>สถานะทะเบียน :</td>
        <td >
            <asp:Label ID="lbl_rgt_stat" runat="server" Text="-"></asp:Label>
        </td>
    </tr>--%>
            </table>

<table >
        <tr>
            <td>
                วันที่อนุญาตทะเบียน :
            </td>
            <td>
                <asp:TextBox ID="txt_appdate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                เลขทะเบียน :
            </td>
            <td>
                <asp:Label ID="lbl_tabean_type" runat="server"></asp:Label>
                <asp:TextBox ID="txt_tabean_no" runat="server"></asp:TextBox>
                <asp:Label ID="lbl_tabean_other_type" runat="server"></asp:Label> <br /> (กรอกแต่เลขทะเบียน เช่น 1/61)

            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btn_save_app" runat="server" Text="บันทึกเลขทะเบียนและวันที่อนุญาต" CssClass="input-lg" />
                <asp:Button ID="btn_preview" runat="server" Text="พิมพ์ย.2" CssClass="input-lg" />


                <asp:Button ID="btn_pay" runat="server" Text="ออกใบสั่งชำระ" CssClass="input-lg"/>


            </td>
        </tr>
    </table>




        </p>
        <p>
            <asp:Button ID="Button19" runat="server" Text="Button" />
            <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" />
        </p>
        <p>
            &nbsp;</p>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server">
        </rsweb:ReportViewer>
        <p>
            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
        </p>
        <p>
            <asp:Button ID="Button2" runat="server" Text="RUN REPORT" />
            <asp:Button ID="Button28" runat="server" Text="RUN Checklist" />
            <asp:Button ID="Button3" runat="server" Text="Run Order ID" />
            <asp:Button ID="Button10" runat="server" Text="test_aa" />
            <asp:Button ID="btn_rp_lcn" runat="server" Text="Run Report Lcn" />
            <asp:Button ID="Button29" runat="server" Text="Run Lit" />

            <a href="WS_GET_REGIST.asmx" target="_blank"></a><a/>
        </p>
        <p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button5" runat="server" Text="ดึง RQ ไป RG" />
            <asp:Button ID="Button16" runat="server" Text="get_hour" style="height: 26px" />
            <asp:Button ID="Button18" runat="server" Text="เซอวิสจ่ายเงินทะเบียนออโต้" />
        </p>
        <p>
            <asp:Button ID="Button4" runat="server" Text="Button" style="height: 26px" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button6" runat="server" Text="ดึงไป xnl" />
            <asp:Button ID="Button7" runat="server" Text="Button" />
            <asp:Button ID="Button8" runat="server" Text="TEST" />
            <asp:Button ID="Button11" runat="server" Text="test_ws_lcnsnm" />
        </p>
        <p>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <asp:Button ID="Button9" runat="server" Text="Button" />
        </p>
        <p>
            &nbsp;</p>
        <p>
            &nbsp;</p>



         <table class="table">
                    <tr ><td>หมายเหตุ</td><td>
                        <asp:TextBox ID="Txt_Remark" runat="server" CssClass="input-lg"></asp:TextBox>
                        </td></tr>

                 <%--   <tr ><td>ชื่อผู้ลงนาม </td><td>
                        <asp:DropDownList ID="ddl_staff_offer" runat="server" DataTextField="STAFF_OFFER_NAME" DataValueField="IDA" CssClass="input-lg" Width="200px">
                        </asp:DropDownList>
                        </td></tr>--%>
                    <tr ><td>ประเภททะเบียน</td><td>
                        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                        </td></tr>

                    <tr ><td>วงเล็บ(ถ้ามี)</td><td>
                        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                        </td></tr>
                    <tr ><td>เลขทะเบียน</td><td>
                        <asp:TextBox ID="Txt_rcvno_no" runat="server" class="input-lg"></asp:TextBox>
                        ( ตัวอย่าง 1/62)</td></tr>

                    <tr ><td>วันที่เสนอลงนาม</td><td>
                        <asp:TextBox ID="TextBox6" runat="server" class="input-lg"></asp:TextBox></td></tr>

                    </table>
        <asp:Button ID="btn_repeat" runat="server" Text="เทสเลขซ้ำ" />

        <asp:Button ID="Button12" runat="server" Text="Button" />

        <asp:Button ID="Button13" runat="server" Text="thai2arbic" />

        <br />
        <br />
        <br />
        <br />
        <asp:TextBox ID="txt_regis_id" runat="server"></asp:TextBox>
        <asp:Button ID="Button15" runat="server" Text="ดึง regist ไป drrqt" />

        <asp:Button ID="Button17" runat="server" Text="gen_tr_id" />

        <asp:Button ID="btn_update_stat" runat="server" Text="วนส่ง lpi" />

        <p>
            <asp:Button ID="btn_geneqto" runat="server" Text="Gen EQTO" />
        </p>
        <p>
            pvncd :
            <asp:TextBox ID="txt_pvncd" runat="server"></asp:TextBox><br />
             rgttpcd :
            <asp:TextBox ID="txt_rgttpcd" runat="server"></asp:TextBox><br />
             drgtpcd :
            <asp:TextBox ID="txt_drgtpcd" runat="server"></asp:TextBox><br />
             rgtno :
            <asp:TextBox ID="txt_rgtno" runat="server"></asp:TextBox>

        </p>
        <p>
      
            <asp:Button ID="Button20" runat="server" Text="ดึง DR ไประบบทราย" />
        </p>
        <p>
            <asp:TextBox ID="txt_dh_ida" runat="server"></asp:TextBox>
            <asp:Button ID="Button22" runat="server" Text="ดึงDH" />
        </p>
        <p>
            <uc1:UC_general_BC ID="UC_general_BC1" runat="server" />
        </p>
        <p>
            &nbsp;</p>
         <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Value="0">กรุณาเลือก</asp:ListItem>
                            <asp:ListItem Value="1">&lt;=</asp:ListItem>
                            <asp:ListItem Value="2">&lt;</asp:ListItem>
                            <asp:ListItem Value="3">=</asp:ListItem>
                            <asp:ListItem Value="4">&gt;=</asp:ListItem>
                            <asp:ListItem Value="5">&gt;</asp:ListItem>
                        </asp:DropDownList>
    </form>


</body>
</html>
