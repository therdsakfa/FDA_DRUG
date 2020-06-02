<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_PHARMACIST.Master" CodeBehind="FRM_PHARMACIST_MAIN.aspx.vb" Inherits="FDA_DRUG.WebForm2" %>
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

                  //$('#ContentPlaceHolder1_btn_upload').click(function () {

                  //    //  $('#spinner').toggle('slow');
                  //    Popups('POPUP_DS_UPLOAD.aspx');
                  //    return false;
                  //});

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
            <h2> เภสัชกร</h2>

        </div>


        <table style="width: 100%; display:none;" class=" table">
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
            &nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
            <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
        </div>
    </div>
  
   <hr />
   <div>

      <asp:GridView  ID="GV_lcnno"  runat="server" Width="100%"  DataKeyNames="PHR_IDA" CellPadding="4" CssClass="table" 
      ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
    <AlternatingRowStyle BackColor="White"  />
    <Columns>
          <asp:TemplateField ItemStyle-Width="0%" Visible="false" >
                     <ItemTemplate>
                   <asp:Button ID="btn_pdf" runat="server" Text="ดาวโหลดPDF" CommandName="pdf" Width="80%" Visible="false" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />
            </ItemTemplate>
                </asp:TemplateField>
           <asp:BoundField DataField="IDA" HeaderText="IDA" ItemStyle-Width ="0%" Visible="false"  />
         <asp:BoundField DataField="lcnsid" HeaderText="รหัสผู้ประกอบการ" ItemStyle-Width ="0%" Visible="false"  />
        <asp:BoundField DataField="lcnno" HeaderText="เลขที่ใบอนุญาต" ItemStyle-Width ="10%" ItemStyle-HorizontalAlign="Left" />
       
        <asp:BoundField  HeaderText="ชื่อสถานที่" ItemStyle-Width="20%" DataField="nameplace"/>
         <asp:BoundField  HeaderText="ที่อยู่" ItemStyle-Width="35%" DataField="fulladdr"/>
        <asp:BoundField  HeaderText="สถานะการยืนยัน" ItemStyle-Width="15%" DataField="STATUS_NAME"/>
   
        <asp:TemplateField ItemStyle-Width="10%">
                     <ItemTemplate>
                          
                   <asp:Button ID="btn_down" runat="server" Text="ดาวน์โหลดำขอ" CommandName="down" Width="100%" CssClass="btn-link"  CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />  &nbsp; &nbsp; &nbsp;
                        
                     </ItemTemplate>
                </asp:TemplateField>
        <asp:TemplateField ItemStyle-Width="10%">
                     <ItemTemplate>
                          
                        <asp:Button ID="btn_up" runat="server" Text="อัพโหลดคำขอ" CommandName="up" Width="100%" CssClass="btn-link"   CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  />
            
                     </ItemTemplate>
                </asp:TemplateField>
    </Columns>
    <EditRowStyle BackColor="#2461BF" />
    <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#8CB340 " Font-Bold="True" ForeColor="White"  CssClass="row"/>
    <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#EFF3FB" CssClass="row" />
    <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#F5F7FB" />
    <SortedAscendingHeaderStyle BackColor="#6D95E1" />
    <SortedDescendingCellStyle BackColor="#E9EBEF" />
    <SortedDescendingHeaderStyle BackColor="#4870BE" />
            </asp:GridView>

              <br />

              <div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  /> 
              </div>  
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>รายละเอียด เภสัชกร </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
