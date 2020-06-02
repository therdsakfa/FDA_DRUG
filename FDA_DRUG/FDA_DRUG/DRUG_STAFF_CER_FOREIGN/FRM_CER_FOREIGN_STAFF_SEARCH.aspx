<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_CER_FOREIGN_STAFF_SEARCH.aspx.vb" Inherits="FDA_DRUG.FRM_CER_FOREIGN_STAFF_SEARCH" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style.css" rel="stylesheet" />
    <link href="../css/css_radgrid.css" rel="stylesheet" />
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
                   //  var IDA = getQuerystring("IDA");
                   //var FK_IDA = getQuerystring("FK_IDA");
                   // var process = getQuerystring("process");
                   //  $('#spinner').toggle('slow');
                   //Popups('POPUP_DH_UPLOAD.aspx?IDA=' + IDA + '&FK_IDA=' + FK_IDA + '&process=' + process);
                   Popups('POPUP_DH_UPLOAD.aspx');
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
            <h2>ค้นหา Cer</h2>

        </div>


        <table style="width: 100%;" class=" table">
            <tr>
                <td>เลขที่ CER</td>
                <td>
                    <asp:TextBox ID="txt_CER_NUMBER" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
                </td>

                <td>
                    ชื่อผู้ผลิตต่างประเทศ</td>
                <td style="width:25%;">
                    <asp:TextBox ID="txt_FOREIGN_LOCATION_NAME" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_filter" runat="server" Text="ค้นหา" Width="100px" CssClass="btn-lg" />
                </td>
            </tr>
        </table>
    </div>
    
   <hr />
   <div>
       <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15">
                                <MasterTableView autogeneratecolumns="False">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                            HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                                        </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="thacntnm" FilterControlAltText="Filter thacntnm column"
                                            HeaderText="ประเทศ" SortExpression="thacntnm" UniqueName="thacntnm">
                                        </telerik:GridBoundColumn>
                                        
                                        <telerik:GridBoundColumn DataField="CER_FORMAT" FilterControlAltText="Filter CER_FORMAT column"
                                            HeaderText="เลขที่ CER" SortExpression="CER_FORMAT" UniqueName="CER_FORMAT">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter REQUEST_DATE column"
                                            HeaderText="วันที่ยื่นคำขอ" SortExpression="REQUEST_DATE" UniqueName="REQUEST_DATE">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                                            HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="FOREIGN_LOCATION_NAME" FilterControlAltText="Filter FOREIGN_LOCATION_NAME column"
                                            HeaderText="ชื่อผู้ผลิตต่างประเทศ" SortExpression="FOREIGN_LOCATION_NAME" UniqueName="FOREIGN_LOCATION_NAME">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="cer_type" FilterControlAltText="Filter cer_type column"
                                            HeaderText="ประเภท CER" SortExpression="cer_type" UniqueName="cer_type">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_remark" CommandName="remark" Text="เหตุผลที่คืนคำขอ">

                   </telerik:GridButtonColumn>
                                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select" CommandName="sel" Text="ดูข้อมูล">
                                       </telerik:GridButtonColumn>
                                    </Columns>
                                    </MasterTableView>
                            </telerik:RadGrid>
              <br />

        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>รายละเอียด CER</h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
       <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"  />
</asp:Content>
