<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="US_DS_PORYOR8(YAVEJAI).ascx.vb" Inherits="FDA_DRUG.US_DS_PORYOR8_YAVEJAI_" %>
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
    }
    .auto-style11 {
        font-size: 18px;
    }
    .auto-style12 {
        text-align: center;
    }
    .auto-style14 {
        width: 616px;
    }
    .auto-style15 {
        height: 24px;
        width: 616px;
    }
    .auto-style16 {
        text-align: left;
    }
    .auto-style17 {
        height: 26px;
        text-align: left;
    }
    .auto-style18 {
        height: 24px;
        text-align: left;
    }
    .auto-style20 {
        width: 1236px;
    }
    .auto-style21 {
        width: 4%;
    }
    .auto-style22 {
        width: 609px;
    }
    .auto-style23 {
        width: 618px;
    }
    .auto-style24 {
        height: 24px;
        width: 618px;
    }
</style>
<link href="../css/css_radgrid.css" rel="stylesheet" />
<div class="auto-style12">
<div class="box">
    <table class="auto-style21">
<div class="panel-heading panel-title">
                <h1 class="auto-style20">ยาวิจัย (ผย8)</h1> (หากมีปัญหาเกี่ยวกับการใช้งานระบบหรือไม่พบตัวเลือกโปรดแจ้ง Drug-SmartHelp@fda.moph.go.th)
             </div>
        <br />
                     </table>
         </div>
<center><h3>ข้อมูลทั่วไป</h3></center>
          <div class="box">
<table class="table" style="width:100%;">
    <tr>
        <td align="right" class="auto-style22" >
            เขียนที่ :</td>
        <td class="auto-style17">
    
            <asp:TextBox ID="txt_WRITE_AT" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style22">
           วันที่ :</td>
        <td class="auto-style16">
            <asp:TextBox ID="txt_WRITE_DATE" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lbl_date" runat="server" Text="(ตัวอย่าง 31/12/2560)"></asp:Label>
        </td>
        </tr>
         <tr>
            <td align="right" class="auto-style22">
                บัญชีรายการยา :</td>
            <td class="auto-style16">
                <asp:DropDownList ID="ddl_search" runat="server" CssClass="btn-lg" Width="21%" Height="24px"></asp:DropDownList>
                <asp:button ID="btn_search" runat="server" Text="ดึงข้อมูล" CssClass="auto-style11" Height="53px" Width="100px"></asp:button>
            </td>
        </tr>
      </table>
          </div>

    <center><h3>ข้อมูลใบอนุญาต</h3></center>
<div class="box">
<table class="table" style="width:100%;">
        <tr>
            <td align="right" class="auto-style14">
                ชื่อผู้รับอนุญาต :</td>
            <td class="auto-style16">
                <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
                เลขที่ใบอนุญาต :</td>
            <td class="auto-style16">
                <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
                <asp:Label ID="lbl_lcnno2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
                สถานที่ผลิต/นำสั่ง :</td>
            <td class="auto-style16">
                <asp:Label ID="lbl_place_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
         <tr>
        <td align="right" class="auto-style14">
            ชื่อผู้ดำเนินกิจการ :</td>
        <td class="auto-style16">
            <asp:Label ID="lbl_bsn_name" runat="server" Text="-"></asp:Label>
        </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
               ที่อยู่ :</td>
            <td class="auto-style1">
                <asp:Label ID="lbl_number" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
                ซอย :</td>
            <td class="auto-style16">
                <asp:Label ID="lbl_lane" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
               ถนน :</td>
            <td class="auto-style16">
                <asp:Label ID="lbl_road" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
               หมู่ :</td>
            <td class="auto-style16">
                <asp:Label ID="lbl_village_no" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
                ตำบล :</td>
            <td class="auto-style16">
                <asp:Label ID="lbl_sub_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style15">
                อำเภอ :</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
                จังหวัด :</td>
            <td class="auto-style16">
                <asp:Label ID="lbl_province" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
             โทรศัพท์ :</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_tel" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
    </table>
    </div>

    <center><h3>ข้อมูลผลิตภัณฑ์ยา</h3></center>
