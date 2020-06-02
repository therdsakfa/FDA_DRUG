<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_NODE_EDIT.Master" CodeBehind="FRM_EDIT_TABEAN_YA_MAIN.aspx.vb" Inherits="FDA_DRUG.WebForm12" %>
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
                var IDA = getQuerystring("IDA");
                var FK_IDA = getQuerystring("FK_IDA");
                var PROCESS = getQuerystring("PROCESS");
                //  $('#spinner').toggle('slow');
                Popups('POPUP_DI_UPLOAD.aspx?IDA=' + IDA + '&FK_IDA=' + FK_IDA + '&PROCESS=' + PROCESS);
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
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h2> ทะเบียนที่ต้องการร้องขอแก้ไข</h2>
            <p> &gt; <asp:Label ID="lbl_AUTO_TYPE" runat="server" Text=""></asp:Label>
                &nbsp;<asp:Label ID="lbl_EDIT_TYPE" runat="server" Text=""></asp:Label>
            </p>

            License number : 
            <asp:Label ID="lbl_lcnno" runat="server" Text=""></asp:Label>
        </div>


        <table style="width: 100%;" class=" table">
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
     
            <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />
            <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
      
   <hr />
   <div>

     <asp:GridView ID="GV_data" DataKeyNames="IDA" runat="server" Width="100%" CssClass="table" CellPadding="4" ForeColor="#333333"
           GridLines="None" AutoGenerateColumns="False" AllowPaging="True" PageSize="20" Font-Size="10pt">
           <AlternatingRowStyle BackColor="White" />
           <Columns>

               <asp:BoundField DataField="ID" HeaderText="ID" ItemStyle-Width="0%" Visible="false">
                   <ItemStyle Width="0%"></ItemStyle>
               </asp:BoundField>
       
               <asp:BoundField DataField="appvno" HeaderText="เลขที่คำขอ" ItemStyle-Width="10%">
               </asp:BoundField>
                  
               <asp:BoundField DataField="appdate" DataFormatString="{0:d}" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width="10%">
               </asp:BoundField>
               <asp:BoundField DataField="thadrgnm" HeaderText="วันที่ยื่นคำขอ" ItemStyle-Width="30%">
               </asp:BoundField>
               
        
               <%--   <asp:BoundField DataField="STATUS_ID" HeaderText="สถานะ" ItemStyle-Width="10%">
                   <ItemStyle Width="10%"></ItemStyle>
               </asp:BoundField>--%>
          <%--     <asp:TemplateField ItemStyle-Width="10%" HeaderText="สถานะ">
                   <ItemTemplate>
                       <asp:Label ID="lbl_status" runat="server"></asp:Label>
                   </ItemTemplate>

                   <ItemStyle Width="10%"></ItemStyle>
               </asp:TemplateField>--%>
           <%--    <asp:TemplateField ItemStyle-Width="10%" HeaderText="รหัสการดำเนินการ">
                   <ItemTemplate>
                       <asp:Label ID="lbl_transession" runat="server"></asp:Label>
                   </ItemTemplate>

                   <ItemStyle Width="10%"></ItemStyle>
               </asp:TemplateField>--%>
              <%-- <asp:TemplateField ItemStyle-Width="15%">
                   <ItemTemplate>
                       <asp:Button ID="btn_Select" runat="server" Text="ดูข้อมูล" CommandName="sel" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                        </ItemTemplate>
               </asp:TemplateField>--%>
                <asp:TemplateField ItemStyle-Width="15%">
                   <ItemTemplate>
                       <asp:Button ID="btn_Edit" runat="server" Text="เลือกข้อมูล" CommandName="edt" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                        </ItemTemplate>
               </asp:TemplateField>
              <%--   <asp:TemplateField ItemStyle-Width="20%">
                   <ItemTemplate>
                       <asp:Button ID="btn_Download" runat="server" Text="ดาวน์โหลดคำขอ" CommandName="Download" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                       </ItemTemplate>
               </asp:TemplateField>
                 <asp:TemplateField ItemStyle-Width="15%">
                   <ItemTemplate>
                       <asp:Button ID="btn_Upload" runat="server" Text="อัพโหลดคำขอ" CommandName="Upload" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                        </ItemTemplate>
               </asp:TemplateField>--%>
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

              <div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  /> 
              </div>  
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>รายละเอียด คำขอแก้ไข</h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
