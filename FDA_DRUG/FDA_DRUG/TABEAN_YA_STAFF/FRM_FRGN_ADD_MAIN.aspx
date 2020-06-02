<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_FRGN_ADD_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_FRGN_ADD_MAIN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <script type="text/javascript" >
     $(document).ready(function () {
         $(window).load(function () {
             $.ajax({
                 type: 'POST',
                 data: { submit: true },
                 success: function (result) {
                     // $('#spinner').fadeOut('slow');
                 }
             });
         });

         function CloseSpin() {
             $('#spinner').toggle('slow');
         }


         $('#ContentPlaceHolder1_btn_download_t').click(function () {
             $('#spinner').fadeIn('slow');

         });

         //$('#ContentPlaceHolder1_btn_upload_ex').click(function () {

         //    //  $('#spinner').toggle('slow');
         //    Popups('../DS/POPUP_DS_UPLOAD.aspx');
         //    return false;
         //});

         $('#ContentPlaceHolder1_btn_download_ex').click(function () {
             $('#spinner').fadeIn('slow');

         });
         function Popups(url) { // สำหรับทำ Div Popup
             $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
             var i = $('#f1'); // ID ของ iframe   
             i.attr("src", url); //  url ของ form ที่จะเปิด
         }


     });

     function Popups2(url) { // สำหรับทำ Div Popup
         $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
         var i = $('#f1'); // ID ของ iframe   
         i.attr("src", url); //  url ของ form ที่จะเปิด
     }
     function close_modal() { // คำสั่งสั่งปิด PopUp
         $('#myModal').modal('hide');
         $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
     }
     function spin_space() { // คำสั่งสั่งปิด PopUp
         //    alert('123456');
         $('#spinner').toggle('slow');
         //$('#myModal').modal('hide');
         //$('#ContentPlaceHolder1_Button2').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
     }
     function closespinner() {
         $('#spinner').fadeOut('slow');
         alert('Download Success');
         $('#ContentPlaceHolder1_Button1').click();

     }
        </script> 
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div>
        <div >
            <h2> เพิ่มผู้ผลิตต่างประเทศ</h2>
            <asp:Button ID="btn_reload" runat="server" Text="Button" style="display:none;" />
          <%--  License number : 
            <asp:Label ID="lbl_lcnno" runat="server" Text=""></asp:Label>--%>
        </div>


        
    </div>
    <br />

    <br />

   <div>

       <fieldset>
           <table class="table" style="width: 100%;">
               <tr>
            <td align="center">
                <table width="60%">
                    <tr>
                        <td>ชื่อผู้ผลิตต่างประเทศ : 
                            <asp:TextBox ID="txt_search" runat="server" CssClass="input-lg" Width="300px"></asp:TextBox>
                        </td>
                        <td>
                            <table style="width: 100%;">
                                <tr>
                                    <td>
<asp:Button ID="btn_search" runat="server" Text="ค้นหา" CssClass="input-lg" />
                                    </td>
                                    <td>
<asp:Button ID="btn_add_frgn" runat="server" Text="เพิ่มผู้ผลิตรายใหม่" CssClass="input-lg" />
                                    </td>
                                </tr>
                            </table>
                            

                            
                        </td>
                    </tr>
                </table>
               
             
                
                <asp:HiddenField ID="HiddenField1" runat="server" />
            </td>
        </tr>
               <tr>
                   <td>
                       <telerik:radgrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="frgncd" DataType="System.Int32" FilterControlAltText="Filter frgncd column" HeaderText="frgncd"
                           SortExpression="frgncd" UniqueName="frgncd" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="engfrgnnm" FilterControlAltText="Filter engfrgnnm column"
                           HeaderText="ชื่อผู้ผลิตต่างประเทศ (ภาษาอังกฤษ)" SortExpression="engfrgnnm" UniqueName="engfrgnnm">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="thafrgnnm" FilterControlAltText="Filter thafrgnnm column"
                           HeaderText="ชื่อผู้ผลิตต่างประเทศ (ภาษาไทย)" SortExpression="thafrgnnm" UniqueName="thafrgnnm">
                       </telerik:GridBoundColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_sel"
                           CommandName="sel" Text="เลือก">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                   </Columns>
               </MasterTableView>
           </telerik:radgrid>
                   </td>
               </tr>


           </table>
       </fieldset>
<br /> <br />
 <table class="table" style="width: 100%;">
     <tr>
         <td align="right">
             <asp:Button ID="btn_add" runat="server" Text="เพิ่มที่อยู่ใหม่" CssClass="btn-lg" style="display:none;"/>
         </td>
     </tr>
               <tr>
                   <td>
                       <telerik:radgrid ID="RadGrid2" runat="server" AllowPaging="true" PageSize="30" AllowFilteringByColumn="True">
               <MasterTableView AutoGenerateColumns="False">
                   <Columns>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                           SortExpression="IDA" UniqueName="IDA" Display="false" AllowFiltering="true">
                       </telerik:GridBoundColumn>
                        <telerik:GridBoundColumn DataField="fulladdr2" FilterControlAltText="Filter fulladdr2 column"
                           HeaderText="ที่อยู่" SortExpression="fulladdr2" UniqueName="fulladdr2">
                       </telerik:GridBoundColumn>
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="btn_edit"
                           CommandName="_edit" Text="แก้ไข">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                   </Columns>
               </MasterTableView>
           </telerik:radgrid>
                   </td>
               </tr>


           </table>

      
              <div style="text-align:center;"> 
                  <asp:Button ID="btn_back" runat="server" Width="10%" Text="กลับ" Visible="false"  CssClass="btn-lg btn-info"  style="display:none;" /> 
              </div>  
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>
                       <asp:Label ID="lbl_titlename" runat="server" Text=""></asp:Label></h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal" onclick="close_modal();">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
