<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_STAFF.Master" CodeBehind="FRM_LIST.aspx.vb" Inherits="FDA_DRUG.WebForm33" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript" >
        var abc = 0.00;
        var count_row = 0;
        $(document).ready(function () {
            $('#ContentPlaceHolder1_gv tr').click(function (e) { //อันนี้เป็น Event ว่ามีการกด Click ที่ Row หรือป่าว

                var k = $(this);
                var val1 = k.context.cells[2].textContent; //ดึงค่าออกมาว่าจะเอา column ไหน ตัวอย่างคือ cell 1
                var val2 = k.context.cells[3].textContent;  //ดึงค่าออกมาว่าจะเอา column ไหน ตัวอย่างคือ cell 2
                //alert('[' + val1 + '][' + val2 + ']');
                Popups(val1, val2); // ในส่วนนี้เป็นตัวอย่างกดแล้วเป็น Div popup ถ้าจะเล่นก็ปลดคำสั่ง mark ออกเอง

            })

        });
        $('#ContentPlaceHolder1_Button2').click(function () {
            //event.preventDefault();
            $('#spinner').fadeIn('slow');
            //$.ajax({
            //    type: 'POST',
            //    data: { submit: true },
            //    success: function (result) {

            //        $('#spinner').toggle('slow');

            //    }
            //});

        });

        $('#ContentPlaceHolder1_Button1').click(function () {
            //event.preventDefault();



            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            i.attr("src", 'TestLoading.aspx?IDA=1'); //  url ของ form ที่จะเปิด

            return false;
        });



        function Popups(ID, process_tpye) { // สำหรับทำ Div Popup
            $('#myModal').modal('toggle'); // เป็นคำสั่งเปิดปิด
            var i = $('#f1'); // ID ของ iframe   
            if (process_tpye = '41')
            { process_tpye = '41'; }
            if (process_tpye = 'สบ.3')
            { process_tpye = '3'; }
            if (process_tpye = 'ใบอนุญาตสถานที่')
            { process_tpye = '1'; }
            i.attr("src", 'POPUP_CHECK_TYPE.aspx?ID=' + ID + '&process_tpye=' + process_tpye); //  url ของ form ที่จะเปิด
            //     i.attr("src", '../test.aspx'); //  url ของ form ที่จะเปิด
            return false;
        }
    </script>
    <div>

     
      <div class="panel-heading panel-title" style="padding-left:5%;">
            <h2>รายการคำขออนุญาต</h2>
        <h4> <asp:Label ID="lbl_systemID" runat="server" Text=""></asp:Label></h4>
    </div> 
        <hr />
       <div style="padding:0 5% 0 5%;">

 <asp:GridView ID="gv" Width="100%" CssClass="table" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
    
     <AlternatingRowStyle BackColor="White" />
     <Columns>
         <asp:BoundField HeaderText="เลขใบอนุญาต" DataField="lcnno" />
         <%--<asp:BoundField HeaderText="เลขสารบบ" DataField="fdpdtno" />--%>
         <%--<asp:BoundField HeaderText="ชื่อผลิตภัณฑ์" DataField="prdnmt" />--%>
         <%--<asp:BoundField HeaderText="ชื่อบริษัท" DataField="thanm" />--%>
         
          <asp:BoundField HeaderText="เลขรับ" DataField="rcvno" />
          <asp:BoundField HeaderText="เลขTransection" DataField="ID"  InsertVisible="false" />
         <%--<asp:BoundField HeaderText="ประเภท" DataField="PROCESS_NAME"   InsertVisible="false" />--%>
         <asp:BoundField HeaderText="ประเภท" DataField="PROCESS_ID"   InsertVisible="false" />
          <asp:BoundField HeaderText="วันที่ยื่นคำขอ" DataField="rcvdate"   DataFormatString="{0:d}"  InsertVisible="false" />
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


      <div  class="modal fade "  id="myModal">
             <div class="panel panel-info" style="width:100%">
                 <div class="panel-heading">
      <div class="modal-title text-center h1 " >รายละเอียด<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                 </div>
    <div class="panel-body panel-info" style="width:100%">
   
           <iframe id="f1"  style="width:100%;  height:600px;" >
          </iframe>
        
        </div>
</div>
                 </div>
              </div>

<%--           <div class="modal fade" id="myModal">
  <div class="modal-dialog " style="width:100%;">
    <div class="modal-content " style="height:700px">
      <div class="modal-body " style="width:100%; height:650px;">
             <div class="modal-title text-center h1 " >รายละเอียด<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>

   </div>
          <iframe id="f1"  style="width:100%;  height:600px;" >
          </iframe>
   </div>
    
    </div>
  </div>
</div>
              --%>  
       


</asp:Content>
