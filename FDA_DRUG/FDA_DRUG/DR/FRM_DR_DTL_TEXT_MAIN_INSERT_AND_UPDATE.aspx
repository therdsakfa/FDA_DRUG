<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_DR_DTL_TEXT_MAIN_INSERT_AND_UPDATE.aspx.vb" Inherits="FDA_DRUG.FRM_DR_DTL_TEXT_MAIN_INSERT_AND_UPDATE" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../css/css_radgrid.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel" style="width:100%">
        <div class="panel-heading panel-title">
                <h1>ผลิตภัณฑ์</h1>
            </div>
        <table class="table" style="width:100%;">
            <tr>
                <td align="right">
                    ชื่อผลิตภัณฑ์
                    <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                    </telerik:RadScriptManager>
                </td>
                <td>
                    <asp:TextBox ID="txt_name_product" runat="server"></asp:TextBox>
                </td>
                <td align="right">
                    เลขทะเบียน
                </td>
                <td>
                    <asp:TextBox ID="txt_lcnno" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btn_search" runat="server" Text="ค้นหา" CssClass="btn-lg" />
                </td>
            </tr>
            <tr>
                <td align="right" colspan="5">
                    <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="5">
                        <ClientSettings Selecting-AllowRowSelect="true" EnablePostBackOnRowClick="true"></ClientSettings>
                        <ClientSettings EnableRowHoverStyle="true">
                            <Selecting AllowRowSelect="true" />
                        </ClientSettings>
                        <MasterTableView>
                            <Columns>
                                <telerik:GridCheckBoxColumn UniqueName="chk">

                                </telerik:GridCheckBoxColumn>
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                    SortExpression="IDA" UniqueName="IDA" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="Newcode" FilterControlAltText="Filter Newcode column" HeaderText="Newcode"
                                    SortExpression="Newcode" UniqueName="Newcode" Display="false">
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="pvncd" FilterControlAltText="Filter pvncd column" HeaderText="pvncd"
                                    SortExpression="pvncd" UniqueName="pvncd" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="drgtpcd" FilterControlAltText="Filter drgtpcd column" HeaderText="drgtpcd"
                                    SortExpression="drgtpcd" UniqueName="drgtpcd" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="rgttpcd" FilterControlAltText="Filter rgttpcd column" HeaderText="rgttpcd"
                                    SortExpression="rgttpcd" UniqueName="rgttpcd" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="rgtno" FilterControlAltText="Filter rgtno column" HeaderText="rgtno"
                                    SortExpression="rgtno" UniqueName="rgtno" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="engdrgtpnm" FilterControlAltText="Filter engdrgtpnm column" HeaderText="engdrgtpnm"
                                    SortExpression="engdrgtpnm" UniqueName="engdrgtpnm" Display="false">
                                </telerik:GridBoundColumn>

                                <telerik:GridBoundColumn DataField="lcnno_display" FilterControlAltText="Filter lcnno_display column" HeaderText="เลขทะเบียน"
                                    SortExpression="lcnno_display" UniqueName="lcnno_display">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="thadrgnm" FilterControlAltText="Filter thadrgnm column" HeaderText="ชื่อผลิตภัณฑ์(ภาษาไทย)"
                                    SortExpression="thadrgnm" UniqueName="thadrgnm">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="engdrgnm" FilterControlAltText="Filter engdrgnm column" HeaderText="ชื่อผลิตภัณฑ์(ภาษาอังกฤษ)"
                                    SortExpression="engdrgnm" UniqueName="engdrgnm">
                                </telerik:GridBoundColumn>
                                
                                <%--<telerik:GridBoundColumn DataField="rgttpcd" FilterControlAltText="Filter rgttpcd column" HeaderText="rgttpcd"
                                    SortExpression="rgttpcd" UniqueName="rgttpcd">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="engdrgtpnm" FilterControlAltText="Filter engdrgtpnm column" HeaderText="วงเล็บ"
                                    SortExpression="engdrgtpnm" UniqueName="engdrgtpnm">
                                </telerik:GridBoundColumn>--%>
                            </Columns>
                        </MasterTableView>
                    </telerik:RadGrid>
                </td>
            </tr>
            <tr>
            <td colspan="5">
              <table width="100%">
                  <tr>
                      <td align="right">
                          ชื่อผลิตภัณฑ์ :
                      </td>
                      <td>
                          <asp:Label ID="lbl_product_name" runat="server" Text="-"></asp:Label>
                      </td>
                      <td align="right">
                          เลขทะเบียน :
                      </td>
                      <td>
                          <asp:Label ID="lbl_lcnno_display" runat="server" Text="-"></asp:Label>
                      </td>

                      <td align="right">
                          rgttpcd :
                      </td>
                      <td>
                          <asp:Label ID="lbl_rgttpcd" runat="server" Text="-"></asp:Label>
                      </td>
                       <td align="right">
                          วงเล็บ :
                      </td>
                      <td>
                          <asp:Label ID="lbl_engdrgtpnm" runat="server" Text="-"></asp:Label>
                      </td>
                  </tr>
              </table>

                </td>
            </tr>
            <tr>
                <td colspan="5">
                   <table width="100%">
                       <tr>
                           <td>
                               1.ข้อบ่งใช้</td>
                           <td width="75%">
                               <asp:TextBox ID="txt_dtl" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

                           </td>
                       </tr>
                       <tr>
                           <td>
                               2.ขนาดบรรจุ
                           </td>
                           <td width="75%">
                               <asp:TextBox ID="txt_pcksize" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

                           </td>
                       </tr>
                       <%--<tr>
                           <td>
                               3.รูปแบบการเก็บรักษา</td>
                           <td width="75%">
                               &nbsp;</td>
                       </tr>
                       <tr>
                           <td>
                               3.1 อายุการใช้งาน</td>
                           <td width="75%">
                               <asp:TextBox ID="txt_useage" runat="server"></asp:TextBox>
&nbsp;เดือน</td>
                       </tr>
                       <tr>
                           <td>
                               3.2 ช่วงอุณหภูมิ</td>
                           <td width="75%">
                               <asp:TextBox ID="txt_tplow" runat="server"></asp:TextBox>
&nbsp;ถึง
                               <asp:TextBox ID="txt_tphigh" runat="server"></asp:TextBox>

                           </td>
                       </tr>
                       <tr>
                           <td>
                               3.3 สภาวะการเก็บรักษา</td>
                           <td width="75%">
                               <asp:TextBox ID="txt_keepdesc" runat="server" TextMode="MultiLine" Width="100%" Height="200px"></asp:TextBox>

                           </td>
                       </tr>
                       <tr>
                           <td>
                               &nbsp;</td>
                           <td width="75%">
                               &nbsp;</td>
                       </tr>--%>
                       <tr>
                           <td colspan="2" align="center">
                               <asp:Button ID="btn_save" runat="server" Text="บันทึก" CssClass="btn-lg" />

                           </td>
                       </tr>
                   </table>
                </td>
            </tr>
        </table>
        </div>
</asp:Content>
