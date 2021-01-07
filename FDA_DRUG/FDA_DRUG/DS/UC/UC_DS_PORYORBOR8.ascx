<%@ Control Language="vb" AutoEventWireup="false"  CodeBehind="UC_DS_PORYORBOR8.ascx.vb" Inherits="FDA_DRUG.UC_DS_PORYORBOR8_" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">
        .box{
        border:3px solid #8CB340;
        margin:10px;
        border-radius: 20px;
    }
    .auto-style1 {
        height: 21px;
        text-align: left;
        width: 1244px;
    }
    .auto-style11 {
        font-size: 18px;
    }
    .auto-style12 {
        text-align: center;
    }
    .auto-style13 {
        width: 1398px;
        height: 55px;
    }
    .auto-style14 {
        width: 552px;
    }
    .auto-style15 {
        text-align: left;
    }
    .auto-style16 {
        height: 26px;
        text-align: left;
    }
    .auto-style20 {
        width: 1413px;
    }
    .auto-style21 {
        width: 1414px;
    }
    .auto-style23 {
        width: 1406px;
    }
    .auto-style24 {
        width: 137%;
    }
    .auto-style26 {
        width: 821px;
    }
    .auto-style27 {
        text-align: left;
        width: 1244px;
    }
    .auto-style28 {
        height: 24px;
        text-align: left;
        width: 1244px;
    }
</style>
<link href="../css/css_radgrid.css" rel="stylesheet" />
<div class="auto-style12">
<div class="box">
    <table class="auto-style24">
    <div class="panel-heading panel-title">
<div class="panel-heading panel-title">
                <h1 class="auto-style13">การขอผลิต/นำเข้า ผลิตยาตัวอย่าง</h1> (หากมีปัญหาเกี่ยวกับการใช้งานระบบหรือไม่พบตัวเลือกโปรดแจ้ง Drug-SmartHelp@fda.moph.go.th)
               </div>
        <br />
                     </table>
         </div>

 <center><h3 class="auto-style23">ข้อมูลทั่วไป</h3></center>
          <div class="box">
              <table class="auto-style24">
    <tr>
            <td align="right" class="auto-style14">
            คำขออนุญาต :</td>
            <td class="auto-style15">
                <asp:RadioButton ID="rdb_sample_drug" runat="server" Text="ผลิตยาตัวอย่าง" AutoPostBack="True" GroupName="Drug" EnableTheming="True" ValidationGroup="Drug2" Enabled="False"></asp:RadioButton>
                </br>
                <asp:RadioButton ID="rdb_direct_register" runat="server" Text="นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักร" AutoPostBack="True" GroupName="Drug" Enabled="False"></asp:RadioButton>
               </br>
                _________________________
        </tr>
    <tr>
        <td align="right" class="auto-style14" >
            เขียนที่ :</td>
        <td class="auto-style16">
            <asp:TextBox ID="txt_WRITE_AT" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style14">
           วันที่ :</td>
        <td class="auto-style15">
            <asp:TextBox ID="txt_WRITE_DATE" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lbl_date" runat="server" Text="(ตัวอย่าง 31/12/2560)"></asp:Label>
        </td>
        </tr>
         <tr>
            <td align="right" class="auto-style14">
                บัญชีรายการยา :</td>
            <td class="auto-style15">
                <%--<asp:DropDownList ID="ddl_search" runat="server" CssClass="btn-lg" Width="21%" Height="24px"></asp:DropDownList>
                <asp:button ID="btn_search" runat="server" Text="ดึงข้อมูล" CssClass="auto-style11" Height="53px" Width="100px"></asp:button>--%>
                <asp:Label ID="pid" runat="server"></asp:Label>
            </td>
        </tr>

                   </table>
          </div>

    <center><h3 class="auto-style20">ข้อมูลใบอนุญาต</h3>
    </center>
