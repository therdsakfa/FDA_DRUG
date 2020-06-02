<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="UC_DS_GRID_TABLE.ascx.vb" Inherits="FDA_DRUG.UC_DS_GRID_TABLE" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<link href="../css/css_radgrid.css" rel="stylesheet" />

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

                      $('#spinner').toggle('slow');
                      Popups('../POPUP_DS_UPLOAD_NORYORMOR.aspx');
                      return false;
                  });

                  $('#ContentPlaceHolder1_btn_download').click(function () {
                      $('#spinner').fadeIn('slow');
                      Popups('POPUP_LCN_DOWNLOAD.aspx');
                      return false;
                  });

                  $('#ContentPlaceHolder1_UC_DS_GRID_TABLE1_Button3').click(function () {
                      //var lct_ida = getQuerystring("lct_ida");
                      //var lcn_ida = getQuerystring("lcn_ida");
                      var process = getQuerystring("process");
                      //  $('#spinner').toggle('slow');
                      //Popups('POPUP_RESEARCH_SUM_DL.aspx?lct_ida=' + lct_ida + '&lcn_ida=' + lcn_ida + '&process=' + process);
                      Popups2('POPUP_RESEARCH_SUM_UL.aspx?process=' + process);
                      return false;
                  });

                  $('#ContentPlaceHolder1_UC_DS_GRID_TABLE1_Button2').click(function () {
                      //$('#spinner').fadeIn('slow');
                      Popups2('POPUP_RESEARCH_SUM_DL.aspx');
                      return false;
                  });

                  function popups(url) { // สำหรับทำ Div Popup
                      $('#myModal').modal('togPopupsgle'); // เป็นคำสั่งเปิดปิด
                      var i = $('#f1'); // ID ของ iframe   
                      i.attr("src", url); //  url ของ form ที่จะเปิด
                  }
                  
                  function close_modal() { // คำสั่งสั่งปิด PopUp
                      $('#myModal').modal('hide');
                      $('#ContentPlaceHolder1_UC_DS_GRID_TABLE1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
                  }
              });

              function spin_space() { // คำสั่งสั่งปิด PopUp
                  //    alert('123456');
                  $('#spinner').toggle('slow');
                  //$('#myModal').modal('hide');
                  //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

                    }
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
        </script> 

    <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>คำขออนุญาตนำหรือสั่งยาเข้ามาในราชอาณาจักรเพื่อการวิจัย (นยม1)</h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>

     <script type="text/javascript" >
         function closespinner() {
             $('#spinner').fadeOut('slow');
             alert('Download Success');
             $('#ContentPlaceHolder1_UC_DS_GRID_TABLE1_Button1').click();

              }
         function download() {
             Popups_dl('../DRUG_IMPORT/POPUP_NYM1_DOWNLOAD.aspx');
         }
         function Popups_dl(url) { // สำหรับทำ Div Popup
             $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
             var i = $('#f1'); // ID ของ iframe   
             i.attr("src", url); //  url ของ form ที่จะเปิด
         }
         function Popups2(url) { // สำหรับทำ Div Popup
             $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
             var i = $('#f1'); // ID ของ iframe   
             i.attr("src", url); //  url ของ form ที่จะเปิด
         }

         $(function () {
             $("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_Button6").toggle(
                 function () {
                     $("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_hide").hide();
                     $("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_Button6").val("เปิดเมนูสรุปย่อโครงการวิจัย");
                     $("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_hide2").show();
                     //$("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_Button7").val("ซ่อนนยม1");
                 },
                 function () {
                     $("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_hide").show();
                     $("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_Button6").val("เปิดเมนูนยม1");
                     $("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_hide2").hide();
                     //$("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_Button7").val("เปิดนยม1");
                     //$("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_hide").ad
                 });
         });

         //$(function () {
         //    $("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_Button7").toggle(
         //        function () {
         //            $("#hide2").hide();
         //            $("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_Button7").val("เปิดนยม1");
         //            //$("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_hide").show();
         //            //$("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_Button6").val("ซ่อนสรุปย่อโครงการวิจัย");
         //        },
         //        function () {
         //            $("#hide2").show();
         //            $("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_Button7").val("ซ่อนนยม1");
         //            $("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_hide").hide();
         //            $("#ContentPlaceHolder1_UC_DS_GRID_TABLE1_Button6").val("เปิดสรุปย่อโครงการวิจัย");
         //        });
         //});

         </script>

