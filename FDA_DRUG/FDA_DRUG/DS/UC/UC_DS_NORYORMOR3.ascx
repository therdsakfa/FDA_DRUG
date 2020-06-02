<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DS_NORYORMOR3.ascx.vb" Inherits="FDA_DRUG.UC_DS_NORYORMOR3" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/DS/UC/UC_DS_NORYORMOR4.ascx" TagPrefix="uc1" TagName="UC_DS_NORYORMOR4" %>

<style type="text/css">
        .box{
        border:3px solid #8CB340;
        margin:10px;
        border-radius: 20px;
    }
    .auto-style1 {
        height: 21px;
    }
    .auto-style3 {
        width: 417px;
    }
    .auto-style4 {
        height: 21px;
        width: 417px;
    }
    .auto-style6 {
        width: 417px;
        height: 26px;
    }
    .auto-style7 {
        height: 26px;
    }
    .auto-style8 {
        width: 417px;
        height: 24px;
    }
    .auto-style9 {
        height: 24px;
    }
    .auto-style10 {
        width: 417px;
        height: 54px;
    }
    .auto-style11 {
        height: 54px;
    }
    .auto-style14 {
        width:auto;
    }
</style>

<center><h3>ข้อมูลทั่วไป</h3></center>
<div class="box">
<table class="table" style="width:100%;">
    <tr>
        <td align="right" class="auto-style3">
            เขียนที่ :</td>
        <td>
            <asp:TextBox ID="txt_WRITE_AT" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style3">
           วันที่ :</td>
        <td>
            <asp:TextBox ID="txt_WRITE_DATE" runat="server"></asp:TextBox>
            <asp:Label ID="lbl_date" runat="server" Text="(ตัวอย่าง 31/12/2560)"></asp:Label>
        </td>
        </tr>
         <tr>
            <td align="right" class="auto-style3">
                เลขบัญชีรายการยา :</td>
            <td>
                <asp:TextBox ID="txt_secrch" runat="server"></asp:TextBox>
                <asp:button ID="btn_search" runat="server" Text="ดึงข้อมูล"></asp:button>
            </td>
        </tr>
          <tr>
            <td align="right" class="auto-style3">
                คำขออนุญาตนำหรือสั่งยา :</td>
            <td>
                <asp:RadioButton  ID="chk_for1" runat="server" GroupName="for" Text="แผนปัจจุบัน เข้ามาในราชอาณาจักรเพื่อการจัดนิทรรศการ"></asp:RadioButton>
                <br />
                <asp:RadioButton ID="chk_for2" runat="server" GroupName="for"  Text="แผนโบราณ เข้ามาในราชอาณาจักรเพื่อการจัดนิทรรศการ" AutoPostBack="True"></asp:RadioButton> 
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                ชื่อผู้รับอนุญาต :</td>
            <td>
                <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
    <tr>
            <td align="right" class="auto-style3">
                ตำแหน่งชื่อผู้รับอนุญาต :</td>
            <td>
                <asp:textbox ID="txt_rank" runat="server"></asp:textbox>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style10">
                ในนามของ :</td>
            <td class="auto-style11">
                <asp:Radiobutton ID="CheckBox1" Text="กระทรวง" runat="server" GroupName="in_name" /><asp:DropDownList ID="department" runat="server">
                    <asp:ListItem></asp:ListItem>
                    <asp:ListItem>สำนักนายกรัฐมนตรี</asp:ListItem>
                    <asp:ListItem>กระทรวงกลาโหม</asp:ListItem>
                    <asp:ListItem>กระทรวงการคลัง</asp:ListItem>
                    <asp:ListItem>สำนักพระราชวัง</asp:ListItem>
                    <asp:ListItem>กระทรวงเกษตรและสหกรณ์</asp:ListItem>
                    <asp:ListItem>กระทรวงคมนาคม</asp:ListItem>
                    <asp:ListItem>กระทรวงมหาดไทย</asp:ListItem>
                    <asp:ListItem>กระทรวงยุติธรรม</asp:ListItem>
                    <asp:ListItem>กระทรวงศึกษาธิการ</asp:ListItem>
                    <asp:ListItem>กระทรวงสาธารณสุข</asp:ListItem>
                    <asp:ListItem>กระทรวงทรัพยากรธรรมชาติและสิ่งแวดล้อม</asp:ListItem>
                    <asp:ListItem>กระทรวงเทคโนโลยีสารสนเทศและการสื่อสาร</asp:ListItem>
                    <asp:ListItem>กระทรวงพลังงาน</asp:ListItem>
                    <asp:ListItem>กระทรวงการท่องเที่ยวและกีฬา</asp:ListItem>
                    <asp:ListItem>สำนักงานปลัดกระทรวงสาธารณสุข</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Radiobutton ID="CheckBox3" Text="กรม" runat="server" GroupName="in_name"/><asp:DropDownList ID="kom" runat="server">
                    <asp:ListItem></asp:ListItem>      
                    <asp:ListItem>กรมการแพทย์</asp:ListItem>
                    <asp:ListItem>กรมควบคุมโรค</asp:ListItem>
                    <asp:ListItem>กรมพัฒนาการแพทย์ไทยและการแพทย์ทางเลือก</asp:ListItem>
                    <asp:ListItem>กรมวิทยาศาสตร์การแพทย์</asp:ListItem>
                    <asp:ListItem>กรมสนับสนุนบริการสุขภาพ</asp:ListItem>
                    <asp:ListItem>กรมสุขภาพจิต</asp:ListItem>
                    <asp:ListItem>กรมอนามัย</asp:ListItem>
                    <asp:ListItem>สำนักงานคณะกรรมการอาหารและยา</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Radiobutton ID="CheckBox2" Text="ทบวง" runat="server" GroupName="in_name"/><asp:TextBox ID="txt_thabuang" runat="server"></asp:TextBox>
                <br />
                <asp:Radiobutton ID="CheckBox4" Text="สภากาชาดไทย" runat="server" GroupName="in_name"/>
                <br />
                <asp:Radiobutton ID="CheckBox5" Text="องค์การเภสัชกรรม" runat="server" GroupName="in_name"/>
                <br />
                <asp:Radiobutton ID="CheckBox6" Text="ผู้แทนการค้าของประเทศ" runat="server" GroupName="in_name"/><asp:TextBox ID="txt_phoothane" runat="server"></asp:TextBox>
                <br />
                <asp:Radiobutton ID="CheckBox7" Text="สมาคม" runat="server" GroupName="in_name"/><asp:TextBox ID="txt_samakom" runat="server"></asp:TextBox>
                <br />
                <asp:Radiobutton ID="CheckBox8" Text="มูลนิธิ" runat="server" GroupName="in_name"/><asp:TextBox ID="txt_moolniti" runat="server"></asp:TextBox>
                <br />
                <asp:Radiobutton ID="CheckBox9" Text="ผู้รับอนุญาตผลิตยา" runat="server" GroupName="in_name"/>
                <br />
                <asp:Radiobutton ID="CheckBox10" Text="ผู้รับอนุญาตนำหรือสั่งยาฯ ณ สถานที่ชื่อ" runat="server" GroupName="in_name"/>
            </td>
        </tr>
    </table>
