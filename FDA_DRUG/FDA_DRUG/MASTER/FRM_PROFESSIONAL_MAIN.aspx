<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_PROFESSIONAL_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_PROFESSIONAL_MAIN" %>
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
            <h2> รายการผู้เชียวชาญ&nbsp;</h2>
            <asp:Button ID="btn_reload" runat="server" Text="Button" style="display:none;" />
        </div>

    </div>
    
   <hr />
   <div>
       
       <br />
       <table width="100%">
           <tr>
               <td align="right">
                   <asp:Button ID="btn_manual" runat="server" Text="เพิ่มผชช. (Manual)" CssClass="input-lg" style="display:none;"/>
                   <asp:Button ID="btn_add" runat="server" Text="ดึงข้อมูลจากฐานข้อมูลกลาง" CssClass="input-lg"/></td>
           </tr>
           <tr>
               <td>
                   <telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="true" PageSize="20">
                       <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                           <Columns>
                               <telerik:GridBoundColumn DataField="IDA" FilterControlAltText="Filter IDA column"
                                   HeaderText="IDA" SortExpression="IDA" UniqueName="IDA" Display="false">
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="CITIZEN_ID" FilterControlAltText="Filter CITIZEN_ID column"
                                   HeaderText="เลขบัตรประชาชน" SortExpression="CITIZEN_ID" UniqueName="CITIZEN_ID" >
                               </telerik:GridBoundColumn>
                               <telerik:GridBoundColumn DataField="FULLNAME" FilterControlAltText="Filter FULLNAME column"
                                   HeaderText="ชื่อผู้เชี่ยวชาญ" SortExpression="FULLNAME" UniqueName="FULLNAME">
                               </telerik:GridBoundColumn>
                               <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="edt"
                                   CommandName="edt" Text="แก้ไข">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
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