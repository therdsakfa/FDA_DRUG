<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Auto_Menu.Master" CodeBehind="FRM_EXTEND_LCN_ATTACH_PAGE.aspx.vb" Inherits="FDA_DRUG.FRM_EXTEND_LCN_ATTACH_PAGE" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" >



        $(document).ready(function () {
            //$(window).load(function () {
            //    $.ajax({
            //        type: 'POST',
            //        data: { submit: true },
            //        success: function (result) {
            //            $('#spinner').fadeOut(1);

            //        }
            //    });
            //});

            function CloseSpin() {
                $('#spinner').toggle('slow');
            }

            //$('#ContentPlaceHolder1_btn_upload').click(function () {
            //    Popups('POPUP_LCN_UPLOAD_ATTACH_SELECT.aspx');
            //    return false;
            //});

            $('#ContentPlaceHolder1_btn_download').click(function () {
                Popups('POPUP_LCN_DOWNLOAD_DRUG.aspx');
                return false;
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
        function Popups3(url) { // สำหรับทำ Div Popup

            $('#myModal2').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f2'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }
        function spin_space() { // คำสั่งสั่งปิด PopUp
            //    alert('123456');
            $('#spinner').toggle('slow');
            //$('#myModal').modal('hide');
            //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click

        }
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        function close_modal2() { // คำสั่งสั่งปิด PopUp
            $('#myModal2').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }
        </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>
        พิกัด
        <table width="100%" class="table">
            <tr>
                <td>
                    latitude
                </td>
                <td>

                    <asp:TextBox ID="txt_latitude" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>
                    longitude</td>
                <td>

                    <asp:TextBox ID="txt_longitude" runat="server"></asp:TextBox>

                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>

                    <asp:Button ID="btn_save_lalong" runat="server" Text="บันทึกพิกัด" />

                </td>
            </tr>
        </table>
    </h2>

    <br /><hr />
    <h2>
        เลือกการยื่นเอกสาร
    </h2>
     <table width="100%" class="table">
         <tr>
             <td>
                  <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True">
                     <asp:ListItem Value="1">1. ยื่นผ่านระบบ skynet Smart Dropbox</asp:ListItem>
                     <asp:ListItem Value="2">2. ยื่นผ่านไปรษณีย์ลงทะเบียนไปยัง (บอกที่อยู่และใบนำส่งเอกสาร)</asp:ListItem>
                     <asp:ListItem Value="3">3. ยื่นด้วยตนเองที่ อย. (โปรดระบุบเลขดำเนินการและใบนำส่งเอกสาร)</asp:ListItem>
                 </asp:RadioButtonList>
             </td>
             <td>
                  <asp:TextBox ID="txt_ATTACH_DETAIL" runat="server" Width="300px" TextMode="MultiLine" Height="100px"></asp:TextBox>
             </td>
         </tr>
         <tr>
             <td>
                  <asp:Button ID="btn_att_type" runat="server" Text="บันทึกการยื่นเอกสาร" />
             </td>
             <td>
                  &nbsp;</td>
         </tr>
        </table>

    <br /><hr />
    <h2>
        รายการไฟล์แนบ
    </h2>
    <table width="100%" class="table">
        <tr>
            <td align="right">
                <asp:Button ID="btn_upload" runat="server" Text="UPLOAD" CssClass="input-lg" />
                <asp:Button ID="btn_reload" runat="server" Text="Button" style="display:none;" />
            </td>
        </tr>
        
        <tr>
            <td>
                <asp:GridView ID="gv" runat="server" Width="100%" DataKeyNames="IDA" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                      <AlternatingRowStyle BackColor="White" />
                      <Columns>
                          <asp:BoundField  HeaderText="ชื่อไฟล์แนบ" ItemStyle-Width="70%" DataField="NAME_REAL"/>

                           <asp:TemplateField ItemStyle-Width="30%">
                     <ItemTemplate>
                          
                        <asp:HyperLink ID="btn_Select" runat="server"  Target="_blank" CssClass="btn-control" CommandName="sel" Width="100%"  CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'  >ดูข้อมูล</asp:HyperLink>
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
                 </asp:GridView></td>
        </tr>
    </table>
    <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    
                    แนบไฟล์<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
