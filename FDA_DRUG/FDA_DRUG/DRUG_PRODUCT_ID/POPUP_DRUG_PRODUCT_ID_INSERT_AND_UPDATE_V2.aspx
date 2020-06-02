<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2.aspx.vb" Inherits="FDA_DRUG.POPUP_DRUG_PRODUCT_ID_INSERT_AND_UPDATE_V2" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
<%--    <script src="../js/jquery-1.8.3.js"></script>
    <script src="../js/jdropdown/jquery.searchabledropdown-1.0.7.min.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {  
             $("#ContentPlaceHolder1_ddl_gr_group").searchable();
             $("#ContentPlaceHolder1_ddl_chemecal").searchable();
             $("#ContentPlaceHolder1_ddl_atc").searchable();
             $("#ContentPlaceHolder1_ddl_small_unit").searchable();
             $("#ContentPlaceHolder1_ddl_first_unit").searchable();
         });

         </script>--%>
    <style type="text/css">
       /*.RadComboBox .rcbInner { 
            height: 22px; 
        }*/
       
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
        <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <div class="panel-heading panel-title">
                <h1>ผลิตภัณฑ์</h1> <br />
                (หากมีปัญหาเกี่ยวกับการใช้งานระบบหรือไม่พบตัวเลือกโปรดแจ้ง Drug-SmartHelp@fda.moph.go.th)
            </div>
            <div class="panel-body" style="width:100%">
                <asp:Panel ID="Panel4" runat="server">
                <table class="table" style="width: 100%">
                 <tr>
                        <td>
                            <asp:Label ID="lbl_PRODUCT_NAME" runat="server" Text="ชื่อผลิตภัณฑ์"></asp:Label>
                            ที่ต้องการเชื่อมโยง</td>
                        <td>
                            <asp:DropDownList ID="ddl_product" runat="server" CssClass="input-sm" Width="200px" AutoPostBack="True">
                            </asp:DropDownList>