<div class="box">
<table class="auto-style24">
        <tr>
            <td align="right" class="auto-style26">
                ชื่อผู้รับอนุญาต :</td>
            <td class="auto-style27">
                <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
        <td align="right" class="auto-style26">
            ชื่อผู้ดำเนินกิจการ :</td>
        <td class="auto-style27">
            <asp:Label ID="lbl_bsn_name" runat="server" Text="-"></asp:Label>
        </td>
        </tr>
         <tr>
            <td align="right" class="auto-style26">
            ได้รับอนุญาตให้ :</td>
            <td class="auto-style27">
                <asp:RadioButton ID="rdb_manufacture" runat="server" Text="ผลิตยาแผนโบราณ" AutoPostBack="True" Enabled="False"></asp:RadioButton>
                <asp:RadioButton ID="rdb_direct_license" runat="server" Text="นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรตามใบอนุญาต" AutoPostBack="True" Enabled="False"></asp:RadioButton>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style26">
                เลขที่ใบอนุญาต :</td>
            <td class="auto-style27">
                <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
                <asp:Label ID="lbl_lcnno2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style26">
                สถานที่ประกอบธุรกิจ :</td>
            <td class="auto-style27">
                <asp:Label ID="lbl_place_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
     
        <tr>
            <td align="right" class="auto-style26">
               ที่อยู่ :</td>
            <td class="auto-style1">
                <asp:Label ID="lbl_number" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style26">
                ซอย :</td>
            <td class="auto-style27">
                <asp:Label ID="lbl_lane" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style26">
               ถนน :</td>
            <td class="auto-style27">
                <asp:Label ID="lbl_road" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style26">
               หมู่ :</td>
            <td class="auto-style27">
                <asp:Label ID="lbl_village_no" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style26">
                ตำบล :</td>
            <td class="auto-style27">
                <asp:Label ID="lbl_sub_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style26">
                อำเภอ :</td>
            <td class="auto-style27">
                <asp:Label ID="lbl_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style26">
                จังหวัด :</td>
            <td class="auto-style27">
                <asp:Label ID="lbl_province" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style26">
             โทรศัพท์ :</td>
            <td class="auto-style28">
                <asp:Label ID="lbl_tel" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
                <td align="right" class="auto-style26">ผู้มีหน้าที่ปฏิบัติการ :<br />
                </td>
                <td class="auto-style28">
                    <asp:DropDownList ID="ddl_phesaj" runat="server" Height="16px">
                    </asp:DropDownList>
                    <br />
                </td>
            </tr>
     </table>
    </div>

    <center><h3 class="auto-style21">ข้อมูลผลิตภัณฑ์ยา </h3></center>
