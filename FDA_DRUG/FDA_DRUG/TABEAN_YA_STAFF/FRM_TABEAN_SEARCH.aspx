<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_TABEAN_SEARCH.aspx.vb" Inherits="FDA_DRUG.FRM_TABEAN_SEARCH" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            height: 160px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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

           $('#ContentPlaceHolder1_btn_upload').click(function () {
               Popups('POPUP_LCN_UPLOAD_ATTACH_SELECT.aspx');
               return false;
           });

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
    
 <%--  <div style="text-align:center;" >  เลขที่ใบอนุญาตสถานที่&nbsp;&nbsp;&nbsp;&nbsp;  <asp:DropDownList ID="ddl_lcnno" runat="server" CssClass="input-lg"  Width="20%"></asp:DropDownList> &nbsp;
       <asp:Button ID="Btn_ok" runat="server" Text="ยืนยัน" CssClass="btn-info" Width="67px"/>
       <br />
    </div>--%>
      <div id="spinner" style=" background-color:transparent; display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>
     <div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h2>ค้นหาใบทะเบียน</h2>

        </div>

    </div>
    
   <hr />
   <div>
       <table width="100%">
           <tr>
               <td class="auto-style1">
                    <table style="width: 100%;" class=" table">
           
           <%-- <tr>
                <td>เลขนิติบุคคล/เลขบัตรประชาชน</td>
                <td Width="70%">
                                <asp:TextBox ID="txt_CITIZEN_AUTHORIZE" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                </td>
            </tr>--%>
            <tr>
                <td>เลขทะเบียน</td>
                <td Width="70%">
                                <asp:TextBox ID="txt_lcnno_no" runat="server" CssClass="input-lg" Width="70%"></asp:TextBox>
                &nbsp;(ตัวอย่าง 1/26)</td>
            </tr>

            <tr>
                <td>&nbsp;</td>
                <td Width="70%">
                               <asp:Button ID="btn_search" runat="server" Text="ค้นหาข้อมูล" CssClass="btn-lg"/>
                </td>
            </tr>
        </table>


               </td>
           </tr>
           <tr>
               <td>

                   &nbsp;</td>
           </tr>
           <br />
           
            </table>
       <table width="100%">
           <tr>
               <td>
                  
                   <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       
                       <telerik:GridBoundColumn DataField="Newcode_U" FilterControlAltText="Filter Newcode_U column" HeaderText="Newcode_U"
                           SortExpression="Newcode_U" UniqueName="Newcode_U" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="rcvno_display" FilterControlAltText="Filter rcvno_display column"
                           HeaderText="เลขรับ" SortExpression="rcvno_display" UniqueName="rcvno_display">
                       </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="rgtno_display" FilterControlAltText="Filter rgtno_display column"
                           HeaderText="เลขทะเบียน" SortExpression="rgtno_display" UniqueName="rgtno_display">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column"
                           HeaderText="ชื่อการค้า(ภาษาไทย)" SortExpression="thadrgnm" UniqueName="thadrgnm">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column"
                           HeaderText="ชื่อการค้า(อื่นๆ)" SortExpression="engdrgnm" UniqueName="engdrgnm">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="rgtno_t_display" FilterControlAltText="Filter rgtno_t_display column"
                           HeaderText="เลขทะเบียนทรานสเฟอร์" SortExpression="rgtno_t_display" UniqueName="rgtno_t_display">
                       </telerik:GridBoundColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_report"
                           CommandName="report" Text="แบบฟอร์มทะเบียน">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_Select"
                           CommandName="sel" Text="ดูข้อมูล">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_add"
                           CommandName="add" Text="เพิ่มข้อมูลส่วนที่ 2">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_trid"
                       CommandName="_trid" Text="ขอเลขดำเนินการ" ConfirmText="คุณต้องการทำต่อหรือไม่?">
                       <HeaderStyle Width="70px" />

                   </telerik:GridButtonColumn>
                   </Columns>
               </MasterTableView>
           </telerik:RadGrid>
              
                   
               </td>
           </tr>

       </table>
        </div>
   <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    <asp:Label ID="lbl_titlename" runat="server" Text=""></asp:Label><button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
    <div class="modal fade " id="myModal2">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    เสนอลงนาม
                    <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f2" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
     <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"  />
</asp:Content>