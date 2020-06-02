<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_ETRACKING_STATUS_SUB_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_ETRACKING_STATUS_SUB_MAIN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register src="UC/UC_INFORMATION_HEAD.ascx" tagname="UC_INFORMATION_HEAD" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../../css/css_radgrid.css" rel="stylesheet" />
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

                   //  $('#spinner').toggle('slow');
                   Popups('POPUP_DS_UPLOAD.aspx');
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
            <h2> 
                ปรับสถานะเสริม</h2>
            <uc1:UC_INFORMATION_HEAD ID="UC_INFORMATION_HEAD1" runat="server" />
            <%--License number : 
            <asp:Label ID="lbl_lcnno" runat="server" Text=""></asp:Label>--%>
        </div>


        <%--<table style="width: 100%;" class=" table">
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
                <td>ชื่อผลิตภัณฑ์ 
                </td>
                <td>
                    <asp:TextBox ID="txt_name" class="form-control" runat="server"></asp:TextBox>
                </td>

                <td>เลขจดแจ้ง  
                </td>
                <td>
                    <asp:TextBox ID="txt_number" class="form-control" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_filter" runat="server" Text="ค้นหา" Width="100px" CssClass="btn-lg" />
                </td>
            </tr>
        </table>--%>
        <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
        </telerik:RadScriptManager>
    </div>
    
    <div class="panel-info" style="text-align: right; width: 100%">
        <div style="text-align: right;height: 60px;">
            <table style="width:100%;">
                <tr>
                    <td>ช่วงสถานะ</td>
                    <td style="width:40%;">
                        <asp:DropDownList ID="ddl_head_status" runat="server" CssClass="input-sm" Width="40%" AutoPostBack="True"></asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                    <td>
<asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" CssClass="btn-lg "/>
<asp:Button ID="btn_add" runat="server" Text="เพิ่มช่วงสถานะเสริม" CssClass="btn-lg "/>
                    </td>
                </tr>
                <%--<tr>
                    <td>วันที่เริ่มกระบวนการ</td>
                    <td style="width:40%;" align="left">
                        <asp:TextBox ID="txt_start_date" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        วันสิ้นสุด</td>
                    <td align="left">
                        <asp:TextBox ID="txt_end_date" runat="server"></asp:TextBox></td>
                </tr>--%>
            </table>


            
            <asp:Button ID="btn_download" runat="server" Text="ดาวน์โหลดคำขอ" Width="170px" CssClass="btn-lg " style="display:none;" />
            &nbsp;&nbsp;
       <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดคำขอ" Width="170px" CssClass="btn-lg " style="display:none;"/>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
            <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
        </div>
    </div>
  
   <hr />
   <div>

       <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="15" CellSpacing="0">
           <MasterTableView>
               <Columns>
                   <telerik:GridBoundColumn UniqueName="IDA" DataField="IDA" Display="false" HeaderText="IDA">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn UniqueName="HEAD_STATUS_ID" DataField="HEAD_STATUS_ID" Display="false" HeaderText="HEAD_STATUS_ID">
                   </telerik:GridBoundColumn>
                   
                   <telerik:GridBoundColumn UniqueName="FDA_STATUS" DataField="FDA_STATUS" HeaderText="เลขที่คำขอ">
                   </telerik:GridBoundColumn>
                   <telerik:GridBoundColumn UniqueName="START_DATE" DataField="START_DATE" HeaderText="วันที่เริ่มกระบวนการ" DataFormatString="{0:d}">
                   </telerik:GridBoundColumn>
                 <telerik:GridBoundColumn UniqueName="END_DATE" DataField="END_DATE" HeaderText="วันสิ้นสุดกระบวนการ" DataFormatString="{0:d}">
                   </telerik:GridBoundColumn>
                   <%--<telerik:GridBoundColumn UniqueName="STATUS_NAME" DataField="STATUS_NAME" HeaderText="สถานะ">
                   </telerik:GridBoundColumn>--%>
                   <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="_date" Text="บันทึกวันที่เริ่ม-สิ้นสุด" UniqueName="_date">
                   </telerik:GridButtonColumn>
                   <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="sel" Text="ปรับสถานะ" UniqueName="btn_sel">
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
       </asp:GridView>--%>

              <br />

              <%--<div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  /> 
              </div>--%>  
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