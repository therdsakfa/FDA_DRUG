<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF_MAIN.Master" CodeBehind="FRM_REPLACEMENT_BOOKING_INSERT.aspx.vb" Inherits="FDA_DRUG.FRM_REPLACEMENT_BOOKING_INSERT" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 25px;
        }
        .auto-style2 {
            width: 25%;
            height: 25px;
        }
    </style>
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

	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
	<script type="text/javascript" src="../jquery.searchabledropdown-1.0.8.min.js"></script>

       <script type="text/javascript">


           $(document).ready(function () {

               $("#ContentPlaceHolder1_ddl_doc").searchable();
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
             <td style="width:25%">

            </td>
             <td style="width:25%">

                 รหัสอ้างอิง :</td>
           <td style="width:25%">

               <asp:TextBox ID="txt_num" runat="server" Width="80%"></asp:TextBox>

               
             
            </td>
             <td style="width:25%">

                 <asp:Button ID="btn_data" runat="server" Text="ตรวจสอบข้อมูล"  Width="80%" CssClass="btn-info"/>

                 <asp:HiddenField ID="hf_SYSTEM_ID" runat="server" />
                 <asp:HiddenField ID="hf_PRICE" runat="server" />

                 </td>
        </tr>
         
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
             <td style="width:25%">

            </td>
             <td >

                 เลขบัตรประชาชนผู้มายื่น :</td>
           <td style="width:25%">

               <asp:TextBox ID="txt_no_visitor" runat="server" Width="80%"></asp:TextBox>

              </td>
             <td style="width:25%">

                 <asp:Button ID="btn_data_txt_no" runat="server" Text="ตรวจสอบข้อมูลเลขบัตรประชาชน"  Width="80%" CssClass="btn-info"/>

                 </td>
        </tr>
             <tr>
             <td >

            </td>
             <td >

                 ชื่อผู้มายื่น :</td>
           <td style="width:25%">

               <asp:Label ID="lbl_name_visitor" runat="server" Text=""></asp:Label>

              </td>
             <td style="width:25%">

                 &nbsp;</td>
        </tr>


      
                    <tr>
             <td >

            </td>
             <td >

                 เบอร์โทรศัพท์ :</td>
           <td style="width:25%">

               <asp:TextBox ID="txt_tel" runat="server" Width="80%"></asp:TextBox>

              </td>
             <td style="width:25%">

                 &nbsp;</td>
        </tr>
                    <tr>
             <td >

            </td>
             <td >

                 E-mail :</td>
           <td style="width:25%">

               <asp:TextBox ID="txt_email" runat="server" Width="80%"></asp:TextBox>

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

               <asp:TextBox ID="txt_remark" runat="server" Width="80%" Height="54px" TextMode="MultiLine"></asp:TextBox>

              </td>
             <td class="auto-style2">

                 </td>
        </tr>

          <tr>
             <td style="width:100%;text-align:center;"  colspan="4" >

                 &nbsp;

                 </td>
        </tr>
     

          <tr>
             <td style="width:100%;text-align:center;"  colspan="4" >

                 &nbsp;

                 </td>
        </tr>
    </table>
    <asp:Panel ID="pn_data"  Width="100%" runat="server" Visible="false">
        <h3 style="text-align:center;" >
            ข้อมูลการขอนัดหมาย
        </h3>

    <table style="width:100%" class="table">
             <tr>
             <td style="width:25%">

            </td>
             <td style="width:25%">

                 Product ID :</td>
           <td style="width:25%">

               <asp:TextBox ID="txt_product_ID" runat="server" Width="80%" Enabled="true"></asp:TextBox>
                 </td>
             <td style="width:25%">

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
             <td style="width:25%">

            </td>
             <td style="width:25%">

                 ชื่อผลิตภัณฑ์ :</td>
           <td style="width:25%">

             <asp:Label ID="lbl_product_name" runat="server" Text=""></asp:Label>
                    </td>
             <td style="width:25%">

                 &nbsp;</td>
        </tr>
          
        <tr>
             <td style="width:25%">

            </td>
             <td style="width:25%">

                 ชื่อผู้ประกอบการ :</td>
           <td style="width:25%">

               <asp:Label ID="lbl_name" runat="server" Text=""></asp:Label>
             </td>
             <td style="width:25%">

                 &nbsp;</td>
        </tr>
            <tr>
             <td >

            </td>
             <td >

                 กระบวนการ :</td>
           <td colspan="2">

               <%--<asp:Label ID="lbl_doc" runat="server"></asp:Label>--%>
               &nbsp;<%--<telerik:RadComboBox ID="rcb_process" Runat="server"  AutoCompleteSeparator="Contains" Filter="Contains" Width="80%">
               </telerik:RadComboBox>--%><asp:DropDownList ID="ddl_process" runat="server" Width="80%"  >
               </asp:DropDownList>
             </td>
           
        </tr>
       <tr>
             <td >

            </td>
             <td >

                 รายการชำระ :</td>
           <td  colspan="2">

               <%--<asp:Label ID="lbl_doc" runat="server"></asp:Label>--%>
               &nbsp;<%--<telerik:RadComboBox ID="rcb_doc" Runat="server"  AutoCompleteSeparator="Contains" Filter="Contains" AllowCustomText="false" Width="80%">
               </telerik:RadComboBox>--%><asp:DropDownList ID="ddl_doc" runat="server" Width="80%"  >
               </asp:DropDownList>
             </td>
            
        </tr>
   
          <tr>
             <td class="auto-style1" >

            </td>
             <td class="auto-style1" >

                 ชื่อสถานที่ :</td>
           <td class="auto-style2">

               <asp:Label ID="lbl_location_name" runat="server"></asp:Label>
              </td>
             <td class="auto-style2">

                 </td>
        </tr>
  
      <tr>
             <td >

            </td>
             <td >

                 ที่อยู่สถานที่ :</td>
           <td style="width:25%">

               <asp:Label ID="lbl_location_address" runat="server"></asp:Label>
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
</asp:Content>
