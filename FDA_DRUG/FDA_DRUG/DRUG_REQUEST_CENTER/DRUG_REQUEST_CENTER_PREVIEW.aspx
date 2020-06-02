<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="DRUG_REQUEST_CENTER_PREVIEW.aspx.vb" Inherits="FDA_DRUG.DRUG_REQUEST_CENTER_PREVIEW" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 618px;
        }
        </style>
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
            <h2>ออกเลขรับคำรอง</h2>
        <h4> <asp:Label ID="lbl_systemID" runat="server" Text=""></asp:Label></h4>
    </div> 

           <asp:Panel ID="Panel1" runat="server" GroupingText="">
                    <table class="table" style="width:100%;">
                   
                          <tr>
                            <td>ประเภทคำขอ</td>
                            <td class="auto-style1">
                                <asp:Label ID="lbl_request_type" runat="server" Text="-"></asp:Label>
                            </td>
                        </tr>
                         
                        <tr>
                            <td>เลขที่ใบอนุญาต</td>
                            <td >
                                <asp:TextBox ID="txt_lcnno" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                                </td>
                        </tr>

                          <tr>
                              <td>เลขรับคำร้อง</td>
                              <td>
                                  <asp:TextBox ID="txt_r_no" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                              </td>
                          </tr>

                        <tr>
                            <td>วันที่รับเรื่อง</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txt_date" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                               
                            </td>
                        </tr>
                          <tr>
                              <td>เลขบัตรประชาชนผู้ยื่น</td>
                              <td class="auto-style1">
                                  <asp:TextBox ID="txt_citizen_id" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                              </td>
                          </tr>
                          <tr>
                              <td>ชื่อผู้ยื่น</td>
                              <td class="auto-style1">
                                  <asp:Label ID="lbl_request_name" runat="server"></asp:Label>
                              </td>
                          </tr>
                         <tr>
                            <td>เลขนิติบุคคล/เลขบัตรประชาชน</td>
                            <td class="auto-style1">
                                <asp:TextBox ID="txt_company" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                                <asp:DropDownList ID="DropDownList1" runat="server" DataTextField="IOWA" DataValueField="IDA" CssClass="input-lg" Width="70%" style="display:none;">
                                </asp:DropDownList>
                            </td>
                        </tr>
                         <tr>
                            <td>ชื่อผู้รับอนุญาต</td>
                            <td class="auto-style1">
                                
                                <asp:DropDownList ID="DropDownList4" runat="server" DataTextField="IOWA" DataValueField="IDA" CssClass="input-lg" Width="70%" style="display:none;">
                                </asp:DropDownList>
                                <asp:Label ID="lbl_company" runat="server" ></asp:Label>
                            </td>
                        </tr>
                         <tr>
                            <td>ชื่อสถานที่</td>
                            <td class="auto-style1">
                               
                                <asp:Label ID="lbl_placename" runat="server" Text="-"></asp:Label>

                            </td>
                        </tr>
                         <tr>
                            <td>ชื่อยาภาษาไทย</td>
                            <td >
                                <asp:TextBox ID="txt_DRUG_NAME_THAI" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                            </td>
                        </tr>
                         <tr>
                            <td>ชื่อยาภาษาอังกฤษ</td>
                            <td >
                                <asp:TextBox ID="txt_DRUG_NAME_ENG" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    
                    
                </asp:Panel>

        <div style="text-align:center;">

            <%--<asp:Label ID="Label1" runat="server" CssClass="badge" Text="" vi Font-Size="XX-Large"></asp:Label>--%>
        </div>
             </div>
   
    
</asp:Content>
