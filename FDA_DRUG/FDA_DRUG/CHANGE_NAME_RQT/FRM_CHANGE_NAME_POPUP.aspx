<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_CHANGE_NAME_POPUP.aspx.vb" Inherits="FDA_DRUG.FRM_CHANGE_NAME_POPUP" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
            <div class="panel-heading panel-title">
                <h2>คำขอเปลี่ยนแปลงชื่อผู้รับอนุญาตตามกรมการปกครอง/กรมพัฒนาธุรกิจ</h2>
            </div>
            <div class="panel-body">
                <table>
                    <tr>
                        <td>
                            ชื่อผู้รับอนุญาต 
                        </td>
                        <td>
                            <asp:Label ID="lbl_oldname" runat="server" Text="-"></asp:Label>
                        </td>
                    </tr>
                </table>


                รายการใบอนุญาตสถานที่ด้านยา
                <telerik:RadGrid ID="RadGrid1" runat="server" AllowPaging="true" PageSize="15">
                    <MasterTableView AutoGenerateColumns="False">
                        <Columns>
                            <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                SortExpression="IDA" UniqueName="IDA" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="lcnno_no" FilterControlAltText="Filter lcnno_no column"
                                HeaderText="เลขใบอนุญาต" SortExpression="lcnno_no" UniqueName="lcnno_no">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>

                <br />
                รายการผลิตภัณฑ์
               <telerik:RadGrid ID="RadGrid2" runat="server" AllowPaging="true" PageSize="15">
                    <MasterTableView AutoGenerateColumns="False">
                        <Columns>
                            <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                SortExpression="IDA" UniqueName="IDA" Display="false">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="register" FilterControlAltText="Filter register column"
                                HeaderText="เลขทะเบียน" SortExpression="register" UniqueName="register">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column"
                                HeaderText="ชื่อยาภาษาไทย" SortExpression="thadrgnm" UniqueName="thadrgnm">
                            </telerik:GridBoundColumn>
                             <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column"
                                HeaderText="ชื่อยาภาษาอังกฤษ" SortExpression="engdrgnm" UniqueName="engdrgnm">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <br />
                *หากรายการผลิตภัณฑ์ไม่ครบ กรุณาติดต่อ drug-smarthelp@fda.moph.go.th
            </div>
              <div class="panel-footer " style="text-align:center;">
                  <asp:Button ID="Button1" runat="server" Text="ยื่นคำขอ" CssClass="btn-lg" OnClientClick="return confirm('ต้องการยื่นคำขอหรือไม่');" />
                  &nbsp;&nbsp;
                  <asp:Button ID="Button2" runat="server" Text="ปิดหน้าต่างนี้"  CssClass="btn-lg"/>
              </div>
        </div>
</asp:Content>
