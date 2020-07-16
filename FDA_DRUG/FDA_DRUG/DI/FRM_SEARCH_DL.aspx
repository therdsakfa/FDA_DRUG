<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_Empty.Master" CodeBehind="FRM_SEARCH_DL.aspx.vb" Inherits="FDA_DRUG.FRM_SEARCH_DL" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        </script> 

     <div id="spinner" style=" background-color:transparent; display:none; " >
  <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
</div>
       <div class="h3" style="padding-left:5%;">  
       </div>
    
     <div class="panel" style="text-align:left ;width:100%">
         <div  style="height:70px" > 
            
              <div  class="col-lg-4 col-md-4"><h4> &nbsp;</h4> </div>
                          <div  class="col-lg-8 col-md-8">
                              <table style="width:100%;">
                                  <tr>
                                      <td style="width:15%;">

                                      </td>
                                      <td style="width:25%;">
                                          โปรดเลือกเลขบัญชีรายการยา
                                      </td>
                                      <td style="width:35%;">
                                          <%--<asp:DropDownList ID="ddl_search" runat="server" CssClass="btn-lg" Width="80%"></asp:DropDownList>--%>
                                          <telerik:RadComboBox ID="rcb_search" Runat="server" Width="80%" Filter="Contains">
                             </telerik:RadComboBox>
                                      </td>
                                       <td  style="width:25%;">
                                           <asp:Button ID="btn_search" runat="server" Text="เลือก" CssClass="btn-lg" />
                                      </td>
                                       
                                  </tr>
                              </table>
                                   
                               <p style="text-align:right;padding-right:5%;">

        &nbsp;&nbsp;
                                  

                                     <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"   />
                                     <asp:Button ID="Button1" runat="server" Text="" style="display:none;"  />
        </p>
                          </div>

         </div>
    <div class="panel panel-body"  style="width:100%;padding-left:5%;">
                
                      <div class="h5" style="padding-left:87%;">  
                      <asp:HyperLink ID="hl_pay" runat="server"  target="_blank" style="display:none;"> ชำระเงินคลิกที่นี้</asp:HyperLink>
                        </div>
                               
    </div>
   

          <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียด ใบอนุญาต<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>

</asp:Content>
