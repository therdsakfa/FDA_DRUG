<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_DR_ACCEPT.aspx.vb" Inherits="FDA_DRUG.POPUP_DR_ACCEPT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h1>ระบุเลขรับ</h1>
            </div>
            <div class="panel-body">

                <table class="table">
                    <tr ><td>
                        <p>
                        <span style="padding-left:80px"></span>ผลิตภัณฑ์สมุนไพรที่ได้รับขึ้นทะเบียน หรือรับขึ้นทะเบียนตำรับผลิตภัณฑ์ไปแล้วนั้น <br />
                        หากปรากฏว่ามีรายละเอียดที่ไม่เป็นไปตามหลักเกณฑ์เงื่อนไขที่กำหนต ให้ผู้รับใบสำคัญการขึ้นทะเบียน หรือ <br />
                        รับขึ้นทะเบียนตำรับผลิตภัณฑ์ต้องมาแก้ไขให้ถูกต้องครบถ้วนภายใน ๓๐ วันนับแต่วันที่ได้รับหนังสือจากผู้อนุญาต<br />
                        หากไม่มาดำเนินการสำนักงานคณะกรรมการอาหารและยาจะดำเนินการยกเลิกหรือเพิกถอนใบสำคัญ <br />
                        การขึ้นทะเบียน หรือรับขึ้นทะเบียนตำรับผลิตภัณฑ์
                        </p>
                        
                         </td></tr>

                    <tr ><td align="center">
                        <asp:CheckBox ID="CheckBox1" runat="server" Text="ยอมรับ" />
                        
                         </td></tr>

                   </table>
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="บันทึก" CssClass="btn-lg" />
                  &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ปิดหน้าต่าง"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>
