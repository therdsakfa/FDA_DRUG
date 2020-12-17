<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DS_PORYOR8.ascx.vb" Inherits="FDA_DRUG.UC_DS_PORYOR8" %>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<style type="text/css">
      .box{
        border:3px solid #8CB340;
        margin:10px;
        border-radius: 20px;
    }
    .auto-style1 {
        height: 21px;
    }
    .auto-style7 {
        height: 26px;
    }
    .auto-style9 {
        height: 24px;
    }
    .auto-style11 {
        font-size: 18px;
    }
    .auto-style12 {
        width: 1243px;
    }
    .auto-style13 {
        width: 613px;
    }
    .auto-style14 {
        width: 619px;
    }
    .auto-style15 {
        height: 24px;
        width: 619px;
    }
    .auto-style17 {
        height: 24px;
        width: 644px;
    }
    .auto-style18 {
        width: 644px;
    }
    .auto-style19 {
        width: 644px;
        height: 57px;
    }
    .auto-style20 {
        height: 57px;
    }
    </style>
<link href="../css/css_radgrid.css" rel="stylesheet" />
<div class="box">
    <table class="table" style="width: 100%;">
    <div class="panel-heading panel-title">
                <center><h1 class="auto-style12">ผลิตยาตัวอย่างเพื่อขอขึ้นทะเบียนตำรับยา (ผย8)</h1></center> <center>(หากมีปัญหาเกี่ยวกับการใช้งานระบบหรือไม่พบตัวเลือกโปรดแจ้ง Drug-SmartHelp@fda.moph.go.th)</center>
            </div>
        <br />
                </table>
    </div>
 <center><h3>ข้อมูลทั่วไป</h3></center>
          <div class="box">
              <table class="table" style="width: 100%;">
    <tr>
        <td align="right" class="auto-style13" >
            เขียนที่ :</td>
        <td class="auto-style7">
    
            <asp:TextBox ID="txt_WRITE_AT" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style13">
           วันที่ :</td>
        <td>
            <asp:TextBox ID="txt_WRITE_DATE" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lbl_date" runat="server" Text="(ตัวอย่าง 31/12/2560)"></asp:Label>
        </td>
        </tr>
         <tr>
            <td align="right" class="auto-style13">
                บัญชีรายการยา :</td>
            <td>
                <%--<asp:DropDownList ID="ddl_search" runat="server" CssClass="btn-lg" Width="21%" Height="24px"></asp:DropDownList>
                <asp:button ID="btn_search" runat="server" Text="ดึงข้อมูล" CssClass="auto-style11" Height="53px" Width="100px"></asp:button>--%>
                <asp:Label ID="pid" runat="server"></asp:Label>
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
            <td>
                <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
                เลขที่ใบอนุญาต :</td>
            <td>
                <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
                <asp:Label ID="lbl_lcnno2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
                สถานที่ผลิต/นำสั่ง :</td>
            <td>
                <asp:Label ID="lbl_place_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
         <tr>
        <td align="right" class="auto-style14">
            ชื่อผู้ดำเนินกิจการ :</td>
        <td>
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
            <td>
                <asp:Label ID="lbl_lane" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
               ถนน :</td>
            <td>
                <asp:Label ID="lbl_road" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
               หมู่ :</td>
            <td>
                <asp:Label ID="lbl_village_no" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
                ตำบล :</td>
            <td>
                <asp:Label ID="lbl_sub_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style15">
                อำเภอ :</td>
            <td class="auto-style9">
                <asp:Label ID="lbl_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
                จังหวัด :</td>
            <td>
                <asp:Label ID="lbl_province" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style14">
             โทรศัพท์ :</td>
            <td class="auto-style9">
                <asp:Label ID="lbl_tel" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
                <td align="right" class="auto-style21">ผู้มีหน้าที่ปฏิบัติการ :</td>
                <td class="auto-style9">
                    <asp:DropDownList ID="ddl_phesaj" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
     </table>
    </div>

    <center><h3>ข้อมูลผลิตภัณฑ์ยา</h3></center>
