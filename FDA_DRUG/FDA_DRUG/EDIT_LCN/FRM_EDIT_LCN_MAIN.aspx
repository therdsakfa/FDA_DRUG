<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Auto_Menu.Master" CodeBehind="FRM_EDIT_LCN_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_EDIT_LCN_MAIN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
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
              //    Popups('POPUP_LCN_UPLOAD_ATTACH_SELECT.aspx');
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

           function closespinner() {
              alert('Download เสร็จสิ้น');
              $('#spinner').fadeOut('slow');
              $('#ContentPlaceHolder1_Button1').click();
          }
        </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="spinner" style=" background-color:transparent; display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>

    
    <div class="h3" style="padding-left:5%;">  <asp:Label ID="lbl_name" runat="server" Visible="false" Text=""></asp:Label> </div>
    
     <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4> คำขอแก้ไขใบอนุญาตสถานที่ด้านยา</h4> </div>
             <div  class="col-lg-8 col-md-8">
                               <p style="text-align:right;padding-right:5%;">

                                   <asp:Button ID="Button1" runat="server" Text="Button" style="display:none;" />


            <asp:Button ID="btn_download" runat="server" Text="ดาวน์โหลดคำขอ" CssClass="btn-lg"   />
        &nbsp;&nbsp;
            <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดคำขอ" CssClass="btn-lg"   />
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
                        <telerik:GridBoundColumn DataField="RCVNO_MANUAL" FilterControlAltText="Filter RCVNO_MANUAL column"
                           HeaderText="เลขรับที่" SortExpression="RCVNO_MANUAL" UniqueName="RCVNO_MANUAL">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="LCNNO_MANUAL" FilterControlAltText="Filter LCNNO_MANUAL column"
                           HeaderText="เลขที่ใบอนุญาต" SortExpression="LCNNO_MANUAL" UniqueName="LCNNO_MANUAL">
                       </telerik:GridBoundColumn>
                       <%--<telerik:GridBoundColumn DataField="lcntpcd" FilterControlAltText="Filter lcntpcd column"
                           HeaderText="ประเภท" SortExpression="lcntpcd" UniqueName="lcntpcd">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column"
                           HeaderText="ที่อยู่" SortExpression="fulladdr" UniqueName="fulladdr">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="lcnsid" FilterControlAltText="Filter lcnsid column"
                           HeaderText="รหัสผู้ประกอบการ" SortExpression="lcnsid" UniqueName="lcnsid">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="house_no" FilterControlAltText="Filter house_no column"
                           HeaderText="เลขสถานที่" SortExpression="house_no" UniqueName="house_no">
                       </telerik:GridBoundColumn>--%>
                       <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                           HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="TRANSACTION_UPLOAD" FilterControlAltText="Filter TRANSACTION_UPLOAD column"
                           HeaderText="เลขดำเนินการ" SortExpression="TRANSACTION_UPLOAD" UniqueName="TRANSACTION_UPLOAD" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                           CommandName="sel" Text="ดูข้อมูล">
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

</asp:Content>
