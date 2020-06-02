<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_NODE.Master" CodeBehind="FRM_NORYORMOR3_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_PORYORBOR3_MAIN" %>
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

                //  $('#spinner').toggle('slow');
                Popups('POPUP_NORYORMOR3_UPLOAD.aspx');
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
    
    <div class="panel-info" style="text-align:right ;width:100%">
     <div  style="text-align:left;padding-left:5%;height:60px;">
          <asp:Button ID="btn_download" runat="server" Text="ดาวน์โหลดคำขอ" Width="170px" CssClass="btn-lg "   />   &nbsp;&nbsp;
       <asp:Button ID="btn_upload" runat="server" Text="อัพโหลดคำขอ" Width="170px"  CssClass="btn-lg "  />
         <asp:Button ID="btn_reload" runat="server" Text="reload" Width="170px"  CssClass="btn-lg "  Style="display:none;" />
         <asp:Button ID="btn_load" runat="server" Text="อัพโหลดคำขอ" Width="170px"  CssClass="btn-lg "  Style="display:none;"  />
         <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
            </div>
    </div>
   <hr />
   <div>

  
   
    <asp:GridView ID="GV_data" DataKeyNames="ID" runat="server" Width="100%"  CssClass="table"    CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
         <%--<asp:BoundField DataField="lcnsid" HeaderText="รหัสผู้ประกอบการ" ItemStyle-Width ="15%"  />--%>
       <%-- <asp:BoundField DataField="lcnno" HeaderText="เลขที่ใบอุญาตสถานที่" ItemStyle-Width ="20%" >
<ItemStyle Width="20%"></ItemStyle>
         </asp:BoundField>--%>
         <asp:BoundField DataField="ID"   HeaderText="ID" ItemStyle-Width ="1%" Visible="false" >
<ItemStyle Width="1%"></ItemStyle>
         </asp:BoundField>
        <asp:TemplateField ItemStyle-Width="0%" >
                     <ItemTemplate>
                      
                   <asp:Button ID="btn_pdf" runat="server" Text="ดาวโหลดPDF" CommandName="pdf" Visible="false" Width="0%"  CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />
            </ItemTemplate>

<ItemStyle Width="0%"></ItemStyle>
                </asp:TemplateField>
         <asp:BoundField DataField="regntfno" HeaderText="เลขที่คำขอ" ItemStyle-Width ="10%"  >
<ItemStyle Width="10%"></ItemStyle>
         </asp:BoundField>
        <%--<asp:BoundField DataField="fdpdtno"   HeaderText="เลขสารบบ" ItemStyle-Width ="10%" />--%>
           <asp:TemplateField HeaderText="เลขสารบบ" ItemStyle-Width ="10%"> 
                <ItemTemplate> 
                 <asp:label ID="lbl_fdpdtno"  runat="server" Text='<% #Eval("fdpdtno").ToString()%>' ></asp:label> 
                </ItemTemplate> 

<ItemStyle Width="10%"></ItemStyle>
                </asp:TemplateField> 
         <asp:BoundField DataField="rcvdate"  DataFormatString="{0:d}" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width ="20%" >
<ItemStyle Width="20%"></ItemStyle>
         </asp:BoundField>
         <asp:BoundField HeaderText="วันที่รับพิจารณา" DataFormatString="{0:d}" />
         <asp:BoundField HeaderText="วันที่แล้วเสร็จ" DataFormatString="{0:d}" />
        <asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                     <ItemTemplate>
                          <asp:Label ID="lbl_status" runat="server" ></asp:Label>
                     </ItemTemplate>

<ItemStyle Width="10%"></ItemStyle>
                </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="10%" HeaderText="รหัสการดำเนินการ">
                     <ItemTemplate>
                          <asp:Label ID="lbl_transession" runat="server" ></asp:Label>
                     </ItemTemplate>

<ItemStyle Width="10%"></ItemStyle>
                </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="20%">
                     <ItemTemplate>
                          
                   <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link"  CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />
                          <asp:Button ID="btn_Preview" runat="server" Text="ดูข้อมูล" CommandName="preview" Width="0%" CssClass="btn-link"  Visible="false"   CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />
            </ItemTemplate>

<ItemStyle Width="20%"></ItemStyle>
                </asp:TemplateField>
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#8CB343" Font-Bold="True" ForeColor="White"  />
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>

              <br />

              <div style="text-align:center;"> 
                  </div>  
        </div>

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
