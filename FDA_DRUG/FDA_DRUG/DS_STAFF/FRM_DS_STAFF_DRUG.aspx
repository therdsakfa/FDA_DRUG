﻿<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_DS_STAFF_DRUG.aspx.vb" Inherits="FDA_DRUG.FRM_DS_STAFF_DRUG" %>
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
            
             <div  class="col-lg-4 col-md-4"><h4> ใบอนุญาตขออนุญาตยาตัวอย่าง</h4> </div>

         </div>
    
    </div>

      <div class="panel panel-body"  style="width:100%;padding-left:5%;">
           <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="PROCESS_ID" DataType="System.Int32" FilterControlAltText="Filter PROCESS_ID column" HeaderText="PROCESS_ID"
                           SortExpression="PROCESS_ID" UniqueName="PROCESS_ID" Display="false">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="UPLOAD_DATE" FilterControlAltText="Filter UPLOAD_DATE column"
                           HeaderText="วันเวลาที่ส่งคำขอ" SortExpression="UPLOAD_DATE" UniqueName="UPLOAD_DATE">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="lcntpcd" FilterControlAltText="Filter lcntpcd column"
                           HeaderText="ประเภท" SortExpression="lcntpcd" UniqueName="lcntpcd">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="RCVNO_DISPLAY" FilterControlAltText="Filter RCVNO_DISPLAY column"
                           HeaderText="รหัสบัญชีรายการยา" SortExpression="RCVNO_DISPLAY" UniqueName="RCVNO_DISPLAY">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="drug_name" FilterControlAltText="Filter drug_name column"
                           HeaderText="ชื่อยา (Th/Eng)" SortExpression="drug_name" UniqueName="drug_name">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="ID" FilterControlAltText="Filter ID column"
                           HeaderText="เลขดำเนินการ" SortExpression="ID" UniqueName="ID">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                           HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                       </telerik:GridBoundColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                           CommandName="sel" Text="ดูข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_edit"
                           CommandName="_edit" Text="แก้ไขข้อมูลส่วนที่ 2">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                   </Columns>
               </MasterTableView>
           </telerik:RadGrid>
           </div>
           <%--<asp:GridView ID="GV_lcnno" runat="server" Width="100%" DataKeyNames="IDA" CellPadding="4" CssClass="table"
               ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
               <AlternatingRowStyle BackColor="White" />
               <Columns>
                   <asp:BoundField DataField="LCNNO_MANUAL" HeaderText="เลขที่ใบอนุญาต" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left" />
                   <asp:BoundField DataField="lcntpcd" HeaderText="ประเภท" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left" />

                   <asp:BoundField DataField="fulladdr" HeaderText="ที่อยู่" ItemStyle-Width="30%" />
                   <asp:BoundField DataField="lcnsid" HeaderText="รหัสผู้ประกอบการ" ItemStyle-Width="10%" Visible="false" />
                   <asp:BoundField DataField="house_no" HeaderText="เลขสถานที่" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left" />
                   <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width="10%" />
                   <asp:BoundField DataField="TRANSACTION_UPLOAD" HeaderText="เลขดำเนินการ" ItemStyle-Width="10%" />
                   <asp:CheckBoxField DataField="pay_stat_chk" HeaderText="การชำระเงิน" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                   <asp:TemplateField ItemStyle-Width="10%">
                       <ItemTemplate>
                           <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="20%">
                       <ItemTemplate>
                           <asp:Button ID="btn_edit" runat="server" Text="แก้ไขการเสนอลงนาม" CommandName="_edit" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                       </ItemTemplate>
                   </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="20%">
                       <ItemTemplate>
                       </ItemTemplate>
                   </asp:TemplateField>
               </Columns>
               <EmptyDataTemplate>
                   <center>ไม่พบข้อมูล</center>
               </EmptyDataTemplate>
               <EditRowStyle BackColor="#2461BF" />
               <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
               <HeaderStyle BackColor="#8CB340 " Font-Bold="True" ForeColor="White" CssClass="row" />
               <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
               <RowStyle BackColor="#EFF3FB" CssClass="row" />
               <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
               <SortedAscendingCellStyle BackColor="#F5F7FB" />
               <SortedAscendingHeaderStyle BackColor="#6D95E1" />
               <SortedDescendingCellStyle BackColor="#E9EBEF" />
               <SortedDescendingHeaderStyle BackColor="#4870BE" />
           </asp:GridView>--%>



   



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
                    ข้อมูลส่วนที่ 2
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
