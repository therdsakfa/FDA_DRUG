<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_RQT_REGIST_ANIMAL_INFORMATION.aspx.vb" Inherits="FDA_DRUG.FRM_RQT_REGIST_ANIMAL_INFORMATION" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="~/TABEAN_YA/UC/UC_general.ascx" TagPrefix="uc1" TagName="UC_general" %>
<%@ Register Src="~/TABEAN_YA/UC/UC_officer_che.ascx" TagPrefix="uc1" TagName="UC_officer_che" %>
<%@ Register Src="~/TABEAN_YA/UC/UC_recipe.ascx" TagPrefix="uc1" TagName="UC_recipe" %>
<%@ Register src="UC/UC_drug_properties_and_color.ascx" tagname="UC_drug_properties_and_color" tagprefix="uc2" %>
<%@ Register src="UC/UC_DETAIL_USE.ascx" tagname="UC_DETAIL_USE" tagprefix="uc3" %>
<%@ Register src="UC/UC_officer_in_country.ascx" tagname="UC_officer_in_country" tagprefix="uc4" %>
<%@ Register src="UC/UC_Condition.ascx" tagname="UC_Condition" tagprefix="uc5" %>
<%@ Register src="UC/UC_Packing_Size.ascx" tagname="UC_Packing_Size" tagprefix="uc6" %>
<%@ Register src="UC/UC_RGT_REFER.ascx" tagname="UC_RGT_REFER" tagprefix="uc7" %>
<%@ Register src="UC/UC_DTB.ascx" tagname="UC_DTB" tagprefix="uc8" %>
<%@ Register src="UC/UT_NAME_DRUG_EXPORT.ascx" tagname="UT_NAME_DRUG_EXPORT" tagprefix="uc9" %>
<%@ Register src="UC/UC_DRUG_KEEP.ascx" tagname="UC_DRUG_KEEP" tagprefix="uc10" %>
<%@ Register src="UC/UC_DRUG_ANIMAL.ascx" tagname="UC_DRUG_ANIMAL" tagprefix="uc11" %>
<%@ Register src="UC/UC_UPLOAD_DRUG_DOCUMENT.ascx" tagname="UC_UPLOAD_DRUG_DOCUMENT" tagprefix="uc12" %>
<%@ Register src="UC/UC_officer.ascx" tagname="UC_officer" tagprefix="uc13" %>
<%@ Register src="UC/UC_Packing_Size_V2.ascx" tagname="UC_Packing_Size_V2" tagprefix="uc14" %>
<%@ Register src="UC/UC_COLOR.ascx" tagname="UC_COLOR" tagprefix="uc15" %>
<%@ Register src="UC/UC_No_Use.ascx" tagname="UC_No_Use" tagprefix="uc16" %>
<%@ Register src="UC/UC_recipe_V2.ascx" tagname="UC_recipe_V2" tagprefix="uc17" %>
<%--<%@ Register Src="~/TABEAN_YA/UC/UC_officer_format_maintain.ascx" TagPrefix="uc1" TagName="UC_officer_format_maintain" %>

