<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_RGT_EDIT_MAIN_STAFF.aspx.vb" Inherits="FDA_DRUG.FRM_RGT_EDIT_MAIN_STAFF" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                       var IDA = getQuerystring("rgt_ida");
                       //var FK_IDA = getQuerystring("FK_IDA");
                       var lcn_ida = getQuerystring("lcn_ida");
                       var process = getQuerystring("process");
                       //  $('#spinner').toggle('slow');
                       //Popups('POPUP_DH_UPLOAD.aspx?IDA=' + IDA + '&FK_IDA=' + FK_IDA + '&process=' + process);
                       Popups('FRM_RGT_UPLOAD.aspx?rgt_ida=' + IDA + '&process=' + process + '&lcn_ida=' + lcn_ida);
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
               function getQuerystring(key, default_) {
                   if (default_ == null) default_ = "";
                   key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
                   var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
                   var qs = regex.exec(window.location.href);
                   if (qs == null)
                       return default_;
                   else
                       return qs[1];
               }
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

    
    <div class="h3" style="padding-left:5%;">  <asp:Label ID="lbl_name" runat="server" Visible="false" Text=""></asp:Label> </div>
    
     <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4> คำขอแก้ไขเปลี่ยนแปลงทะเบียน</h4> </div>
             <div  class="col-lg-8 col-md-8">
                               <p style="text-align:right;padding-right:5%;">
                                   <table width="100%">
                                       <tr>
                                           <td align="right">
                                               <table>
                                                   <tr>
                                                       <td>&nbsp;</td>
                                                       <td>&nbsp;</td>
                                                       <td align="right">
                                                           &nbsp;&nbsp;
                                                       </td>
                                                       <td>
                                                           &nbsp;</td>
                                                   </tr>
                                               </table>
                                           </td>
                                       </tr>
                                   </table>
                                   
                                   
            
        
            
                                     <asp:Button ID="Button1" runat="server" Text="" style="display:none;"  />
                                     <asp:Button ID="Button2" runat="server" Text="" style="display:none;"  />
        </p>
                          </div>
         </div>
    
    </div>

       <div class="panel panel-body"  style="width:100%;padding-left:5%;">
           <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="P_IDA" DataType="System.Int32" FilterControlAltText="Filter P_IDA column" HeaderText="P_IDA"
                           SortExpression="P_IDA" UniqueName="P_IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="Newcode" FilterControlAltText="Filter Newcode column" HeaderText="Newcode"
                           SortExpression="Newcode" UniqueName="Newcode" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       
                        <telerik:GridBoundColumn DataField="STATUS_ID" DataType="System.Int32" FilterControlAltText="Filter STATUS_ID column" HeaderText="STATUS_ID"
                           SortExpression="STATUS_ID" UniqueName="STATUS_ID" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="RCVNO_MANUAL" FilterControlAltText="Filter RCVNO_MANUAL column"
                           HeaderText="เลขรับที่" SortExpression="RCVNO_MANUAL" UniqueName="RCVNO_MANUAL">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="RGTNO_DISPLAY" FilterControlAltText="Filter RGTNO_DISPLAY column"
                           HeaderText="เลขทะเบียน" SortExpression="RGTNO_DISPLAY" UniqueName="RGTNO_DISPLAY">
                       </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column"
                           HeaderText="ชื่อภาษาไทย" SortExpression="thadrgnm" UniqueName="thadrgnm">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column"
                           HeaderText="ชื่อภาษาอังกฤษ" SortExpression="engdrgnm" UniqueName="engdrgnm">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                           HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="EDIT_DESCRIPTION" FilterControlAltText="Filter EDIT_DESCRIPTION column"
                           HeaderText="รายละเอียดการแก้ไข" SortExpression="EDIT_DESCRIPTION" UniqueName="EDIT_DESCRIPTION">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                           HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                       </telerik:GridBoundColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                           CommandName="sel" Text="ดูข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_edt"
                           CommandName="edt" Text="แก้ไข">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_report2"
                           CommandName="_report" Text="ใบนัด">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="report" Text="เพิ่มการหยุดและขยายเวลา" UniqueName="report">
                               </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_trid"
                       CommandName="_trid" Text="ขอเลขดำเนินการ" ConfirmText="คุณต้องการทำต่อหรือไม่?">
                       <HeaderStyle Width="70px" />
                   </telerik:GridButtonColumn>
                   </Columns>
               </MasterTableView>
           </telerik:RadGrid>
    </div>
   



    <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียด<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    <div class="modal fade " id="myModal2">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    เสนอลงนาม
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
     <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"  />

    &nbsp;
</asp:Content>