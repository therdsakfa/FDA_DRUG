﻿<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Auto_Menu.Master" CodeBehind="FRM_LCN_DRUG.aspx.vb" Inherits="FDA_DRUG.FRM_LCN_DRUG" %>

<%@ Register src="../UC/UC_INFMT.ascx" tagname="UC_INFMT" tagprefix="uc4" %>

<%@ Register Src="~/UC/UC_INFMT.ascx" TagPrefix="uc1" TagName="UC_INFMT" %>




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
    
 <%--  <div style="text-align:center;" >  เลขที่ใบอนุญาตสถานที่&nbsp;&nbsp;&nbsp;&nbsp;  <asp:DropDownList ID="ddl_lcnno" runat="server" CssClass="input-lg"  Width="20%"></asp:DropDownList> &nbsp;
       <asp:Button ID="Btn_ok" runat="server" Text="ยืนยัน" CssClass="btn-info" Width="67px"/>
       <br />
    </div>--%>
      <div id="spinner" style=" background-color:transparent; display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>

    <uc1:UC_INFMT runat="server" ID="UC_INFMT" />
    <div class="h3" style="padding-left:5%;">  </div>
    
     <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4> ใบอนุญาต<asp:Label ID="lbl_name_2" runat="server"  Text=""></asp:Label><asp:Label ID="lbl_name" runat="server"  Text=""></asp:Label> </h4> </div>
                          <div  class="col-lg-8 col-md-8">
                               <p style="text-align:right;padding-right:5%;">
                                   <table width="100%">
                                       <tr>
                                           <td>เลขบัตรผู้ดำเนินฯ</td>
                                           <td><asp:TextBox ID="txt_bsn" runat="server"></asp:TextBox>
                                           </td>
                                           <td align="right">
                                               <asp:Button ID="btn_download" runat="server" Text="ดาวน์โหลดคำขอ" CssClass="btn-lg" />&nbsp;&nbsp;
                                           </td>
                                           <td>
                                               <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดคำขอ" CssClass="btn-lg" />
                                           </td>
                                       </tr>
                                       <tr>
                                           <td>
                                               <asp:Label ID="lbl_head_org" runat="server" Text="กรุณาเลือกประเภทหน่วยงาน" style="display:none;"></asp:Label>
                                           </td>
                                           <td colspan="3">
                                               <asp:RadioButtonList ID="rdl_org" runat="server" RepeatDirection="Horizontal" RepeatColumns="6" style="display:none;">
                                               </asp:RadioButtonList>
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
                       <asp:Label ID="lbl_remark" runat="server" Text="*หมายเหตุ เมื่ออัพโหลดคำขออนุญาตผลิตยาแผนปัจจุบันแล้ว ให้ทำการเพิ่มหมวดยาจึงจะสามารถส่งคำขอได้" style="display:none;"></asp:Label>
                   </td>
               </tr>
           </table>
           <asp:GridView ID="GV_lcnno" runat="server" Width="100%" DataKeyNames="IDA" CellPadding="4" CssClass="table"
               ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
               <AlternatingRowStyle BackColor="White" />
               <Columns>
                   <%--<asp:BoundField DataField="pay_stat" HeaderText="การชำระเงิน" ItemStyle-Width ="10%" />--%>
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

                   <asp:BoundField DataField="LCNNO_MANUAL" HeaderText="เลขที่ใบอนุญาต" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                       <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width="10%">
                       <ItemStyle Width="10%" />
                   </asp:BoundField>
                   <asp:BoundField DataField="thanameplace" HeaderText="ชื่อสถานที่" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                       <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="fulladdr" HeaderText="ที่อยู่" ItemStyle-Width="30%">

                       <ItemStyle Width="30%"></ItemStyle>
                   </asp:BoundField>

                   <asp:BoundField DataField="lcnsid" HeaderText="รหัสผู้ประกอบการ" ItemStyle-Width="10%" Visible="false">
                       <ItemStyle Width="10%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="HOUSENO" HeaderText="เลขสถานที่" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Left">
                       <ItemStyle HorizontalAlign="Left" Width="10%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="TRANSECTION_ID_UPLOAD" HeaderText="เลขดำเนินการ" ItemStyle-Width="10%">
                       <ItemStyle Width="10%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="REMARK" HeaderText="เหตุผลการคืนคำขอ" ItemStyle-Width="10%">
                       <ItemStyle Width="10%"></ItemStyle>
                   </asp:BoundField>
                  <%-- <asp:CheckBoxField DataField="pay_stat_chk" HeaderText="การชำระเงิน" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="Center">
                       <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                   </asp:CheckBoxField>--%>

                   <asp:TemplateField ItemStyle-Width="10%">
                       <ItemTemplate>

                           <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                           &nbsp; &nbsp; &nbsp;
                        
                       </ItemTemplate>

                       <ItemStyle Width="10%"></ItemStyle>
                   </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="10%">
                       <ItemTemplate>

                           <asp:Button ID="btn_sell" runat="server" Text="ประเภทขายส่ง" CommandName="sell" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                           &nbsp; &nbsp; &nbsp;
                        
                       </ItemTemplate>

                       <ItemStyle Width="10%"></ItemStyle>
                   </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="10%">
                       <ItemTemplate>

                           <asp:Button ID="btn_drug_group" runat="server" Text="รายละเอียดหมวดยา" CommandName="drug_group" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                           &nbsp; &nbsp; &nbsp;
                        
                       </ItemTemplate>

                       <ItemStyle Width="10%"></ItemStyle>
                   </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="10%">
                       <ItemTemplate>

                           <%--<asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="0%" Visible CssClass="btn-link"  CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />  &nbsp; &nbsp; &nbsp;--%>
                           <asp:Button ID="btn_lcn" runat="server" Text="เลือกข้อมูล" CommandName="lcn" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />

                       </ItemTemplate>

                       <ItemStyle Width="10%"></ItemStyle>

                   </asp:TemplateField>
                   <asp:TemplateField ItemStyle-Width="10%">

                       <ItemTemplate>
                           <asp:Button ID="btn_leaves" runat="server" Text="ใบย่อย" CommandName="leaves" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                           &nbsp; &nbsp; &nbsp;
                       </ItemTemplate>
                       <ItemStyle Width="10%"></ItemStyle>
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
           </asp:GridView>
                      <div class="h5" style="padding-left:87%;">  
                      <asp:HyperLink ID="hl_pay" runat="server"  target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
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
