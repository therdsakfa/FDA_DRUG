<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_PRODUCT_ID.Master" CodeBehind="FRM_DS_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_DS_MAIN" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register Src="~/DS/UC/UC_DS_MAIN.ascx" TagPrefix="uc1" TagName="UC_DS_MAIN" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--   <script type="text/javascript" >
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
                //var lct_ida = getQuerystring("lct_ida");
                //var lcn_ida = getQuerystring("lcn_ida");
                var process = getQuerystring("process");
                //  $('#spinner').toggle('slow');
                //Popups('POPUP_DS_UPLOAD2.aspx?lct_ida=' + lct_ida + '&lcn_ida=' + lcn_ida + '&process=' + process);
                Popups('POPUP_DS_UPLOAD2.aspx?process=' + '&process=' + process);
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
     <script type="text/javascript" >
         function closespinner() {
             $('#spinner').fadeOut('slow');
             alert('Download Success');
             $('#ContentPlaceHolder1_Button1').click();

         }--%>
        <%-- </script>--%>
  <%--  
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <<%--div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h2> ลงทะเบียน GMP สถานที่ผลิต&nbsp;
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </h2>--%>
           
            
            <%--<uc1:uc_information runat="server" id="UC_Information" />--%>
            <%--<br />

            <br />

 <table>
       </table>

            <br />
        </div>
            <br />

            <br />

 <table>
       </table>

            <br />--%>
<%--    <div class="panel" style="text-align:left ;width:100%">
         <div class="panel-heading panel-title" style="height:100px" > 
             <div  class="col-lg-4 col-md-4"><h4 class="auto-style2"> ใบอนุญาต<asp:Label ID="lbl_name_2" runat="server"  Text=""></asp:Label><asp:Label ID="lbl_name" runat="server"  Text=""></asp:Label> </h4>
             </div>
                          <div  class="col-lg-8 col-md-8">
                               <p style="text-align:right;padding-right:5%;">
            <asp:Button ID="btn_download" runat="server" Text="เพิ่มคำขอ" CssClass="btn-lg"   />
        &nbsp;&nbsp;
            <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดคำขอ" CssClass="btn-lg"   />
                                     <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"  />
                                     <asp:Button ID="Button1" runat="server" Text="" style="display:none;"  />
        </p>
                               <p style="text-align:right;padding-right:5%;">
                                   &nbsp;</p>
                          </div>
         </div> 
    </div>

     <div class="panel panel-body"  style="width:100%;padding-left:5%;">
            <asp:GridView ID="GV_lcnno" runat="server" Width="100%" DataKeyNames="IDA" CellPadding="4" CssClass="table"
               ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt" style="margin-top: 12px">
               <AlternatingRowStyle BackColor="White" />
               <Columns>
                
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
                   <asp:BoundField DataField="STATUS_NAME" HeaderText="สถานะ" ItemStyle-Width="15%" ItemStyle-HorizontalAlign="center">

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
                      <asp:HyperLink ID="hl_pay" runat="server"  target="_blank" > ชำระเงินคลิกที่นี้</asp:HyperLink>
                        </div>
                               
    </div>--%>
    <uc1:UC_DS_MAIN runat="server" ID="UC_DS_MAIN" />

    
 <%--   <div class="modal fade " id="myModal">
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
    </div>--%>
    
</asp:Content>

