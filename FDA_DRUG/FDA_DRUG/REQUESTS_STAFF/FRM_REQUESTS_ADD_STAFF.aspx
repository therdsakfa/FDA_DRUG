<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_REQUESTS_ADD_STAFF.aspx.vb" Inherits="FDA_DRUG.FRM_REQUESTS_ADD_STAFF" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        .auto-style1 {
            height: 71px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
     <script type="text/javascript" >

         $(document).ready(function () {
             $("#ContentPlaceHolder1_ddl_WORK_GROUP").searchable();
             $("#ContentPlaceHolder1_ddl_category_requests").searchable();

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



       <div >
         <div class="panel-heading panel-title" style="padding-left:5%;">
            <h2>ใบนัดรับผลพิจารณาคำขอ</h2>
        <h4> <asp:Label ID="lbl_systemID" runat="server" Text=""></asp:Label></h4>
    </div> 

           <asp:Panel ID="Panel1" runat="server" GroupingText="">
                    <table class="table" style="width:100%;">
                   
                        <%--    <tr>
                            <td>เจ้าหน้าที่ผู้รับผิดชอบ</td>
                            <td >
                                <asp:DropDownList ID="ddl_WORK_GROUP" runat="server" CssClass="input-lg" Width="70%" AutoPostBack="True">
                                    <asp:ListItem Selected="True" Value="1">กลุ่มงานใบอนุญาต</asp:ListItem>
                                    <asp:ListItem  Value="2">กลุ่มงานโฆษณา</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>--%>
                        <tr>
                            <td>กลุ่มงาน</td>
                            <td >
                                <asp:DropDownList ID="ddl_WORK_GROUP" runat="server" AutoPostBack="True" CssClass="input-lg" Width="70%">
                                </asp:DropDownList>
                            </td>
                        </tr>
                          <tr>
                            <td >ประเภทคำขอ</td>
                            <td >
                                <asp:DropDownList ID="ddl_category_requests" runat="server" CssClass="input-lg" Width="70%" AutoPostBack="True">
                                    <asp:ListItem Value="1">คำขอจดทะเบียนสถานประกอบการผลิต</asp:ListItem>
                                    <asp:ListItem Value="2">คำขอจดทะเบียนสถานประกอบการนำเข้า</asp:ListItem>
                                    <asp:ListItem Value="3">คำขอจดทะเบียนสถานที่ขาย</asp:ListItem>

                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td >ชื่อย่อประเภทคำขอ</td>
                            <td >
                                <asp:TextBox ID="txt_SUB_TYPE_REQUESTS" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td >เลขที่ใบอนุญาต</td>
                            <td >
                                <asp:TextBox ID="txt_lcnno" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                                (เฉพาะคำขอแก้ไข)</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">วันที่รับเรื่อง</td>
                            <td class="auto-style1" >
                                <asp:TextBox ID="txt_date" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                               
                                <asp:Label ID="Label1" runat="server">  (ตัวอย่าง 31/12/2559)</asp:Label>
                               
                            </td>
                        </tr>
                        <tr>
                            <td >เลขนิติบุคคล/เลขบัตรประชาชน</td>
                            <td >
                                <asp:TextBox ID="txt_company" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                                <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="IOWA" DataValueField="IDA" CssClass="input-lg" Width="70%" style="display:none;">
                                </asp:DropDownList>
                                <asp:Button ID="btn_company" runat="server" Text="ตรวจสอบชื่อผู้รับอนุญาต"  CssClass="btn-lg" Width="50%"  />
                            </td>
                        </tr>
                        <tr>
                            <td >ชื่อผู้รับอนุญาต</td>
                            <td >
                                
                                <asp:DropDownList ID="DropDownList4" runat="server" DataTextField="IOWA" DataValueField="IDA" CssClass="input-lg" Width="70%" style="display:none;">
                                </asp:DropDownList>
                                <asp:Label ID="lbl_company" runat="server" ></asp:Label>
                            </td>
                        </tr>
                         <%--<tr>
                            <td >ชื่อผู้ขอรับบริการ</td>
                            <td >
                                <asp:TextBox ID="txt_name_company" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                            </td>
                        </tr--%>
                        <caption>
                            &gt;
                            <tr>
                                <td>ชื่อการค้า (ไทย)</td>
                                <td>
                                    <asp:TextBox ID="txt_thainame" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                                    (เฉพาะคำขอแก้ไข)</td>
                            </tr>
                            <tr>
                                <td>ชื่อการค้า (อังกฤษ)</td>
                                <td>
                                    <asp:TextBox ID="txt_engname" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                                    <asp:Label ID="text" runat="server">  (ตัวอย่าง 31/12/2559)</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>เจ้าหน้าที่ผู้รับคำขอ</td>
                                <td>
                                    <h4>
                                        <asp:Label ID="lbl_authorities_responsible" runat="server" Text=""></asp:Label>
                                    </h4>
                                </td>
                            </tr>
                            <%--<tr>
                            <td >เจ้าหน้าที่ผู้พิจารณา</td>
                            <td >
                                <asp:TextBox ID="txt_admin_appv" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                            </td>
                        </tr>
                    --%>
                            <tr>
                                <td>จำนวนวันทำการ</td>
                                <td>
                                    <asp:TextBox ID="txt_number" runat="server" CssClass="input-sm" Width="20%"></asp:TextBox>
                                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="input-lg" DataTextField="IOWA" DataValueField="IDA" style="display:none;" Width="300px">
                                    </asp:DropDownList>
                                    &nbsp;<asp:Button ID="btn_day" runat="server" CssClass="btn-lg" Text="คำนวนวัน" />
                                </td>
                            </tr>
                            <tr>
                                <td>วันที่กำหนดแล้วเสร็จ</td>
                                <td>
                                    <asp:Label ID="lbl_number_day" runat="server"></asp:Label>
                                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="input-lg" DataTextField="IOWA" DataValueField="IDA" style="display:none;" Width="300px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>ชื่อยาภาษาไทย</td>
                                <td>
                                    <asp:TextBox ID="txt_DRUG_NAME_THAI" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>ชื่อยาภาษาอังกฤษ</td>
                                <td>
                                    <asp:TextBox ID="txt_DRUG_NAME_ENG" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                                </td>
                            </tr>
                        </caption>
                    </table>
                    
                    
                </asp:Panel>

           <div  class="col-lg-8 col-md-8">
                               <p style="text-align:right;padding-right:40%;">
                                                    
            <asp:Button ID="btn_add" runat="server" Text="บันทึก" CssClass="btn-lg"   />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="ยกเลิก" CssClass="btn-lg"   />
            
                                  
                               </p>
             
                          </div>
        <div style="text-align:center;">

            <%--<asp:Label ID="Label1" runat="server" CssClass="badge" Text="" vi Font-Size="XX-Large"></asp:Label>--%>
        </div>
             </div>
   
    
</asp:Content>
