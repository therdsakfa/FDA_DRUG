<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="POPUP_E_TRACKING_STOP_TIME.aspx.vb" Inherits="FDA_DRUG.POPUP_E_TRACKING_STOP_TIME" %>
<%@ Register assembly="Telerik.Web.UI" namespace="Telerik.Web.UI" tagprefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../../Scripts/jquery-1.8.2.js"></script>
    <link href="../../css/smoothness/jquery-ui-1.7.2.custom.css" rel="stylesheet" />
    <link href="../../css/smoothness/jquery2.custom.css" rel="stylesheet" />
    <script src="../../Jsdate/ui.datepicker-th.js"></script>
    <script src="../../Jsdate/ui.datepicker.js"></script>
    <script src="../../Jsdate/Jsdatemain.js"></script>
     <script type="text/javascript">
         $(document).ready(function () {
             showdate($("#ContentPlaceHolder1_txt_end_date_det"));
             showdate($("#ContentPlaceHolder1_txt_start_date_det"));
             showdate($("#ContentPlaceHolder1_txt_START_DATE_COUNT"));
             showdate($("#ContentPlaceHolder1_txt_END_DATE_COUNT"));
         });
         </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="table">
        <tr>
            <td align="center" >
                <h1>
รายงานสรุประยะเวลาที่ใช้ในการพิจารณาคำขอ</h1>
            </td>
        </tr>
    </table>
    <table class="table">
        <tr>
            <td align="right">
                <table class="table">
                    <tr>
                        <td align="right">
                            ช่วงเวลา
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_period" runat="server" Width="200px" AutoPostBack="True"></asp:DropDownList>
                        </td>
                        <td align="right">
                            ครั้งที่
                        </td>
                        <td>
                            <asp:DropDownList ID="ddl_period_count" runat="server">
                                <asp:ListItem Value="1">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                                <asp:ListItem Value="7">7</asp:ListItem>
                                <asp:ListItem Value="8">8</asp:ListItem>
                                <asp:ListItem Value="9">9</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="11">11</asp:ListItem>
                                <asp:ListItem Value="12">12</asp:ListItem>
                                <asp:ListItem Value="13">13</asp:ListItem>
                                <asp:ListItem Value="14">14</asp:ListItem>
                                <asp:ListItem Value="15">15</asp:ListItem>
                                <asp:ListItem Value="16">16</asp:ListItem>
                                <asp:ListItem Value="17">17</asp:ListItem>
                                <asp:ListItem Value="18">18</asp:ListItem>
                                <asp:ListItem Value="19">19</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Panel ID="Panel2" runat="server" style="display:none;">
                                <table class="table">
                                <tr>
                                    <td>
                                        <asp:Label ID="lbl_expert_type" runat="server" Text="ด้าน"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_expert_type" runat="server"></asp:DropDownList>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl_expert_count" runat="server" Text="คนที่"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddl_expert_count" runat="server">
                                            <asp:ListItem Value="1">1</asp:ListItem>
                                            <asp:ListItem Value="2">2</asp:ListItem>
                                            <asp:ListItem Value="3">3</asp:ListItem>
                                            <asp:ListItem Value="4">4</asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            </asp:Panel>
                            
                        </td>
                        
                        <td>
                            &nbsp;</td>
                    </tr>
                   <%-- <tr>
                        <td align="right">วันที่เริ่มหยุดเวลา</td>
                        <td align="left">
                            <asp:TextBox ID="txt_start_date_det" runat="server"></asp:TextBox>
                        </td>
                        <td align="right">วันที่เริมนับต่อ</td>
                        <td align="left">
                            <asp:TextBox ID="txt_end_date_det" runat="server"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>--%>
                    <tr>
                        <td align="center" colspan="6">&nbsp;
                        <asp:Button ID="btn_add" runat="server" CssClass="input-lg" Text="เพิ่มข้อมูล" /></td>
                    </tr>
                </table>
               

                <telerik:RadScriptManager ID="RadScriptManager1" Runat="server">
                </telerik:RadScriptManager>
            </td>
        </tr>
        <tr>
            <td>
 <telerik:RadGrid ID="RadGrid1" runat="server" AutoGenerateColumns="false" AllowPaging="true" PageSize="10" ShowFooter="true">
     <MasterTableView>
                            <Columns>
                                <telerik:GridBoundColumn DataField="IDA" DataType="System.Int32" FilterControlAltText="Filter IDA column" HeaderText="IDA"
                                    SortExpression="IDA" UniqueName="IDA" Display="false">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="PERIOD_DESCRIPTION" FilterControlAltText="Filter PERIOD_DESCRIPTION column" HeaderText="การผ่อนผันของ ผปก."
                                    SortExpression="PERIOD_DESCRIPTION" UniqueName="PERIOD_DESCRIPTION">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="START_DATE" FilterControlAltText="Filter START_DATE column" HeaderText="วันที่เริ่มหยุดเวลา"
                                    SortExpression="START_DATE" UniqueName="START_DATE" DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                                <telerik:GridBoundColumn DataField="END_DATE" FilterControlAltText="Filter END_DATE column" HeaderText="วันที่เวลาเริ่มนับต่อ"
                                    SortExpression="END_DATE" UniqueName="END_DATE" DataFormatString="{0:dd/MM/yyyy}">
                                </telerik:GridBoundColumn>
                                
                                <telerik:GridBoundColumn DataField="count_day" FilterControlAltText="Filter count_day column" HeaderText="จำนวนวันทำการ"
                                    SortExpression="count_day" UniqueName="count_day" Aggregate="Sum" FooterAggregateFormatString="รวม : {0:###,###.##}">
                                </telerik:GridBoundColumn>
                               <telerik:GridButtonColumn ButtonType="LinkButton" CommandName="_date" Text="เพิ่มหยุดเวลา" UniqueName="_date">
                               </telerik:GridButtonColumn>
                                <telerik:GridButtonColumn ButtonType="LinkButton" UniqueName="del" ConfirmText="คุณต้องการลบข้อมูลหรือไม่"
                                   CommandName="del" Text="ลบข้อมูล">
                                   <HeaderStyle Width="70px" />
                               </telerik:GridButtonColumn>
                                
                            </Columns>
                        </MasterTableView>
                </telerik:RadGrid>
     
            </td>
        </tr>
    </table>

</asp:Content>
