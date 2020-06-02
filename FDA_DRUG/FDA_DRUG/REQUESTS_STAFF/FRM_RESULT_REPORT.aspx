<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_RESULT_REPORT.aspx.vb" Inherits="FDA_DRUG.FRM_RESULT_REPORT" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

       <div >
      
           <div class="panel-heading panel-title" style="height:70px" > 
            
             <div  class="col-lg-4 col-md-4"><h4> รายงานสรุป</h4> </div>

         </div>
           
        <div style="text-align:center;">
            <telerik:RadScriptManager ID="RadScriptManager1" runat="server"></telerik:RadScriptManager>
            <%--<asp:Label ID="Label1" runat="server" CssClass="badge" Text="" vi Font-Size="XX-Large"></asp:Label>--%>
           
              <div class="panel panel-body"  style="width:100%;">

                  <table >
                      <tr>
                            <td>วันที่ออกเลขระหว่าง</td>
                            <td align="left">
                                <asp:TextBox ID="txt_date" runat="server"></asp:TextBox>
                            </td>
                            <td align="left">
                                และ</td>
                            <td align="left">
                                <asp:TextBox ID="txt_dateend" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btn_filter" runat="server" Text="ค้นหา" />
                                <asp:Button ID="btn_export" runat="server" Text="EXPORT" /></td>
                            <td ></td>
                      </tr>
                  </table>
                  <br />
                  <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="True" CellSpacing="0" GridLines="None" PageSize="15" Width="100%">
                      <MasterTableView AutoGenerateColumns="False" DataKeyNames="IDA">
                          <Columns>

                              <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column"
                                  HeaderText="IDA" ReadOnly="True" SortExpression="IDA" UniqueName="IDA" Display="false">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="R_NO" HeaderText="เลขรับคำขอ" SortExpression="R_NO" UniqueName="R_NO">
                              </telerik:GridBoundColumn>

                              <telerik:GridBoundColumn DataField="C_NO" HeaderText="เลขตรวจคำขอ" SortExpression="C_NO" UniqueName="C_NO">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="A_NO" HeaderText="เลขรับประเมินคำขอ" SortExpression="A_NO" UniqueName="A_NO">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="TYPE_REQUESTS" HeaderText="เลข Process ID" SortExpression="TYPE_REQUESTS" UniqueName="TYPE_REQUESTS">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="REQUESTS_DATE" DataType="System.DateTime"
                                  HeaderText="วันที่ออกเลข" SortExpression="REQUESTS_DATE" UniqueName="REQUESTS_DATE" DataFormatString="{0:d/M/yyyy}">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="CONREQ_LAST_UPDATE" DataType="System.DateTime"
                                  HeaderText="วันที่ครบกำหนด" SortExpression="CONREQ_LAST_UPDATE" UniqueName="CONREQ_LAST_UPDATE" DataFormatString="{0:d/M/yyyy}">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="TYPE_REQUESTS_NAME" HeaderText="ชื่อกระบวนงาน" SortExpression="TYPE_REQUESTS_NAME" UniqueName="TYPE_REQUESTS_NAME">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="DOCUMENT_TYPE_NAME" HeaderText="ค่าใช้จ่าย" SortExpression="DOCUMENT_TYPE_NAME" UniqueName="DOCUMENT_TYPE_NAME" HeaderStyle-Width="200px">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="REF_NO" HeaderText="รหัสอ้างอิง" SortExpression="REF_NO" UniqueName="REF_NO">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="PRICE" HeaderText="จำนวนเงิน" SortExpression="PRICE" UniqueName="PRICE" DataFormatString="{0:###,###.##}">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="ALLOW_NAME" HeaderText="ชื่อผู้รับอนุญาต" SortExpression="ALLOW_NAME" UniqueName="ALLOW_NAME">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="NAME_REQUEST" HeaderText="ผู้ติดต่อ" SortExpression="NAME_REQUEST" UniqueName="NAME_REQUEST">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="EMAIL_EGA" HeaderText="E-MAil" SortExpression="EMAIL_EGA" UniqueName="EMAIL_EGA">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="WORK_GROUP" HeaderText="กลุ่มงานที่รับผิดชอบ" SortExpression="WORK_GROUP" UniqueName="WORK_GROUP">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="FDA_STATUS" HeaderText="ช่วงสถานะล่าสุด" SortExpression="FDA_STATUS" UniqueName="FDA_STATUS">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="START_DATE" DataType="System.DateTime"
                                  HeaderText="วันที่ของช่วงล่าสุด" SortExpression="START_DATE" UniqueName="START_DATE" DataFormatString="{0:d/M/yyyy}">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="SUB_STATUS" HeaderText="ผลการพิจารณา" SortExpression="SUB_STATUS" UniqueName="SUB_STATUS">
                              </telerik:GridBoundColumn>
                              <telerik:GridBoundColumn DataField="stop_days" HeaderText="จำนวนวันหยุดเวลา" SortExpression="stop_days" UniqueName="stop_days">
                              </telerik:GridBoundColumn>
                          </Columns>

                      </MasterTableView>

                  </telerik:RadGrid>
           


        </div>

     
    </div>
    
     <div class="modal fade " id="myModal">
        <div class="panel panel-info" style="width: 100%">
            <div class="panel-heading">
                <div class="modal-title text-center h1 ">
                    รายละเอียด ใบนัดรับพิจารณา<button type="button" class="btn btn-default pull-right" data-dismiss="modal">Close</button>
                </div>
                <div class="panel-body panel-info" style="width: 100%">

                    <iframe id="f1" style="width: 100%; height: 600px;"></iframe>

                </div>
            </div>
        </div>
    </div>
             <asp:Button ID="btn_reload" runat="server" Text="" style="display:none;"  />

</asp:Content>