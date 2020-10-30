<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_PRODUCT_ID.Master" CodeBehind="FEM_REGISTRATION_MAIN.aspx.vb" Inherits="FDA_DRUG.FEM_REGISTRATION_MAIN"%>

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
                   var tt = getQuerystring("tt");
                   var e = document.getElementById("ContentPlaceHolder1_ddl_tamrab");
                   var ddl_val = e.options[e.selectedIndex].value;
                   //  $('#spinner').toggle('slow');
                  // Popups('POPUP_REGISTRATION_UPLOAD.aspx?IDA=' + IDA + '&FK_IDA=' + FK_IDA + '&process=' + process);
                   Popups('POPUP_REGISTRATION_UPLOAD.aspx?lcn_ida=' + lcn_ida + "&lct_ida=" + lct_ida + "&process=" + process + "&tt=" + tt + '&val=' + ddl_val);

                   return false;
               });

               $('#ContentPlaceHolder1_btn_insert').click(function () {
                   var lcn_ida = getQuerystring("lcn_ida");
                   var lct_ida = getQuerystring("lct_ida");
                   var process = getQuerystring("r_process");
                   var tt = getQuerystring("tt");
                   var e = document.getElementById("ContentPlaceHolder1_ddl_tamrab");
                   var ddl_val = e.options[e.selectedIndex].value;
                   //  $('#spinner').toggle('slow');
                   // Popups('POPUP_REGISTRATION_UPLOAD.aspx?IDA=' + IDA + '&FK_IDA=' + FK_IDA + '&process=' + process);
                   Popups('POPUP_REGISTRATION_INSERT.aspx?lcn_ida=' + lcn_ida + "&lct_ida=" + lct_ida + "&process=" + process + "&tt=" + tt + '&val=' + ddl_val);

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
          <h2>&nbsp;<asp:Label ID="lbl_Header_txt" runat="server" Text="สร้างตำรับ"></asp:Label></h2>
        </div>
        <uc1:UC_Information runat="server" ID="UC_Information" />
    </div>
    
    <div class="panel-info" style="text-align: right; width: 100%">
        <div style="text-align: right; padding-left: 5%; height: 60px;">
           <%-- เลขบัญชีรายการยา--%>
            <asp:DropDownList ID="ddl_product_id" runat="server" style="display:none;">
            </asp:DropDownList>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="lbl_sel_tamrab" runat="server" Text="กรุณาเลือกชื่อตำรับ"></asp:Label>
                        
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_tamrab" runat="server"></asp:DropDownList>
                    </td>
                </tr>
            </table>

            

            &nbsp;&nbsp;
            <asp:Button ID="btn_insert" runat="server" Text="สร้างชื่อตำรับ" Width="170px" CssClass="btn-lg " />
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
                       <telerik:GridBoundColumn DataField="H_IDA" DataType="System.Int32" FilterControlAltText="Filter H_IDA column" HeaderText="H_IDA"
                           SortExpression="H_IDA" UniqueName="H_IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="RCVNO_DISPLAY" FilterControlAltText="Filter RCVNO_DISPLAY column"
                           HeaderText="เลขที่ตำรับ" SortExpression="RCVNO_DISPLAY" UniqueName="RCVNO_DISPLAY">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="rcvdate" DataFormatString="{0:d}" FilterControlAltText="Filter rcvdate column"
                           HeaderText="วันที่สร้างตำรับ" SortExpression="rcvdate" UniqueName="rcvdate">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="DRUG_NAME_THAI" FilterControlAltText="Filter DRUG_NAME_THAI column"
                           HeaderText="ชื่อตำรับ (ภาษาไทย)" SortExpression="DRUG_NAME_THAI" UniqueName="DRUG_NAME_THAI">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="DRUG_NAME_OTHER" FilterControlAltText="Filter DRUG_NAME_OTHER column"
                           HeaderText="ชื่อตำรับ (ภาษาอังกฤษ)" SortExpression="DRUG_NAME_OTHER" UniqueName="DRUG_NAME_OTHER">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                           HeaderText="เลขดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID">
                       </telerik:GridBoundColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_add2" HeaderText="เพิ่มข้อมูลส่วนที่ 2"  
                            CommandName="_add2" Text="เพิ่มข้อมูลส่วนที่ 2">
                            <HeaderStyle Width="70px" />
                        </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_sel" HeaderText="ดูข้อมูล/ยื่นคำขอ" 
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

       <%--<asp:GridView ID="GV_data" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
           <AlternatingRowStyle BackColor="White" />
           <Columns>
               <asp:BoundField DataField="IDA" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
                   <ItemStyle Width="0%"></ItemStyle>
               </asp:BoundField>
               <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="0%" Visible="false">
                   <ItemStyle Width="0%"></ItemStyle>
               </asp:BoundField>

               <asp:BoundField DataField="RCVNO_DISPLAY" HeaderText="เลขที่คำขอ" ItemStyle-Width="10%">
                   <ItemStyle Width="10%"></ItemStyle>
               </asp:BoundField>

               <asp:BoundField DataField="rcvdate" DataFormatString="{0:d}" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
               <asp:BoundField DataField="DRUG_NAME_THAI" HeaderText="ชื่อยา" ItemStyle-Width="20%"></asp:BoundField>
               <asp:BoundField DataField="DRUG_NAME_OTHER" HeaderText="ชื่อยาอื่น ๆ" ItemStyle-Width="20%"></asp:BoundField>
               <asp:BoundField DataField="stat" HeaderText="สถานะ" ItemStyle-Width="20%"></asp:BoundField>
               <asp:BoundField DataField="trans_code" HeaderText="รหัสการดำเนินการ"></asp:BoundField>
               <asp:TemplateField ItemStyle-Width="20%">
                   <ItemTemplate>
                       <asp:Button ID="btn_edit" runat="server" Text="เพิ่มข้อมูลส่วนที่ 2" CommandName="add2" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                   </ItemTemplate>
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:TemplateField>
               <asp:TemplateField ItemStyle-Width="20%">
                   <ItemTemplate>
                       <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                   </ItemTemplate>
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:TemplateField>
               <asp:TemplateField ItemStyle-Width="10%">
                   <ItemTemplate>
                       <asp:Button ID="btn_Choose" runat="server" Text="เลือกข้อมูล" CommandName="choose" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                   </ItemTemplate>
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
       </asp:GridView>--%>


              <br />

              <div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  /> 
              </div>  
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>
                       <asp:Label ID="lbl_head1" runat="server" Text="-"></asp:Label></h1></div>
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