<div class="box">
    <table class="auto-style24">
    <tr>
            <td align="right" class="auto-style14">
            ขออนุญาต :</td>
            <td class="auto-style15">
                <asp:RadioButton ID="rdb_samples_drug" runat="server" Text="ผลิตยาตัวอย่าง" AutoPostBack="True" Enabled="False" EnableTheming="True" ValidationGroup="Drug2"></asp:RadioButton>
                <asp:RadioButton ID="rdb_direct_registers" runat="server" Text="นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรเพื่อขอขึ้นทะเบียน" AutoPostBack="True" Enabled="False"></asp:RadioButton>
            </td>
        </tr>
            <tr>
            <td align="right" class="auto-style14">
             ชื่อยา :</td>
            <td class="auto-style15">
                <asp:Label ID="lbl_drugthanm" runat="server" Text="-"></asp:Label>
                &nbsp;
                <asp:Label ID="lbl_drugengnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
                ลักษณะและสีของยา :</td>
            <td class="auto-style15">
                <asp:Label ID="lbl_nature" runat="server" Text="-"></asp:Label>
            </td>
            <tr>
              <td class="auto-style14">

                   <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" Width="201%"  ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                        <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="iowanm" HeaderText="ตัวยาสำคัญ" DataField="iowanm" >
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn UniqueName="QTY" HeaderText="ปริมาณ" DataField="QTY" >
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn> 
                            <%-- <telerik:GridBoundColumn UniqueName="Unit" HeaderText="หน่วย" DataField="sunitengnm" >
                            </telerik:GridBoundColumn>--%>
                         <telerik:GridBoundColumn UniqueName="unit_name" HeaderText="หน่วย" DataField="unit_name" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                           </Columns>
                            </MasterTableView>
                            </telerik:RadGrid>

                                    </td>
                                </tr>
          <tr>
            <td align="right" class="auto-style14">
            ขออนุญาต :</td>
            <td class="auto-style15">
                <asp:RadioButton ID="rdb_drug_produce" runat="server" Text="ยาที่ผลิต" AutoPostBack="True" Enabled="False"></asp:RadioButton>
                <asp:RadioButton ID="rdb_direct" runat="server" Text="ยาที่นำนำหรือสั่งเข้ามาในราชอาณาจักร" AutoPostBack="True" Enabled="False"></asp:RadioButton>
            </td>
        </tr>
        <tr>
        <td align="right" class="auto-style14">
            หน่วยนับตามรูปแบบยา :</td>
        <td class="auto-style16">
            <%--<asp:DropDownList ID="ddl_unit" runat="server" DataTextField="unit_name" DataValueField="unit_name" AutoPostBack="True">
            </asp:DropDownList>--%>
            <asp:Label ID="lbl_unit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
            (
            <asp:Label ID="Stext_unit" runat="server"></asp:Label>
            )<asp:label ID="lbl_sunit_ida" runat="server" DataTextField="lbl_sunit_ida" DataValueField="lbl_sunit_ida" AutoPostBack="True" Visible="False"></asp:label>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:DropDownList ID="ddl_snunit" runat="server" AutoPostBack="True" Visible="False">
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style14">
                ปริมาณที่จะผลิต/นำสั่ง :</td>
             <td class="auto-style16">
                <asp:DropDownList ID="ddl_package_unit" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:TextBox ID="txt_qty" runat="server" AutoPostBack="True"></asp:TextBox>
                &nbsp;
                <asp:Label ID="imp_unit" runat="server"></asp:Label>
 
                &nbsp;
                <asp:Label ID="lbl_import_sum" runat="server"></asp:Label>
            &nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="บันทึกขนาดบรรจุ" CssClass="auto-style11" Height="53px" Width="150px" />
                <br />
                <%--<asp:Label ID="txt_imp" runat="server"></asp:Label>--%>
                 <asp:Label ID="all_sum" runat="server" Visible ="false"></asp:Label>  <asp:TextBox ID="txt_summ" runat="server" AutoPostBack="True" Visible ="false"></asp:TextBox>
                &nbsp;<asp:DropDownList ID="ddl_package_sum" runat="server" Visible="false" AutoPostBack="True">
                </asp:DropDownList>
                 <asp:Button ID="Button4" runat="server" Text="บันทึก" CssClass="auto-style11" Height="24px" Width="65px" Visible="false" />
            </td>

        </tr>
            <tr >
                        <td colspan="2" style="padding-left: 33%;">
                <telerik:RadGrid ID="RadGrid5" runat="server" GridLines="None" width="500px" ShowFooter="true"  AutoGenerateColumns="false">
                    
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
                    <telerik:GridBoundColumn UniqueName="SUM" HeaderText="จำนวนปริมาณนำสั่ง / ผลิต" DataField="SUM" >
                                 <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="SMALL_UNIT" HeaderText="หน่วย" DataField="SMALL_UNIT" >
                                 <ItemStyle HorizontalAlign="Center" />
                            </telerik:GridBoundColumn>
                    <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del">
                            </telerik:GridButtonColumn>
                    </Columns>
                    </MasterTableView>
                    </telerik:RadGrid>
                </td>
        </tr>
            <%--<td class="auto-style7">
                <asp:Label ID="lbl_DOSAGE" runat="server" Text="-" AutoPostBack="True"></asp:Label>
                <asp:Label ID="lbl_unit2" runat="server" Text="-" AutoPostBack="True"></asp:Label>
               <%-- <asp:DropDownList ID="ddl_unit2" runat="server" DataTextField="unit_name" DataValueField="unit_name">
                </asp:DropDownList>--%>
             <tr>
        <td align="right" class="auto-style14"></td>
        <td align="left"><asp:Button ID="btn_package" runat="server" Height="53px" Text="เพิ่ม/ลบ ขนาดบรรจุ" Width="180px" CssClass="auto-style11" />
            <asp:Label ID="Label2" runat="server" Text="on" Visible="False"></asp:Label>
        </td>
        </tr>
            <tr id="package2" runat="server" style="display: none;">
                <td align="right" class="auto-style14">
                <%--<asp:CheckBox ID="chk_unit" runat="server" Text="ขนาดบรรจุ :" AutoPostBack="True"></asp:CheckBox>--%>
                <%-- <tr id="package2" runat="server" style="display:none;">--%>
                    <asp:Label ID="lb_unit" runat="server" Text="ขนาดบรรจุ :"></asp:Label>
                </td>
                
                <td class="auto-style15">
                    ชื่อขนาดบรรจุ 
                <asp:TextBox ID="txt_packagename" runat="server"></asp:TextBox></br>
                จำนวน
                <asp:TextBox ID="txt_sunit" runat="server" Height="22px"></asp:TextBox>
                    <asp:Label ID="lbl_sunit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
                    ต่อ จำนวน 1
                <%--<asp:TextBox ID="txt_size2" runat="server"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddl_munit" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm" AutoPostBack="True"></asp:DropDownList>
                    ต่อ
                <br />
                    จำนวน
                <asp:TextBox ID="txt_mamount" runat="server"></asp:TextBox>
                    <asp:Label ID="lbl_munit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
                    ต่อ จำนวน
                <%--<asp:TextBox ID="txt_size4" runat="server"></asp:TextBox>--%>
                1
                <asp:DropDownList ID="ddl_bunit" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm"></asp:DropDownList>
                    หมายเลขบาร์โค้ด
                <asp:TextBox ID="txt_barcode" runat="server" Width="128px"></asp:TextBox>
                    </br>
                <asp:Button ID="btn_add" runat="server" Text="บันทึกขนาดบรรจุ" CssClass="auto-style11" Height="53px" Width="180px"></asp:Button>
                </td>
                <%--</tr>--%>
            </tr>
          <%--  <tr>
            <td class="auto-style10">
                <asp:button ID="btn_add" runat="server" Text="เพิ่มขนาดบรรจุ"></asp:button>
            </td>
            </tr>--%>
            <tr id="package3" runat="server" style="display:none;">
                <td class="auto-style14">
              <%--<td class="auto-style10">--%>

                   <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" width="200%" ShowFooter="true" AutoGenerateColumns="false">                       
                    <MasterTableView>
                    <Columns>
                    <telerik:GridBoundColumn UniqueName="IDA" HeaderText="IDA" DataField="IDA" Display="false" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="PACKAGE_NAME" HeaderText="ชื่อขนาดบรรจุ" DataField="PACKAGE_NAME" >
                                  <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn UniqueName="SMALL_AMOUNT" HeaderText="จำนวน" DataField="SMALL_AMOUNT" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="SMALL_UNIT" HeaderText="หน่วย" DataField="SMALL_UNIT" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="x" HeaderText="ต่อ" DataField="x" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="MEDIUM_AMOUNT" HeaderText="จำนวน" DataField="MEDIUM_AMOUNT" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="MEDIUM_UNIT" HeaderText="หน่วย" DataField="MEDIUM_UNIT" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="fix_bigunit" HeaderText="จำนวน" DataField="fix_bigunit" >
                                  <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BIG_UNIT" HeaderText="หน่วย" DataField="BIG_UNIT" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BARCODE" HeaderText="หมายเลขบาร์โค้ด" DataField="BARCODE" >
                                 <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del">
                            </telerik:GridButtonColumn>
                            </Columns>
                            </MasterTableView>
                            </telerik:RadGrid>

                                    </td>
                                </tr>
              </table>
    </div>
        <tr>
            <td align="right" class="auto-style3">
              </td>
            <td>
                <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="53px"  Width="150px" CssClass="auto-style11"></asp:Button>
                &nbsp;
                <asp:Button ID="btn_back" runat="server" Text="ปิดหน้าต่าง" Height="53px"  Width="150px" CssClass="auto-style11" />
            </div>

            </td>
        </tr>