<div id="hidetop" runat="server">
<h4>คำขออนุญาตนำหรือสั่งยาเข้ามาในราชอาณาจักรเพื่อการวิจัย (นยม1)</h4>
<asp:Button ID="Button6" class="btn-lg" style="display:block;" runat="server" Text="เปิดเมนูนยม1" Visible="False"/>
</div>
<%--<asp:Button ID="Button7" runat="server" CssClass="btn-lg" style="display:block;" Text="เปิดนยม1" />--%>
<div id="hide" runat="server">

    <div class="col-lg-6 col-md-6">
    </div>

    
<div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:100px" > 
            
             <div  class="col-lg-6 col-md-6"><h4> <asp:Label ID="Label1" runat="server"  Text="รายละเอียดโครงการวิจัย"></asp:Label> </h4>
             </div>
                          <div  class="col-lg-6 col-md-6">
                               <p style="text-align:right;padding-right:5%;">

            <asp:Button ID="Button2" runat="server" Text="เพิ่มโครงการ" CssClass="btn-lg"   />
        &nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" Text="อัพโหลดโครงการ" CssClass="btn-lg"   />
                                     <asp:Button ID="Button4" runat="server" Text="" style="display:none;"  />
                                     <asp:Button ID="Button5" runat="server" Text="" style="display:none;"  />
        </p>
                          </div>

         </div>
    
</div>

       <div class="panel panel-body"  style="padding-left:5%;">
           <center>เลขดำเนินการ :
           <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; รหัสโครงการ&nbsp; :&nbsp;
           <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp;
           <asp:Button ID="Button7" runat="server" Text="ค้นหา" /></center>
           <br />
         <telerik:RadGrid ID="PJSUM" runat="server" AllowPaging="true" PageSize="15">
           <MasterTableView AutoGenerateColumns="False">
               <Columns>
                   <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                       SortExpression="IDA" UniqueName="IDA" Display="false">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="CREATE_DATE" FilterControlAltText="Filter CREATE_DATE column" DataFormatString="{0:dd/MM/yyyy}"
                       HeaderText="วันเวลาที่อัพโหลด" HeaderStyle-width="100px" SortExpression="CREATE_DATE" UniqueName="CREATE_DATE">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn HeaderText="เลขดำเนินการ" DataField="TR_ID" DataType="System.Int32" FilterControlAltText="Filter TR_ID column"
                           SortExpression="TR_ID" UniqueName="TR_ID">
                   </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="TFDA_CT_no" FilterControlAltText="Filter TFDA_CT_no column"
                           HeaderText="TFDA_CT_no" SortExpression="TFDA_CT_no" UniqueName="TFDA_CT_no">
                       </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="pj_code" FilterControlAltText="Filter pj_code column"
                           HeaderText="รหัสโครงการ" SortExpression="pj_code" UniqueName="pj_code">
                       </telerik:GridBoundColumn>
                   <%--<telerik:GridCalculatedColumn HeaderText="ชื่อโครงการวิจัย" UniqueName="pjnm" DataFields="pj_enname, pj_thname"
                        Expression='{0} + " / " + {1}'>
                    </telerik:GridCalculatedColumn>--%>
                   <telerik:GridBoundColumn DataField="STATUS" FilterControlAltText="Filter STATUS column"
                       HeaderText="สถาณะ" SortExpression="STATUS" UniqueName="STATUS">
                   </telerik:GridBoundColumn>
                   <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                       CommandName="sel" Text="ดูข้อมูล">
                       <HeaderStyle Width="50px" />
                   </telerik:GridButtonColumn>
                   <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                       CommandName="chnge" Text="เปลี่ยนผู้ยื่น">
                       <HeaderStyle Width="70px" />
                   </telerik:GridButtonColumn>
                                      <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                       CommandName="add" Text="เพิ่มคำขอ">
                       <HeaderStyle Width="70px" />
                   </telerik:GridButtonColumn>
               </Columns>
           </MasterTableView>
       </telerik:RadGrid>
    </div>
    </div>
