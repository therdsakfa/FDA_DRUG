<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_DS_STAFF_SEARCH.aspx.vb" Inherits="FDA_DRUG.FRM_DS_STAFF_SEARCH" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/style.css" rel="stylesheet" />
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
                   //  var IDA = getQuerystring("IDA");
                   //var FK_IDA = getQuerystring("FK_IDA");
                   // var process = getQuerystring("process");
                   //  $('#spinner').toggle('slow');
                   //Popups('POPUP_DH_UPLOAD.aspx?IDA=' + IDA + '&FK_IDA=' + FK_IDA + '&process=' + process);
                   Popups('POPUP_DH_UPLOAD.aspx');
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
            <h2>ค้นหายาตัวอย่าง</h2>

        </div>


        <table style="width: 100%;" class=" table">
            <tr>
                <td>สถานะ  
                </td>
                <td>
                    <asp:DropDownList ID="ddl_status" runat="server" class="form-control" DataSourceID="SqlDataSource1" DataTextField="STATUS_NAME" DataValueField="STATUS_ID"></asp:DropDownList>
                            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:LGT_DRUGConnectionString %>" SelectCommand="SELECT [STATUS_ID], [STATUS_NAME] FROM [MAS_STATUS] WHERE (([STATUS_GROUP] = @STATUS_GROUP) AND ([STATUS_ID] &gt;= @STATUS_ID)) ORDER BY [STATUS_ID] DESC">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="1" Name="STATUS_GROUP" Type="Int32" />
                            <asp:Parameter DefaultValue="7" Name="STATUS_ID" Type="Double" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </td>

                <td>
                    <%--<asp:DropDownList ID="ddl_number" runat="server" CssClass="dropdown-tasks" AutoPostBack="True"></asp:DropDownList>--%>
                    เลขดำเนินการ  
                </td>
                <td style="width:25%;">
                    <asp:TextBox ID="txt_number" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_filter" runat="server" Text="ค้นหา" Width="100px" CssClass="btn-lg" />
                </td>
            </tr>
        </table>
    </div>
    
   <hr />
   <div>
       <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15">
           <MasterTableView>
               <Columns>
                   <telerik:GridBoundColumn DataField="IDA" Display="false" UniqueName="IDA" HeaderText="IDA" >
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="rcvno" UniqueName="rcvno" HeaderText="เลขที่คำขอ" >
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="rcvdate" DataType="System.DateTime" UniqueName="rcvdate" HeaderText="วันที่ยื่นคำขอ" DataFormatString="{0:d}">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="STATUS_NAME" UniqueName="STATUS_NAME" HeaderText="สถานะ" DataType="System.String" >
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn DataField="TR_ID" UniqueName="TR_ID" HeaderText="รหัสการดำเนินการ" DataType="System.String">
                   </telerik:GridBoundColumn>
                   <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_remark" CommandName="remark" Text="เหตุผลที่คืนคำขอ">

                   </telerik:GridButtonColumn>
                   <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select" CommandName="sel" Text="ดูข้อมูล">

                   </telerik:GridButtonColumn>
               </Columns>
           </MasterTableView>
       </telerik:RadGrid>
              <br />

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
       <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"  />
</asp:Content>