</div>

<center><h3>ข้อมูลใบอนุญาต</h3></center>
<div class="box">
<table class="table" style="width:100%;">
        <tr>
            <td align="right" class="auto-style3">
                เลขที่ใบอนุญาต :</td>
            <td>
                <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
                <asp:Label ID="lbl_lcnno2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                คำขออนุญาตินำหรือสั่งยาฯ ณ สถานที่ชื่อ :</td>
            <td>
                <asp:Label ID="lbl_place_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
         <tr>
        <td align="right" class="auto-style3">
            ชื่อผู้ดำเนินกิจการ :</td>
        <td>
            <asp:Label ID="lbl_bsn_prefixed" runat="server"></asp:Label>
            <asp:Label ID="lbl_bsn_name" runat="server" Text="-"></asp:Label>
        </td>
        </tr>
        <tr>
            <td align="right" class="auto-style4">
               ที่อยู่ :</td>
            <td class="auto-style1">
                <asp:Label ID="lbl_number" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                ซอย :</td>
            <td>
                <asp:Label ID="lbl_lane" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
               ถนน :</td>
            <td>
                <asp:Label ID="lbl_road" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
               หมู่ :</td>
            <td>
                <asp:Label ID="lbl_village_no" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                ตำบล :</td>
            <td>
                <asp:Label ID="lbl_sub_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                อำเภอ :</td>
            <td>
                <asp:Label ID="lbl_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                จังหวัด :</td>
            <td>
                <asp:Label ID="lbl_province" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style8">
             โทรศัพท์ :</td>
            <td class="auto-style9">
                <asp:Label ID="lbl_tel" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
    </table>
