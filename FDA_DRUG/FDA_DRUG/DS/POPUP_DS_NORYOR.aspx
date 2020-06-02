<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DS_NORYOR.aspx.vb" Inherits="FDA_DRUG.POPUP_DS_NORYOR" %>
<%@ Register src="UC/UC_DS_NORYOR8_DETAIL.ascx" tagname="UC_DS_NORYOR8_DETAIL" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
            <h2>คำขออนุญาตนำหรือสั่งยาตัวอย่างเข้ามาในราชอาณาจักรเพื่อขอขึ้นทะเบียนตำรับยา</h2>
    </div> 

           <asp:Panel ID="Panel1" runat="server" GroupingText="" style="width:100%;">
                    <table class="table" style="width:100%;">
                   
                          <tr>
                            <td>
                                <uc1:UC_DS_NORYOR8_DETAIL ID="UC_DS_NORYOR8_DETAIL1" runat="server" />
                              </td>
                           
                        </tr>
                  <tr>
                      <td>

                          <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" Width="90px" />

                      </td>
                  </tr>
                    </table>
                </asp:Panel>
           
           <asp:Panel ID="Panel2" runat="server" GroupingText="" style="width:100%;">
 <table class="table" style="width:100%;">
     <tr>
         <td>

         </td>
     </tr>
     </table>
            </asp:Panel>


             </div>
   
    
</asp:Content>