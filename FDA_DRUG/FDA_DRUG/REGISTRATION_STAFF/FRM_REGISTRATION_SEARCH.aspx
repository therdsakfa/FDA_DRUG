<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_REGISTRATION_SEARCH.aspx.vb" Inherits="FDA_DRUG.FRM_REGISTRATION_SEARCH" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" >
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

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            $('#ContentPlaceHolder1_btn_upload').click(function () {
                var IDA = getQuerystring("IDA");
                /// var FK_IDA = getQuerystring("FK_IDA");
                // var process = getQuerystring("process");
                //  $('#spinner').toggle('slow');
                // Popups('POPUP_REGISTRATION_UPLOAD.aspx?IDA=' + IDA + '&FK_IDA=' + FK_IDA + '&process=' + process);
                Popups('POPUP_REGISTRATION_UPLOAD.aspx');

                return false;
            });

            $('#ContentPlaceHolder1_btn_download').click(function () {
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
        function Popups3(url) { // สำหรับทำ Div Popup
            $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f2'); // ID ของ iframe   
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

    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h1>ค้นหา บัญชีรายการขอขึ้นทะเบียนยา</h1>
            <br />
        </div>

        <asp:Button ID="btn_reload" runat="server" Text="Button"  style="display:none;"/>
        
    </div>
    
   <hr />
   <div>
       <table width="100%">
           <tr>
               <td>
                    <table style="width: 100%;" class=" table">
            <%--<tr>
                <td>กลุ่มงาน</td>
                <td Width="70%">
                                <asp:DropDownList ID="ddl_WORK_GROUP" runat="server" AutoPostBack="True" CssClass="input-lg" Width="70%">
                                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>ประเภทคำขอ</td>
                <td Width="70%">
                                <asp:DropDownList ID="ddl_category_requests" runat="server" CssClass="input-lg" Width="70%">
                                   
                                </asp:DropDownList>
                </td>
            </tr>--%>
<%--            <tr>
                <td>สถานะใบอนุญาต</td>
                <td Width="70%">
                                <asp:RadioButtonList ID="rdl_stat" runat="server" RepeatColumns="3" RepeatDirection="Horizontal" CssClass="input-lg" CellSpacing="10">
                                    <asp:ListItem Value="0" Selected="True">ทั้งหมด &nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem Value="1">คงอยู่ &nbsp;&nbsp;</asp:ListItem>
                                    <asp:ListItem Value="2">ยกเลิก &nbsp;&nbsp;</asp:ListItem>
                                </asp:RadioButtonList>
                </td>
            </tr>--%>
            <tr>
                <td>เลขนิติบุคคล/เลขบัตรประชาชน</td>
                <td Width="70%">
                                <asp:TextBox ID="txt_CITIZEN_AUTHORIZE" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>เลขรับ</td>
                <td Width="70%">
                                <asp:TextBox ID="txt_rcv_no" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                </td>
            </tr>
            <%--<tr>
                <td>เลขสถานที่</td>
                <td Width="70%">
                                <asp:TextBox ID="txt_lcnsid" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td>ชื่อยา</td>
                <td Width="70%">
                                <asp:TextBox ID="txt_drugname" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td Width="70%">
                               <asp:Button ID="btn_search" runat="server" Text="ค้นหาข้อมูล" CssClass="btn-lg"/>
                </td>
            </tr>
        </table>


               </td>
           </tr>
           <tr>
               <td>

                   &nbsp;</td>
           </tr>
           <br />
           
            <tr>
               <td align="right">
                   <%--<asp:Button ID="btn_export" runat="server" Text="Export ใบอนุญาตทั้งหมด" CssClass="btn-lg" />--%>
               </td>
           </tr>
           <tr>
               <td>

                   <%--*หมายเหตุ (1) วันที่ใช้ไปหมายถึง วันที่รับคำขอจนถึงวันที่คำนวณปัจจุบัน (คำนวณทุกวันศุกร์), (2) วันหยุดเวลาหมายถึง วันที่อยู่ในระหว่างการผ่อนผันของผู้ประกอบการ (3) วันที่แสดงเป็นวันทำการ</td>--%>
           </tr>
           </table>
       <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="rcvno" FilterControlAltText="Filter rcvno column"
                           HeaderText="เลขที่คำขอ" SortExpression="rcvno" UniqueName="rcvno">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="rcvdate" FilterControlAltText="Filter rcvdate column"
                           HeaderText="วันที่ยื่นคำขอ" SortExpression="rcvdate" UniqueName="rcvdate" DataType="System.DateTime" DataFormatString="{0:d}">
                       </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="REGIS_NO" FilterControlAltText="Filter REGIS_NO column"
                           HeaderText="เลข DL" SortExpression="REGIS_NO" UniqueName="REGIS_NO">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="DRUG_NAME_THAI" FilterControlAltText="Filter DRUG_NAME_THAI column"
                           HeaderText="ชื่อยา" SortExpression="DRUG_NAME_THAI" UniqueName="DRUG_NAME_THAI">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="DRUG_NAME_OTHER" FilterControlAltText="Filter DRUG_NAME_OTHER column"
                           HeaderText="ชื่อยาภาษาอังกฤษ" SortExpression="DRUG_NAME_OTHER" UniqueName="DRUG_NAME_OTHER">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="stat" FilterControlAltText="Filter stat column"
                           HeaderText="สถานะ" SortExpression="stat" UniqueName="stat">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                           HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                           CommandName="sel" Text="ดูข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_trid"
                       CommandName="_trid" Text="ขอเลขดำเนินการ" ConfirmText="คุณต้องการทำต่อหรือไม่?">
                       <HeaderStyle Width="70px" />
                   </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_add2" HeaderText="เพิ่มข้อมูลส่วนที่ 2"  
                            CommandName="_add2" Text="เพิ่มข้อมูลส่วนที่ 2">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="choose" HeaderText="เลือกข้อมูล"
                            CommandName="choose" Text="เลือกข้อมูล">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                   </Columns>
               </MasterTableView>
           </telerik:RadGrid>

              <br />

              <div style="text-align:center;"> 
              </div>  
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>รายละเอียด รายการขึ้นทะเบียนเรื่องขออนุญาตผลิตภัณฑ์ยา </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
    <div class=" modal fade" id="myModal2">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>เพิ่มข้อมูลส่วนที่ 2 </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="close_modal2();">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f2"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
