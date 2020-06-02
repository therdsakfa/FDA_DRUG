<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/MAIN_EDIT.Master" CodeBehind="FRM_EDIT_LCN_LIST.aspx.vb" Inherits="FDA_DRUG.FRM_EDIT_LCN_LIST" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
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
    <div id="spinner" style="background-color: transparent;display:none;">
        <img src="../imgs/spinner.gif" alt="Loading" style="position: absolute; top: 120px; left: 293px; height: 185px; width: 207px;" />
    </div>
    <div>
        <div class="panel-heading panel-title" style="padding-left: 5%;">
            <h2> แก้ไขใบอนุญาตสถานที่</h2>

        </div>

    </div>
    
   <hr />
   <div>
       <br />
       <table width="100%">
           <tr>
               <td>
              <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15">
               <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                   <CommandItemSettings ExportToPdfText="Export to PDF"></CommandItemSettings>

                   <RowIndicatorColumn Visible="True" FilterControlAltText="Filter RowIndicator column">
                       <HeaderStyle Width="20px"></HeaderStyle>
                   </RowIndicatorColumn>

                   <ExpandCollapseColumn Visible="True" FilterControlAltText="Filter ExpandColumn column">
                       <HeaderStyle Width="20px"></HeaderStyle>
                   </ExpandCollapseColumn>

                   <Columns>
                       <telerik:GridBoundColumn DataField="rcvno" FilterControlAltText="Filter rcvno column"
                           HeaderText="เลขรับ" ReadOnly="True" SortExpression="rcvno" UniqueName="rcvno">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="lcnno" FilterControlAltText="Filter lcnno column" HeaderText="เลขที่ใบอนุญาต"
                           SortExpression="lcnno" UniqueName="lcnno" >
                       </telerik:GridBoundColumn>

                       <telerik:GridBoundColumn DataField="thanameplace" FilterControlAltText="Filter thanameplace column"
                           HeaderText="ชื่อสถานที่" SortExpression="thanameplace" UniqueName="thanameplace">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="fulladdr" FilterControlAltText="Filter fulladdr column" HeaderText="ที่อยู่" ReadOnly="True" SortExpression="fulladdr" UniqueName="fulladdr">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                           HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                       </telerik:GridBoundColumn>
                       <telerik:GridBoundColumn DataField="lcntpcd" FilterControlAltText="Filter lcntpcd column"
                           HeaderText="ประเภท" ReadOnly="True" SortExpression="lcntpcd" UniqueName="lcntpcd">
                       </telerik:GridBoundColumn>
                        
                       <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="_edit"
                           CommandName="_edit" Text="แก้ไข">
                           <HeaderStyle Width="70px" />
                       </telerik:GridButtonColumn>
                   </Columns>

                   <EditFormSettings>
                       <EditColumn FilterControlAltText="Filter EditCommandColumn column"></EditColumn>
                   </EditFormSettings>

                   <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>
               </MasterTableView>

               <PagerStyle PageSizeControlType="RadComboBox"></PagerStyle>

               <FilterMenu EnableImageSprites="False"></FilterMenu>
           </telerik:RadGrid>
               </td>
           </tr>
       </table>
        </div>
   <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>แก้ไข </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>