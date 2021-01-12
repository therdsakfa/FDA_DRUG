<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_LCN_STAFF_LCN_INFORMATION.aspx.vb" Inherits="FDA_DRUG.FRM_LCN_STAFF_LCN_INFORMATION" MaintainScrollPositionOnPostback="true" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>--%>
     <script type="text/javascript" >



         $(document).ready(function () {


             function CloseSpin() {
                 $('#spinner').toggle('slow');
             }


             function Popups(url) { // สำหรับทำ Div Popup

                 $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                 var i = $('#f1'); // ID ของ iframe   
                 i.attr("src", url); //  url ของ form ที่จะเปิด
             }


             $('#ContentPlaceHolder1_btn_download_2').click(function () {
                 $('#spinner').fadeIn('slow');

             });

             $('#ContentPlaceHolder1_btn_download').click(function () {
                 $('#spinner').fadeIn('slow');

             });

         });
         function close_modal() { // คำสั่งสั่งปิด PopUp
             $('#myModal').modal('hide');
             $('#ContentPlaceHolder1_btn_reset').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
         }

         function Popups2(url) { // สำหรับทำ Div Popup

             $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
             var i = $('#f1'); // ID ของ iframe   
             i.attr("src", url); //  url ของ form ที่จะเปิด
         }


         function closespinner() {
             alert('Download เสร็จสิ้น');
             $('#spinner').fadeOut('slow');
             $('#ContentPlaceHolder1_Button1').click();
         }
        </script> 
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <h2>
        รายละเอียดใบอนุญาต
    </h2>
    <asp:Button ID="btn_reset" runat="server" Text="reset" CssClass="btn-lg" style="display:none;"/>
    <table class="table">
                <tr>
                    <td> เลขอนุญาต :</td>
                    <td>  <asp:Label ID="lbl_lcnno" runat="server" Text=""></asp:Label></td>
                    <td>เลขนิติฯ/เลขบัตรปชช.ผู้รับอนุญาต</td>
                    <td>
                        <asp:Label ID="lbl_citizenid" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>ชื่อสถานที่ :</td>
                    <td> <asp:Label ID="lbl_thanameplace" runat="server"></asp:Label></td>
                    <td>ชื่อผู้ดำเนินกิจการ :</td>
                    <td> <asp:Label ID="lbl_nameOperator" runat="server"></asp:Label></td>
                </tr>
    </table>

    <br />
    <h2>
        สถานะใบอนุญาต
    </h2>
    <table class="table">
                <tr>
                    <td> สถานะปัจจุบัน :</td>
                    <td>  <asp:Label ID="lbl_statname" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td> วันที่มีผล :</td>
                    <td>  
                        <asp:Label ID="lbl_date_cancel" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td> วันที่ออกให้ครั้งแรก</td>
                    <td>  
                        <asp:Label ID="lbl_first_appdate" runat="server" Text="-"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2"> 
                        <h2>การขอเปลี่ยนแปลงสถานะ&nbsp;</h2>
                    </td>
                </tr>
        <tr>
                    <td> เลือกสถานะใหม่ :</td>
                    <td>  
                        <asp:DropDownList ID="ddl_stat" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td> เลือกวันที่มีผล :</td>
                    <td>  
                        <telerik:RadDatePicker ID="rdp_cncdate" Runat="server">
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                
                <tr>
                    <td> &nbsp;</td>
                    <td>  <asp:Button ID="btn_c_stat" runat="server" Text="เปลี่ยนสถานะ" CssClass="btn-lg"/></td>
                </tr>
                 </table>
    <br />

    <h2>
        เวลาทำการ
    </h2>
    <table class="table">
        <tr>
            <td>เวลาทำการ :</td>
            <td style="width:30%;">
                <asp:TextBox ID="txt_time" runat="server" CssClass="input-sm" Width="250px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btn_time" runat="server" Text="เปลี่ยนเวลาทำการ" CssClass="btn-sm" Width="144px" />
            </td>
        </tr>

        <tr>
            <td>รูปแบบบ้านเลขที่ในไฟล์ pdf</td>
            <td style="width:30%;">
                <asp:DropDownList ID="ddl_template" runat="server" Width="80%">
                            <asp:ListItem Value="1">แบบปกติ</asp:ListItem>
                            <asp:ListItem Value="2">แบบบ้านเลขที่ยาว</asp:ListItem>
                        </asp:DropDownList></td>
            <td>
                <asp:Button ID="btn_template" runat="server" Text="เปลี่ยนรูปบบ pdf" CssClass="btn-sm" Width="144px" />
            </td>
        </tr>

    </table>
    <br />

    <h2>
        แก้ไขวันที่ให้ไว้ ณ และปีที่หมดอายุ
    </h2>

    <table class="table">
        <tr>
            <td>วันที่ให้ไว้ ณ  :</td>
            <td style="width:30%;">
                <asp:TextBox ID="txt_appdate" runat="server" CssClass="input-sm" Width="250px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btn_appdate" runat="server" Text="เปลี่ยนวันที่ให้ไว้ ณ" CssClass="btn-sm" Width="144px" />
            </td>
        </tr>

        <tr>
            <td>ปีที่หมดอายุ</td>
            <td style="width:30%;">
                <asp:TextBox ID="txt_expyear" runat="server" CssClass="input-sm" Width="250px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btn_expyear" runat="server" Text="เปลี่ยนปีที่หมดอายุ" CssClass="btn-sm" Width="144px" />
            </td>
        </tr>

    </table>
    <br />

    <h2>
        รูปถ่ายที่แนบในใบอนุญาต
        <table class="table">
            <tr>
                <td>

                    <telerik:RadBinaryImage ID="RadBinaryImage1" runat="server" Width ="114px" Height="152px" />

                </td>
            </tr>
            <tr>
                <td>
                    <table width="50%">
                        <tr>
                            <td width="50%"><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                            <td width="50%"><asp:Button ID="btn_upload_img" runat="server" Text="Upload รูป" CssClass="btn-sm" /></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </h2>
    <br />
    <asp:Panel ID="Panel2" runat="server" style="display:none;">
         <h2>ประเภทการขาย</h2>
         <table>
             <tr>
                 <td>
                     <asp:CheckBoxList ID="cbl_chk_sell_type_ky1" runat="server" AutoPostBack="true">
                         <asp:ListItem Value="1">ขายปลีก</asp:ListItem>
                         <asp:ListItem Value="2">ขายส่ง</asp:ListItem>
                         <asp:ListItem Value="3">ปรุงยาสำหรับผู้ป่วยเฉพาะราย</asp:ListItem>
                     </asp:CheckBoxList>
                 </td>
                 <td>
                     <asp:CheckBoxList ID="cbl_chk_sell_type_ky1_2" runat="server" style="display:none;">
                         <asp:ListItem Value="13">ขายส่งยาสำเร็จรูป</asp:ListItem>
                         <asp:ListItem Value="12">ขายส่งเภสัชเคมีภัณฑ์</asp:ListItem>
                     </asp:CheckBoxList>
                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Button ID="btn_save_ky1" runat="server" Text="บันทึก" CssClass="btn-sm" />
                 </td>
             </tr>
         </table>
     </asp:Panel>
    <br />
    <asp:Panel ID="Panel3" runat="server" style="display:none;">
         <h2>ประเภทการขายส่ง</h2>
         <table>
             <tr>
                 <td>
                     <asp:CheckBoxList ID="cbl_chk_sell_type_ky4" runat="server">
                         <asp:ListItem Value="13">ขายส่งยาสำเร็จรูป</asp:ListItem>
                         <asp:ListItem Value="12">ขายส่งเภสัชเคมีภัณฑ์</asp:ListItem>
                     </asp:CheckBoxList>
                 </td>
                 <td>

                 </td>
             </tr>
             <tr>
                 <td>
                     <asp:Button ID="btn_save_ky4" runat="server" Text="บันทึก" CssClass="btn-sm" />
                 </td>
             </tr>
         </table>
     </asp:Panel>

    <h2>
        รายละเอียดสถานที่ตั้ง
    </h2>
    <table class="table">
        <tr>
            <td align="right">
                
                <table>
                    <tr>
                        <td><asp:Button ID="btn_location_select" runat="server" Text="เลือกสถานที่ตั้ง" CssClass="btn-lg"/></td>
                        <td><asp:Button ID="btn_location" runat="server" Text="เพิ่มสถานที่ตั้งใหม่" CssClass="btn-lg" style="display:none;"/>
                            <%--<asp:Button ID="btn_location_ref" runat="server" Text="" CssClass="btn-lg"/>--%>

                        </td>
                    </tr>
                </table>
                <asp:HiddenField ID="hd_location" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="rglocation" runat="server">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                        <Columns>
                            <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                SortExpression="IDA" UniqueName="IDA" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                                HeaderText="ชื่อสถานที่" SortExpression="thanameplace" UniqueName="thanameplace">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่ตามทะเบียนราษฎร์" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_edit" HeaderText=""  Display="false"
                           CommandName="_edit" Text="แก้ไขคำผิดในที่อยู่เดิม">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <br />
                *หมายเหตุ หากมีการเพิ่มสถานที่ตั้งใหม่ ระบบจะทำการผูกกับใบอนุญาตให้อัติโนมัติ
            </td>
        </tr>
    </table>
    <br />
    <h2>
        รายละเอียดสถานที่เก็บ(ถ้ามี)
    </h2>
    <table class="table">
        <tr>
            <td align="right">
                <table>
                    <tr>
                        <td><asp:Button ID="btn_add_keep_select" runat="server" Text="เลือกสถานที่เก็บ" CssClass="btn-lg"/></td>
                        <td><asp:Button ID="btn_add_keep" runat="server" Text="เพิ่มสถานที่เก็บใหม่" CssClass="btn-lg" style="display:none;"/></td>
                    </tr>
                </table>
                <asp:HiddenField ID="hdkeep" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="rgkeep" runat="server">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                        <Columns>
                            <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                SortExpression="IDA" UniqueName="IDA" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                                HeaderText="ชื่อสถานที่เก็บ" SortExpression="thanameplace" UniqueName="thanameplace">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="edt" HeaderText="" Display="false"
                           CommandName="edt" Text="แก้ไข">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="del" HeaderText="" ConfirmText="ต้องการลบข้อมูลหรือไม่"
                           CommandName="del" Text="ลบข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <br />
                *หมายเหตุ เมื่อเพิ่มสถานที่เก็บใหม่ จะต้องทำการเลือกสถานที่เก็บทุกครั้ง ข้อมูลถึงจะเปลี่ยนตามที่เพิ่มเข้าไปใหม่
            </td>
        </tr>
    </table><br />
    <h2>
        รายละเอียดผู้ดำเนินกิจการ
    </h2>
    <table class="table">
        <tr>
            <td align="right">
                <asp:Button ID="btn_bsn" runat="server" Text="เปลี่ยนผู้ดำเนินกิจการ" CssClass="btn-lg"/>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="rg_bsn" runat="server">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                        <Columns>
                            <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                SortExpression="IDA" UniqueName="IDA" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="BSN_IDENTIFY" FilterControlAltText="Filter BSN_IDENTIFY column" HeaderText="BSN_IDENTIFY"
                                SortExpression="BSN_IDENTIFY" UniqueName="BSN_IDENTIFY" Display="false">
                            </telerik:GridBoundColumn>
                            
                            <telerik:GridBoundColumn DataField="BSN_THAIFULLNAME" FilterControlAltText="Filter BSN_THAIFULLNAME column"
                                HeaderText="ชื่อผู้ดำเนินกิจการ" SortExpression="BSN_THAIFULLNAME" UniqueName="BSN_THAIFULLNAME">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_edit" HeaderText="" ItemStyle-Width="15%"
                           CommandName="_edit" Text="อัพเดทข้อมูล" ConfirmText="ต้องการอัพเดทข้อมูลหรือไม่?">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_edit2" HeaderText="" ItemStyle-Width="15%"
                           CommandName="_edit2" Text="แก้ไขข้อมูลชื่อ-ที่อยู่เอง">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <br />
    <h2>
        รายละเอียดผู้รับอนุญาต
    </h2>
    <table class="table">
        <tr>
            <td align="right">
                <asp:Button ID="btn_lcnname" runat="server" Text="เปลี่ยนผู้รับอนุญาต" CssClass="btn-lg"/>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="rglcnname" runat="server">
                    <MasterTableView AutoGenerateColumns="False" DataKeyNames="identify" NoMasterRecordsText="ไม่พบข้อมูล">
                        <Columns>
                            <telerik:GridBoundColumn DataField="identify" DataType="System.String" FilterControlAltText="Filter identify column" HeaderText="เลขนิติบุคคล"
                                SortExpression="identify" UniqueName="identify">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="thanm" FilterControlAltText="Filter thanm column"
                                HeaderText="ชื่อผู้รับอนุญาต" SortExpression="thanm" UniqueName="thanm">
                            </telerik:GridBoundColumn>
                            <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_edit" HeaderText="" ItemStyle-Width="15%"
                           CommandName="_edit" Text="อัพเดทข้อมูล" ConfirmText="ต้องการอัพเดทข้อมูลหรือไม่?">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <br />
    <h2>
        รายละเอียดผู้มีหน้าที่ปฏิบัติการ</h2>
    <table class="table">
        <tr>
            <td align="right">
                <asp:Button ID="btn_phr_add" runat="server" Text="เพิ่มผู้มีหน้าที่ปฏิบัติการ" CssClass="btn-lg"/>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="rgphr" runat="server">
                       <MasterTableView AutoGenerateColumns="False" DataKeyNames="PHR_IDA" NoMasterRecordsText="ไม่พบข้อมูล">
                           <Columns>
                        
                               <telerik:GridBoundColumn DataField="PHR_IDA" FilterControlAltText="Filter PHR_IDA column"
                                   HeaderText="PHR_IDA" SortExpression="PHR_IDA" UniqueName="PHR_IDA" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="PHR_CTZNO" FilterControlAltText="Filter PHR_CTZNO column"
                                   HeaderText="เลขบัตรปชช." SortExpression="PHR_CTZNO" UniqueName="PHR_CTZNO" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="PHR_FULLNAME" FilterControlAltText="Filter PHR_FULLNAME column"
                                   HeaderText="ชื่อผู้มีหน้าที่ปฏิบัติการ" SortExpression="PHR_FULLNAME" UniqueName="PHR_FULLNAME">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="PHR_TEXT_WORK_TIME" FilterControlAltText="Filter PHR_TEXT_WORK_TIME column"
                                   HeaderText="เวลาทำการ" SortExpression="PHR_TEXT_WORK_TIME" UniqueName="PHR_TEXT_WORK_TIME" >
                               </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="functnm" FilterControlAltText="Filter functnm column"
                                   HeaderText="หน้าที่" SortExpression="functnm" UniqueName="functnm" >
                               </telerik:GridBoundColumn>
                               <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="edt"
                                   CommandName="edt" Text="แก้ไข">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
                               <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del" ItemStyle-Width="15%"
                                   CommandName="r_del" Text="ลบข้อมูลถาวร" ConfirmText="คุณต้องการลบผู้ปฏิบัติการหรือไม่">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
                           </Columns>
                       </MasterTableView>
                   </telerik:RadGrid>
            </td>
        </tr>
    </table>
    <br />
    <asp:Panel ID="Panel1" runat="server" style="display:none;">
        <h2>หมวดยา ผลิตยาโบราณ/วจ 3,4</h2>
        <table>
            <tr>
                <td>
                    หมวดยา
                </td>
                <td>
                    <asp:TextBox ID="txt_CATEGORY_DRUG" runat="server" Width="600px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_CATEGORY_DRUG" runat="server" Text="บันทึก" CssClass="btn-sm"/>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
     
    <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>
                       <asp:Label ID="lbl_title" runat="server" Text=""></asp:Label> </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
