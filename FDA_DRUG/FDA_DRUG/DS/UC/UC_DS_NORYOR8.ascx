<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DS_NORYOR8.ascx.vb" Inherits="FDA_DRUG.UC_DS_NORYOR8" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<script type="text/javascript">



    $(document).ready(function () {
        //$(window).load(function () {
        //    $.ajax({
        //        type: 'POST',
        //        data: { submit: true },
        //        success: function (result) {
        //            $('#spinner').fadeOut(1);

        //        }
        //    });
        //});

        function CloseSpin() {
            $('#spinner').toggle('slow');
        }

        //$('#ContentPlaceHolder1_btn_upload').click(function () {
        //    var IDA = getQuerystring("IDA");
        //    var process = getQuerystring("process");
        //    Popups('POPUP_LCN_UPLOAD_ATTACH.aspx?IDA=' & IDA  & '&process=' & process & '');
        //    return false;
        //});

        //$('#ContentPlaceHolder1_btn_download').click(function () {
        //    Popups('POPUP_LCN_DOWNLOAD_DRUG.aspx');
        //    return false;
        //});

        function Popups(url) { // สำหรับทำ Div Popup

            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }




        $('#UC_DS_NORYOR8_btn_save').click(function () {
            $('#spinner').fadeIn('slow');

        });

    });
    function close_modal() { // คำสั่งสั่งปิด PopUp
        $('#myModal').modal('hide');
        $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
    }

    function Popups2(url) { // สำหรับทำ Div Popup

        $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
        var i = $('#f1'); // ID ของ iframe   
        i.attr("src", url); //  url ของ form ที่จะเปิด
    }
    function Popups3(url) { // สำหรับทำ Div Popup

        $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
        var i = $('#f3'); // ID ของ iframe   
        i.attr("src", url); //  url ของ form ที่จะเปิด
    }
    function Popups4(url) { // สำหรับทำ Div Popup

        $('#myModal4').modal('toggle'); // เป็นคำสั่งเปิดปิด
        var i = $('#f4'); // ID ของ iframe   
        i.attr("src", url); //  url ของ form ที่จะเปิด
    }
    function spin_space() { // คำสั่งสั่งปิด PopUp
        //    alert('123456');
        $('#spinner').toggle('slow');
        //$('#myModal').modal('hide');
        //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

    }
    function closespinner() {
        alert('Download เสร็จสิ้น');
        //$('#spinner').fadeOut('slow');
        $('#myModal').modal('hide');
        $('#Button1').click();
    }
</script>

<%--  <div style="text-align:center;" >  เลขที่ใบอนุญาตสถานที่&nbsp;&nbsp;&nbsp;&nbsp;  <asp:DropDownList ID="ddl_lcnno" runat="server" CssClass="input-lg"  Width="20%"></asp:DropDownList> &nbsp;
       <asp:Button ID="Btn_ok" runat="server" Text="ยืนยัน" CssClass="btn-info" Width="67px"/>
       <br />
    </div>--%>
  <%-- <asp:Button ID="Button1" runat="server" Text="ปิดหน้าต่าง" Height="53px" Width="145px" CssClass="auto-style12" Display="false" />--%>
