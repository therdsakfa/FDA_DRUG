<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_SEARCH_PERSON.aspx.vb" Inherits="FDA_DRUG.FRM_SEARCH_PERSON" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <script type="text/javascript" >



          $(document).ready(function () {

              function CloseSpin() {
                  $('#spinner').toggle('slow');
              }

              //$('#ContentPlaceHolder1_btn_upload').click(function () {
              //    Popups('POPUP_LCN_TYPE_UPLOAD.aspx');
              //    return false;
              //});

              $('#ContentPlaceHolder1_btn_download').click(function () {
                  Popups('POPUP_LCN_DOWNLOAD.aspx');
                  return false;
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

        </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
     
     <div >
         <div class="panel-heading panel-title" style="padding-left:5%;">
            <h2>ค้นหาข้อมูลบุคคลธรรมดาและนิติบุคคลจากชื่อหรือเลขบัตรประจำตัวประชาชน</h2>
        <h4> <asp:Label ID="lbl_systemID" runat="server" Text=""></asp:Label></h4>
    </div> 

           <asp:Panel ID="Panel1" runat="server" GroupingText="">

      <table class="table" style="width:100%;">
          <tr>
                            <td width="50%">กรอกชื่อ - นามสกุล หรือ<br /> เลขบัตรประจำตัวประชาชน<br /> </td>
                            <td style="margin-left:0px">
                                <asp:TextBox ID="txt_chk_person" runat="server" CssClass="input-lg" style="width:70%;margin-left:0px;" MaxLength="13"></asp:TextBox>
                                <asp:Button ID="btn_chk_bsn" runat="server" Text="ตรวจสอบชื่อผู้ยืนคำร้อง"  CssClass="btn-lg" Width="50%"  />
                            
                                 </td>

                        </tr>

    </table>
               <P>
                   <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                   </telerik:RadScriptManager>
               </P>
               <telerik:RadGrid ID="RadGrid1" runat="server">
                   <MasterTableView AutoGenerateColumns="False" DataKeyNames="ID">
                       <CommandItemSettings ExportToPdfText="Export to PDF" />
                       <RowIndicatorColumn FilterControlAltText="Filter RowIndicator column" Visible="True">
                           <HeaderStyle Width="20px" />
                       </RowIndicatorColumn>
                       <ExpandCollapseColumn FilterControlAltText="Filter ExpandColumn column" Visible="True">
                           <HeaderStyle Width="20px" />
                       </ExpandCollapseColumn>
                       <Columns>
                           <telerik:GridBoundColumn DataField="tha_fullnm" DataType="System.Int32" FilterControlAltText="Filter tha_fullnm column" HeaderStyle-HorizontalAlign="Center" HeaderText="ชื่อ - นามสกุล" ItemStyle-HorizontalAlign="Center" SortExpression="tha_fullnm" UniqueName="tha_fullnm">
                               <ColumnValidationSettings>
                               </ColumnValidationSettings>
                           </telerik:GridBoundColumn>
                           <telerik:GridBoundColumn DataField="identify" DataType="System.Int32" FilterControlAltText="Filter identify column" HeaderStyle-HorizontalAlign="Center" HeaderText="เลขบัตรประชาชน" ItemStyle-HorizontalAlign="Center" SortExpression="identify" UniqueName="identify">
                               <ColumnValidationSettings>
                               </ColumnValidationSettings>
                           </telerik:GridBoundColumn>
                           <telerik:GridBoundColumn DataField="ID" DataType="System.Int32" Display="false" FilterControlAltText="Filter ID column" HeaderText="ID" ReadOnly="True" SortExpression="ID" UniqueName="ID">
                           </telerik:GridBoundColumn>
                           <telerik:GridTemplateColumn>
                               <ItemTemplate>
                                   <asp:Button ID="btn_back" Text="เลือก" CommandName="btn_back" runat="server" />
                                   <%--<asp:HyperLink ID="HyperLink1" runat="server">เลือกข้อมูล</asp:HyperLink>--%>
                               </ItemTemplate>
                           </telerik:GridTemplateColumn>
                       </Columns>
                       <EditFormSettings>
                           <EditColumn FilterControlAltText="Filter EditCommandColumn column">
                           </EditColumn>
                       </EditFormSettings>
                       <PagerStyle PageSizeControlType="RadComboBox" />
                   </MasterTableView>
                   <PagerStyle PageSizeControlType="RadComboBox" />
                   <FilterMenu EnableImageSprites="False">
                   </FilterMenu>
               </telerik:RadGrid>
                 <asp:Button ID="btn_reload" runat="server" Text="Button"  style="display:none" />

               </asp:Panel>
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
</asp:Content>
