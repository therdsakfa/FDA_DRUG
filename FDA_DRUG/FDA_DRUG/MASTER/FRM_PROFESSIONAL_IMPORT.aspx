<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_PROFESSIONAL_IMPORT.aspx.vb" Inherits="FDA_DRUG.FRM_PROFESSIONAL_IMPORT" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="panel" style="width:100%">

        <div class="panel-heading panel-title">
                <h1>ดึงข้อมูลผู้เชี่ยวชาญ</h1>
            </div>
         <table style="width:100%;" class="table">
             <tr>
                 <td align="right" width="40%">
                     เลขบัตรประชาชน :
                 </td>
                 <td>
                     <asp:TextBox ID="txt_citizen_id_search" runat="server" CssClass="input-sm" Width="300px"></asp:TextBox>
       <asp:Button ID="btn_check" runat="server" Text="ตรวจสอบ" CssClass="btn-lg" Width="120px" />
                 </td>
             </tr>
          </table>
         <asp:Panel ID="Panel1" runat="server">
             <table style="width:100%;" class="table">
        <tr>

            <td align="right" width="40%">
                ชื่อ-นามสกุล :</td>
           <td>
               <asp:TextBox ID="txt_name" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
           </td>
        </tr>
        <%--<tr>

            <td align="right">
                นามสกุล :</td>
           <td>
               <asp:TextBox ID="txt_SURNAME" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
            </td>
        </tr>--%>
     <%--   <tr>

            <td align="right">
                เลขบัตรประชาชน</td>
           <td>
               <asp:TextBox ID="txt_CITIZEN_ID" runat="server" CssClass="input-sm" Width="70%"></asp:TextBox>
            </td>
        </tr>--%>
        </table>
         </asp:Panel>
    

        <div class="panel-footer " style="text-align:center;">
       <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" Width="120px" />
                <asp:Button ID="btn_close" runat="server" Text="ปิดหน้าต่าง" CssClass="btn-lg" Width="120px"/>
        </div>
        </div>

    <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:60%;">
                   <div class="panel-heading  text-center"><h1>ดึงข้อมูลผู้เชี่ยวชาญ </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