&nbsp;<asp:Button ID="btn_search" runat="server" Text="ดึงข้อมูล" CssClass="btn-lg"  OnClientClick="return confirm('คุณต้องการดึงข้อมูลหรือไม่');"/></td>
                    </tr>
                    </table>
                </asp:Panel>
                <table class="table" style="width: 100%">
                    
                    <tr>
                        <td>ชื่อการค้า <font style="color:red;">*</font></td>
                        <td>
                            <asp:TextBox ID="Txt_TRADE_NAME" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                        &nbsp;</td>
                    </tr>
                    <tr>
                        <td>ชื่อการค้าภาษาอังกฤษ (<font style="color:red;">*</font>)</td>
                        <td>
                            <asp:TextBox ID="Txt_TRADE_NAME_ENG" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>รูปแบบยา <font style="color:red;">*</font></td>
                        <td>
                            <asp:DropDownList ID="ddl_gr_group" runat="server" DataValueField="IDA" DataTextField="thadsgnm" CssClass="input-sm" Width="200px" style="display:none;"></asp:DropDownList>
   
                            <telerik:RadComboBox ID="rcb_gr_group" runat="server" Height="300px" Width="305"  DataValueField="IDA" DataTextField="thadsgnm" 
                        EmptyMessage="กรุณาเลือกรูปแบบยา" MarkFirstMatch="true">
                        
                    </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ความแรง</td>
                        <td>
                            <asp:TextBox ID="Txt_DRUG_STR" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ชื่อหรือรหัสยาที่ใช้ระหว่างวิจัย (ถ้ามี)</td>
                        <td>
                            <asp:TextBox ID="Txt_DRUG_NAME_OR_CODE" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>แหล่งผลิตภัณฑ์</td>
                        <td>
                            <asp:RadioButtonList ID="rdl_national" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" Selected="True">ในประเทศ</asp:ListItem>
                                <asp:ListItem Value="2">ต่างประเทศ</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>เป็นยาที่ต้องมีการศึกษา BE</td>
                        <td>
                            <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="True" Selected="True">เป็น</asp:ListItem>
                                <asp:ListItem Value="False">ไม่เป็น</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>หน่วยนับตามรูปแบบยา (Physical Unit) <font style="color:red;">*</font></td>
                        <td>
                            <telerik:RadComboBox ID="rcb_small_unit" runat="server" EmptyMessage="กรุณาเลือกหน่วยนับ" 
                                Height="300px" MarkFirstMatch="true" Width="305" DataValueField="IDA" DataTextField="unit_name">
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:CheckBox ID="cb_other_unit" runat="server" Text="หน่วยนับทางชีวภาพ (Biological Unit)" AutoPostBack="true" />
                            <br />
                            (ถ้ามี)</td>
                        <td>
                            บรรจุใน <asp:DropDownList ID="ddl_bio_pack" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td>
                            หน่วย
                            <asp:DropDownList ID="ddl_bio_unit" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>ข้อบ่งใช้</td>
                        <td>
                            <asp:TextBox ID="Txt_TERM_TO_USE" runat="server" CssClass="input-sm" Width="400px" TextMode="MultiLine" Height="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ลักษณะและสีของยา <font style="color:red;">*</font></td>
                        <td>
                            <asp:TextBox ID="Txt_Drug_Nature" runat="server" CssClass="input-sm" Width="400px" TextMode="MultiLine" Height="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>หมายเหตุ</td>
                        <td>
                            <asp:TextBox ID="txt_REMARK" runat="server" CssClass="input-sm" Width="400px" TextMode="MultiLine" Height="150px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div style="text-align: center;">
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" /></td>
                                        <td>
                                            <asp:Button ID="btn_edit" runat="server" Text="แก้ไข" CssClass="btn-lg" /></td>
                                        <td>
                                            <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" /></td>
                                    </tr>
                                </table>

                                &nbsp;&nbsp;
                   &nbsp;&nbsp;

                            </div>
                        </td>
                    </tr>
                    <tr>


                        <td colspan="2">
                            <asp:Panel ID="Panel1" runat="server">
                                <div class="panel-heading panel-title">
                                    <h4>ตัวยาสำคัญ (INN or Generic Name of Substance) <font style="color:red;">*</font></h4>
                                </div>
                                <table>

                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:Label ID="lb_paylist" runat="server" Text="ตัวยาสำคัญ :"></asp:Label>
                                        </td>
                                        <td valign="top">
                                            <%--<asp:DropDownList ID="ddl_chemecal" runat="server" DataTextField="iowanm" DataValueField="IDA" Width="200px" CssClass="input-sm" style="display:none;">
                                            </asp:DropDownList>--%>
                                            <telerik:RadComboBox ID="rcb_chemecal" runat="server" Height="300px" Width="305" DataValueField="IDA" DataTextField="iowanm"
                                                EmptyMessage="กรุณาเลือกตัวยาสำคัญ" MarkFirstMatch="true">
                                            </telerik:RadComboBox>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td align="right">ปริมาณ :</td>
                                        <td>
                                            <asp:TextBox ID="Txt_DOSAGE" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddl_unit" runat="server">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">
                                            <asp:Button ID="btn_add" runat="server" CssClass="btn-lg" Text="เพิ่มตัวยาสำคัญ" />
                                        </td>
                                    </tr>
                                </table>


                                <table width="100%">
                                    <tr>
                                        <td align="right">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td>

                                            <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" Width="100%" ShowFooter="true" AutoGenerateColumns="false">
                                                <MasterTableView>
                                                    <Columns>

                                                        <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="IDA" HeaderText="IDA" DataField="IDA" Display="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="FK_IDA" HeaderText="FK_IDA" DataField="FK_IDA" Display="false">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="iowanm" HeaderText="ตัวยาสำคัญ" DataField="iowanm">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="DOSAGE" HeaderText="ปริมาณ" DataField="DOSAGE" DataType="System.String">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="sunitengnm" HeaderText="หน่วย" DataField="sunitengnm">
                                                        </telerik:GridBoundColumn>

                                                        <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del">
                                                        </telerik:GridButtonColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <div class="panel-heading panel-title">
                                                <h4>กลุ่มตำรับ (ATC) <font style="color:red;">*</font></h4>
                                            </div>
                                            <asp:Panel ID="Panel2" runat="server">
                                                <table width="100%">
                                                    <tr>
                                                        <td>กลุ่มตำรับ :
                                                    <asp:DropDownList ID="ddl_atc" runat="server" style="display:none;" CssClass="input-sm" DataTextField="atcnm" DataValueField="IDA" Width="200px">
                                                    </asp:DropDownList>
                                                            <telerik:RadComboBox ID="rcb_atc" runat="server" Height="300px" Width="305" DataValueField="atc_code" DataTextField="atcnm"
                                                                EmptyMessage="กรุณาเลือกกลุ่มตำรับ" MarkFirstMatch="true">
                                                            </telerik:RadComboBox>

                                                        </td>
                                                        <td>&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <asp:Button ID="btn_add2" runat="server" CssClass="btn-lg" Text="เพิ่มกลุ่มตำรับ" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <telerik:RadGrid ID="RadGrid2" runat="server" AutoGenerateColumns="false" GridLines="None" ShowFooter="true" Width="100%">
                                                                <MasterTableView>
                                                                    <Columns>
                                                                        <telerik:GridBoundColumn DataField="RowNumber" HeaderText="ลำดับ" UniqueName="RowNumber">
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="IDA" Display="false" HeaderText="IDA" UniqueName="IDA">
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="FK_IDA" Display="false" HeaderText="FK_IDA" UniqueName="FK_IDA">
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="atccd" HeaderText="รหัส" UniqueName="atccd">
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridBoundColumn DataField="atcnm" HeaderText="กลุ่มตำรับ" UniqueName="atcnm">
                                                                        </telerik:GridBoundColumn>
                                                                        <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="del" Text="ลบข้อมูล" UniqueName="del">
                                                                        </telerik:GridButtonColumn>
                                                                    </Columns>
                                                                </MasterTableView>
                                                            </telerik:RadGrid>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>

                                        </td>
                                    </tr>
                                  
                                    <tr>
                                        <td align="center"></td>
                                    </tr>
                                </table>
                            </asp:Panel>

                        </td>
                    </tr>


                </table>
            </div>
        <asp:Panel ID="Panel3" runat="server">
            <div class="panel-footer " style="text-align: center;">
                <asp:Button ID="btn_next" runat="server" CssClass="btn-lg" Text="หน้าถัดไป" />
            </div>
        </asp:Panel>
              
        </div>

</asp:Content>