<%@ Register Src="~/TABEAN_YA/UC/UC_officer_in_country.ascx" TagPrefix="uc1" TagName="UC_officer_in_country" %>
<%@ Register Src="~/TABEAN_YA/UC/UC_officer_Animal_drug.ascx" TagPrefix="uc1" TagName="UC_officer_Animal_drug" %>
<%@ Register Src="~/TABEAN_YA/UC/UC_officer_drugname_export.ascx" TagPrefix="uc1" TagName="UC_officer_drugname_export" %>
<%@ Register Src="~/TABEAN_YA/UC/UC_officer_history.ascx" TagPrefix="uc1" TagName="UC_officer_history" %>
<%@ Register Src="~/TABEAN_YA/UC/UC_officer_refer.ascx" TagPrefix="uc1" TagName="UC_officer_refer" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Jsdate/ui.datepicker.js"></script>
    <script src="../Jsdate/ui.datepicker-th.js"></script>

    <script type="text/javascript" >
        function showdate(targetobject) {
            $(targetobject).datepicker({
                showOn: "button",
                buttonImage: "../jsdate/calendar.gif",
                buttonImageOnly: true

            });

        }

        $(document).ready(function () {
            $(window).load(function () {
                $.ajax({
                    type: 'POST',
                    data: { submit: true },
                    success: function (result) {
                        // $('#spinner').fadeOut('slow');
                    }
                });
            });
            showdate($("#ContentPlaceHolder1_txt_appdate"));

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            //$('#ContentPlaceHolder1_btn_upload_t').click(function () {

            //    //  $('#spinner').toggle('slow');
            //    Popups('../DR/POPUP_DR_UPLOAD.aspx');
            //    return false;
            //});

            $('#ContentPlaceHolder1_btn_download_t').click(function () {
                $('#spinner').fadeIn('slow');

            });

            //$('#ContentPlaceHolder1_btn_upload_ex').click(function () {

            //    //  $('#spinner').toggle('slow');
            //    Popups('../DS/POPUP_DS_UPLOAD.aspx');
            //    return false;
            //});

            $('#ContentPlaceHolder1_btn_download_ex').click(function () {
                $('#spinner').fadeIn('slow');

            });
            function Popups(url) { // สำหรับทำ Div Popup
                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }


        });


        function Popups2(url) { // สำหรับทำ Div Popup
            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }
        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }
        function closespinner() {
            $('#spinner').fadeOut('slow');
            alert('Download Success');
            $('#ContentPlaceHolder1_Button1').click();

        }
        </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table">
    
       <tr>
        <td colspan="2" >
            <h2>ข้อมูลทั่วไปผลิตภัณฑ์ยา<asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </h2>
        </td>
    </tr>


       <tr>
        <td width="40%">เลขทะเบียนตำรับยา</td>
        <td><asp:Label ID="lbl_rgtno" runat="server" ></asp:Label></td>
    </tr>
        
    <tr>
        <td >ชื่อการค้า (ภาษาไทย):</td>
        <td >
            <asp:Label ID="lbl_thadrgnm" runat="server" ></asp:Label></td>
    </tr>



    <tr>
        <td >ชื่อการค้า (ภาษาอังกฤษ):</td>
        <td >
            <asp:Label ID="lbl_engdrgnm" runat="server" ></asp:Label>
        </td>
    </tr>



    <tr>
        <td>ชื่อผู้รับอนุญาต : </td>
        <td >
            <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
        </td>
    </tr>



    <tr>
        <td>ชื่อสถานที่ :</td>
        <td >
            <asp:Label ID="lbl_thanameplace" runat="server" Text="-"></asp:Label>
        </td>
    </tr>



    <tr>
        <td>ที่ตั้ง :</td>
        <td >
            <asp:Label ID="lbl_addr" runat="server" Text="-"></asp:Label>
        </td>
    </tr>



    <tr>
        <td>ประเภทใบอนุญาต :</td>
        <td >
            <asp:Label ID="lbl_lcntpcd" runat="server" Text="-"></asp:Label>
        </td>
    </tr>



    <tr>
        <td>เลขที่ใบอนุญาต :</td>
        <td >
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
    <telerik:RadTabStrip ID="RadTabStrip1" runat="server" SelectedIndex="0" MultiPageID="RadMultiPage1" Orientation="VerticalLeft">
        <Tabs>
            <telerik:RadTab runat="server" Text="1.ข้อมูลทั่วไป" Selected="True" Value="1">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="2.ขนาดบรรจุ" Value="2">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="3.1 ผู้ผลิตต่างประเทศ" Value="3">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="3.2 ผู้ผลิตในประเทศ" Value="4">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="4.สูตรสาร" Value="5">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="5.การเก็บรักษา">
            </telerik:RadTab>     
            <telerik:RadTab runat="server" Text="6.กลุ่มตำรับ">
            </telerik:RadTab>
       <telerik:RadTab runat="server" Text="7.ข้อบ่งใช้">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="8.ลักษณะและสีของยา">
            </telerik:RadTab>

            <telerik:RadTab runat="server" Text="9.ข้อมูลยาสัตว์ " Value="10">
            </telerik:RadTab>
       
            <telerik:RadTab runat="server" Text="10.เงื่อนไข">
            </telerik:RadTab>
            
            <%--<telerik:RadTab runat="server" Text="8.การรายงานตามกฏหมาย">
            </telerik:RadTab>
       
            <telerik:RadTab runat="server" Text="9.ข้อบ่งใช้">
            </telerik:RadTab>
       
            <telerik:RadTab runat="server" Text="10.การออกหนังสือรับรอง">
            </telerik:RadTab>
       
            <telerik:RadTab runat="server" Text="11.ข้อมูลรหัสที่เกี่ยวข้องกับยา">
            </telerik:RadTab>
       
            <telerik:RadTab runat="server" Text="12.การรายงานการผลิตและการนำสั่ง">
            </telerik:RadTab>
       
            <telerik:RadTab runat="server" Text="13.ประวัติ">
            </telerik:RadTab>--%>
       
            <telerik:RadTab runat="server" Text="11.อ้างอิง">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="12.ผู้แทนจำหน่าย">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="13.ชื่อยาส่งออก">
            </telerik:RadTab>
