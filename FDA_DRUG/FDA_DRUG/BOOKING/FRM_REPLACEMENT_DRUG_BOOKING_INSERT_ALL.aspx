<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF_MAIN.Master" CodeBehind="FRM_REPLACEMENT_DRUG_BOOKING_INSERT_ALL.aspx.vb" Inherits="FDA_DRUG.FRM_REPLACEMENT_DRUG_BOOKING_INSERT_ALL" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server">
      </telerik:RadAjaxManager>


     <!-- BEGIN syntax highlighter -->
	<script type="text/javascript" src="../sh/shCore.js"></script>
	<script type="text/javascript" src="../sh/shBrushJScript.js"></script>
	<link type="text/css" rel="stylesheet" href="../sh/shCore.css"/>
	<link type="text/css" rel="stylesheet" href="../sh/shThemeDefault.css"/>
	<script type="text/javascript">
	    SyntaxHighlighter.all();
	</script>
	<!-- END syntax highlighter -->

	<%--<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>--%>
	<script type="text/javascript" src="../jquery.searchabledropdown-1.0.8.min.js"></script>



      <script type="text/javascript" >



          $(document).ready(function () {

              $("#ContentPlaceHolder1_ddl_process").searchable();



              function CloseSpin() {
                  $('#spinner').toggle('slow');
              }


              function Popups(url) { // สำหรับทำ Div Popup

                  $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
                  var i = $('#f1'); // ID ของ iframe   
                  i.attr("src", url); //  url ของ form ที่จะเปิด
              }




              $('#ContentPlaceHolder1_btn_download').click(function () {
                  $('#spinner').fadeIn('slow');

              });

          });
          function close_modal() { // คำสั่งสั่งปิด PopUp
              $('#myModal').modal('hide');
              $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
          }

          function close_modal_customer() { // คำสั่งสั่งปิด PopUp
              $('#myModal').modal('hide');
              $('#ContentPlaceHolder1_btn_customer_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
          }

          function close_modal_address() { // คำสั่งสั่งปิด PopUp
              $('#myModal').modal('hide');
              $('#ContentPlaceHolder1_btn_address_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
          }

          function close_modal_visitor() { // คำสั่งสั่งปิด PopUp
              $('#myModal').modal('hide');
              $('#ContentPlaceHolder1_btn_reload_visitor').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
          }

          function reload() { // คำสั่งสั่งปิด PopUp
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
              $('#ContentPlaceHolder1_btn_down').click();
          }
        </script> 


   <div class="panel panel-default">
       <div class="panel-heading" style="background-color:gold;color:black;width:100%"> ลงทะเบียนนัดหมาย</div>
       
        </div>
        <table style="width:100%" class="table">
    
       <tr>
             <td  style="width:15%">

            </td>
             <td  style="width:20%">
                 
                 กลุ่ม/ฝ่าย :</td>
           <td style="width:45%">

               <asp:DropDownList ID="ddl_SERVICE" runat="server" Width="100%" AutoPostBack="true">
                   <asp:ListItem Value="0" Text ="กรุณาเลือกกลุ่ม/ฝ่าย"></asp:ListItem>
                  
               </asp:DropDownList>



            </td>
             <td style="width:25%">

                 &nbsp;</td>
        </tr>
   <tr>
             <td >

            </td>

             <td >

                 กระบวนการ :</td>
           <td >

               <%--<telerik:RadSearchBox ID="rsb_doc" runat="server"  Width="100%" AutoCompleteSeparator="Contains " MarkFirstMatch="True" ></telerik:RadSearchBox>--%>
             <%--  <telerik:RadComboBox ID="rcb_doc" Runat="server" Width="100%"  AutoCompleteSeparator="Contains" Filter="Contains">
                   <Items>
                       <telerik:RadComboBoxItem runat="server" Text="กรุณาเลือกข้อมูล" Value="0" />
                       <telerik:RadComboBoxItem runat="server" Text="ยาเสพติดให้โทษ" Value="1" />
                   </Items>
               </telerik:RadComboBox>--%>
               <asp:DropDownList ID="ddl_process" runat="server" Width="80%"  >
                   <asp:ListItem Value="0">กรุณาเลือกกระบวนการ</asp:ListItem>
               </asp:DropDownList>
             </td>
             <td >

                 &nbsp;</td>
        </tr>
            </table>
    <asp:Panel ID="pn_date" runat="server" Width="100%" Visible="false">
      <table style="width:100%" class="table">
          <tr>
             <td style="width:15%" >

            </td>
             <td style="width:20%">

                 วันที่ :</td>
           <td style="width:45%">

               <telerik:RadDatePicker ID="rdp_date" runat="server" AutoPostBack="True" Calendar-DayCellToolTipFormat="dd/MM/yyyy" Culture="th-TH" DateInput-DateFormat="dd/MM/yyyy" DateInput-DisplayDateFormat="dd/MM/yyyy" Width="80%">
                   <DateInput ID="DateInput3" runat="server" AutoPostBack="false" DateFormat="dd/MM/yyyy" Width="80%">
                   </DateInput>
                   <Calendar ID="Calendar3" runat="server" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                   </Calendar>
               </telerik:RadDatePicker>

              </td>
             <td style="width:25%">

                 &nbsp;</td>
        </tr>
                     <tr>
             <td >

            </td>
             <td >

                 เวลาเริ่มต้น :</td>
           <td style="width:25%">

            
  <telerik:RadTimePicker ID="rtp_time_start" Runat="server"  Width="80%" >
                 </telerik:RadTimePicker>
              </td>
             <td style="width:25%">

               
                         </td>
        </tr>
              <tr>
             <td >

            </td>
             <td >

                 เวลาสิ้นสุด :</td>
           <td style="width:25%">
                   <telerik:RadTimePicker ID="rtp_time_end" Runat="server"  Width="80%"></telerik:RadTimePicker>
              </td>
             <td style="width:25%">

                 &nbsp;</td>
        </tr>
           </table>
        </asp:Panel>
     <table style="width:100%" class="table">
    <tr>
             <td style="width:15%">

            </td>
             <td style="width:20%">

                 เลขบัตรประชาชนผู้มาติดต่อนัดหมาย :</td>
           <td style="width:45%">

               <asp:TextBox ID="txt_no_visitor" runat="server" Width="100%" Enabled="false"></asp:TextBox>

              </td>
             <td style="width:25%">

                 <asp:Button ID="btn_data_txt_no" runat="server" Text="เลือกชื่อผู้มาติดต่อนัดหมาย"  Width="70%" CssClass="btn-info"/>
                   &nbsp;<asp:Button ID="btn_reload_visitor" runat="server" CssClass="btn-info" Style="display:none;"  Text="btn_reload_visitor" Width="70%" />
               
                 </td>
        </tr>
             <tr>
             <td >

            </td>
             <td >

                 ชื่อผู้มายื่น :</td>
           <td style="width:25%">

             
               <asp:TextBox ID="txt_name_visitor" runat="server" Width="100%" Enabled="false"></asp:TextBox>

              </td>
             <td style="width:25%">

                 &nbsp;</td>
        </tr>
      <tr>
             <td class="auto-style1">

            </td>
             <td class="auto-style1">

                 หมายเหตุ :</td>
           <td class="auto-style2">

               <asp:TextBox ID="txt_remark" runat="server" Width="100%" Height="54px" TextMode="MultiLine"></asp:TextBox>

              </td>
             <td class="auto-style2">

                 </td>
        </tr>

          <tr>
             <td style="width:100%;text-align:center;"  colspan="4" >

                 &nbsp;

                 </td>
        </tr>
    </table>
    <asp:Panel ID="pn_data"  Width="100%" runat="server" >
        <h3 style="text-align:center;" >
            ข้อมูลการขอนัดหมาย
        </h3>

    <table style="width:100%" class="table">
                  <tr>
             <td >

            </td>
             <td >

                 Product ID :</td>
           <td >

               <asp:TextBox ID="txt_product_ID" runat="server" Width="80%" Enabled="true"></asp:TextBox>
                 </td>
             <td >

                 <asp:Button ID="btn_data_product_id" runat="server" CssClass="btn-info" Text="ตรวจสอบข้อมูล Product ID" Width="80%" />
                 </td>
        </tr>
          <tr>
             <td style="width:25%">

            </td>
             <td style="width:25%">

                 เลขทะเบียน :</td>
           <td style="width:25%">
               
               <asp:TextBox ID="txt_LCN_NUMBER" runat="server" Width="80%" Enabled="true"></asp:TextBox>
                 
                    </td>
             <td style="width:25%">

                 <asp:Button ID="btn_data_product_id_2" runat="server" CssClass="btn-info" Text="ตรวจสอบข้อมูลเลขทะเบียน" Width="80%" />
              </td>
        </tr>
                <tr>
             <td >

            </td>

             <td >

                 ชื่อผลิตภัณฑ์ :</td>
           <td >

             <asp:Label ID="lbl_product_name" runat="server" Text=""></asp:Label>
                    </td>
             <td >

                 &nbsp;</td>
        </tr>
              
           <tr>
             <td style="width:15%">

            </td>
             <td style="width:20%">

                 เลขนิติบุคคล/เลขบัตรประชาชน/รหัสองค์กร :</td>
           <td style="width:45%">

               <asp:TextBox ID="txt_identify" runat="server" Width="100%" Enabled="false"></asp:TextBox>
             </td>
             <td style="width:25%">
                 <asp:Button ID="btn_customer" runat="server" CssClass="btn-info" Text="เลือกข้อมูลผู้ประกอบการ" Width="70%" />
                 &nbsp;<asp:Button ID="btn_customer_reload" runat="server" CssClass="btn-info" Style="display:none;" Text="btn_customer_reload" Width="70%" />
               </td>
        </tr>
        <tr>
             <td style="width:15%">

            </td>
             <td style="width:20%">

                 ชื่อผู้ประกอบการ :</td>
           <td style="width:45%">

               <asp:TextBox ID="txt_name" runat="server" Width="100%" Enabled="false"></asp:TextBox>
             </td>
             <td style="width:25%">

                 &nbsp;</td>
        </tr>

     
  
  
          <tr>
             <td >

            </td>
             <td >

                 ชื่อสถานที่ :</td>
           <td style="width:25%">

              <asp:TextBox ID="txt_location_name" runat="server" Width="100%" Enabled="false"></asp:TextBox>
              </td>
             <td style="width:25%">

                 <asp:Button ID="btn_address" runat="server" CssClass="btn-info" Text="เลือกข้อมูลสถานที่" Width="70%" />
                 <asp:Button ID="btn_address_reload" runat="server" CssClass="btn-info" Style="display:none;" Text="btn_address_reload" Width="70%" />
              </td>
        </tr>
  
      <tr>
             <td >

            </td>
             <td >

                 ที่อยู่สถานที่ :</td>
           <td style="width:25%">

               <asp:TextBox ID="txt_location_address" runat="server" Width="100%" TextMode="MultiLine" Height="47px" Enabled="false"></asp:TextBox>
             </td>
             <td style="width:25%">

                 &nbsp;</td>
        </tr>

          <tr>
             <td style="width:100%;text-align:center;"  colspan="4" >

                 &nbsp;

                 </td>
        </tr>
    </table>

        </asp:Panel>

    <div style="text-align:center;width:100%">

                 <asp:Button ID="Btn_confirm" runat="server" Text="ยืนยันการนัดหมาย"  Width="25%" CssClass="btn-success btn-lg"/>

                 &nbsp;<asp:Button ID="Btn_back" runat="server" Text="ยกเลิก" Width="25%" CssClass="btn-danger btn-lg"  />
    </div> 

         <div class="modal  " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                 <asp:Label ID="lbl_modal" runat="server" Text=""></asp:Label>   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>

</asp:Content>