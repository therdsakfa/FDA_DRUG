<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_EDIT.Master" CodeBehind="FRM_PHR_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_PHR_MAIN" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<%@ Register src="../UC/UC_Information_edit.ascx" tagname="UC_Information_edit" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript" >



        $(document).ready(function () {


            function CloseSpin() {
                $('#spinner').toggle('slow');
            }


            function Popups(url) { // สำหรับทำ Div Popup

                $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                var i = $('#f1'); // ID ของ iframe   
                i.attr("src", url); //  url ของ form ที่จะเปิด
            }


            $('#ContentPlaceHolder1_btn_download_2').click(function () {
                $('#spinner').fadeIn('slow');

            });

            $('#ContentPlaceHolder1_btn_download').click(function () {
                $('#spinner').fadeIn('slow');

            });

        });
        function close_modal() { // คำสั่งสั่งปิด PopUp
            $('#myModal').modal('hide');
            $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
        }

        function Popups2(url) { // สำหรับทำ Div Popup

            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", url); //  url ของ form ที่จะเปิด
        }


        function closespinner() {
            alert('Download เสร็จสิ้น');
            $('#spinner').fadeOut('slow');
            $('#ContentPlaceHolder1_Button1').click();
        }
        </script> 
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h2> เภสัชกร</h2>
            <asp:Button ID="btn_reload" runat="server" Text="Button" style="display:none;" />
        </div>

    </div>
    
   <hr />
   <div>
       <table width="100%">
           <tr>
               <td align="center">
                   <%--<table>
                       <tr>
                           <td>
                               ประเภทการค้นหา</td>
                           <td>
                               <asp:DropDownList ID="ddl_type" runat="server">
                                   <asp:ListItem Value="1">สถานที่จำลอง</asp:ListItem>
                                   <asp:ListItem Value="2">สถานที่เก็บ</asp:ListItem>
                               </asp:DropDownList>
                           </td>
                           <td>
                               เลขนิติบุคคล</td>
                           <td>
                               <asp:TextBox ID="txt_citizen" runat="server" CssClass="btn-lg" Width="200px"></asp:TextBox>
                               <asp:Button ID="btn_search" runat="server" Text="ค้นหาข้อมูล" CssClass="btn-lg"/></td>
                       </tr>
                   </table>--%>
                   
                   <uc1:UC_Information_edit ID="UC_Information_edit1" runat="server" />
                   
               </td>
           </tr>
                      
       </table>
       
       <br />
       <table width="100%">
           <tr>
               <td align="right">
                   <asp:Button ID="btn_change" runat="server" Text="เปลี่ยนผู้ปฏิบัติการ" CssClass="input-lg"/>
                   <asp:Button ID="btn_add" runat="server" Text="เพิ่มผู้ปฏิบัติการ" CssClass="input-lg"/></td>
           </tr>
           <tr>
               <td>
                   <telerik:RadGrid ID="RadGrid2" runat="server">
                       <ClientSettings EnableRowHoverStyle="true">
                           <Selecting AllowRowSelect="true" />
                       </ClientSettings>
                       <MasterTableView AutoGenerateColumns="False" DataKeyNames="PHR_IDA">
                           <Columns>
                        
                               <telerik:GridBoundColumn DataField="PHR_IDA" FilterControlAltText="Filter PHR_IDA column"
                                   HeaderText="PHR_IDA" SortExpression="PHR_IDA" UniqueName="PHR_IDA" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="PHR_FULLNAME" FilterControlAltText="Filter PHR_FULLNAME column"
                                   HeaderText="ชื่อผู้ปฏิบัติการ" SortExpression="PHR_FULLNAME" UniqueName="PHR_FULLNAME">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="PHR_CTZNO" FilterControlAltText="Filter PHR_CTZNO column"
                                   HeaderText="เลขบัตรประชาชน" SortExpression="PHR_CTZNO" UniqueName="PHR_CTZNO" >
                               </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="functnm" FilterControlAltText="Filter functnm column"
                                   HeaderText="หน้าที่" SortExpression="functnm" UniqueName="functnm" >
                               </telerik:GridBoundColumn>
                               <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="his"
                                   CommandName="his" Text="ประวัติ">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
                               <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="edt"
                                   CommandName="edt" Text="แก้ไข">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
                               <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="del"
                                   CommandName="del" Text="ลาออก/ยกเลิก">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
                              <%-- <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="add"
                                   CommandName="add" Text="ขอเพิ่ม">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>--%>
                               <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="r_del"
                                   CommandName="r_del" Text="ลบข้อมูลถาวร">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
                               <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="job"
                                   CommandName="job" Text="หน้าที่">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
                               <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="cancel" ConfirmText="คุณต้องการยกเลิกหรือไม่"
                                   CommandName="cancel" Text="ยกเลิก">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>--%>
                           </Columns>
                       </MasterTableView>
                   </telerik:RadGrid>
              
               </td>
           </tr>
       </table>
        </div>
    <div class="panel-footer">
        <center>
<asp:Button ID="btn_back" runat="server" Text="ย้อนกลับ" CssClass="btn-lg"></asp:Button>
        </center>
    </div>



   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>ข้อมูลผู้ปฏิบัติงาน </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>