<%--            <telerik:RadTab runat="server" Text="12.รูปแบบการเก็บรักษา">
            </telerik:RadTab>
            <telerik:RadTab runat="server" Text="13.ยาสัตว์">
            </telerik:RadTab>--%>
            
            <telerik:RadTab runat="server" Text="14.เอกสารกำกับยา">
            </telerik:RadTab>
            
            
        </Tabs>


    </telerik:RadTabStrip>
    <telerik:RadMultiPage ID="RadMultiPage1" runat="server" SelectedIndex="0" CssClass="fa left">
        <telerik:RadPageView ID="RadPageView1" runat="server" TabIndex="1">
            <h2>ข้อมูลทั่วไป </h2>
            <uc1:UC_general runat="server" ID="UC_general" />
            <br />

            <asp:Button ID="btn_update_gen" runat="server" Text="แก้ไขข้อมูล" CssClass="input-lg" />
            <br />

            <%--<uc2:UC_drug_properties_and_color ID="UC_drug_properties_and_color1" runat="server" />--%>
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView2" runat="server" TabIndex="2">
            <h2>ขนาดบรรจุ</h2>
            <table width="100%">
                            <tr>
                                <td>คำบรรยายขนาดบรรจุ</td>
                                <td width="70%">
                                    <asp:TextBox ID="txt_package" runat="server" TextMode="MultiLine" Height="300px" Width="100%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td width="70%">
                                    <asp:Button ID="btn_save_pack" runat="server" Text="บันทึก" />
                                </td>
                            </tr>
                        </table>
            <uc14:UC_Packing_Size_V2 ID="UC_Packing_Size_V21" runat="server" />
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView3" runat="server" TabIndex="3">
            <h2>ผู้ผลิตต่างประเทศ</h2>
            <uc13:UC_officer ID="UC_officer1" runat="server" />
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView4" runat="server" TabIndex="4">
                <h2>ผู้ผลิตในประเทศ</h2>
                <uc4:UC_officer_in_country ID="UC_officer_in_country1" runat="server" />
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView5" runat="server" TabIndex="5">
                <h2>สูตรสาร</h2>
                <uc1:UC_officer_che runat="server" ID="UC_officer_che" />
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView6" runat="server" TabIndex="6">
            <h2>การเก็บรักษา</h2>
            <uc10:UC_DRUG_KEEP ID="UC_DRUG_KEEP1" runat="server" />
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView7" runat="server" TabIndex="7">
            <h2>กลุ่มตำรับ</h2>

            <uc17:UC_recipe_V2 ID="UC_recipe_V21" runat="server" />

            <br />

        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView8" runat="server" TabIndex="8">
            <h2>ข้อบ่งใช้</h2>
            <uc3:UC_DETAIL_USE ID="UC_DETAIL_USE1" runat="server" />
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView9" runat="server" TabIndex="9">
            <h2>ลักษณะและสีของยา</h2>
            <uc15:UC_COLOR ID="UC_COLOR1" runat="server" />
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView10" runat="server" TabIndex="10" >
            <h2>ข้อมูลยาสัตว์</h2>
            <uc11:UC_DRUG_ANIMAL ID="UC_DRUG_ANIMAL1" runat="server" />
            <br />
            <uc16:UC_No_Use ID="UC_No_Use1" runat="server" />
            <br />

        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView11" runat="server" TabIndex="11">
            <h2>เงื่อนไข</h2>
            <uc5:UC_Condition ID="UC_Condition1" runat="server" />
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView12" runat="server" TabIndex="12">
            <h2>อ้างอิง</h2>
            <uc7:UC_RGT_REFER ID="UC_RGT_REFER1" runat="server" />
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView13" runat="server" TabIndex="13">
            <h2>ผู้แทนจำหน่าย</h2>
            <uc8:UC_DTB ID="UC_DTB1" runat="server" />
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView14" runat="server" TabIndex="14">
            <h2>ชื่อยาส่งออก</h2>
            <uc9:UT_NAME_DRUG_EXPORT ID="UT_NAME_DRUG_EXPORT1" runat="server" />
        </telerik:RadPageView>
        <telerik:RadPageView ID="RadPageView15" runat="server" TabIndex="15">
            <h2>เอกสารกำกับยา</h2>
            <uc12:UC_UPLOAD_DRUG_DOCUMENT ID="UC_UPLOAD_DRUG_DOCUMENT1" runat="server" />
        </telerik:RadPageView>
    </telerik:RadMultiPage>
    <br /><br />

    <table style="display:none;">
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


    
    <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>
                       <asp:Label ID="lbl_titlename" runat="server" Text=""></asp:Label></h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
    <asp:Button ID="btn_preview2" runat="server" Text="พิมพ์ย.2 แบบ Word" CssClass="input-lg" style="display:none;" />
    </asp:Content>