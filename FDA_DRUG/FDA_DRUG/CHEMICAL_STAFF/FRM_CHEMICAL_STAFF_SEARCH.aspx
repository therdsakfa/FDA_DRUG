<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_CHEMICAL_STAFF_SEARCH.aspx.vb" Inherits="FDA_DRUG.FRM_CHEMICAL_STAFF_SEARCH" %>
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
            <h2>ค้นหาสาร</h2>

        </div>


        <table style="width: 100%;" class=" table">
            <tr>
                <td>ชื่อสารที่ต้องการค้นหา</td>
                <td>
                    <asp:TextBox ID="txt_iowanm" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
                </td>

                <td>
                    <%--<asp:DropDownList ID="ddl_number" runat="server" CssClass="dropdown-tasks" AutoPostBack="True"></asp:DropDownList>--%>
                    เลข iowa (ยาว)</td>
                <td style="width:25%;">
                    <asp:TextBox ID="txt_iowa" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
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
                                <MasterTableView autogeneratecolumns="False" datakeynames="IDA">
                                    <Columns>
                                        <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                            HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="true">
                                        </telerik:GridBoundColumn>
                                         <telerik:GridBoundColumn DataField="cas_number" FilterControlAltText="Filter cas_number column"
                                            HeaderText="CAS NO." SortExpression="cas_number" UniqueName="cas_number">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="iowanm" FilterControlAltText="Filter iowanm column"
                                            HeaderText="ชื่อสาร" SortExpression="iowanm" UniqueName="iowanm">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="iowacd" FilterControlAltText="Filter iowacd column"
                                            HeaderText="iowacd" SortExpression="iowacd" UniqueName="iowacd">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="iowa" FilterControlAltText="Filter iowa column"
                                            HeaderText="iowa" SortExpression="iowa" UniqueName="iowa" Display="false">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="runno" FilterControlAltText="Filter runno column"
                                            HeaderText="runno" SortExpression="runno" UniqueName="runno">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="salt" FilterControlAltText="Filter salt column"
                                            HeaderText="salt" SortExpression="salt" UniqueName="salt">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="syn" FilterControlAltText="Filter syn column"
                                            HeaderText="syn" SortExpression="syn" UniqueName="syn">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="aori" FilterControlAltText="Filter aori column"
                                            HeaderText="aori" SortExpression="aori" UniqueName="aori">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="REGIS_STATUS" FilterControlAltText="Filter REGIS_STATUS column"
                                            HeaderText="REGIS_STATUS" SortExpression="REGIS_STATUS" UniqueName="REGIS_STATUS">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="INN" FilterControlAltText="Filter INN column"
                                            HeaderText="INN" SortExpression="INN" UniqueName="INN">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="INN_TH" FilterControlAltText="Filter INN_TH column"
                                            HeaderText="INN_TH" SortExpression="INN_TH" UniqueName="INN_TH">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridBoundColumn DataField="Version_update" FilterControlAltText="Filter Version_update column"
                                            HeaderText="Version update" SortExpression="Version_update" UniqueName="Version_update">
                                        </telerik:GridBoundColumn>
                                        <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                                           CommandName="_edit" Text="แก้ไข">
                                           <HeaderStyle Width="70px" />
                                       </telerik:GridButtonColumn>
                                    </Columns>
                                    </MasterTableView>
                            </telerik:RadGrid>
              <br />

        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>สาร </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
       <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"  />
</asp:Content>
