<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_LIST.aspx.vb" Inherits="FDA_DRUG.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">
  .hiddencol
  {
    display: none;
  }
</style>
    <script type="text/javascript" >
        var abc = 0.00;
        var count_row = 0;
        //$(document).ready(function () {
        //    $('#ContentPlaceHolder1_gv tr').click(function (e) { //อันนี้เป็น Event ว่ามีการกด Click ที่ Row หรือป่าว

        //        var k = $(this);
        //        var IDA = k.context.cells[7].textContent;
        //        // alert(IDA)
        //        var val1 = k.context.cells[4].textContent; //ดึงค่าออกมาว่าจะเอา column ไหน ตัวอย่างคือ cell 1
        //        var val2 = k.context.cells[5].textContent;  //ดึงค่าออกมาว่าจะเอา column ไหน ตัวอย่างคือ cell 2
        //        //alert('[' + IDA + '][' + val2 + ']');

        //        Popups(IDA, val1, val2); // ในส่วนนี้เป็นตัวอย่างกดแล้วเป็น Div popup ถ้าจะเล่นก็ปลดคำสั่ง mark ออกเอง

        //    })

        //});
        //$('#ContentPlaceHolder1_Button2').click(function () {
        //    //event.preventDefault();
        //    $('#spinner').fadeIn('slow');
        //    //$.ajax({
        //    //    type: 'POST',
        //    //    data: { submit: true },
        //    //    success: function (result) {

        //    //        $('#spinner').toggle('slow');

        //    //    }
        //    //});

        //});

        //$('#ContentPlaceHolder1_Button1').click(function () {
        //    //event.preventDefault();

        //    $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
        //    var i = $('#f1'); // ID ของ iframe   
        //    i.attr("src", 'TestLoading.aspx?IDA=1'); //  url ของ form ที่จะเปิด

        //    return false;
        //});

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

        function Popups(IDA, TR_ID, process_type) { // สำหรับทำ Div Popup
            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            if (process_type == 'สบ.5')
            { process_type = '5'; }
            if (process_type == 'สบ.3')
            { process_type = '3'; }
            if (process_type == 'ใบอนุญาตสถานที่')
            { process_type = '1'; }
            if (process_type == 'สบ.5 reprocess')
            { process_type = '6'; }
            if (process_type == 'ทะเบียนตำรับ')
            { process_type = '7'; }
            // alert(IDA + " / " + TR_ID + " / " + process_tpye);
            //alert('POPUP_CHECK_TYPE.aspx?TR_ID=' + TR_ID);
            //alert('POPUP_CHECK_TYPE.aspx?TR_ID=' + TR_ID + '&process_type=' + process_type + '&IDA=' + IDA);
            i.attr("src", 'POPUP_CHECK_TYPE.aspx?TR_ID=' + TR_ID + '&process_type=' + process_type + '&IDA=' + IDA); //  url ของ form ที่จะเปิด
            //     i.attr("src", '../test.aspx'); //  url ของ form ที่จะเปิด
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Button ID="btn_reload" runat="server" Text="reload" style="display:none;" />
     
      <div class="panel-heading panel-title" style="padding-left:5%;">
            <h2>รายการคำขออนุญาต
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </h2>
        <h4> <asp:Label ID="lbl_systemID" runat="server" Text=""></asp:Label></h4>
    </div> 
        <hr />
       <div >

 <asp:GridView ID="gv" Width="100%" CssClass="table" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" AllowPaging="True" PageSize="50">
    
     <AlternatingRowStyle BackColor="White" />
     <Columns>
         <asp:BoundField HeaderText="เลขใบอนุญาต" DataField="lcnno" />
       <asp:BoundField HeaderText="เลขรับ" DataField="rcvno" />
         <asp:BoundField HeaderText="ชื่อผลิตภัณฑ์" DataField="prdnmt" />
         <asp:BoundField HeaderText="ชื่อบริษัท" DataField="thanm" />
        
          <asp:BoundField HeaderText="เลขTransection" DataField="ID"  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol" />
         <asp:BoundField HeaderText="ประเภท" DataField="PROCESS_NAME"   InsertVisible="false" />
          <asp:BoundField HeaderText="วันที่ยื่นคำขอ" DataField="rcvdate"   DataFormatString="{0:d}"  InsertVisible="false" />
         <asp:BoundField HeaderText="IDA" DataField="IDA"  HeaderStyle-CssClass="hiddencol" ItemStyle-CssClass="hiddencol"  />
             <asp:BoundField HeaderText="สถานะ" DataField="STATUS_NAME"   />

                  <asp:TemplateField >
                    <ItemTemplate>
                        <asp:Button ID="btn_lcn" runat="server" Text="เลือกข้อมูล" CommandName="lcn" Width="100%" CssClass="btn-link" CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />

                    </ItemTemplate>

                    <ItemStyle Width="10%"></ItemStyle>
                </asp:TemplateField>

     </Columns>
           <EditRowStyle BackColor="#2461BF" />
     <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
     <HeaderStyle BackColor="#8cb340" Font-Bold="True" ForeColor="White" />
     <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
     <RowStyle BackColor="#EFF3FB" />
     <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
     <SortedAscendingCellStyle BackColor="#F5F7FB" />
     <SortedAscendingHeaderStyle BackColor="#6D95E1" />
     <SortedDescendingCellStyle BackColor="#E9EBEF" />
     <SortedDescendingHeaderStyle BackColor="#4870BE" />
           </asp:GridView>
       </div>
       
    </div>
<div class=" modal fade" id="myModal">
 
  
    
                              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" >
         </iframe>

                   </div>
                   <div class="panel-footer"></div>
               </div>       
  

                
       


    

</div>
</asp:Content>