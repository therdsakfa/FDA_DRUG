<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_PHR_CANCEL.aspx.vb" Inherits="FDA_DRUG.FRM_PHR_CANCEL" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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




              $('#ContentPlaceHolder1_btn_download').click(function () {
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

      <div id="spinner" style=" background-color:transparent; display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>

    <div class="h3" style="padding-left:5%;">  </div>
    
     <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4> ยกเลิกผู้มีหน้าที่ปฏิบัติการ</h4> </div>
                          <div  class="col-lg-8 col-md-8">
                               <p style="text-align:right;padding-right:5%;">
                                   <table width="100%">
                                       <tr>
                                           <td>&nbsp;</td>
                                           <td>&nbsp;</td>
                                           <td align="right">
                                               เลขบัตรผู้มีหน้าที่ปฏิบัติการ<asp:TextBox ID="txt_bsn" runat="server"></asp:TextBox>
                                               <asp:Button ID="btn_download" runat="server" Text="ดาวน์โหลดคำขอ" CssClass="btn-lg" />&nbsp;&nbsp;
                                           </td>
                                           <td align="left">
                                               <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดคำขอ" CssClass="btn-lg" />
                                           </td>
                                       </tr>
                                   </table>
                                     <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"  />
                                     <asp:Button ID="Button1" runat="server" Text="" style="display:none;"  />
        </p>
                          </div>

         </div>
    
    </div>

       <div class="panel panel-body"  style="width:100%;padding-left:5%;">
           <table style="width:100%;">
               <tr>
                   <td align="right">
                       <telerik:RadGrid ID="RadGrid1" runat="server" AllowFilteringByColumn="True" AllowPaging="true" PageSize="15">
                           <MasterTableView AutoGenerateColumns="False">
                               <Columns>
                                   <telerik:GridBoundColumn AllowFiltering="true" DataField="IDA" DataType="System.Int32" Display="false" FilterControlAltText="Filter IDA column" HeaderText="IDA" SortExpression="IDA" UniqueName="IDA">
                                   </telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="RCVNO_DISPLAY" FilterControlAltText="Filter RCVNO_DISPLAY column" HeaderText="เลขรับที่" SortExpression="RCVNO_DISPLAY" UniqueName="RCVNO_DISPLAY">
                                   </telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="PHR_TXT_NUM" FilterControlAltText="Filter PHR_TXT_NUM column" HeaderText="เลขที่ใบประกอบโรคศิลป" SortExpression="PHR_TXT_NUM" UniqueName="PHR_TXT_NUM">
                                   </telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="PHR_CTZO" FilterControlAltText="Filter PHR_CTZO column" HeaderText="เลขบัตรประชาชน" SortExpression="PHR_CTZO" UniqueName="PHR_CTZO">
                                   </telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="PHR_FULL_NAME" FilterControlAltText="Filter PHR_FULL_NAME column" HeaderText="ชื่อ-นามสกุล" SortExpression="PHR_FULL_NAME" UniqueName="PHR_FULL_NAME">
                                   </telerik:GridBoundColumn>
                                   <telerik:GridBoundColumn DataField="PURPOSE" FilterControlAltText="Filter PURPOSE column" HeaderText="เหตุผลการแจ้งเลิก" SortExpression="PURPOSE" UniqueName="PURPOSE">
                                   </telerik:GridBoundColumn>
                                   <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="sel" Text="ดูข้อมูล" UniqueName="btn_Select">
                                       <HeaderStyle Width="70px" />
                                   </telerik:GridButtonColumn>
                               </Columns>
                           </MasterTableView>
                       </telerik:RadGrid>
                   </td>
               </tr>
           </table>
                      <div class="h5" style="padding-left:87%;">  
                        </div>
          
    </div>
    <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    แจ้งยกเลิกผู้มีหน้าที่ปฏิบัติการ<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>

    <div class="modal fade " id="myModal3">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียด หมวดยา<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f3" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    <div class="modal fade " id="myModal4">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    ประเภทขายส่ง<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f4" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    
</asp:Content>