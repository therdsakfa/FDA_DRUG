<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_SUBSTITUTE_TABEAN_STAFF_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_SUBSTITUTE_TABEAN_STAFF_MAIN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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

              $('#ContentPlaceHolder1_btn_upload').click(function () {
                  Popups('POPUP_LCN_UPLOAD_ATTACH_SELECT.aspx');
                  return false;
              });

              $('#ContentPlaceHolder1_btn_download').click(function () {
                  Popups('POPUP_LCN_DOWNLOAD_DRUG.aspx');
                  return false;
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
          function spin_space() { // คำสั่งสั่งปิด PopUp
              //    alert('123456');
              $('#spinner').toggle('slow');
              //$('#myModal').modal('hide');
              //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

          }
          function close_modal() { // คำสั่งสั่งปิด PopUp
              $('#myModal').modal('hide');
              $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
          }

          function close_modal2() { // คำสั่งสั่งปิด PopUp
              $('#myModal2').modal('hide');
              $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
          }
        </script> 
    
 <%--  <div style="text-align:center;" >  เลขที่ใบอนุญาตสถานที่&nbsp;&nbsp;&nbsp;&nbsp;  <asp:DropDownList ID="ddl_lcnno" runat="server" CssClass="input-lg"  Width="20%"></asp:DropDownList> &nbsp;
       <asp:Button ID="Btn_ok" runat="server" Text="ยืนยัน" CssClass="btn-info" Width="67px"/>
       <br />
    </div>--%>
      <div id="spinner" style=" background-color:transparent; display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>

    
    <div class="h3" style="padding-left:5%;">  <asp:Label ID="lbl_name" runat="server" Visible="false" Text=""></asp:Label> </div>
    
     <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4> คำขอใบแทนใบสำคัญ</h4> </div>

         </div>
    
    </div>

       <div class="panel panel-body"  style="width:100%;padding-left:5%;">
           <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="RCVNO_MANUAL" FilterControlAltText="Filter RCVNO_MANUAL column"
                           HeaderText="เลขรับที่" SortExpression="RCVNO_MANUAL" UniqueName="RCVNO_MANUAL">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="RGTNO_DISPLAY" FilterControlAltText="Filter RGTNO_DISPLAY column"
                           HeaderText="เลขทะเบียน" SortExpression="RGTNO_DISPLAY" UniqueName="RGTNO_DISPLAY">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                           HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="PURPOSE" FilterControlAltText="Filter PURPOSE column"
                           HeaderText="เหตุผล" SortExpression="PURPOSE" UniqueName="PURPOSE">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                           HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                       </telerik:GridBoundColumn>
                       
                       <telerik:GridBoundColumn DataField="newcode" FilterControlAltText="Filter newcode column"
                           HeaderText="newcode" SortExpression="newcode" UniqueName="newcode" Display="false">
                       </telerik:GridBoundColumn>

                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                           CommandName="sel" Text="ดูข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_print" 
                           CommandName="print" Text="ใบสำคัญ">
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
                    รายละเอียด ใบอนุญาต<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
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
