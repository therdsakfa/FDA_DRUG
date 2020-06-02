<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_PRODUCT_PHESAJ.Master" CodeBehind="FRM_DH_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_DH_MAIN" %>


<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
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
                   var IDA = getQuerystring("lcn_ida");
                   //var FK_IDA = getQuerystring("FK_IDA");
                   var process = getQuerystring("process");
                   //  $('#spinner').toggle('slow');
                   //Popups('POPUP_DH_UPLOAD.aspx?IDA=' + IDA + '&FK_IDA=' + FK_IDA + '&process=' + process);
                   Popups('POPUP_DH_UPLOAD.aspx?fk_ida=' + IDA + '&process=' + process);
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
           function close_modal() { // คำสั่งสั่งปิด PopUp
               $('#myModal').modal('hide');
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
         <h2>เภสัชเคมีภัณฑ์ >    <asp:Label ID="lbl_Header_txt" runat="server" Text=""></asp:Label></h2>
            <br />

            License number : 
            <asp:Label ID="lbl_lcnno" runat="server" Text=""></asp:Label>
        </div>


        <table style="width: 100%;display:none;" class=" table">
            <tr>
                <td>สถานะ  
                </td>
                <td>
                    <asp:DropDownList ID="ddl_status" runat="server" class="form-control" DataSourceID="SqlDataSource1" DataTextField="STATUS_NAME" DataValueField="STATUS_ID"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LGT_DRUGConnectionString %>" SelectCommand="SELECT [STATUS_ID], [STATUS_NAME] FROM [MAS_STATUS] WHERE ([STATUS_GROUP] = @STATUS_GROUP) ORDER BY [STATUS_ID]">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="STATUS_GROUP" Type="Int32" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>
                <td>
                    <%--<asp:DropDownList ID="ddl_name" runat="server" CssClass="dropdown-tasks" AutoPostBack="True"></asp:DropDownList>--%>
            ชื่อผลิตภัณฑ์ 
                </td>
                <td>
                    <asp:TextBox ID="txt_name" class="form-control" runat="server"></asp:TextBox>
                </td>

                <td>
                    <%--<asp:DropDownList ID="ddl_number" runat="server" CssClass="dropdown-tasks" AutoPostBack="True"></asp:DropDownList>--%>
                 เลขจดแจ้ง  
                </td>
                <td>
                    <asp:TextBox ID="txt_number" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_filter" runat="server" Text="ค้นหา" Width="100px" CssClass="btn-lg" />
                </td>
            </tr>
        </table>
    </div>
    
    <div class="panel-info" style="text-align: right; width: 100%">
        <div style="text-align: right; padding-left: 5%; height: 60px;">
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
  
       1.สามารถพิมพ์ใบสั่งชำระเงินจากระบบไปชำระได้ที่ ธนาคารไทยพาณิชย์ ทุกสาขา ตู้ATMของธนาคาร หรือชำระผ่าน SCBeasy หรือMobile appication ของธนาคาร<br />
2.เพื่อป้องกันไม่ให้เกิดปัญหาการชำระเงิน แนะนำ ใช้เครื่องพิมพ์ ชนิดเลเซอร์ในการพิมพ์ใบสั่งชำระ<br />
3.ไม่สามารถออกใบสั่งชำระที่ออกจากระบบอื่นที่ไม่ได้ออกมาจากระบบเภสัชเคมีภัณฑ์นี้ได้<br />
       *หากพบปัญหาในการใช้งาน ขอความกรุณาแจ้งมาที่ drug-smarthelp@fda.moph.go.th ด้วยครับ
       <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
           <MasterTableView AutoGenerateColumns="False">
               <Columns>
                   <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="RCVNO_DISPLAY" FilterControlAltText="Filter RCVNO_DISPLAY column"
                           HeaderText="เลขที่รับคำขอ" SortExpression="RCVNO_DISPLAY" UniqueName="RCVNO_DISPLAY">
                       </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter REQUEST_DATE column" DataFormatString="{0:d}"
                           HeaderText="วันที่ยื่นคำขอ" SortExpression="REQUEST_DATE" UniqueName="REQUEST_DATE">
                       </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="STATUS_NAME" FilterControlAltText="Filter STATUS_NAME column"
                           HeaderText="สถานะ" SortExpression="STATUS_NAME" UniqueName="STATUS_NAME">
                       </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="phm15dgt" FilterControlAltText="Filter phm15dgt column"
                           HeaderText="รหัส 15 หลัก" SortExpression="phm15dgt" UniqueName="phm15dgt">
                       </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="CAS_NAME" FilterControlAltText="Filter CAS_NAME column"
                           HeaderText="ชื่อสาร" SortExpression="CAS_NAME" UniqueName="CAS_NAME">
                       </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="TR_ID" FilterControlAltText="Filter TR_ID column"
                           HeaderText="รหัสการดำเนินการ" SortExpression="TR_ID" UniqueName="TR_ID">
                       </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="REMARK" FilterControlAltText="Filter REMARK column"
                           HeaderText="เหตุผลการคืนคำขอ" SortExpression="REMARK" UniqueName="REMARK">
                       </telerik:GridBoundColumn>

                   <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                           CommandName="sel" Text="ดูข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                   <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_cancel"
                           CommandName="cancel" Text="ขอยกเลิก" ConfirmText="คุณต้องการยกเลิกข้อมูลหรือไม่">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_print"
                           CommandName="_print" Text="พิมพ์เลข 15 หลัก">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_pay" 
                           CommandName="_pay" Text="ออกใบสั่งชำระ">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
               </Columns>
           </MasterTableView>
       </telerik:RadGrid>
&nbsp;<asp:GridView ID="GV_data" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333" style="display:none;"
           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="15" Font-Size="10pt">
           <AlternatingRowStyle BackColor="White" />
           <Columns>

               <asp:BoundField DataField="IDA" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
                   <ItemStyle Width="0%"></ItemStyle>
               </asp:BoundField>
       
               <asp:BoundField DataField="RCVNO_DISPLAY" HeaderText="เลขที่รับคำขอ" ItemStyle-Width="10%">
                   <ItemStyle Width="10%"></ItemStyle>
               </asp:BoundField>
                  
               <asp:BoundField DataField="REQUEST_DATE" DataFormatString="{0:d}" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
        
                 <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
          <asp:BoundField DataField="phm15dgt" HeaderText="รหัส 15 หลัก" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
               <asp:BoundField DataField="CAS_NAME" HeaderText="ชื่อสาร" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
               
             <asp:BoundField DataField="TR_ID" HeaderText="รหัสการดำเนินการ" ItemStyle-Width="20%">
                   <ItemStyle Width="20%"></ItemStyle>
               </asp:BoundField>
               <asp:BoundField DataField="REMARK" HeaderText="เหตุผลการคืนคำขอ" ItemStyle-Width ="20%" /> 
               <asp:TemplateField ItemStyle-Width="20%">
                   <ItemTemplate>

                       <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                       <asp:Button ID="btn_Preview" runat="server" Text="ดูข้อมูล" CommandName="preview" Width="0%" CssClass="btn-link" Visible="false" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                       <asp:Button ID="btn_cancel" runat="server" Text="ขอยกเลิก" OnClientClick="return confirm('คุณต้องการยกเลิกข้อมูลหรือไม่');" CommandName="cancel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                   
                   </ItemTemplate>

                   <ItemStyle Width="20%"></ItemStyle>
               </asp:TemplateField>
               <asp:TemplateField ItemStyle-Width="20%">
                   <ItemTemplate>
                        <asp:Button ID="btn_print" runat="server" Text="พิมพ์เลข 15 หลัก" CommandName="_print" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                    </ItemTemplate>
                   </asp:TemplateField>
               <asp:TemplateField ItemStyle-Width="20%">
                   <ItemTemplate>
                       <asp:LinkButton ID="btn_pay" runat="server" CommandName="_pay" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' Text="ออกใบสั่งชำระ"></asp:LinkButton>

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
       </asp:GridView>

              <br />
       <div class="h5" style="padding-left:87%;">  
                      <asp:HyperLink ID="hl_pay" runat="server"  target="_blank"> ชำระเงิน/รายการใบสั่งชำระ</asp:HyperLink>
                        </div>
              <div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  /> 
              </div>  
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>รายละเอียด เภสัชเคมีภัณฑ์ </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>

       </font>

</asp:Content>