<div class="box">
    <table class="table" style="width: 100%;">
            <tr>
            <td align="right" class="auto-style18">
             ชื่อยา :</td>
            <td>
                <asp:Label ID="lbl_drugthanm" runat="server" Text="-"></asp:Label>
                &nbsp;
                <asp:Label ID="lbl_drugengnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style17">
                ลักษณะและสีของยา :</td>
            <td class="auto-style9">
                <asp:Label ID="lbl_nature" runat="server" Text="-"></asp:Label>
            </td>
            <tr>
              <td class="auto-style18">

                   <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None"  ShowFooter="True" Width="150%" AutoGenerateColumns="False" CellSpacing="0" >
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
                            <%--  <telerik:GridBoundColumn UniqueName="Unit" HeaderText="หน่วย" DataField="sunitengnm" >
                            </telerik:GridBoundColumn>--%>                   
                               <telerik:GridBoundColumn UniqueName="unit_name" HeaderText="หน่วย" DataField="sunitengnm" >
                                    <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>   
                          
                        </Columns>
                    </MasterTableView>
                    </telerik:RadGrid>

                                    </td>
                                </tr>
        <tr>
        <td align="right" class="auto-style18">
            หน่วยนับตามรูปแบบยา :</td>
        <td class="auto-style7">
            <%--<asp:DropDownList ID="ddl_unit" runat="server" DataTextField="unit_name" DataValueField="unit_name" AutoPostBack="True">
            </asp:DropDownList>--%>
            <asp:Label ID="lbl_unit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
            &nbsp;(
            <asp:Label ID="Stext_unit" runat="server"></asp:Label>
            )<asp:label ID="lbl_sunit_ida" runat="server" DataTextField="lbl_sunit_ida" DataValueField="lbl_sunit_ida" AutoPostBack="True" Visible="False"></asp:label>
            <asp:HiddenField ID="HiddenField1" runat="server" />
            <asp:DropDownList ID="ddl_snunit" runat="server" AutoPostBack="True" Visible="False">
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style18">
                ปริมาณที่จะผลิต/นำสั่ง :</td>
             <td class="auto-style7">
                 <br />
                 <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal" AutoPostBack ="True" Height="30px" Width="457px">
                     <asp:ListItem Value="1">แบบระบุขนาดบรรจุแบบ SKU</asp:ListItem>
                     <asp:ListItem Value="2">แบบระบุปริมาณที่ต้องการ</asp:ListItem>
                 </asp:RadioButtonList>
                 <br />
                <asp:DropDownList ID="ddl_package_unit" runat="server" Visible="false" AutoPostBack="True">
                </asp:DropDownList>
                &nbsp;&nbsp;
                <asp:TextBox ID="txt_qty" runat="server" Visible="false" AutoPostBack="True"></asp:TextBox>
                &nbsp;
                <asp:Label ID="imp_unit" runat="server" Visible="false"></asp:Label>
 
                &nbsp;
                <asp:Label ID="lbl_import_sum" runat="server" Visible="false"></asp:Label>
            &nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Visible="false" Text="บันทึก" CssClass="auto-style11" Height="53px" Width="100px" />
                <br />
                 
                <%--<asp:Label ID="txt_imp" runat="server"></asp:Label>--%>
                 <asp:Label ID="all_sum" runat="server" Visible ="false"></asp:Label>  <asp:TextBox ID="txt_summ" runat="server" AutoPostBack="True" Visible ="false"></asp:TextBox>
                &nbsp;<asp:DropDownList ID="ddl_package_sum" runat="server" Visible="false" AutoPostBack="True">
                </asp:DropDownList>
                 <asp:Button ID="Button4" runat="server" Text="บันทึก" CssClass="auto-style11" Height="24px" Width="65px" Visible="false" />
            &nbsp;
                <asp:Label ID="sum_finally" runat="server"></asp:Label>
 
                <asp:Label ID="unit_finally" runat="server"></asp:Label>
 
                 <br />
                 <br />
 
                 <br />
 
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
                            <telerik:GridBoundColumn UniqueName="IM_DETAIL" HeaderText="รายละเอียดของสินค้าที่อนุญาต" DataField="IM_DETAIL" >
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
        <td align="right" class="auto-style19">
                 </td>
        <td class="auto-style20">
               <asp:Button ID="btn_package" runat="server" Height="53px" Text="เพิ่ม/ลบ ขนาดบรรจุ" Width="180px" CssClass="auto-style11" />

           <%-- <asp:Label ID="Label2" runat="server" Text="on" Visible="False"></asp:Label>
        </td>
        </tr>
            <tr id="package2" runat="server" style="display: none;">
                <td align="right" class="auto-style18">
                <%--<asp:CheckBox ID="chk_unit" runat="server" Text="ขนาดบรรจุ :" AutoPostBack="True"></asp:CheckBox>--%>
                <%-- <tr id="package2" runat="server" style="display:none;">--%>
<%--                    <asp:Label ID="lb_unit" runat="server" Text="ขนาดบรรจุ :"></asp:Label>
                </td>
                
                <td>
                    ชื่อขนาดบรรจุ 
                <asp:TextBox ID="txt_packagename" runat="server"></asp:TextBox></br>
                จำนวน
                <asp:TextBox ID="txt_sunit" runat="server" Height="22px"></asp:TextBox>
                    <asp:Label ID="lbl_sunit" runat="server" Text="-" AutoPostBack="True"></asp:Label>--%>
                   <%-- &nbsp;ต่อ--%>
                                </tr>
      <tr>
            <td align="right" class="auto-style18">
                สำหรับ :</td>
            <td>
                <asp:RadioButton  ID="chk_forhuman" runat="server" GroupName="for" Text="การศึกษาวิจัยในมนุษย์" Enabled="False"></asp:RadioButton>
                <br />
                <asp:RadioButton ID="chk_forother" runat="server" GroupName="for"  Text="กรณีอื่นๆ (ระบุ)" AutoPostBack="True" Enabled="False"></asp:RadioButton> 
                <asp:TextBox ID="txt_forother" runat="server" Text="" Visible="False" Width="618px"></asp:TextBox>
            </td>
        </tr>
            </table>
    </div>
        <tr>
            <td align="right" class="auto-style3">
              </td>
            <td>
               <asp:Button ID="btn_save" runat="server" Text="สร้างคำขอยาตัวอย่าง" Height="53px"  Width="185px" CssClass="auto-style11"></asp:Button>
                &nbsp;
                <asp:Button ID="btn_back" runat="server" Text="ปิดหน้าต่าง" Height="53px"  Width="150px" CssClass="auto-style11" />
                <%--<asp:Button ID="btn_gen" runat="server" Text="gen xml" />--%>
                 <%--<asp:Button ID="btn_genf" runat="server" Text="gen pdf"/>--%>
            </td>
            <td style="color:red">&nbsp;&nbsp;&nbsp;&nbsp;* โปรดนำคำขอที่สร้างขึ้นไปอัพโหลดในขั้นตอนต่อไป</td>
        </tr>


