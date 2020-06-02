<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN.Master" CodeBehind="FRM_LCN_STAFF_DRUG.aspx.vb" Inherits="FDA_DRUG.FRM_LCN_STAFF_CONFIRM" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
           <asp:GridView  ID="GV_lcnno"  runat="server" Width="100%"  DataKeyNames="IDA" CellPadding="4" CssClass="table" 
      ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
    <AlternatingRowStyle BackColor="White"  />
    <Columns>
        <asp:BoundField DataField="lcnno" HeaderText="เลขที่ใบอนุญาต" ItemStyle-Width ="10%" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="fulladdr" HeaderText="ที่อยู่" ItemStyle-Width ="30%" /> 
        <asp:BoundField DataField="lcnsid" HeaderText="รหัสผู้ประกอบการ" ItemStyle-Width ="10%" Visible="false"  />
        <asp:BoundField DataField="house_no" HeaderText="เลขสถานที่" ItemStyle-Width ="10%" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width ="10%" /> 
        <asp:BoundField DataField="TRANSACTION_UPLOAD" HeaderText="เลขดำเนินการ" ItemStyle-Width ="20%" /> 
         <%--<asp:BoundField DataField="rcvno" HeaderText="เลขที่รับ" ItemStyle-Width ="10%" ItemStyle-HorizontalAlign="Left" />
      
         <asp:BoundField DataField="rcvdate"  DataFormatString="{0:d}" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width ="20%" >
<ItemStyle Width="20%"></ItemStyle>
         </asp:BoundField>
         <asp:BoundField HeaderText="วันที่รับพิจารณา" DataFormatString="{0:d}" />
         <asp:BoundField HeaderText="วันที่แล้วเสร็จ" DataFormatString="{0:d}" />--%>
         <%--<asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                     <ItemTemplate>
                          <asp:Label ID="lbl_status" runat="server" ></asp:Label>
                     </ItemTemplate>
                </asp:TemplateField>--%>

        <asp:TemplateField ItemStyle-Width="10%">
                     <ItemTemplate>
                          
                   <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link"  CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />  &nbsp; &nbsp; &nbsp;
                        
                     </ItemTemplate>
                </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="10%">
                     <ItemTemplate>
                          
                   <%--<asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="0%" Visible CssClass="btn-link"  CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />  &nbsp; &nbsp; &nbsp;--%>
                         <%--<asp:Button ID="btn_lcn" runat="server" Text="เลือกข้อมูล" CommandName="lcn" Width="100%" CssClass="btn-link"   CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />--%>
            
                     </ItemTemplate>
                </asp:TemplateField>

        
    </Columns>
    <EmptyDataTemplate> <center>ไม่พบข้อมูล</center> </EmptyDataTemplate>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#8CB340 " Font-Bold="True" ForeColor="White"  CssClass="row"/>
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" CssClass="row" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>


    </div>
   



          <div  class="modal fade "  id="myModal">
             <div class="panel panel-info" style="width:100%">
                 <div class="panel-heading">
      <div class="modal-title text-center h1 " >รายละเอียด ใบอนุญาต<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                 </div>
    <div class="panel-body panel-info" style="width:100%">
   
           <iframe id="f1"  style="width:100%;  height:600px;" >
          </iframe>
        
        </div>
</div>
                 </div>
              </div>

     <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"  />

    &nbsp;
</asp:Content>
