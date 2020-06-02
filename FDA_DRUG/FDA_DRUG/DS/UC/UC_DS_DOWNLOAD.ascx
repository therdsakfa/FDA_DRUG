<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DS_DOWNLOAD.ascx.vb" Inherits="FDA_DRUG.UC_DS_DOWNLOAD" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">

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
        height: 53px;
    }
    .auto-style11 {
        height: 53px;
    }
    .auto-style12 {
        width: 417px;
        height: 30px;
    }
    .auto-style13 {
        height: 30px;
    }
</style>

<table class="table" style="width:100%;">
    <tr>
        <td align="right" class="auto-style3">
            เขียนที่ :</td>
        <td>
                <asp:Label ID="lbl_write_at" runat="server" Text="-"></asp:Label>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style3">
           วันที่ :</td>
        <td>
                <asp:Label ID="lbl_date" runat="server" Text="-"></asp:Label>
        </td>
        </tr>
         <tr>
            <td align="right" class="auto-style12">
                เลขบัญชีรายการยา :</td>
            <td class="auto-style13">
                <asp:Label ID="lbl_product_id" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
    <%--<tr>
            <td align="right" class="auto-style3">
                คำขออนุญาตนำหรือสั่งยา :</td>
            <td>
                <asp:RadioButton  ID="chk_for1" runat="server" GroupName="for" Text="แผนปัจจุบัน เข้ามาในราชอาณาจักรเพื่อการวิเคราะห์"></asp:RadioButton>
                <br />
                <asp:RadioButton ID="chk_for2" runat="server" GroupName="for"  Text="แผนโบราณ เข้ามาในราชอาณาจักรเพื่อการวิเคราะห์" AutoPostBack="True"></asp:RadioButton> 
            </td>
        </tr>--%>
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
                <asp:Label ID="lbl_rank" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                ในนามของ :</td>
            <td class="auto-style3">
                <asp:Label ID="lbl_inname" runat="server" Text="-"></asp:Label>

                
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style8">
                เลขที่ใบอนุญาต :</td>
            <td class="auto-style9">
                <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
                <asp:Label ID="lbl_lcnno2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style3">
                คำขออนุญาตนำหรือสั่งยาฯ ณ สถานที่ชื่อ :</td>
            <td>
                <asp:Label ID="lbl_place_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
         <tr>
        <td align="right" class="auto-style3">
            ชื่อผู้ดำเนินกิจการ :</td>
        <td>
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

                   <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" width="200%" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="iowanm" HeaderText="ตัวยาสำคัญ" DataField="iowanm" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="DOSAGE" HeaderText="จำนวน" DataField="DOSAGE" >
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="sunitengnm" HeaderText="หน่วย" DataField="sunitengnm" >
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>

                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                   </asp:ScriptManager>

                                    <br />

                                    </td>
                                </tr>
    <tr>
        <td align="right" class="auto-style3">
            หน่วยนับตามรูปแบบยา</td>
        <td>
            <asp:label ID="lbl_unitnm" runat="server" DataTextField="unit_name" DataValueField="unit_name" AutoPostBack="True">
            </asp:label>
            <asp:label ID="lbl_unite_ida" runat="server" DataTextField="lbl_unite_ida" DataValueField="lbl_unite_ida" AutoPostBack="True" Visible="False"></asp:label>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style6">
                ปริมาณที่จะผลิต/นำสั่ง :</td>
            <td class="auto-style7">
                <asp:label ID="lbl_DOSAGE" runat="server" Text=""></asp:label>
                <asp:Label ID="lbl_unit" runat="server" AutoPostBack="True"> </asp:Label>
            </td>
        </tr>
           <tr>
              <td class="auto-style3">

                   <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" width="200%" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
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
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>

                                    </td>
                                </tr>
        <tr>
            <td>
                <br />
            </td>
    </tr>
        <tr>
            <td align="right" class="auto-style3">
        <asp:Button ID="Button3" runat="server" Height="50px" Text="ดาวน์โหลด PDF" Width="150px" />

              </td>
            <td>
               <asp:Button ID="Button2" runat="server" Height="50px" Text="ไปยังหน้าอัพโหลดคำขอ" Width="150px" />

            </td>
        </tr>

    </table>

