<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_PRODUCT_ID.Master" CodeBehind="FRM_REGISTRATION_MAIN_V2.aspx.vb" Inherits="FDA_DRUG.FRM_REGISTRATION_MAIN_V2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<%@ Register Src="~/UC/UC_Information.ascx" TagPrefix="uc1" TagName="UC_Information" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                   var lcn_ida = getQuerystring("lcn_ida");
                   var lct_ida = getQuerystring("lct_ida");
                   var process = getQuerystring("r_process");
                   //  $('#spinner').toggle('slow');
                   // Popups('POPUP_REGISTRATION_UPLOAD.aspx?IDA=' + IDA + '&FK_IDA=' + FK_IDA + '&process=' + process);
                   Popups('POPUP_REGISTRATION_UPLOAD.aspx?lcn_ida=' + lcn_ida + "&lct_ida=" + lct_ida + "&process=" + process);

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

           function getQuerystring(key, default_) {
               if (default_ == null) default_ = "";
               key = key.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
               var regex = new RegExp("[\\?&]" + key + "=([^&#]*)");
               var qs = regex.exec(window.location.href);
               if (qs == null)
                   return default_;
               else
                   return qs[1];
           }
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
           function close_modal() { // คำสั่งสั่งปิด PopUp
               $('#myModal').modal('hide');
               $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
           }
           function close_modal2() { // คำสั่งสั่งปิด PopUp
               $('#myModal2').modal('hide');
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
          <h2>&nbsp;<asp:Label ID="lbl_Header_txt" runat="server" Text=""></asp:Label></h2>
        </div>
        <uc1:UC_Information runat="server" ID="UC_Information" />
    </div>
    
    <div class="panel-info" style="text-align: right; width: 100%">
        <div style="text-align: right; padding-left: 5%; height: 60px;">
           <%-- เลขบัญชีรายการยา--%>
            <asp:DropDownList ID="ddl_product_id" runat="server" style="display:none;">
            </asp:DropDownList>
            <asp:Button ID="btn_download" runat="server" Text="ดาวน์โหลดคำขอ" Width="170px" CssClass="btn-lg " />
            &nbsp;&nbsp;
       <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดคำขอ" Width="170px" CssClass="btn-lg " />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
            <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
        </div>
    </div>

   <hr />
   <div>

   <telerik:RadGrid ID="Rg_regist" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="RCVNO_DISPLAY" FilterControlAltText="Filter RCVNO_DISPLAY column"
                           HeaderText="เลขที่คำขอ" SortExpression="RCVNO_DISPLAY" UniqueName="RCVNO_DISPLAY">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="rcvdate" DataFormatString="{0:d}" FilterControlAltText="Filter rcvdate column"
                           HeaderText="วันที่ยื่นคำขอ" SortExpression="rcvdate" UniqueName="rcvdate">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="DRUG_NAME_THAI" FilterControlAltText="Filter DRUG_NAME_THAI column"
                           HeaderText="ชื่อยา" SortExpression="DRUG_NAME_THAI" UniqueName="DRUG_NAME_THAI">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="DRUG_NAME_OTHER" FilterControlAltText="Filter DRUG_NAME_OTHER column"
                           HeaderText="ชื่อยาอื่น ๆ" SortExpression="DRUG_NAME_OTHER" UniqueName="DRUG_NAME_OTHER">
                       </telerik:GridBoundColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_add2" HeaderText="เพิ่มข้อมูลส่วนที่ 2"  
                            CommandName="_add2" Text="เพิ่มข้อมูลส่วนที่ 2">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_sel" HeaderText="ดูข้อมูล" 
                            CommandName="_sel" Text="ดูข้อมูล">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="choose" HeaderText="เลือกข้อมูล"
                            CommandName="choose" Text="เลือกข้อมูล">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                   </Columns>
               </MasterTableView>
           </telerik:RadGrid>
              <br />
       <fieldset>
           <legend style="color: red;">คำขอขึ้นทะเบียนยา</legend>
           <table style="width: 100%;">
               <tr>
                   <td style="width: 55%;">
                       <table style="width: 100%;">
                           <tr>
                               <td><b>ชื่อภาษาไทย :</b></td>
                               <td>
                                   <asp:Label ID="lb_th_name" runat="server"></asp:Label>
                               </td>
                               <td><b>ชื่อภาษาอังกฤษ :</b></td>
                               <td>
                                   <asp:Label ID="lb_eng_name" runat="server"></asp:Label>
                               </td>
                           </tr>
                           <tr>
                               <td><b>สถานะ :</b></td>
                               <td colspan="4">
                                   <asp:Label ID="lb_stat" runat="server"></asp:Label>
                               </td>
                           </tr>
                       </table>



                   </td>
                   <td valign="center">
                       <div style="text-align: right; padding-left: 5%; height: 60px;">
                           <asp:Button ID="btn_download_t" runat="server" Text="ดาวน์โหลดคำขอ" Width="170px" CssClass="btn-lg " style="display:none;" />
                           &nbsp;&nbsp;
       <asp:Button ID="btn_upload_t" runat="server" Text="อัพโหลดคำขอ" Width="170px" CssClass="btn-lg " style="display:none;"/>
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="reload" Style="display: none" />
                           <asp:Button ID="Button3" runat="server" Text="Button" Style="display: none" />
                       </div>
                   </td>
               </tr>
           </table>
           <br />
           <table class="table" style="width: 100%;">
               <tr>
                   <td>
                       <h2>คำขอ</h2>
                       <asp:GridView ID="GV_Tabean" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
                           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" Font-Size="10pt">
                           <AlternatingRowStyle BackColor="White" />
                           <Columns>
                               <asp:BoundField DataField="IDA" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
                                   <ItemStyle Width="0%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="TR_ID" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
                                   <ItemStyle Width="0%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="rcvno" HeaderText="เลขที่คำขอ" ItemStyle-Width="10%">
                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:BoundField>

                               <asp:BoundField DataField="rcvdate" DataFormatString="{0:d}" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="thadrgnm" HeaderText="ชื่อภาษาไทย" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="engdrgnm" HeaderText="ชื่อภาษาอังกฤษ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <%--<asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_status" runat="server"></asp:Label>
                                   </ItemTemplate>

                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:TemplateField>--%>
                               <asp:BoundField DataField="trans_code" HeaderText="รหัสการดำเนินการ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:TemplateField ItemStyle-Width="20%">
                                   <ItemTemplate>

                                       <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                       <asp:Button ID="btn_Preview" runat="server" Text="ดูข้อมูล" CommandName="preview" Width="0%" CssClass="btn-link" Visible="false" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                       <asp:Button ID="btn_add" runat="server" Text="เพิ่มข้อมูลส่วนที่ 2" CommandName="_add" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                        <%--<asp:Button ID="btn_iden" runat="server" Text="เพิ่มเลข Identify" CommandName="_add_iden" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />--%>
                                   </ItemTemplate>

                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:TemplateField>
                           </Columns>
                           <EditRowStyle BackColor="#2461BF" />
                           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                           <HeaderStyle BackColor="#8CB343" Font-Bold="True" ForeColor="White" />
                           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                           <RowStyle BackColor="#EFF3FB" />
                           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                           <SortedAscendingCellStyle BackColor="#F5F7FB" />
                           <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                           <SortedDescendingCellStyle BackColor="#E9EBEF" />
                           <SortedDescendingHeaderStyle BackColor="#4870BE" />
                       </asp:GridView>
                       <table width="100%">
                           <tr>
                               <td align="right">
<asp:HyperLink ID="hl_pay" runat="server"  target="_blank"> ชำระเงินคลิกที่นี้</asp:HyperLink>
                               </td>
                           </tr>
                       </table>
                       
                       <br /><br />
                       <h2>ทะเบียนตำรับ</h2>
                       <asp:GridView ID="GV_Tabean2" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
                           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="10" Font-Size="10pt">
                           <AlternatingRowStyle BackColor="White" />
                           <Columns>
                               <asp:BoundField DataField="IDA" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
                                   <ItemStyle Width="0%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="TR_ID" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
                                   <ItemStyle Width="0%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="rcvno" HeaderText="เลขที่คำขอ" ItemStyle-Width="10%">
                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:BoundField>

                               <asp:BoundField DataField="rcvdate" DataFormatString="{0:d}" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="thadrgnm" HeaderText="ชื่อภาษาไทย" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="engdrgnm" HeaderText="ชื่อภาษาอังกฤษ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <%--<asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_status" runat="server"></asp:Label>
                                   </ItemTemplate>

                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:TemplateField>--%>
                               <asp:BoundField DataField="trans_code" HeaderText="รหัสการดำเนินการ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:TemplateField ItemStyle-Width="20%">
                                   <ItemTemplate>

                                       <asp:Button ID="btn_Select0" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                       <asp:Button ID="btn_Preview0" runat="server" Text="ดูข้อมูล" CommandName="preview" Width="0%" CssClass="btn-link" Visible="false" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                       <asp:Button ID="btn_add0" runat="server" Text="เพิ่มข้อมูลส่วนที่ 2" CommandName="_add" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                        <%--<asp:Button ID="btn_iden0" runat="server" Text="เพิ่มเลข Identify" CommandName="_add_iden" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />--%>
                                   </ItemTemplate>

                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:TemplateField>
                           </Columns>
                           <EditRowStyle BackColor="#2461BF" />
                           <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                           <HeaderStyle BackColor="#8CB343" Font-Bold="True" ForeColor="White" />
                           <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                           <RowStyle BackColor="#EFF3FB" />
                           <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                           <SortedAscendingCellStyle BackColor="#F5F7FB" />
                           <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                           <SortedDescendingCellStyle BackColor="#E9EBEF" />
                           <SortedDescendingHeaderStyle BackColor="#4870BE" />
                       </asp:GridView>

                   </td>
               </tr>


           </table>
       </fieldset>
              <div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  /> 
              </div>  
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>รายละเอียด รายการขึ้นทะเบียนเรื่องขออนุญาตผลิตภัณฑ์ยา </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
<div class=" modal fade" id="myModal2">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>เพิ่มข้อมูลส่วนที่ 2 </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="close_modal2();">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f2"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
