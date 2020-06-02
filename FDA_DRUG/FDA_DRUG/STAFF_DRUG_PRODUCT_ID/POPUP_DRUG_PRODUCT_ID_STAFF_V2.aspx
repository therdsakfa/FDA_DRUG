<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DRUG_PRODUCT_ID_STAFF_V2.aspx.vb" Inherits="FDA_DRUG.POPUP_DRUG_PRODUCT_ID_STAFF_V2" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>

    <table style="width:100%;height:500px;">
        <tr>
            <td rowspan="2" style="width:70%;">

               <div class="panel-body">
                
                <br />
                   <asp:Panel ID="Panel_Set1" runat="server">

                   <table class="table" style="width: 100%">
                    <tr>
                        <td>ชื่อการค้า</td>
                        <td>
                            <asp:TextBox ID="Txt_TRADE_NAME" runat="server" CssClass="input-sm" Width="300px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ชื่อการค้าภาษาอังกฤษ</td>
                        <td>
                            <asp:TextBox ID="Txt_TRADE_NAME_ENG" runat="server" CssClass="input-sm" Width="300px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>รูปแบบยา</td>
                        <td>
                            <telerik:RadComboBox ID="rcb_gr_group" runat="server" Height="300px" Width="305"  DataValueField="IDA" DataTextField="thadsgnm" 
                        EmptyMessage="กรุณาเลือกรูปแบบยา" MarkFirstMatch="true">
                        
                    </telerik:RadComboBox>
                            <%--<asp:DropDownList ID="ddl_gr_group" runat="server" DataValueField="IDA" DataTextField="ctgthanm" CssClass="input-sm" Width="200px"></asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>ความแรง</td>
                        <td>
                            <asp:TextBox ID="Txt_DRUG_STR" runat="server" CssClass="input-sm" Width="300px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>ชื่อหรือรหัสยาที่ใช้ระหว่างวิจัย (ถ้ามี)</td>
                        <td>
                            <asp:TextBox ID="Txt_DRUG_NAME_OR_CODE" runat="server" CssClass="input-sm" Width="300px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                       <tr>
                           <td>แหล่งผลิตภัณฑ์</td>
                           <td>
                               <asp:RadioButtonList ID="rdl_national" runat="server" RepeatDirection="Horizontal" ReadOnly="True">
                                   <asp:ListItem Selected="True" Value="1">ในประเทศ</asp:ListItem>
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
                        <td>หน่วยนับตามรูปแบบยา (Physical Unit)</td>
                        <td>
                            <telerik:RadComboBox ID="rcb_small_unit" runat="server" EmptyMessage="กรุณาเลือกหน่วยนับ" Height="300px" MarkFirstMatch="true" Width="305" DataValueField="IDA" DataTextField="unit_name">
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
                            <asp:TextBox ID="Txt_TERM_TO_USE" runat="server" CssClass="input-sm" Width="400px" TextMode="MultiLine" Height="150px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                       <tr>
                        <td>ลักษณะและสีของยา</td>
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
                            &nbsp;</td>
                    </tr>
                    <tr>


                        <td colspan="2">
                            <asp:Panel ID="Panel1" runat="server">
                                <div class="panel-heading panel-title">
                                    <h4>ตัวยาสำคัญ (INN or Generic Name of Substance)</h4>
                                </div>
                                <table>

                                    <tr>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </table>


                                <table width="100%">
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
                                                        <telerik:GridBoundColumn UniqueName="DOSAGE" HeaderText="ปริมาณ" DataField="DOSAGE">
                                                        </telerik:GridBoundColumn>
                                                        <telerik:GridBoundColumn UniqueName="sunitengnm" HeaderText="หน่วย" DataField="sunitengnm">
                                                        </telerik:GridBoundColumn>
                                                    </Columns>
                                                </MasterTableView>
                                            </telerik:RadGrid>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <br />
                                            <div class="panel-heading panel-title">
                                                <h4>กลุ่มตำรับ (ATC)</h4>
                                            </div>
                                            <asp:Panel ID="Panel2" runat="server">
                                                <table width="100%">
                                                    <tr>
                                                        <td>
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
                                        <td>
                                            <br />
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

                    <asp:Panel ID="Panel3" runat="server">
            <div class="panel-footer " style="text-align: center;">
                <asp:Button ID="btn_next" runat="server" CssClass="btn-lg" Text="หน้าถัดไป" />
            </div>
        </asp:Panel>


                </asp:Panel>
                   <asp:Panel ID="Panel_Set2" runat="server" style="display:none;">
                   <div class="panel-heading panel-title">
                <h1>ที่อยู่</h1>
            </div>

       <div class="panel-heading panel-title">
                                    <h4>ผู้ผลิตในประเทศ</h4>
                                </div>
    <table style="width:100%;" class="table">
        <tr>
            <td align="right" style="width:100px">
                ชื่อสถานที่ผลิต :</td>
            <td colspan="3">
                <asp:TextBox ID="txt_thanameplace" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
        </tr>
        <%--<tr>
            <td align="right">
                ที่ตั้ง :</td>
            <td colspan="3">
                <asp:TextBox ID="txt_fulladdr" runat="server" CssClass="input-sm" Width="600px"></asp:TextBox>
            </td>
        </tr>--%>
        <tr>
            <td align="right">บ้านเลขที่</td>
            <td ><asp:TextBox ID="txt_addr" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right">ถนน</td>
            <td ><asp:TextBox ID="txt_road" runat="server"  CssClass="input-sm"  Width="80%"></asp:TextBox></td>
        </tr> 
        <tr>
            <td align="right">หมู่</td>
            <td ><asp:TextBox ID="txt_mu" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right" style="width:200px">ซอย</td>
            <td ><asp:TextBox ID="txt_soi" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
        </tr> 
         <tr>
            <td align="right">จังหวัด</td>
            <td >
      
                  <asp:DropDownList ID="ddl_bsn_jungwat"  CssClass="input-sm"  Width="80%" runat="server" AutoPostBack="True"></asp:DropDownList>
             </td>
            <td align="right">&nbsp;</td>
            <td >
      
                  &nbsp;</td>
        </tr> 
             <tr>
            <td align="right">อำเภอ</td>
            <td >

                  <asp:DropDownList ID="ddl_bsn_amper"  CssClass="input-sm"  Width="80%" runat="server" AutoPostBack="True"></asp:DropDownList>
            </td>
            <td align="right">ตำบล</td>
            <td >
                  <asp:DropDownList ID="ddl_bsn_tumbol"  CssClass="input-sm"  Width="80%" runat="server"></asp:DropDownList>
            </td>
        </tr> 
             <tr>
            <td align="right">รหัสไปรษณีย์</td>
            <td ><asp:TextBox ID="txt_zipcode" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right">เบอร์โทรศัพท์</td>
            <td ><asp:TextBox ID="txt_tel" runat="server"  CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
                 </tr>
      </table>
    
 <div class="panel-heading panel-title">
                                    <h4>ผู้ผลิตต่างในประเทศ</h4>
                                </div>
    <table style="width:100%;" class="table">
        <tr>
            <td align="right" >
                ชื่อสถานที่ผลิตในต่างประเทศ :</td>
            <td colspan="3">
                <asp:TextBox ID="txt_FRGN_NAME" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="right">
                ที่อยู่</td>
            <td colspan="3">
                <asp:TextBox ID="txt_FRGN_FULLADDR" runat="server" CssClass="input-sm" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">เมือง</td>
            <td ><asp:TextBox ID="txt_FRGN_CITY_NAME" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right" >รหัสไปรษณีย์&nbsp;</td>
            <td ><asp:TextBox ID="txt_FRGN_ZIPCODE" runat="server"  CssClass="input-sm"  Width="80%"></asp:TextBox></td>
        </tr>
        <%--<tr>
            <td align="right">บ้านเลขที่</td>
            <td style="width:300px"><asp:TextBox ID="txt_addr2" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right" style="width:200px">ถนน</td>
            <td ><asp:TextBox ID="txt_road2" runat="server"  CssClass="input-sm"  Width="80%"></asp:TextBox></td>
        </tr> 

        <tr>
            <td align="right">หมู่</td>
            <td style="width:300px"><asp:TextBox ID="txt_mu2" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right" style="width:200px">ซอย</td>
            <td ><asp:TextBox ID="txt_soi2" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
        </tr> 
         <tr>
            <td align="right">จังหวัด</td>
            <td >
      
                  <asp:DropDownList ID="ddl_bsn_jungwat2"  CssClass="input-sm"  Width="80%" runat="server" AutoPostBack="True"></asp:DropDownList>
             </td>
            <td align="right">&nbsp;</td>
            <td >
      
                  &nbsp;</td>
        </tr> 
             <tr>
            <td align="right">อำเภอ</td>
            <td >

                  <asp:DropDownList ID="ddl_bsn_amper2"  CssClass="input-sm"  Width="80%" runat="server" AutoPostBack="True"></asp:DropDownList>
            </td>
            <td align="right">ตำบล</td>
            <td >
                  <asp:DropDownList ID="ddl_bsn_tumbol2"  CssClass="input-sm"  Width="80%" runat="server"></asp:DropDownList>
            </td>
        </tr> 
             <tr>
            <td align="right">รหัสไปรษณีย์</td>
            <td ><asp:TextBox ID="txt_zipcode2" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right">เบอร์โทรศัพท์</td>
            <td ><asp:TextBox ID="txt_tel2" runat="server"  CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
                 </tr>--%>
        <tr>
            <td align="right">ประเทศ</td>
            <td >
                <asp:DropDownList ID="ddl_nat" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
            <td align="right" >&nbsp;</td>
            <td >&nbsp;</td>
        </tr>
        </table>         <div class="panel-heading panel-title">
                                    <h4>ผู้แทนจำหน่าย</h4>
                                </div>
    <table style="width:100%;" class="table">
        <tr>
            <td align="right" >
                ชื่อสถานที่ผลิต :</td>
            <td colspan="3">
                <asp:TextBox ID="txt_thanameplace3" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td align="right">บ้านเลขที่</td>
            <td style="width:200px"><asp:TextBox ID="txt_addr3" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right">ถนน</td>
            <td ><asp:TextBox ID="txt_road3" runat="server"  CssClass="input-sm"  Width="80%"></asp:TextBox></td>
        </tr> 

        <tr>
            <td align="right">หมู่</td>
            <td style="width:200px"><asp:TextBox ID="txt_mu3" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right" >ซอย</td>
            <td ><asp:TextBox ID="txt_soi3" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
        </tr> 
         <tr>
            <td align="right">จังหวัด</td>
            <td >
      
                  <asp:DropDownList ID="ddl_bsn_jungwat3"  CssClass="input-sm"  Width="80%" runat="server" AutoPostBack="True"></asp:DropDownList>
             </td>
            <td align="right">&nbsp;</td>
            <td >
      
                  &nbsp;</td>
        </tr> 
             <tr>
            <td align="right">อำเภอ</td>
            <td >

                  <asp:DropDownList ID="ddl_bsn_amper3"  CssClass="input-sm"  Width="80%" runat="server" AutoPostBack="True"></asp:DropDownList>
            </td>
            <td align="right">ตำบล</td>
            <td >
                  <asp:DropDownList ID="ddl_bsn_tumbol3"  CssClass="input-sm"  Width="80%" runat="server"></asp:DropDownList>
            </td>
        </tr> 
             <tr>
            <td align="right">รหัสไปรษณีย์</td>
            <td ><asp:TextBox ID="txt_zipcode3" runat="server"   CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
            <td align="right">เบอร์โทรศัพท์</td>
            <td ><asp:TextBox ID="txt_tel3" runat="server"  CssClass="input-sm"  Width="80%" ></asp:TextBox></td>
                 </tr>
      </table>
        <div class="panel-footer " style="text-align:center;">
       <asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" CssClass="btn-lg" Width="120px" />
        </div>