<div class="auto-style15">
    <div id="spinner" style="background-color: transparent; display: none;">
        <img src="../../imgs/spinner.gif" alt="Loading" class="auto-style13" />
    </div>
    <style type="text/css">
        .box {
            border: 3px solid #8CB340;
            margin: 10px;
            border-radius: 20px;
        }

        .auto-style1 {
            height: 21px;
            text-align: left;
        }

        .auto-style9 {
            height: 24px;
            text-align: left;
        }

        .auto-style11 {
            text-align: left;
        }

        .auto-style12 {
            font-size: 18px;
        }

        .auto-style13 {
            position: absolute;
            top: 666px;
            left: 486px;
            height: 185px;
            width: 207px;
        }

        .auto-style15 {
            text-align: center;
        }

        .auto-style16 {
            text-align: center;
            width: 1233px;
            height: 46px;
        }

        .auto-style17 {
            text-align: center;
            width: 1238px;
        }

        .auto-style19 {
            width: 619px;
        }

        .auto-style20 {
            width: 623px;
        }

        .auto-style21 {
            width: 620px;
        }

        .auto-style22 {
            height: 26px;
            text-align: left;
        }
        .auto-style27 {
            width: 99%;
            height: 20px;
        }
    </style>
    <link href="../css/css_radgrid.css" rel="stylesheet" />

    <div class="box">
        <table class="auto-style27">
            <div class="panel-heading panel-title">
                    <h1 class="auto-style16">นำหรือสั่งยาตัวอย่างเข้ามาในราชอาณาจักรเพื่อขอขึ้นทะเบียนตำรับยา (นย8)</h1> (หากมีปัญหาเกี่ยวกับการใช้งานระบบหรือไม่พบตัวเลือกโปรดแจ้ง Drug-SmartHelp@fda.moph.go.th)
                       
                    </div>
        <br />
        </table>
    </div>

    <center><h3>ข้อมูลทั่วไป</h3></center>
    <div class="box">
        <table class="table" style="width: 100%;">
            <tr>
                <td align="right" class="auto-style19">เขียนที่ :</td>
                <td class="auto-style11"><asp:TextBox ID="txt_WRITE_AT" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style19">วันที่ :</td>
                <td class="auto-style11">
                          <asp:TextBox ID="txt_WRITE_DATE" runat="server" ReadOnly="True"></asp:TextBox>

                    &nbsp;<asp:Label ID="lbl_date" runat="server" Text="(ตัวอย่าง 31/12/2560)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style19">บัญชีรายการยา :</td>
                <td class="auto-style11">
                    <%--<asp:TextBox ID="txt_secrch" runat="server"></asp:TextBox>--%><%--<asp:DropDownList ID="ddl_search" runat="server" CssClass="btn-lg" Width="33%" Height="23px"></asp:DropDownList>
                    <asp:Button ID="btn_search" runat="server" Text="ดึงข้อมูล" CssClass="auto-style12" Height="53px" Width="100px"></asp:Button>--%>
                    <asp:Label ID="pid" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
    </div>

    <center><h3>ข้อมูลใบอนุญาต</h3></center>
    <div class="box">
        <table class="table" style="width: 100%;">
            <tr>
                <td align="right" class="auto-style21">ชื่อผู้รับอนุญาต :</td>
                <td class="auto-style11">
                    <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style21">ชื่อผู้ดำเนินกิจการ :</td>
                <td class="auto-style11">
                    <asp:Label ID="lbl_bsn_prefixed" runat="server" Text=""></asp:Label>
                    <asp:Label ID="lbl_bsn_name" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style21">เลขที่ใบอนุญาต :</td>
                <td class="auto-style11">
                    <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
                    <asp:Label ID="lbl_lcnno2" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style21">สถานที่ผลิต/นำสั่ง :</td>
                <td class="auto-style11">
                    <asp:Label ID="lbl_place_name" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style21">ที่อยู่ :</td>
                <td class="auto-style1">
                    <asp:Label ID="lbl_number" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style21">ซอย :</td>
                <td class="auto-style11">
                    <asp:Label ID="lbl_lane" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style21">ถนน :</td>
                <td class="auto-style11">
                    <asp:Label ID="lbl_road" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style21">หมู่ :</td>
                <td class="auto-style11">
                    <asp:Label ID="lbl_village_no" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style21">ตำบล :</td>
                <td class="auto-style11">
                    <asp:Label ID="lbl_sub_district" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style21">อำเภอ :</td>
                <td class="auto-style11">
                    <asp:Label ID="lbl_district" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style21">จังหวัด :</td>
                <td class="auto-style11">
                    <asp:Label ID="lbl_province" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style21">โทรศัพท์ :</td>
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
    <div >
        <table class="table" style="width: 100%;">
            <tr>
                <td align="right" class="auto-style20">ชื่อยา :</td>
                <td class="auto-style11">
                    <asp:Label ID="lbl_drugthanm" runat="server" Text="-"></asp:Label>
                    &nbsp;
                <asp:Label ID="lbl_drugengnm" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style20">ลักษณะและสีของยา :</td>
                <td class="auto-style11">
                    <asp:Label ID="lbl_nature" runat="server" Text="-"></asp:Label>
                </td>
            </tr>
            <tr>

                <td>
                <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None" Width="228%" ShowFooter="true" AutoGenerateColumns="false">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber">
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="iowanm" HeaderText="ตัวยาสำคัญ" DataField="iowanm">
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn UniqueName="QTY" HeaderText="ปริมาณ" DataField="QTY">
                                <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>
                            <%--<telerik:GridBoundColumn UniqueName="Unit" HeaderText="หน่วย" DataField="sunitengnm">
                            </telerik:GridBoundColumn>--%>
                                                           <telerik:GridBoundColumn UniqueName="unit_name" HeaderText="หน่วย" DataField="unit_name" >
                                                               <ItemStyle HorizontalAlign="Left" />
                            </telerik:GridBoundColumn>  
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                </td><td></td>
            </tr>
            <tr>
                <td align="right" class="auto-style20">หน่วยนับตามรูปแบบยา :</td>
                <td class="auto-style22">
                    <%--<telerik:GridBoundColumn UniqueName="Unit" HeaderText="หน่วย" DataField="sunitengnm">
                            </telerik:GridBoundColumn>--%>
                    <asp:Label ID="lbl_unit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
                    &nbsp;(
                    <asp:Label ID="Stext_unit" runat="server"></asp:Label>
                    )<asp:Label ID="lbl_sunit_ida" runat="server" DataTextField="lbl_sunit_ida" DataValueField="lbl_sunit_ida" AutoPostBack="True" Visible="False"></asp:Label>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <asp:DropDownList ID="ddl_snunit" runat="server" AutoPostBack="True" Visible="False">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" class="auto-style20">ปริมาณที่จะผลิต/นำสั่ง :</td>
                <td class="auto-style22">
                    <asp:DropDownList ID="ddl_package_unit" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                    &nbsp;&nbsp;
                <asp:TextBox ID="txt_qty" runat="server" AutoPostBack="True"></asp:TextBox>
                    &nbsp;
                <asp:Label ID="imp_unit" runat="server"></asp:Label>

                    &nbsp;
                <asp:Label ID="lbl_import_sum" runat="server"></asp:Label>
                    &nbsp;&nbsp;
                <asp:Button ID="Button3" runat="server" Text="บันทึก" CssClass="auto-style12" Height="53px" Width="100px" />
                    <br />
                    <%--<asp:Label ID="txt_imp" runat="server"></asp:Label>--%>
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
                            <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del">
                            </telerik:GridButtonColumn>
                        </Columns>
                    </MasterTableView>
                                        </telerik:RadGrid>
                </td>
        </tr>



            <%--<telerik:GridBoundColumn UniqueName="Unit" HeaderText="หน่วย" DataField="sunitengnm">
                            </telerik:GridBoundColumn>--%>
            <tr>
                <td align="right" class="auto-style20">&nbsp;</td>
                <td>
                    <asp:Button ID="btn_package" runat="server" Height="53px" Text="เพิ่ม/ลบ ขนาดบรรจุ" Width="180px" CssClass="auto-style12" />

                    <asp:Label ID="Label2" runat="server" Text="on" Visible="False"></asp:Label>
                </td>
            </tr>
            <tr id="package2" runat="server" style="display: none;">
                <td align="right" class="auto-style20">
                    <%--<telerik:GridBoundColumn UniqueName="Unit" HeaderText="หน่วย" DataField="sunitengnm">
                            </telerik:GridBoundColumn>--%><%--<asp:DropDownList ID="ddl_unit" runat="server" DataTextField="unit_name" DataValueField="unit_name" AutoPostBack="True">
            </asp:DropDownList>--%>
                    <asp:Label ID="lb_unit" runat="server" Text="ขนาดบรรจุ :"></asp:Label>
                </td>

                <td class="auto-style11">จำนวน
                <asp:TextBox ID="txt_sunit" runat="server" Height="22px"></asp:TextBox>
                    <asp:Label ID="lbl_sunit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
                    &nbsp;ต่อ&nbsp;
                    <asp:DropDownList ID="ddl_munit" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm" AutoPostBack="True"></asp:DropDownList>
                    <br />
                    จำนวน
                <asp:TextBox ID="txt_mamount" runat="server"></asp:TextBox>
                    <asp:Label ID="lbl_munit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
                    &nbsp;ต่อ&nbsp;
                <asp:DropDownList ID="ddl_bunit" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm"></asp:DropDownList>
                    <br />
                    ชื่อขนาดบรรจุ 
                <asp:TextBox ID="txt_packagename" runat="server"></asp:TextBox>
                    &nbsp;หมายเลขบาร์โค้ด
                <asp:TextBox ID="txt_barcode" runat="server" Width="128px"></asp:TextBox>
                    <br />
                    <asp:Button ID="btn_add" runat="server" Text="บันทึกขนาดบรรจุ" CssClass="auto-style12" Height="53px" Width="180px"></asp:Button>
                </td>
            </tr>
            <tr id="package3" runat="server" style="display: none;">
                <td class="auto-style20">

                    <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" Width="200%" ShowFooter="true" AutoGenerateColumns="false">
                        <MasterTableView>
                            <Columns>
                                <%-- <telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                <ItemTemplate>
                                   <asp:CheckBox ID="checkColumn" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
                                <telerik:GridBoundColumn UniqueName="IDA" HeaderText="IDA" DataField="IDA" Display="false">
                                     <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="RowNumber" HeaderText="ลำดับ" DataField="RowNumber">
                                     <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="PACKAGE_NAME" HeaderText="ชื่อขนาดบรรจุ" DataField="PACKAGE_NAME">
                                     <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="SMALL_AMOUNT" HeaderText="จำนวน" DataField="SMALL_AMOUNT">
                                     <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="SMALL_UNIT" HeaderText="หน่วย" DataField="SMALL_UNIT">
                                     <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="x" HeaderText="ต่อ" DataField="x">
                                     <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="MEDIUM_AMOUNT" HeaderText="จำนวน" DataField="MEDIUM_AMOUNT">
                                     <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="MEDIUM_UNIT" HeaderText="หน่วย" DataField="MEDIUM_UNIT">
                                     <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="fix_bigunit" HeaderText="จำนวน" DataField="fix_bigunit">
                                     <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="BIG_UNIT" HeaderText="หน่วย" DataField="BIG_UNIT">
                                     <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn UniqueName="BARCODE" HeaderText="หมายเลขบาร์โค้ด" DataField="BARCODE">
                                     <ItemStyle HorizontalAlign="Left" />
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn UniqueName="del" ButtonType="LinkButton" Text="ลบข้อมูล" CommandName="del">
                                </telerik:GridButtonColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>

                </td>
                <td>&nbsp;</td>
            </tr>

        </table>
    </div>

    <div class="auto-style17">
                        <asp:Button ID="btn_save" runat="server" Text="บันทึก" Height="53px" Width="145px" CssClass="auto-style12"></asp:Button>
                    &nbsp;
                <asp:Button ID="btn_back" runat="server" Text="ปิดหน้าต่าง" Height="53px" Width="145px" CssClass="auto-style12" />
                    </div>
             