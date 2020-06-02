<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage/POPUP.Master" CodeBehind="FRM_E_TRACKING_TIME_CAL_POPUP2.aspx.vb" Inherits="FDA_DRUG.FRM_E_TRACKING_TIME_CAL_POPUP2" %>
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


             //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV4_Table1_dd_BudgetAdjust").searchable();
             //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV4_Table1_dd_CUSTOMER").searchable();
             //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_DetailV4_Table1_ddl_GL").searchable();
             //$("#ctl00_ContentPlaceHolder1_UC_CERTIFICATE_ALL_Detail1_dd_Province").searchable();
             //$("#ctl00_ContentPlaceHolder1_UC_Disburse_Budget_Detail1_txt_Bill_RECIEVE_DATE input").addClass("validate[required] text-input");

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
            <td align="right" style="width:25%;">
                ชื่อยา/เลขรับ
            </td>
            <td style="width:25%;">
                <asp:TextBox ID="txt_DRUG_NAME" runat="server" CssClass="input-sm" Width="100%"></asp:TextBox>
            </td>
            <td style="width:25%;">
                <asp:TextBox ID="txt_RCVNO_DISPLAY" runat="server" CssClass="input-sm" Width="100%"></asp:TextBox>
            </td>
            <td style="width:25%;"></td>
        </tr>
       <%-- <tr>
            <td align="right" style="width:25%;">
                เลขติดตาม</td>
            <td style="width:25%;">
                <asp:TextBox ID="txt_RCVNO_FOLLOW" runat="server" CssClass="input-sm" Width="100%"></asp:TextBox>
            </td>
            <td style="width:25%;">
                &nbsp;</td>
            <td style="width:25%;"></td>
        </tr>--%>
        <tr>
            <td align="right" style="width:25%;">
                กระบวนงาน&nbsp;</td>
            <td style="width:25%;">
                <asp:DropDownList ID="ddl_TYPE_REQUESTS" runat="server" CssClass="input-sm" Width="250px" AutoPostBack="True">
                </asp:DropDownList>
            </td>
            <td style="width:25%;">
                &nbsp;</td>
            <td style="width:25%;"></td>
        </tr>
        <tr>
            <td align="right" style="width:25%;">
                วันเริ่มนับเวลา</td>
            <td colspan="3">
                <table>
                    <tr>
                        <td>
<asp:TextBox ID="txt_START_DATE_COUNT" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
                        </td>
                        <td>
                            วันที่อนุญาต
                        </td>
                        <td>
                            <asp:TextBox ID="txt_END_DATE_COUNT" runat="server" CssClass="input-sm" Width="200px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                
            </td>
        </tr>
        <tr>
            <td align="center" colspan="2">
                ระยะเวลาที่คาดหวัง (วันทำการ)
                <br />
                [= ระยะเวลาตามประกาศ + ระยะเวลาที่ขยายเพิ่ม ]</td>
            <td colspan="2" align="center">

                ระยะเวลาที่ใช้จริง (วันทำการ)
                <br />
                [= ระยะเวลารวมทั้งหมด - ระยะเวลาที่หยุดเวลา]</td>
        </tr>
        <tr>
            <td align="right" colspan="2">
                <asp:TextBox ID="txt_DAY_FIXED" runat="server" CssClass="input-sm" Width="100%"></asp:TextBox>
            </td>
            <td colspan="2">

                <asp:TextBox ID="txt_REAL_DAY_USE" runat="server" CssClass="input-sm" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center">
                ระยะเวลาตามประกาศ
                <br />
                (วันทำการ)</td>
            <td align="center">

                ระยะเวลาที่ขยายเพิ่ม
                <br />
                (วันทำการ)</td>
            <td align="center">
                ระยะเวลารวมทั้งหมด
                <br />
                (วันทำการ)</td>
            <td align="center">

                ระยะเวลาที่หยุดเวลา
                <br />
                (วันทำการ)</td>
        </tr>
        <tr>
            <td align="center">
                <asp:TextBox ID="txt_DAY_FIXED_CAL" runat="server" CssClass="input-sm" Width="100%"></asp:TextBox>
            </td>
            <td align="center">
                <asp:TextBox ID="txt_DAY_EXPAND_CAL" runat="server" CssClass="input-sm" Width="100%"></asp:TextBox>
                </td>
            <td align="center">
                <asp:TextBox ID="txt_DAY_ALL_CAL" runat="server" CssClass="input-sm" Width="100%"></asp:TextBox>
                </td>
            <td align="center">
                <asp:TextBox ID="txt_DAY_STOP_CAL" runat="server" CssClass="input-sm" Width="100%"></asp:TextBox>
                </td>
        </tr>
        <tr>
            <td align="right">
                จำนวนรอบที่ใช้ประเมิน</td>
            <td align="center">
                <asp:TextBox ID="txt_ROUND_COUNT" runat="server" CssClass="input-sm" Width="100%"></asp:TextBox>
            </td>
            <td align="center">
                ระยะเวลาที่ขยาย
                <br />
                ต่อรอบการประเมิน</td>
            <td align="center">
                <asp:TextBox ID="txt_DAY_EXPAND_PER_ROUND" runat="server" CssClass="input-sm" Width="100%"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4">
                <asp:Button ID="btn_save" runat="server" Text="บันทึกข้อมูล" CssClass="btn-lg" />
                <asp:Button ID="btn_edit" runat="server" Text="แก้ไขข้อมูล" CssClass="btn-lg" style="display:none;"/>
            </td>
        </tr>
    </table>
    <asp:Panel ID="Panel1" runat="server" style="display:none;" >
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
                    <tr>
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
                    </tr>
                    <tr>
                        <td align="center" colspan="5">&nbsp;
                        <asp:Button ID="btn_add" runat="server" CssClass="input-lg" Text="เพิ่มข้อมูล" /></td>
                        <asp:Button ID="btn_report" runat="server" CssClass="input-lg" Text="พิมพ์รายงาน" />
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
    </asp:Panel>
    
    </asp:Content>