<div class="box">
    <table class="table" style="width: 100%;">
            <tr>
            <td align="right" class="auto-style23">
             ชื่อยา :</td>
            <td class="auto-style16">
                <asp:Label ID="lbl_drugthanm" runat="server" Text="-"></asp:Label>
                &nbsp;
                <asp:Label ID="lbl_drugengnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style24">
                ลักษณะและสีของยา :</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_nature" runat="server" Text="-"></asp:Label>
            </td>
            <tr>
              <td class="auto-style23">

                   <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" width="200%" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="iowanm" HeaderText="ตัวยาสำคัญ" DataField="iowanm" >
                            </telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn UniqueName="QTY" HeaderText="ปริมาณ" DataField="QTY" >
                            </telerik:GridBoundColumn>                          
                           <%-- <telerik:GridBoundColumn UniqueName="Unit" HeaderText="หน่วย" DataField="sunitengnm" >
                            </telerik:GridBoundColumn>--%>
                        </Columns>
                    </MasterTableView>
                    </telerik:RadGrid>

                                    </td>
                                </tr>
        <tr>
        <td align="right" class="auto-style23">
            หน่วยนับตามรูปแบบยา :</td>
        <td class="auto-style17">
            <%--<asp:DropDownList ID="ddl_unit" runat="server" DataTextField="unit_name" DataValueField="unit_name" AutoPostBack="True">
            </asp:DropDownList>--%>
            <asp:Label ID="lbl_unit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
            <asp:label ID="lbl_sunit_ida" runat="server" DataTextField="lbl_sunit_ida" DataValueField="lbl_sunit_ida" AutoPostBack="True" Visible="False"></asp:label>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style23">
                ปริมาณที่จะผลิต/นำสั่ง :</td>
             <td class="auto-style17">
                <asp:DropDownList ID="ddl_package_unit" runat="server" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:TextBox ID="txt_qty" runat="server" AutoPostBack="True"></asp:TextBox>
                &nbsp;
                <asp:Label ID="imp_unit" runat="server"></asp:Label>
 
                &nbsp;
                <asp:Label ID="lbl_import_sum" runat="server"></asp:Label>
            &nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="บันทึก" CssClass="auto-style11" Height="53px" Width="100px" />
                <br />
                <asp:Label ID="txt_imp" runat="server"></asp:Label>
            </td>

        </tr>
            <%--<td class="auto-style7">
                <asp:Label ID="lbl_DOSAGE" runat="server" Text="-" AutoPostBack="True"></asp:Label>
                <asp:Label ID="lbl_unit2" runat="server" Text="-" AutoPostBack="True"></asp:Label>
               <%-- <asp:DropDownList ID="ddl_unit2" runat="server" DataTextField="unit_name" DataValueField="unit_name">
                </asp:DropDownList>--%>
             <tr>
        <td align="right" class="auto-style23">
            &nbsp;</td>
        <td>
               <asp:Button ID="btn_package" runat="server" Height="53px" Text="เพิ่ม/ลบ ขนาดบรรจุ" Width="180px" CssClass="auto-style11" />

            <asp:Label ID="Label2" runat="server" Text="on" Visible="False"></asp:Label>
        </td>
        </tr>
            <tr id="package2" runat="server" style="display: none;">
                <td align="right" class="auto-style23">
                <%--<asp:CheckBox ID="chk_unit" runat="server" Text="ขนาดบรรจุ :" AutoPostBack="True"></asp:CheckBox>--%>
                <%-- <tr id="package2" runat="server" style="display:none;">--%>
                    <asp:Label ID="lb_unit" runat="server" Text="ขนาดบรรจุ :"></asp:Label>
                </td>
                
                <td class="auto-style16">
                    ชื่อขนาดบรรจุ 
                <asp:TextBox ID="txt_packagename" runat="server"></asp:TextBox></br>
                จำนวน
                <asp:TextBox ID="txt_sunit" runat="server" Height="22px"></asp:TextBox>
                    <asp:Label ID="lbl_sunit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
                    &nbsp;ต่อ จำนวน 1
                <%--<asp:TextBox ID="txt_size2" runat="server"></asp:TextBox>--%>
                    <asp:DropDownList ID="ddl_munit" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm" AutoPostBack="True"></asp:DropDownList>
                    ต่อ
                <br />
                    จำนวน
                <asp:TextBox ID="txt_mamount" runat="server"></asp:TextBox>
                    <asp:Label ID="lbl_munit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
                    &nbsp;ต่อ จำนวน
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
            <%--<tr>
            <td class="auto-style10">
                <asp:button ID="btn_add" runat="server" Text="เพิ่มขนาดบรรจุ"></asp:button>
            </td>
            </tr>--%>
           <tr id="package3" runat="server" style="display:none;">
                <td class="auto-style23">
             <%-- <td class="auto-style10">--%>

                   <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" width="200%" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                            <%--<telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                <ItemTemplate>
                                   <asp:CheckBox ID="checkColumn" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                            <telerik:GridBoundColumn UniqueName="IDA" HeaderText="IDA" DataField="IDA" Display="false" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn UniqueName="PACKAGE_NAME" HeaderText="ชื่อขนาดบรรจุ" DataField="PACKAGE_NAME" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="SMALL_AMOUNT" HeaderText="จำนวน" DataField="SMALL_AMOUNT" >
                            </telerik:GridBoundColumn>  
                            <telerik:GridBoundColumn UniqueName="SMALL_UNIT" HeaderText="หน่วย" DataField="SMALL_UNIT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="x" HeaderText="ต่อ" DataField="x" >
                            </telerik:GridBoundColumn>  
                            <telerik:GridBoundColumn UniqueName="MEDIUM_AMOUNT" HeaderText="จำนวน" DataField="MEDIUM_AMOUNT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="MEDIUM_UNIT" HeaderText="หน่วย" DataField="MEDIUM_UNIT" >
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn UniqueName="fix_bigunit" HeaderText="จำนวน" DataField="fix_bigunit" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BIG_UNIT" HeaderText="หน่วย" DataField="BIG_UNIT" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="BARCODE" HeaderText="หมายเลขบาร์โค้ด" DataField="BARCODE" >
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del">
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>

                                    </td>
                                </tr>
      <tr>
            <td align="right" class="auto-style23">
                สำหรับ :</td>
            <td class="auto-style16">
                <asp:RadioButton  ID="chk_forhuman" runat="server" GroupName="for" Text="การศึกษาวิจัยในมนุษย์" Enabled="False"></asp:RadioButton>
                <br />
                <asp:RadioButton ID="chk_forother" runat="server" GroupName="for"  Text="กรณีอื่นๆ (ระบุ)" AutoPostBack="True" Enabled="False"></asp:RadioButton> 
                <asp:TextBox ID="txt_forother" runat="server" Text="" Visible="False"></asp:TextBox>
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
