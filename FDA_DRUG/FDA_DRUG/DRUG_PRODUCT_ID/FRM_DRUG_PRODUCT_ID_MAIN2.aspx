<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Empty.Master" CodeBehind="FRM_DRUG_PRODUCT_ID_MAIN2.aspx.vb" Inherits="FDA_DRUG.FRM_DRUG_PRODUCT_ID_MAIN2" %>
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

              //$('#ContentPlaceHolder1_btn_upload').click(function () {
              //    var IDA = getQuerystring("IDA");
              //    var process = getQuerystring("process");
              //    Popups('POPUP_LCN_UPLOAD_ATTACH.aspx?IDA=' & IDA  & '&process=' & process & '');
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
    
 <%--  <div style="text-align:center;" >  เลขที่ใบอนุญาตสถานที่&nbsp;&nbsp;&nbsp;&nbsp;  <asp:DropDownList ID="ddl_lcnno" runat="server" CssClass="input-lg"  Width="20%"></asp:DropDownList> &nbsp;
       <asp:Button ID="Btn_ok" runat="server" Text="ยืนยัน" CssClass="btn-info" Width="67px"/>
       <br />
    </div>--%>
      <div id="spinner" style=" background-color:transparent; display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>

    <div class="h3" style="padding-left:5%;">  </div>
    
     <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4> ลงทะเบียนผลิตภัณฑ์ยา</h4> </div>
                          <div  class="col-lg-8 col-md-8">
                               <p style="text-align:right;padding-right:5%;">
                               <asp:Button ID="btn_add" runat="server" Text="เพิ่มผลิตภัณฑ์หลัก" CssClass="btn-lg" /> &nbsp;
                                   <asp:Button ID="btn_add2" runat="server" Text="เพิ่มผลิตภัณฑ์แบบอ้างอิง" CssClass="btn-md"/>   
            <asp:Button ID="btn_download" runat="server" Text="ดาวน์โหลดคำขอ" CssClass="btn-lg"  style="display:none;" />
       
                                   &nbsp;
            <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดคำขอ" CssClass="btn-lg"  style="display:none;" />
                                     <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"  />
                                     <asp:Button ID="Button1" runat="server" Text="" style="display:none;"  />
        </p>
                          </div>

         </div>
    
    </div>

       <div class="panel panel-body"  style="width:100%;padding-left:5%;">
           <asp:GridView  ID="GV_lcnno"  runat="server" Width="100%"  DataKeyNames="IDA" CellPadding="4" CssClass="table" 
      ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" Font-Size="10pt">
    <AlternatingRowStyle BackColor="White"  />
    <Columns>
        <asp:BoundField DataField="LCNNO_DISPLAY" HeaderText="เลขที่ผลิตภัณฑ์" ItemStyle-Width ="10%" ItemStyle-HorizontalAlign="Left" >
<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
        </asp:BoundField>
        <asp:BoundField DataField="stat_name" HeaderText="สถานะ" ItemStyle-Width ="10%" > 
        <ItemStyle Width="10%" />
        </asp:BoundField>
        <asp:BoundField DataField="TRADE_NAME" HeaderText="ชื่อผลิตภัณฑ์" ItemStyle-Width ="10%" ItemStyle-HorizontalAlign="Left" >        
<ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
        </asp:BoundField>
        
        <asp:TemplateField ItemStyle-Width="10%">
                     <ItemTemplate>
                          
                   <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link"  CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />  &nbsp; &nbsp; &nbsp;
                        
                     </ItemTemplate>

<ItemStyle Width="10%"></ItemStyle>
                </asp:TemplateField>
        <asp:TemplateField>
                   <ItemTemplate>
                       <asp:Button ID="btn_accept" runat="server" OnClientClick="return confirm('คุณต้องการยืนยันข้อมูลหรือไม่');" Text="ยืนยันข้อมูล" CommandName="accept" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                   </ItemTemplate>
               </asp:TemplateField>
        <asp:TemplateField>
            <ItemTemplate>
                       <asp:Button ID="btn_edit" runat="server"  Text="แก้ไขเพิ่มเติม" CommandName="_edit" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                   </ItemTemplate>
            </asp:TemplateField>

         <asp:TemplateField >
                   
                 <ItemTemplate>
                       <asp:Button ID="btn_cancel" runat="server"  Text="ยกเลิก" OnClientClick="return confirm('คุณต้องการยกเลิกข้อมูลหรือไม่');" CommandName="_cancel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
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



    &nbsp;
</asp:Content>
