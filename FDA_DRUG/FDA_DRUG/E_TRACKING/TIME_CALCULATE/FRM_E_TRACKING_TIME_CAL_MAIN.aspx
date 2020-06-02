<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_E_Tracking.Master" CodeBehind="FRM_E_TRACKING_TIME_CAL_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_E_TRACKING_TIME_CAL_MAIN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/css_radgrid.css" rel="stylesheet" />
    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <script src="../../Scripts/bootstrap.js"></script>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />

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
             //alert(url);
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
    <table width="100%">
        <tr>
            <td align="right">

                <asp:Button ID="btn_add" runat="server" Text="เพิ่มข้อมูล" CssClass="btn-lg" />
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" 
                    AllowPaging="true" PageSize="10" MasterTableView-AllowFilteringByColumn="true">
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                    SortExpression="IDA" UniqueName="IDA" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="DRUG_NAME" FilterControlAltText="Filter DRUG_NAME column" HeaderText="ชื่อยา"
                                    SortExpression="DRUG_NAME" UniqueName="DRUG_NAME">
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="RCVNO_DISPLAY" FilterControlAltText="Filter RCVNO_DISPLAY column" HeaderText="เลขรับ"
                                    SortExpression="RCVNO_DISPLAY" UniqueName="RCVNO_DISPLAY" DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="START_DATE_COUNT" FilterControlAltText="Filter START_DATE_COUNT column" HeaderText="วันเริ่มนับเวลา"
                                    SortExpression="START_DATE_COUNT" UniqueName="START_DATE_COUNT" DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="END_DATE_COUNT" FilterControlAltText="Filter END_DATE_COUNT column" HeaderText="วันที่อนุญาต"
                                    SortExpression="END_DATE_COUNT" UniqueName="END_DATE_COUNT" DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                                <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="sel" UniqueName="sel" Text="แก้ไข/ดูข้อมูล">

                                </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="print" UniqueName="print" Text="พิมพ์รายงาน">

                                </telerik:GridButtonColumn>
                                <%--<telerik:GridBoundColumn DataField="engdrgtpnm" FilterControlAltText="Filter engdrgtpnm column" HeaderText="วงเล็บ"
                                    SortExpression="engdrgtpnm" UniqueName="engdrgtpnm">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="stat" FilterControlAltText="Filter stat column" HeaderText="สถานะ"
                                    SortExpression="stat" UniqueName="stat">
                                </telerik:GridBoundColumn>
                     
                                <telerik:GridTemplateColumn UniqueName="hp_sel">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">ดู/ปรับสถานะ</asp:HyperLink>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>--%>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
            </td>
        </tr>
    </table>
    
   <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />

    <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>เพิ่มรายงาน </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>