</asp:Panel>


            </div>
            </td>
             <td style="padding-left:10%;height:50%;" valign="top">

                 <table class="table" style="width:90%"> 
                     
                     <tr><td>
                         <asp:DropDownList ID="ddl_status" runat="server"  Width="80%" style="display:none;" >
                         </asp:DropDownList>
                         </td></tr>
                     
                     <tr><td>
                         วันที่
                         <asp:TextBox ID="txt_app_date" runat="server"></asp:TextBox>
                         </td></tr>
                     
                     <tr><td>
                         เหตุผลการยกเลิก
                         <asp:TextBox ID="txt_reject_remark" runat="server" TextMode="MultiLine" Width="80%" Height="120px"></asp:TextBox>
                         </td></tr>
                     
                     <tr><td>
                         <asp:Button ID="btn_confirm" runat="server" Text="ยืนยัน" CssClass="btn-lg"   Width="80%" style="display:none;" />
                         <asp:Button ID="btn_cancel" runat="server" Text="ยกเลิก" CssClass="btn-lg" OnClientClick="return confirm('คุณต้องการยกเลิกหรือไม่');"   Width="80%" />
                         </td></tr>
                     <tr><td>  <asp:Button ID="btn_load0" runat="server" Text="กลับหน้ารายการ" CssClass="btn-lg"   Width="80%" /></td></tr>

                 </table>
                 


             </td>
        </tr>
        <tr>
             <td style="width:30%;height:50%;padding-left:10%">

                 <br />
           
             </td>
        </tr>
        </table>
</asp:Content>
