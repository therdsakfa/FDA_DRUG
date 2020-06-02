<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_EXTEND_TIME_LOCATION_MAIN_STAFF.aspx.vb" Inherits="FDA_DRUG.FRM_EXTEND_TIME_LOCATION_MAIN_STAFF" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/css_radgrid.css" rel="stylesheet" />

    



    



    



    

    

    



    



    



    

    <style type="text/css">
        .auto-style1 {
            width: 45%;
        }
        .auto-style2 {
            width: 45%;
        }
        .auto-style3 {
            width: 55%;
            height: 35px;
        }
        .auto-style4 {
            height: 35px;
        }
        .auto-style5 {
            height: 35px;
        }
    </style>

    



    



    



    

    

    



    



    



    

    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../../Content/bootstrap-theme.min.css" rel="stylesheet" />   
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <link href="../../css/style.css" rel="stylesheet" type="text/css" />

    <script src="../../js/jquery-1.8.3.js"></script>
     <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <script src="../../Scripts/bootstrap.min.js"></script>
     <script type="text/javascript" >

         $(document).ready(function () {

             $("#ContentPlaceHolder1_ddl_WORK_GROUP").searchable();
             $("#ContentPlaceHolder1_ddl_category_requests").searchable();

             //$('#ContentPlaceHolder1_btn_add').click(function () {
             //    Popups('../DRUG_REQUEST_CENTER/DRUG_REQUEST_CENTER_INSERT.aspx');
             //    return false;
             //});
             //$('#ContentPlaceHolder1_btn_add2').click(function () {
             //    Popups('../DRUG_REQUEST_CENTER/DRUG_REQUEST_CENTER_C_INSERT.aspx');
             //    return false;
             //});
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
         function closespinner() {
             alert('Download เสร็จสิ้น');
             $('#spinner').fadeOut('slow');
             $('#ContentPlaceHolder1_Button1').click();
         }

         function insert() {
             alert('บันทึกข้อมูลเรียบร้อยแล้ว');
             $('#spinner').fadeOut('slow');
             $('#ContentPlaceHolder1_Button1').click();
         }

        </script> 
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h2>ใบอนุญาตต่ออายุสถานที่ด้านยา</h2>

        </div>

    </div>
    
   <hr />
   <div>
       <table width="100%">
           <tr>
               <td align="center">
                    <table style="width: 100%;" class=" table">
            <%--<tr>
                <td>กลุ่มงาน</td>
                <td Width="70%">
                                <asp:DropDownList ID="ddl_WORK_GROUP" runat="server" AutoPostBack="True" CssClass="input-lg" Width="70%">
                                </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>ประเภทคำขอ</td>
                <td Width="70%">
                                <asp:DropDownList ID="ddl_category_requests" runat="server" CssClass="input-lg" Width="70%">
                                   
                                </asp:DropDownList>
                </td>
            </tr>--%>
            <tr>
                <td class="auto-style3">เลขที่อนุญาต</td>
                <td class="auto-style4" colspan="2" >
                               <asp:Label ID="lbl_lcnno1" runat="server" Text="-"></asp:Label>
                                   
                </td>
            </tr>
            <tr>
                <td class="auto-style1" >ประเภทใบอนุญาต(ค่าจ่ายตามม.44)</td>
                <td class="auto-style2" colspan="2" >
                               <asp:Label ID="lbl_pay_type" runat="server" Text="-"></asp:Label>
                               <%--<asp:DropDownList ID="ddl_search" runat="server" CssClass="btn-lg" Width="70%" AutoPostBack="True">

                               </asp:DropDownList>--%>
                                   
                </td>
            </tr>
            <tr>
                <td class="auto-style1">จำนวนเงินพรบ.</td>
                <td class="auto-style2"  >
                               <%--<asp:DropDownList ID="ddl_search2" runat="server" CssClass="btn-lg" Width="70%"></asp:DropDownList>--%>
                                <asp:Label ID="lbl_price" runat="server" Text="-" CssClass="btn-lg"></asp:Label> 
                </td>
                <td  >
                               บาท</td>
            </tr>
            <tr>
                <td class="auto-style1">จำนวนเงินตามม.44</td>
                <td class="auto-style2">
                               <asp:Label ID="lbl_price44" runat="server" Text="-" CssClass="btn-lg"></asp:Label> 
                                
                </td>
                <td>
                               บาท</td>
            </tr>
            <tr>
                <td class="auto-style1">จำนวนเงินค่าตรวจ GPP</td>
                <td class="auto-style2" >
                            
                                <asp:Label ID="lbl_price45" runat="server" Text="-" CssClass="btn-lg"></asp:Label> 
                                
                </td>
                <td >
                            
                                บาท</td>
            </tr>
            <tr>
                <td class="auto-style1">&nbsp;</td>
                <td class="auto-style2" >
                               <asp:Button ID="Button1" runat="server" Text="ลบค่า GPP" />
                </td>
                <td >
                               &nbsp;</td>
            </tr>
        </table>
               </td>
           </tr>
           <tr>
               <td>

                   &nbsp;</td>
           </tr>
           <br />
           
           <tr>
               <td>

                   <%--*หมายเหตุ (1) วันที่ใช้ไปหมายถึง วันที่รับคำขอจนถึงวันที่คำนวณปัจจุบัน (คำนวณทุกวันศุกร์), (2) วันหยุดเวลาหมายถึง วันที่อยู่ในระหว่างการผ่อนผันของผู้ประกอบการ (3) วันที่แสดงเป็นวันทำการ</td>--%>
           </tr>
           </table>
      
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>ใบอนุญาตต่ออายุสถานที่ด้านยา </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
    <div class=" modal fade" id="myModal2">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>ปรับสถานะ </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f2"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
