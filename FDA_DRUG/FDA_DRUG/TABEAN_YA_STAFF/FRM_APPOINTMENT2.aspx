<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_APPOINTMENT2.aspx.vb" Inherits="FDA_DRUG.FRM_APPOINTMENT2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../Scripts/jquery.searchabledropdown-1.0.7.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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



    <asp:Panel ID="Panel1" runat="server" GroupingText="">
    <table class="table" style="width:100%;">
                   <tr>
                                <td>เลขดำเนินการ</td>
                                <td>
                                    <asp:Label ID="lbl_TR_ID" runat="server" Text="-"></asp:Label>
                                    <br />
                                </td>
                            </tr>
         <tr>
                            <td>ชื่อยาภาษาไทย/ชื่อยาภาษาอังกฤษ</td>
                            <td >
                                <asp:Label ID="lbl_name_drug" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                            <tr>
                            <td>กลุ่มประเภทคำขอ</td>
                            <td >
                                <asp:Label ID="lbl_group_name" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                          <tr>
                            <td>ประเภทคำขอ</td>
                            <td >
                                <asp:Label ID="lbl_type_name" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                            
                        <tr>
                            <td>เลขทะเบียน</td>
                            <td>
                                <asp:Label ID="lbl_rgtno" runat="server" Text="-"></asp:Label>
                            </td>
                   </tr>
                            
                        <tr>
                            <td>วันที่รับเรื่อง</td>
                            <td >
                                <asp:TextBox ID="txt_date" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                               
                                <asp:Label ID="text" runat="server">  (ตัวอย่าง 31/12/2559)</asp:Label>
                               
                            </td>
                        </tr>
                         <tr>
                            <td>เลขนิติบุคคล/เลขบัตรประชาชน</td>
                            <td >
                                <asp:TextBox ID="txt_company" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                                <asp:Button ID="btn_company" runat="server" Text="ตรวจสอบชื่อผู้รับอนุญาต"  CssClass="btn-lg" Width="50%"  />
                            </td>
                        </tr>
                         <tr>
                            <td>ชื่อผู้รับอนุญาต</td>
                            <td >
                                <asp:Label ID="lbl_company" runat="server" ></asp:Label>
                            </td>
                        </tr>
                        
                    
                         <tr>
                            <td>จำนวนวันทำการ</td>
                            <td >
                                <asp:TextBox ID="txt_number" runat="server" CssClass="input-sm" Width="20%"></asp:TextBox>
                                &nbsp;<asp:Button ID="btn_day" runat="server" CssClass="btn-lg" Text="คำนวนวัน" />
                            </td>
                        </tr>
                         <tr>
                            <td>วันที่นัด</td>
                            <td >
                               
                            <asp:Label ID="lbl_number_day" runat="server" ></asp:Label>
                                <asp:HiddenField ID="HiddenField1" runat="server" />
                            </td>
                        </tr>
                        
                    <tr>
                        <td>ระบุผู้รับผิดชอบหลัก</td>
                        <td>
                            <asp:TextBox ID="txt_namestaff_search" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                            <asp:Button ID="btn_search_name" runat="server" CssClass="btn-lg" Text="ค้นหาชื่อ" />
                            <asp:Label ID="lbl_staff_name" runat="server" Text="-"></asp:Label>
                        </td>
                   </tr>
                        
                    <tr>
                        <td>&nbsp;</td>
                        <td>
                            <asp:DropDownList ID="ddl_name" runat="server" DataTextField="fullname2" DataValueField="IDENTITY">
                            </asp:DropDownList>
                            
                        </td>
                   </tr>
                        
                    </table>
        </asp:Panel>
    <div  class="col-lg-8 col-md-8">
                               <%--<p style="text-align:right;padding-right:40%;">--%>
             <center>                                   
            <asp:Button ID="btn_add" runat="server" Text="บันทึก" CssClass="btn-lg"   />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" Text="ยกเลิก" CssClass="btn-lg"   style="display:none;"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 <asp:Button ID="btn_report" runat="server" Text="ดูใบนัด" CssClass="btn-lg"  style="display:none;"  />
            </center>    
                                  
                              <%-- </p>--%>
             
                          </div>
</asp:Content>