<div id="hide2" runat="server">
<div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:100px" > 
            
             <div  class="col-lg-6 col-md-6"><h4> <asp:Label ID="lbl_name_2" runat="server"  Text=""></asp:Label><asp:Label ID="lbl_name" runat="server"  Text=""></asp:Label> </h4>
             </div>
                          <div  class="col-lg-6 col-md-6">
                               <p style="text-align:right;padding-right:5%;">

                <asp:DropDownList ID="ddl_tabaen" runat="server" AutoPostBack="false" Height="40px" Width="174px">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;

            <asp:Button ID="btn_download" runat="server" Text="เพิ่มคำขอ" CssClass="btn-lg"   />
        &nbsp;&nbsp;
            <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดคำขอ" CssClass="btn-lg"   />
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
                       
                       <asp:Button ID="bt_proof"  CssClass="btn-link" runat="server" />
                       
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

                   <asp:BoundField DataField="UPLOAD_DATE" HeaderText="วันเวลาที่ส่งคำขอ" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                       <ItemStyle HorizontalAlign="center" Width="15%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="LCNNO_DISPLAY" HeaderText="รหัสบัญชีรายการยา" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                       <ItemStyle HorizontalAlign="center" Width="20%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="drug_name" HeaderText="ชื่อยา (Th/Eng)" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                       <ItemStyle HorizontalAlign="center" Width="15%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="ID" HeaderText="รหัสดำเนินการ" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">

                       <ItemStyle HorizontalAlign="center" Width="15%"></ItemStyle>
                   </asp:BoundField>
                   <asp:TemplateField ItemStyle-Width="15%" ItemStyle-HorizontalAlign="center">
                       <ItemTemplate>

                           <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                           &nbsp; &nbsp; &nbsp;
                        
                       </ItemTemplate>

                       <ItemStyle Width="15%" HorizontalAlign="center"></ItemStyle>
                   </asp:TemplateField>
                   <asp:BoundField DataField="STATUS_NAME" HeaderText="สถาณะ" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="center">

                       <ItemStyle HorizontalAlign="center" Width="15%"></ItemStyle>
                   </asp:BoundField>
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
           <asp:GridView ID="nym1" runat="server" Width="100%" DataKeyNames="IDA" CellPadding="4" CssClass="table"
               ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
               <AlternatingRowStyle BackColor="White" />
               <Columns>
                   <asp:BoundField DataField="UPLOAD_DATE" HeaderText="วันเวลาที่ส่งคำขอ" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                       <ItemStyle HorizontalAlign="center" Width="15%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="pj_thname" HeaderText="ชื่อโครงการภาษาไทย" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="center">
                       <ItemStyle HorizontalAlign="center" Width="20%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="pj_enname" HeaderText="ชื่อโครงการภาษาอังกฤษ" ItemStyle-Width="20%" ItemStyle-HorizontalAlign="center">
                       <ItemStyle HorizontalAlign="center" Width="15%"></ItemStyle>
                   </asp:BoundField>
                   <asp:BoundField DataField="TR" HeaderText="รหัสดำเนินการ" ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">

                       <ItemStyle HorizontalAlign="center" Width="15%"></ItemStyle>
                   </asp:BoundField>
                   <asp:TemplateField ItemStyle-Width="10%" ItemStyle-HorizontalAlign="center">
                       <ItemTemplate>

                           <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                           &nbsp; &nbsp; &nbsp;
                        
                       </ItemTemplate>

                       <ItemStyle Width="15%" HorizontalAlign="center"></ItemStyle>
                   </asp:TemplateField>
                   <asp:BoundField DataField="STATUS_NAME" HeaderText="สถาณะ"  ItemStyle-Width="15%" ItemStyle-HorizontalAlign="center">

                       <ItemStyle HorizontalAlign="center" Width="15%"></ItemStyle>
                   </asp:BoundField>
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
    </div>
                      