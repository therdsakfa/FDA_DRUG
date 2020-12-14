<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="POPUP_NYM_REDIRECT2.aspx.vb" Inherits="FDA_DRUG.POPUP_NYM_REDIRECT2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
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

              //$('#ContentPlaceHolder1_btn_upload').click(function () {
              //    var IDA = getQuerystring("IDA");
              //    var process = getQuerystring("process");
              //    Popups('POPUP_LCN_UPLOAD_ATTACH.aspx?IDA=' & IDA  & '&process=' & process & '');
              //    return false;
              //});
            
              //$('#ContentPlaceHolder1_btn_download').click(function () {
              //    Popups('POPUP_LCN_DOWNLOAD_DRUG.aspx');
              //    return false;
              //});

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
        function Redirect_page() { // คำสั่งสั่งปิด PopUp
              $('#ContentPlaceHolder1_Button1').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
          }
          function Popups2(url) { // สำหรับทำ Div Popup

              $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
              var i = $('#f1'); // ID ของ iframe   
              i.attr("src", url); //  url ของ form ที่จะเปิด
          }
          function Popups3(url) { // สำหรับทำ Div Popup

              $('#myModal3').modal('toggle'); // เป็นคำสั่งเปิดปิด
              var i = $('#f3'); // ID ของ iframe   
              i.attr("src", url); //  url ของ form ที่จะเปิด
          }
          function Popups4(url) { // สำหรับทำ Div Popup

              $('#myModal4').modal('toggle'); // เป็นคำสั่งเปิดปิด
              var i = $('#f4'); // ID ของ iframe   
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
        </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
</html>
