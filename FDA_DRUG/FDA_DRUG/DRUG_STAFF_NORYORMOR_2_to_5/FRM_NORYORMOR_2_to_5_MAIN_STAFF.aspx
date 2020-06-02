<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_NORYORMOR_2_to_5_MAIN_STAFF.aspx.vb" Inherits="FDA_DRUG.FRM_NORYORMOR_2_to_5_MAIN_STAFF" %>
<%@ Register Src="~/UC/UC_HEADER.ascx" TagPrefix="uc1" TagName="UC_HEADER" %>
<%@ Register Src="~/UC/UC_FILTER.ascx" TagPrefix="uc1" TagName="UC_FILTER" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                var process_id;
                process_id = getQuerystring('process');
                //  $('#spinner').toggle('slow');
                Popups('POPUP_NORYORMOR_2_to_5_UPLOAD.aspx?process=' + process_id);
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
     <div id="spinner" style=" background-color:transparent; display:none;" >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>

    <div >
         
        <uc1:UC_HEADER runat="server" id="UC_HEADER" />
      
            <table style="width:100%;" class=" table">
        <tr>
            <td >
                <uc1:UC_FILTER runat="server" id="UC_FILTER" />
            </td>
             <td style="width:15%;">
                 <asp:Button ID="btn_filter" runat="server" Text="ค้นหา" Width="100px" CssClass="btn-lg"  />
            </td>
        </tr>
    </table>
    </div>
    <fieldset>
           <legend style="color: red;">ข้อมูล</legend>
        <table class="table" style="width: 100%;">
            <tr>
                <td>
                    ชื่อยา
                </td>
                <td>
                    <asp:Label ID="lb_drug_name" runat="server" Text=""></asp:Label>
                </td>
            </tr>
        </table>
    </fieldset>
    
   <div>

           <fieldset>
           <legend style="color: red;">Report</legend>
               <div class="panel-info" style="text-align:right ;width:100%">
    </div>
           <table style="width: 100%;">
               <tr>
                   <td>
                       <asp:GridView ID="GV_data" DataKeyNames="ID" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
                           <AlternatingRowStyle BackColor="White" />
                           <Columns>

                               <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="1%" Visible="false">
                                   <ItemStyle Width="1%"></ItemStyle>
                               </asp:BoundField>
                               <asp:TemplateField ItemStyle-Width="0%">
                                   <ItemTemplate>

                                       <asp:Button ID="btn_pdf" runat="server" Text="ดาวโหลดPDF" CommandName="pdf" Visible="false" Width="0%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                   </ItemTemplate>

                                   <ItemStyle Width="0%"></ItemStyle>
                               </asp:TemplateField>
                               <asp:BoundField DataField="regntfno" HeaderText="เลขที่คำขอ" ItemStyle-Width="10%">
                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:BoundField>
                               <%--<asp:BoundField DataField="fdpdtno"   HeaderText="เลขสารบบ" ItemStyle-Width ="10%" />--%>
                               <asp:TemplateField HeaderText="เลขสารบบ" ItemStyle-Width="10%">
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_fdpdtno" runat="server" Text='<% #Eval("fdpdtno").ToString()%>'></asp:Label>
                                   </ItemTemplate>

                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:TemplateField>
                               <asp:BoundField DataField="rcvdate" DataFormatString="{0:d}" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width="20%">
                                   <ItemStyle Width="20%"></ItemStyle>
                               </asp:BoundField>
                               <asp:BoundField HeaderText="วันที่รับพิจารณา" DataFormatString="{0:d}" />
                               <asp:BoundField HeaderText="วันที่แล้วเสร็จ" DataFormatString="{0:d}" />
                               <asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_status" runat="server"></asp:Label>
                                   </ItemTemplate>

                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:TemplateField>
                               <asp:TemplateField ItemStyle-Width="10%" HeaderText="รหัสการดำเนินการ">
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_transession" runat="server"></asp:Label>
                                   </ItemTemplate>

                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:TemplateField>
                               <asp:TemplateField ItemStyle-Width="20%">
                                   <ItemTemplate>

                                       <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                       <asp:Button ID="btn_Preview" runat="server" Text="ดูข้อมูล" CommandName="preview" Width="0%" CssClass="btn-link" Visible="false" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
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
   
    

              <br />

              <div style="text-align:center;"> 
                  </div>  
        </div>
     <fieldset>
           <legend style="color: red;">ข้อมูลจากระบบด่าน</legend>
           <table class="table" style="width:100%;">
   <tr>
        <td>
            
        </td>
    </tr>
</table>
       </fieldset>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>

</asp:Content>