</div>
<center><h3>ข้อมูลผลิตภัณฑ์ยา</h3></center>
<div class="box">
<table class="table" style="width:100%;">

            <tr>
            <td align="right" class="auto-style3">
             ชื่อยา :</td>
            <td>
                <asp:Label ID="lbl_drugthanm" runat="server" Text="-"></asp:Label>
                &nbsp;
                <asp:Label ID="lbl_drugengnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                ลักษณะและสีของยา :</td>
            <td>
                <asp:Label ID="lbl_nature" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        
    <%-- <tr>
            <td class="auto-style3">
                <asp:button ID="btn_add" runat="server" Text="เพิ่มตัวยาสำคัญ"></asp:button>
            </td>
            </tr>--%>
         <tr>
              <td class="auto-style3">

                   <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" width="150%" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="iowanm" HeaderText="ตัวยาสำคัญ" DataField="iowanm" >
                            </telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn UniqueName="DOSAGE" HeaderText="จำนวน" DataField="DOSAGE" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="sunitengnm" HeaderText="หน่วย" DataField="sunitengnm" >
                            </telerik:GridBoundColumn>--%>
                            <telerik:GridBoundColumn UniqueName="QTY" HeaderText="ปริมาณ" DataField="QTY">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>

                                    <br />

                                    </td>
                                </tr>
    <tr>
        <td align="right" class="auto-style3">
            หน่วยนับตามรูปแบบยา</td>
        <td>
            <asp:label ID="lbl_unitnm" runat="server" DataTextField="unit_name" DataValueField="unit_name" AutoPostBack="True"></asp:label>
            <asp:label ID="lbl_unite_ida" runat="server" DataTextField="lbl_unite_ida" DataValueField="lbl_unite_ida" AutoPostBack="True" Visible="False"></asp:label>
            <asp:DropDownList ID="ddl_snunit" runat="server" AutoPostBack="True" Visible="False">
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style6">
                ปริมาณที่จะผลิต/นำสั่ง :</td>
            <td class="auto-style7">
                <asp:DropDownList ID="ddl_package_unit" runat="server" AutoPostBack="True">
                </asp:DropDownList>
&nbsp;&nbsp;
                <asp:TextBox ID="txt_qty" runat="server" AutoPostBack="True"></asp:TextBox>
