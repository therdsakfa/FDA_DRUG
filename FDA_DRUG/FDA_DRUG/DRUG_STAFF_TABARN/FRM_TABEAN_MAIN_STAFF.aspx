<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_TABEAN_MAIN_STAFF.aspx.vb" Inherits="FDA_DRUG.FRM_TABEAN_MAIN_STAFF" %>
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

               $('#ContentPlaceHolder1_btn_upload_t').click(function () {

                   //  $('#spinner').toggle('slow');
                   Popups('../DR/POPUP_DR_UPLOAD.aspx');
                   return false;
               });

               $('#ContentPlaceHolder1_btn_download_t').click(function () {
                   $('#spinner').fadeIn('slow');

               });

               $('#ContentPlaceHolder1_btn_upload_ex').click(function () {

                   //  $('#spinner').toggle('slow');
                   Popups('../DS/POPUP_DS_UPLOAD.aspx');
                   return false;
               });

               $('#ContentPlaceHolder1_btn_download_ex').click(function () {
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
        <div >
            <h2> บัญชีรายการขอขึ้นทะเบียนยา</h2>

            License number : 
            <asp:Label ID="lbl_lcnno" runat="server" Text=""></asp:Label>
        </div>


        
    </div>
    <br />
    <asp:Panel ID="Panel3" runat="server" GroupingText="ข้อมูล">
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
    </asp:Panel>   

    <br />
<%--    <div class="panel-info" style="text-align: right; width: 100%">
        
    </div>--%>
  
   <div>

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
                       <%--<div style="text-align: right; padding-left: 5%; height: 60px;">
                           <asp:Button ID="btn_download_t" runat="server" Text="ดาวน์โหลดคำขอ" Width="170px" CssClass="btn-lg " />
                           &nbsp;&nbsp;
       <asp:Button ID="btn_upload_t" runat="server" Text="อัพโหลดคำขอ" Width="170px" CssClass="btn-lg " />
                           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
                           <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
                       </div>--%>
                   </td>
               </tr>
           </table>
           <br />
           <table class="table" style="width: 100%;">
               <tr>
                   <td>
                       <asp:GridView ID="GV_Tabean" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
                           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
                           <AlternatingRowStyle BackColor="White" />
                           <Columns>
                               <asp:BoundField DataField="IDA" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
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
                               <%--<asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                                   <ItemTemplate>
                                       <asp:Label ID="lbl_status" runat="server"></asp:Label>
                                   </ItemTemplate>

                                   <ItemStyle Width="10%"></ItemStyle>
                               </asp:TemplateField>--%>
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


       <fieldset>
           <legend style="color: red;">ยาตัวอย่าง</legend>
           <div style="text-align: right;">
            <%--<asp:Button ID="btn_download_ex" runat="server" Text="ดาวน์โหลดคำขอ" Width="170px" CssClass="btn-lg " />
            &nbsp;&nbsp;
       <asp:Button ID="btn_upload_ex" runat="server" Text="อัพโหลดคำขอ" Width="170px" CssClass="btn-lg " />--%>
           <%-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
            <asp:Button ID="Button4" runat="server" Text="reload" Style="display: none" />
            <asp:Button ID="Button5" runat="server" Text="Button" Style="display: none" />
        </div>
           <table class="table" style="width:100%;">
   <tr>
        <td>
            <asp:GridView ID="GV_Drug_EX" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
           <AlternatingRowStyle BackColor="White" />
           <Columns>
               <asp:BoundField DataField="IDA" HeaderText="IDA" ItemStyle-Width="0%" Visible="false">
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
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  /> 
              </div>  
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>รายละเอียด ยาตัวอย่าง </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
