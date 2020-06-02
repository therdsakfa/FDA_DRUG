<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_EXTEND_TIME_LOCATION_MAIN_TOTAL.aspx.vb" Inherits="FDA_DRUG.FRM_EXTEND_TIME_LOCATION_MAIN_TOTAL" %>
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
            
             <div  class="col-lg-4 col-md-4"><h4> ใบอนุญาต</h4> </div>

         </div>
    
    </div>

       <div class="panel panel-body"  style="width:100%;padding-left:5%;">
           <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
             HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="Newcode_not" DataType="System.Int32" FilterControlAltText="Filter Newcode_not column"
             HeaderText="Newcode_not" ReadOnly="True" SortExpression="Newcode_not" UniqueName="Newcode_not" Display="false">
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="lcntpcd" FilterControlAltText="Filter lcntpcd column" 
            HeaderText="ประเภทคำขอ" SortExpression="lcntpcd" UniqueName="lcntpcd" >
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="lcnno_display_full" FilterControlAltText="Filter lcnno_display_full column" 
            HeaderText="เลขที่ใบอนุญาต" SortExpression="lcnno_display_full" UniqueName="lcnno_display_full" >
        </telerik:GridBoundColumn>
     <%--   <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter REQUEST_DATE column" DataType="System.DateTime" 
            HeaderText="วันที่รับเรื่อง"  SortExpression="REQUEST_DATE" UniqueName="REQUEST_DATE"  DataFormatString="{0:dd/MM/yyyy}"> 
        </telerik:GridBoundColumn>--%>
       <telerik:GridBoundColumn DataField="thanm" FilterControlAltText="Filter thanm column" 
            HeaderText="ชื่อสถานที่" SortExpression="thanm" UniqueName="thanm" >
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="thanm_addr" FilterControlAltText="Filter thanm_addr column" 
            HeaderText="ที่อยู่" SortExpression="thanm_addr" UniqueName="thanm_addr" >
        </telerik:GridBoundColumn>
     <%--   <telerik:GridBoundColumn DataField="grannm_lo" FilterControlAltText="Filter grannm_lo column" 
            HeaderText="ชื่อผู้ดำเนินกิจการ" SortExpression="grannm_lo" UniqueName="grannm_lo" >
        </telerik:GridBoundColumn>
            <telerik:GridBoundColumn DataField="thachngwtnm" FilterControlAltText="Filter thachngwtnm column" 
            HeaderText="จังหวัด" SortExpression="thachngwtnm" UniqueName="thachngwtnm" >
        </telerik:GridBoundColumn>--%>
        <telerik:GridBoundColumn DataField="extend_year" FilterControlAltText="Filter extend_year column" 
            HeaderText="ปีที่หมดอายุุ" SortExpression="extend_year" UniqueName="extend_year" >
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="pay_amount" FilterControlAltText="Filter pay_amount column" DataFormatString="{0:###,###.##}"
            HeaderText="ราคา" SortExpression="pay_amount" UniqueName="pay_amount" >
        </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="pay_amount44" FilterControlAltText="Filter pay_amount44 column"  DataFormatString="{0:###,###.##}"
            HeaderText="ราคาม.44" SortExpression="pay_amount44" UniqueName="pay_amount44" >
        </telerik:GridBoundColumn>
<%--        <telerik:GridBoundColumn DataField="cncnm" FilterControlAltText="Filter cncnm column" 
            HeaderText="สถานะ" SortExpression="cncnm" UniqueName="cncnm" >
        </telerik:GridBoundColumn>--%>
 <%--           <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                       CommandName="sel" Text="เลือกข้อมูล">
                       <HeaderStyle Width="70px" />
                   </telerik:GridButtonColumn>--%>
                   </Columns>
               </MasterTableView>
           </telerik:RadGrid>

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