&nbsp;
                <asp:Label ID="imp_unit" runat="server"></asp:Label>
 
                &nbsp;
                <asp:Label ID="lbl_import_sum" runat="server"></asp:Label>
            &nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="บันทึก" />
                <br />
                <asp:Label ID="txt_imp" runat="server" Visible="False"></asp:Label>
                <asp:Label ID="txt_main_ida" runat="server" Visible="False"></asp:Label>
            </td>
        </tr>
    <tr>
        <td align="right" class="auto-style3">
            &nbsp;</td>
        <td>
               <asp:Button ID="btn_package" runat="server" Height="50px" Text="เพิ่ม/ลบ ขนาดบรรจุ" Width="150px" />

            <asp:Label ID="Label2" runat="server" Text="on" Visible="False"></asp:Label>
        </td>
        </tr>
         <tr id="package2" runat="server" style="display:none;">
            <td align="left" class="auto-style14">
                <%--<asp:CheckBox ID="chk_size" runat="server" Text="เพิ่มขนาดบรรจุ :" AutoPostBack="true"></asp:CheckBox>--%>

                เพิ่มขนาดบรรจุ
                </td>
                <td align="center" class="auto-style14">
                 จำนวน&nbsp; <asp:TextBox ID="txt_size1" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Label ID="lbl_size_5" runat="server" AutoPostBack="true"></asp:Label>
                &nbsp; ใน&nbsp;
                <asp:DropDownList ID="ddl_size6" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm" AutoPostBack="True"></asp:DropDownList>
 
                <br />
 
                จำนวน&nbsp;
 
                <asp:TextBox ID="txt_size3" runat="server"></asp:TextBox>
                &nbsp;
                <asp:Label ID="lbl_size_m" runat="server" AutoPostBack="True"></asp:Label>
                &nbsp; ใน&nbsp;
                <asp:DropDownList ID="ddl_size4" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm"></asp:DropDownList>
                <br />
                <br />ชื่อขนาดบรรจุ :
                <asp:TextBox ID="txt_package_name" runat="server"></asp:TextBox>
                &nbsp;
                หมายเลขบาร์โค้ด :
                <asp:TextBox ID="txt_barcode" runat="server"></asp:TextBox>
                <br />
                <br />
                <asp:button ID="btn_add" runat="server" Text="บันทึกขนาดบรรจุ"></asp:button>
            </td>
        </tr>
       <%--    <tr id="package3" runat="server" style="display:none;">
              <td class="auto-style3">

                   <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" width="150%" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
<%--                            <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                <ItemTemplate><uc1:UC_DS_NORYORMOR4 runat="server" id="UC_DS_NORYORMOR4" />
                                   <asp:CheckBox ID="checkColumn" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                           <%-- <telerik:GridBoundColumn UniqueName="IDA" HeaderText="IDA" DataField="IDA" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn UniqueName="PACKAGE_NAME" HeaderText="ชื่อขนาดบรรจุ" DataField="PACKAGE_NAME" >
                            </telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn UniqueName="SMALL_AMOUNT" HeaderText="จำนวน" DataField="SMALL_AMOUNT" >
                            </telerik:GridBoundColumn>  
                            <telerik:GridBoundColumn UniqueName="SMALL_UNIT" HeaderText="หน่วย" DataField="SMALL_UNIT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="x" DataField="x" ></telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn UniqueName="MEDIUM_AMOUNT" HeaderText="จำนวน" DataField="MEDIUM_AMOUNT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="MEDIUM_UNIT" HeaderText="หน่วย" DataField="MEDIUM_UNIT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="x" DataField="x" ></telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn UniqueName="fix_bigunit" HeaderText="จำนวน" DataField="fix_bigunit" ></telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn UniqueName="BIG_UNIT" HeaderText="หน่วย" DataField="BIG_UNIT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BARCODE" HeaderText="บาร์โค้ด" DataField="BARCODE" >
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del">
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>

                                    </td>
                                </tr--%>>
                <tr >
                        <td colspan="2" style="padding-left: 33%;">
                <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" width="500px" ShowFooter="true"  AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                           <%-- <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                <ItemTemplate>
                                   <asp:CheckBox ID="checkColumn" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                                                                 <telerik:GridBoundColumn UniqueName="IDA" HeaderText="ลำดับ" DataField="IDA" display ="false"  >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn UniqueName="IM_DETAIL" HeaderText="ชื่อขนาดบรรจุ" DataField="IM_DETAIL" >
                                  <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del">
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>
                </td>
        </tr>


        <tr>
            <td align="right" class="auto-style3">
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="50px" Width="150px"></asp:Button>
              </td>
            <td>
               <asp:Button ID="Button2" runat="server" Height="50px" Text="ไปยังหน้าอัพโหลดคำขอ" Width="150px" />

            </td>
        </tr>
    </table>
</div>
