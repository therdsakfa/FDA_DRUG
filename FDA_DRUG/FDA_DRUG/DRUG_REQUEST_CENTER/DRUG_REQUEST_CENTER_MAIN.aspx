<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="DRUG_REQUEST_CENTER_MAIN.aspx.vb" Inherits="FDA_DRUG.DRUG_REQUEST_CENTER_MAIN" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <script type="text/javascript" >
         $(document).ready(function () {
             $('#ContentPlaceHolder1_btn_add').click(function () {
                 Popups('../DRUG_REQUEST_CENTER/DRUG_REQUEST_CENTER_INSERT_V2.aspx');
                 return false;
             });
             $('#ContentPlaceHolder1_btn_add2').click(function () {
                 Popups('../DRUG_REQUEST_CENTER/DRUG_REQUEST_CENTER_C_INSERT.aspx');
                 return false;
             });
             function CloseSpin() {
                 $('#spinner').toggle('slow');
             }
         });
         function Popups(url) { // สำหรับทำ Div Popup

             $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
             var i = $('#f1'); // ID ของ iframe   
             i.attr("src", url); //  url ของ form ที่จะเปิด
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
         function close_modal() { // คำสั่งสั่งปิด PopUp
             $('#myModal').modal('hide');
             $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
         }

         function close_modal2() { // คำสั่งสั่งปิด PopUp
             $('#myModal2').modal('hide');
             $('#ContentPlaceHolder1_btn_reload').click(); // ตัวอย่างให้คำสั่งปุ่มที่ซ่อนอยู่ Click
         }
        </script> 

       <div >
      
           <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4> ออกเลขรับคำร้อง</h4> </div>

         </div>
           <div class="panel panel-body"  style="width:100%;padding-left:5%;">
        <table width="100%">
            <tr>
                <td align="right">
                    <asp:Button ID="btn_add" runat="server" Text="เพิ่มข้อมูลเลขรับคำร้อง" CssClass="btn-lg" />
                    <asp:Button ID="btn_add2" runat="server" Text="เพิ่มข้อมูลเลขตรวจคำขอ" CssClass="btn-lg" />
                </td>

            </tr>
        </table>
        </div>
           
        <div>

            <div class="panel panel-body"  style="width:100%;padding-left:5%;">

                  <br />
           <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0" GridLines="None" PageSize="15">
<MasterTableView autogeneratecolumns="False" datakeynames="IDA">

    <Columns>
       
        <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
             HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
        </telerik:GridBoundColumn>
 
        <telerik:GridBoundColumn DataField="TYPE_REQUEST_NAME" FilterControlAltText="Filter TYPE_REQUEST_NAME column" 
            HeaderText="ประเภทคำขอ" SortExpression="TYPE_REQUEST_NAME" UniqueName="TYPE_REQUEST_NAME" >
        </telerik:GridBoundColumn>
         <telerik:GridBoundColumn DataField="RCVNO_DISPLAY" FilterControlAltText="Filter RCVNO_DISPLAY column" 
            HeaderText="เลขคำร้อง" SortExpression="RCVNO_DISPLAY" UniqueName="RCVNO_DISPLAY" >
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="REQUEST_DATE" FilterControlAltText="Filter REQUEST_DATE column" DataType="System.DateTime" 
            HeaderText="วันที่รับเรื่อง"  SortExpression="REQUEST_DATE" UniqueName="REQUEST_DATE"  DataFormatString="{0:dd/MM/yyyy}"> 
        </telerik:GridBoundColumn>
       <telerik:GridBoundColumn DataField="TRADENAME" FilterControlAltText="Filter TRADENAME column" 
            HeaderText="ชื่อยา" SortExpression="TRADENAME" UniqueName="TRADENAME" >
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="TRADENAME_ENG" FilterControlAltText="Filter TRADENAME_ENG column" 
            HeaderText="ชื่อยาภาษาอังกฤษ" SortExpression="TRADENAME_ENG" UniqueName="TRADENAME_ENG" >
        </telerik:GridBoundColumn>
        <telerik:GridBoundColumn DataField="ALLOW_NAME" FilterControlAltText="Filter ALLOW_NAME column" 
            HeaderText="ชื่อผู้รับอนุญาต" SortExpression="ALLOW_NAME" UniqueName="ALLOW_NAME" >
        </telerik:GridBoundColumn>
              <telerik:GridButtonColumn  ButtonType="LinkButton" UniqueName="select" Display="false"
                        CommandName="sel" Text="ดูข้อมูล" >
                        <HeaderStyle Width="70px" />
   </telerik:GridButtonColumn>
        <telerik:GridButtonColumn  ButtonType="LinkButton" UniqueName="_report" CommandName="_report" Text="ดูข้อมูล" >
                        <HeaderStyle Width="70px" />
              </telerik:GridButtonColumn>
              <telerik:GridButtonColumn  ButtonType="LinkButton" UniqueName="_del" ConfirmText="คุณต้องการที่จะลบข้อมูลนี้?"
                        CommandName="_del" Text="ลบข้อมูล" Display="false">
                        <HeaderStyle Width="70px" />
              </telerik:GridButtonColumn>
    </Columns>
    </MasterTableView>
           </telerik:RadGrid>
           


        </div>

     
    </div>
    
     <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียด<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
             <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"  />

</asp:Content>
