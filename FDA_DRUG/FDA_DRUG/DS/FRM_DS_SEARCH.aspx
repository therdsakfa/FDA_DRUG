<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Empty.Master" CodeBehind="FRM_DS_SEARCH.aspx.vb" Inherits="FDA_DRUG.FRM_DS_SEARCH" %>
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

     <div id="spinner" style=" background-color:transparent; display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>
       <div class="h3" style="padding-left:5%;">  
       </div>
    
     <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:85px" > 
            
              <div  class="col-lg-4 col-md-4"><h4> ใบอนุญาต<asp:Label ID="lbl_name_2" runat="server"  Text=""></asp:Label><asp:Label ID="lbl_name" runat="server"  Text=""></asp:Label> </h4> </div>
                          <div  class="col-lg-8 col-md-8">
                              <table style="width:100%;">
                                  <tr>
                                      <td style="width:15%;">

                                      </td>
                                      <td style="width:25%;">
                                       <asp:Label ID="lbl_search" runat="server" Text="เลขที่ใบอนุญาต " CssClass="btn-lg"></asp:Label>
                                      </td>
                                      <td style="width:35%;">
                                          <asp:DropDownList ID="ddl_search" runat="server" CssClass="btn-lg" Width="80%"></asp:DropDownList>
                                      </td>
                                       <td  style="width:25%;">
                                           <asp:Button ID="btn_search" runat="server" Text="ค้นหา" CssClass="btn-lg" />
                                      </td>
                                       
                                  </tr>
                              </table>
                                   
                               <p style="text-align:right;padding-right:5%;">

        &nbsp;&nbsp;
                                  

                                     <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"   />
                                     <asp:Button ID="Button1" runat="server" Text="" style="display:none;"  />
        </p>
                          </div>
             </div>
           <div class="panel panel-body"  style="width:100%;padding-left:5%;">
               
           <asp:GridView  ID="GV_lcnno"  runat="server" Width="100%"  DataKeyNames="IDA" CellPadding="4" CssClass="table" 
      ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" Font-Size="10pt">
    <AlternatingRowStyle BackColor="White"  />
    <Columns>
        <asp:BoundField DataField="LCNNO_DISPLAY" HeaderText="เลขที่ใบอนุญาต" ItemStyle-Width ="10%" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="thanameplace" HeaderText="ชื่อสถานที่" ItemStyle-Width ="30%" ItemStyle-HorizontalAlign="Left" />        
        <asp:BoundField DataField="fulladdr" HeaderText="ที่อยู่" ItemStyle-Width ="60%" /> 

        <%--<asp:BoundField DataField="lcnsid" HeaderText="รหัสผู้ประกอบการ" ItemStyle-Width ="10%" Visible="false"  />
        <asp:BoundField DataField="HOUSENO" HeaderText="เลขสถานที่" ItemStyle-Width ="10%" ItemStyle-HorizontalAlign="Left" />
        <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width ="10%" /> 
        <asp:BoundField DataField="TRANSECTION_ID_UPLOAD" HeaderText="เลขดำเนินการ" ItemStyle-Width ="10%" /> 
        <asp:BoundField DataField="REMARK" HeaderText="เหตุผลการคืนคำขอ" ItemStyle-Width ="10%" /> --%>
        <%--<asp:BoundField DataField="pay_stat" HeaderText="การชำระเงิน" ItemStyle-Width ="10%" />--%>
        <%--<asp:CheckBoxField DataField="pay_stat_chk" HeaderText="การชำระเงิน" ItemStyle-Width ="10%" ItemStyle-HorizontalAlign="Center"/>--%>
  
        
            
        <asp:TemplateField ItemStyle-Width="10%">

        <ItemTemplate>
                          
                   <asp:Button ID="btn_sel" runat="server" Text="เลือกข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link"  CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />  &nbsp; &nbsp; &nbsp;
                        
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
                      <div class="h5" style="padding-left:87%;">  
                      <asp:HyperLink ID="hl_pay" runat="server"  target="_blank" style="display:none;"> ชำระเงินคลิกที่นี้</asp:HyperLink>
                        </div>
                               
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

    </asp:Content>