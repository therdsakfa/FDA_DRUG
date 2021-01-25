<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DS_NORYORBOR8.ascx.vb" Inherits="FDA_DRUG.UC_DS_NORYORBOR8" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


    <script type="text/javascript" >



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




              $('#ContentPlaceHolder1_btn_save').click(function () {
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
              $('#spinner').fadeOut('slow');
              $('#ContentPlaceHolder1_Button1').click();
          }
        </script> 

            <div class="auto-style13">

            <div id="spinner" style=" background-color:transparent; display:none; " >
                <img src="../imgs/spinner.gif" alt="Loading" class="auto-style16" />
            </div>
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
    .auto-style9 {
        height: 24px;
        text-align: left;
    }
    .auto-style11 {
        font-size: 18px;
    }
    .auto-style12 {
        height: 53px;
    }
    .auto-style13 {
        text-align: center;
    }
    .auto-style14 {
        width: 1241px;
        height: 49px;
    }
    .auto-style15 {
        width: 99%;
    }
    .auto-style16 {
        position: absolute;
        top: 123px;
        left: 298px;
        height: 185px;
        width: 207px;
    }
    .auto-style17 {
        width: 619px;
    }
    .auto-style18 {
        text-align: left;
    }
    .auto-style19 {
        height: 26px;
        text-align: left;
    }
    .auto-style20 {
        width: 620px;
    }
    .auto-style21 {
        width: 618px;
    }
    .auto-style22 {
        height: 53px;
        width: 618px;
    }
    .auto-style23 {
        width: 618px;
        height: 23px;
    }
    .auto-style24 {
        text-align: left;
        height: 23px;
    }
</style>
                <link href="../css/css_radgrid.css" rel="stylesheet" />
     <div class="box">
         <table class="auto-style15">
    <div class="panel-heading panel-title">
                <h1 class="auto-style14">นำหรือสั่งยาเพื่อขอขึ้นทะเบียนตำรับ ยบ8(นยบ)</h1> (หากมีปัญหาเกี่ยวกับการใช้งานระบบหรือไม่พบตัวเลือกโปรดแจ้ง Drug-SmartHelp@fda.moph.go.th)
            </div>
             <br />
                </table>
          </div>

<center><h3>ข้อมูลทั่วไป</h3></center>
          <div class="box">
<table class="table" style="width:100%;">
    <tr>
            <td align="right" class="auto-style17">
            คำขออนุญาต :</td>
            <td class="auto-style18">
                <asp:RadioButton ID="rdb_sample_drug" runat="server" Text="ผลิตยาตัวอย่าง" AutoPostBack="True" GroupName="Drug" EnableTheming="True" ValidationGroup="Drug2" Enabled="False"></asp:RadioButton>
                </br>
                <asp:RadioButton ID="rdb_direct_register" runat="server" Text="นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักร" AutoPostBack="True" GroupName="Drug" Enabled="False"></asp:RadioButton>
               </br>
                _________________________
        </tr>
    <tr>
        <td align="right" class="auto-style17" >
            เขียนที่ :</td>
        <td class="auto-style19">
            <asp:TextBox ID="txt_WRITE_AT" runat="server"></asp:TextBox>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style17">
           วันที่ :</td>
        <td class="auto-style18">
            <asp:TextBox ID="txt_WRITE_DATE" runat="server" ReadOnly="True"></asp:TextBox>
            <asp:Label ID="lbl_date" runat="server" Text="(ตัวอย่าง 31/12/2560)"></asp:Label>
        </td>
        </tr>
         <tr>
            <td align="right" class="auto-style17">
                บัญชีรายการยา :</td>
            <td class="auto-style18">
                <asp:Label ID="pid" runat="server"></asp:Label>
                <%--<asp:DropDownList ID="ddl_search" runat="server" CssClass="btn-lg" Width="21%" Height="24px"></asp:DropDownList>
                <asp:button ID="btn_search" runat="server" Text="ดึงข้อมูล" CssClass="auto-style11" Height="53px" Width="100px"></asp:button>--%>
            </td>
        </tr>
    </table>
    </div>
<center><h3>ข้อมูลใบอนุญาต</h3></center>
<div class="box">
<table class="table" style="width:100%;">
        <tr>
            <td align="right" class="auto-style20">
                ชื่อผู้รับอนุญาต :</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_lcnsnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
        <td align="right" class="auto-style20">
            ชื่อผู้ดำเนินกิจการ :</td>
        <td class="auto-style18">
            <asp:Label ID="lbl_bsn_name" runat="server" Text="-"></asp:Label>
        </td>
        </tr>
         <tr>
            <td align="right" class="auto-style20">
            ได้รับอนุญาตให้ :</td>
            <td class="auto-style18">
                <asp:RadioButton ID="rdb_manufacture" runat="server" Text="ผลิตยาแผนโบราณ" AutoPostBack="True" Enabled="False"></asp:RadioButton>
                <asp:RadioButton ID="rdb_direct_license" runat="server" Text="นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรตามใบอนุญาต" AutoPostBack="True" Enabled="False"></asp:RadioButton>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style20">
                เลขที่ใบอนุญาต :</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_lcnno" runat="server" Text="-"></asp:Label>
                <asp:Label ID="lbl_lcnno2" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style20">
                สถานที่ประกอบธุรกิจ :</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_place_name" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
     
        <tr>
            <td align="right" class="auto-style20">
               ที่อยู่ :</td>
            <td class="auto-style1">
                <asp:Label ID="lbl_number" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style20">
                ซอย :</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_lane" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style20">
               ถนน :</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_road" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style20">
               หมู่ :</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_village_no" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style20">
                ตำบล :</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_sub_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style20">
                อำเภอ :</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_district" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style20">
                จังหวัด :</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_province" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style20">
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
            <td align="right" class="auto-style21">
            ขออนุญาต :</td>
            <td class="auto-style18">
                <asp:RadioButton ID="rdb_samples_drug" runat="server" Text="ผลิตยาตัวอย่าง" AutoPostBack="True" Enabled="False" EnableTheming="True" ValidationGroup="Drug2"></asp:RadioButton>
                <asp:RadioButton ID="rdb_direct_registers" runat="server" Text="นำหรือสั่งยาแผนโบราณเข้ามาในราชอาณาจักรเพื่อขอขึ้นทะเบียน" AutoPostBack="True" Enabled="False"></asp:RadioButton>
            </td>
        </tr>
            <tr>
            <td align="right" class="auto-style23">
             ชื่อยา :</td>
            <td class="auto-style24">
                <asp:Label ID="lbl_drugthanm" runat="server" Text="-"></asp:Label>
                &nbsp;
                <asp:Label ID="lbl_drugengnm" runat="server" Text="-"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right" class="auto-style21">
                ลักษณะและสีของยา :</td>
            <td class="auto-style18">
                <asp:Label ID="lbl_nature" runat="server" Text="-"></asp:Label>
            </td>
            <tr>
              <td class="auto-style21">

                   <telerik:RadGrid ID="RadGrid1" runat="server" GridLines="None"  ShowFooter="True" Width="228%" AutoGenerateColumns="False" CellSpacing="0">
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
                            <%--<telerik:GridBoundColumn UniqueName="Unit" HeaderText="หน่วย" DataField="sunitengnm" >
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
            <td align="right" class="auto-style21">
            ขออนุญาต :</td>
            <td class="auto-style18">
                <asp:RadioButton ID="rdb_drug_produce" runat="server" Text="ยาที่ผลิต" AutoPostBack="True" Enabled="False"></asp:RadioButton>
                <asp:RadioButton ID="rdb_direct" runat="server" Text="ยาที่นำนำหรือสั่งเข้ามาในราชอาณาจักร" AutoPostBack="True" Enabled="False"></asp:RadioButton>
            </td>
        </tr>
         <tr>
        <td align="right" class="auto-style21">
            หน่วยนับตามรูปแบบยา :</td>
        <td class="auto-style19">
            <%--<asp:DropDownList ID="ddl_unit" runat="server" DataTextField="unit_name" DataValueField="unit_name" AutoPostBack="True">
            </asp:DropDownList>--%>
            <asp:Label ID="lbl_unit" runat="server" Text="-" AutoPostBack="True"></asp:Label>
            &nbsp;(
            <asp:Label ID="Stext_unit" runat="server"></asp:Label>
            )
            <asp:label ID="lbl_sunit_ida" runat="server" DataTextField="lbl_sunit_ida" DataValueField="lbl_sunit_ida" AutoPostBack="True" Visible="False"></asp:label>
         
            <asp:HiddenField ID="HiddenField1" runat="server" />

            <asp:DropDownList ID="ddl_snunit" runat="server" AutoPostBack="True" Visible="False">
            </asp:DropDownList>
        </td>
        </tr>
        <tr>
        <td align="right" class="auto-style21">
                ปริมาณที่จะผลิต/นำสั่ง :</td>
             <td class="auto-style19">
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
        <td align="right" class="auto-style22">
                 </td>
        <td class="auto-style12">
               <asp:Button ID="btn_package" runat="server" Height="50px" Text="เพิ่ม/ลบ ขนาดบรรจุ" Width="180px" CssClass="auto-style11" />

            <asp:Label ID="Label2" runat="server" Text="on" Visible="False"></asp:Label>
        </td>
        </tr>
            <tr id="package2" runat="server" style="display: none;">
                <td align="right" class="auto-style21">
                <%--<asp:CheckBox ID="chk_unit" runat="server" Text="ขนาดบรรจุ :" AutoPostBack="True"></asp:CheckBox>--%>
                <%-- <tr id="package2" runat="server" style="display:none;">--%>
                    <asp:Label ID="lb_unit" runat="server" Text="ขนาดบรรจุ :"></asp:Label>
                </td>
                
                <td class="auto-style18">
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
                    ต่อ จำนวน
                <%--<asp:TextBox ID="txt_size4" runat="server"></asp:TextBox>--%>
                1
                <asp:DropDownList ID="ddl_bunit" runat="server" DataTextField="sunitengnm" DataValueField="sunitengnm"></asp:DropDownList>
                    <br />
                    หมายเลขบาร์โค้ด
                <asp:TextBox ID="txt_barcode" runat="server" Width="128px"></asp:TextBox>
                    </br>
                <asp:Button ID="btn_add" runat="server" Text="บันทึกขนาดบรรจุ" CssClass="auto-style11" Height="53px" Width="180px"></asp:Button>
                </td>
                <%--</tr>--%>
            </tr>
           <%-- <tr>
            <td class="auto-style10">
                <asp:button ID="btn_add" runat="server" Text="เพิ่มขนาดบรรจุ"></asp:button>
            </td>
            </tr>--%>
         <tr id="package3" runat="server" style="display:none;">
                <td class="auto-style21">

                   <telerik:RadGrid ID="RadGrid2" runat="server" GridLines="None" width="200%" ShowFooter="true" AutoGenerateColumns="false">
                   <MasterTableView>
                        <Columns>
                            <%--<telerik:GridTemplateColumn UniqueName="TemplateColumn">
                                <ItemTemplate>
                                   <asp:CheckBox ID="checkColumn" runat="server" />
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>--%>
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
                <p class="auto-style13">
                    &nbsp;</p>
</div>

            </td>
        </tr>
    
