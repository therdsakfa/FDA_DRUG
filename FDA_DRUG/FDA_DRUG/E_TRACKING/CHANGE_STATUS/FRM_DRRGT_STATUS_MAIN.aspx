<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/Main_E_Tracking.Master" CodeBehind="FRM_DRRGT_STATUS_MAIN.aspx.vb" Inherits="FDA_DRUG.FRM_DRRGT_STATUS_MAIN" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../css/css_radgrid.css" rel="stylesheet" />
    
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

                <asp:Button ID="Button1" runat="server" Text="Button" Style="display:none;"/>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" 
                    AllowPaging="true" PageSize="10" MasterTableView-AllowFilteringByColumn="true">
                        <%--<ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true">

                        </ClientSettings>
                        <ClientSettings EnableRowHoverStyle="true">
                            <Selecting AllowRowSelect="true" />
                        </ClientSettings>--%>
                        <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                    SortExpression="IDA" UniqueName="IDA" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Newcode" FilterControlAltText="Filter Newcode column" HeaderText="Newcode"
                                    SortExpression="Newcode" UniqueName="Newcode" Display="false">
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="product_name" FilterControlAltText="Filter product_name column" HeaderText="ชื่อผลิตภัณฑ์"
                                    SortExpression="product_name" UniqueName="product_name">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="lcnno_display" FilterControlAltText="Filter lcnno_display column" HeaderText="เลขทะเบียน"
                                    SortExpression="lcnno_display" UniqueName="lcnno_display">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="rgttpcd" FilterControlAltText="Filter rgttpcd column" HeaderText="rgttpcd"
                                    SortExpression="rgttpcd" UniqueName="rgttpcd">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="engdrgtpnm" FilterControlAltText="Filter engdrgtpnm column" HeaderText="วงเล็บ"
                                    SortExpression="engdrgtpnm" UniqueName="engdrgtpnm">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="stat" FilterControlAltText="Filter stat column" HeaderText="สถานะ"
                                    SortExpression="stat" UniqueName="stat">
                                </telerik:GridBoundColumn>
                                <%--<telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="sel"
                                   CommandName="sel" Text="ดู/ปรับสถานะ">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>--%>
                                <telerik:GridTemplateColumn UniqueName="hp_sel">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="HyperLink1" runat="server" Target="_blank">ดู/ปรับสถานะ</asp:HyperLink>
                                    </ItemTemplate>
                                </telerik:GridTemplateColumn>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
            </td>
        </tr>
    </table>
    
   <asp:Button ID="btn_reload" runat="server" Text="reload" Style="display: none" />

    <div class=" modal fade" id="myModal">              
               <div class="panel panel-info" style="width:100%;">
                   <div class="panel-heading  text-center"><h1>ข้อมูลผลิตภัณฑ์ </h1></div>
                   <button type="button" class="btn btn-default pull-right" data-dismiss="modal">ปิดหน้านี้</button>
                   <div class="panel-body">
                             <iframe id="f1"  style="width:100%; height:550px;" ></iframe>
                   </div>
                   <div class="panel-footer"></div>
               </div>       
</div>
</asp:Content>
