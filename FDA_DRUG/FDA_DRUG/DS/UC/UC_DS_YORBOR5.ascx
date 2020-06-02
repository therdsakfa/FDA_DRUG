<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DS_YORBOR5.ascx.vb" Inherits="FDA_DRUG.US_DS_YORBOR5" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">

    .auto-style1 {
        height: 21px;
    }
    .auto-style7 {
        height: 26px;
    }
    .auto-style9 {
        height: 24px;
    }
    .auto-style10 {
        width: 251px;
    }
    .auto-style11 {
        text-align: left;
    }
</style>

<table class="table" style="width:100%;">
    <tr>
            <td align="right">
            คำขออนุญาต :</td>
            <td>
                <asp:RadioButton ID="rdb_sample_drug" runat="server" Text="ผลิตยาตัวอย่าง" AutoPostBack="True" EnableTheming="True" ValidationGroup="Drug" Enabled="False" GroupName="Drug"></asp:RadioButton>
                </br>
                <asp:RadioButton ID="rdb_direct_register" runat="server" Text="นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักร" AutoPostBack="True" GroupName="Drug" Enabled="False"></asp:RadioButton>
                </br>
                _________________________
            </td>
             <td>
                 </td>
        </tr>
    <tr>
        <td align="right" >
            เขียนที่ :</td>
        <td class="auto-style7">
            <asp:TextBox ID="txt_WRITE_AT" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td align="right">
           วันที่ :</td>
        <td>
            <asp:TextBox ID="txt_WRITE_DATE" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lbl_date" runat="server" Text="(ตัวอย่าง 31/12/2560)"></asp:Label>
        </td>
        </tr>
         <tr>
            <td align="right">
                บัญชีรายการยา :</td>
            <td>
                <asp:TextBox ID="txt_secrch" runat="server"></asp:TextBox>
                <asp:button ID="btn_search" runat="server" Text="ดึงข้อมูล"></asp:button>
            </td>
        </tr>
        <tr>
            <td align="right">
                ชื่อผู้รับอนุญาต :</td>
            <td>
                <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
        <td align="right">
            ชื่อผู้ดำเนินกิจการ :</td>
        <td>
            <asp:Label ID="lbl_bsn_name" runat="server" Text="-"></asp:Label>
        </td>
        </tr>
         <tr>
            <td align="right">
            ได้รับอนุญาตให้ :</td>
            <td>
                <asp:RadioButton ID="rdb_manufacture" runat="server" Text="ผลิตยาแผนโบราณ" AutoPostBack="True" Enabled="False"></asp:RadioButton>
                <asp:RadioButton ID="rdb_direct_license" runat="server" Text="นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรตามใบอนุญาต" AutoPostBack="True" Enabled="False"></asp:RadioButton>
            </td>
        </tr>
        <tr>
            <td align="right">
                เลขที่ใบอนุญาต :</td>
            <td>
                <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
                <asp:Label ID="lbl_lcnno2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                สถานที่ประกอบธุรกิจ :</td>
            <td>
                <asp:Label ID="lbl_place_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
     
        <tr>
            <td align="right">
               ที่อยู่ :</td>
            <td class="auto-style1">
                <asp:Label ID="lbl_number" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                ซอย :</td>
            <td>
                <asp:Label ID="lbl_lane" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
               ถนน :</td>
            <td>
                <asp:Label ID="lbl_road" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
               หมู่ :</td>
            <td>
                <asp:Label ID="lbl_village_no" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                ตำบล :</td>
            <td>
                <asp:Label ID="lbl_sub_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                อำเภอ :</td>
            <td>
                <asp:Label ID="lbl_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                จังหวัด :</td>
            <td>
                <asp:Label ID="lbl_province" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
             โทรศัพท์ :</td>
            <td class="auto-style9">
                <asp:Label ID="lbl_tel" runat="server" Text="-"></asp:Label>
            </td>
        <tr>
            <td align="right">
            ขออนุญาต :</td>
            <td>
                <asp:RadioButton ID="rdb_samples_drug" runat="server" Text="ผลิตยาตัวอย่าง" AutoPostBack="True" Enabled="False"></asp:RadioButton>
                <asp:RadioButton ID="rdb_direct_registers" runat="server" Text="นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรเพื่อขอขึ้นทะเบียน" AutoPostBack="True" Enabled="False"></asp:RadioButton>
            </td>
        </tr>
            <tr>
            <td align="right">
             ชื่อยา :</td>
            <td>
                <asp:Label ID="lbl_drugthanm" runat="server" Text="-"></asp:Label>
                &nbsp;
                <asp:Label ID="lbl_drugengnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                ลักษณะและสีของยา :</td>
            <td>
                <asp:Label ID="lbl_nature" runat="server" Text="-"></asp:Label>
            </td>
            <tr>
              <td class="auto-style10">

                   <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" width="200%" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="iowanm" HeaderText="ตัวยาสำคัญ" DataField="iowanm" >
                            </telerik:GridBoundColumn> 
                            <telerik:GridBoundColumn UniqueName="DOSAGE" HeaderText="ปริมาณ" DataField="DOSAGE" >
                            </telerik:GridBoundColumn>                          
                            <telerik:GridBoundColumn UniqueName="Unit" HeaderText="หน่วย" DataField="sunitengnm" >
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>

                                    </td>
                                </tr>
          <tr>
            <td align="right">
            ขออนุญาต :</td>
            <td>
                <asp:RadioButton ID="rdb_drug_produce" runat="server" Text="ยาที่ผลิต" AutoPostBack="True" Enabled="False"></asp:RadioButton>
                <asp:RadioButton ID="rdb_direct" runat="server" Text="ยาที่นำนำหรือสั่งเข้ามาในราชอาณาจักร" AutoPostBack="True" Enabled="False"></asp:RadioButton>
            </td>
        </tr>
        <tr>
        <td align="right">
            หน่วยนับตามรูปแบบยา :</td>
        <td class="auto-style7">
            <%--<asp:DropDownList ID="ddl_unit" runat="server" DataTextField="unit_name" DataValueField="unit_name" AutoPostBack="True">
            </asp:DropDownList>--%>
            <asp:Label ID="lbl_unit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
            <asp:label ID="lbl_sunit_ida" runat="server" DataTextField="lbl_sunit_ida" DataValueField="lbl_sunit_ida" AutoPostBack="True" Visible="False"></asp:label>
        </td>
        </tr>
        <tr>
        <td align="right">
                ปริมาณที่จะผลิต/นำสั่ง :</td>
            <td class="auto-style7">
                <asp:Label ID="lbl_DOSAGE" runat="server" Text="-" AutoPostBack="True"></asp:Label>
                <asp:Label ID="lbl_unit2" runat="server" Text="-" AutoPostBack="True"></asp:Label>
               <%-- <asp:DropDownList ID="ddl_unit2" runat="server" DataTextField="unit_name" DataValueField="unit_name">
                </asp:DropDownList>--%>
            </td>
        </tr>
       <%-- <tr>
            <td class="auto-style3">
                <asp:button ID="btn_add" runat="server" Text="เพิ่มตัวยาสำคัญ"></asp:button>
            </td>
            </tr>--%>
         
         <tr>
            <td align="right">
                <asp:CheckBox ID="chk_unit" runat="server" Text="ขนาดบรรจุ :" AutoPostBack="true"></asp:CheckBox>

            <td class="auto-style11">
             ชื่อขนาดบรรจุ 
                <asp:TextBox ID="txt_packagename" runat="server"></asp:TextBox></br>
                จำนวน
                <asp:TextBox ID="txt_sunit" runat="server"></asp:TextBox>
                <asp:Label ID="lbl_sunit" runat="server"  Text="-" AutoPostBack="True"></asp:Label>
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
                <asp:TextBox ID="txt_barcode" runat="server"></asp:TextBox>
            </td>
        </tr>
            <tr>
            <td class="auto-style10">
                <asp:button ID="btn_add" runat="server" Text="เพิ่มขนาดบรรจุ"></asp:button>
            </td>
            </tr>
           <tr>
              <td class="auto-style10">

                   <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" width="200%" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                            <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                <ItemTemplate>
                                   <asp:CheckBox ID="checkColumn" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
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
            <td colspan="2">
                แนบเอกสารเพิ่มเติม </td>
        </tr>
        <tr>
            <td class="auto-style10">
                (1) ฉลากยา</td>
            <td>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:HyperLink ID="hp_file_name1" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td class="auto-style10">
                (2) เอกสารกำกับยา</td>
            <td>
                <asp:FileUpload ID="FileUpload2" runat="server" />
                <asp:HyperLink ID="hp_file_name2" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
     <tr>
            <td class="auto-style10">
                (3) เอกสารอืนๆ (ให้แนบเอกสารแสดงขั้นตอนการผลิตด้วย)</td>
            <td>
                <asp:FileUpload ID="FileUpload3" runat="server" />
                <asp:HyperLink ID="hp_file_name3" runat="server" Style="display:none;" Target="_blank"></asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
              </td>
            <td>
                <asp:Button ID="btn_save" runat="server" Text="บันทึก"></asp:Button>
                <asp:Button ID="btn_close" runat="server" Text="ยกเลิก"></asp:Button>
                <asp:Button ID="btn_gen" runat="server" Text="gen xml" />
            </td>
        </tr>
    </table>
